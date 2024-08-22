using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace MoldOffsetRecord
{
    public partial class ConfigureForm : Form
    {
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        public ConfigureForm()
        {
            InitializeComponent();
        }

        private void ConfigureForm_Load(object sender, EventArgs e)
        {
            Width = 1544;
            Height = 1011;
            Top = 0;
            Left = 0;            
        }

        private void ConfigureForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Dispose();
        }        
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(txtBoxTimeInterval.Text.ToString().Trim(), out int iTime))
                {
                    WritePrivateProfileString("Time", "Interval", iTime.ToString(), string.Format("{0}{1}", Global.ConfigurePath, "Setting.ini"));
                    
                    MessageBox.Show("설정 파라미터 저장 완료", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
                _PARAMETER_LOAD();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"설정 파라미터 저장 중 오류 발생 : {ex.Message}", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _PARAMETER_LOAD()
        {
            try
            {
                // Ini file read
                StringBuilder sbTimeInterval = new StringBuilder();
                GetPrivateProfileString("Time", "Interval", "", sbTimeInterval, sbTimeInterval.Capacity, string.Format("{0}{1}", Global.ConfigurePath, "Setting.ini"));
                if (int.TryParse(sbTimeInterval.ToString().Trim(), out int iTime))
                    Define.iTimeInterval = iTime;

                txtBoxTimeInterval.Text = iTime.ToString().Trim();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"설정 파라미터 로드 중 오류 발생 : {ex.Message}", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
