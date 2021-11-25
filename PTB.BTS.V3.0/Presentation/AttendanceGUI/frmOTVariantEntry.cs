using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;

using Entity.AttendanceEntities;
using Entity.CommonEntity;

using Facade.AttendanceFacade;
using Facade.CommonFacade;

using Presentation.CommonGUI;

using SystemFramework.AppException;
using SystemFramework.AppMessage;
using SystemFramework.AppConfig;

using ictus.Common.Entity.Time;

namespace Presentation.AttendanceGUI
{

	public class frmOTVariantEntry : EntryFormBase
	{
		#region Windows Form Designer generated code
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
					parentForm.Dispose();

					parentForm = null;
					objOTVariant = null;
				}
			}
			base.Dispose( disposing );
		}
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.DateTimePicker dtpTimeFrom;
		private System.Windows.Forms.RadioButton rdoOut;
		private System.Windows.Forms.RadioButton rdoIn;
		private System.Windows.Forms.DateTimePicker dtpTimeTo;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.RadioButton rdoWRateA;
		private System.Windows.Forms.RadioButton rdoWRateB;
		private System.Windows.Forms.RadioButton rdoWRateC;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.RadioButton rdoHRateC;
		private System.Windows.Forms.RadioButton rdoHRateB;
		private System.Windows.Forms.RadioButton rdoHRateA;
		private System.Windows.Forms.GroupBox gpbInOutStatus;
		private System.Windows.Forms.GroupBox gpbTimeInOut;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.DateTimePicker dtpTimeGroupII;
		private System.Windows.Forms.DateTimePicker dtpTimeGroupIII;
		private System.Windows.Forms.DateTimePicker dtpTimeGroupI;
		private System.Windows.Forms.DateTimePicker dtpChargeTimeGroupI;
		private System.Windows.Forms.DateTimePicker dtpChargeTimeGroupIII;
		private System.Windows.Forms.DateTimePicker dtpChargeTimeGroupII;
		private System.ComponentModel.Container components = null;
		
		/// 
		private void InitializeComponent()
		{
			this.gpbInOutStatus = new System.Windows.Forms.GroupBox();
			this.rdoOut = new System.Windows.Forms.RadioButton();
			this.rdoIn = new System.Windows.Forms.RadioButton();
			this.dtpTimeFrom = new System.Windows.Forms.DateTimePicker();
			this.label8 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdOK = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.dtpTimeGroupI = new System.Windows.Forms.DateTimePicker();
			this.dtpTimeGroupIII = new System.Windows.Forms.DateTimePicker();
			this.dtpTimeGroupII = new System.Windows.Forms.DateTimePicker();
			this.label4 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.rdoWRateC = new System.Windows.Forms.RadioButton();
			this.rdoWRateB = new System.Windows.Forms.RadioButton();
			this.rdoWRateA = new System.Windows.Forms.RadioButton();
			this.dtpTimeTo = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.gpbTimeInOut = new System.Windows.Forms.GroupBox();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.rdoHRateC = new System.Windows.Forms.RadioButton();
			this.rdoHRateB = new System.Windows.Forms.RadioButton();
			this.rdoHRateA = new System.Windows.Forms.RadioButton();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.dtpChargeTimeGroupI = new System.Windows.Forms.DateTimePicker();
			this.dtpChargeTimeGroupIII = new System.Windows.Forms.DateTimePicker();
			this.dtpChargeTimeGroupII = new System.Windows.Forms.DateTimePicker();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.gpbInOutStatus.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.gpbTimeInOut.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// gpbInOutStatus
			// 
			this.gpbInOutStatus.Controls.Add(this.rdoOut);
			this.gpbInOutStatus.Controls.Add(this.rdoIn);
			this.gpbInOutStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.gpbInOutStatus.Location = new System.Drawing.Point(25, 16);
			this.gpbInOutStatus.Name = "gpbInOutStatus";
			this.gpbInOutStatus.Size = new System.Drawing.Size(256, 56);
			this.gpbInOutStatus.TabIndex = 90;
			this.gpbInOutStatus.TabStop = false;
			this.gpbInOutStatus.Text = "กำหนดสถานะ";
			// 
			// rdoOut
			// 
			this.rdoOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.rdoOut.Location = new System.Drawing.Point(128, 24);
			this.rdoOut.Name = "rdoOut";
			this.rdoOut.Size = new System.Drawing.Size(80, 24);
			this.rdoOut.TabIndex = 2;
			this.rdoOut.Text = "  เวลาออก";
			// 
			// rdoIn
			// 
			this.rdoIn.Checked = true;
			this.rdoIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.rdoIn.Location = new System.Drawing.Point(24, 24);
			this.rdoIn.Name = "rdoIn";
			this.rdoIn.Size = new System.Drawing.Size(72, 24);
			this.rdoIn.TabIndex = 1;
			this.rdoIn.TabStop = true;
			this.rdoIn.Text = "  เวลาเข้า";
			// 
			// dtpTimeFrom
			// 
			this.dtpTimeFrom.CustomFormat = "HH:mm";
			this.dtpTimeFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.dtpTimeFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpTimeFrom.Location = new System.Drawing.Point(56, 24);
			this.dtpTimeFrom.Name = "dtpTimeFrom";
			this.dtpTimeFrom.ShowUpDown = true;
			this.dtpTimeFrom.Size = new System.Drawing.Size(56, 20);
			this.dtpTimeFrom.TabIndex = 3;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.label8.Location = new System.Drawing.Point(16, 24);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(28, 16);
			this.label8.TabIndex = 2;
			this.label8.Text = "ตั้งแต่";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.label3.Location = new System.Drawing.Point(24, 24);
			this.label3.Name = "label3";
			this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.label3.Size = new System.Drawing.Size(56, 16);
			this.label3.TabIndex = 3;
			this.label3.Text = "TIS Group";
			// 
			// cmdCancel
			// 
			this.cmdCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.cmdCancel.Location = new System.Drawing.Point(288, 312);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.TabIndex = 18;
			this.cmdCancel.Text = "ยกเลิก";
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			// 
			// cmdOK
			// 
			this.cmdOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.cmdOK.Location = new System.Drawing.Point(208, 312);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.TabIndex = 17;
			this.cmdOK.Text = "ตกลง";
			this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.dtpTimeGroupI);
			this.groupBox2.Controls.Add(this.dtpTimeGroupIII);
			this.groupBox2.Controls.Add(this.dtpTimeGroupII);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.groupBox2.Location = new System.Drawing.Point(25, 72);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(520, 64);
			this.groupBox2.TabIndex = 92;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "กำหนดเวลาเทียบเท่า";
			// 
			// dtpTimeGroupI
			// 
			this.dtpTimeGroupI.CustomFormat = "HH:mm";
			this.dtpTimeGroupI.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.dtpTimeGroupI.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpTimeGroupI.Location = new System.Drawing.Point(88, 22);
			this.dtpTimeGroupI.Name = "dtpTimeGroupI";
			this.dtpTimeGroupI.ShowUpDown = true;
			this.dtpTimeGroupI.Size = new System.Drawing.Size(56, 20);
			this.dtpTimeGroupI.TabIndex = 5;
			// 
			// dtpTimeGroupIII
			// 
			this.dtpTimeGroupIII.CustomFormat = "HH:mm";
			this.dtpTimeGroupIII.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.dtpTimeGroupIII.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpTimeGroupIII.Location = new System.Drawing.Point(424, 22);
			this.dtpTimeGroupIII.Name = "dtpTimeGroupIII";
			this.dtpTimeGroupIII.ShowUpDown = true;
			this.dtpTimeGroupIII.Size = new System.Drawing.Size(56, 20);
			this.dtpTimeGroupIII.TabIndex = 7;
			// 
			// dtpTimeGroupII
			// 
			this.dtpTimeGroupII.CustomFormat = "HH:mm";
			this.dtpTimeGroupII.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.dtpTimeGroupII.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpTimeGroupII.Location = new System.Drawing.Point(272, 22);
			this.dtpTimeGroupII.Name = "dtpTimeGroupII";
			this.dtpTimeGroupII.ShowUpDown = true;
			this.dtpTimeGroupII.Size = new System.Drawing.Size(56, 20);
			this.dtpTimeGroupII.TabIndex = 6;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.label4.Location = new System.Drawing.Point(376, 24);
			this.label4.Name = "label4";
			this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.label4.Size = new System.Drawing.Size(38, 16);
			this.label4.TabIndex = 6;
			this.label4.Text = "Others";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.label2.Location = new System.Drawing.Point(192, 24);
			this.label2.Name = "label2";
			this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.label2.Size = new System.Drawing.Size(69, 16);
			this.label2.TabIndex = 5;
			this.label2.Text = "Melco Group";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.rdoWRateC);
			this.groupBox3.Controls.Add(this.rdoWRateB);
			this.groupBox3.Controls.Add(this.rdoWRateA);
			this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.groupBox3.Location = new System.Drawing.Point(24, 200);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(256, 96);
			this.groupBox3.TabIndex = 94;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = " วันทำงาน";
			// 
			// rdoWRateC
			// 
			this.rdoWRateC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.rdoWRateC.Location = new System.Drawing.Point(80, 64);
			this.rdoWRateC.Name = "rdoWRateC";
			this.rdoWRateC.TabIndex = 13;
			this.rdoWRateC.Text = "  อัตรา C";
			// 
			// rdoWRateB
			// 
			this.rdoWRateB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.rdoWRateB.Location = new System.Drawing.Point(80, 40);
			this.rdoWRateB.Name = "rdoWRateB";
			this.rdoWRateB.TabIndex = 12;
			this.rdoWRateB.Text = "  อัตรา B";
			// 
			// rdoWRateA
			// 
			this.rdoWRateA.Checked = true;
			this.rdoWRateA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.rdoWRateA.Location = new System.Drawing.Point(80, 16);
			this.rdoWRateA.Name = "rdoWRateA";
			this.rdoWRateA.TabIndex = 11;
			this.rdoWRateA.TabStop = true;
			this.rdoWRateA.Text = "  อัตรา A";
			// 
			// dtpTimeTo
			// 
			this.dtpTimeTo.CustomFormat = "HH:mm";
			this.dtpTimeTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.dtpTimeTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpTimeTo.Location = new System.Drawing.Point(184, 24);
			this.dtpTimeTo.Name = "dtpTimeTo";
			this.dtpTimeTo.ShowUpDown = true;
			this.dtpTimeTo.Size = new System.Drawing.Size(56, 20);
			this.dtpTimeTo.TabIndex = 4;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.label1.Location = new System.Drawing.Point(136, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(32, 23);
			this.label1.TabIndex = 8;
			this.label1.Text = "จนถึง";
			// 
			// gpbTimeInOut
			// 
			this.gpbTimeInOut.Controls.Add(this.label8);
			this.gpbTimeInOut.Controls.Add(this.label1);
			this.gpbTimeInOut.Controls.Add(this.dtpTimeTo);
			this.gpbTimeInOut.Controls.Add(this.dtpTimeFrom);
			this.gpbTimeInOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.gpbTimeInOut.Location = new System.Drawing.Point(289, 16);
			this.gpbTimeInOut.Name = "gpbTimeInOut";
			this.gpbTimeInOut.Size = new System.Drawing.Size(256, 56);
			this.gpbTimeInOut.TabIndex = 91;
			this.gpbTimeInOut.TabStop = false;
			this.gpbTimeInOut.Text = "กำหนดเวลา";
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.rdoHRateC);
			this.groupBox5.Controls.Add(this.rdoHRateB);
			this.groupBox5.Controls.Add(this.rdoHRateA);
			this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.groupBox5.Location = new System.Drawing.Point(288, 200);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(256, 96);
			this.groupBox5.TabIndex = 95;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = " วันหยุด";
			// 
			// rdoHRateC
			// 
			this.rdoHRateC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.rdoHRateC.Location = new System.Drawing.Point(80, 64);
			this.rdoHRateC.Name = "rdoHRateC";
			this.rdoHRateC.TabIndex = 16;
			this.rdoHRateC.Text = "  อัตรา C";
			// 
			// rdoHRateB
			// 
			this.rdoHRateB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.rdoHRateB.Location = new System.Drawing.Point(80, 40);
			this.rdoHRateB.Name = "rdoHRateB";
			this.rdoHRateB.TabIndex = 15;
			this.rdoHRateB.Text = "  อัตรา B";
			// 
			// rdoHRateA
			// 
			this.rdoHRateA.Checked = true;
			this.rdoHRateA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.rdoHRateA.Location = new System.Drawing.Point(80, 16);
			this.rdoHRateA.Name = "rdoHRateA";
			this.rdoHRateA.TabIndex = 14;
			this.rdoHRateA.TabStop = true;
			this.rdoHRateA.Text = "  อัตรา A";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.dtpChargeTimeGroupI);
			this.groupBox1.Controls.Add(this.dtpChargeTimeGroupIII);
			this.groupBox1.Controls.Add(this.dtpChargeTimeGroupII);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.groupBox1.Location = new System.Drawing.Point(25, 136);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(520, 64);
			this.groupBox1.TabIndex = 93;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "กำหนดเวลาเทียบเท่า (สำหรับลูกค้า)";
			// 
			// dtpChargeTimeGroupI
			// 
			this.dtpChargeTimeGroupI.CustomFormat = "HH:mm";
			this.dtpChargeTimeGroupI.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.dtpChargeTimeGroupI.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpChargeTimeGroupI.Location = new System.Drawing.Point(88, 22);
			this.dtpChargeTimeGroupI.Name = "dtpChargeTimeGroupI";
			this.dtpChargeTimeGroupI.ShowUpDown = true;
			this.dtpChargeTimeGroupI.Size = new System.Drawing.Size(56, 20);
			this.dtpChargeTimeGroupI.TabIndex = 8;
			// 
			// dtpChargeTimeGroupIII
			// 
			this.dtpChargeTimeGroupIII.CustomFormat = "HH:mm";
			this.dtpChargeTimeGroupIII.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.dtpChargeTimeGroupIII.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpChargeTimeGroupIII.Location = new System.Drawing.Point(424, 22);
			this.dtpChargeTimeGroupIII.Name = "dtpChargeTimeGroupIII";
			this.dtpChargeTimeGroupIII.ShowUpDown = true;
			this.dtpChargeTimeGroupIII.Size = new System.Drawing.Size(56, 20);
			this.dtpChargeTimeGroupIII.TabIndex = 10;
			// 
			// dtpChargeTimeGroupII
			// 
			this.dtpChargeTimeGroupII.CustomFormat = "HH:mm";
			this.dtpChargeTimeGroupII.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.dtpChargeTimeGroupII.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpChargeTimeGroupII.Location = new System.Drawing.Point(272, 22);
			this.dtpChargeTimeGroupII.Name = "dtpChargeTimeGroupII";
			this.dtpChargeTimeGroupII.ShowUpDown = true;
			this.dtpChargeTimeGroupII.Size = new System.Drawing.Size(56, 20);
			this.dtpChargeTimeGroupII.TabIndex = 9;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.label5.Location = new System.Drawing.Point(376, 24);
			this.label5.Name = "label5";
			this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.label5.Size = new System.Drawing.Size(38, 16);
			this.label5.TabIndex = 12;
			this.label5.Text = "Others";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.label6.Location = new System.Drawing.Point(192, 24);
			this.label6.Name = "label6";
			this.label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.label6.Size = new System.Drawing.Size(69, 16);
			this.label6.TabIndex = 11;
			this.label6.Text = "Melco Group";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.label7.Location = new System.Drawing.Point(24, 24);
			this.label7.Name = "label7";
			this.label7.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.label7.Size = new System.Drawing.Size(56, 16);
			this.label7.TabIndex = 10;
			this.label7.Text = "TIS Group";
			// 
			// frmOTVariantEntry
			// 
			this.AcceptButton = this.cmdOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.cmdCancel;
			this.ClientSize = new System.Drawing.Size(570, 351);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupBox5);
			this.Controls.Add(this.gpbTimeInOut);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.gpbInOutStatus);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdOK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MinimizeBox = false;
			this.Name = "frmOTVariantEntry";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Load += new System.EventHandler(this.frmOTVariantEntry_Load);
			this.gpbInOutStatus.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.gpbTimeInOut.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region - Private -
		private bool isReadonly = true;
		private frmOTVariant parentForm;
		#endregion

//		============================== Property ==============================
		private OTVariant objOTVariant;
		public OTVariant ObjOTVariant
		{
			set
			{
				objOTVariant = value;
				if(value.InOutStatus == IN_OUT_STATUS_TYPE.IN)
				{
					rdoIn.Checked = true;
				}
				else
				{
					rdoOut.Checked = true;
				}

				dtpTimeFrom.Value = value.APeriod.From;
				dtpTimeTo.Value = value.APeriod.To;
				dtpTimeGroupI.Value = value.EquivalentTimeGroupI;
				dtpTimeGroupII.Value = value.EquivalentTimeGroupII;
				dtpTimeGroupIII.Value = value.EquivalentTimeGroupIII;
				dtpChargeTimeGroupI.Value = value.ChargeEquivalentTimeGroupI;
				dtpChargeTimeGroupII.Value = value.ChargeEquivalentTimeGroupII;
				dtpChargeTimeGroupIII.Value = value.ChargeEquivalentTimeGroupIII;

				switch(value.OtRateWorkingDay)
				{
					case OT_RATE_TYPE.C: 
						rdoWRateC.Checked = true;
						break;
					case OT_RATE_TYPE.B : 
						rdoWRateB.Checked = true;
						break;
					default :
						rdoWRateA.Checked = true;
						break;
				}

				switch(value.OtRateHoliday)
				{
					case OT_RATE_TYPE.C: 
						rdoHRateC.Checked = true;
						break;
					case OT_RATE_TYPE.B : 
						rdoHRateB.Checked = true;
						break;
					default :
						rdoHRateA.Checked = true;
						break;
				}
			}
			get
			{
				objOTVariant = new OTVariant();		
				if(rdoIn.Checked)
				{
					objOTVariant.InOutStatus = IN_OUT_STATUS_TYPE.IN;
				}
				else
				{
					objOTVariant.InOutStatus = IN_OUT_STATUS_TYPE.OUT;
				}

//				objOTVariant.APeriod = getTimePeriod(dtpTimeFrom.Value, dtpTimeTo.Value);
				objOTVariant.APeriod = getTime(dtpTimeFrom.Value, dtpTimeTo.Value);
				objOTVariant.EquivalentTimeGroupI = getTime(dtpTimeGroupI.Value);
				objOTVariant.EquivalentTimeGroupII = getTime(dtpTimeGroupII.Value);
				objOTVariant.EquivalentTimeGroupIII = getTime(dtpTimeGroupIII.Value);
				objOTVariant.ChargeEquivalentTimeGroupI = getTime(dtpChargeTimeGroupI.Value);
				objOTVariant.ChargeEquivalentTimeGroupII = getTime(dtpChargeTimeGroupII.Value);
				objOTVariant.ChargeEquivalentTimeGroupIII = getTime(dtpChargeTimeGroupIII.Value);
				
				if(rdoWRateA.Checked)
				{
					objOTVariant.OtRateWorkingDay = OT_RATE_TYPE.A;
				}
				else if(rdoWRateB.Checked)
				{
					objOTVariant.OtRateWorkingDay = OT_RATE_TYPE.B;
				}
				else
				{
					objOTVariant.OtRateWorkingDay = OT_RATE_TYPE.C;
				}

				if(rdoHRateA.Checked)
				{
					objOTVariant.OtRateHoliday = OT_RATE_TYPE.A;
				}
				else if(rdoHRateB.Checked)
				{
					objOTVariant.OtRateHoliday = OT_RATE_TYPE.B;
				}
				else
				{
					objOTVariant.OtRateHoliday = OT_RATE_TYPE.C;
				}
				return objOTVariant;
			}
		
		}	

//		============================== Constructor ==============================
		public frmOTVariantEntry(frmOTVariant parentForm):base()
		{
			InitializeComponent();
			this.parentForm = parentForm;
			isReadonly = UserProfile.IsReadOnly("miAttendance", "miOvertimeVariant");
		}

//		============================== private method ==============================
		private void enableKeyField(bool enable)
		{
			gpbInOutStatus.Enabled = enable;
			gpbTimeInOut.Enabled = enable;
		}

		private void clearForm()
		{
			clearTime();
			rdoHRateB.Checked = true;
			rdoWRateA.Checked = true;
			TimeConstant dtConstant = new TimeConstant();
			dtpTimeFrom.Value = dtConstant.ChangeHourMinute(4,00);
			dtpTimeTo.Value = dtConstant.ChangeHourMinute(4,04);	
			dtConstant = null;
		}

		private void clearTime()
		{
			TimeConstant dtConstant = new TimeConstant();
			DateTime tmpTime = dtConstant.ChangeHourMinute(0, 0);
			dtpChargeTimeGroupI.Value = tmpTime;
			dtpChargeTimeGroupII.Value = tmpTime;
			dtpChargeTimeGroupIII.Value = tmpTime;
			dtpTimeGroupI.Value = tmpTime;
			dtpTimeGroupII.Value = tmpTime;
			dtpTimeGroupIII.Value = tmpTime;
			dtConstant = null;
		}

		private bool validateForm()
		{
			return validateInput();
		}

		private bool validateInput()
		{
//			if (dtpTimeGroupI.Value.Hour == 0 & dtpTimeGroupI.Value.Minute == 0)
//			{
//				dtpTimeGroupI.Focus();
//				Message(MessageList.Error.E0002, "จำนวนชั่วโมง : นาที" );
//				return false;
//			}
//			if (dtpTimeGroupII.Value.Hour == 0 & dtpTimeGroupII.Value.Minute == 0)
//			{
//				dtpTimeGroupII.Focus();
//				Message(MessageList.Error.E0002, "จำนวนชั่วโมง : นาที" );
//				return false;
//			}
//			if (dtpTimeGroupIII.Value.Hour == 0 & dtpTimeGroupIII.Value.Minute == 0)
//			{
//				dtpTimeGroupIII.Focus();
//				Message(MessageList.Error.E0002, "จำนวนชั่วโมง : นาที" );
//				return false;
//			}
//			if (dtpChargeTimeGroupI.Value.Hour == 0 & dtpChargeTimeGroupI.Value.Minute == 0)
//			{
//				dtpChargeTimeGroupI.Focus();
//				Message(MessageList.Error.E0002, "จำนวนชั่วโมง : นาที" );
//				return false;
//			}
//			if (dtpChargeTimeGroupII.Value.Hour == 0 & dtpChargeTimeGroupII.Value.Minute == 0)
//			{
//				dtpChargeTimeGroupII.Focus();
//				Message(MessageList.Error.E0002, "จำนวนชั่วโมง : นาที" );
//				return false;
//			}
//			if (dtpChargeTimeGroupIII.Value.Hour == 0 & dtpChargeTimeGroupIII.Value.Minute == 0)
//			{
//				dtpChargeTimeGroupIII.Focus();
//				Message(MessageList.Error.E0002, "จำนวนชั่วโมง : นาที" );
//				return false;
//			}
			return true;	
		}

		private bool validateTime(OTVariant value)
		{
			for(int i=0; i<parentForm.FacadeOTVariant.ObjOTVariantList.Count; i++)
			{
				OTVariant otVariant = parentForm.FacadeOTVariant.ObjOTVariantList[i];
				if(value.InOutStatus == otVariant.InOutStatus)
				{
					if(value.APeriod.From <= otVariant.APeriod.To & value.APeriod.From >= otVariant.APeriod.From)
					{
						dtpTimeFrom.Focus();
						Message(MessageList.Error.E0010);
						return false;
					}				
					if(value.APeriod.To <= otVariant.APeriod.To & value.APeriod.To >= otVariant.APeriod.From)
					{
						dtpTimeTo.Focus();
						Message(MessageList.Error.E0010);
						return false;
					}
				}
			}
			return true;
		}

//		============================== public method ==============================
		public void InitAddAction()
		{
			baseADD();
			enableKeyField(true);
			clearForm();
		}

		public void InitEditAction(OTVariant value)
		{
			baseEDIT();
			clearForm();
			ObjOTVariant = value;
			enableKeyField(false);
			dtpTimeGroupI.Focus();

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
				OTVariant otVariant = ObjOTVariant;
				if (validateForm() && validateTime(otVariant) && parentForm.AddRow(otVariant))
				{
					clearTime();
					dtpTimeFrom.Focus();					
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

		private void editEvent()
		{
			try
			{
				if (validateForm() && parentForm.UpdateRow(ObjOTVariant))
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

//		============================== event ==============================
		private void frmOTVariantEntry_Load(object sender, System.EventArgs e)
		{
			if(action == ActionType.ADD)
			{
				dtpTimeFrom.Focus();	
			}
			else
			{
				dtpChargeTimeGroupI.Focus();
			}
		}

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
	}
}
