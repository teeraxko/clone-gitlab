using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;

using Entity.CommonEntity;
using Entity.AttendanceEntities;

using Facade.CommonFacade;
using Facade.AttendanceFacade;

using Presentation.CommonGUI;

using SystemFramework.AppConfig;
using SystemFramework.AppMessage;
using SystemFramework.AppException;

using ictus.Common.Entity.Time;

namespace Presentation.AttendanceGUI
{
	public class frmEmployeeWorkAttendanceEntry : EntryFormBase
	{
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		private System.Windows.Forms.DateTimePicker dtpForDay;
		private System.Windows.Forms.RadioButton rdoHoliday;
		private System.Windows.Forms.RadioButton rdoWorking;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker dtpEndBreak;
		private System.Windows.Forms.DateTimePicker dtpStartBreak;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.DateTimePicker dtpEndWork;
		private System.Windows.Forms.DateTimePicker dtpStartWork;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.GroupBox gpbWorkingStatus;
		private System.Windows.Forms.ComboBox cboAfterBreak;
		private System.Windows.Forms.ComboBox cboBeforeBreak;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox gpbForDate;
		private System.Windows.Forms.GroupBox gpbForTime;

		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
			this.gpbForDate = new System.Windows.Forms.GroupBox();
			this.dtpForDay = new System.Windows.Forms.DateTimePicker();
			this.rdoHoliday = new System.Windows.Forms.RadioButton();
			this.rdoWorking = new System.Windows.Forms.RadioButton();
			this.label7 = new System.Windows.Forms.Label();
			this.gpbForTime = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.dtpEndBreak = new System.Windows.Forms.DateTimePicker();
			this.dtpStartBreak = new System.Windows.Forms.DateTimePicker();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.dtpEndWork = new System.Windows.Forms.DateTimePicker();
			this.dtpStartWork = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdOK = new System.Windows.Forms.Button();
			this.gpbWorkingStatus = new System.Windows.Forms.GroupBox();
			this.cboAfterBreak = new System.Windows.Forms.ComboBox();
			this.cboBeforeBreak = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.gpbForDate.SuspendLayout();
			this.gpbForTime.SuspendLayout();
			this.gpbWorkingStatus.SuspendLayout();
			this.SuspendLayout();
			// 
			// gpbForDate
			// 
			this.gpbForDate.Controls.Add(this.dtpForDay);
			this.gpbForDate.Controls.Add(this.rdoHoliday);
			this.gpbForDate.Controls.Add(this.rdoWorking);
			this.gpbForDate.Controls.Add(this.label7);
			this.gpbForDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.gpbForDate.Location = new System.Drawing.Point(16, 16);
			this.gpbForDate.Name = "gpbForDate";
			this.gpbForDate.Size = new System.Drawing.Size(432, 56);
			this.gpbForDate.TabIndex = 29;
			this.gpbForDate.TabStop = false;
			// 
			// dtpForDay
			// 
			this.dtpForDay.CustomFormat = "dd";
			this.dtpForDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.dtpForDay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpForDay.Location = new System.Drawing.Point(96, 24);
			this.dtpForDay.Name = "dtpForDay";
			this.dtpForDay.ShowUpDown = true;
			this.dtpForDay.Size = new System.Drawing.Size(40, 20);
			this.dtpForDay.TabIndex = 28;
			// 
			// rdoHoliday
			// 
			this.rdoHoliday.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.rdoHoliday.Location = new System.Drawing.Point(272, 24);
			this.rdoHoliday.Name = "rdoHoliday";
			this.rdoHoliday.Size = new System.Drawing.Size(64, 24);
			this.rdoHoliday.TabIndex = 27;
			this.rdoHoliday.Text = " วันหยุด";
			this.rdoHoliday.CheckedChanged += new System.EventHandler(this.rdoHoliday_CheckedChanged);
			// 
			// rdoWorking
			// 
			this.rdoWorking.Checked = true;
			this.rdoWorking.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.rdoWorking.Location = new System.Drawing.Point(184, 24);
			this.rdoWorking.Name = "rdoWorking";
			this.rdoWorking.Size = new System.Drawing.Size(80, 24);
			this.rdoWorking.TabIndex = 26;
			this.rdoWorking.TabStop = true;
			this.rdoWorking.Text = " วันทำงาน";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.label7.Location = new System.Drawing.Point(24, 24);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(53, 16);
			this.label7.TabIndex = 23;
			this.label7.Text = "สำหรับวันที่";
			// 
			// gpbForTime
			// 
			this.gpbForTime.Controls.Add(this.label2);
			this.gpbForTime.Controls.Add(this.dtpEndBreak);
			this.gpbForTime.Controls.Add(this.dtpStartBreak);
			this.gpbForTime.Controls.Add(this.label6);
			this.gpbForTime.Controls.Add(this.label5);
			this.gpbForTime.Controls.Add(this.dtpEndWork);
			this.gpbForTime.Controls.Add(this.dtpStartWork);
			this.gpbForTime.Controls.Add(this.label1);
			this.gpbForTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.gpbForTime.Location = new System.Drawing.Point(16, 72);
			this.gpbForTime.Name = "gpbForTime";
			this.gpbForTime.Size = new System.Drawing.Size(432, 96);
			this.gpbForTime.TabIndex = 30;
			this.gpbForTime.TabStop = false;
			this.gpbForTime.Text = "กำหนดเวลา";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.label2.Location = new System.Drawing.Point(208, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(16, 23);
			this.label2.TabIndex = 36;
			this.label2.Text = "-";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// dtpEndBreak
			// 
			this.dtpEndBreak.CustomFormat = "HH:mm";
			this.dtpEndBreak.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.dtpEndBreak.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpEndBreak.Location = new System.Drawing.Point(248, 56);
			this.dtpEndBreak.Name = "dtpEndBreak";
			this.dtpEndBreak.ShowUpDown = true;
			this.dtpEndBreak.Size = new System.Drawing.Size(64, 20);
			this.dtpEndBreak.TabIndex = 35;
			// 
			// dtpStartBreak
			// 
			this.dtpStartBreak.CustomFormat = "HH:mm";
			this.dtpStartBreak.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.dtpStartBreak.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpStartBreak.Location = new System.Drawing.Point(120, 56);
			this.dtpStartBreak.Name = "dtpStartBreak";
			this.dtpStartBreak.ShowUpDown = true;
			this.dtpStartBreak.Size = new System.Drawing.Size(64, 20);
			this.dtpStartBreak.TabIndex = 34;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.label6.Location = new System.Drawing.Point(40, 56);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(37, 16);
			this.label6.TabIndex = 33;
			this.label6.Text = "เวลาพัก";
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.label5.Location = new System.Drawing.Point(208, 24);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(16, 23);
			this.label5.TabIndex = 32;
			this.label5.Text = "-";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// dtpEndWork
			// 
			this.dtpEndWork.CustomFormat = "HH:mm";
			this.dtpEndWork.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.dtpEndWork.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpEndWork.Location = new System.Drawing.Point(248, 24);
			this.dtpEndWork.Name = "dtpEndWork";
			this.dtpEndWork.ShowUpDown = true;
			this.dtpEndWork.Size = new System.Drawing.Size(64, 20);
			this.dtpEndWork.TabIndex = 31;
			// 
			// dtpStartWork
			// 
			this.dtpStartWork.CustomFormat = "HH:mm";
			this.dtpStartWork.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.dtpStartWork.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpStartWork.Location = new System.Drawing.Point(120, 24);
			this.dtpStartWork.Name = "dtpStartWork";
			this.dtpStartWork.ShowUpDown = true;
			this.dtpStartWork.Size = new System.Drawing.Size(64, 20);
			this.dtpStartWork.TabIndex = 30;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.label1.Location = new System.Drawing.Point(40, 26);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(51, 16);
			this.label1.TabIndex = 27;
			this.label1.Text = "เวลาทำงาน";
			// 
			// cmdCancel
			// 
			this.cmdCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cmdCancel.Location = new System.Drawing.Point(236, 248);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.TabIndex = 28;
			this.cmdCancel.Text = "ยกเลิก";
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			// 
			// cmdOK
			// 
			this.cmdOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cmdOK.Location = new System.Drawing.Point(156, 248);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.TabIndex = 27;
			this.cmdOK.Text = "ตกลง";
			this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
			// 
			// gpbWorkingStatus
			// 
			this.gpbWorkingStatus.Controls.Add(this.cboAfterBreak);
			this.gpbWorkingStatus.Controls.Add(this.cboBeforeBreak);
			this.gpbWorkingStatus.Controls.Add(this.label3);
			this.gpbWorkingStatus.Controls.Add(this.label4);
			this.gpbWorkingStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.gpbWorkingStatus.Location = new System.Drawing.Point(16, 168);
			this.gpbWorkingStatus.Name = "gpbWorkingStatus";
			this.gpbWorkingStatus.Size = new System.Drawing.Size(432, 64);
			this.gpbWorkingStatus.TabIndex = 31;
			this.gpbWorkingStatus.TabStop = false;
			this.gpbWorkingStatus.Text = "สถานะการทำงาน";
			// 
			// cboAfterBreak
			// 
			this.cboAfterBreak.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboAfterBreak.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cboAfterBreak.Location = new System.Drawing.Point(280, 24);
			this.cboAfterBreak.Name = "cboAfterBreak";
			this.cboAfterBreak.Size = new System.Drawing.Size(136, 21);
			this.cboAfterBreak.TabIndex = 7;
			this.cboAfterBreak.SelectedIndexChanged += new System.EventHandler(this.cboAfterBreak_SelectedIndexChanged);
			// 
			// cboBeforeBreak
			// 
			this.cboBeforeBreak.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboBeforeBreak.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cboBeforeBreak.Location = new System.Drawing.Point(72, 24);
			this.cboBeforeBreak.Name = "cboBeforeBreak";
			this.cboBeforeBreak.Size = new System.Drawing.Size(136, 21);
			this.cboBeforeBreak.TabIndex = 6;
			this.cboBeforeBreak.SelectedIndexChanged += new System.EventHandler(this.cboBeforeBreak_SelectedIndexChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.label3.Location = new System.Drawing.Point(224, 24);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(50, 16);
			this.label3.TabIndex = 37;
			this.label3.Text = "ครึ่งวันหลัง";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.label4.Location = new System.Drawing.Point(16, 24);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(51, 16);
			this.label4.TabIndex = 33;
			this.label4.Text = "ครึ่งวันแรก";
			// 
			// frmEmployeeWorkAttendanceEntry
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(466, 287);
			this.Controls.Add(this.gpbWorkingStatus);
			this.Controls.Add(this.gpbForDate);
			this.Controls.Add(this.gpbForTime);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdOK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "frmEmployeeWorkAttendanceEntry";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Load += new System.EventHandler(this.frmEmployeeWorkAttendanceEntry_Load);
			this.gpbForDate.ResumeLayout(false);
			this.gpbForTime.ResumeLayout(false);
			this.gpbWorkingStatus.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region - private -
		private bool isReadonly = true;
		private frmEmployeeWorkAttendance parentForm;
		#endregion

//		============================== Property ==============================
		private WorkSchedule objWorkSchedule;
		public WorkSchedule ObjWorkSchedule
		{
			set
			{
				objWorkSchedule = value;
				dtpForDay.Value = value.WorkDate;

				if(value.DayType == WORKINGDAY_TYPE.HOLIDAY)
				{
					rdoHoliday.Checked = true;				
				}
				else
				{
					rdoWorking.Checked = true;
				}
				
				dtpStartWork.Value = value.AWorkingTime.From;
				dtpEndWork.Value = value.AWorkingTime.To;
				dtpStartBreak.Value = value.ABreakTime.From;
				dtpEndBreak.Value = value.ABreakTime.To;
			}
			get
			{
				objWorkSchedule = new WorkSchedule();
				objWorkSchedule.WorkDate = dtpForDay.Value.Date;
				objWorkSchedule.AWorkingTime = getTimePeriod(dtpStartWork.Value, dtpEndWork.Value, dtpForDay.Value);
				objWorkSchedule.ABreakTime = getBreakTimePeriod(dtpStartBreak.Value, dtpEndBreak.Value, dtpStartWork.Value, dtpEndWork.Value, dtpForDay.Value);

				if(rdoHoliday.Checked)
				{
					objWorkSchedule.DayType = WORKINGDAY_TYPE.HOLIDAY;
				}
				else
				{
					objWorkSchedule.DayType = WORKINGDAY_TYPE.WORKINGDAY;
				}		
				
				return objWorkSchedule;
			}
		}

		private TimeCard objTimeCard;
		public TimeCard ObjTimeCard
		{
			set
			{
				objTimeCard = value;
				dtpForDay.Value = value.CardDate;
				dtpStartWork.Value = value.ATimePeriod.From;
				dtpEndWork.Value = value.ATimePeriod.To;
				cboBeforeBreak.Text = value.ABeforeBreakStatus.AName.Thai;
				cboAfterBreak.Text = value.AAfterBreakStatus.AName.Thai;
				if(value.DayType == WORKINGDAY_TYPE.HOLIDAY)
				{
					rdoHoliday.Checked = true;				
				}
				else
				{
					rdoWorking.Checked = true;
				}
			}
			get
			{
				objTimeCard = new TimeCard();
				objTimeCard.CardDate = dtpForDay.Value.Date;
				objTimeCard.ATimePeriod = getTimePeriod(dtpStartWork.Value, dtpEndWork.Value, dtpForDay.Value);
				objTimeCard.ABeforeBreakStatus = (AttendanceStatus)cboBeforeBreak.SelectedItem;
				objTimeCard.AAfterBreakStatus = (AttendanceStatus)cboAfterBreak.SelectedItem;
				if(rdoHoliday.Checked)
				{
					objTimeCard.DayType = WORKINGDAY_TYPE.HOLIDAY;
				}
				else
				{
					objTimeCard.DayType = WORKINGDAY_TYPE.WORKINGDAY;
				}		
				return objTimeCard;
			}	
		}

//		============================== Constructor ==============================
		public frmEmployeeWorkAttendanceEntry(frmEmployeeWorkAttendance parentForm) : base()
		{
			InitializeComponent();
			this.parentForm = parentForm;
			isReadonly = UserProfile.IsReadOnly("miAttendance", "miEmployeeWorkSchedule");

			try
			{			
				cboBeforeBreak.DataSource = parentForm.FacadeEmployeeWorkAttendance.DataSourceAttendanceStatus;
				cboAfterBreak.DataSource = parentForm.FacadeEmployeeWorkAttendance.DataSourceAttendanceStatus;
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
		#region - CalculateTimeCard -
        //private void calculateForm()
        //{
        //    clearCombo();

        //    WorkSchedule workSchedule = parentForm.FacadeEmployeeWorkAttendance.GetWorkSchedule(dtpForDay.Value.Date);
        //    AttendanceStatus attendanceStatus = new AttendanceStatus();

        //    if(workSchedule == null)
        //    {
        //        clearCombo();
        //    }
        //    else
        //    {
        //        if(rdoHoliday.Checked)
        //        {
        //            attendanceStatus.Code = "H1";
        //            setSelectedByCode(cboBeforeBreak, attendanceStatus);
        //            setSelectedByCode(cboAfterBreak, attendanceStatus);
        //        }
        //        else
        //        {
        //            if(dtpStartWork.Value > workSchedule.AWorkingTime.From.AddMinutes(30))
        //            {
        //                attendanceStatus.Code = "";
        //                setSelectedByCode(cboBeforeBreak, attendanceStatus);
        //            }
        //            else
        //            {
        //                if(dtpStartWork.Value <= workSchedule.AWorkingTime.From && dtpEndWork.Value >= workSchedule.ABreakTime.From)
        //                {
        //                    attendanceStatus.Code = "WK";
        //                    setSelectedByCode(cboBeforeBreak, attendanceStatus);
        //                }
						
        //                if((dtpStartWork.Value > workSchedule.AWorkingTime.From && dtpStartWork.Value <= workSchedule.AWorkingTime.From.AddMinutes(30)) && (dtpEndWork.Value >= workSchedule.ABreakTime.From))
        //                {
        //                    attendanceStatus.Code = "L1";
        //                    setSelectedByCode(cboBeforeBreak, attendanceStatus);
        //                }

        //                if((dtpStartWork.Value <= workSchedule.AWorkingTime.From) && (dtpEndWork.Value >= workSchedule.ABreakTime.From.AddMinutes(-30) && dtpEndWork.Value < workSchedule.ABreakTime.From))
        //                {
        //                    attendanceStatus.Code = "L2";
        //                    setSelectedByCode(cboBeforeBreak, attendanceStatus);
        //                }		
        //            }


        //            if(dtpEndWork.Value < workSchedule.AWorkingTime.To.AddMinutes(-30))
        //            {
        //                attendanceStatus.Code = "";
        //                setSelectedByCode(cboAfterBreak, attendanceStatus);
        //            }
        //            else
        //            {
        //                if(dtpEndWork.Value >= workSchedule.AWorkingTime.To && dtpStartWork.Value <= workSchedule.ABreakTime.To)
        //                {
        //                    attendanceStatus.Code = "WK";
        //                    setSelectedByCode(cboAfterBreak, attendanceStatus);
        //                }

        //                if((dtpStartWork.Value > workSchedule.ABreakTime.To && dtpStartWork.Value <= workSchedule.ABreakTime.To.AddMinutes(30)) && (dtpEndWork.Value >= workSchedule.AWorkingTime.To))
        //                {
        //                    attendanceStatus.Code = "L1";
        //                    setSelectedByCode(cboAfterBreak, attendanceStatus);
        //                }

        //                if((dtpStartWork.Value <= workSchedule.ABreakTime.To) && (dtpEndWork.Value >= workSchedule.AWorkingTime.To.AddMinutes(-30) && dtpEndWork.Value < workSchedule.AWorkingTime.To))
        //                {
        //                    attendanceStatus.Code = "L2";
        //                    setSelectedByCode(cboAfterBreak, attendanceStatus);
        //                }
        //            }			
        //        }			
        //    }
        //    workSchedule = null;
        //}
		#endregion

		private void enableKeyField(bool enable)
		{
			dtpForDay.Enabled = enable;
		}

		private void enableCase(bool enable)
		{
			gpbWorkingStatus.Enabled = enable;
		}

		private void clearForm()
		{
			rdoWorking.Checked = true;

			TimeConstant dtConstant = new TimeConstant();
			dtpStartWork.Value = dtConstant.ChangeHourMinute(8,30);
			dtpEndWork.Value = dtConstant.ChangeHourMinute(17,00);
			dtpStartBreak.Value = dtConstant.ChangeHourMinute(12,00);
			dtpEndBreak.Value = dtConstant.ChangeHourMinute(13,00);

			clearCombo();
			enableCase(true);
		}

		private void clearCombo()
		{
			AttendanceStatus attendanceStatus = new AttendanceStatus();
			attendanceStatus.Code = "";
			setSelectedByCode(cboBeforeBreak, attendanceStatus);
			setSelectedByCode(cboAfterBreak, attendanceStatus);
			attendanceStatus = null;
		}

		private void enableWorkingStatus(TimeCard value)
		{
			string statusBefore = value.ABeforeBreakStatus.Code;
			string statusAfter = value.AAfterBreakStatus.Code;

			if	(statusBefore.Equals("A1") || statusBefore.Equals("B1") || statusBefore.Equals("P1") ||
				statusBefore.Equals("S1") || statusBefore.Equals("S2") || statusBefore.Equals("T1"))
			{
				enableForm(false);
			}
			else
			{
				enableForm(true);

				if (statusBefore.Equals("H1"))
				{
					gpbWorkingStatus.Enabled = false;
				}
			}

			if	(statusAfter.Equals("A1") || statusAfter.Equals("B1") || statusAfter.Equals("P1") ||
				statusAfter.Equals("S1") || statusAfter.Equals("S2") || statusAfter.Equals("T1"))
			{
				enableForm(false);
			}
			else
			{
				enableForm(true);

				if (statusAfter.Equals("H1"))
				{
					gpbWorkingStatus.Enabled = false;
				}
			}
		}

		private void enableForm(bool value)
		{
			cmdOK.Enabled = value;
			gpbForDate.Enabled = value;
			gpbForTime.Enabled = value;		
			gpbWorkingStatus.Enabled = value;
		}

		private void enableCombo()
		{
			string statusAfter = ((AttendanceStatus)cboAfterBreak.SelectedItem).Code;
			string statusBefore = ((AttendanceStatus)cboBeforeBreak.SelectedItem).Code;
			
			if	(statusBefore.Equals("A1") || statusBefore.Equals("B1") || statusBefore.Equals("P1") ||
				statusBefore.Equals("S1") || statusBefore.Equals("S2") || statusBefore.Equals("T1") || 
				(statusBefore.Equals("H1") & !rdoHoliday.Checked))
			{
				cmdOK.Enabled = false;
			}
			else
			{
				cmdOK.Enabled = true;
			}

			if(cmdOK.Enabled)
			{
				if	(statusAfter.Equals("A1") || statusAfter.Equals("B1") || statusAfter.Equals("P1") ||
					statusAfter.Equals("S1") || statusAfter.Equals("S2") || statusAfter.Equals("T1") || 
					(statusAfter.Equals("H1") & !rdoHoliday.Checked))
				{
					cmdOK.Enabled = false;
				}
				else
				{
					cmdOK.Enabled = true;
				}
			}
		}

		#region - validate -
		private bool validatePeriodTime(WorkSchedule value)
		{
			if(value.AWorkingTime.From >= value.ABreakTime.From || value.AWorkingTime.To <= value.ABreakTime.From)
			{
				Message(MessageList.Error.E0046, "เวลาพัก", "เวลาทำงาน" );
				dtpStartBreak.Focus();
				return false;
			}
			if(value.AWorkingTime.From >= value.ABreakTime.To || value.AWorkingTime.To <= value.ABreakTime.To)
			{
				Message(MessageList.Error.E0046, "เวลาพัก", "เวลาทำงาน" );
				dtpEndBreak.Focus();
				return false;
			}
			return true;	
		}

		private bool validateTimeCard()
		{
			return validateCombo() && validateHoliday();
		}

		private bool validateCombo()
		{
//			if(!rdoHoliday.Checked)
//			{
//				AttendanceStatus attendanceStatus = (AttendanceStatus)cboBeforeBreak.SelectedItem;
//				if(attendanceStatus.Code == "")
//				{
//					Message(MessageList.Error.E0005, "สถานะการทำงาน" );
//					cboBeforeBreak.Focus();
//					return false;
//				}
//				attendanceStatus = (AttendanceStatus)cboAfterBreak.SelectedItem;
//				if(attendanceStatus.Code == "")
//				{
//					Message(MessageList.Error.E0005, "สถานะการทำงาน" );
//					cboAfterBreak.Focus();
//					return false;
//				}
//			}
			return true;
		}

		private bool validateHoliday()
		{
			string statusBefore = ((AttendanceStatus)cboBeforeBreak.SelectedItem).Code;
			string statusAfter = ((AttendanceStatus)cboAfterBreak.SelectedItem).Code;

			if(!rdoHoliday.Checked)
			{
				if(statusBefore.Equals("H1"))
				{
					Message(MessageList.Error.E0013, "เลือกสถานะวันหยุดได้","ไม่ใช่วันหยุด" );
					cboBeforeBreak.Focus();
					return false;
				}
				if(statusAfter.Equals("H1"))
				{
					Message(MessageList.Error.E0013, "เลือกสถานะวันหยุดได้","ไม่ใช่วันหยุด" );
					cboAfterBreak.Focus();
					return false;
				}
				if	(statusBefore.Equals("A1") || statusBefore.Equals("B1") || statusBefore.Equals("P1") ||
					statusBefore.Equals("S1") || statusBefore.Equals("S2") || statusBefore.Equals("T1"))
				{
					Message(MessageList.Error.E0013, "เลือกสถานะนี้ได้","เป็นวันทำงาน" );
					cboBeforeBreak.Focus();
					return false;
				}
				if	(statusAfter.Equals("A1") || statusAfter.Equals("B1") || statusAfter.Equals("P1") ||
					statusAfter.Equals("S1") || statusAfter.Equals("S2") || statusAfter.Equals("T1"))
				{
					Message(MessageList.Error.E0013, "เลือกสถานะนี้ได้","เป็นวันทำงาน" );
					cboAfterBreak.Focus();
					return false;
				}
			}
			return true;
		}

		#endregion

//		============================== public method ==============================
		public void InitAddAction(DateTime forDate)
		{
			baseADD();
			clearForm();
			enableKeyField(true);

			setDTPForMonth(dtpForDay, forDate);
			YearMonth yearMonth = new YearMonth(forDate);
			dtpForDay.Value = yearMonth.MinDateOfMonth;
		}

		public void InitEditAction(WorkSchedule aWorkSchedule, TimeCard aTimeCard)
		{
			baseEDIT();
			clearForm();
			ObjWorkSchedule = aWorkSchedule;
			ObjTimeCard = aTimeCard;
			enableKeyField(false);
			enableWorkingStatus(aTimeCard);

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
				WorkSchedule workSchedule = ObjWorkSchedule;

				if (validatePeriodTime(workSchedule) && validateTimeCard() && parentForm.AddRow(workSchedule, ObjTimeCard))
				{
					clearForm();
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
				WorkSchedule workSchedule = ObjWorkSchedule;

				if (validatePeriodTime(workSchedule) && validateTimeCard() && parentForm.UpdateRow(workSchedule, ObjTimeCard))
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
		private void frmEmployeeWorkAttendanceEntry_Load(object sender, System.EventArgs e)
		{
		
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

		private void rdoHoliday_CheckedChanged(object sender, System.EventArgs e)
		{
			if(rdoHoliday.Checked)
			{
				AttendanceStatus attendanceStatus = new AttendanceStatus();
				attendanceStatus.Code = "H1";
				setSelectedByCode(cboBeforeBreak, attendanceStatus);
				setSelectedByCode(cboAfterBreak, attendanceStatus);
				enableCase(false);
			}
			else
			{
				enableCase(true);
			}
		
			enableCombo();
		}

		private void cboBeforeBreak_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			enableCombo();
		}

		private void cboAfterBreak_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			enableCombo();
		}
	}
}
