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
	public class TMPfrmModel : ChildFormBase, IMDIChildForm
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
		private FarPoint.Win.Spread.FpSpread fpsModel;
		private FarPoint.Win.Spread.SheetView fpsModel_Sheet1;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem mniAdd;
		private System.Windows.Forms.MenuItem mniEdit;
		private System.Windows.Forms.MenuItem mniDelete;
		private System.Windows.Forms.Button cmdEdit;
		private System.Windows.Forms.Button cmdAdd;
		private System.Windows.Forms.Button cmdShow;
		private System.Windows.Forms.Button cmdDelete;
		private System.Windows.Forms.ComboBox txtBrandCode;
		private System.ComponentModel.Container components = null;
		private void InitializeComponent()
		{
			FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType5 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType6 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType7 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType8 = new FarPoint.Win.Spread.CellType.TextCellType();
			this.cmdDelete = new System.Windows.Forms.Button();
			this.cmdEdit = new System.Windows.Forms.Button();
			this.cmdAdd = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtBrandCode = new System.Windows.Forms.ComboBox();
			this.cmdShow = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.fpsModel = new FarPoint.Win.Spread.FpSpread();
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.mniAdd = new System.Windows.Forms.MenuItem();
			this.mniEdit = new System.Windows.Forms.MenuItem();
			this.mniDelete = new System.Windows.Forms.MenuItem();
			this.fpsModel_Sheet1 = new FarPoint.Win.Spread.SheetView();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.fpsModel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsModel_Sheet1)).BeginInit();
			this.SuspendLayout();
			// 
			// cmdDelete
			// 
			this.cmdDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdDelete.Location = new System.Drawing.Point(506, 376);
			this.cmdDelete.Name = "cmdDelete";
			this.cmdDelete.TabIndex = 5;
			this.cmdDelete.Text = "ลบ";
			this.cmdDelete.Click += new System.EventHandler(this.cmddelete_Click);
			// 
			// cmdEdit
			// 
			this.cmdEdit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdEdit.Location = new System.Drawing.Point(426, 376);
			this.cmdEdit.Name = "cmdEdit";
			this.cmdEdit.TabIndex = 4;
			this.cmdEdit.Text = "แก้ไข";
			this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
			// 
			// cmdAdd
			// 
			this.cmdAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdAdd.Location = new System.Drawing.Point(346, 376);
			this.cmdAdd.Name = "cmdAdd";
			this.cmdAdd.TabIndex = 3;
			this.cmdAdd.Text = "เพิ่ม";
			this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.groupBox1.Controls.Add(this.txtBrandCode);
			this.groupBox1.Controls.Add(this.cmdShow);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(8, 16);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(904, 64);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			// 
			// txtBrandCode
			// 
			this.txtBrandCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.txtBrandCode.Location = new System.Drawing.Point(64, 24);
			this.txtBrandCode.MaxLength = 50;
			this.txtBrandCode.Name = "txtBrandCode";
			this.txtBrandCode.Size = new System.Drawing.Size(328, 21);
			this.txtBrandCode.TabIndex = 1;
			// 
			// cmdShow
			// 
			this.cmdShow.Location = new System.Drawing.Point(424, 24);
			this.cmdShow.Name = "cmdShow";
			this.cmdShow.TabIndex = 2;
			this.cmdShow.Text = "แสดงข้อมูล";
			this.cmdShow.Click += new System.EventHandler(this.cmdShow_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "ยี่ห้อรถ";
			// 
			// fpsModel
			// 
			this.fpsModel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.fpsModel.ContextMenu = this.contextMenu1;
			this.fpsModel.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
			this.fpsModel.Location = new System.Drawing.Point(19, 96);
			this.fpsModel.Name = "fpsModel";
			this.fpsModel.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
																				  this.fpsModel_Sheet1});
			this.fpsModel.Size = new System.Drawing.Size(885, 264);
			this.fpsModel.TabIndex = 5;
			this.fpsModel.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpsModel_CellDoubleClick);
			// 
			// contextMenu1
			// 
			this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.mniAdd,
																						 this.mniEdit,
																						 this.mniDelete});
			// 
			// mniAdd
			// 
			this.mniAdd.Index = 0;
			this.mniAdd.Text = "เพิ่ม";
			this.mniAdd.Click += new System.EventHandler(this.mniAdd_Click);
			// 
			// mniEdit
			// 
			this.mniEdit.Index = 1;
			this.mniEdit.Text = "แก้ไข";
			this.mniEdit.Click += new System.EventHandler(this.mniEdit_Click);
			// 
			// mniDelete
			// 
			this.mniDelete.Index = 2;
			this.mniDelete.Text = "ลบ";
			this.mniDelete.Click += new System.EventHandler(this.mniDelete_Click);
			// 
			// fpsModel_Sheet1
			// 
			this.fpsModel_Sheet1.Reset();
			// Formulas and custom names must be loaded with R1C1 reference style
			this.fpsModel_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
			this.fpsModel_Sheet1.ColumnCount = 9;
			this.fpsModel_Sheet1.RowCount = 0;
			this.fpsModel_Sheet1.ColumnHeader.Cells.Get(0, 1).Text = "รหัสรุ่น";
			this.fpsModel_Sheet1.ColumnHeader.Cells.Get(0, 2).Text = "ชื่อรุ่น(ภาษาอังกฤษ)";
			this.fpsModel_Sheet1.ColumnHeader.Cells.Get(0, 3).Text = "ประเภทรุ่น";
			this.fpsModel_Sheet1.ColumnHeader.Cells.Get(0, 4).Text = "ประเภทเกียร์";
			this.fpsModel_Sheet1.ColumnHeader.Cells.Get(0, 5).Text = "ประเภทเบรค";
			this.fpsModel_Sheet1.ColumnHeader.Cells.Get(0, 6).Text = "ประเภทเชื้อเพลิง";
			this.fpsModel_Sheet1.ColumnHeader.Cells.Get(0, 7).Text = "ซีซี";
			this.fpsModel_Sheet1.ColumnHeader.Cells.Get(0, 8).Text = "จำนวนที่นั่ง";
			textCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType1.DropDownButton = false;
			this.fpsModel_Sheet1.Columns.Get(0).CellType = textCellType1;
			this.fpsModel_Sheet1.Columns.Get(0).Visible = false;
			this.fpsModel_Sheet1.Columns.Get(1).AllowAutoSort = true;
			textCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType2.DropDownButton = false;
			this.fpsModel_Sheet1.Columns.Get(1).CellType = textCellType2;
			this.fpsModel_Sheet1.Columns.Get(1).Label = "รหัสรุ่น";
			this.fpsModel_Sheet1.Columns.Get(1).Resizable = false;
			this.fpsModel_Sheet1.Columns.Get(1).Width = 80F;
			this.fpsModel_Sheet1.Columns.Get(2).AllowAutoSort = true;
			textCellType3.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType3.DropDownButton = false;
			this.fpsModel_Sheet1.Columns.Get(2).CellType = textCellType3;
			this.fpsModel_Sheet1.Columns.Get(2).Label = "ชื่อรุ่น(ภาษาอังกฤษ)";
			this.fpsModel_Sheet1.Columns.Get(2).Resizable = false;
			this.fpsModel_Sheet1.Columns.Get(2).Width = 224F;
			this.fpsModel_Sheet1.Columns.Get(3).AllowAutoSort = true;
			this.fpsModel_Sheet1.Columns.Get(3).Label = "ประเภทรุ่น";
			this.fpsModel_Sheet1.Columns.Get(3).Resizable = false;
			this.fpsModel_Sheet1.Columns.Get(3).Width = 100F;
			this.fpsModel_Sheet1.Columns.Get(4).AllowAutoSort = true;
			textCellType4.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType4.DropDownButton = false;
			this.fpsModel_Sheet1.Columns.Get(4).CellType = textCellType4;
			this.fpsModel_Sheet1.Columns.Get(4).Label = "ประเภทเกียร์";
			this.fpsModel_Sheet1.Columns.Get(4).Resizable = false;
			this.fpsModel_Sheet1.Columns.Get(4).Width = 100F;
			this.fpsModel_Sheet1.Columns.Get(5).AllowAutoSort = true;
			textCellType5.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType5.DropDownButton = false;
			this.fpsModel_Sheet1.Columns.Get(5).CellType = textCellType5;
			this.fpsModel_Sheet1.Columns.Get(5).Label = "ประเภทเบรค";
			this.fpsModel_Sheet1.Columns.Get(5).Resizable = false;
			this.fpsModel_Sheet1.Columns.Get(5).Width = 100F;
			this.fpsModel_Sheet1.Columns.Get(6).AllowAutoSort = true;
			textCellType6.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType6.DropDownButton = false;
			this.fpsModel_Sheet1.Columns.Get(6).CellType = textCellType6;
			this.fpsModel_Sheet1.Columns.Get(6).Label = "ประเภทเชื้อเพลิง";
			this.fpsModel_Sheet1.Columns.Get(6).Resizable = false;
			this.fpsModel_Sheet1.Columns.Get(6).Width = 100F;
			this.fpsModel_Sheet1.Columns.Get(7).AllowAutoSort = true;
			textCellType7.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType7.DropDownButton = false;
			this.fpsModel_Sheet1.Columns.Get(7).CellType = textCellType7;
			this.fpsModel_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
			this.fpsModel_Sheet1.Columns.Get(7).Label = "ซีซี";
			this.fpsModel_Sheet1.Columns.Get(7).Locked = false;
			this.fpsModel_Sheet1.Columns.Get(7).Resizable = false;
			this.fpsModel_Sheet1.Columns.Get(8).AllowAutoSort = true;
			textCellType8.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType8.DropDownButton = false;
			this.fpsModel_Sheet1.Columns.Get(8).CellType = textCellType8;
			this.fpsModel_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
			this.fpsModel_Sheet1.Columns.Get(8).Label = "จำนวนที่นั่ง";
			this.fpsModel_Sheet1.Columns.Get(8).Resizable = false;
			this.fpsModel_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
			this.fpsModel_Sheet1.RowHeader.Columns.Default.Resizable = false;
			this.fpsModel_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
			this.fpsModel_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
			this.fpsModel_Sheet1.SheetName = "Sheet1";
			this.fpsModel_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
			// 
            // TMPfrmModel
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(922, 422);
			this.Controls.Add(this.cmdEdit);
			this.Controls.Add(this.cmdAdd);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.fpsModel);
			this.Controls.Add(this.cmdDelete);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "TMPfrmModel";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "ข้อมูลรุ่นรถ";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TMPfrmModel_Load);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.fpsModel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsModel_Sheet1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region - Private -
		private bool isReadonly = true;
		private TMPfrmModelEntry frmEntry;
		private frmMain mdiParent;

		private int SelectedRow
		{
			get
			{
				return fpsModel_Sheet1.ActiveRowIndex;
			}
		}

		private string SelectedKey
		{
			get
			{
				return fpsModel_Sheet1.Cells[SelectedRow,0].Text;
			}
		}

		private Model SelectedModel
		{
			get
			{
				return facadeModel.AModelList[SelectedKey];
			}
		}
		#endregion

//		============================== Property ==============================
		private ModelFacade facadeModel;
		public ModelFacade FacadeModel
		{
			get
			{
				return facadeModel;
			}
		}

		public Brand Brand
		{
			get
			{
				return facadeModel.AModelList.ABrand;
			}
		}

//		============================== Constructor ==============================
		public TMPfrmModel(): base()
		{
			InitializeComponent();
			newObject();
			isReadonly = UserProfile.IsReadOnly("miVehicle", "miVehicleVehicleModel");
            this.title = UserProfile.GetFormName("miVehicle", "miVehicleVehicleModel");


			try
			{						
				txtBrandCode.DataSource = facadeModel.DataSourceBrand;
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
			}
		}
        public override string FormID()
        {
            return UserProfile.GetFormID("miVehicle", "miVehicleVehicleModel");
        }
		private void newObject()
		{
			facadeModel = new ModelFacade();
			frmEntry = new TMPfrmModelEntry(this);
		}
		
		//		==============================Private method ==============================
		private void bindModel(int row,Model aModel)
		{
			fpsModel_Sheet1.Cells[row,0].Text = aModel.EntityKey;
			fpsModel_Sheet1.Cells[row,1].Text = aModel.Code;
			fpsModel_Sheet1.Cells[row,2].Text = GUIFunction.GetString(aModel.AName.English);
			fpsModel_Sheet1.Cells[row,3].Text = GUIFunction.GetString(aModel.AModelType.AName.Thai);
			fpsModel_Sheet1.Cells[row,4].Text = GUIFunction.GetString(aModel.GearType);
			fpsModel_Sheet1.Cells[row,5].Text = GUIFunction.GetString(aModel.BreakType);
			fpsModel_Sheet1.Cells[row,6].Text = GUIFunction.GetString(aModel.AGasolineType.AName.Thai);
			fpsModel_Sheet1.Cells[row,7].Text = GUIFunction.GetString(aModel.EngineCC);
			fpsModel_Sheet1.Cells[row,8].Text = GUIFunction.GetString(aModel.NoOfSeat);
		}

		private void bindForm()
		{
			int ModelCount = facadeModel.AModelList.Count;
			if (ModelCount>0)
			{
				fpsModel_Sheet1.RowCount = ModelCount;
				for(int i=0; i<ModelCount; i++)
				{
					bindModel(i,facadeModel.AModelList[i]);
				}
				mdiParent.RefreshMasterCount();
                fpsModel_Sheet1.SetActiveCell(fpsModel_Sheet1.RowCount, 0);
			}
			else
			{
				clearForm();			
			}
		}

		private void enableButton1(bool enable)
		{
			mniEdit.Enabled = enable;
			cmdEdit.Enabled = enable;
			mniDelete.Enabled = enable;
			cmdDelete.Enabled = enable;
		}
		private void enableButton2(bool enable)
		{
			cmdAdd.Enabled = enable;
			mniAdd.Enabled = enable;
		}

		private void enableButtonAll(bool enable)
		{
			enableButton1(enable);
			enableButton2(enable);
		}
		private void clearForm()
		{	
			fpsModel_Sheet1.RowCount = 0;
			enableButton1(false);	
		}
		private void InitCombo()
		{
			txtBrandCode.SelectedIndex = -1;
			txtBrandCode.Text = "";
		}
		private void hideCase()
		{				
			fpsModel.Hide();		
			cmdAdd.Hide();
			cmdEdit.Hide();
			cmdDelete.Hide();
			InitCombo();
		}
		private void showCase()
		{						
			fpsModel.Show();		
			cmdAdd.Show();
			cmdEdit.Show();
			cmdDelete.Show();
		}
		private void enableCase(bool enable)
		{
			txtBrandCode.Enabled = enable;
			cmdShow.Enabled = enable;
		}
//		==========================Public Method========================
		public bool AddRow(Model aModel)
		{
            //if (facadeModel.InsertModel(aModel))
            //{
            //    fpsModel_Sheet1.RowCount++;
            //    bindModel(fpsModel_Sheet1.RowCount-1,aModel);
            //    fpsModel_Sheet1.SetActiveCell(fpsModel_Sheet1.RowCount, 0);
            //    enableButton1(true);
            //    mdiParent.RefreshMasterCount();
            //return true;
            //}
            //else
            //{				
            //    return false;
            //}
            return true;
		}

		public bool UpdateRow(Model aModel)
		{
            //if (facadeModel.UpdateModel(aModel))
            //{
            //    bindModel(SelectedRow, aModel);				
            //    return true;
            //}
            //else
            //{				
            //    return false;
            //}
            return true;
		}
		private void DeleteRow()
		{
			if (facadeModel.DeleteModel(SelectedModel))
			{
				if(fpsModel_Sheet1.RowCount > 1)
				{
					fpsModel.ActiveSheet.Rows.Remove(SelectedRow,1);
				}
				else
				{
					clearForm();
				}		
				mdiParent.RefreshMasterCount();
			}
		}
//		==============================Public method ==============================
		public override int MasterCount()
		{
			return facadeModel.AModelList.Count;
		}


//		============================== Base Event ==============================
		public void InitForm()
		{	
			mdiParent.EnableNewCommand(false);
			mdiParent.EnableDeleteCommand(false);
			mdiParent.EnableRefreshCommand(false);
			mdiParent.EnablePrintCommand(false);
			clearMainMenuStatus();

            newObject();
			mdiParent.RefreshMasterCount();
			
			enableCase(true);
			clearForm();
			hideCase();
			enableButtonAll(true);
			InitCombo();
		
		}

		public void RefreshForm()
		{
			mdiParent.EnableNewCommand(true);
			mdiParent.EnableDeleteCommand(false);
			mdiParent.EnableRefreshCommand(true);
			mdiParent.EnablePrintCommand(true);
			MainMenuNewStatus = true;
			MainMenuDeleteStatus = false;
			MainMenuRefreshStatus = true;
			MainMenuPrintStatus = true;

			Brand cboItem = (Brand)txtBrandCode.SelectedItem;
			try
			{						
				if (facadeModel.DisplayModel(cboItem.Code))
				{			
					enableButtonAll(true);
					
				}
				else
				{
					clearForm();
					enableButton2(true);
				}
				enableCase(false);
				showCase();
				bindForm();
			}
			catch(SqlException sqlex)
			{
				Message(sqlex);
			}
			catch(AppExceptionBase ex)
			{
				Message(ex);
				hideCase();
				enableCase(true);
			}
			catch(Exception ex)
			{
				Message(ex);
			}
			finally
			{
			}

			if(isReadonly)
			{
				cmdAdd.Enabled = false;
				mniAdd.Enabled = false;
				cmdDelete.Enabled = false;
				mniDelete.Enabled = false;
			}
		}

		public void PrintForm()
		{
		}

		public void ExitForm()
		{
			Dispose(true);
		}

		private void AddEvent()
		{
			try
			{
				frmEntry = new TMPfrmModelEntry(this);
				frmEntry.InitAddAction();
				frmEntry.ShowDialog();
				
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
			}
		}

		private void EditEvent()
		{
			try
			{
				frmEntry = new TMPfrmModelEntry(this);
				frmEntry.InitEditAction(SelectedModel);
				frmEntry.ThaiModelName();
				frmEntry.ShowDialog();				
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
			}
		}
		private void DeleteEvent()
		{
			try
			{
				if (Message(MessageList.Question.Q0001) == DialogResult.Yes)
				{
					DeleteRow();
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
			}
		}
//		==============================Event ==============================
		private void fpsModel_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
		{
			if(!e.ColumnHeader)
			{
				EditEvent();
			}
		}

		private void mniDelete_Click(object sender, System.EventArgs e)
		{
			DeleteEvent();
		}

		private void mniEdit_Click(object sender, System.EventArgs e)
		{
			EditEvent();
		}

		private void mniAdd_Click(object sender, System.EventArgs e)
		{
			AddEvent();
		}

		private void cmddelete_Click(object sender, System.EventArgs e)
		{
			DeleteEvent();
		}

		private void cmdAdd_Click(object sender, System.EventArgs e)
		{
			AddEvent();
		}

		private void cmdEdit_Click(object sender, System.EventArgs e)
		{
			EditEvent();
		}

        private void TMPfrmModel_Load(object sender, System.EventArgs e)
		{
			mdiParent = (frmMain)this.MdiParent;
			InitForm();
		}

		private void cmdShow_Click(object sender, System.EventArgs e)
		{
			if (txtBrandCode.Text == "")
			{
				Message(MessageList.Error.E0005, "ยี่ห้อรถ");
				txtBrandCode.Focus();	

			}
			else
			{
				RefreshForm();			
			}		
		}
	}
}
