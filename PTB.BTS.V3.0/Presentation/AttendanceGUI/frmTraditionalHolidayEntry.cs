using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;

using SystemFramework.AppException;
using SystemFramework.AppMessage;
using SystemFramework.AppConfig;

using Entity.CommonEntity;
using Entity.AttendanceEntities;

using Facade.CommonFacade;
using Facade.AttendanceFacade;

using Presentation.CommonGUI;

using ictus.Common.Entity.General;

namespace Presentation.AttendanceGUI
{
	public class frmTraditionalHolidayEntry  : EntryFormBase
	{
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
					objTraditionalHoliday = null;
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.TextBox txtDescription;
		private System.Windows.Forms.DateTimePicker dtpHoliday;
		private System.Windows.Forms.TextBox txtPattern;

		private System.ComponentModel.Container components = null;
		private void InitializeComponent()
		{
			this.label4 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.txtPattern = new System.Windows.Forms.TextBox();
			this.dtpHoliday = new System.Windows.Forms.DateTimePicker();
			this.txtDescription = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdOK = new System.Windows.Forms.Button();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(16, 16);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(36, 16);
			this.label4.TabIndex = 3;
			this.label4.Text = "รูปแบบ";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.txtPattern);
			this.groupBox2.Controls.Add(this.dtpHoliday);
			this.groupBox2.Controls.Add(this.txtDescription);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.groupBox2.Location = new System.Drawing.Point(16, 8);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(368, 112);
			this.groupBox2.TabIndex = 0;
			this.groupBox2.TabStop = false;
			// 
			// txtPattern
			// 
			this.txtPattern.Enabled = false;
			this.txtPattern.Location = new System.Drawing.Point(88, 18);
			this.txtPattern.Name = "txtPattern";
			this.txtPattern.Size = new System.Drawing.Size(264, 20);
			this.txtPattern.TabIndex = 4;
			this.txtPattern.Text = "";
			// 
			// dtpHoliday
			// 
			this.dtpHoliday.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.dtpHoliday.CustomFormat = "dd/MM/yyyy";
			this.dtpHoliday.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.dtpHoliday.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpHoliday.Location = new System.Drawing.Point(88, 48);
			this.dtpHoliday.Name = "dtpHoliday";
			this.dtpHoliday.Size = new System.Drawing.Size(96, 20);
			this.dtpHoliday.TabIndex = 1;
			this.dtpHoliday.Value = new System.DateTime(2005, 10, 21, 10, 38, 12, 936);
			// 
			// txtDescription
			// 
			this.txtDescription.Location = new System.Drawing.Point(88, 80);
			this.txtDescription.MaxLength = 50;
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.Size = new System.Drawing.Size(264, 20);
			this.txtDescription.TabIndex = 2;
			this.txtDescription.Text = "";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(16, 80);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(52, 16);
			this.label2.TabIndex = 1;
			this.label2.Text = "รายละเอียด";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(16, 48);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(23, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "วันที่";
			// 
			// cmdCancel
			// 
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cmdCancel.Location = new System.Drawing.Point(216, 128);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.TabIndex = 4;
			this.cmdCancel.Text = "ยกเลิก";
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			// 
			// cmdOK
			// 
			this.cmdOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cmdOK.Location = new System.Drawing.Point(136, 128);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.TabIndex = 3;
			this.cmdOK.Text = "ตกลง";
			this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
			// 
			// frmTraditionalHolidayEntry
			// 
			this.AcceptButton = this.cmdOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.cmdCancel;
			this.ClientSize = new System.Drawing.Size(402, 160);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdOK);
			this.Controls.Add(this.groupBox2);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MinimizeBox = false;
			this.Name = "frmTraditionalHolidayEntry";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region - private -
		private bool isReadonly = true;
		private frmTraditionalHoliday parentForm;
		private TraditionalHoliday objTraditionalHoliday;
		private TraditionalHolidayPattern objTraditionalHolidayPattern;
		#endregion

//		============================== Property ==============================
		public TraditionalHoliday getTraditionalHoliday()
		{
			objTraditionalHoliday = new TraditionalHoliday();	
			objTraditionalHoliday.HolidayDate = dtpHoliday.Value.Date;			
			objTraditionalHoliday.ADescription.Thai = txtDescription.Text;
			return objTraditionalHoliday;
		}		

//		============================== Constructor ==============================
		public frmTraditionalHolidayEntry(frmTraditionalHoliday parentForm) : base()
		{
			InitializeComponent();					
			this.parentForm = parentForm;
			isReadonly = UserProfile.IsReadOnly("miAttendance", "miTraditionalHoliday");
		}

//		============================== private method ==============================	
		private void setTraditionalHolidayPattern(TraditionalHolidayPattern value)
		{
			objTraditionalHolidayPattern = new TraditionalHolidayPattern();
			txtPattern.Text = value.AName.Thai;
			objTraditionalHolidayPattern = value;
		}

		private bool validateForm()
		{
			if (txtDescription.Text == "")
			{
				Message(MessageList.Error.E0002, "รายละเอียด");
				txtDescription.Focus();
				return false;
			}
			return true;
		}

		private bool validateDupKey(TraditionalHoliday value)
		{
			if(parentForm.FacadeTraditionalHoliday.ObjTraditionalHolidayList.Contain(value))
			{
				Message(MessageList.Error.E0003);
				dtpHoliday.Focus();
				return false;
			}
			return true;
		}

		private bool validateDupDescription()
		{
			TraditionalHoliday traditionalHoliday = new TraditionalHoliday();
			traditionalHoliday.ADescription.Thai = txtDescription.Text;
			if(parentForm.FacadeTraditionalHoliday.FillCheckDupTraditionalHoliday(ref traditionalHoliday, objTraditionalHolidayPattern, dtpHoliday.Value))
			{
				Message(MessageList.Error.E0003);
				setSelected(txtDescription);
				traditionalHoliday = null;
				return false;
			}
			traditionalHoliday = null;
			return true;
		}

//		============================== public method ==============================
		public void InitAddAction(TraditionalHolidayPattern value, DateTime forYear)
		{
			baseADD();
			txtDescription.Text = "";
			setTraditionalHolidayPattern(value);
			dtpHoliday.Enabled = true;
			setDTPForYear(dtpHoliday, forYear);
		}

		public void InitEditAction(TraditionalHolidayPattern value, TraditionalHoliday aTraditionalHoliday)
		{
			baseEDIT();
			txtDescription.Text = "";
			setTraditionalHolidayPattern(value);
			dtpHoliday.Value = aTraditionalHoliday.HolidayDate;
			txtDescription.Text = aTraditionalHoliday.ADescription.Thai;
			objTraditionalHoliday = aTraditionalHoliday;
			dtpHoliday.Enabled = false;

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
				TraditionalHoliday traditionalHoliday  = getTraditionalHoliday();
				if (validateForm() && validateDupKey(traditionalHoliday) && validateDupDescription() && parentForm.AddRow(traditionalHoliday))
				{
					txtDescription.Text = NullConstant.STRING;
					dtpHoliday.Focus();
				}
				traditionalHoliday = null;
			}
			catch(SqlException sqlex)
			{Message(sqlex);}
			catch(AppExceptionBase ex)
			{Message(ex);}
			catch(Exception ex)
			{Message(ex);}	
		}

		private void editEvent()
		{
			try
			{
				bool result = true;
				if(objTraditionalHoliday.ADescription.Thai.ToLower() != txtDescription.Text.ToLower())
				{
					result = validateDupDescription();
				}

				if(validateForm() && result)
				{
					TraditionalHoliday traditionalHoliday  = getTraditionalHoliday();
					if(parentForm.UpdateRow(traditionalHoliday))
					{
						this.Hide();
					}
					traditionalHoliday = null;
				}
				else
				{
					setSelected(txtDescription);
				}				
			}
			catch(SqlException sqlex)
			{Message(sqlex);}
			catch(AppExceptionBase ex)
			{Message(ex);}
			catch(Exception ex)
			{Message(ex);}	
		}

//		================================= event ================================
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
