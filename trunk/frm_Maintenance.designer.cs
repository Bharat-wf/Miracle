namespace WNFProduction
{
    partial class frm_Maintenance
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
            this.DtpDate = new System.Windows.Forms.DateTimePicker();
            this.CmbShift = new System.Windows.Forms.ComboBox();
            this.TxtShiftIncharge = new System.Windows.Forms.TextBox();
            this.CmbMaintType = new System.Windows.Forms.ComboBox();
            this.CmbMcType = new System.Windows.Forms.ComboBox();
            this.DGVEmpDetail = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.DGVMaintenanceHistory = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DGVEmpDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVMaintenanceHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // DtpDate
            // 
            this.DtpDate.CustomFormat = "dd/MMM/yyyy";
            this.DtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpDate.Location = new System.Drawing.Point(123, 23);
            this.DtpDate.Name = "DtpDate";
            this.DtpDate.Size = new System.Drawing.Size(116, 20);
            this.DtpDate.TabIndex = 0;
            this.DtpDate.ValueChanged += new System.EventHandler(this.DtpDate_ValueChanged);
            // 
            // CmbShift
            // 
            this.CmbShift.FormattingEnabled = true;
            this.CmbShift.Location = new System.Drawing.Point(319, 23);
            this.CmbShift.Name = "CmbShift";
            this.CmbShift.Size = new System.Drawing.Size(116, 21);
            this.CmbShift.TabIndex = 1;
            this.CmbShift.SelectedIndexChanged += new System.EventHandler(this.CmbShift_SelectedIndexChanged);
            // 
            // TxtShiftIncharge
            // 
            this.TxtShiftIncharge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtShiftIncharge.Location = new System.Drawing.Point(122, 49);
            this.TxtShiftIncharge.Name = "TxtShiftIncharge";
            this.TxtShiftIncharge.ReadOnly = true;
            this.TxtShiftIncharge.Size = new System.Drawing.Size(315, 20);
            this.TxtShiftIncharge.TabIndex = 2;
            // 
            // CmbMaintType
            // 
            this.CmbMaintType.FormattingEnabled = true;
            this.CmbMaintType.Items.AddRange(new object[] {
            "Preventive",
            "Breakdown",
            "Project",
            "Other"});
            this.CmbMaintType.Location = new System.Drawing.Point(124, 77);
            this.CmbMaintType.Name = "CmbMaintType";
            this.CmbMaintType.Size = new System.Drawing.Size(116, 21);
            this.CmbMaintType.TabIndex = 3;
            // 
            // CmbMcType
            // 
            this.CmbMcType.FormattingEnabled = true;
            this.CmbMcType.Items.AddRange(new object[] {
            "Loom",
            "Stretching Table",
            "Utility",
            "Other",
            "Warping Machine"});
            this.CmbMcType.Location = new System.Drawing.Point(321, 77);
            this.CmbMcType.Name = "CmbMcType";
            this.CmbMcType.Size = new System.Drawing.Size(114, 21);
            this.CmbMcType.TabIndex = 4;
            // 
            // DGVEmpDetail
            // 
            this.DGVEmpDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVEmpDetail.Location = new System.Drawing.Point(13, 113);
            this.DGVEmpDetail.Name = "DGVEmpDetail";
            this.DGVEmpDetail.Size = new System.Drawing.Size(346, 127);
            this.DGVEmpDetail.TabIndex = 5;
            this.DGVEmpDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVEmpDetail_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(251, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Shift";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Shift Incharge";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Type of Maintenance";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(246, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Machine Type";
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(367, 128);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(72, 36);
            this.BtnSave.TabIndex = 11;
            this.BtnSave.Text = "&Save";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(367, 178);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(69, 36);
            this.BtnCancel.TabIndex = 12;
            this.BtnCancel.Text = "&Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // DGVMaintenanceHistory
            // 
            this.DGVMaintenanceHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVMaintenanceHistory.Location = new System.Drawing.Point(12, 257);
            this.DGVMaintenanceHistory.Name = "DGVMaintenanceHistory";
            this.DGVMaintenanceHistory.Size = new System.Drawing.Size(425, 123);
            this.DGVMaintenanceHistory.TabIndex = 13;
            this.DGVMaintenanceHistory.DoubleClick += new System.EventHandler(this.DGVMaintenanceHistory_DoubleClick);
            // 
            // frm_Maintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 394);
            this.Controls.Add(this.DGVMaintenanceHistory);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DGVEmpDetail);
            this.Controls.Add(this.CmbMcType);
            this.Controls.Add(this.CmbMaintType);
            this.Controls.Add(this.TxtShiftIncharge);
            this.Controls.Add(this.CmbShift);
            this.Controls.Add(this.DtpDate);
            this.Name = "frm_Maintenance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Maintenance";
            this.Load += new System.EventHandler(this.Maintenance_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVEmpDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVMaintenanceHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker DtpDate;
        private System.Windows.Forms.ComboBox CmbShift;
        private System.Windows.Forms.TextBox TxtShiftIncharge;
        private System.Windows.Forms.ComboBox CmbMaintType;
        private System.Windows.Forms.ComboBox CmbMcType;
        private System.Windows.Forms.DataGridView DGVEmpDetail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.DataGridView DGVMaintenanceHistory;
    }
}