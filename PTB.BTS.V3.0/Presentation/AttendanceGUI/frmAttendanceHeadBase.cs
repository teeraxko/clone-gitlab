using System;
using System.Data.SqlClient;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity.Time;

using Entity.CommonEntity;

using Facade.AttendanceFacade;

using Presentation.PiGUI;
using Presentation.CommonGUI;

using SystemFramework.AppMessage;
using SystemFramework.AppException;
using SystemFramework.AppConfig;

namespace Presentation.AttendanceGUI
{
	public class frmAttendanceHeadBase : Presentation.CommonGUI.ChildFormBase, IMDIChildForm
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
		private System.Windows.Forms.GroupBox gpbEmployee;
		private System.Windows.Forms.Label lblAgeMonth;
		private System.Windows.Forms.TextBox txtAgeMonth;
		private System.Windows.Forms.Label lblAgeYear;
		private System.Windows.Forms.Label lblAge;
		private System.Windows.Forms.TextBox txtAgeYear;
		private System.Windows.Forms.Label lblPositionType;
		private System.Windows.Forms.TextBox txtPositionType;
		private System.Windows.Forms.Label lblPosition;
		private System.Windows.Forms.TextBox txtEmpPosition;
		private System.Windows.Forms.TextBox txtEmpNo;
		private System.Windows.Forms.TextBox txtEmpName;
		private System.Windows.Forms.Label lblSection;
		private System.Windows.Forms.TextBox txtEmpSection;
		private System.Windows.Forms.Label label4;
		protected System.Windows.Forms.PictureBox pctEmployee;
		private System.Windows.Forms.Button cmdDelete;
		private System.Windows.Forms.Button cmdEdit;
		private System.Windows.Forms.Button cmdAdd;

		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
			this.gpbEmployee = new System.Windows.Forms.GroupBox();
			this.lblAgeMonth = new System.Windows.Forms.Label();
			this.txtAgeMonth = new System.Windows.Forms.TextBox();
			this.lblAgeYear = new System.Windows.Forms.Label();
			this.lblAge = new System.Windows.Forms.Label();
			this.txtAgeYear = new System.Windows.Forms.TextBox();
			this.lblPositionType = new System.Windows.Forms.Label();
			this.txtPositionType = new System.Windows.Forms.TextBox();
			this.lblPosition = new System.Windows.Forms.Label();
			this.txtEmpPosition = new System.Windows.Forms.TextBox();
			this.txtEmpNo = new System.Windows.Forms.TextBox();
			this.txtEmpName = new System.Windows.Forms.TextBox();
			this.lblSection = new System.Windows.Forms.Label();
			this.txtEmpSection = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.pctEmployee = new System.Windows.Forms.PictureBox();
			this.cmdDelete = new System.Windows.Forms.Button();
			this.cmdEdit = new System.Windows.Forms.Button();
			this.cmdAdd = new System.Windows.Forms.Button();
			this.gpbEmployee.SuspendLayout();
			this.SuspendLayout();
			// 
			// gpbEmployee
			// 
			this.gpbEmployee.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.gpbEmployee.Controls.Add(this.lblAgeMonth);
			this.gpbEmployee.Controls.Add(this.txtAgeMonth);
			this.gpbEmployee.Controls.Add(this.lblAgeYear);
			this.gpbEmployee.Controls.Add(this.lblAge);
			this.gpbEmployee.Controls.Add(this.txtAgeYear);
			this.gpbEmployee.Controls.Add(this.lblPositionType);
			this.gpbEmployee.Controls.Add(this.txtPositionType);
			this.gpbEmployee.Controls.Add(this.lblPosition);
			this.gpbEmployee.Controls.Add(this.txtEmpPosition);
			this.gpbEmployee.Controls.Add(this.txtEmpNo);
			this.gpbEmployee.Controls.Add(this.txtEmpName);
			this.gpbEmployee.Controls.Add(this.lblSection);
			this.gpbEmployee.Controls.Add(this.txtEmpSection);
			this.gpbEmployee.Controls.Add(this.label4);
			this.gpbEmployee.Controls.Add(this.pctEmployee);
			this.gpbEmployee.Location = new System.Drawing.Point(9, 0);
			this.gpbEmployee.Name = "gpbEmployee";
			this.gpbEmployee.Size = new System.Drawing.Size(951, 128);
			this.gpbEmployee.TabIndex = 26;
			this.gpbEmployee.TabStop = false;
			// 
			// lblAgeMonth
			// 
			this.lblAgeMonth.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.lblAgeMonth.Location = new System.Drawing.Point(784, 56);
			this.lblAgeMonth.Name = "lblAgeMonth";
			this.lblAgeMonth.Size = new System.Drawing.Size(32, 23);
			this.lblAgeMonth.TabIndex = 19;
			this.lblAgeMonth.Text = "เดือน";
			// 
			// txtAgeMonth
			// 
			this.txtAgeMonth.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.txtAgeMonth.Enabled = false;
			this.txtAgeMonth.Location = new System.Drawing.Point(752, 56);
			this.txtAgeMonth.Name = "txtAgeMonth";
			this.txtAgeMonth.Size = new System.Drawing.Size(32, 20);
			this.txtAgeMonth.TabIndex = 18;
			this.txtAgeMonth.Text = "";
			// 
			// lblAgeYear
			// 
			this.lblAgeYear.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.lblAgeYear.Location = new System.Drawing.Point(728, 56);
			this.lblAgeYear.Name = "lblAgeYear";
			this.lblAgeYear.Size = new System.Drawing.Size(16, 23);
			this.lblAgeYear.TabIndex = 17;
			this.lblAgeYear.Text = "ปี";
			// 
			// lblAge
			// 
			this.lblAge.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.lblAge.Location = new System.Drawing.Point(656, 56);
			this.lblAge.Name = "lblAge";
			this.lblAge.Size = new System.Drawing.Size(24, 23);
			this.lblAge.TabIndex = 15;
			this.lblAge.Text = "อายุ";
			// 
			// txtAgeYear
			// 
			this.txtAgeYear.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.txtAgeYear.Enabled = false;
			this.txtAgeYear.Location = new System.Drawing.Point(688, 56);
			this.txtAgeYear.Name = "txtAgeYear";
			this.txtAgeYear.Size = new System.Drawing.Size(32, 20);
			this.txtAgeYear.TabIndex = 16;
			this.txtAgeYear.Text = "";
			// 
			// lblPositionType
			// 
			this.lblPositionType.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.lblPositionType.Location = new System.Drawing.Point(432, 56);
			this.lblPositionType.Name = "lblPositionType";
			this.lblPositionType.Size = new System.Drawing.Size(80, 23);
			this.lblPositionType.TabIndex = 13;
			this.lblPositionType.Text = "ประเภทตำแหน่ง";
			// 
			// txtPositionType
			// 
			this.txtPositionType.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.txtPositionType.Enabled = false;
			this.txtPositionType.Location = new System.Drawing.Point(520, 56);
			this.txtPositionType.Name = "txtPositionType";
			this.txtPositionType.Size = new System.Drawing.Size(120, 20);
			this.txtPositionType.TabIndex = 14;
			this.txtPositionType.Text = "";
			// 
			// lblPosition
			// 
			this.lblPosition.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.lblPosition.Location = new System.Drawing.Point(16, 56);
			this.lblPosition.Name = "lblPosition";
			this.lblPosition.Size = new System.Drawing.Size(48, 23);
			this.lblPosition.TabIndex = 5;
			this.lblPosition.Text = "ตำแหน่ง";
			// 
			// txtEmpPosition
			// 
			this.txtEmpPosition.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.txtEmpPosition.Enabled = false;
			this.txtEmpPosition.Location = new System.Drawing.Point(72, 56);
			this.txtEmpPosition.Name = "txtEmpPosition";
			this.txtEmpPosition.Size = new System.Drawing.Size(336, 20);
			this.txtEmpPosition.TabIndex = 6;
			this.txtEmpPosition.Text = "";
			// 
			// txtEmpNo
			// 
			this.txtEmpNo.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.txtEmpNo.Location = new System.Drawing.Point(72, 24);
			this.txtEmpNo.MaxLength = 5;
			this.txtEmpNo.Name = "txtEmpNo";
			this.txtEmpNo.Size = new System.Drawing.Size(56, 20);
			this.txtEmpNo.TabIndex = 1;
			this.txtEmpNo.Text = "";
			this.txtEmpNo.TextChanged += new System.EventHandler(this.txtEmpNo_TextChanged);
			this.txtEmpNo.DoubleClick += new System.EventHandler(this.txtEmpNo_DoubleClick);
			// 
			// txtEmpName
			// 
			this.txtEmpName.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.txtEmpName.Enabled = false;
			this.txtEmpName.Location = new System.Drawing.Point(136, 24);
			this.txtEmpName.Name = "txtEmpName";
			this.txtEmpName.Size = new System.Drawing.Size(272, 20);
			this.txtEmpName.TabIndex = 2;
			this.txtEmpName.Text = "";
			// 
			// lblSection
			// 
			this.lblSection.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.lblSection.Location = new System.Drawing.Point(432, 24);
			this.lblSection.Name = "lblSection";
			this.lblSection.Size = new System.Drawing.Size(40, 23);
			this.lblSection.TabIndex = 3;
			this.lblSection.Text = "ส่วนงาน";
			// 
			// txtEmpSection
			// 
			this.txtEmpSection.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.txtEmpSection.Enabled = false;
			this.txtEmpSection.Location = new System.Drawing.Point(520, 24);
			this.txtEmpSection.Name = "txtEmpSection";
			this.txtEmpSection.Size = new System.Drawing.Size(304, 20);
			this.txtEmpSection.TabIndex = 4;
			this.txtEmpSection.Text = "";
			// 
			// label4
			// 
			this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label4.Location = new System.Drawing.Point(16, 24);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(56, 23);
			this.label4.TabIndex = 0;
			this.label4.Text = "พนักงาน";
			// 
			// pctEmployee
			// 
			this.pctEmployee.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.pctEmployee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pctEmployee.Location = new System.Drawing.Point(848, 16);
			this.pctEmployee.Name = "pctEmployee";
			this.pctEmployee.Size = new System.Drawing.Size(88, 104);
			this.pctEmployee.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pctEmployee.TabIndex = 7;
			this.pctEmployee.TabStop = false;
			// 
			// cmdDelete
			// 
			this.cmdDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cmdDelete.Location = new System.Drawing.Point(528, 441);
			this.cmdDelete.Name = "cmdDelete";
			this.cmdDelete.Size = new System.Drawing.Size(72, 24);
			this.cmdDelete.TabIndex = 29;
			this.cmdDelete.Text = "ลบ";
			this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
			// 
			// cmdEdit
			// 
			this.cmdEdit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cmdEdit.Location = new System.Drawing.Point(448, 441);
			this.cmdEdit.Name = "cmdEdit";
			this.cmdEdit.Size = new System.Drawing.Size(72, 24);
			this.cmdEdit.TabIndex = 28;
			this.cmdEdit.Text = "แก้ไข";
			this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
			// 
			// cmdAdd
			// 
			this.cmdAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cmdAdd.Location = new System.Drawing.Point(368, 441);
			this.cmdAdd.Name = "cmdAdd";
			this.cmdAdd.Size = new System.Drawing.Size(72, 24);
			this.cmdAdd.TabIndex = 27;
			this.cmdAdd.Text = "เพิ่ม";
			this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
			// 
			// frmAttendanceHeadBase
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(968, 488);
			this.Controls.Add(this.cmdDelete);
			this.Controls.Add(this.cmdEdit);
			this.Controls.Add(this.cmdAdd);
			this.Controls.Add(this.gpbEmployee);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "frmAttendanceHeadBase";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmAttendanceHeadBase_Load);
			this.gpbEmployee.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region - Private -
		protected frmMain mdiParent; 
		private frmEmplist formEmplist;
		protected EmployeeAttendanceFacadeBase facadeEmployeeAttendance;
		#endregion

		#region - Property -
		#endregion

		//		==============================  Constructor  ==============================
		public frmAttendanceHeadBase() : base()
		{
			InitializeComponent();
		}

		//		==============================Private method ==============================
		#region - Private Method -
		private void NullException(Exception ex)
		{
			ex = null;
		}

		private void bindEmployee()
		{
			txtEmpName.Text = "";
			txtEmpSection.Text = "";
			txtEmpPosition.Text = "";
			txtPositionType.Text = "";

			txtAgeYear.Text = "";
			txtAgeMonth.Text = "";
			pctEmployee.Text = "";
		}

		private void bindEmployee(Employee value)
		{
			txtEmpName.Text = value.EmployeeName;
			txtEmpSection.Text = value.ASection.AFullName.English;
			txtEmpPosition.Text = value.APosition.AName.English;
			txtPositionType.Text = value.APosition.APositionType.ADescription.English;

			YearMonth age = facadeEmployeeAttendance.CalculateAge(value.BirthDate);

			txtAgeYear.Text = age.Year.ToString();
			txtAgeMonth.Text = age.Month.ToString();

			try
			{
				System.IO.DirectoryInfo dirInfo = new System.IO.DirectoryInfo(ApplicationProfile.PHOTO_PATH);
				System.IO.FileInfo[] files = dirInfo.GetFiles(facadeEmployeeAttendance.Employee.EmployeeNo + ".*");
				if (files != null && files.Length == 1)
				{
                    //Old function use file always : woranai 2009/04/27
                    //pctEmployee.Image = System.Drawing.Image.FromFile(files[0].FullName);
                    pctEmployee.Load(files[0].FullName);
				}
				else
				{
					pctEmployee.Image = null;
				}
				dirInfo = null;
				files = null;			
			}
			catch
			{
				pctEmployee.Image = null;
			}
		}

		private void visibleDetailEmployee(bool value)
		{
			txtEmpNo.Enabled = !value;
			txtEmpName.Visible = value;
			lblSection.Visible = value;
			txtEmpSection.Visible = value;
			lblPosition.Visible = value;
			txtEmpPosition.Visible = value;
			lblPositionType.Visible = value;
			txtPositionType.Visible = value;
			lblAge.Visible = value;
			txtAgeYear.Visible = value;
			lblAgeYear.Visible = value;
			txtAgeMonth.Visible = value;
			lblAgeMonth.Visible = value;
			pctEmployee.Visible = value;

			MainMenuNewStatus = value;
			MainMenuRefreshStatus = value;
			mdiParent.EnableNewCommand(value);
			mdiParent.EnableRefreshCommand(value);
		}

		private void visibleButton(bool value)
		{
			cmdAdd.Visible = value;
			cmdEdit.Visible = value;
			cmdDelete.Visible = value;
		}

		protected void enableEditButton(bool value)
		{
			cmdEdit.Enabled = value;
		}

		protected virtual void enableButton(bool value)
		{
			cmdEdit.Enabled = value;
			cmdDelete.Enabled = value;
		}

		protected virtual void visibleForm(bool value)
		{
			visibleButton(value);
		}
		
		protected void setPermission(bool value)
		{
			cmdAdd.Enabled = value;
			cmdDelete.Enabled = value;
		}
		#endregion

		//		==============================  Base Event   ==============================
		#region - Menu Method -
		public virtual void InitForm()
		{
			mdiParent = (frmMain)this.MdiParent;
			formEmplist = new frmEmplist();
			visibleDetailEmployee(false);
			visibleForm(false);
			bindEmployee();
			txtEmpNo.Text = "";
		}

		public virtual void RefreshForm()
		{
		}

		public void PrintForm()
		{}

		public void ExitForm()
		{
			formEmplist = null;
			facadeEmployeeAttendance = null;
			this.Close();
		}

		#endregion

		private void displayEmployee()
		{
			try
			{
				if(facadeEmployeeAttendance.DisplayEmployee(txtEmpNo.Text.Trim()))
				{
					visibleDetailEmployee(true);
					visibleForm(true);
					bindEmployee(facadeEmployeeAttendance.Employee);
					RefreshForm();
				}
				else
				{
					visibleDetailEmployee(false);
					visibleForm(false);
					bindEmployee();
				}
			}
			catch(SqlException sqlex)
			{
				Message(sqlex);
			}
			catch(EmpNotFoundException ex)
			{
				NullException(ex);
				Message(MessageList.Error.E0004, "รหัสพนักงาน");
				setSelected(txtEmpNo);
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
			{}
		}

		private void callEmpList()
		{
			try
			{
				formEmplist.ShowDialog();
				if(formEmplist.Selected)
				{
					txtEmpNo.Text = formEmplist.SelectedEmployee.EmployeeNo;
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
			{}
		}


		protected virtual void addEvent()
		{
		}

		protected virtual void editEvent()
		{
		}
	
		protected virtual void deleteEvent()
		{
		}

		//		==============================     event     ==============================
		private void frmAttendanceHeadBase_Load(object sender, System.EventArgs e)
		{		
		}

		private void txtEmpNo_TextChanged(object sender, System.EventArgs e)
		{
			if(txtEmpNo.Text.Trim().Length == txtEmpNo.MaxLength)
			{
				displayEmployee();
			}
		}

		private void txtEmpNo_DoubleClick(object sender, System.EventArgs e)
		{
			callEmpList();
		}

		private void cmdAdd_Click(object sender, System.EventArgs e)
		{
			addEvent();
		}

		private void cmdEdit_Click(object sender, System.EventArgs e)
		{
			editEvent();
		}

		private void cmdDelete_Click(object sender, System.EventArgs e)
		{
			deleteEvent();
		}
	}
}
