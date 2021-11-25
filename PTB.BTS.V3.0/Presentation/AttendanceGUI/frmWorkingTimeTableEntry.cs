using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;

using SystemFramework.AppConfig;
using SystemFramework.AppMessage;
using SystemFramework.AppException;

using Entity.CommonEntity;
using Entity.AttendanceEntities;

using Facade.CommonFacade;
using Facade.AttendanceFacade;

using Presentation.CommonGUI;

using ictus.Common.Entity;
using ictus.Common.Entity.Time;

namespace Presentation.AttendanceGUI
{
	public class frmWorkingTimeTableEntry :EntryFormBase
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
					aWorkingTimeTable = null;
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
	
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtDescription;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtTableId;
		private System.Windows.Forms.GroupBox v;
		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.DateTimePicker dtpEndBreak;
		private System.Windows.Forms.DateTimePicker dtpStartBreak;
		private System.Windows.Forms.DateTimePicker dtpEndWork;
		private System.Windows.Forms.DateTimePicker dtpStartWork;
		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.txtTableId = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.txtDescription = new System.Windows.Forms.TextBox();
			this.v = new System.Windows.Forms.GroupBox();
			this.dtpEndBreak = new System.Windows.Forms.DateTimePicker();
			this.dtpStartBreak = new System.Windows.Forms.DateTimePicker();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.dtpEndWork = new System.Windows.Forms.DateTimePicker();
			this.dtpStartWork = new System.Windows.Forms.DateTimePicker();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdOK = new System.Windows.Forms.Button();
			this.v.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.label1.Location = new System.Drawing.Point(16, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(50, 18);
			this.label1.TabIndex = 10;
			this.label1.Text = "รูปแบบที่";
			// 
			// txtTableId
			// 
			this.txtTableId.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.txtTableId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtTableId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.txtTableId.Location = new System.Drawing.Point(88, 24);
			this.txtTableId.MaxLength = 2;
			this.txtTableId.Name = "txtTableId";
			this.txtTableId.Size = new System.Drawing.Size(32, 22);
			this.txtTableId.TabIndex = 1;
			this.txtTableId.Text = "";
			// 
			// label7
			// 
			this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.label7.Location = new System.Drawing.Point(16, 56);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(61, 18);
			this.label7.TabIndex = 17;
			this.label7.Text = "รายละเอียด";
			// 
			// txtDescription
			// 
			this.txtDescription.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.txtDescription.Location = new System.Drawing.Point(88, 56);
			this.txtDescription.MaxLength = 50;
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.Size = new System.Drawing.Size(280, 22);
			this.txtDescription.TabIndex = 3;
			this.txtDescription.Text = "";
			// 
			// v
			// 
			this.v.Controls.Add(this.dtpEndBreak);
			this.v.Controls.Add(this.dtpStartBreak);
			this.v.Controls.Add(this.label3);
			this.v.Controls.Add(this.label2);
			this.v.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.v.Location = new System.Drawing.Point(16, 168);
			this.v.Name = "v";
			this.v.Size = new System.Drawing.Size(352, 56);
			this.v.TabIndex = 7;
			this.v.TabStop = false;
			this.v.Text = "เวลาพัก";
			// 
			// dtpEndBreak
			// 
			this.dtpEndBreak.CustomFormat = "HH:mm";
			this.dtpEndBreak.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpEndBreak.Location = new System.Drawing.Point(264, 24);
			this.dtpEndBreak.Name = "dtpEndBreak";
			this.dtpEndBreak.ShowUpDown = true;
			this.dtpEndBreak.Size = new System.Drawing.Size(64, 22);
			this.dtpEndBreak.TabIndex = 26;
			// 
			// dtpStartBreak
			// 
			this.dtpStartBreak.CustomFormat = "HH:mm";
			this.dtpStartBreak.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpStartBreak.Location = new System.Drawing.Point(80, 24);
			this.dtpStartBreak.Name = "dtpStartBreak";
			this.dtpStartBreak.ShowUpDown = true;
			this.dtpStartBreak.Size = new System.Drawing.Size(64, 22);
			this.dtpStartBreak.TabIndex = 25;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(32, 24);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(23, 18);
			this.label3.TabIndex = 21;
			this.label3.Text = "เริ่ม";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(216, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(35, 18);
			this.label2.TabIndex = 20;
			this.label2.Text = "สิ้นสุด";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.dtpEndWork);
			this.groupBox2.Controls.Add(this.dtpStartWork);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.groupBox2.Location = new System.Drawing.Point(16, 96);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(352, 56);
			this.groupBox2.TabIndex = 4;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "เวลาทำงาน";
			// 
			// dtpEndWork
			// 
			this.dtpEndWork.CustomFormat = "HH:mm";
			this.dtpEndWork.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpEndWork.Location = new System.Drawing.Point(264, 24);
			this.dtpEndWork.Name = "dtpEndWork";
			this.dtpEndWork.ShowUpDown = true;
			this.dtpEndWork.Size = new System.Drawing.Size(64, 22);
			this.dtpEndWork.TabIndex = 25;
			// 
			// dtpStartWork
			// 
			this.dtpStartWork.CustomFormat = "HH:mm";
			this.dtpStartWork.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpStartWork.Location = new System.Drawing.Point(80, 24);
			this.dtpStartWork.Name = "dtpStartWork";
			this.dtpStartWork.ShowUpDown = true;
			this.dtpStartWork.Size = new System.Drawing.Size(64, 22);
			this.dtpStartWork.TabIndex = 24;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(32, 24);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(23, 18);
			this.label5.TabIndex = 23;
			this.label5.Text = "เริ่ม";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(216, 24);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(35, 18);
			this.label4.TabIndex = 22;
			this.label4.Text = "สิ้นสุด";
			// 
			// cmdCancel
			// 
			this.cmdCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cmdCancel.Location = new System.Drawing.Point(192, 240);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.TabIndex = 9;
			this.cmdCancel.Text = "ยกเลิก";
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			// 
			// cmdOK
			// 
			this.cmdOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cmdOK.Location = new System.Drawing.Point(112, 240);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.TabIndex = 8;
			this.cmdOK.Text = "ตกลง";
			this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
			// 
			// frmWorkingTimeTableEntry
			// 
			this.AcceptButton = this.cmdOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.cmdCancel;
			this.ClientSize = new System.Drawing.Size(378, 280);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdOK);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.v);
			this.Controls.Add(this.txtDescription);
			this.Controls.Add(this.txtTableId);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MinimizeBox = false;
			this.Name = "frmWorkingTimeTableEntry";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.v.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region - Private -
		private bool isReadonly = true;
		private frmWorkingTimeTable parentForm;	
		#endregion

//		============================== Property ==============================
		private WorkingTimeTable aWorkingTimeTable;
		public WorkingTimeTable AWorkingTimeTable
		{
			get
			{
				aWorkingTimeTable = new WorkingTimeTable();
				aWorkingTimeTable.TableID =  txtTableId.Text;                   
				aWorkingTimeTable.Description =  txtDescription.Text;
				aWorkingTimeTable.AWorkingTime = getTimePeriod(dtpStartWork.Value, dtpEndWork.Value);
				aWorkingTimeTable.ABreakTime = getBreakTimePeriod(dtpStartBreak.Value, dtpEndBreak.Value, dtpStartWork.Value, dtpEndWork.Value);
				return aWorkingTimeTable;
			}
			set
			{
				aWorkingTimeTable = value;
				txtTableId.Text = GUIFunction.GetString(value.TableID);
				txtDescription.Text = GUIFunction.GetString(value.Description);
				dtpStartWork.Value = value.AWorkingTime.From;
				dtpEndWork.Value = value.AWorkingTime.To;
				dtpStartBreak.Value = value.ABreakTime.From;
				dtpEndBreak.Value = value.ABreakTime.To;
			}
		}	

//		============================== Constructor ==============================
		public frmWorkingTimeTableEntry(frmWorkingTimeTable parentForm) : base()
		{
			InitializeComponent();
			this.parentForm = parentForm;	
			isReadonly = UserProfile.IsReadOnly("miAttendance", "miWorkingTimeTable");
		}

//		============================== private method ==============================
		private void enableKeyField(bool enable)
		{
			txtTableId.Enabled = enable;		
		}

		private void clearForm()
		{
			txtTableId.Text = "";
			txtDescription.Text = "";
			TimeConstant dtConstant = new TimeConstant();
			dtpStartWork.Value = dtConstant.ChangeHourMinute(8,30);
			dtpEndWork.Value = dtConstant.ChangeHourMinute(17,00);
			dtpStartBreak.Value = dtConstant.ChangeHourMinute(12,00);
			dtpEndBreak.Value = dtConstant.ChangeHourMinute(13,00);
		}

		#region - validate -
		private bool validateForm()
		{
			if(txtTableId.Text == "") 
			{
				Message(MessageList.Error.E0002, "รูปแบบ" );
				txtTableId.Focus();
				return false;
			}
			return true;
		}		

		private bool validateTimePeriod(WorkingTimeTable value)
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

		private bool validateDupKey(WorkingTimeTable value)
		{
			if(parentForm.FacadeWorkingTimeTable.ObjWorkingTimeTableList.Contain(value))
			{
				Message(MessageList.Error.E0003);
				setSelected(txtTableId);
				return false;
			}		
			return true;
		}

		private bool validateDupDescription()
		{
			if(txtDescription.Text != "" && parentForm.FacadeWorkingTimeTable.GetDupDescriptionWorkingTimeTable(txtDescription.Text) != null)
			{
				Message(MessageList.Error.E0003);
				setSelected(txtDescription);
				return false;
			}
			return true;
		}
		#endregion
		
//		============================== public method ==============================
		public void InitAddAction()
		{
			baseADD();
			clearForm();
			txtTableId.Focus();
			enableKeyField(true);
		}

		public void InitEditAction(WorkingTimeTable value)
		{
			baseEDIT();
			clearForm();
			AWorkingTimeTable = value;
			txtDescription.Focus();
			enableKeyField(false);

			if(isReadonly)
			{
				cmdOK.Enabled = false;
			}
		}
		
//		============================== Base event ==============================
		private void AddEvent()
		{
			try
			{
				WorkingTimeTable workingTimeTable = AWorkingTimeTable;

				if (validateForm() && validateTimePeriod(workingTimeTable) && validateDupKey(workingTimeTable) && validateDupDescription() && parentForm.AddRow(workingTimeTable))
				{
					clearForm();
					txtTableId.Focus();
				}
			}
			catch(SqlException sqlex)
			{Message(sqlex);}
			catch(AppExceptionBase ex)
			{Message(ex);}
			catch(Exception ex)
			{Message(ex);}		
		}

		private void EditEvent()
		{
			try
			{
				bool result = true;
				if(aWorkingTimeTable.Description.ToLower() != txtDescription.Text.ToLower())
				{
					result = validateDupDescription();
				}

				WorkingTimeTable workingTimeTable = AWorkingTimeTable;

				if (validateForm() && validateTimePeriod(workingTimeTable) && result && parentForm.UpdateRow(workingTimeTable))
				{
					this.Hide();
				}
			}
			catch(SqlException sqlex)
			{Message(sqlex);}
			catch(AppExceptionBase ex)
			{Message(ex);}
			catch(Exception ex)
			{Message(ex);}	
		}

//		============================== event ==============================
		private void cmdOK_Click(object sender, System.EventArgs e)
		{
			switch (action)
			{					
				case ActionType.ADD :
					AddEvent();
					break;
				case ActionType.EDIT :
					EditEvent();
					break;
			}
		}

		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			this.Hide();
		}		
	}
}

#region - Old data -
				//Working Time
//				if(DTConst.ChangeHourMinute(dtpStartWork.Value).ToString("HH:mm") == "00:00" && DTConst.ChangeHourMinute(dtpEndWork.Value).ToString("HH:mm") == "00:00")
//				{
//					aWorkingTimeTable.AWorkingTime.From = DTConst.ChangeHourMinute(dtpStartWork.Value).AddDays(1);
//					aWorkingTimeTable.AWorkingTime.To = DTConst.ChangeHourMinute(dtpEndWork.Value).AddDays(1);
//				}
//				else if(DTConst.ChangeHourMinute(dtpStartWork.Value).ToString("HH:mm") == "00:00")
//				{
//					aWorkingTimeTable.AWorkingTime.From = DTConst.ChangeHourMinute(dtpStartWork.Value).AddDays(1);
//					aWorkingTimeTable.AWorkingTime.To = DTConst.ChangeHourMinute(dtpEndWork.Value).AddDays(1);
//				}
//				else
//				{
//					if(dtpStartWork.Value > dtpEndWork.Value)
//					{
//						aWorkingTimeTable.AWorkingTime.To = DTConst.ChangeHourMinute(dtpEndWork.Value).AddDays(1);
//						
//					}
//					else
//					{
//						aWorkingTimeTable.AWorkingTime.To = DTConst.ChangeHourMinute(dtpEndWork.Value);
//					}
//					aWorkingTimeTable.AWorkingTime.From = DTConst.ChangeHourMinute(dtpStartWork.Value);
//				}
//
//				//Break Time
//				if(DTConst.ChangeHourMinute(dtpStartBreak.Value).ToString("HH:mm") == "00:00" && DTConst.ChangeHourMinute(dtpEndBreak.Value).ToString("HH:mm") == "00:00")
//				{
//					aWorkingTimeTable.ABreakTime.From = DTConst.ChangeHourMinute(dtpStartBreak.Value).AddDays(1);
//					aWorkingTimeTable.ABreakTime.To = DTConst.ChangeHourMinute(dtpEndBreak.Value).AddDays(1);
//				}
//				else if(DTConst.ChangeHourMinute(dtpStartBreak.Value).ToString("HH:mm") == "00:00")
//				{
//					aWorkingTimeTable.ABreakTime.From = DTConst.ChangeHourMinute(dtpStartBreak.Value).AddDays(1);
//					aWorkingTimeTable.ABreakTime.To = DTConst.ChangeHourMinute(dtpEndBreak.Value).AddDays(1);
//				}
//				else
//				{
//					if(dtpStartBreak.Value > dtpEndBreak.Value)
//					{
//						aWorkingTimeTable.ABreakTime.To = DTConst.ChangeHourMinute(dtpEndBreak.Value).AddDays(1);
//						
//					}
//					else
//					{
//						aWorkingTimeTable.ABreakTime.To = DTConst.ChangeHourMinute(dtpEndBreak.Value);
//					}
//					aWorkingTimeTable.ABreakTime.From = DTConst.ChangeHourMinute(dtpStartBreak.Value);
//				}
#endregion
