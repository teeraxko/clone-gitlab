namespace Presentation.AttendanceGUI
{
    partial class FrmGenEmpScheduleBase
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
            this.gpbEmployee = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.rdoSelectSome = new System.Windows.Forms.RadioButton();
            this.rdoSelectAll = new System.Windows.Forms.RadioButton();
            this.gpbCondition = new System.Windows.Forms.GroupBox();
            this.lblServiceStaffType = new System.Windows.Forms.Label();
            this.cboServiceStaffType = new System.Windows.Forms.ComboBox();
            this.gpbPositionType = new System.Windows.Forms.GroupBox();
            this.rdoService = new System.Windows.Forms.RadioButton();
            this.rdoOfficer = new System.Windows.Forms.RadioButton();
            this.cmdShow = new System.Windows.Forms.Button();
            this.dtpForMonth = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.ltbEmpListSelected = new System.Windows.Forms.ListBox();
            this.ltbEmpListCandidate = new System.Windows.Forms.ListBox();
            this.cmdRemoveAll = new System.Windows.Forms.Button();
            this.cmdRemove = new System.Windows.Forms.Button();
            this.cmdSelectAll = new System.Windows.Forms.Button();
            this.cmdSelect = new System.Windows.Forms.Button();
            this.lblSelected = new System.Windows.Forms.Label();
            this.lblCandidate = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.gpbEmployee.SuspendLayout();
            this.gpbCondition.SuspendLayout();
            this.gpbPositionType.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbEmployee
            // 
            this.gpbEmployee.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gpbEmployee.Controls.Add(this.label5);
            this.gpbEmployee.Controls.Add(this.rdoSelectSome);
            this.gpbEmployee.Controls.Add(this.rdoSelectAll);
            this.gpbEmployee.Controls.Add(this.gpbCondition);
            this.gpbEmployee.Controls.Add(this.gpbPositionType);
            this.gpbEmployee.Controls.Add(this.cmdShow);
            this.gpbEmployee.Controls.Add(this.dtpForMonth);
            this.gpbEmployee.Controls.Add(this.label2);
            this.gpbEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.gpbEmployee.Location = new System.Drawing.Point(59, 8);
            this.gpbEmployee.Name = "gpbEmployee";
            this.gpbEmployee.Size = new System.Drawing.Size(453, 112);
            this.gpbEmployee.TabIndex = 2;
            this.gpbEmployee.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label5.Location = new System.Drawing.Point(160, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "สำหรับ";
            // 
            // rdoSelectSome
            // 
            this.rdoSelectSome.AutoSize = true;
            this.rdoSelectSome.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.rdoSelectSome.Location = new System.Drawing.Point(287, 19);
            this.rdoSelectSome.Name = "rdoSelectSome";
            this.rdoSelectSome.Size = new System.Drawing.Size(103, 17);
            this.rdoSelectSome.TabIndex = 13;
            this.rdoSelectSome.Text = "พนักงานบางส่วน";
            this.rdoSelectSome.UseVisualStyleBackColor = true;
            this.rdoSelectSome.CheckedChanged += new System.EventHandler(this.rdoSelectSome_CheckedChanged);
            // 
            // rdoSelectAll
            // 
            this.rdoSelectAll.AutoSize = true;
            this.rdoSelectAll.Checked = true;
            this.rdoSelectAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.rdoSelectAll.Location = new System.Drawing.Point(200, 19);
            this.rdoSelectAll.Name = "rdoSelectAll";
            this.rdoSelectAll.Size = new System.Drawing.Size(99, 17);
            this.rdoSelectAll.TabIndex = 5;
            this.rdoSelectAll.TabStop = true;
            this.rdoSelectAll.Text = "พนักงานทั้งหมด";
            this.rdoSelectAll.UseVisualStyleBackColor = true;
            this.rdoSelectAll.CheckedChanged += new System.EventHandler(this.rdoSelectAll_CheckedChanged);
            // 
            // gpbCondition
            // 
            this.gpbCondition.Controls.Add(this.lblServiceStaffType);
            this.gpbCondition.Controls.Add(this.cboServiceStaffType);
            this.gpbCondition.Enabled = false;
            this.gpbCondition.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.gpbCondition.Location = new System.Drawing.Point(220, 48);
            this.gpbCondition.Name = "gpbCondition";
            this.gpbCondition.Size = new System.Drawing.Size(227, 56);
            this.gpbCondition.TabIndex = 11;
            this.gpbCondition.TabStop = false;
            this.gpbCondition.Text = "กำหนดเงื่อนไข";
            // 
            // lblServiceStaffType
            // 
            this.lblServiceStaffType.AutoSize = true;
            this.lblServiceStaffType.Location = new System.Drawing.Point(9, 25);
            this.lblServiceStaffType.Name = "lblServiceStaffType";
            this.lblServiceStaffType.Size = new System.Drawing.Size(116, 13);
            this.lblServiceStaffType.TabIndex = 12;
            this.lblServiceStaffType.Text = "ประเภทพนักงานบริการ";
            // 
            // cboServiceStaffType
            // 
            this.cboServiceStaffType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboServiceStaffType.Location = new System.Drawing.Point(113, 24);
            this.cboServiceStaffType.Name = "cboServiceStaffType";
            this.cboServiceStaffType.Size = new System.Drawing.Size(104, 21);
            this.cboServiceStaffType.TabIndex = 13;
            // 
            // gpbPositionType
            // 
            this.gpbPositionType.Controls.Add(this.rdoService);
            this.gpbPositionType.Controls.Add(this.rdoOfficer);
            this.gpbPositionType.Enabled = false;
            this.gpbPositionType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.gpbPositionType.Location = new System.Drawing.Point(5, 48);
            this.gpbPositionType.Name = "gpbPositionType";
            this.gpbPositionType.Size = new System.Drawing.Size(208, 56);
            this.gpbPositionType.TabIndex = 8;
            this.gpbPositionType.TabStop = false;
            this.gpbPositionType.Text = "ประเภทตำแหน่ง";
            // 
            // rdoService
            // 
            this.rdoService.AutoSize = true;
            this.rdoService.Location = new System.Drawing.Point(113, 24);
            this.rdoService.Name = "rdoService";
            this.rdoService.Size = new System.Drawing.Size(97, 17);
            this.rdoService.TabIndex = 10;
            this.rdoService.Text = "พนักงานบริการ";
            this.rdoService.UseVisualStyleBackColor = true;
            this.rdoService.CheckedChanged += new System.EventHandler(this.rdoService_CheckedChanged);
            // 
            // rdoOfficer
            // 
            this.rdoOfficer.AutoSize = true;
            this.rdoOfficer.Checked = true;
            this.rdoOfficer.Location = new System.Drawing.Point(13, 24);
            this.rdoOfficer.Name = "rdoOfficer";
            this.rdoOfficer.Size = new System.Drawing.Size(110, 17);
            this.rdoOfficer.TabIndex = 9;
            this.rdoOfficer.TabStop = true;
            this.rdoOfficer.Text = "พนักงานสำนักงาน";
            this.rdoOfficer.UseVisualStyleBackColor = true;
            this.rdoOfficer.CheckedChanged += new System.EventHandler(this.rdoOfficer_CheckedChanged);
            // 
            // cmdShow
            // 
            this.cmdShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cmdShow.Location = new System.Drawing.Point(380, 16);
            this.cmdShow.Name = "cmdShow";
            this.cmdShow.Size = new System.Drawing.Size(67, 23);
            this.cmdShow.TabIndex = 7;
            this.cmdShow.Text = "แสดงข้อมูล";
            this.cmdShow.Click += new System.EventHandler(this.cmdShow_Click);
            // 
            // dtpForMonth
            // 
            this.dtpForMonth.CustomFormat = "MM/yyyy";
            this.dtpForMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dtpForMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpForMonth.Location = new System.Drawing.Point(67, 17);
            this.dtpForMonth.Name = "dtpForMonth";
            this.dtpForMonth.Size = new System.Drawing.Size(62, 20);
            this.dtpForMonth.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.Location = new System.Drawing.Point(10, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "สำหรับเดือน";
            // 
            // ltbEmpListSelected
            // 
            this.ltbEmpListSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.ltbEmpListSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.ltbEmpListSelected.Location = new System.Drawing.Point(314, 128);
            this.ltbEmpListSelected.Name = "ltbEmpListSelected";
            this.ltbEmpListSelected.Size = new System.Drawing.Size(194, 264);
            this.ltbEmpListSelected.Sorted = true;
            this.ltbEmpListSelected.TabIndex = 21;
            this.ltbEmpListSelected.DoubleClick += new System.EventHandler(this.ltbEmpListSelected_DoubleClick);
            // 
            // ltbEmpListCandidate
            // 
            this.ltbEmpListCandidate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.ltbEmpListCandidate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.ltbEmpListCandidate.Location = new System.Drawing.Point(62, 128);
            this.ltbEmpListCandidate.Name = "ltbEmpListCandidate";
            this.ltbEmpListCandidate.Size = new System.Drawing.Size(193, 264);
            this.ltbEmpListCandidate.Sorted = true;
            this.ltbEmpListCandidate.TabIndex = 20;
            this.ltbEmpListCandidate.DoubleClick += new System.EventHandler(this.ltbEmpListCandidate_DoubleClick);
            // 
            // cmdRemoveAll
            // 
            this.cmdRemoveAll.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmdRemoveAll.Enabled = false;
            this.cmdRemoveAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cmdRemoveAll.Location = new System.Drawing.Point(271, 312);
            this.cmdRemoveAll.Name = "cmdRemoveAll";
            this.cmdRemoveAll.Size = new System.Drawing.Size(26, 23);
            this.cmdRemoveAll.TabIndex = 25;
            this.cmdRemoveAll.Text = "<<";
            this.cmdRemoveAll.Click += new System.EventHandler(this.cmdRemoveAll_Click);
            // 
            // cmdRemove
            // 
            this.cmdRemove.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmdRemove.Enabled = false;
            this.cmdRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cmdRemove.Location = new System.Drawing.Point(271, 288);
            this.cmdRemove.Name = "cmdRemove";
            this.cmdRemove.Size = new System.Drawing.Size(26, 23);
            this.cmdRemove.TabIndex = 24;
            this.cmdRemove.Text = "<";
            this.cmdRemove.Click += new System.EventHandler(this.cmdRemove_Click);
            // 
            // cmdSelectAll
            // 
            this.cmdSelectAll.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmdSelectAll.Enabled = false;
            this.cmdSelectAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cmdSelectAll.Location = new System.Drawing.Point(271, 216);
            this.cmdSelectAll.Name = "cmdSelectAll";
            this.cmdSelectAll.Size = new System.Drawing.Size(26, 23);
            this.cmdSelectAll.TabIndex = 23;
            this.cmdSelectAll.Text = ">>";
            this.cmdSelectAll.Click += new System.EventHandler(this.cmdSelectAll_Click);
            // 
            // cmdSelect
            // 
            this.cmdSelect.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmdSelect.Enabled = false;
            this.cmdSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cmdSelect.Location = new System.Drawing.Point(271, 192);
            this.cmdSelect.Name = "cmdSelect";
            this.cmdSelect.Size = new System.Drawing.Size(26, 23);
            this.cmdSelect.TabIndex = 22;
            this.cmdSelect.Text = ">";
            this.cmdSelect.Click += new System.EventHandler(this.cmdSelect_Click);
            // 
            // lblSelected
            // 
            this.lblSelected.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblSelected.AutoSize = true;
            this.lblSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblSelected.Location = new System.Drawing.Point(415, 400);
            this.lblSelected.Name = "lblSelected";
            this.lblSelected.Size = new System.Drawing.Size(28, 13);
            this.lblSelected.TabIndex = 37;
            this.lblSelected.Text = "       ";
            // 
            // lblCandidate
            // 
            this.lblCandidate.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblCandidate.AutoSize = true;
            this.lblCandidate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblCandidate.Location = new System.Drawing.Point(155, 400);
            this.lblCandidate.Name = "lblCandidate";
            this.lblCandidate.Size = new System.Drawing.Size(28, 13);
            this.lblCandidate.TabIndex = 36;
            this.lblCandidate.Text = "       ";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.Location = new System.Drawing.Point(441, 400);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 13);
            this.label4.TabIndex = 33;
            this.label4.Text = "คน";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.Location = new System.Drawing.Point(181, 400);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 13);
            this.label3.TabIndex = 31;
            this.label3.Text = "คน";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(61, 400);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "จำนวนพนักงานทั้งหมด";
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cmdCancel.Location = new System.Drawing.Point(285, 436);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(68, 23);
            this.cmdCancel.TabIndex = 35;
            this.cmdCancel.Text = "ยกเลิก";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdOK.Enabled = false;
            this.cmdOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cmdOK.Location = new System.Drawing.Point(219, 436);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(64, 23);
            this.cmdOK.TabIndex = 34;
            this.cmdOK.Text = "ตกลง";
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label6.Location = new System.Drawing.Point(315, 400);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 13);
            this.label6.TabIndex = 32;
            this.label6.Text = "จำนวนพนักงานทั้งหมด";
            // 
            // FrmGenEmpScheduleBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 478);
            this.Controls.Add(this.lblSelected);
            this.Controls.Add(this.lblCandidate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ltbEmpListSelected);
            this.Controls.Add(this.ltbEmpListCandidate);
            this.Controls.Add(this.cmdRemoveAll);
            this.Controls.Add(this.cmdRemove);
            this.Controls.Add(this.cmdSelectAll);
            this.Controls.Add(this.cmdSelect);
            this.Controls.Add(this.gpbEmployee);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmGenEmpScheduleBase";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmGenEmpScheduleBase_Load);
            this.gpbEmployee.ResumeLayout(false);
            this.gpbEmployee.PerformLayout();
            this.gpbCondition.ResumeLayout(false);
            this.gpbCondition.PerformLayout();
            this.gpbPositionType.ResumeLayout(false);
            this.gpbPositionType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbEmployee;
        private System.Windows.Forms.GroupBox gpbCondition;
        private System.Windows.Forms.Label lblServiceStaffType;
        private System.Windows.Forms.ComboBox cboServiceStaffType;
        private System.Windows.Forms.GroupBox gpbPositionType;
        private System.Windows.Forms.Button cmdShow;
        private System.Windows.Forms.DateTimePicker dtpForMonth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox ltbEmpListSelected;
        private System.Windows.Forms.ListBox ltbEmpListCandidate;
        private System.Windows.Forms.Button cmdRemoveAll;
        private System.Windows.Forms.Button cmdRemove;
        private System.Windows.Forms.Button cmdSelectAll;
        private System.Windows.Forms.Button cmdSelect;
        private System.Windows.Forms.RadioButton rdoService;
        private System.Windows.Forms.RadioButton rdoOfficer;
        private System.Windows.Forms.Label lblSelected;
        private System.Windows.Forms.Label lblCandidate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rdoSelectSome;
        private System.Windows.Forms.RadioButton rdoSelectAll;

    }
}
