using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MoldOffsetRecord
{
    public partial class PM1Form : UserControl
    {
        private FtpDownloader _ftpDownloader;
        private MaintnanceForm m_Parent;        

        public PM1Form(MaintnanceForm parent)
        {                 
            InitializeComponent();

            m_Parent = parent;

            _ftpDownloader = new FtpDownloader();

            _deviceComboBox.Items.AddRange(new string[] { "Kaanapali", "Marlin", "Monaco", "Stanza" });
        }

        private void PM1Form_Load(object sender, EventArgs e)
        {
            Width = 1544;
            Height = 1011;
            Top = 0;
            Left = 0;

            _pointChart_Init();
        }

        private void SetDoubleBuffered(Control control, bool doubleBuffered = true)
        {
            PropertyInfo propertyInfo = typeof(Control).GetProperty
            (
                "DoubleBuffered",
                BindingFlags.Instance | BindingFlags.NonPublic
            );
            propertyInfo.SetValue(control, doubleBuffered, null);
        }

        private void _pointChart_Init()
        {
            _pointChart.ChartAreas[0].AxisX.Interval = 1;
            _pointChart.ChartAreas[0].AxisX.Minimum = 0;
            _pointChart.ChartAreas[0].AxisX.Maximum = 15;

            _pointChart.ChartAreas[0].AxisY.Interval = 0.01;
            _pointChart.ChartAreas[0].AxisY.Minimum = -0.15;
            _pointChart.ChartAreas[0].AxisY.Maximum = 0.15;

            _pointChart.Series["X"].BorderWidth = 2;
            _pointChart.Series["X"].Color = Color.Red;

            _pointChart.Series["Y"].BorderWidth = 2;
            _pointChart.Series["Y"].Color = Color.Blue;
        }

        public void Display()
        {
            SetDoubleBuffered(_listBox);
            SetDoubleBuffered(_dataGridView);
        }

        private void _searchButton_Click(object sender, EventArgs e)
        {
            if (_deviceComboBox.SelectedItem == null)
            {                
                MessageBox.Show("Device를 선택하세요", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DateTime selectedDate = _monthCalendar.SelectionStart;
            string formattedDate = selectedDate.ToString("yyyyMMdd");
            string devicePrefix = GetDevicePrefix(_deviceComboBox.SelectedItem.ToString());
            // 날짜와 Device 조건으로 파일 로드
            LoadCsvFilesFromFtp(devicePrefix, formattedDate);
        }

        private string GetDevicePrefix(string device)
        {
            switch (device)
            {
                case "Kaanapali":
                    return "NNN";

                case "Marlin":
                    return "TTT";

                case "Monaco":
                    return "AAA";

                case "Stanza":
                    return "SSS";

                default:
                    return string.Empty;
            }
        }
        
        private void LoadCsvFilesFromFtp(string prefix, string date)
        {
            try
            {
                string ftpFolderPath = $"{_ftpDownloader._ftpAddress}";
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpFolderPath);
                request.Method = WebRequestMethods.Ftp.ListDirectory;
                request.Credentials = new NetworkCredential(_ftpDownloader._ftpUser, _ftpDownloader._ftpPassword);
                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    _listBox.Items.Clear();
                    string line;
                    bool fileFound = false;     // 파일이 발견되었는지 여부를 추적
                    while ((line = reader.ReadLine()) != null)
                    {
                        // 파일명이 devicePrefix로 시작하고, 날짜를 포함하는 경우에만 추가
                        if (line.StartsWith(prefix) && line.Contains(date) && line.EndsWith(".csv"))
                        {
                            _listBox.Items.Add(line);
                            fileFound = true;   // 파일을 발견했음을 표시
                        }
                    }

                    // 조건에 맞는 파일이 없으면 메시지 박스 표시
                    if (!fileFound)
                    {
                        MessageBox.Show("조건에 맞는 파일이 없습니다", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"FTP서버 파일 로드 중 오류 발생 : {ex.Message}", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_listBox.SelectedItem == null) 
                return;

            string selectedFile = _listBox.SelectedItem.ToString();
            string localFilePath = Path.Combine(Global.searchFileDirectory, selectedFile);
            // FTP 서버에서 로컬 디렉토리로 CSV 파일 다운로드
            DownloadCsvFileFromFtp(selectedFile, localFilePath);
            
            // CSV 파일 내용을 DataGridView에 로드
            LoadCsvDataToGrid(localFilePath);

            // Chart 그리기
            PlotChart(localFilePath);
        }

        private void DownloadCsvFileFromFtp(string fileName, string localFilePath)
        {
            try
            {
                string ftpFilePath = $"{_ftpDownloader._ftpAddress}/{fileName}";
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpFilePath);
                request.Method = WebRequestMethods.Ftp.DownloadFile;
                request.Credentials = new NetworkCredential(_ftpDownloader._ftpUser, _ftpDownloader._ftpPassword);
                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                using (Stream responseStream = response.GetResponseStream())
                using (FileStream fileStream = new FileStream(localFilePath, FileMode.Create))
                {
                    responseStream.CopyTo(fileStream);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"CSV 파일 다운로드 중 오류 발생 : {ex.Message}", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCsvDataToGrid(string filePath)
        {
            try
            {
                var dataTable = new DataTable();                
                // 열 제목 추가
                dataTable.Columns.Add("Column1", typeof(string));
                for (int i = 2; i <= 15; i++)
                {
                    dataTable.Columns.Add($"Column{i}", typeof(string));
                }

                // 첫 번째 행 : 제목
                var row1 = dataTable.NewRow();
                row1["Column1"] = "Lot#";
                row1["Column2"] = "Strip ID";
                row1["Column3"] = "Time";
                row1["Column4"] = "L/R";
                dataTable.Rows.Add(row1);
                
                // CSV 파일 내용 읽기
                string[] lines = File.ReadAllLines(filePath);                
                // 두 번째 행 : CSV 파일에서 해당 값 가져오기
                var row2 = dataTable.NewRow();
                row2["Column1"] = lines.First(l => l.StartsWith("LOT#")).Split(',')[1];
                row2["Column2"] = lines.First(l => l.StartsWith("STRIP ID")).Split(',')[1];
                row2["Column3"] = Path.GetFileNameWithoutExtension(filePath).Split('_')[1];
                row2["Column4"] = lines.First(l => l.StartsWith("Left/Right")).Split(',')[1];
                dataTable.Rows.Add(row2);
                
                // 세 번째 행 : 제목 (Point, 1, 2, ..., 14)
                var row3 = dataTable.NewRow();
                row3["Column1"] = "Point";
                for (int i = 2; i <= 15; i++)
                {
                    row3[$"Column{i}"] = (i - 1).ToString();                    
                }
                dataTable.Rows.Add(row3);

                // 네 번째 행 : "X" 제목
                var row4 = dataTable.NewRow();
                row4["Column1"] = "X";
                dataTable.Rows.Add(row4);
                
                // 다섯 번째 행 : "Y" 제목
                var row5 = dataTable.NewRow();
                row5["Column1"] = "Y";
                dataTable.Rows.Add(row5);
                
                // CSV 파일에서 Distance X, Y값을 가져와서 추가
                int colIndex = 2;   // Column2부터 시작                
                string[] strValue = new string[3];
                for (int i = 7; i < lines.Length; i++)
                {
                    strValue = lines[i].Split(',');
                    row4[$"Column{colIndex}"] = strValue[1];  // X값
                    row5[$"Column{colIndex}"] = strValue[2];  // Y값                    
                    colIndex++;
                }

                _dataGridView.DataSource = dataTable;

                // DataGridView 열 정렬 비활성화
                foreach (DataGridViewColumn column in _dataGridView.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                    column.Width = 85;
                }
                
                // 제목 행의 배경색
                _dataGridView.Rows[0].DefaultCellStyle.BackColor = Color.PaleTurquoise;
                _dataGridView.Rows[2].DefaultCellStyle.BackColor = Color.Cornsilk;                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"CSV 파일 로드 중 오류 발생 : {ex.Message}", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PlotChart(string filePath)
        {
            try
            {
                // Chart clear
                _pointChart.Series["X"].Points.Clear();
                _pointChart.Series["Y"].Points.Clear();

                string[] lines = File.ReadAllLines(filePath);
                int pointIndex = 1;
                string[] strValue = new string[3];
                for (int i = 7; i < lines.Length; i++)
                {
                    strValue = lines[i].Split(',');
                    double xValue = double.Parse(strValue[1]);
                    double yValue = double.Parse(strValue[2]);                    
                    
                    // Chart에 데이터 추가 (X값)
                    DataPoint xDataPoint = new DataPoint(pointIndex, xValue)
                    {
                        Label = xValue.ToString()   // X값 라벨 설정
                    };
                    _pointChart.Series["X"].Points.Add(xDataPoint);

                    // Chart에 데이터 추가 (Y값)
                    DataPoint yDataPoint = new DataPoint(pointIndex, yValue)
                    {
                        Label = yValue.ToString()   // Y값 라벨 설정
                    };
                    _pointChart.Series["Y"].Points.Add(yDataPoint);
                    pointIndex++;
                }

                // Chart를 새로 고침해서 그리기
                _pointChart.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Chart 데이터를 그리는 중 오류 발생 : {ex.Message}", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _excelDownloadButton_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel Files|*.xlsx";
                saveFileDialog.Title = "저장할 위치를 선택하세요";
                saveFileDialog.FileName = "Audio Offset";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {                    
                    string remoteFileName = Path.GetFileName(saveFileDialog.FileName);                                                                     
                    string remoteFilePath = $"{_ftpDownloader._ftpIP}{_ftpDownloader._ftpExcelFileFolder}/{remoteFileName}";
                    DownloadFile(remoteFilePath, saveFileDialog.FileName);                    
                }
            }
        }

        private void DownloadFile(string remoteFileName, string localFilePath)
        {
            try
            {                
                string ftpFilePath = $"{remoteFileName}";
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpFilePath);
                request.Method = WebRequestMethods.Ftp.DownloadFile;
                request.Credentials = new NetworkCredential(_ftpDownloader._ftpUser, _ftpDownloader._ftpPassword);
                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                using (Stream responseStream = response.GetResponseStream())
                using (FileStream fileStream = new FileStream(localFilePath, FileMode.Create))
                {
                    responseStream.CopyTo(fileStream);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Excel파일 다운로드 중 오류 발생 : {ex.Message}", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
