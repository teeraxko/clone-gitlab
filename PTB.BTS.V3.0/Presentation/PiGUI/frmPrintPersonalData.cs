//using System;
//using System.Drawing;
//using System.Collections;
//using System.ComponentModel;
//using System.Windows.Forms;
//using System.Data.SqlClient;
//
//using SystemFramework.AppMessage;
//using SystemFramework.AppException;
//
//using ictus.PIS.PI.Entity;
//using Entity.CommonEntity;
//
//using Facade.PiFacade;
//using Facade.CommonFacade;
//
//using Presentation.CommonGUI;
//
//namespace Presentation.PiGUI
//{
//	public class frmPrintPersonalData : ChildFormBase, IMDIChildForm
//	{
//		private System.Windows.Forms.GroupBox groupBox1;
//		private System.Windows.Forms.Label label1;
//		private System.Windows.Forms.Button cmdOK;
//		private System.Windows.Forms.Button cmdCancel;
//		private System.Windows.Forms.GroupBox gpbDepartment;
//		private System.Windows.Forms.ComboBox cboDepartment;
//		private System.Windows.Forms.GroupBox gpbSection;
//		private System.Windows.Forms.ComboBox cboSection;
//		private System.Windows.Forms.GroupBox gpbEmpName;
//		private System.Windows.Forms.ProgressBar pgbProcess;
//		private System.Windows.Forms.TextBox txtEmpName;
//		private System.Windows.Forms.TextBox txtEmpCode;
//		private System.Windows.Forms.Label label2;
//		private System.Windows.Forms.RadioButton rdoEmpName;
//		private System.Windows.Forms.RadioButton rdoSection;
//		private System.Windows.Forms.RadioButton rdoDepartment;
//		private System.Windows.Forms.RadioButton rdoAll;
//
//		private System.ComponentModel.Container components = null;
//
//		protected override void Dispose( bool disposing )
//		{
//			if( disposing )
//			{
//				if(components != null)
//				{
//					components.Dispose();
//				}
//			}
//			base.Dispose( disposing );
//		}
//
//		#region - Private -
//		private frmMain mdiParent;
//		#endregion - Private - 
//		#region Windows Form Designer generated code
//
//		private void InitializeComponent()
//		{
//			this.groupBox1 = new System.Windows.Forms.GroupBox();
//			this.rdoEmpName = new System.Windows.Forms.RadioButton();
//			this.rdoSection = new System.Windows.Forms.RadioButton();
//			this.rdoDepartment = new System.Windows.Forms.RadioButton();
//			this.rdoAll = new System.Windows.Forms.RadioButton();
//			this.cmdOK = new System.Windows.Forms.Button();
//			this.cmdCancel = new System.Windows.Forms.Button();
//			this.gpbDepartment = new System.Windows.Forms.GroupBox();
//			this.cboDepartment = new System.Windows.Forms.ComboBox();
//			this.gpbSection = new System.Windows.Forms.GroupBox();
//			this.cboSection = new System.Windows.Forms.ComboBox();
//			this.gpbEmpName = new System.Windows.Forms.GroupBox();
//			this.label2 = new System.Windows.Forms.Label();
//			this.txtEmpCode = new System.Windows.Forms.TextBox();
//			this.txtEmpName = new System.Windows.Forms.TextBox();
//			this.pgbProcess = new System.Windows.Forms.ProgressBar();
//			this.label1 = new System.Windows.Forms.Label();
//			this.groupBox1.SuspendLayout();
//			this.gpbDepartment.SuspendLayout();
//			this.gpbSection.SuspendLayout();
//			this.gpbEmpName.SuspendLayout();
//			this.SuspendLayout();
//			// 
//			// groupBox1
//			// 
//			this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
//			this.groupBox1.Controls.Add(this.rdoEmpName);
//			this.groupBox1.Controls.Add(this.rdoSection);
//			this.groupBox1.Controls.Add(this.rdoDepartment);
//			this.groupBox1.Controls.Add(this.rdoAll);
//			this.groupBox1.Location = new System.Drawing.Point(16, 16);
//			this.groupBox1.Name = "groupBox1";
//			this.groupBox1.Size = new System.Drawing.Size(600, 64);
//			this.groupBox1.TabIndex = 0;
//			this.groupBox1.TabStop = false;
//			this.groupBox1.Text = "กำหนดเงื่อนไขการพิมพ์";
//			// 
//			// rdoEmpName
//			// 
//			this.rdoEmpName.Location = new System.Drawing.Point(416, 24);
//			this.rdoEmpName.Name = "rdoEmpName";
//			this.rdoEmpName.Size = new System.Drawing.Size(168, 24);
//			this.rdoEmpName.TabIndex = 6;
//			this.rdoEmpName.Text = "  พิมพ์ตามรายชื่อพนักงาน";
//			this.rdoEmpName.CheckedChanged += new System.EventHandler(this.rdoEmpName_CheckedChanged);
//			// 
//			// rdoSection
//			// 
//			this.rdoSection.Location = new System.Drawing.Point(296, 24);
//			this.rdoSection.Name = "rdoSection";
//			this.rdoSection.TabIndex = 5;
//			this.rdoSection.Text = "  พิมพ์ตามส่วนงาน";
//			this.rdoSection.CheckedChanged += new System.EventHandler(this.rdoSection_CheckedChanged);
//			// 
//			// rdoDepartment
//			// 
//			this.rdoDepartment.Location = new System.Drawing.Point(144, 24);
//			this.rdoDepartment.Name = "rdoDepartment";
//			this.rdoDepartment.Size = new System.Drawing.Size(136, 24);
//			this.rdoDepartment.TabIndex = 4;
//			this.rdoDepartment.Text = " พิมพ์ตามฝ่ายต้นสังกัด";
//			this.rdoDepartment.CheckedChanged += new System.EventHandler(this.rdoDepartment_CheckedChanged);
//			// 
//			// rdoAll
//			// 
//			this.rdoAll.Location = new System.Drawing.Point(24, 24);
//			this.rdoAll.Name = "rdoAll";
//			this.rdoAll.TabIndex = 3;
//			this.rdoAll.Text = "  พิมพ์ทั้งหมด";
//			this.rdoAll.CheckedChanged += new System.EventHandler(this.rdoAll_CheckedChanged);
//			// 
//			// cmdOK
//			// 
//			this.cmdOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
//			this.cmdOK.Location = new System.Drawing.Point(208, 320);
//			this.cmdOK.Name = "cmdOK";
//			this.cmdOK.TabIndex = 1;
//			this.cmdOK.Text = "ตกลง";
//			// 
//			// cmdCancel
//			// 
//			this.cmdCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
//			this.cmdCancel.Location = new System.Drawing.Point(304, 320);
//			this.cmdCancel.Name = "cmdCancel";
//			this.cmdCancel.TabIndex = 2;
//			this.cmdCancel.Text = "ยกเลิก";
//			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
//			// 
//			// gpbDepartment
//			// 
//			this.gpbDepartment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
//			this.gpbDepartment.Controls.Add(this.cboDepartment);
//			this.gpbDepartment.Location = new System.Drawing.Point(16, 96);
//			this.gpbDepartment.Name = "gpbDepartment";
//			this.gpbDepartment.Size = new System.Drawing.Size(256, 72);
//			this.gpbDepartment.TabIndex = 3;
//			this.gpbDepartment.TabStop = false;
//			this.gpbDepartment.Text = " พิมพ์ตามฝ่ายต้นสังกัด";
//			// 
//			// cboDepartment
//			// 
//			this.cboDepartment.Location = new System.Drawing.Point(16, 32);
//			this.cboDepartment.Name = "cboDepartment";
//			this.cboDepartment.Size = new System.Drawing.Size(200, 21);
//			this.cboDepartment.TabIndex = 0;
//			this.cboDepartment.Text = "comboBox1";
//			// 
//			// gpbSection
//			// 
//			this.gpbSection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
//			this.gpbSection.Controls.Add(this.cboSection);
//			this.gpbSection.Location = new System.Drawing.Point(16, 176);
//			this.gpbSection.Name = "gpbSection";
//			this.gpbSection.Size = new System.Drawing.Size(256, 72);
//			this.gpbSection.TabIndex = 4;
//			this.gpbSection.TabStop = false;
//			this.gpbSection.Text = "  พิมพ์ตามส่วนงาน";
//			// 
//			// cboSection
//			// 
//			this.cboSection.Location = new System.Drawing.Point(16, 32);
//			this.cboSection.Name = "cboSection";
//			this.cboSection.Size = new System.Drawing.Size(200, 21);
//			this.cboSection.TabIndex = 1;
//			this.cboSection.Text = "comboBox2";
//			// 
//			// gpbEmpName
//			// 
//			this.gpbEmpName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
//			this.gpbEmpName.Controls.Add(this.label2);
//			this.gpbEmpName.Controls.Add(this.txtEmpCode);
//			this.gpbEmpName.Controls.Add(this.txtEmpName);
//			this.gpbEmpName.Location = new System.Drawing.Point(296, 96);
//			this.gpbEmpName.Name = "gpbEmpName";
//			this.gpbEmpName.Size = new System.Drawing.Size(320, 152);
//			this.gpbEmpName.TabIndex = 5;
//			this.gpbEmpName.TabStop = false;
//			this.gpbEmpName.Text = " พิมพ์ตามรายชื่อพนักงาน";
//			// 
//			// label2
//			// 
//			this.label2.Location = new System.Drawing.Point(24, 32);
//			this.label2.Name = "label2";
//			this.label2.Size = new System.Drawing.Size(48, 23);
//			this.label2.TabIndex = 2;
//			this.label2.Text = "รหัส";
//			// 
//			// txtEmpCode
//			// 
//			this.txtEmpCode.Location = new System.Drawing.Point(112, 32);
//			this.txtEmpCode.MaxLength = 5;
//			this.txtEmpCode.Name = "txtEmpCode";
//			this.txtEmpCode.Size = new System.Drawing.Size(44, 20);
//			this.txtEmpCode.TabIndex = 1;
//			this.txtEmpCode.Text = "";
//			this.txtEmpCode.DoubleClick += new System.EventHandler(this.txtEmpCode_DoubleClick);
//			// 
//			// txtEmpName
//			// 
//			this.txtEmpName.Enabled = false;
//			this.txtEmpName.Location = new System.Drawing.Point(112, 64);
//			this.txtEmpName.MaxLength = 50;
//			this.txtEmpName.Name = "txtEmpName";
//			this.txtEmpName.Size = new System.Drawing.Size(168, 20);
//			this.txtEmpName.TabIndex = 0;
//			this.txtEmpName.Text = "";
//			// 
//			// pgbProcess
//			// 
//			this.pgbProcess.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
//			this.pgbProcess.Location = new System.Drawing.Point(120, 280);
//			this.pgbProcess.Name = "pgbProcess";
//			this.pgbProcess.Size = new System.Drawing.Size(360, 23);
//			this.pgbProcess.TabIndex = 6;
//			this.pgbProcess.Click += new System.EventHandler(this.pgbProcess_Click);
//			// 
//			// label1
//			// 
//			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
//			this.label1.Location = new System.Drawing.Point(168, 368);
//			this.label1.Name = "label1";
//			this.label1.Size = new System.Drawing.Size(256, 23);
//			this.label1.TabIndex = 7;
//			this.label1.Text = "กำลังเตรียมข้อมูลเพื่อออกรายงาน";
//			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
//			// 
//			// frmPrintPersonalData
//			// 
//			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
//			this.ClientSize = new System.Drawing.Size(632, 422);
//			this.Controls.Add(this.label1);
//			this.Controls.Add(this.pgbProcess);
//			this.Controls.Add(this.gpbEmpName);
//			this.Controls.Add(this.gpbSection);
//			this.Controls.Add(this.gpbDepartment);
//			this.Controls.Add(this.cmdCancel);
//			this.Controls.Add(this.cmdOK);
//			this.Controls.Add(this.groupBox1);
//			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
//			this.Name = "frmPrintPersonalData";
//			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
//			this.Text = "พิมพ์รายงานข้อมูลบุคคล";
//			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
//			this.Load += new System.EventHandler(this.frmPrintPersonalData_Load);
//			this.Closed += new System.EventHandler(this.frmPrintPersonalData_Closed);
//			this.groupBox1.ResumeLayout(false);
//			this.gpbDepartment.ResumeLayout(false);
//			this.gpbSection.ResumeLayout(false);
//			this.gpbEmpName.ResumeLayout(false);
//			this.ResumeLayout(false);
//
//		}
//		#endregion
//
//		private PrintPersonalDataFacade facadePrintPersonalData;
//		public PrintPersonalDataFacade FacadePrintPersonalData
//		{
//			get
//			{
//				return facadePrintPersonalData;
//			}
//		}
//		public frmPrintPersonalData(): base()
//		{
//			InitializeComponent();	
//			CTFunction ctFunction = new CTFunction();
//			facadePrintPersonalData = new PrintPersonalDataFacade();
//			cboDepartment.DataSource = facadePrintPersonalData.DataSourceDepartment;
//			cboSection.DataSource = facadePrintPersonalData.DataSourceSection;
//			rdoAll.Checked = true;
//			EnableGroupBox(false);
//
//		}
//		private void EnableGroupBox(bool enable)
//		{
//			gpbDepartment.Enabled = enable;
//			gpbEmpName.Enabled = enable;
//			gpbSection.Enabled = enable;
//		}
//		private void EnableGPBDepartment (bool enable)
//		{
//			gpbDepartment.Enabled = enable;
//		}
//		private void EnableGPBEmpName (bool enable)
//		{
//			gpbEmpName.Enabled = enable;
//		}
//		private void EnableGPBSection (bool enable)
//		{
//			gpbSection.Enabled = enable;
//		}
//		
//		//		============================== Base Event ==============================
//		public void InitForm()
//		{
//			mdiParent.EnableNewCommand(false);
//			mdiParent.EnableDeleteCommand(false);
//			mdiParent.EnableRefreshCommand(true);
//			mdiParent.EnablePrintCommand(true);
//			mdiParent.EnableExitCommand(true);
//
//			try
//			{
//				
//			}
//			catch(SqlException sqlex)
//			{
//				Message(sqlex);
//			}
//			catch(AppExceptionBase ex)
//			{
//				Message(ex);
//			}
//			catch(Exception ex)
//			{
//				Message(ex);
//			}
//		}
//
//		public void RefreshForm()
//		{
//			InitForm();
//		}
//
//		public void PrintForm()
//		{
//		}
//
//		public void ExitForm()
//		{
//			mdiParent.EnableNewCommand(true);
//			mdiParent.EnableDeleteCommand(true);
//			mdiParent.EnableRefreshCommand(true);
//			mdiParent.EnablePrintCommand(true);
//			mdiParent.EnableExitCommand(true);
//			Dispose(true);
//		}
//		//		============================== Event ==============================
//		private void frmPrintPersonalData_Load(object sender, System.EventArgs e)
//		{		
//			mdiParent = (frmMain)this.MdiParent;
//			InitForm();
//		}
//		private void rdoDepartment_CheckedChanged(object sender, System.EventArgs e)
//		{
//			EnableGroupBox(false);
//			EnableGPBDepartment(true);
//		}
//		private void rdoSection_CheckedChanged(object sender, System.EventArgs e)
//		{
//			EnableGroupBox(false);
//			EnableGPBSection(true);
//		}
//		private void rdoEmpName_CheckedChanged(object sender, System.EventArgs e)
//		{
//			EnableGroupBox(false);
//			EnableGPBEmpName(true);
//		}
//		private void rdoAll_CheckedChanged(object sender, System.EventArgs e)
//		{
//			EnableGroupBox(false);
//		}
//		private void txtEmpCode_DoubleClick(object sender, System.EventArgs e)
//		{
//			frmEmplist dialogEmplist = new frmEmplist();
//			dialogEmplist.ShowDialog();
//			if(dialogEmplist.Selected)
//			{
//				txtEmpName.Text = dialogEmplist.SelectedEmployee.APrefix.Thai +
//					dialogEmplist.SelectedEmployee.AName.Thai + " " + 
//					dialogEmplist.SelectedEmployee.ASurname.Thai;
//			}
//		}
//		private void cmdCancel_Click(object sender, System.EventArgs e)
//		{
//			this.Hide();
//		}
//		private void pgbProcess_Click(object sender, System.EventArgs e)
//		{
//			for (int i = 1; i<= 5; i++)
//			{
//				pgbProcess.Increment(i);
//			}
//
//		}
//		private void frmPrintPersonalData_Closed(object sender, System.EventArgs e)
//		{
//			ExitForm();
//		}
//
//	}
//}
