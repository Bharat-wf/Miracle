namespace WNFMaintenance
{
    partial class frm_DashboardSales
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rBtnYear = new System.Windows.Forms.RadioButton();
            this.rBtnDaily = new System.Windows.Forms.RadioButton();
            this.rBtnMonth = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbZone = new System.Windows.Forms.ComboBox();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rBtn20Cust = new System.Windows.Forms.RadioButton();
            this.rBtnPeriod = new System.Windows.Forms.RadioButton();
            this.rBtnCustomer = new System.Windows.Forms.RadioButton();
            this.cmbFY = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(13, 97);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Sales";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(948, 394);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(361, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(248, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Interactive Dashboard - Sales";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.rBtnYear);
            this.panel1.Controls.Add(this.rBtnDaily);
            this.panel1.Controls.Add(this.rBtnMonth);
            this.panel1.Location = new System.Drawing.Point(762, 53);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(197, 38);
            this.panel1.TabIndex = 5;
            // 
            // rBtnYear
            // 
            this.rBtnYear.AutoSize = true;
            this.rBtnYear.Checked = true;
            this.rBtnYear.Location = new System.Drawing.Point(12, 10);
            this.rBtnYear.Name = "rBtnYear";
            this.rBtnYear.Size = new System.Drawing.Size(54, 17);
            this.rBtnYear.TabIndex = 7;
            this.rBtnYear.TabStop = true;
            this.rBtnYear.Text = "Yearly";
            this.rBtnYear.UseVisualStyleBackColor = true;
            this.rBtnYear.Click += new System.EventHandler(this.rBtnYear_Click);
            // 
            // rBtnDaily
            // 
            this.rBtnDaily.AutoSize = true;
            this.rBtnDaily.Location = new System.Drawing.Point(134, 10);
            this.rBtnDaily.Name = "rBtnDaily";
            this.rBtnDaily.Size = new System.Drawing.Size(48, 17);
            this.rBtnDaily.TabIndex = 6;
            this.rBtnDaily.Text = "Daily";
            this.rBtnDaily.UseVisualStyleBackColor = true;
            this.rBtnDaily.Click += new System.EventHandler(this.rBtnDaily_Click);
            // 
            // rBtnMonth
            // 
            this.rBtnMonth.AutoSize = true;
            this.rBtnMonth.Location = new System.Drawing.Point(66, 10);
            this.rBtnMonth.Name = "rBtnMonth";
            this.rBtnMonth.Size = new System.Drawing.Size(62, 17);
            this.rBtnMonth.TabIndex = 5;
            this.rBtnMonth.Text = "Monthly";
            this.rBtnMonth.UseVisualStyleBackColor = true;
            this.rBtnMonth.Click += new System.EventHandler(this.rBtnMonth_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(12, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Zone";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(12, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Customer";
            // 
            // cmbZone
            // 
            this.cmbZone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbZone.FormattingEnabled = true;
            this.cmbZone.Location = new System.Drawing.Point(85, 47);
            this.cmbZone.Name = "cmbZone";
            this.cmbZone.Size = new System.Drawing.Size(132, 21);
            this.cmbZone.TabIndex = 17;
            this.cmbZone.SelectedIndexChanged += new System.EventHandler(this.cmbZone_SelectedIndexChanged);
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(85, 70);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(305, 21);
            this.cmbCustomer.TabIndex = 18;
            this.cmbCustomer.SelectedIndexChanged += new System.EventHandler(this.cmbCustomer_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.rBtn20Cust);
            this.panel2.Controls.Add(this.rBtnPeriod);
            this.panel2.Controls.Add(this.rBtnCustomer);
            this.panel2.Location = new System.Drawing.Point(434, 53);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(322, 38);
            this.panel2.TabIndex = 19;
            // 
            // rBtn20Cust
            // 
            this.rBtn20Cust.AutoSize = true;
            this.rBtn20Cust.Checked = true;
            this.rBtn20Cust.Location = new System.Drawing.Point(7, 9);
            this.rBtn20Cust.Name = "rBtn20Cust";
            this.rBtn20Cust.Size = new System.Drawing.Size(111, 17);
            this.rBtn20Cust.TabIndex = 10;
            this.rBtn20Cust.TabStop = true;
            this.rBtn20Cust.Text = "Top 20 Customers\r\n";
            this.rBtn20Cust.UseVisualStyleBackColor = true;
            this.rBtn20Cust.Click += new System.EventHandler(this.rBtn20Cust_Click);
            // 
            // rBtnPeriod
            // 
            this.rBtnPeriod.AutoSize = true;
            this.rBtnPeriod.Location = new System.Drawing.Point(236, 9);
            this.rBtnPeriod.Name = "rBtnPeriod";
            this.rBtnPeriod.Size = new System.Drawing.Size(82, 17);
            this.rBtnPeriod.TabIndex = 9;
            this.rBtnPeriod.Text = "Period Wise";
            this.rBtnPeriod.UseVisualStyleBackColor = true;
            this.rBtnPeriod.Click += new System.EventHandler(this.rBtnPeriod_Click);
            // 
            // rBtnCustomer
            // 
            this.rBtnCustomer.AutoSize = true;
            this.rBtnCustomer.Location = new System.Drawing.Point(129, 10);
            this.rBtnCustomer.Name = "rBtnCustomer";
            this.rBtnCustomer.Size = new System.Drawing.Size(96, 17);
            this.rBtnCustomer.TabIndex = 8;
            this.rBtnCustomer.Text = "Customer Wise";
            this.rBtnCustomer.UseVisualStyleBackColor = true;
            this.rBtnCustomer.Click += new System.EventHandler(this.rBtnCustomer_Click);
            // 
            // cmbFY
            // 
            this.cmbFY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFY.FormattingEnabled = true;
            this.cmbFY.Location = new System.Drawing.Point(827, 26);
            this.cmbFY.Name = "cmbFY";
            this.cmbFY.Size = new System.Drawing.Size(132, 21);
            this.cmbFY.TabIndex = 21;
            this.cmbFY.SelectedIndexChanged += new System.EventHandler(this.cmbFY_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(759, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 15);
            this.label4.TabIndex = 20;
            this.label4.Text = "Fin. Year";
            // 
            // frm_DashboardSales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 502);
            this.Controls.Add(this.cmbFY);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.cmbCustomer);
            this.Controls.Add(this.cmbZone);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chart1);
            this.Name = "frm_DashboardSales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Interactive Dashboard - Sales";
            this.Load += new System.EventHandler(this.frm_DashboardSales_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rBtnYear;
        private System.Windows.Forms.RadioButton rBtnDaily;
        private System.Windows.Forms.RadioButton rBtnMonth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbZone;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rBtnCustomer;
        private System.Windows.Forms.RadioButton rBtnPeriod;
        private System.Windows.Forms.RadioButton rBtn20Cust;
        private System.Windows.Forms.ComboBox cmbFY;
        private System.Windows.Forms.Label label4;
    }
}