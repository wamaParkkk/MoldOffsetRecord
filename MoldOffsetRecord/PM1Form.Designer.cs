﻿
namespace MoldOffsetRecord
{
    partial class PM1Form
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this._monthCalendar = new System.Windows.Forms.MonthCalendar();
            this._deviceComboBox = new System.Windows.Forms.ComboBox();
            this._searchButton = new System.Windows.Forms.Button();
            this._listBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this._dataGridView = new System.Windows.Forms.DataGridView();
            this._pointChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._pointChart)).BeginInit();
            this.SuspendLayout();
            // 
            // _monthCalendar
            // 
            this._monthCalendar.Location = new System.Drawing.Point(10, 35);
            this._monthCalendar.Name = "_monthCalendar";
            this._monthCalendar.TabIndex = 0;
            // 
            // _deviceComboBox
            // 
            this._deviceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._deviceComboBox.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this._deviceComboBox.FormattingEnabled = true;
            this._deviceComboBox.Location = new System.Drawing.Point(234, 36);
            this._deviceComboBox.Name = "_deviceComboBox";
            this._deviceComboBox.Size = new System.Drawing.Size(218, 24);
            this._deviceComboBox.TabIndex = 1;
            // 
            // _searchButton
            // 
            this._searchButton.BackColor = System.Drawing.Color.PaleGreen;
            this._searchButton.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this._searchButton.Location = new System.Drawing.Point(322, 137);
            this._searchButton.Name = "_searchButton";
            this._searchButton.Size = new System.Drawing.Size(130, 60);
            this._searchButton.TabIndex = 2;
            this._searchButton.Text = "검색";
            this._searchButton.UseVisualStyleBackColor = false;
            this._searchButton.Click += new System.EventHandler(this._searchButton_Click);
            // 
            // _listBox
            // 
            this._listBox.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this._listBox.FormattingEnabled = true;
            this._listBox.ItemHeight = 16;
            this._listBox.Location = new System.Drawing.Point(10, 209);
            this._listBox.Name = "_listBox";
            this._listBox.Size = new System.Drawing.Size(442, 788);
            this._listBox.TabIndex = 3;
            this._listBox.SelectedIndexChanged += new System.EventHandler(this._listBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Plum;
            this.label1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "날짜 선택";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.PaleTurquoise;
            this.label2.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(234, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(218, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "Device 선택";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MintCream;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this._monthCalendar);
            this.panel1.Controls.Add(this._deviceComboBox);
            this.panel1.Controls.Add(this._listBox);
            this.panel1.Controls.Add(this._searchButton);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(464, 1005);
            this.panel1.TabIndex = 7;
            // 
            // _dataGridView
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this._dataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this._dataGridView.BackgroundColor = System.Drawing.Color.White;
            this._dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._dataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this._dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridView.ColumnHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this._dataGridView.Location = new System.Drawing.Point(473, 3);
            this._dataGridView.Name = "_dataGridView";
            this._dataGridView.ReadOnly = true;
            this._dataGridView.RowHeadersWidth = 30;
            this._dataGridView.RowTemplate.Height = 23;
            this._dataGridView.Size = new System.Drawing.Size(1068, 400);
            this._dataGridView.TabIndex = 8;
            // 
            // _pointChart
            // 
            this._pointChart.BackColor = System.Drawing.Color.Cornsilk;
            chartArea1.Name = "ChartArea1";
            this._pointChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this._pointChart.Legends.Add(legend1);
            this._pointChart.Location = new System.Drawing.Point(473, 409);
            this._pointChart.Name = "_pointChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "X";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "Y";
            this._pointChart.Series.Add(series1);
            this._pointChart.Series.Add(series2);
            this._pointChart.Size = new System.Drawing.Size(1068, 591);
            this._pointChart.TabIndex = 9;
            this._pointChart.Text = "Point Chart";
            // 
            // PM1Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.Controls.Add(this._pointChart);
            this.Controls.Add(this._dataGridView);
            this.Controls.Add(this.panel1);
            this.Name = "PM1Form";
            this.Size = new System.Drawing.Size(1544, 1011);
            this.Load += new System.EventHandler(this.PM1Form_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._pointChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MonthCalendar _monthCalendar;
        private System.Windows.Forms.ComboBox _deviceComboBox;
        private System.Windows.Forms.Button _searchButton;
        private System.Windows.Forms.ListBox _listBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView _dataGridView;
        private System.Windows.Forms.DataVisualization.Charting.Chart _pointChart;
    }
}