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
using Entity.VehicleEntities;

using Facade.CommonFacade;
using Facade.VehicleFacade;

using Presentation.CommonGUI;

namespace Presentation.VehicleGUI
{
	public class frmDailyProcess : ChildFormBase, IMDIChildForm
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
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DateTimePicker dtpForDate;
		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.Button cmdOK;

		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.dtpForDate = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdOK = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.groupBox1.Controls.Add(this.dtpForDate);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(29, 16);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(296, 72);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			// 
			// dtpForDate
			// 
			this.dtpForDate.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.dtpForDate.CustomFormat = "dd/MM/yyyy";
			this.dtpForDate.Enabled = false;
			this.dtpForDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpForDate.Location = new System.Drawing.Point(176, 27);
			this.dtpForDate.Name = "dtpForDate";
			this.dtpForDate.Size = new System.Drawing.Size(96, 20);
			this.dtpForDate.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label1.Location = new System.Drawing.Point(24, 27);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(136, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Daily Process สำหรับวันที่";
			// 
			// cmdCancel
			// 
			this.cmdCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.Location = new System.Drawing.Point(180, 104);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.TabIndex = 4;
			this.cmdCancel.Text = "ยกเลิก";
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			// 
			// cmdOK
			// 
			this.cmdOK.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.cmdOK.Location = new System.Drawing.Point(100, 104);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.TabIndex = 3;
			this.cmdOK.Text = "ตกลง";
			this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
			// 
			// frmDailyProcess
			// 
			this.AcceptButton = this.cmdOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.cmdCancel;
			this.ClientSize = new System.Drawing.Size(354, 143);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdOK);
			this.Controls.Add(this.groupBox1);
			this.Name = "frmDailyProcess";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Daily Process";
			this.Load += new System.EventHandler(this.frmDailyProcess_Load);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region - Private -
		private bool isReadonly = true;
		private frmMain mdiParent;
		private DailyProcessFacade facadeDailyProcess;
		#endregion

//		============================== Constructor ==============================
		public frmDailyProcess()
		{
			InitializeComponent();
			facadeDailyProcess = new DailyProcessFacade();
			isReadonly = UserProfile.IsReadOnly("miBatchProcess", "miBatchProcessDaily");
            this.title = UserProfile.GetFormName("miBatchProcess", "miBatchProcessDaily");

        }
        public override string FormID()
        {
            return UserProfile.GetFormID("miBatchProcess", "miBatchProcessDaily");
        }

//		==============================Private method ==============================
		public bool UpdateDailyProcess(bool isRerun)
		{
			bool result = true;
			bool isError = false;
			DailyProcessControl dailyProcess;
			PROCESS_STATUS_TYPE type = new PROCESS_STATUS_TYPE();

			try
			{	
				dailyProcess = new DailyProcessControl();
				dailyProcess.DailyDate = dtpForDate.Value;

				if(facadeDailyProcess.FillDailyProcessControl(ref dailyProcess))
				{
					type = dailyProcess.ProcessStatus;

					if(dailyProcess.ProcessStatus == PROCESS_STATUS_TYPE.NOT_RUN || dailyProcess.ProcessStatus == PROCESS_STATUS_TYPE.FINISH)
					{
						if(dailyProcess.ProcessStatus == PROCESS_STATUS_TYPE.FINISH && !isRerun)
						{
							return true;
						}
						else
						{
							if(Message(MessageList.Question.Q0011) == DialogResult.Yes)
							{
								if(dailyProcess.ProcessStatus == PROCESS_STATUS_TYPE.NOT_RUN && isReadonly)
								{
									Message(MessageList.Error.E0051);
									result &= false;
								}
								else
								{
									dailyProcess.ProcessStatus = PROCESS_STATUS_TYPE.RUNNING;
									result &= facadeDailyProcess.UpdateDailyProcessControl(dailyProcess);
								}
							
							}
							else
							{
								result &= false;
							}		
						}
					}
					else
					{
						Message(MessageList.Information.I0003);
						result &= false;
					}
				}
				else
				{
					dailyProcess.DailyDate = dtpForDate.Value;
					dailyProcess.ProcessStatus = PROCESS_STATUS_TYPE.NOT_RUN;
					result &= facadeDailyProcess.InsertDailyProcessControl(dailyProcess);
					if(Message(MessageList.Question.Q0011) == DialogResult.Yes)
					{
						if(dailyProcess.ProcessStatus == PROCESS_STATUS_TYPE.NOT_RUN && isReadonly)
						{
							Message(MessageList.Error.E0051);
							result &= false;
						}
						else
						{
							dailyProcess.ProcessStatus = PROCESS_STATUS_TYPE.RUNNING;
							result &= facadeDailyProcess.UpdateDailyProcessControl(dailyProcess);
						}
					}
					else
					{
						result &= false;
					}					
				}		

				if(result)
				{
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					Application.DoEvents();

					if(facadeDailyProcess.UpdateDailyProcess(dtpForDate.Value))
					{
						dailyProcess.ProcessStatus = PROCESS_STATUS_TYPE.FINISH;
						if(facadeDailyProcess.UpdateDailyProcessControl(dailyProcess))
						{
							result &= true;
							this.Cursor = System.Windows.Forms.Cursors.Arrow;
							Message(MessageList.Information.I0002);
							dtpForDate.Focus();
						}
						else
						{
							result &= false;
						}							
					}
					else
					{
						result &= false;
						isError = true;
					}
				}
			}
			catch(SqlException sqlex)
			{
				Message(sqlex);
				isError = true;
				result &= false;
			}
			catch(AppExceptionBase ex)
			{
				Message(ex);
				isError = true;
				result &= false;
			}
			catch(Exception ex)
			{
				Message(ex);
				isError = true;
				result &= false;
			}
			finally
			{
				if(isError)
				{
					dailyProcess = new DailyProcessControl();
					dailyProcess.DailyDate = dtpForDate.Value;

					if(type == PROCESS_STATUS_TYPE.FINISH)
					{
						dailyProcess.ProcessStatus = PROCESS_STATUS_TYPE.FINISH;
					}
					else
					{
						dailyProcess.ProcessStatus = PROCESS_STATUS_TYPE.NOT_RUN;	
						Message(MessageList.Error.E0024);
					}
					
					facadeDailyProcess.UpdateDailyProcessControl(dailyProcess);
				}
				
				this.Cursor = System.Windows.Forms.Cursors.Arrow;
				dailyProcess = null;
			}		

			return result;
		}

//		============================== Base Event ==============================
		public void InitForm()
		{		
			clearMainMenuStatus();
			baseInitMenuMDIParent(mdiParent);
			dtpForDate.Value = DateTime.Today;

			if(isReadonly)
			{
				cmdOK.Enabled = false;
			}
		}

		public void RefreshForm()
		{
		}

		public void PrintForm()
		{
		}

		public void ExitForm()
		{
			Dispose(true);
		}

		public bool ProcessDaily()
		{
			return true;
		}

//		==============================Event ==============================
		private void frmDailyProcess_Load(object sender, System.EventArgs e)
		{
			mdiParent = (frmMain)this.MdiParent;
			InitForm();
            this.WindowState = FormWindowState.Normal;
		}

		private void cmdOK_Click(object sender, System.EventArgs e)
		{
			UpdateDailyProcess(true);
		}

		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
