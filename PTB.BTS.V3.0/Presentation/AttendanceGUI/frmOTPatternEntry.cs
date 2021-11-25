using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;

using Entity.AttendanceEntities;
using Entity.CommonEntity;

using Facade.CommonFacade;
using Facade.AttendanceFacade;

using Presentation.CommonGUI;

using SystemFramework.AppException;
using SystemFramework.AppMessage;
using SystemFramework.AppConfig;

namespace Presentation.AttendanceGUI
{
	public class frmOTPatternEntry : EntryFormBase
	{
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
					parentForm.Dispose();

					parentForm = null;
					objOTPattern = null;
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		
		private System.Windows.Forms.Label lblPatternId;
		private System.Windows.Forms.Label lblPatternName;
		private System.Windows.Forms.Label lblOTPeriod;
		private System.Windows.Forms.CheckBox chkFixedHour;
		private System.Windows.Forms.CheckBox chkMaxHourLimit;
		private System.Windows.Forms.CheckBox chkMinHourLimit;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtPatternId;
		private System.Windows.Forms.TextBox txtPatternName;
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.ComboBox cboOTRate;
		private System.Windows.Forms.ComboBox cboOTPeriod;
		private System.Windows.Forms.RadioButton rdoHoliday;
		private System.Windows.Forms.RadioButton rdoWorkingDay;
		private System.Windows.Forms.GroupBox gpbFixed;
		private System.Windows.Forms.GroupBox gpbMax;
		private System.Windows.Forms.GroupBox gpbMin;
		private System.Windows.Forms.GroupBox gpbHourDetermination;
		private FarPoint.Win.Input.FpInteger fpiFixedHour;
		private FarPoint.Win.Input.FpInteger fpiFixedMinute;
		private FarPoint.Win.Input.FpInteger fpiMaxMinute;
		private FarPoint.Win.Input.FpInteger fpiMaxHour;
		private FarPoint.Win.Input.FpInteger fpiMinMinute;
		private FarPoint.Win.Input.FpInteger fpiMinHour;
		private FarPoint.Win.Input.FpInteger fpiAdditionalMinute;
		private System.ComponentModel.Container components = null;
		public void InitializeComponent()
		{
			this.lblPatternId = new System.Windows.Forms.Label();
			this.lblPatternName = new System.Windows.Forms.Label();
			this.lblOTPeriod = new System.Windows.Forms.Label();
			this.chkFixedHour = new System.Windows.Forms.CheckBox();
			this.chkMaxHourLimit = new System.Windows.Forms.CheckBox();
			this.chkMinHourLimit = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.cboOTRate = new System.Windows.Forms.ComboBox();
			this.cboOTPeriod = new System.Windows.Forms.ComboBox();
			this.txtPatternId = new System.Windows.Forms.TextBox();
			this.txtPatternName = new System.Windows.Forms.TextBox();
			this.cmdOK = new System.Windows.Forms.Button();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.rdoHoliday = new System.Windows.Forms.RadioButton();
			this.rdoWorkingDay = new System.Windows.Forms.RadioButton();
			this.gpbFixed = new System.Windows.Forms.GroupBox();
			this.fpiFixedMinute = new FarPoint.Win.Input.FpInteger();
			this.fpiFixedHour = new FarPoint.Win.Input.FpInteger();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.fpiAdditionalMinute = new FarPoint.Win.Input.FpInteger();
			this.gpbMax = new System.Windows.Forms.GroupBox();
			this.fpiMaxMinute = new FarPoint.Win.Input.FpInteger();
			this.fpiMaxHour = new FarPoint.Win.Input.FpInteger();
			this.gpbMin = new System.Windows.Forms.GroupBox();
			this.fpiMinMinute = new FarPoint.Win.Input.FpInteger();
			this.fpiMinHour = new FarPoint.Win.Input.FpInteger();
			this.gpbHourDetermination = new System.Windows.Forms.GroupBox();
			this.groupBox1.SuspendLayout();
			this.gpbFixed.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.gpbMax.SuspendLayout();
			this.gpbMin.SuspendLayout();
			this.gpbHourDetermination.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblPatternId
			// 
			this.lblPatternId.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.lblPatternId.AutoSize = true;
			this.lblPatternId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.lblPatternId.Location = new System.Drawing.Point(16, 23);
			this.lblPatternId.Name = "lblPatternId";
			this.lblPatternId.Size = new System.Drawing.Size(42, 16);
			this.lblPatternId.TabIndex = 3;
			this.lblPatternId.Text = "รูปแบบ :";
			// 
			// lblPatternName
			// 
			this.lblPatternName.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.lblPatternName.AutoSize = true;
			this.lblPatternName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.lblPatternName.Location = new System.Drawing.Point(16, 55);
			this.lblPatternName.Name = "lblPatternName";
			this.lblPatternName.Size = new System.Drawing.Size(58, 16);
			this.lblPatternName.TabIndex = 4;
			this.lblPatternName.Text = "รายละเอียด :";
			// 
			// lblOTPeriod
			// 
			this.lblOTPeriod.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.lblOTPeriod.AutoSize = true;
			this.lblOTPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.lblOTPeriod.Location = new System.Drawing.Point(256, 88);
			this.lblOTPeriod.Name = "lblOTPeriod";
			this.lblOTPeriod.Size = new System.Drawing.Size(40, 16);
			this.lblOTPeriod.TabIndex = 6;
			this.lblOTPeriod.Text = "ช่วงเวลา";
			// 
			// chkFixedHour
			// 
			this.chkFixedHour.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.chkFixedHour.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.chkFixedHour.Location = new System.Drawing.Point(20, 16);
			this.chkFixedHour.Name = "chkFixedHour";
			this.chkFixedHour.Size = new System.Drawing.Size(120, 24);
			this.chkFixedHour.TabIndex = 6;
			this.chkFixedHour.Text = "กำหนดชั่วโมงคงที่";
			this.chkFixedHour.CheckedChanged += new System.EventHandler(this.chkFixedHour_CheckedChanged);
			// 
			// chkMaxHourLimit
			// 
			this.chkMaxHourLimit.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.chkMaxHourLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.chkMaxHourLimit.Location = new System.Drawing.Point(168, 16);
			this.chkMaxHourLimit.Name = "chkMaxHourLimit";
			this.chkMaxHourLimit.Size = new System.Drawing.Size(112, 24);
			this.chkMaxHourLimit.TabIndex = 9;
			this.chkMaxHourLimit.Text = "กำหนดชั่วโมงสูงสุด";
			this.chkMaxHourLimit.CheckedChanged += new System.EventHandler(this.chkMaxHourLimit_CheckedChanged);
			// 
			// chkMinHourLimit
			// 
			this.chkMinHourLimit.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.chkMinHourLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.chkMinHourLimit.Location = new System.Drawing.Point(316, 16);
			this.chkMinHourLimit.Name = "chkMinHourLimit";
			this.chkMinHourLimit.Size = new System.Drawing.Size(112, 24);
			this.chkMinHourLimit.TabIndex = 12;
			this.chkMinHourLimit.Text = "กำหนดชั่วโมงต่ำสุด";
			this.chkMinHourLimit.CheckedChanged += new System.EventHandler(this.chkMinHourLimit_CheckedChanged);
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.label1.Location = new System.Drawing.Point(40, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(95, 16);
			this.label1.TabIndex = 13;
			this.label1.Text = "นาทีที่เพิ่มหลังเลิกงาน";
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.label2.Location = new System.Drawing.Point(248, 22);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(65, 16);
			this.label2.TabIndex = 14;
			this.label2.Text = "อัตรา   A,B,C";
			// 
			// cboOTRate
			// 
			this.cboOTRate.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.cboOTRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboOTRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.cboOTRate.Location = new System.Drawing.Point(328, 22);
			this.cboOTRate.Name = "cboOTRate";
			this.cboOTRate.Size = new System.Drawing.Size(48, 21);
			this.cboOTRate.TabIndex = 16;
			// 
			// cboOTPeriod
			// 
			this.cboOTPeriod.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.cboOTPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboOTPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.cboOTPeriod.Location = new System.Drawing.Point(312, 88);
			this.cboOTPeriod.Name = "cboOTPeriod";
			this.cboOTPeriod.Size = new System.Drawing.Size(104, 21);
			this.cboOTPeriod.TabIndex = 5;
			// 
			// txtPatternId
			// 
			this.txtPatternId.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.txtPatternId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtPatternId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.txtPatternId.Location = new System.Drawing.Point(96, 23);
			this.txtPatternId.MaxLength = 2;
			this.txtPatternId.Name = "txtPatternId";
			this.txtPatternId.Size = new System.Drawing.Size(40, 20);
			this.txtPatternId.TabIndex = 1;
			this.txtPatternId.Text = "";
			// 
			// txtPatternName
			// 
			this.txtPatternName.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.txtPatternName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.txtPatternName.Location = new System.Drawing.Point(96, 55);
			this.txtPatternName.MaxLength = 50;
			this.txtPatternName.Name = "txtPatternName";
			this.txtPatternName.Size = new System.Drawing.Size(320, 20);
			this.txtPatternName.TabIndex = 2;
			this.txtPatternName.Text = "";
			// 
			// cmdOK
			// 
			this.cmdOK.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.cmdOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.cmdOK.Location = new System.Drawing.Point(152, 336);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.TabIndex = 17;
			this.cmdOK.Text = "ตกลง";
			this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
			// 
			// cmdCancel
			// 
			this.cmdCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.cmdCancel.Location = new System.Drawing.Point(240, 336);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.TabIndex = 18;
			this.cmdCancel.Text = "ยกเลิก";
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.groupBox1.Controls.Add(this.rdoHoliday);
			this.groupBox1.Controls.Add(this.rdoWorkingDay);
			this.groupBox1.Controls.Add(this.lblPatternId);
			this.groupBox1.Controls.Add(this.txtPatternId);
			this.groupBox1.Controls.Add(this.lblPatternName);
			this.groupBox1.Controls.Add(this.txtPatternName);
			this.groupBox1.Controls.Add(this.lblOTPeriod);
			this.groupBox1.Controls.Add(this.cboOTPeriod);
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.groupBox1.Location = new System.Drawing.Point(16, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(432, 124);
			this.groupBox1.TabIndex = 30;
			this.groupBox1.TabStop = false;
			// 
			// rdoHoliday
			// 
			this.rdoHoliday.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.rdoHoliday.Location = new System.Drawing.Point(96, 88);
			this.rdoHoliday.Name = "rdoHoliday";
			this.rdoHoliday.TabIndex = 4;
			this.rdoHoliday.Text = "วันหยุด";
			// 
			// rdoWorkingDay
			// 
			this.rdoWorkingDay.Checked = true;
			this.rdoWorkingDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.rdoWorkingDay.Location = new System.Drawing.Point(16, 88);
			this.rdoWorkingDay.Name = "rdoWorkingDay";
			this.rdoWorkingDay.TabIndex = 3;
			this.rdoWorkingDay.TabStop = true;
			this.rdoWorkingDay.Text = "วันทำงาน";
			this.rdoWorkingDay.CheckedChanged += new System.EventHandler(this.rdoWorkingDay_CheckedChanged);
			// 
			// gpbFixed
			// 
			this.gpbFixed.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.gpbFixed.Controls.Add(this.fpiFixedMinute);
			this.gpbFixed.Controls.Add(this.fpiFixedHour);
			this.gpbFixed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.gpbFixed.Location = new System.Drawing.Point(20, 40);
			this.gpbFixed.Name = "gpbFixed";
			this.gpbFixed.Size = new System.Drawing.Size(96, 48);
			this.gpbFixed.TabIndex = 31;
			this.gpbFixed.TabStop = false;
			// 
			// fpiFixedMinute
			// 
			this.fpiFixedMinute.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
			this.fpiFixedMinute.AllowClipboardKeys = true;
			this.fpiFixedMinute.ButtonMarginColor = System.Drawing.SystemColors.Control;
			this.fpiFixedMinute.Enabled = false;
			this.fpiFixedMinute.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.fpiFixedMinute.Location = new System.Drawing.Point(56, 16);
			this.fpiFixedMinute.MaxValue = 59;
			this.fpiFixedMinute.MinValue = 0;
			this.fpiFixedMinute.Name = "fpiFixedMinute";
			this.fpiFixedMinute.Size = new System.Drawing.Size(32, 20);
			this.fpiFixedMinute.TabIndex = 8;
			this.fpiFixedMinute.Text = "";
			// 
			// fpiFixedHour
			// 
			this.fpiFixedHour.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
			this.fpiFixedHour.AllowClipboardKeys = true;
			this.fpiFixedHour.ButtonMarginColor = System.Drawing.SystemColors.Control;
			this.fpiFixedHour.Enabled = false;
			this.fpiFixedHour.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.fpiFixedHour.Location = new System.Drawing.Point(8, 16);
			this.fpiFixedHour.MaxValue = 24;
			this.fpiFixedHour.MinValue = 0;
			this.fpiFixedHour.Name = "fpiFixedHour";
			this.fpiFixedHour.Size = new System.Drawing.Size(32, 20);
			this.fpiFixedHour.TabIndex = 7;
			this.fpiFixedHour.Text = "";
			// 
			// groupBox3
			// 
			this.groupBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.groupBox3.Controls.Add(this.fpiAdditionalMinute);
			this.groupBox3.Controls.Add(this.label2);
			this.groupBox3.Controls.Add(this.label1);
			this.groupBox3.Controls.Add(this.cboOTRate);
			this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.groupBox3.Location = new System.Drawing.Point(16, 256);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(432, 64);
			this.groupBox3.TabIndex = 32;
			this.groupBox3.TabStop = false;
			// 
			// fpiAdditionalMinute
			// 
			this.fpiAdditionalMinute.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
			this.fpiAdditionalMinute.AllowClipboardKeys = true;
			this.fpiAdditionalMinute.ButtonMarginColor = System.Drawing.SystemColors.Control;
			this.fpiAdditionalMinute.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.fpiAdditionalMinute.Location = new System.Drawing.Point(144, 24);
			this.fpiAdditionalMinute.MaxValue = 59;
			this.fpiAdditionalMinute.MinValue = 0;
			this.fpiAdditionalMinute.Name = "fpiAdditionalMinute";
			this.fpiAdditionalMinute.Size = new System.Drawing.Size(40, 20);
			this.fpiAdditionalMinute.TabIndex = 15;
			this.fpiAdditionalMinute.Text = "";
			// 
			// gpbMax
			// 
			this.gpbMax.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.gpbMax.Controls.Add(this.fpiMaxMinute);
			this.gpbMax.Controls.Add(this.fpiMaxHour);
			this.gpbMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.gpbMax.Location = new System.Drawing.Point(168, 40);
			this.gpbMax.Name = "gpbMax";
			this.gpbMax.Size = new System.Drawing.Size(96, 48);
			this.gpbMax.TabIndex = 33;
			this.gpbMax.TabStop = false;
			// 
			// fpiMaxMinute
			// 
			this.fpiMaxMinute.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
			this.fpiMaxMinute.AllowClipboardKeys = true;
			this.fpiMaxMinute.ButtonMarginColor = System.Drawing.SystemColors.Control;
			this.fpiMaxMinute.Enabled = false;
			this.fpiMaxMinute.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.fpiMaxMinute.Location = new System.Drawing.Point(56, 16);
			this.fpiMaxMinute.MaxValue = 59;
			this.fpiMaxMinute.MinValue = 0;
			this.fpiMaxMinute.Name = "fpiMaxMinute";
			this.fpiMaxMinute.Size = new System.Drawing.Size(32, 20);
			this.fpiMaxMinute.TabIndex = 11;
			this.fpiMaxMinute.Text = "";
			// 
			// fpiMaxHour
			// 
			this.fpiMaxHour.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
			this.fpiMaxHour.AllowClipboardKeys = true;
			this.fpiMaxHour.ButtonMarginColor = System.Drawing.SystemColors.Control;
			this.fpiMaxHour.Enabled = false;
			this.fpiMaxHour.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.fpiMaxHour.Location = new System.Drawing.Point(8, 16);
			this.fpiMaxHour.MaxValue = 24;
			this.fpiMaxHour.MinValue = 0;
			this.fpiMaxHour.Name = "fpiMaxHour";
			this.fpiMaxHour.Size = new System.Drawing.Size(32, 20);
			this.fpiMaxHour.TabIndex = 10;
			this.fpiMaxHour.Text = "";
			// 
			// gpbMin
			// 
			this.gpbMin.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.gpbMin.Controls.Add(this.fpiMinMinute);
			this.gpbMin.Controls.Add(this.fpiMinHour);
			this.gpbMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.gpbMin.Location = new System.Drawing.Point(316, 40);
			this.gpbMin.Name = "gpbMin";
			this.gpbMin.Size = new System.Drawing.Size(96, 48);
			this.gpbMin.TabIndex = 34;
			this.gpbMin.TabStop = false;
			// 
			// fpiMinMinute
			// 
			this.fpiMinMinute.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
			this.fpiMinMinute.AllowClipboardKeys = true;
			this.fpiMinMinute.ButtonMarginColor = System.Drawing.SystemColors.Control;
			this.fpiMinMinute.Enabled = false;
			this.fpiMinMinute.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.fpiMinMinute.Location = new System.Drawing.Point(56, 16);
			this.fpiMinMinute.MaxValue = 59;
			this.fpiMinMinute.MinValue = 0;
			this.fpiMinMinute.Name = "fpiMinMinute";
			this.fpiMinMinute.Size = new System.Drawing.Size(32, 20);
			this.fpiMinMinute.TabIndex = 14;
			this.fpiMinMinute.Text = "";
			// 
			// fpiMinHour
			// 
			this.fpiMinHour.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
			this.fpiMinHour.AllowClipboardKeys = true;
			this.fpiMinHour.ButtonMarginColor = System.Drawing.SystemColors.Control;
			this.fpiMinHour.Enabled = false;
			this.fpiMinHour.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.fpiMinHour.Location = new System.Drawing.Point(8, 16);
			this.fpiMinHour.MaxValue = 24;
			this.fpiMinHour.MinValue = 0;
			this.fpiMinHour.Name = "fpiMinHour";
			this.fpiMinHour.Size = new System.Drawing.Size(32, 20);
			this.fpiMinHour.TabIndex = 13;
			this.fpiMinHour.Text = "";
			// 
			// gpbHourDetermination
			// 
			this.gpbHourDetermination.Controls.Add(this.chkFixedHour);
			this.gpbHourDetermination.Controls.Add(this.gpbFixed);
			this.gpbHourDetermination.Controls.Add(this.chkMaxHourLimit);
			this.gpbHourDetermination.Controls.Add(this.gpbMax);
			this.gpbHourDetermination.Controls.Add(this.chkMinHourLimit);
			this.gpbHourDetermination.Controls.Add(this.gpbMin);
			this.gpbHourDetermination.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.gpbHourDetermination.Location = new System.Drawing.Point(16, 144);
			this.gpbHourDetermination.Name = "gpbHourDetermination";
			this.gpbHourDetermination.Size = new System.Drawing.Size(432, 100);
			this.gpbHourDetermination.TabIndex = 35;
			this.gpbHourDetermination.TabStop = false;
			// 
			// frmOTPatternEntry
			// 
			this.AcceptButton = this.cmdOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.cmdCancel;
			this.ClientSize = new System.Drawing.Size(466, 376);
			this.Controls.Add(this.gpbHourDetermination);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdOK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MinimizeBox = false;
			this.Name = "frmOTPatternEntry";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Load += new System.EventHandler(this.frmOTPatternEntry_Load);
			this.groupBox1.ResumeLayout(false);
			this.gpbFixed.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.gpbMax.ResumeLayout(false);
			this.gpbMin.ResumeLayout(false);
			this.gpbHourDetermination.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region - Private -
		private bool isReadonly = true;
		private frmOTPattern parentForm;
		#endregion - Private -

//		=====================================property===============================
		private OTPattern objOTPattern;
		public OTPattern ObjOTPattern
		{
			get
			{
				objOTPattern = new OTPattern();
				objOTPattern.PatternId = txtPatternId.Text;                    
				objOTPattern.PatternName = txtPatternName.Text;
				objOTPattern.AdditionalMinute = int.Parse(fpiAdditionalMinute.Text);
				objOTPattern.OTPeriod = CTFunction.GetPeriodType(cboOTPeriod.Text);
				objOTPattern.OTRate = CTFunction.GetRateType(cboOTRate.Text);

				if(rdoHoliday.Checked)
				{
					objOTPattern.DayType = WORKINGDAY_TYPE.HOLIDAY;
				}
				else
				{
					objOTPattern.DayType = WORKINGDAY_TYPE.WORKINGDAY;
				}
            
				//Fixed_Hour_Limit
				if(chkFixedHour.Checked)
				{ 				
					objOTPattern.IsFixedHour = true;
					objOTPattern.FixedHour = GUIFunction.ConverToDecimal(fpiFixedHour.Text, fpiFixedMinute.Text);
				}
				else
				{
					objOTPattern.IsFixedHour = false;
				}			

				//Max_Hour_Limit
				if(chkMaxHourLimit.Checked)
				{ 				
					objOTPattern.IsMaxHourLimit = true;
					objOTPattern.MaxHourLimit = GUIFunction.ConverToDecimal(fpiMaxHour.Text, fpiMaxMinute.Text);
				}
				else
				{
					objOTPattern.IsMaxHourLimit = false;
				}	
	
				//Min_Hour_Limit
				if(chkMinHourLimit.Checked)
				{ 				
					objOTPattern.IsMinHourLimit = true;
					objOTPattern.MinHourLimit = GUIFunction.ConverToDecimal(fpiMinHour.Text, fpiMinMinute.Text);
				}
				else
				{
					objOTPattern.IsMinHourLimit = false;
				}

				return objOTPattern;
			}
			set
			{
				objOTPattern = value;
				txtPatternId.Text = GUIFunction.GetString(value.PatternId);
				txtPatternName.Text = GUIFunction.GetString(value.PatternName);
				cboOTPeriod.Text = GUIFunction.GetString(value.OTPeriod);
				cboOTRate.Text = GUIFunction.GetString(value.OTRate);
				fpiAdditionalMinute.Value = value.AdditionalMinute;

				if(value.DayType == WORKINGDAY_TYPE.HOLIDAY)
				{
					rdoHoliday.Checked = true;				
				}
				else
				{
					rdoWorkingDay.Checked = true;
				}

				if(value.IsFixedHour)
				{
					chkFixedHour.Checked = true;
					fpiFixedHour.Value = Decimal.Floor(value.FixedHour);
					fpiFixedMinute.Text = GUIFunction.ConverToMinute(value.FixedHour);	
				}
				else
				{
					chkFixedHour.Checked = false;
				}

				if(value.IsMaxHourLimit)
				{
					chkMaxHourLimit.Checked = true;
					fpiMaxHour.Value = Decimal.Floor(value.MaxHourLimit);
					fpiMaxMinute.Text = GUIFunction.ConverToMinute(value.MaxHourLimit);
				}
				else
				{
					chkMaxHourLimit.Checked = false;
				}

				if(value.IsMinHourLimit)
				{
					chkMinHourLimit.Checked = true;
					fpiMinHour.Value = Decimal.Floor(value.MinHourLimit);
					fpiMinMinute.Text = GUIFunction.ConverToMinute(value.MinHourLimit);
				}
				else
				{
					chkMinHourLimit.Checked = false;
				}
			}
		}

//		============================== Constructor ==============================
		public frmOTPatternEntry(frmOTPattern parentForm): base()
		{
			InitializeComponent();						
			this.parentForm = parentForm;	
			isReadonly = UserProfile.IsReadOnly("miAttendance", "miOTPattern");

			try
			{			
				cboOTPeriod.DataSource = parentForm.FacadeOTPattern.DataSourceOTPeriod;
				cboOTRate.DataSource = parentForm.FacadeOTPattern.DataSourceOTRate;
			}
			catch(SqlException sqlex)
			{
				Message(sqlex);
			}
			catch(AppExceptionBase ex)
			{
				Message(ex);
			}
			catch(Exception ex)
			{
				Message(ex);
			}			
		}

//		============================== private method ==============================
		#region - validate -
		private bool validateForm()
		{
			return validatePattern() && validateFixedTime();
		}

		private bool validatePattern()
		{
			if(txtPatternId.Text == "")
			{
				Message(MessageList.Error.E0002,"รูปแบบ");
				txtPatternId.Focus();
				return false;
			}
			if(txtPatternName.Text == "")
			{
				Message(MessageList.Error.E0002,"รูปแบบ");
				txtPatternId.Focus();
				return false;
			}
			if(cboOTPeriod.Text == "")
			{
				Message(MessageList.Error.E0005,"ช่วงเวลา");
				cboOTPeriod.Focus();
				return false;
			}
			if(cboOTRate.Text == "")
			{
				Message(MessageList.Error.E0005,"อัตรา A,B,C");
				cboOTRate.Focus();
				return false;
			}
			return true;
		}

		private bool validateFixedTime()
		{
			if(chkFixedHour.Checked)
			{
				if(fpiFixedHour.Text == "0" & fpiFixedMinute.Text == "0")
				{
					Message(MessageList.Error.E0002,"จำนวนชั่วโมง : นาที");
					fpiFixedMinute.Focus();
					return false;
				}	
			}

			if(chkMaxHourLimit.Checked)	
			{
				if(fpiMaxHour.Text == "0" & fpiMaxMinute.Text == "0")
				{
					Message(MessageList.Error.E0002,"จำนวนชั่วโมง : นาที");
					fpiMaxMinute.Focus();
					return false;
				}
			}

			if(chkMinHourLimit.Checked)	
			{
				if(fpiMinHour.Text == "0" & fpiMinMinute.Text == "0")
				{
					Message(MessageList.Error.E0002,"จำนวนชั่วโมง : นาที");
					fpiMinMinute.Focus();
					return false;
				}
			}

			return true;
		}
		#endregion

		private void enableKeyField(bool enable)
		{
			txtPatternId.Enabled = enable;
		}

		public void clearForm()
		{
			txtPatternId.Text = "";
			txtPatternName.Text = "";			

			fpiAdditionalMinute.Value = 0;
			clearFixedHour();
			clearMaxHour();
			clearMinHour();

			rdoWorkingDay.Checked = true;
			chkFixedHour.Checked = false;
			chkMaxHourLimit.Checked = false;
			chkMinHourLimit.Checked = false;

			cboOTPeriod.SelectedIndex = -1;
			cboOTPeriod.SelectedIndex = -1;
			cboOTRate.SelectedIndex = -1;
			cboOTRate.SelectedIndex = -1;
		}
		private void enableFixedHour(bool enable)
		{
			fpiFixedHour.Enabled = enable;
			fpiFixedMinute.Enabled = enable;
		}

		private void enableMaxHour(bool enable)
		{
			fpiMaxHour.Enabled = enable;
			fpiMaxMinute.Enabled = enable;
		}

		private void enableMinHour(bool enable)
		{
			fpiMinHour.Enabled = enable;
			fpiMinMinute.Enabled = enable;
		}

		private void clearFixedHour()
		{
			fpiFixedHour.Value = 0;
			fpiFixedMinute.Value = 0;
		}

		private void clearMaxHour()
		{
			fpiMaxHour.Value = 0;
			fpiMaxMinute.Value = 0;
		}

		private void clearMinHour()
		{
			fpiMinHour.Value = 0;
			fpiMinMinute.Value = 0;
		}

//		============================== public method ==============================
		public void InitAddAction()
		{
			baseADD();
			enableKeyField(true);
			clearForm();
			txtPatternId.Focus();
		}

		public void InitEditAction(OTPattern value)
		{
			baseEDIT();
			clearForm();
			ObjOTPattern = value;
			enableKeyField(false);
			txtPatternName.Focus();

			if(isReadonly)
			{
				cmdOK.Enabled = false;
			}
		}
		
//		============================== Base event ==============================
		private void addEvent()
		{
			try
			{
				if (validateForm() && parentForm.AddRow(ObjOTPattern))
				{
					clearForm();
					txtPatternId.Focus();
				}
			}
			catch(SqlException sqlex)
			{
				Message(sqlex);
			}
			catch(AppExceptionBase ex)
			{
				Message(ex);
				setSelected(txtPatternId);
			}
			catch(Exception ex)
			{
				Message(ex);
			}		
		}

		private void editEvent()
		{
			try
			{
				if (validateForm() && parentForm.UpdateRow(ObjOTPattern))
				{
					this.Hide();
				}
			}
			catch(SqlException sqlex)
			{
				Message(sqlex);
			}
			catch(AppExceptionBase ex)
			{
				Message(ex);
			}
			catch(Exception ex)
			{
				Message(ex);
			}	
		}		
		
//		================================= event ================================		
		private void frmOTPatternEntry_Load(object sender, System.EventArgs e)
		{}

    	private void cmdOK_Click(object sender, System.EventArgs e)
		{
			switch (action)
			{					
				case ActionType.ADD :
					addEvent();
					break;
				case ActionType.EDIT :
					editEvent();
					break;
			}
		}

		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
	       this.Hide();
		}

		private void chkFixedHour_CheckedChanged(object sender, System.EventArgs e)
		{
			if (chkFixedHour.Checked)
			{
				enableFixedHour(true);
				chkMaxHourLimit.Enabled = false;
				chkMinHourLimit.Enabled = false;
				clearMaxHour();
				clearMinHour();
			}
			else
			{
				enableFixedHour(false);
				chkMaxHourLimit.Enabled = true;
				chkMinHourLimit.Enabled = true;
			}
			clearFixedHour();
		}

		private void chkMaxHourLimit_CheckedChanged(object sender, System.EventArgs e)
		{
			if (chkMaxHourLimit.Checked)
			{
				enableMaxHour(true);
				chkFixedHour.Enabled = false;
				clearFixedHour();
			}
			else
			{
				enableMaxHour(false);	
				if(!chkMinHourLimit.Checked)
				{
					chkFixedHour.Enabled = true;
				}
			}
			clearMaxHour();
		}

		private void chkMinHourLimit_CheckedChanged(object sender, System.EventArgs e)
		{
			if (chkMinHourLimit.Checked)
			{
				enableMinHour(true);
				chkFixedHour.Enabled = false;
				clearFixedHour();
			}
			else
			{
				enableMinHour(false);
				if(!chkMaxHourLimit.Checked)
				{
					chkFixedHour.Enabled = true;
				}
			}
			clearMinHour();
		}

		private void rdoWorkingDay_CheckedChanged(object sender, System.EventArgs e)
		{
			if(rdoWorkingDay.Checked)
			{
				fpiAdditionalMinute.Enabled = true;
			}
			else
			{
				fpiAdditionalMinute.Value = 0;
				fpiAdditionalMinute.Enabled = false;
			}
		}
	}
}
