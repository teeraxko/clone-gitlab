using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;

using SystemFramework.AppMessage;
using SystemFramework.AppException;
using SystemFramework.AppConfig;

using Entity.CommonEntity;
using Entity.ContractEntities;
using Entity.VehicleEntities;

using Facade.CommonFacade;
using Facade.ContractFacade;

using Presentation.CommonGUI;

using ictus.Common.Entity.General;
using System.Collections.Generic;

namespace Presentation.ContractGUI
{
	public class frmVDContractMatch : ChildFormBase, IMDIChildForm
	{
		#region Windows Form Designer generated code
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
                    objVehicleContract = null;
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		private FarPoint.Win.Spread.FpSpread fpsVehicleDriver;
		private FarPoint.Win.Spread.SheetView fpsVehicleDriver_Sheet1;
		private System.Windows.Forms.Button cmdAdd;
		private System.Windows.Forms.Button cmdEdit;
		private System.Windows.Forms.Button cmdDelete;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem mniAdd;
		private System.Windows.Forms.MenuItem mniEdit;
		private System.Windows.Forms.MenuItem mniDelete;
		private System.Windows.Forms.GroupBox gpbRetriveContract;
		private System.Windows.Forms.TextBox txtDocumentType;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.ComboBox cboContractType;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.ComboBox cboCustomerTHName;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.TextBox txtContractNoXXX;
		private System.Windows.Forms.TextBox txtContractNoMM;
		private System.Windows.Forms.TextBox txtContractNoYY;
		private System.Windows.Forms.ComboBox cboContractStatus;
        private System.Windows.Forms.ComboBox cboVehicleKindContract;
		private System.ComponentModel.Container components = null;
		private void InitializeComponent()
		{
			FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
			this.fpsVehicleDriver = new FarPoint.Win.Spread.FpSpread();
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.mniAdd = new System.Windows.Forms.MenuItem();
			this.mniEdit = new System.Windows.Forms.MenuItem();
			this.mniDelete = new System.Windows.Forms.MenuItem();
			this.fpsVehicleDriver_Sheet1 = new FarPoint.Win.Spread.SheetView();
			this.cmdAdd = new System.Windows.Forms.Button();
			this.cmdEdit = new System.Windows.Forms.Button();
			this.cmdDelete = new System.Windows.Forms.Button();
			this.gpbRetriveContract = new System.Windows.Forms.GroupBox();
            this.cboVehicleKindContract = new System.Windows.Forms.ComboBox();
			this.txtContractNoXXX = new System.Windows.Forms.TextBox();
			this.txtContractNoMM = new System.Windows.Forms.TextBox();
			this.txtContractNoYY = new System.Windows.Forms.TextBox();
			this.txtDocumentType = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
			this.label23 = new System.Windows.Forms.Label();
			this.label25 = new System.Windows.Forms.Label();
			this.cboContractStatus = new System.Windows.Forms.ComboBox();
			this.label26 = new System.Windows.Forms.Label();
			this.cboContractType = new System.Windows.Forms.ComboBox();
			this.label27 = new System.Windows.Forms.Label();
			this.label28 = new System.Windows.Forms.Label();
			this.cboCustomerTHName = new System.Windows.Forms.ComboBox();
			this.label29 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.fpsVehicleDriver)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsVehicleDriver_Sheet1)).BeginInit();
			this.gpbRetriveContract.SuspendLayout();
			this.SuspendLayout();
			// 
			// fpsVehicleDriver
			// 
			this.fpsVehicleDriver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.fpsVehicleDriver.ContextMenu = this.contextMenu1;
			this.fpsVehicleDriver.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
			this.fpsVehicleDriver.Location = new System.Drawing.Point(177, 144);
			this.fpsVehicleDriver.Name = "fpsVehicleDriver";
			this.fpsVehicleDriver.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
																						  this.fpsVehicleDriver_Sheet1});
			this.fpsVehicleDriver.Size = new System.Drawing.Size(497, 304);
			this.fpsVehicleDriver.TabIndex = 30;
			this.fpsVehicleDriver.SelectionChanged += new FarPoint.Win.Spread.SelectionChangedEventHandler(this.fpsVehicleDriver_SelectionChanged);
			this.fpsVehicleDriver.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpsVehicleDriver_CellDoubleClick);
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
			this.mniAdd.Text = "จับคู่";
			this.mniAdd.Click += new System.EventHandler(this.mniAdd_Click);
			// 
			// mniEdit
			// 
			this.mniEdit.Index = 1;
			this.mniEdit.Text = "แก้ไขการจับคู่";
			this.mniEdit.Click += new System.EventHandler(this.mniEdit_Click);
			// 
			// mniDelete
			// 
			this.mniDelete.Index = 2;
			this.mniDelete.Text = "ลบการจับคู่";
			this.mniDelete.Click += new System.EventHandler(this.mniDelete_Click);
			// 
			// fpsVehicleDriver_Sheet1
			// 
			this.fpsVehicleDriver_Sheet1.Reset();
			// Formulas and custom names must be loaded with R1C1 reference style
			this.fpsVehicleDriver_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
			this.fpsVehicleDriver_Sheet1.ColumnCount = 4;
			this.fpsVehicleDriver_Sheet1.RowCount = 1;
			this.fpsVehicleDriver_Sheet1.ColumnHeader.Cells.Get(0, 1).Text = "สถานะสัญญารถ";
			this.fpsVehicleDriver_Sheet1.ColumnHeader.Cells.Get(0, 2).Text = "เลขที่สัญญาสำหรับรถ";
			this.fpsVehicleDriver_Sheet1.ColumnHeader.Cells.Get(0, 3).Text = "เลขที่สัญญาสำหรับพนักงานขับรถ";
			textCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType1.DropDownButton = false;
			this.fpsVehicleDriver_Sheet1.Columns.Get(0).CellType = textCellType1;
			this.fpsVehicleDriver_Sheet1.Columns.Get(0).Visible = false;
			this.fpsVehicleDriver_Sheet1.Columns.Get(1).AllowAutoSort = true;
			textCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType2.DropDownButton = false;
			this.fpsVehicleDriver_Sheet1.Columns.Get(1).CellType = textCellType2;
			this.fpsVehicleDriver_Sheet1.Columns.Get(1).Label = "สถานะสัญญารถ";
			this.fpsVehicleDriver_Sheet1.Columns.Get(1).Resizable = false;
			this.fpsVehicleDriver_Sheet1.Columns.Get(1).Width = 96F;
			this.fpsVehicleDriver_Sheet1.Columns.Get(2).AllowAutoSort = true;
			textCellType3.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType3.DropDownButton = false;
			this.fpsVehicleDriver_Sheet1.Columns.Get(2).CellType = textCellType3;
			this.fpsVehicleDriver_Sheet1.Columns.Get(2).Label = "เลขที่สัญญาสำหรับรถ";
			this.fpsVehicleDriver_Sheet1.Columns.Get(2).Resizable = false;
			this.fpsVehicleDriver_Sheet1.Columns.Get(2).Width = 165F;
			this.fpsVehicleDriver_Sheet1.Columns.Get(3).AllowAutoSort = true;
			textCellType4.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType4.DropDownButton = false;
			this.fpsVehicleDriver_Sheet1.Columns.Get(3).CellType = textCellType4;
			this.fpsVehicleDriver_Sheet1.Columns.Get(3).Label = "เลขที่สัญญาสำหรับพนักงานขับรถ";
			this.fpsVehicleDriver_Sheet1.Columns.Get(3).Resizable = false;
			this.fpsVehicleDriver_Sheet1.Columns.Get(3).Width = 180F;
			this.fpsVehicleDriver_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
			this.fpsVehicleDriver_Sheet1.RowHeader.Columns.Default.Resizable = false;
			this.fpsVehicleDriver_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
			this.fpsVehicleDriver_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
			this.fpsVehicleDriver_Sheet1.SheetName = "Sheet1";
			this.fpsVehicleDriver_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
			// 
			// cmdAdd
			// 
			this.cmdAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdAdd.Enabled = false;
			this.cmdAdd.Location = new System.Drawing.Point(304, 471);
			this.cmdAdd.Name = "cmdAdd";
			this.cmdAdd.TabIndex = 31;
			this.cmdAdd.Text = "จับคู่";
			this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
			// 
			// cmdEdit
			// 
			this.cmdEdit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdEdit.Enabled = false;
			this.cmdEdit.Location = new System.Drawing.Point(384, 471);
			this.cmdEdit.Name = "cmdEdit";
			this.cmdEdit.TabIndex = 32;
			this.cmdEdit.Text = "แก้ไขการจับคู่";
			this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
			// 
			// cmdDelete
			// 
			this.cmdDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdDelete.Enabled = false;
			this.cmdDelete.Location = new System.Drawing.Point(464, 471);
			this.cmdDelete.Name = "cmdDelete";
			this.cmdDelete.TabIndex = 33;
			this.cmdDelete.Text = "ลบการจับคู่";
			this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
			// 
			// gpbRetriveContract
			// 
			this.gpbRetriveContract.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gpbRetriveContract.Controls.Add(this.cboVehicleKindContract);
			this.gpbRetriveContract.Controls.Add(this.txtContractNoXXX);
			this.gpbRetriveContract.Controls.Add(this.txtContractNoMM);
			this.gpbRetriveContract.Controls.Add(this.txtContractNoYY);
			this.gpbRetriveContract.Controls.Add(this.txtDocumentType);
			this.gpbRetriveContract.Controls.Add(this.label12);
			this.gpbRetriveContract.Controls.Add(this.label15);
			this.gpbRetriveContract.Controls.Add(this.label22);
			this.gpbRetriveContract.Controls.Add(this.label23);
			this.gpbRetriveContract.Controls.Add(this.label25);
			this.gpbRetriveContract.Controls.Add(this.cboContractStatus);
			this.gpbRetriveContract.Controls.Add(this.label26);
			this.gpbRetriveContract.Controls.Add(this.cboContractType);
			this.gpbRetriveContract.Controls.Add(this.label27);
			this.gpbRetriveContract.Controls.Add(this.label28);
			this.gpbRetriveContract.Controls.Add(this.cboCustomerTHName);
			this.gpbRetriveContract.Controls.Add(this.label29);
			this.gpbRetriveContract.Location = new System.Drawing.Point(45, 16);
			this.gpbRetriveContract.Name = "gpbRetriveContract";
			this.gpbRetriveContract.Size = new System.Drawing.Size(760, 104);
			this.gpbRetriveContract.TabIndex = 88;
			this.gpbRetriveContract.TabStop = false;
			this.gpbRetriveContract.Text = "เรียกดูสัญญาตามเงื่อนไข";
            // 
            // cboVehicleKindContract
            // 
            this.cboVehicleKindContract.DropDownHeight = 105;
            this.cboVehicleKindContract.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVehicleKindContract.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cboVehicleKindContract.FormattingEnabled = true;
            this.cboVehicleKindContract.IntegralHeight = false;
            this.cboVehicleKindContract.Location = new System.Drawing.Point(544, 54);
            this.cboVehicleKindContract.Name = "cboVehicleKindContract";
            this.cboVehicleKindContract.Size = new System.Drawing.Size(34, 21);
            this.cboVehicleKindContract.TabIndex = 89;
            this.cboVehicleKindContract.SelectedIndexChanged += new System.EventHandler(this.cboVehicleKindContract_SelectedIndexChanged);
			// 
			// txtContractNoXXX
			// 
            this.txtContractNoXXX.Location = new System.Drawing.Point(662, 54);
			this.txtContractNoXXX.MaxLength = 3;
			this.txtContractNoXXX.Name = "txtContractNoXXX";
			this.txtContractNoXXX.Size = new System.Drawing.Size(40, 20);
			this.txtContractNoXXX.TabIndex = 106;
			this.txtContractNoXXX.Text = "";
			this.txtContractNoXXX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtContractNoXXX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtContractNoXXX_KeyDown);
			this.txtContractNoXXX.TextChanged += new System.EventHandler(this.txtContractNoXXX_TextChanged);
			this.txtContractNoXXX.DoubleClick += new System.EventHandler(this.txtContractNoXXX_DoubleClick);
			// 
			// txtContractNoMM
			// 
            this.txtContractNoMM.Location = new System.Drawing.Point(630, 54);
			this.txtContractNoMM.MaxLength = 2;
			this.txtContractNoMM.Name = "txtContractNoMM";
			this.txtContractNoMM.Size = new System.Drawing.Size(32, 20);
			this.txtContractNoMM.TabIndex = 105;
			this.txtContractNoMM.Text = "";
			this.txtContractNoMM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtContractNoMM.TextChanged += new System.EventHandler(this.txtContractNoMM_TextChanged);
			// 
			// txtContractNoYY
			// 
            this.txtContractNoYY.Location = new System.Drawing.Point(598, 54);
			this.txtContractNoYY.MaxLength = 2;
			this.txtContractNoYY.Name = "txtContractNoYY";
			this.txtContractNoYY.Size = new System.Drawing.Size(32, 20);
			this.txtContractNoYY.TabIndex = 104;
			this.txtContractNoYY.Text = "";
			this.txtContractNoYY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtContractNoYY.TextChanged += new System.EventHandler(this.txtContractNoYY_TextChanged);
			// 
			// txtDocumentType
			// 
			this.txtDocumentType.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.txtDocumentType.Enabled = false;
			this.txtDocumentType.Location = new System.Drawing.Point(544, 56);
			this.txtDocumentType.MaxLength = 1;
			this.txtDocumentType.Name = "txtDocumentType";
			this.txtDocumentType.Size = new System.Drawing.Size(24, 20);
			this.txtDocumentType.TabIndex = 91;
			this.txtDocumentType.Text = "C";
			this.txtDocumentType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label12
			// 
			this.label12.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
            this.label12.Location = new System.Drawing.Point(577, 56);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(14, 23);
			this.label12.TabIndex = 103;
			this.label12.Text = "-";
			// 
			// label15
			// 
			this.label15.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label15.Location = new System.Drawing.Point(678, 76);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(32, 16);
			this.label15.TabIndex = 102;
			this.label15.Text = "XXX";
			// 
			// label22
			// 
			this.label22.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label22.Location = new System.Drawing.Point(638, 76);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(24, 16);
			this.label22.TabIndex = 101;
			this.label22.Text = "MM";
			// 
			// label23
			// 
			this.label23.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label23.Location = new System.Drawing.Point(606, 76);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(24, 16);
			this.label23.TabIndex = 100;
			this.label23.Text = "YY";
			// 
			// label25
			// 
			this.label25.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.label25.Location = new System.Drawing.Point(504, 56);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(40, 23);
			this.label25.TabIndex = 99;
            this.label25.Text = "PTB  - "; 
			// 
			// cboContractStatus
			// 
			this.cboContractStatus.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.cboContractStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboContractStatus.Location = new System.Drawing.Point(96, 56);
			this.cboContractStatus.Name = "cboContractStatus";
			this.cboContractStatus.Size = new System.Drawing.Size(240, 21);
			this.cboContractStatus.TabIndex = 90;
			// 
			// label26
			// 
			this.label26.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label26.Location = new System.Drawing.Point(392, 56);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(96, 23);
			this.label26.TabIndex = 98;
			this.label26.Text = "เลขที่สัญญาสำหรับรถ";
			// 
			// cboContractType
			// 			
			this.cboContractType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboContractType.Location = new System.Drawing.Point(504, 24);
			this.cboContractType.Name = "cboContractType";
			this.cboContractType.Size = new System.Drawing.Size(240, 21);
			this.cboContractType.TabIndex = 89;
            this.cboContractType.SelectedIndexChanged += new System.EventHandler(this.cboContractType_SelectedIndexChanged);
			// 
			// label27
			// 
			this.label27.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label27.Location = new System.Drawing.Point(424, 24);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(72, 23);
			this.label27.TabIndex = 97;
			this.label27.Text = "ประเภทสัญญา";
			// 
			// label28
			// 
			this.label28.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label28.Location = new System.Drawing.Point(16, 56);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(64, 23);
			this.label28.TabIndex = 96;
			this.label28.Text = "สถานะสัญญา";
			// 
			// cboCustomerTHName
			// 
			this.cboCustomerTHName.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.cboCustomerTHName.DisplayMember = "sss";
			this.cboCustomerTHName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboCustomerTHName.Location = new System.Drawing.Point(96, 24);
			this.cboCustomerTHName.Name = "cboCustomerTHName";
			this.cboCustomerTHName.Size = new System.Drawing.Size(312, 21);
			this.cboCustomerTHName.TabIndex = 88;
			// 
			// label29
			// 
			this.label29.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label29.Location = new System.Drawing.Point(16, 24);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(40, 23);
			this.label29.TabIndex = 95;
			this.label29.Text = "ชื่อลูกค้า";
			// 
			// frmVDContractMatch
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(850, 511);
			this.Controls.Add(this.cmdDelete);
			this.Controls.Add(this.cmdEdit);
			this.Controls.Add(this.cmdAdd);
			this.Controls.Add(this.fpsVehicleDriver);
			this.Controls.Add(this.gpbRetriveContract);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "frmVDContractMatch";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            //this.Text = "ข้อมูลการจับคู่รถและพนักงานขับรถ";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmVDContractMatch_Load);
			((System.ComponentModel.ISupportInitialize)(this.fpsVehicleDriver)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsVehicleDriver_Sheet1)).EndInit();
			this.gpbRetriveContract.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region - private -
		private bool isReadonly = true;
		private bool isEventTextChanged = true;
		private frmVDContractMatchingEntry frmEntry;
		private frmMain mdiParent;
		private DocumentNo objDocumentNo;
		private VehicleContract objVehicleContract;

		private int SelectedRow
		{
			get{return fpsVehicleDriver_Sheet1.ActiveRowIndex;}
		}

		private string SelectedContractBaseKey
		{
			get
			{
				if(fpsVehicleDriver_Sheet1.Cells[SelectedRow,3].Text != "")
				{
					objDocumentNo = new DocumentNo(fpsVehicleDriver_Sheet1.Cells[SelectedRow,3].Text);
				}
				return fpsVehicleDriver_Sheet1.Cells[SelectedRow,0].Text;
			}
		}

		private ContractBase SelectedContractBase
		{
			get{return facadeVDContractMatch.ObjContractList[SelectedContractBaseKey];}
		}

		#endregion

//		============================== Property ==============================
		private VDContractMatchFacade facadeVDContractMatch;	
		public VDContractMatchFacade FacadeVDContractMatch
		{
			get{return facadeVDContractMatch;}
		}

        //D21018-BTS Contract Modification
        private DOCUMENT_TYPE _documentType = DOCUMENT_TYPE.CONTRACT;
        private DOCUMENT_TYPE DocumentType
        {
            get
            {
                return this._documentType;
            }
            set
            {
                this._documentType = value;
            }
        }

        private DocumentNo getContractNo()
		{
            //D21018 จับคู่สัญญารถยนต์กับสัญญาพนักงานขับรถ
            DocumentNo contractNo = new DocumentNo(_documentType, txtContractNoYY.Text, txtContractNoMM.Text, txtContractNoXXX.Text);
            return contractNo;
		}

		private void setContractBase(ContractBase value)
		{	
			isEventTextChanged = false;
            cboCustomerTHName.Text = value.ACustomerDepartment.ACustomer.ToString();
			cboContractType.Text = GUIFunction.GetString(value.AContractType);
			cboContractStatus.Text = GUIFunction.GetString(value.AContractStatus);
			txtContractNoYY.Text = value.ContractNo.Year;
			txtContractNoMM.Text = value.ContractNo.Month;
			txtContractNoXXX.Text = value.ContractNo.No;	
			isEventTextChanged = true;
		}

//		============================== Constructor ==============================
		public frmVDContractMatch(): base()
		{
			InitializeComponent();
			newObject();
			isReadonly = UserProfile.IsReadOnly("miContract", "miContractDocumentVDContractMatching");
            this.title = UserProfile.GetFormName("miContract", "miContractDocumentVDContractMatching");

			try
			{					
				cboCustomerTHName.DataSource = facadeVDContractMatch.DataSourceCustomer;
				cboContractStatus.DataSource = facadeVDContractMatch.DataSourceContractAvailableStatus;
				//cboContractType.DataSource = facadeVDContractMatch.DataSourceContractTypeAvailable;
                cboContractType.DataSource = facadeVDContractMatch.DataSourceContractType;
			}
			catch(AppExceptionBase ex)
			{Message(ex);}
			catch(Exception ex)
			{Message(ex);}
			finally
			{}
		}
        public override string FormID()
        {
            return UserProfile.GetFormID("miContract", "miContractDocumentVDContractMatching");
        }

//		============================== Private Method ==============================
		private void newObject()
		{			
            //D21018 - ส่ง document type ไปยัง facade
            //facadeVDContractMatch = new VDContractMatchFacade();
            facadeVDContractMatch = new VDContractMatchFacade(this.DocumentType);
            frmEntry = new frmVDContractMatchingEntry(this);
            objVehicleContract = new VehicleContract(facadeVDContractMatch.GetCompany());
            //objDocumentNo = new DocumentNo(DOCUMENT_TYPE.CONTRACT, NullConstant.STRING, NullConstant.STRING, NullConstant.STRING);
            objDocumentNo = new DocumentNo(this.DocumentType, NullConstant.STRING, NullConstant.STRING, NullConstant.STRING);
		}

		private void bindVDContractMatch(int row, VehicleContract value)
		{
			fpsVehicleDriver_Sheet1.Cells[row,0].Text = GUIFunction.GetString(value.EntityKey);
			fpsVehicleDriver_Sheet1.Cells[row,1].Text = GUIFunction.GetString(value.AContractStatus);
			fpsVehicleDriver_Sheet1.Cells[row,2].Text = GUIFunction.GetString(value.ContractNo.ToString());

			if(value.ADriverContract != null && value.ADriverContract.ContractNo != null && value.ADriverContract.ContractNo.ToString() != "")
			{
				fpsVehicleDriver_Sheet1.Cells[row,3].Text = GUIFunction.GetString(value.ADriverContract.ContractNo.ToString());
			}
		}
		
		private void bindForm()
		{
			if (facadeVDContractMatch.ObjContractList != null)
			{
				int iRowCount = facadeVDContractMatch.ObjContractList.Count;
				fpsVehicleDriver_Sheet1.RowCount = iRowCount;
				for(int i=0; i<iRowCount; i++)
				{
					bindVDContractMatch(i, (VehicleContract)facadeVDContractMatch.ObjContractList[i]);
				}		
				mdiParent.RefreshMasterCount();
			}
		}

		private void enableContext(bool enable)
		{
			mniAdd.Enabled = enable;
			cmdAdd.Enabled = enable;
			mniEdit.Enabled = enable;
			cmdEdit.Enabled = enable;
			mniDelete.Enabled = enable;
			cmdDelete.Enabled = enable;
		}

		private void clearForm()
		{
			fpsVehicleDriver_Sheet1.RowCount = 0;
			enableContext(false);
			cboContractType.Enabled = false;
			txtContractNoYY.Text = "";
			txtContractNoMM.Text = "";
			txtContractNoXXX.Text = "";
            //cboContractStatus.SelectedIndex = -1;
            //cboContractStatus.SelectedIndex = -1;
			cboContractStatus.Text = "";
		}

		private void setForm()
		{
			fpsVehicleDriver_Sheet1.RowCount = 0;
			enableContext(false);
			cboContractType.Enabled = false;	
		}

		private void hideCase()
		{
			fpsVehicleDriver.Hide();
			cmdAdd.Hide();
			cmdDelete.Hide();
			cmdEdit.Hide();
			enableContext(false);
			gpbRetriveContract.Enabled = true;
		}

		private void showCase()
		{
			fpsVehicleDriver.Show();
			cmdAdd.Show();
			cmdDelete.Show();
			cmdEdit.Show();
			enableContext(false);
			gpbRetriveContract.Enabled = false;
			RefreshForm();
		}

		private void disableButtonMatch()
		{
			cmdAdd.Enabled = true;
			cmdEdit.Enabled = false;
			cmdDelete.Enabled = false;

			mniAdd.Enabled = true;
			mniEdit.Enabled = false;
			mniDelete.Enabled = false;
		}

		private void eableButtonMatch()
		{
			cmdAdd.Enabled = false;
			cmdEdit.Enabled = true;
			cmdDelete.Enabled = true;

			mniAdd.Enabled = false;
			mniEdit.Enabled = true;
			mniDelete.Enabled = true;
		}

		#region - Validate Input -
		private bool validateForm()
		{
			if(validateInputContractNo() && validateRetriveContract())
			{return true;}
			else
			{return false;}
		}

		private bool validateInputContractNo()
		{
			if(validatetxtContractNoYY() && validatetxtContractNoMM() && validatetxtContractNoXXX())
			{return true;}
			else
			{return false;}			
		}

		private bool validatetxtContractNoYY()
		{
			if(txtContractNoYY.Text == "")
			{
				Message(MessageList.Error.E0002, "เลขที่สัญญา");
				txtContractNoYY.Focus();
				return false;
			}
			else
			{return true;}
		}

		private bool validatetxtContractNoMM()
		{
			if(txtContractNoMM.Text == "")
			{
				Message(MessageList.Error.E0002, "เลขที่สัญญา");
				txtContractNoMM.Focus();
				return false;
			}
			else
			{return true;}
		}

		private bool validatetxtContractNoXXX()
		{
			if(txtContractNoXXX.Text == "")
			{
				Message(MessageList.Error.E0002, "เลขที่สัญญา");
				txtContractNoXXX.Focus();
				return false;
			}
			else
			{return true;}
		}

		private bool validateRetriveContract()
		{
			ContractBase contractBase = new ContractBase();
			contractBase = facadeVDContractMatch.RetriveContract(getContractNo());
			if(contractBase != null)
			{
				if(contractBase.AContractStatus.Code == "1")
				{
					Message(MessageList.Error.E0016, "สัญญาฉบับนี้ยังไม่ผ่านการอนุมัติ" );
					txtContractNoYY.Focus();
					return false;
				}
				else if(contractBase.AContractType.Code != "V")
				{
					Message(MessageList.Error.E0004, "เลขที่สัญญาสำหรับรถ");
					txtContractNoYY.Focus();
					return false;
				}
				return true;
			}
			else
			{
				Message(MessageList.Error.E0004, "เลขที่สัญญาสำหรับรถ");
				txtContractNoYY.Focus();
				return false;			
			}
		}

		private bool validateDelete(VehicleContract value)
		{
			if(!facadeVDContractMatch.ValidateDeleteVDContractMatch(value))
			{
				Message(MessageList.Error.E0013, "ลบรายการนี้ได้","มีพนักงานถูกจ่ายงานไปแล้ว" );
				return false;
			}
			return true;
		}
		#endregion - Validate Input -

		private void formContractList()
		{
			frmContractVDOList dialogContractList = new frmContractVDOList();
			ContractType contractType = new ContractType();
			
			if(cboCustomerTHName.Text != "")
			{dialogContractList.ConditionCustomer = (Customer)cboCustomerTHName.SelectedItem;}

			contractType.Code = "V";
			dialogContractList.ConditionCONTRACT_TYPE = contractType;

			if(cboContractStatus.Text != "")
			{
				dialogContractList.ConditionContractStatus	= (ContractStatus)cboContractStatus.SelectedItem;
			}

			if(txtContractNoYY.Text != "")
			{dialogContractList.ConditionYY  = txtContractNoYY.Text;}

			if(txtContractNoMM.Text != "")
			{dialogContractList.ConditionMM = txtContractNoMM.Text;}

			if(txtContractNoXXX.Text != "")
			{dialogContractList.ConditionXXX = txtContractNoXXX.Text;}

			dialogContractList.IsVehicleContract = true;

			dialogContractList.ShowDialog();
			
			if(dialogContractList.Selected)
			{
				retriveContract(dialogContractList.SelectedContract);
			}
		}

		private void setVehicleContractCondition(ContractBase value)
		{
			facadeVDContractMatch.ConditionCONTRACT_TYPE = value.AContractType;

			if(value.ContractNo != null)
			{facadeVDContractMatch.condition = (VehicleContract)value;}
		
			if(value.AContractStatus != null)
			{facadeVDContractMatch.ConditionContractStatus = value.AContractStatus;}

			if(value.ACustomerDepartment != null && value.ACustomerDepartment.ACustomer != null)
			{facadeVDContractMatch.ConditionCustomer = value.ACustomerDepartment.ACustomer;}

            objVehicleContract = (VehicleContract)value;
		}

		private void setVehicleContractCondition()
		{
			ContractType contractType = new ContractType();

			if(cboCustomerTHName.Text != "")
			{facadeVDContractMatch.ConditionCustomer = (Customer)cboCustomerTHName.SelectedItem;}

			contractType.Code = "V";
			facadeVDContractMatch.ConditionCONTRACT_TYPE = contractType;

			if(cboContractStatus.Text != "")
			{facadeVDContractMatch.ConditionContractStatus	= (ContractStatus)cboContractStatus.SelectedItem;}

			if(txtContractNoYY.Text != "")
			{facadeVDContractMatch.ConditionYY  = txtContractNoYY.Text;}

			if(txtContractNoMM.Text != "")
			{facadeVDContractMatch.ConditionMM = txtContractNoMM.Text;}

			if(txtContractNoXXX.Text != "")
			{facadeVDContractMatch.ConditionXXX = txtContractNoXXX.Text;}

			if(txtContractNoYY.Text == "" && txtContractNoMM.Text == "" && txtContractNoXXX.Text == "")
			{facadeVDContractMatch.condition.ContractNo = null;}
		}

		private void retriveContract(ContractBase value)
		{
			setContractBase(value);
			setVehicleContractCondition(value);
			showCase();
		}

		private void retriveContract()
		{
			setVehicleContractCondition();
			showCase();
		}

		private void formCurrentRefresh()
		{
			fpsVehicleDriver_Sheet1.RowCount = 0;
			newObject();
			retriveContract();	
		}

		private void setPermission()
		{
			if(isReadonly)
			{
				cmdAdd.Enabled = false;
				mniAdd.Enabled = false;
				cmdDelete.Enabled = false;
				mniDelete.Enabled = false;
			}
		}

        private void ControlPrefix(ContractType contractType)
        {
            if (contractType.Code == ContractType.CONTRACT_TYPE_VEHICLE)
            {
                txtDocumentType.Text = "C"; //Vehicle
                txtDocumentType.Visible = false;
                label25.Visible = true;
                cboVehicleKindContract.Text = "C";
                List<string> kindContract = new List<string>() { "C", "R", "T" };
                cboVehicleKindContract.DataSource = kindContract;
                cboVehicleKindContract.Visible = true;
                this.DocumentType = DOCUMENT_TYPE.CONTRACT;
            }
            else if (contractType.Code == ContractType.CONTRACT_TYPE_DRIVER)
            {
                txtDocumentType.Text = "D"; //Driver
                txtDocumentType.Visible = true;
                label25.Visible = true;
                cboVehicleKindContract.Visible = false;
                cboVehicleKindContract.Text = "C";
                this.DocumentType = DOCUMENT_TYPE.CONTRACT_DRIVER;
            }
            else
            {
                txtDocumentType.Text = "C"; //Other    
                txtDocumentType.Visible = true;
                label25.Visible = true;
                cboVehicleKindContract.Text = "C";
                cboVehicleKindContract.Visible = false;
                this.DocumentType = DOCUMENT_TYPE.CONTRACT;
            }
        }


//		============================== public method ==============================
		public bool AddRow(VehicleContract value)
		{
			if (facadeVDContractMatch.InsertVDContractMatch(value))
			{
				formCurrentRefresh();	
				return true;
			}
			else
			{return false;}
		}

		public bool UpdateRow(VehicleContract value)
		{
			if (facadeVDContractMatch.UpdateVDContractMatch(value))
			{
				formCurrentRefresh();
				return true;
			}
			else
			{return false;}
		}
			
		public override int MasterCount()
		{
			return facadeVDContractMatch.ObjContractList.Count;
		}

//		============================== Base Event ==============================
		public void InitForm()
		{
			mdiParent.DisableCommand();
			clearMainMenuStatus();

			newObject();
			clearForm();
			hideCase();
			mdiParent.RefreshMasterCount();
		}
		
		public void RefreshForm()
		{
			MainMenuNewStatus = true;
			MainMenuDeleteStatus = false;
			MainMenuRefreshStatus = false;
			MainMenuPrintStatus = false;

			mdiParent.EnableNewCommand(true);
			mdiParent.EnableDeleteCommand(false);
			mdiParent.EnableRefreshCommand(false);
			mdiParent.EnablePrintCommand(false);
			mdiParent.EnableExitCommand(true);

			try
			{
				if (facadeVDContractMatch.DisplayVDContractMatch())
				{bindForm();}
				else
				{setForm();}
			}
			catch(SqlException sqlex)
			{
				Message(sqlex);
			}
			catch(AppExceptionBase ex)
			{Message(ex);}
			catch(Exception ex)
			{Message(ex);}

			setPermission();
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
				frmEntry = new frmVDContractMatchingEntry(this);
				frmEntry.InitAddAction((VehicleContract)SelectedContractBase);
				frmEntry.DriverFocus();
				frmEntry.ShowDialog();
			}
			catch(SqlException sqlex)
			{
				Message(sqlex);
			}
			catch(AppExceptionBase ex)
			{Message(ex);}
			catch(Exception ex)
			{Message(ex);}		
		}
		
		private void EditEvent()
		{
			try
			{
				frmEntry.InitEditAction((VehicleContract)SelectedContractBase);
				frmEntry.ShowDialog();				
			}
			catch(SqlException sqlex)
			{
				Message(sqlex);
			}
			catch(AppExceptionBase ex)
			{Message(ex);}
			catch(Exception ex)
			{Message(ex);}		
		}

		private void DeleteEvent()
		{
			try
			{
				if(validateDelete((VehicleContract)SelectedContractBase))
				{
					if (Message(MessageList.Question.Q0001) == DialogResult.Yes)
					{
						if(facadeVDContractMatch.DeleteVDContractMatch((VehicleContract)SelectedContractBase))
						{
							formCurrentRefresh();
						}
					}
					else
					{this.Show();}
				}
			}
			catch(SqlException sqlex)
			{
				Message(sqlex);
			}
			catch(AppExceptionBase ex)
			{Message(ex);}
			catch(Exception ex)
			{Message(ex);}		
		}

//		============================== event ==============================
		private void mniAdd_Click(object sender, System.EventArgs e)
		{
			AddEvent();
		}

		private void mniEdit_Click(object sender, System.EventArgs e)
		{
			EditEvent();
		}

		private void mniDelete_Click(object sender, System.EventArgs e)
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

		private void cmdDelete_Click(object sender, System.EventArgs e)
		{
			DeleteEvent();
		}

		private void frmVDContractMatch_Load(object sender, System.EventArgs e)
		{
			mdiParent = (frmMain)this.MdiParent;
			InitForm();
		}

		private void txtContractNoXXX_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == System.Windows.Forms.Keys.Enter)
			{retriveContract();}
		}

		private void txtContractNoXXX_TextChanged(object sender, System.EventArgs e)
		{
			if(isEventTextChanged)
			{
				if(txtContractNoXXX.Text.Length == 3)
				{
					if(validateForm())
					{retriveContract(facadeVDContractMatch.RetriveContract(getContractNo()));}
				}
			}
		}

		private void txtContractNoYY_TextChanged(object sender, System.EventArgs e)
		{
			if(isEventTextChanged)
			{
				if(txtContractNoYY.Text.Length == 2)
				{txtContractNoMM.Focus();}
			}
		}

		private void txtContractNoMM_TextChanged(object sender, System.EventArgs e)
		{
			if(isEventTextChanged)
			{
				if(txtContractNoMM.Text.Length == 2)
				{txtContractNoXXX.Focus();}
			}
		}	
		
		private void txtContractNoXXX_DoubleClick(object sender, System.EventArgs e)
		{
			formContractList();
		}

		private void fpsVehicleDriver_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
		{
            if (!e.ColumnHeader)
			{
                if (objVehicleContract != null && objVehicleContract.AContractStatus != null && objVehicleContract.AContractStatus.Code.Equals("2") && fpsVehicleDriver_Sheet1.Cells[SelectedRow, 3].Text == "")
                {
                    AddEvent();
                }
                else 
                {
                    EditEvent();                
                }
			}		
		}

		private void fpsVehicleDriver_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
		{
            if (objVehicleContract != null && objVehicleContract.AContractStatus != null)
            {
                if (objVehicleContract.AContractStatus.Code.Equals("2"))
                {
                    if (fpsVehicleDriver_Sheet1.Cells[SelectedRow, 3].Text == "")
                    { disableButtonMatch(); }
                    else
                    { eableButtonMatch(); }
                }
                else if (objVehicleContract.AContractStatus.Code.Equals("4"))
                {
                    cmdEdit.Enabled = true;
                    mniEdit.Enabled = true;
                }
                else
                {
                    enableContext(false);                
                }
            }
            else
            { 
                enableContext(false); 
            }

            setPermission();
		}

        private void cboVehicleKindContract_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboVehicleKindContract.Text)
            {
                case "C":
                    this.DocumentType = Entity.CommonEntity.DOCUMENT_TYPE.CONTRACT;
                    break;
                case "R":
                    this.DocumentType = Entity.CommonEntity.DOCUMENT_TYPE.CONTRACT_RENEWAL;
                    break;
                case "T":
                    this.DocumentType = Entity.CommonEntity.DOCUMENT_TYPE.CONTRACT_TEMPORARY;
                    break;
                default:
                    this.DocumentType = Entity.CommonEntity.DOCUMENT_TYPE.CONTRACT;
                    break;
            }

        }

        private void cboContractType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboContractType.SelectedIndex != -1)
            {
                ContractType contractType = (ContractType)cboContractType.SelectedItem;
                ControlPrefix(contractType);
            }
        }
	}
}

