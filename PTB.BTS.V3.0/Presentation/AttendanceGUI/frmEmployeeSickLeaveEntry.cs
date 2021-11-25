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
using ictus.Common.Entity.General;

namespace Presentation.AttendanceGUI
{
	public class frmEmployeeSickLeaveEntry : EntryFormBase
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
		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox gpbTo;
		private System.Windows.Forms.RadioButton rdoToOneDay;
		private System.Windows.Forms.RadioButton rdoToPM;
		private System.Windows.Forms.RadioButton rdoToAM;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.DateTimePicker dtpToDate;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox gpbFrom;
		private System.Windows.Forms.RadioButton rdoFromOneDay;
		private System.Windows.Forms.RadioButton rdoFromPM;
		private System.Windows.Forms.RadioButton rdoFromAM;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker dtpFromDate;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cboDisease;
		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdOK = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.gpbTo = new System.Windows.Forms.GroupBox();
			this.rdoToOneDay = new System.Windows.Forms.RadioButton();
			this.rdoToPM = new System.Windows.Forms.RadioButton();
			this.rdoToAM = new System.Windows.Forms.RadioButton();
			this.label4 = new System.Windows.Forms.Label();
			this.dtpToDate = new System.Windows.Forms.DateTimePicker();
			this.label3 = new System.Windows.Forms.Label();
			this.gpbFrom = new System.Windows.Forms.GroupBox();
			this.rdoFromOneDay = new System.Windows.Forms.RadioButton();
			this.rdoFromPM = new System.Windows.Forms.RadioButton();
			this.rdoFromAM = new System.Windows.Forms.RadioButton();
			this.label2 = new System.Windows.Forms.Label();
			this.cboDisease = new System.Windows.Forms.ComboBox();
			this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.gpbTo.SuspendLayout();
			this.gpbFrom.SuspendLayout();
			this.SuspendLayout();
			// 
			// cmdCancel
			// 
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.Location = new System.Drawing.Point(259, 314);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.TabIndex = 8;
			this.cmdCancel.Text = "ยกเลิก";
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			// 
			// cmdOK
			// 
			this.cmdOK.Location = new System.Drawing.Point(179, 314);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.TabIndex = 7;
			this.cmdOK.Text = "ตกลง";
			this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.gpbTo);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.dtpToDate);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.gpbFrom);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.cboDisease);
			this.groupBox1.Controls.Add(this.dtpFromDate);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(16, 14);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(480, 288);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			// 
			// gpbTo
			// 
			this.gpbTo.Controls.Add(this.rdoToOneDay);
			this.gpbTo.Controls.Add(this.rdoToPM);
			this.gpbTo.Controls.Add(this.rdoToAM);
			this.gpbTo.Location = new System.Drawing.Point(264, 88);
			this.gpbTo.Name = "gpbTo";
			this.gpbTo.Size = new System.Drawing.Size(120, 120);
			this.gpbTo.TabIndex = 3;
			this.gpbTo.TabStop = false;
			this.gpbTo.Text = "ช่วงเวลา";
			// 
			// rdoToOneDay
			// 
			this.rdoToOneDay.Location = new System.Drawing.Point(24, 88);
			this.rdoToOneDay.Name = "rdoToOneDay";
			this.rdoToOneDay.Size = new System.Drawing.Size(56, 24);
			this.rdoToOneDay.TabIndex = 2;
			this.rdoToOneDay.Text = " ทั้งวัน";
			// 
			// rdoToPM
			// 
			this.rdoToPM.Location = new System.Drawing.Point(24, 56);
			this.rdoToPM.Name = "rdoToPM";
			this.rdoToPM.Size = new System.Drawing.Size(80, 24);
			this.rdoToPM.TabIndex = 1;
			this.rdoToPM.Text = " ครึ่งวันหลัง";
			// 
			// rdoToAM
			// 
			this.rdoToAM.Location = new System.Drawing.Point(24, 24);
			this.rdoToAM.Name = "rdoToAM";
			this.rdoToAM.Size = new System.Drawing.Size(80, 24);
			this.rdoToAM.TabIndex = 0;
			this.rdoToAM.Text = " ครึ่งวันแรก";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(296, 24);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(56, 23);
			this.label4.TabIndex = 80;
			this.label4.Text = "วันที่สิ้นสุด";
			// 
			// dtpToDate
			// 
			this.dtpToDate.CustomFormat = "dd/MM/yyyy";
			this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpToDate.Location = new System.Drawing.Point(280, 56);
			this.dtpToDate.Name = "dtpToDate";
			this.dtpToDate.Size = new System.Drawing.Size(88, 20);
			this.dtpToDate.TabIndex = 5;
			this.dtpToDate.ValueChanged += new System.EventHandler(this.dtpToDate_ValueChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(232, 56);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(16, 23);
			this.label3.TabIndex = 5;
			this.label3.Text = " - ";
			// 
			// gpbFrom
			// 
			this.gpbFrom.Controls.Add(this.rdoFromOneDay);
			this.gpbFrom.Controls.Add(this.rdoFromPM);
			this.gpbFrom.Controls.Add(this.rdoFromAM);
			this.gpbFrom.Location = new System.Drawing.Point(96, 88);
			this.gpbFrom.Name = "gpbFrom";
			this.gpbFrom.Size = new System.Drawing.Size(120, 120);
			this.gpbFrom.TabIndex = 2;
			this.gpbFrom.TabStop = false;
			this.gpbFrom.Text = "ช่วงเวลา";
			// 
			// rdoFromOneDay
			// 
			this.rdoFromOneDay.Location = new System.Drawing.Point(24, 88);
			this.rdoFromOneDay.Name = "rdoFromOneDay";
			this.rdoFromOneDay.Size = new System.Drawing.Size(56, 24);
			this.rdoFromOneDay.TabIndex = 2;
			this.rdoFromOneDay.Text = " ทั้งวัน";
			// 
			// rdoFromPM
			// 
			this.rdoFromPM.Location = new System.Drawing.Point(24, 56);
			this.rdoFromPM.Name = "rdoFromPM";
			this.rdoFromPM.Size = new System.Drawing.Size(80, 24);
			this.rdoFromPM.TabIndex = 1;
			this.rdoFromPM.Text = " ครึ่งวันหลัง";
			// 
			// rdoFromAM
			// 
			this.rdoFromAM.Checked = true;
			this.rdoFromAM.Location = new System.Drawing.Point(24, 24);
			this.rdoFromAM.Name = "rdoFromAM";
			this.rdoFromAM.Size = new System.Drawing.Size(80, 24);
			this.rdoFromAM.TabIndex = 0;
			this.rdoFromAM.TabStop = true;
			this.rdoFromAM.Text = " ครึ่งวันแรก";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(40, 240);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 23);
			this.label2.TabIndex = 80;
			this.label2.Text = "ชื่อโรค";
			// 
			// cboDisease
			// 
			this.cboDisease.Location = new System.Drawing.Point(88, 240);
			this.cboDisease.Name = "cboDisease";
			this.cboDisease.Size = new System.Drawing.Size(352, 21);
			this.cboDisease.TabIndex = 6;
			// 
			// dtpFromDate
			// 
			this.dtpFromDate.CustomFormat = "dd/MM/yyyy";
			this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpFromDate.Location = new System.Drawing.Point(112, 56);
			this.dtpFromDate.Name = "dtpFromDate";
			this.dtpFromDate.Size = new System.Drawing.Size(88, 20);
			this.dtpFromDate.TabIndex = 4;
			this.dtpFromDate.ValueChanged += new System.EventHandler(this.dtpFromDate_ValueChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(128, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 23);
			this.label1.TabIndex = 80;
			this.label1.Text = "วันที่เริ่มต้น";
			// 
			// frmEmployeeSickLeaveEntry
			// 
			this.AcceptButton = this.cmdOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.cmdCancel;
			this.ClientSize = new System.Drawing.Size(512, 350);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdOK);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "frmEmployeeSickLeaveEntry";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Load += new System.EventHandler(this.frmEmployeeSickLeaveEntry_Load);
			this.groupBox1.ResumeLayout(false);
			this.gpbTo.ResumeLayout(false);
			this.gpbFrom.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Private Variable
		private bool isReadonly = true;
		private bool isChange = true;
		private frmEmployeeSickLeave parentForm;
		#endregion

        #region Property
        private SickLeave objSickLeave;
        public SickLeave ObjSickLeave
        {
            set
            {
                isChange = false;
                objSickLeave = value;
                dtpFromDate.Value = value.LeaveDate;
                dtpToDate.Value = value.LeaveDate;
                cboDisease.Text = value.ADisease.Name;

                switch (value.PeriodStatus)
                {
                    case LEAVE_PERIOD_TYPE.AM:
                        rdoFromAM.Checked = true;
                        break;
                    case LEAVE_PERIOD_TYPE.PM:
                        rdoFromPM.Checked = true;
                        break;
                    case LEAVE_PERIOD_TYPE.ONE_DAY:
                        rdoFromOneDay.Checked = true;
                        break;
                }
                isChange = true;
            }
        } 
        #endregion

        #region Constructor
        public frmEmployeeSickLeaveEntry(frmEmployeeSickLeave parentForm)
            : base()
        {
            InitializeComponent();
            this.parentForm = parentForm;
            isReadonly = UserProfile.IsReadOnly("miAttendance", "miEmployeeSickLeave");

            try
            {
                cboDisease.DataSource = parentForm.FacadeEmployeeSickLeave.DataSourceDisease;
            }
            catch (SqlException sqlex)
            {
                Message(sqlex);
            }
            catch (AppExceptionBase ex)
            {
                Message(ex);
            }
            catch (Exception ex)
            {
                Message(ex);
            }
        } 
        #endregion

        #region Private Method
        private void enableKeyfield(bool value)
        {
            dtpFromDate.Enabled = value;
            dtpToDate.Enabled = value;
        }

        private void enableNotOneDay(bool value)
        {
            gpbTo.Enabled = value;
            rdoFromAM.Enabled = !value;
            rdoToPM.Enabled = !value;
            rdoFromAM.Checked = !value;
            rdoFromPM.Checked = value;
            rdoToAM.Checked = value;
        }

        private void clearForm()
        {
            clearCombo();
        }

        private void clearCombo()
        {
            cboDisease.SelectedIndex = -1;
            cboDisease.SelectedIndex = -1;
        }

        private void addEvent()
        {
            try
            {
                bool result = false;

                if (validateForm() && validateDupLeave() && validateAddWorkSchedule())
                {
                    result = true;

                    DateTime fromDate = dtpFromDate.Value.Date;
                    DateTime toDate = dtpToDate.Value.Date;

                    for (DateTime date = fromDate; date <= toDate; date = date.AddDays(1))
                    {
                        objSickLeave = new SickLeave();
                        objSickLeave.ADisease.Name = cboDisease.Text;
                        if (fromDate == date)
                        {
                            if (rdoFromAM.Checked)
                            {
                                objSickLeave.PeriodStatus = LEAVE_PERIOD_TYPE.AM;
                            }
                            else if (rdoFromPM.Checked)
                            {
                                objSickLeave.PeriodStatus = LEAVE_PERIOD_TYPE.PM;
                            }
                            else if (rdoFromOneDay.Checked)
                            {
                                objSickLeave.PeriodStatus = LEAVE_PERIOD_TYPE.ONE_DAY;
                            }
                        }
                        else if (toDate == date)
                        {
                            if (rdoToAM.Checked)
                            {
                                objSickLeave.PeriodStatus = LEAVE_PERIOD_TYPE.AM;
                            }
                            else if (rdoToPM.Checked)
                            {
                                objSickLeave.PeriodStatus = LEAVE_PERIOD_TYPE.PM;
                            }
                            else if (rdoToOneDay.Checked)
                            {
                                objSickLeave.PeriodStatus = LEAVE_PERIOD_TYPE.ONE_DAY;
                            }
                        }
                        else
                        {
                            objSickLeave.PeriodStatus = LEAVE_PERIOD_TYPE.ONE_DAY;
                        }

                        objSickLeave.LeaveDate = date;
                        result |= parentForm.AddRow(objSickLeave);
                    }

                    if (result)
                    {
                        clearForm();
                        dtpFromDate.Focus();
                    }
                }
            }
            catch (SqlException sqlex)
            {
                Message(sqlex);
            }
            catch (AppExceptionBase ex)
            {
                Message(ex);
            }
            catch (Exception ex)
            {
                Message(ex);
            }
        }

        private void editEvent()
        {
            try
            {
                objSickLeave.ADisease.Name = cboDisease.Text;
                if (rdoFromAM.Checked)
                {
                    objSickLeave.PeriodStatus = LEAVE_PERIOD_TYPE.AM;
                }
                else if (rdoFromPM.Checked)
                {
                    objSickLeave.PeriodStatus = LEAVE_PERIOD_TYPE.PM;
                }
                else if (rdoFromOneDay.Checked)
                {
                    objSickLeave.PeriodStatus = LEAVE_PERIOD_TYPE.ONE_DAY;
                }

                bool result = true;
                if (validateForm() && validateWorkSchedule(dtpFromDate.Value) && validateEditWorkSchedule())
                {
                    SickLeave tempSickLeave = parentForm.FacadeEmployeeSickLeave.GetSickLeave(dtpFromDate.Value);
                    if (tempSickLeave.LeaveDate == objSickLeave.LeaveDate && tempSickLeave.PeriodStatus != objSickLeave.PeriodStatus)
                    {
                        result &= validateDupLeave();
                    }

                    if (result && parentForm.UpdateRow(objSickLeave))
                    {
                        this.Hide();
                    }
                }
            }
            catch (SqlException sqlex)
            {
                Message(sqlex);
            }
            catch (AppExceptionBase ex)
            {
                Message(ex);
            }
            catch (Exception ex)
            {
                Message(ex);
            }
        }

        #region - Validate -
        private bool validateForm()
        {
            if (dtpFromDate.Value.Date > dtpToDate.Value.Date)
            {
                Message(MessageList.Error.E0011, "วันที่เริ่มต้น", "วันที่สิ้นสุด");
                dtpFromDate.Focus();
                return false;
            }
            if (!rdoFromAM.Checked & !rdoFromOneDay.Checked & !rdoFromPM.Checked)
            {
                Message(MessageList.Error.E0005, "ช่วงเวลา");
                return false;
            }
            if (gpbTo.Enabled & !rdoToAM.Checked & !rdoToOneDay.Checked & !rdoToPM.Checked)
            {
                Message(MessageList.Error.E0005, "ช่วงเวลา");
                return false;
            }
            if (cboDisease.Text.Trim() == "")
            {
                Message(MessageList.Error.E0002, "ชื่อโรค");
                cboDisease.Focus();
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
            if (parentForm.FacadeEmployeeSickLeave.Employee != null
                && parentForm.FacadeEmployeeSickLeave.Employee.TerminationDate != NullConstant.DATETIME
                && parentForm.FacadeEmployeeSickLeave.Employee.TerminationDate.Date < dtpToDate.Value.Date)
            {
                Message(MessageList.Error.E0013, "บันทึกข้อมูลได้", "พนักงานมีสถานะสิ้นสุดการทำงานในช่วงเวลาที่กำหนด");
                dtpToDate.Focus();
                return false;
            }
            return true;
        }

        private bool validateAddWorkSchedule()
        {
            TimePeriod timePeriod = new TimePeriod();
            timePeriod.From = dtpFromDate.Value.Date;
            timePeriod.To = dtpToDate.Value.Date;
            if (parentForm.FacadeEmployeeSickLeave.GetCheckEmployeeWorkSchedule(timePeriod))
            {
                if (Message(MessageList.Question.Q0010) != DialogResult.Yes)
                {
                    return false;
                }
            }
            return true;
        }

        private bool validateEditWorkSchedule()
        {
            TimePeriod timePeriod = new TimePeriod();
            timePeriod.From = dtpFromDate.Value;
            timePeriod.To = dtpToDate.Value;

            if (parentForm.FacadeEmployeeSickLeave.GetCheckEmployeeWorkSchedule(timePeriod))
            {
                Message(MessageList.Error.E0049);
                rdoFromAM.Focus();
                return false;
            }
            return true;
        }

        private bool validateWorkSchedule(DateTime value)
        {
            WorkSchedule workSchedule = new WorkSchedule();
            workSchedule.WorkDate = value;

            if (parentForm.FacadeEmployeeSickLeave.FillWorkSchedule(ref workSchedule))
            {
                if (workSchedule.DayType == WORKINGDAY_TYPE.HOLIDAY)
                {
                    Message(MessageList.Error.E0049);
                    rdoFromAM.Focus();
                    return false;
                }
            }
            return true;
        }

        private bool validateDupLeave()
        {
            bool result = true;
            string after, before;
            TimeCard timeCard;
            DateTime fromDate = dtpFromDate.Value.Date;
            DateTime toDate = dtpToDate.Value.Date;

            for (DateTime date = fromDate; date <= toDate; date = date.AddDays(1))
            {
                timeCard = new TimeCard();
                timeCard.CardDate = date;
                if (parentForm.FacadeEmployeeSickLeave.FillTimeCard(ref timeCard))
                {
                    after = timeCard.AAfterBreakStatus.Code.Trim();
                    before = timeCard.ABeforeBreakStatus.Code.Trim();

                    if (fromDate == date)
                    {
                        if (rdoFromAM.Checked)
                        {
                            result &= validateLeaveCode(before);
                        }
                        else if (rdoFromPM.Checked)
                        {
                            result &= validateLeaveCode(after);
                        }
                        else if (rdoFromOneDay.Checked)
                        {
                            result &= (validateLeaveCode(before) && validateLeaveCode(after));
                        }
                    }
                    else if (toDate == date)
                    {
                        if (rdoToAM.Checked)
                        {
                            result &= validateLeaveCode(before);
                        }
                        else if (rdoToPM.Checked)
                        {
                            result &= validateLeaveCode(after);
                        }
                        else if (rdoToOneDay.Checked)
                        {
                            result &= (validateLeaveCode(before) && validateLeaveCode(after));
                        }
                    }
                    else
                    {
                        result &= (validateLeaveCode(before) && validateLeaveCode(after));
                    }
                }
            }

            if (!result)
            {
                Message(MessageList.Error.E0050);
                return false;
            }
            return true;
        }

        private bool validateLeaveCode(string code)
        {
            //Add new status F1 (Forget) to attendance status : woranai 2010/03/08
            if (code != "L1" & code != "L2" & code != "H1" & code != "WK" &
                code != "" & code != "S1" & code != "F1")
            {
                return false;
            }
            return true;
        }
        #endregion 
        #endregion

        #region Public Method
        public void InitAddAction(DateTime value)
        {
            baseADD();
            enableKeyfield(true);
            clearForm();
            setDTPForMonth(dtpFromDate, value);
            dtpFromDate.Value = value;
            dtpToDate.Value = value;
            clearCombo();
            dtpFromDate.Focus();
        }

        public void InitEditAction(SickLeave value)
        {
            baseEDIT();
            enableKeyfield(false);
            clearForm();
            ObjSickLeave = value;
            gpbTo.Enabled = false;

            if (isReadonly)
            {
                cmdOK.Enabled = false;
            }
        } 
        #endregion

        #region Form Event
        private void frmEmployeeSickLeaveEntry_Load(object sender, System.EventArgs e)
        {
            if (action == ActionType.ADD)
            {
                clearCombo();
            }
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
            this.Hide();
        }

        private void dtpFromDate_ValueChanged(object sender, System.EventArgs e)
        {
            if (isChange)
            {
                if (dtpFromDate.Value.Date < dtpToDate.Value.Date)
                {
                    enableNotOneDay(true);
                }
                else
                {
                    enableNotOneDay(false);
                }
            }
        }

        private void dtpToDate_ValueChanged(object sender, System.EventArgs e)
        {
            if (isChange)
            {
                if (dtpFromDate.Value.Date < dtpToDate.Value.Date)
                {
                    enableNotOneDay(true);
                }
                else
                {
                    enableNotOneDay(false);
                }
            }
        } 
        #endregion
	}
}
