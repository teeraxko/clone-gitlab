using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Entity.CommonEntity;
using Entity.AttendanceEntities;

using Presentation.CommonGUI;

using SystemFramework.AppException;
using SystemFramework.AppMessage;
using SystemFramework.AppConfig;
using ictus.Common.Entity.General;

namespace Presentation.AttendanceGUI
{
	public class frmEmployeeAnnualLeaveEntry : EntryFormBase
	{
		#region Windows Form Designer generated code
		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.DateTimePicker dtpToDate;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker dtpFromDate;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cboLeaveReason;
		private Presentation.AttendanceGUI.UCTLeavePeriod uctLeavePeriodFrom;
		private Presentation.AttendanceGUI.UCTLeavePeriod uctLeavePeriodTo;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox cboLeaveYearStatus;
		private System.ComponentModel.Container components = null;

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

		private void InitializeComponent()
		{
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdOK = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label5 = new System.Windows.Forms.Label();
			this.cboLeaveYearStatus = new System.Windows.Forms.ComboBox();
			this.uctLeavePeriodTo = new Presentation.AttendanceGUI.UCTLeavePeriod();
			this.label4 = new System.Windows.Forms.Label();
			this.dtpToDate = new System.Windows.Forms.DateTimePicker();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.cboLeaveReason = new System.Windows.Forms.ComboBox();
			this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.uctLeavePeriodFrom = new Presentation.AttendanceGUI.UCTLeavePeriod();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// cmdCancel
			// 
			this.cmdCancel.Location = new System.Drawing.Point(240, 312);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.TabIndex = 5;
			this.cmdCancel.Text = "ยกเลิก";
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			// 
			// cmdOK
			// 
			this.cmdOK.Location = new System.Drawing.Point(160, 312);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.TabIndex = 4;
			this.cmdOK.Text = "ตกลง";
			this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.cboLeaveYearStatus);
			this.groupBox1.Controls.Add(this.uctLeavePeriodTo);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.dtpToDate);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.cboLeaveReason);
			this.groupBox1.Controls.Add(this.dtpFromDate);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.uctLeavePeriodFrom);
			this.groupBox1.Location = new System.Drawing.Point(16, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(440, 288);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(32, 216);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(40, 23);
			this.label5.TabIndex = 11;
			this.label5.Text = "ปีที่ใช้";
			// 
			// cboLeaveYearStatus
			// 
			this.cboLeaveYearStatus.ItemHeight = 13;
			this.cboLeaveYearStatus.Location = new System.Drawing.Point(80, 216);
			this.cboLeaveYearStatus.Name = "cboLeaveYearStatus";
			this.cboLeaveYearStatus.Size = new System.Drawing.Size(168, 21);
			this.cboLeaveYearStatus.TabIndex = 10;
			// 
			// uctLeavePeriodTo
			// 
			this.uctLeavePeriodTo.Location = new System.Drawing.Point(240, 72);
			this.uctLeavePeriodTo.Name = "uctLeavePeriodTo";
			this.uctLeavePeriodTo.SelectedValue = Presentation.AttendanceGUI.UCTLeavePeriod.PERIOD_TYPE.ALL_DAY;
			this.uctLeavePeriodTo.Size = new System.Drawing.Size(136, 136);
			this.uctLeavePeriodTo.TabIndex = 9;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(280, 24);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(56, 23);
			this.label4.TabIndex = 7;
			this.label4.Text = "วันที่สิ้นสุด";
			// 
			// dtpToDate
			// 
			this.dtpToDate.CustomFormat = "dd/MM/yyyy";
			this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpToDate.Location = new System.Drawing.Point(248, 48);
			this.dtpToDate.Name = "dtpToDate";
			this.dtpToDate.Size = new System.Drawing.Size(120, 20);
			this.dtpToDate.TabIndex = 6;
			this.dtpToDate.ValueChanged += new System.EventHandler(this.dtpToDate_ValueChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(216, 48);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(16, 23);
			this.label3.TabIndex = 5;
			this.label3.Text = " - ";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(32, 248);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 23);
			this.label2.TabIndex = 3;
			this.label2.Text = "สาเหตุ";
			// 
			// cboLeaveReason
			// 
			this.cboLeaveReason.ItemHeight = 13;
			this.cboLeaveReason.Location = new System.Drawing.Point(80, 248);
			this.cboLeaveReason.Name = "cboLeaveReason";
			this.cboLeaveReason.Size = new System.Drawing.Size(288, 21);
			this.cboLeaveReason.TabIndex = 2;
			// 
			// dtpFromDate
			// 
			this.dtpFromDate.CustomFormat = "dd/MM/yyyy";
			this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpFromDate.Location = new System.Drawing.Point(80, 48);
			this.dtpFromDate.Name = "dtpFromDate";
			this.dtpFromDate.Size = new System.Drawing.Size(120, 20);
			this.dtpFromDate.TabIndex = 1;
			this.dtpFromDate.ValueChanged += new System.EventHandler(this.dtpFromDate_ValueChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(112, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "วันที่เริ่มต้น";
			// 
			// uctLeavePeriodFrom
			// 
			this.uctLeavePeriodFrom.Location = new System.Drawing.Point(72, 72);
			this.uctLeavePeriodFrom.Name = "uctLeavePeriodFrom";
			this.uctLeavePeriodFrom.SelectedValue = Presentation.AttendanceGUI.UCTLeavePeriod.PERIOD_TYPE.ALL_DAY;
			this.uctLeavePeriodFrom.Size = new System.Drawing.Size(136, 136);
			this.uctLeavePeriodFrom.TabIndex = 8;
			// 
			// frmEmployeeAnnualLeaveEntry
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(474, 352);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdOK);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "frmEmployeeAnnualLeaveEntry";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "ข้อมูลการลาพักร้อนประจำปี";
			this.Load += new System.EventHandler(this.frmEmployeeAnnualLeaveEntry_Load);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Private Variable
		private bool isReadonly = true;
		private frmEmployeeAnnualLeave parentForm;

		private AnnualLeaveDayList annualLeaveDayList;
		private AnnualLeaveDay getAnnualLeaveDay
		{
			get
			{				
				AnnualLeave annualLeave = parentForm.FacadeEmployeeAnnualLeave.AnnualLeave;

				AnnualLeaveDay annualLeaveDay = new AnnualLeaveDay(dtpFromDate.Value);
				annualLeaveDay.ForYear = annualLeave.ForYear;
				annualLeaveDay.LeaveYearStatus = getLeaveYearStatus;
				annualLeaveDay.PeriodStatus = getLeavePeriod(uctLeavePeriodFrom);
				annualLeaveDay.Reason.Name = cboLeaveReason.Text;

				annualLeave = null;
				return annualLeaveDay;
			}
		}

		private AnnualLeaveDayList getAnnualLeaveDayList
		{
			get
			{
				AnnualLeaveDay annualLeaveDay;
				AnnualLeave annualLeave = parentForm.FacadeEmployeeAnnualLeave.AnnualLeave;
				annualLeaveDayList = new AnnualLeaveDayList(annualLeave.Employee);

				for(DateTime tempDate = dtpFromDate.Value; tempDate<= dtpToDate.Value; tempDate = tempDate.AddDays(1))
				{
					annualLeaveDay = new AnnualLeaveDay(tempDate);
					annualLeaveDay.ForYear = annualLeave.ForYear;
					annualLeaveDay.LeaveYearStatus = getLeaveYearStatus;
					#region annualLeaveDay.PeriodStatus
						if(tempDate==dtpFromDate.Value)
						{
							annualLeaveDay.PeriodStatus = getLeavePeriod(uctLeavePeriodFrom);
						}
						else
						{
							if(tempDate==dtpToDate.Value)
							{
								annualLeaveDay.PeriodStatus = getLeavePeriod(uctLeavePeriodTo);
							}
							else
							{
								annualLeaveDay.PeriodStatus = LEAVE_PERIOD_TYPE.ONE_DAY;
							}
						}
					#endregion
					annualLeaveDay.Reason.Name = cboLeaveReason.Text;

					annualLeaveDayList.Add(annualLeaveDay);
				}

				return annualLeaveDayList;
			}
		}

		private LEAVE_YEAR_STATUS_TYPE getLeaveYearStatus
		{
			get
			{
				AnnualLeave annualLeave = parentForm.FacadeEmployeeAnnualLeave.AnnualLeave;
				if(cboLeaveYearStatus.Text==annualLeave.ForYear.ToString())
				{
					annualLeave = null;
					return LEAVE_YEAR_STATUS_TYPE.CURRENT;
				}
				else
				{
					if(cboLeaveYearStatus.Text==(annualLeave.ForYear-1).ToString())
					{
						annualLeave = null;
						return LEAVE_YEAR_STATUS_TYPE.PREVIOUS;
					}
					else
					{
						annualLeave = null;
						return LEAVE_YEAR_STATUS_TYPE.MIX;
					}
				}
			}
        }
        #endregion

        #region Constructor
        public frmEmployeeAnnualLeaveEntry(frmEmployeeAnnualLeave value)
        {
            InitializeComponent();
            parentForm = value;
            isReadonly = UserProfile.IsReadOnly("miAttendance", "miGenAnnualLeaveDay");
        } 
        #endregion

		#region - Private Method -
		public void initForm(DateTime value)
		{
			setDTPForMonth(dtpFromDate, value);
			setDTPForMonth(dtpToDate, value);

			cboLeaveReason.DataSource = parentForm.FacadeEmployeeAnnualLeave.DataSourceLeaveReason;
			cboLeaveYearStatus.DataSource = parentForm.FacadeEmployeeAnnualLeave.DataSourceLeaveYearStatus();
		}

		private LEAVE_PERIOD_TYPE getLeavePeriod(UCTLeavePeriod control)
		{
			switch(control.SelectedValue)
			{
				case UCTLeavePeriod.PERIOD_TYPE.AM :
				{
					return LEAVE_PERIOD_TYPE.AM;
				}
				case UCTLeavePeriod.PERIOD_TYPE.PM :
				{
					return LEAVE_PERIOD_TYPE.PM;
				}
				default :
				{
					return LEAVE_PERIOD_TYPE.ONE_DAY;
				}
			}
		}

		private void clearForm(DateTime value)
		{
			dtpFromDate.Enabled = true;
			dtpToDate.Enabled = true;
			
			uctLeavePeriodFrom.SelectedValue = UCTLeavePeriod.PERIOD_TYPE.ALL_DAY;
			uctLeavePeriodTo.SelectedValue = UCTLeavePeriod.PERIOD_TYPE.ALL_DAY;
		}

		private void bindForm(AnnualLeaveDay value)
			{
				dtpFromDate.Value = value.LeaveDate;
				dtpFromDate.Enabled = false;
				dtpToDate.Value = value.LeaveDate;
				dtpToDate.Enabled = false;
				switch(value.PeriodStatus)
				{
					case LEAVE_PERIOD_TYPE.AM :
					{
						uctLeavePeriodFrom.SelectedValue = UCTLeavePeriod.PERIOD_TYPE.AM;
						break;
					}
					case LEAVE_PERIOD_TYPE.PM :
					{
						uctLeavePeriodFrom.SelectedValue = UCTLeavePeriod.PERIOD_TYPE.PM;
						break;
					}
					case LEAVE_PERIOD_TYPE.ONE_DAY :
					{
						uctLeavePeriodFrom.SelectedValue = UCTLeavePeriod.PERIOD_TYPE.ALL_DAY;
						break;
					}
				}
				uctLeavePeriodTo.Clear();
				switch(value.LeaveYearStatus)
				{
					case LEAVE_YEAR_STATUS_TYPE.CURRENT :
					{
						cboLeaveYearStatus.Text = value.ForYear.ToString();
						break;
					}
					case LEAVE_YEAR_STATUS_TYPE.PREVIOUS :
					{
						cboLeaveYearStatus.Text = (value.ForYear-1).ToString();
						break;
					}
					default :
					{
						cboLeaveYearStatus.SelectedIndex = 0;
						break;
					}
				}
				cboLeaveReason.Text = value.Reason.Name;
			}

		#region - Validate -
		private bool validateAdd()
		{
			if(!validateAll())
			{
				return false;
			}

			if(dtpFromDate.Value>dtpToDate.Value)
			{
				Message(MessageList.Error.E0011, "วันที่เริ่มต้น", "วันที่สิ้นสุด");
				dtpToDate.Focus();
				return false;
			}

			annualLeaveDayList = getAnnualLeaveDayList;
			if(parentForm.FacadeEmployeeAnnualLeave.AnnualLeave.Contain(annualLeaveDayList))
			{
				Message(MessageList.Error.E0047);
				dtpToDate.Focus();
				return false;
			}

			bool hasHoliday = false;
			for(int i=0; i<annualLeaveDayList.Count; i++)
			{
				if(parentForm.FacadeEmployeeAnnualLeave.IsHoliday(annualLeaveDayList[i].LeaveDate))
				{
					hasHoliday = true;
					break;
				}
			}

			if(hasHoliday && Message(MessageList.Question.Q0010)!=DialogResult.Yes)
			{
				return false;
			}

			return true;
		}

		private bool validateUpdate()
		{
			return validateAll();
		}

		private bool validateAll()
		{
			bool hasLeave = false;
			annualLeaveDayList = getAnnualLeaveDayList;

			for(int i=0; i<annualLeaveDayList.Count; i++)
			{
				if(parentForm.FacadeEmployeeAnnualLeave.IsLeave(annualLeaveDayList[i].LeaveDate, annualLeaveDayList[i].PeriodStatus))
				{
					hasLeave = true;
					break;
				}
			}

			if(hasLeave)
			{
				Message(MessageList.Error.E0050);
				return false;
			}

			if(cboLeaveReason.Text.Trim() == "")
			{
				Message(MessageList.Error.E0005, "สาเหตุ");
				cboLeaveReason.Focus();
				return false;
			}

            if (!validateEmployeeResign())
            {
                return false;
            }

			return true;
		}

        private bool validateEmployeeResign()
        {
            if (parentForm.FacadeEmployeeAnnualLeave.Employee != null
                && parentForm.FacadeEmployeeAnnualLeave.Employee.TerminationDate != NullConstant.DATETIME
                && parentForm.FacadeEmployeeAnnualLeave.Employee.TerminationDate.Date < dtpToDate.Value.Date)
            {
                Message(MessageList.Error.E0013, "บันทึกข้อมูลได้", "พนักงานมีสถานะสิ้นสุดการทำงานในช่วงเวลาที่กำหนด");
                dtpToDate.Focus();
                return false;
            }
            return true;
        }
		#endregion

		private void setOneDayLeave()
		{
			if(dtpFromDate.Value == dtpToDate.Value)
			{
				uctLeavePeriodFrom.EnablePeriod(true);
				uctLeavePeriodTo.Enabled = false;				
			}
			else
			{
				uctLeavePeriodFrom.EnablePeriod(UCTLeavePeriod.PERIOD_TYPE.AM, false);
				uctLeavePeriodTo.Enabled = true;
				uctLeavePeriodTo.EnablePeriod(UCTLeavePeriod.PERIOD_TYPE.PM, false);
			}
		}

		private void addEvent()
		{
			try
			{
				if(validateAdd())
				{
					if(parentForm.AddAnnualLeaveDayList(getAnnualLeaveDayList))
					{
						this.Close();
					}
					else
					{
						Message(MessageList.Error.E0048);
					}
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
			finally
			{
				annualLeaveDayList = null;
			}
		}

		private void editEvent()
		{
			try
			{
				if(validateUpdate())
				{
					if(parentForm.UpdateAnnualLeaveDay(getAnnualLeaveDay))
					{
						this.Close();
					}
					else
					{
						Message(MessageList.Error.E0048);
					}
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
			finally
			{
				annualLeaveDayList = null;
			}
        }
        #endregion

        #region Public Method
        public void InitAddAction(DateTime yearMonth)
        {
            base.baseADD();
            clearDTP(dtpFromDate);
            clearDTP(dtpToDate);
            initForm(yearMonth);
            clearForm(yearMonth);
        }

        public void InitEditAction(AnnualLeaveDay value)
        {
            base.baseEDIT();
            clearDTP(dtpFromDate);
            clearDTP(dtpToDate);
            initForm(value.LeaveDate);
            bindForm(value);

            if (isReadonly)
            {
                cmdOK.Enabled = false;
            }
        } 
        #endregion

        #region Form Event
        private void dtpFromDate_ValueChanged(object sender, System.EventArgs e)
        {
            dtpToDate.Value = dtpFromDate.Value;
            setOneDayLeave();
        }

        private void dtpToDate_ValueChanged(object sender, System.EventArgs e)
        {
            setOneDayLeave();
        }

        private void cmdOK_Click(object sender, System.EventArgs e)
        {
            switch (action)
            {
                case ActionType.ADD:
                    addEvent();
                    break;
                case ActionType.EDIT:
                    editEvent();
                    break;
            }
        }

        private void cmdCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void frmEmployeeAnnualLeaveEntry_Load(object sender, System.EventArgs e)
        {
            this.title = "การลาพักร้อนประจำปี";
        } 
        #endregion
	}
}