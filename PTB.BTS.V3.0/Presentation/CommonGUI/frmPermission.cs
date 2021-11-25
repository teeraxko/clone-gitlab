using System;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using FarPoint.Win.Spread.CellType;

using SystemFramework.AppConfig;
using SystemFramework.AppException;
using SystemFramework.AppMessage;

using Facade.CommonFacade;

namespace Presentation.CommonGUI
{
	public class frmPermission : Presentation.CommonGUI.ChildFormBase, IMDIChildForm
	{
		#region Windows Form Designer generated code
			private System.Windows.Forms.TreeView trvUserPermission;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.RadioButton rdbAccess;
		private System.Windows.Forms.RadioButton rdbNoAccess;
		private System.Windows.Forms.ImageList imlList;
		private FarPoint.Win.Spread.FpSpread fpSpread1;
		private FarPoint.Win.Spread.SheetView fpsFunctionPermission;
		private System.Windows.Forms.Button btnUpdateChange;
		private System.Windows.Forms.Button btnDeletePermission;
		private System.Windows.Forms.TextBox lblUserName;
		private System.Windows.Forms.TextBox lblModuleName;
			private System.ComponentModel.IContainer components = null;

			protected override void Dispose( bool disposing )
			{
				if( disposing )
				{
					if (components != null) 
					{
						components.Dispose();
					}
				}
				base.Dispose( disposing );
			}

			private void InitializeComponent()
			{
				this.components = new System.ComponentModel.Container();
				System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmPermission));
				FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType1 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
				this.trvUserPermission = new System.Windows.Forms.TreeView();
				this.imlList = new System.Windows.Forms.ImageList(this.components);
				this.groupBox1 = new System.Windows.Forms.GroupBox();
				this.lblModuleName = new System.Windows.Forms.TextBox();
				this.lblUserName = new System.Windows.Forms.TextBox();
				this.rdbNoAccess = new System.Windows.Forms.RadioButton();
				this.rdbAccess = new System.Windows.Forms.RadioButton();
				this.label3 = new System.Windows.Forms.Label();
				this.label2 = new System.Windows.Forms.Label();
				this.label1 = new System.Windows.Forms.Label();
				this.fpSpread1 = new FarPoint.Win.Spread.FpSpread();
				this.fpsFunctionPermission = new FarPoint.Win.Spread.SheetView();
				this.btnUpdateChange = new System.Windows.Forms.Button();
				this.btnDeletePermission = new System.Windows.Forms.Button();
				this.groupBox1.SuspendLayout();
				((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).BeginInit();
				((System.ComponentModel.ISupportInitialize)(this.fpsFunctionPermission)).BeginInit();
				this.SuspendLayout();
				// 
				// trvUserPermission
				// 
				this.trvUserPermission.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
				this.trvUserPermission.ImageList = this.imlList;
				this.trvUserPermission.Indent = 25;
				this.trvUserPermission.ItemHeight = 20;
				this.trvUserPermission.Location = new System.Drawing.Point(24, 24);
				this.trvUserPermission.Name = "trvUserPermission";
				this.trvUserPermission.ShowPlusMinus = false;
				this.trvUserPermission.Size = new System.Drawing.Size(368, 432);
				this.trvUserPermission.TabIndex = 0;
				this.trvUserPermission.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvUserPermission_AfterSelect);
				// 
				// imlList
				// 
				this.imlList.ImageSize = new System.Drawing.Size(20, 20);
				this.imlList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlList.ImageStream")));
				this.imlList.TransparentColor = System.Drawing.Color.Transparent;
				// 
				// groupBox1
				// 
				this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
				this.groupBox1.Controls.Add(this.lblModuleName);
				this.groupBox1.Controls.Add(this.lblUserName);
				this.groupBox1.Controls.Add(this.rdbNoAccess);
				this.groupBox1.Controls.Add(this.rdbAccess);
				this.groupBox1.Controls.Add(this.label3);
				this.groupBox1.Controls.Add(this.label2);
				this.groupBox1.Controls.Add(this.label1);
				this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
				this.groupBox1.Location = new System.Drawing.Point(408, 24);
				this.groupBox1.Name = "groupBox1";
				this.groupBox1.Size = new System.Drawing.Size(440, 120);
				this.groupBox1.TabIndex = 1;
				this.groupBox1.TabStop = false;
				this.groupBox1.Text = "ข้อมูลผู้ใช้ระบบ";
				// 
				// lblModuleName
				// 
				this.lblModuleName.BackColor = System.Drawing.Color.White;
				this.lblModuleName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
				this.lblModuleName.Location = new System.Drawing.Point(96, 56);
				this.lblModuleName.Name = "lblModuleName";
				this.lblModuleName.ReadOnly = true;
				this.lblModuleName.Size = new System.Drawing.Size(192, 23);
				this.lblModuleName.TabIndex = 8;
				this.lblModuleName.Text = "";
				// 
				// lblUserName
				// 
				this.lblUserName.BackColor = System.Drawing.Color.White;
				this.lblUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
				this.lblUserName.Location = new System.Drawing.Point(96, 24);
				this.lblUserName.Name = "lblUserName";
				this.lblUserName.ReadOnly = true;
				this.lblUserName.Size = new System.Drawing.Size(192, 23);
				this.lblUserName.TabIndex = 7;
				this.lblUserName.Text = "";
				// 
				// rdbNoAccess
				// 
				this.rdbNoAccess.Checked = true;
				this.rdbNoAccess.Location = new System.Drawing.Point(200, 88);
				this.rdbNoAccess.Name = "rdbNoAccess";
				this.rdbNoAccess.Size = new System.Drawing.Size(88, 24);
				this.rdbNoAccess.TabIndex = 6;
				this.rdbNoAccess.TabStop = true;
				this.rdbNoAccess.Text = "No Access";
				// 
				// rdbAccess
				// 
				this.rdbAccess.Location = new System.Drawing.Point(96, 88);
				this.rdbAccess.Name = "rdbAccess";
				this.rdbAccess.Size = new System.Drawing.Size(72, 18);
				this.rdbAccess.TabIndex = 5;
				this.rdbAccess.Text = "Access";
				this.rdbAccess.CheckedChanged += new System.EventHandler(this.rdbAccess_CheckedChanged);
				// 
				// label3
				// 
				this.label3.AutoSize = true;
				this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
				this.label3.Location = new System.Drawing.Point(16, 88);
				this.label3.Name = "label3";
				this.label3.Size = new System.Drawing.Size(75, 18);
				this.label3.TabIndex = 4;
				this.label3.Text = "Permission : ";
				// 
				// label2
				// 
				this.label2.AutoSize = true;
				this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
				this.label2.Location = new System.Drawing.Point(16, 56);
				this.label2.Name = "label2";
				this.label2.Size = new System.Drawing.Size(56, 18);
				this.label2.TabIndex = 2;
				this.label2.Text = "Module : ";
				// 
				// label1
				// 
				this.label1.AutoSize = true;
				this.label1.Location = new System.Drawing.Point(16, 24);
				this.label1.Name = "label1";
				this.label1.Size = new System.Drawing.Size(52, 19);
				this.label1.TabIndex = 0;
				this.label1.Text = "ชื่อผู้ใช้ : ";
				// 
				// fpSpread1
				// 
				this.fpSpread1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
				this.fpSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
				this.fpSpread1.Location = new System.Drawing.Point(408, 160);
				this.fpSpread1.Name = "fpSpread1";
				this.fpSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
																					   this.fpsFunctionPermission});
				this.fpSpread1.Size = new System.Drawing.Size(440, 264);
				this.fpSpread1.TabIndex = 2;
				this.fpSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
				// 
				// fpsFunctionPermission
				// 
				this.fpsFunctionPermission.Reset();
				// Formulas and custom names must be loaded with R1C1 reference style
				this.fpsFunctionPermission.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
				this.fpsFunctionPermission.ColumnCount = 2;
				this.fpsFunctionPermission.RowCount = 0;
				this.fpsFunctionPermission.AlternatingRows.Get(0).BackColor = System.Drawing.Color.AliceBlue;
				this.fpsFunctionPermission.ColumnHeader.Cells.Get(0, 0).Text = "Function Name";
				this.fpsFunctionPermission.ColumnHeader.Cells.Get(0, 1).Text = "Permission";
				this.fpsFunctionPermission.ColumnHeader.Columns.Default.Resizable = false;
				this.fpsFunctionPermission.Columns.Default.Resizable = false;
				this.fpsFunctionPermission.Columns.Get(0).Label = "Function Name";
				this.fpsFunctionPermission.Columns.Get(0).Locked = true;
				this.fpsFunctionPermission.Columns.Get(0).Width = 250F;
				comboBoxCellType1.ItemData = new string[] {
															  "F",
															  "R",
															  "N"};
				comboBoxCellType1.Items = new string[] {
														   "Full Control",
														   "Read Only",
														   "No Access"};
				this.fpsFunctionPermission.Columns.Get(1).CellType = comboBoxCellType1;
				this.fpsFunctionPermission.Columns.Get(1).Label = "Permission";
				this.fpsFunctionPermission.Columns.Get(1).Width = 100F;
				this.fpsFunctionPermission.RowHeader.Columns.Default.Resizable = false;
				this.fpsFunctionPermission.RowHeader.Rows.Default.Resizable = false;
				this.fpsFunctionPermission.Rows.Default.Resizable = false;
				this.fpsFunctionPermission.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
				this.fpsFunctionPermission.SheetName = "Sheet1";
				this.fpsFunctionPermission.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
				// 
				// btnUpdateChange
				// 
				this.btnUpdateChange.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
				this.btnUpdateChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
				this.btnUpdateChange.Location = new System.Drawing.Point(544, 432);
				this.btnUpdateChange.Name = "btnUpdateChange";
				this.btnUpdateChange.Size = new System.Drawing.Size(104, 23);
				this.btnUpdateChange.TabIndex = 3;
				this.btnUpdateChange.Text = "เปลี่ยนแปลงสิทธิ์";
				this.btnUpdateChange.Click += new System.EventHandler(this.btnUpdateChange_Click);
				// 
				// btnDeletePermission
				// 
				this.btnDeletePermission.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
				this.btnDeletePermission.Location = new System.Drawing.Point(656, 432);
				this.btnDeletePermission.Name = "btnDeletePermission";
				this.btnDeletePermission.Size = new System.Drawing.Size(72, 23);
				this.btnDeletePermission.TabIndex = 4;
				this.btnDeletePermission.Text = "ลบสิทธิ์ผู้ใช้";
				this.btnDeletePermission.Click += new System.EventHandler(this.btnDeletePermission_Click);
				// 
				// frmPermission
				// 
				this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
				this.BackColor = System.Drawing.SystemColors.Control;
				this.ClientSize = new System.Drawing.Size(872, 478);
				this.Controls.Add(this.btnDeletePermission);
				this.Controls.Add(this.btnUpdateChange);
				this.Controls.Add(this.fpSpread1);
				this.Controls.Add(this.groupBox1);
				this.Controls.Add(this.trvUserPermission);
				this.Name = "frmPermission";
				this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
				this.Load += new System.EventHandler(this.frmPermission_Load);
				this.groupBox1.ResumeLayout(false);
				((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).EndInit();
				((System.ComponentModel.ISupportInitialize)(this.fpsFunctionPermission)).EndInit();
				this.ResumeLayout(false);

			}
		#endregion

		#region - Constant -
		#endregion

		#region - Private - 
			private PermissionFacade facadePermission;
			private frmMain mdiParent;
		#endregion

		//============================== Property ==============================
		private MODULE_PERMISSION ModulePermission
		{
			get
			{
				if(rdbAccess.Checked)
				{
					return MODULE_PERMISSION.ACCESS;
				}
				else
				{
					return MODULE_PERMISSION.NO_ACCESS;
				}
			}
		}

		//============================== Constructor ==============================
		public frmPermission() : base()
		{
			InitializeComponent();
			facadePermission = new PermissionFacade();
		}

		//============================== Private Method ==============================
		#region - Private Method - 
			private int imageIndex(USER_ROLE value)
			{
				switch(value)
				{
					case USER_ROLE.ADMIN :
					{
						return 0;
					}
					case USER_ROLE.POWER_USER :
					{
						return 1;
					}
					case USER_ROLE.USER :
					{
						return 2;
					}
					default :
					{
						return 2;
					}
				}
			}
			
			private int imageIndex(MODULE_PERMISSION value)
			{
				switch(value)
				{
					case MODULE_PERMISSION.ACCESS :
					{
						return 3;
					}
					case MODULE_PERMISSION.NO_ACCESS :
					{
						return 4;
					}
					default :
					{
						return 4;
					}
				}
			}

			private int imageIndex(FUNCTION_PERMISSION value)
			{
				switch(value)
				{
					case FUNCTION_PERMISSION.FULL_CONTROL :
					{
						return 5;
					}
					case FUNCTION_PERMISSION.READ_ONLY :
					{
						return 6;
					}
					case FUNCTION_PERMISSION.NO_ACCESS :
					{
						return 7;
					}
					default :
					{
						return 7;
					}
				}
			}

			private void bindUserProfile(TreeNode value)
			{
				ApplicationUserPermission userPermission = (ApplicationUserPermission)value.Tag;
				lblUserName.Text = userPermission.AUser.UserName;
				lblUserName.Tag = value;
				userPermission = null;
			}

			private void clearUserProfile()
			{
				lblUserName.Text = "";
				lblUserName.Tag = null;
			}

			private void bindFunction(int row, FunctionPermission value)
			{
				fpsFunctionPermission.Cells[row, 0].Text = value.Description;
				fpsFunctionPermission.Cells[row, 1].Text = value.PermissionString;
			}

			private void bindModule(TreeNode value)
			{
				ModulePermission modulePermission = (ModulePermission)value.Tag;
				lblModuleName.Text = modulePermission.Module.Description;
				lblModuleName.Tag = value;
				switch(modulePermission.Permission)
				{
					case MODULE_PERMISSION.ACCESS :
					{
						rdbAccess.Checked = true;
						fpsFunctionPermission.RowCount = modulePermission.Count;
						for(int i=0; i<modulePermission.Count; i++)
						{
							bindFunction(i, modulePermission[i]);
						}
						break;				
					}
					case MODULE_PERMISSION.NO_ACCESS :
					{
						rdbNoAccess.Checked = true;
						fpsFunctionPermission.RowCount = modulePermission.Count;
						for(int i=0; i<modulePermission.Count; i++)
						{
							bindFunction(i, modulePermission[i]);
						}
						break;				
					}
					default :
					{
						rdbNoAccess.Checked = true;
						break;
					}
				}
			}

			private void clearModule()
			{
				lblModuleName.Text = "";
				fpsFunctionPermission.RowCount = 0;
			}
		#endregion

		private void bindTreeview()
		{
			trvUserPermission.BeginUpdate();
			trvUserPermission.Nodes.Clear();

			ApplicationUserPermission userPermission;
			TreeNode userNode;

			ModulePermission modulePermission;
			TreeNode moduleNode;

			FunctionPermission functionPermission;
			TreeNode functionNode;

			for(int i=0; i<facadePermission.UserPermissionList.Count; i++)
			{
				userPermission = facadePermission.UserPermissionList[i];

				if(userPermission.AUser.UserRole < UserProfile.UserROLE)
				{
					continue;
				}

				int imgIndex = imageIndex(userPermission.AUser.UserRole);
				userNode = new TreeNode(userPermission.AUser.UserName, imgIndex, imgIndex);
				userNode.Tag = userPermission;

				for(int j=0; j<userPermission.Count; j++)
				{
					modulePermission = userPermission[j];
					if((UserProfile.UserROLE != USER_ROLE.ADMIN) && (modulePermission.Module.IsSystem))
					{
						continue;
					}

					imgIndex = imageIndex(modulePermission.Permission);
					moduleNode = new TreeNode(modulePermission.Description, imgIndex, imgIndex);
					moduleNode.Tag = modulePermission;
	
					for(int k=0; k<modulePermission.Count; k++)
					{
						functionPermission = modulePermission[k];
						if((UserProfile.UserROLE != USER_ROLE.ADMIN) && (functionPermission.Function.IsSystem))
						{
							continue;
						}

						imgIndex = imageIndex(functionPermission.Permission);
						functionNode = new TreeNode(functionPermission.Description, imgIndex, imgIndex);
						functionNode.Tag = functionPermission;

						moduleNode.Nodes.Add(functionNode);
					}

					userNode.Nodes.Add(moduleNode);
				}
				trvUserPermission.Nodes.Add(userNode);
			}
			trvUserPermission.EndUpdate();
		}

		private void clearForm()
		{
			clearUserProfile();
			clearModule();
		}

		//============================== Public Method ==============================

		//============================== Base Event ==============================
		public void InitForm()
		{
			mdiParent.EnableNewCommand(false);
			mdiParent.EnableDeleteCommand(false);
			mdiParent.EnableRefreshCommand(true);
			mdiParent.EnablePrintCommand(false);

			MainMenuNewStatus = false;
			MainMenuDeleteStatus = false;
			MainMenuRefreshStatus = true;
			MainMenuPrintStatus = false;
		}

		public void RefreshForm()
		{
			if(facadePermission.DisplayApplicationUserPermissionList())
			{
				bindTreeview();
			}
			else
			{
				clearForm();
			}
		}

		public void PrintForm()
		{
		}

		public void ExitForm()
		{
//			clearMainMenuStatus();

			Dispose(true);
		}

		public bool SaveChange()
		{
			TreeNode treeNodeModulePermission = (TreeNode)lblModuleName.Tag;
			ModulePermission modulePermission = (ModulePermission)treeNodeModulePermission.Tag;

			TreeNode treeNodeUserProfile = (TreeNode)lblUserName.Tag;
			ApplicationUserPermission userPermission = (ApplicationUserPermission)treeNodeUserProfile.Tag;

			if(modulePermission.Permission != ModulePermission)
			{
				modulePermission.Permission = ModulePermission;

				if(facadePermission.UpdateModulePermission(modulePermission, userPermission.AUser))
				{
					treeNodeModulePermission.ImageIndex = imageIndex(modulePermission.Permission);
					treeNodeModulePermission.SelectedImageIndex = treeNodeModulePermission.ImageIndex;
				}
				else
				{
					errorMessage("ไม่สามารถบันทึกการเปลี่ยนแปลงสิทธิ์ได้\nโปรดตรวจสอบอีกครั้ง");
					return false;
				}
			}

			bool functionPermissionChanged = false;
			for(int i=0; i<fpsFunctionPermission.Rows.Count; i++)
			{
				if(fpsFunctionPermission.Cells[i, 1].Text != modulePermission[i].PermissionString)
				{
					modulePermission[i].PermissionString = fpsFunctionPermission.Cells[i, 1].Text;
					functionPermissionChanged = true;
				}
			}

			if(functionPermissionChanged)
			{
				if(facadePermission.UpdateFunctionPermission(modulePermission, userPermission.AUser))
				{
					for(int i=0; i<modulePermission.Count; i++)
					{
						treeNodeModulePermission.Nodes[i].ImageIndex = imageIndex(modulePermission[i].Permission);
						treeNodeModulePermission.Nodes[i].SelectedImageIndex = treeNodeModulePermission.Nodes[i].ImageIndex;
					}
				}
				else
				{
					errorMessage("ไม่สามารถบันทึกการเปลี่ยนแปลงสิทธิ์ได้\nโปรดตรวจสอบอีกครั้ง");
					return false;
				}
			}

			infoMessage("บันทึกข้อมูลการเปลี่ยนแปลงสิทธิ์เรียบร้อยแล้ว");
			return true;
		}

		private void DeleteEvent()
		{
			try
			{
				if (Message(MessageList.Question.Q0001) == DialogResult.Yes)
				{
					TreeNode treeNodeUserPermission = (TreeNode)lblUserName.Tag;
					ApplicationUserPermission userPermission = (ApplicationUserPermission)treeNodeUserPermission.Tag;

					if(facadePermission.DeleteUserPermission(userPermission))
					{
						treeNodeUserPermission.Remove();
					}
					userPermission = null;
					treeNodeUserPermission = null;	
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

		//============================== event ==============================
		private void frmPermission_Load(object sender, System.EventArgs e)
		{
			mdiParent = (frmMain)this.MdiParent;
			InitForm();
			RefreshForm();
			if(UserProfile.UserROLE == USER_ROLE.USER)
			{
				groupBox1.Enabled = false;
				fpSpread1.Enabled = false;
				btnUpdateChange.Enabled = false;
				btnDeletePermission.Enabled = false;
			}
		}

		private void trvUserPermission_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			switch(e.Node.ImageIndex)
			{
				case 0 :
				case 1 :
				case 2 :
				{
					bindUserProfile(e.Node);
					clearModule();
					break;
				}
				case 3 :
				case 4 :
				{
					bindModule(e.Node);
					bindUserProfile(e.Node.Parent);
					break;
				}
				case 5 :
				case 6 :
				case 7 :
				{
//					bindFunction((FunctionPermission)e.Node.Tag);
					bindModule(e.Node.Parent);
					bindUserProfile(e.Node.Parent.Parent);
					break;
				}
			}	
		}

		private void rdbAccess_CheckedChanged(object sender, System.EventArgs e)
		{
			fpSpread1.Enabled = rdbAccess.Checked;
		}

		private void btnUpdateChange_Click(object sender, System.EventArgs e)
		{
			SaveChange();
		}

		private void btnDeletePermission_Click(object sender, System.EventArgs e)
		{
			DeleteEvent();
		}

	}
}