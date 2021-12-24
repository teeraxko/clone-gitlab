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
using Entity.VehicleEntities;
using Entity.ContractEntities;

using Facade.CommonFacade;
using Facade.VehicleFacade;
using Facade.ContractFacade;

using Presentation.CommonGUI;
using Presentation.VehicleGUI;

namespace Presentation.ContractGUI
{
	public class frmServiceStaffMatchToContract : ChildFormBase, IMDIChildForm	
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

		private System.Windows.Forms.ComboBox cboContractType;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Button cmdShow;
		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.GroupBox gpbRetriveContract;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.TextBox txtContractNoXXX;
		private System.Windows.Forms.TextBox txtContractNoMM;
		private System.Windows.Forms.TextBox txtContractNoYY;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label26;
		private FarPoint.Win.Spread.FpSpread fpsContractList;
		private FarPoint.Win.Spread.SheetView fpsContractList_Sheet1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cboContractStatus;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.ComboBox cboCustomerTHName;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.TextBox txtContractPrefix;
		
		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
			FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType1 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmServiceStaffMatchToContract));
			FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType2 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType5 = new FarPoint.Win.Spread.CellType.TextCellType();
			this.fpsContractList = new FarPoint.Win.Spread.FpSpread();
			this.fpsContractList_Sheet1 = new FarPoint.Win.Spread.SheetView();
			this.cmdShow = new System.Windows.Forms.Button();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cboContractType = new System.Windows.Forms.ComboBox();
			this.label27 = new System.Windows.Forms.Label();
			this.gpbRetriveContract = new System.Windows.Forms.GroupBox();
			this.txtContractPrefix = new System.Windows.Forms.TextBox();
			this.cboCustomerTHName = new System.Windows.Forms.ComboBox();
			this.label29 = new System.Windows.Forms.Label();
			this.cboContractStatus = new System.Windows.Forms.ComboBox();
			this.label28 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
			this.label23 = new System.Windows.Forms.Label();
			this.txtContractNoXXX = new System.Windows.Forms.TextBox();
			this.txtContractNoMM = new System.Windows.Forms.TextBox();
			this.txtContractNoYY = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label26 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.fpsContractList)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsContractList_Sheet1)).BeginInit();
			this.gpbRetriveContract.SuspendLayout();
			this.SuspendLayout();
			// 
			// fpsContractList
			// 
			this.fpsContractList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.fpsContractList.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
			this.fpsContractList.Location = new System.Drawing.Point(14, 128);
			this.fpsContractList.Name = "fpsContractList";
			this.fpsContractList.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
																						 this.fpsContractList_Sheet1});
			this.fpsContractList.Size = new System.Drawing.Size(1000, 320);
			this.fpsContractList.TabIndex = 0;
			this.fpsContractList.TabStop = false;
			this.fpsContractList.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpsContractList_CellDoubleClick);
			// 
			// fpsContractList_Sheet1
			// 
			this.fpsContractList_Sheet1.Reset();
			// Formulas and custom names must be loaded with R1C1 reference style
			this.fpsContractList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
			this.fpsContractList_Sheet1.ColumnCount = 9;
			this.fpsContractList_Sheet1.RowCount = 1;
			this.fpsContractList_Sheet1.ColumnHeader.Cells.Get(0, 1).Text = "สถานะสัญญา";
			this.fpsContractList_Sheet1.ColumnHeader.Cells.Get(0, 2).Text = "เลขที่สัญญา";
			this.fpsContractList_Sheet1.ColumnHeader.Cells.Get(0, 3).Text = "ประเภทสัญญา";
			this.fpsContractList_Sheet1.ColumnHeader.Cells.Get(0, 4).Text = "วันที่เริ่มต้นสัญญา";
			this.fpsContractList_Sheet1.ColumnHeader.Cells.Get(0, 5).Text = "วันที่สิ้นสุดสัญญา";
			this.fpsContractList_Sheet1.ColumnHeader.Cells.Get(0, 6).Text = "ลูกค้า";
			this.fpsContractList_Sheet1.ColumnHeader.Cells.Get(0, 7).Text = "ฝ่ายลูกค้า";
			this.fpsContractList_Sheet1.ColumnHeader.Cells.Get(0, 8).Text = "จำนวน";
			this.fpsContractList_Sheet1.ColumnHeader.Columns.Default.Resizable = false;
			this.fpsContractList_Sheet1.Columns.Default.Resizable = false;
			textCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType1.DropDownButton = false;
			this.fpsContractList_Sheet1.Columns.Get(0).CellType = textCellType1;
			this.fpsContractList_Sheet1.Columns.Get(0).Visible = false;
			this.fpsContractList_Sheet1.Columns.Get(1).Label = "สถานะสัญญา";
			this.fpsContractList_Sheet1.Columns.Get(1).Width = 76F;
			this.fpsContractList_Sheet1.Columns.Get(2).AllowAutoSort = true;
			textCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType2.DropDownButton = false;
			this.fpsContractList_Sheet1.Columns.Get(2).CellType = textCellType2;
			this.fpsContractList_Sheet1.Columns.Get(2).Label = "เลขที่สัญญา";
			this.fpsContractList_Sheet1.Columns.Get(2).Width = 95F;
			this.fpsContractList_Sheet1.Columns.Get(3).Label = "ประเภทสัญญา";
			this.fpsContractList_Sheet1.Columns.Get(3).Width = 150F;
			this.fpsContractList_Sheet1.Columns.Get(4).AllowAutoSort = true;
			dateTimeCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			dateTimeCellType1.Calendar = new System.Globalization.GregorianCalendar(System.Globalization.GregorianCalendarTypes.Localized);
			dateTimeCellType1.DateDefault = new System.DateTime(2005, 11, 3, 15, 47, 24, 0);
			dateTimeCellType1.DropDownButton = false;
			dateTimeCellType1.TimeDefault = new System.DateTime(2005, 11, 3, 15, 47, 24, 0);
			this.fpsContractList_Sheet1.Columns.Get(4).CellType = dateTimeCellType1;
			this.fpsContractList_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsContractList_Sheet1.Columns.Get(4).Label = "วันที่เริ่มต้นสัญญา";
			this.fpsContractList_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
			this.fpsContractList_Sheet1.Columns.Get(4).Width = 100F;
			this.fpsContractList_Sheet1.Columns.Get(5).AllowAutoSort = true;
			dateTimeCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			dateTimeCellType2.Calendar = new System.Globalization.GregorianCalendar(System.Globalization.GregorianCalendarTypes.Localized);
			dateTimeCellType2.DateDefault = new System.DateTime(2005, 11, 3, 15, 47, 50, 0);
			dateTimeCellType2.DropDownButton = false;
			dateTimeCellType2.TimeDefault = new System.DateTime(2005, 11, 3, 15, 47, 50, 0);
			this.fpsContractList_Sheet1.Columns.Get(5).CellType = dateTimeCellType2;
			this.fpsContractList_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsContractList_Sheet1.Columns.Get(5).Label = "วันที่สิ้นสุดสัญญา";
			this.fpsContractList_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
			this.fpsContractList_Sheet1.Columns.Get(5).Width = 100F;
			this.fpsContractList_Sheet1.Columns.Get(6).AllowAutoSort = true;
			textCellType3.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType3.DropDownButton = false;
			this.fpsContractList_Sheet1.Columns.Get(6).CellType = textCellType3;
			this.fpsContractList_Sheet1.Columns.Get(6).Label = "ลูกค้า";
			this.fpsContractList_Sheet1.Columns.Get(6).Width = 260F;
			this.fpsContractList_Sheet1.Columns.Get(7).AllowAutoSort = true;
			textCellType4.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType4.DropDownButton = false;
			this.fpsContractList_Sheet1.Columns.Get(7).CellType = textCellType4;
			this.fpsContractList_Sheet1.Columns.Get(7).Label = "ฝ่ายลูกค้า";
			this.fpsContractList_Sheet1.Columns.Get(7).Width = 100F;
			this.fpsContractList_Sheet1.Columns.Get(8).AllowAutoSort = true;
			textCellType5.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType5.DropDownButton = false;
			this.fpsContractList_Sheet1.Columns.Get(8).CellType = textCellType5;
			this.fpsContractList_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsContractList_Sheet1.Columns.Get(8).Label = "จำนวน";
			this.fpsContractList_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
			this.fpsContractList_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
			this.fpsContractList_Sheet1.RowHeader.Columns.Default.Resizable = false;
			this.fpsContractList_Sheet1.RowHeader.Rows.Default.Resizable = false;
			this.fpsContractList_Sheet1.Rows.Default.Resizable = false;
			this.fpsContractList_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
			this.fpsContractList_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
			this.fpsContractList_Sheet1.SheetName = "Sheet1";
			this.fpsContractList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
			// 
			// cmdShow
			// 
			this.cmdShow.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdShow.Location = new System.Drawing.Point(390, 472);
			this.cmdShow.Name = "cmdShow";
			this.cmdShow.Size = new System.Drawing.Size(120, 23);
			this.cmdShow.TabIndex = 7;
			this.cmdShow.Text = "ดูข้อมูล";
			this.cmdShow.Click += new System.EventHandler(this.cmdShow_Click);
			// 
			// cmdCancel
			// 
			this.cmdCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.Location = new System.Drawing.Point(518, 472);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.Size = new System.Drawing.Size(120, 23);
			this.cmdCancel.TabIndex = 8;
			this.cmdCancel.Text = "ยกเลิก";
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			// 
			// cboContractType
			// 
			this.cboContractType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboContractType.Location = new System.Drawing.Point(512, 24);
			this.cboContractType.Name = "cboContractType";
			this.cboContractType.Size = new System.Drawing.Size(240, 21);
			this.cboContractType.TabIndex = 2;
            this.cboContractType.SelectedIndexChanged += new System.EventHandler(this.cboContractType_SelectedIndexChanged);
			// 
			// label27
			// 
			this.label27.Location = new System.Drawing.Point(432, 24);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(72, 23);
			this.label27.TabIndex = 81;
			this.label27.Text = "ประเภทสัญญา";
			// 
			// gpbRetriveContract
			// 
			this.gpbRetriveContract.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.gpbRetriveContract.Controls.Add(this.txtContractPrefix);
			this.gpbRetriveContract.Controls.Add(this.cboCustomerTHName);
			this.gpbRetriveContract.Controls.Add(this.label29);
			this.gpbRetriveContract.Controls.Add(this.cboContractStatus);
			this.gpbRetriveContract.Controls.Add(this.label28);
			this.gpbRetriveContract.Controls.Add(this.label1);
			this.gpbRetriveContract.Controls.Add(this.label4);
			this.gpbRetriveContract.Controls.Add(this.label22);
			this.gpbRetriveContract.Controls.Add(this.label23);
			this.gpbRetriveContract.Controls.Add(this.txtContractNoXXX);
			this.gpbRetriveContract.Controls.Add(this.txtContractNoMM);
			this.gpbRetriveContract.Controls.Add(this.txtContractNoYY);
			this.gpbRetriveContract.Controls.Add(this.label5);
			this.gpbRetriveContract.Controls.Add(this.label26);
			this.gpbRetriveContract.Controls.Add(this.label27);
			this.gpbRetriveContract.Controls.Add(this.cboContractType);
			this.gpbRetriveContract.Location = new System.Drawing.Point(14, 8);
			this.gpbRetriveContract.Name = "gpbRetriveContract";
			this.gpbRetriveContract.Size = new System.Drawing.Size(1000, 104);
			this.gpbRetriveContract.TabIndex = 100;
			this.gpbRetriveContract.TabStop = false;
			this.gpbRetriveContract.Text = "เรียกดูสัญญาตามเงื่อนไข";
			this.gpbRetriveContract.Enter += new System.EventHandler(this.gpbRetriveContract_Enter);
			// 
			// txtContractPrefix
			// 
			this.txtContractPrefix.Enabled = false;
			this.txtContractPrefix.Location = new System.Drawing.Point(560, 56);
			this.txtContractPrefix.Name = "txtContractPrefix";
			this.txtContractPrefix.Size = new System.Drawing.Size(24, 20);
			this.txtContractPrefix.TabIndex = 85;
			this.txtContractPrefix.TabStop = false;
			this.txtContractPrefix.Text = "C";
			this.txtContractPrefix.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// cboCustomerTHName
			// 
			this.cboCustomerTHName.DisplayMember = "sss";
			this.cboCustomerTHName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboCustomerTHName.Location = new System.Drawing.Point(104, 24);
			this.cboCustomerTHName.Name = "cboCustomerTHName";
			this.cboCustomerTHName.Size = new System.Drawing.Size(312, 21);
			this.cboCustomerTHName.TabIndex = 83;
			// 
			// label29
			// 
			this.label29.Location = new System.Drawing.Point(24, 24);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(40, 23);
			this.label29.TabIndex = 84;
			this.label29.Text = "ชื่อลูกค้า";
			// 
			// cboContractStatus
			// 
			this.cboContractStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboContractStatus.Location = new System.Drawing.Point(104, 56);
			this.cboContractStatus.Name = "cboContractStatus";
			this.cboContractStatus.Size = new System.Drawing.Size(240, 21);
			this.cboContractStatus.TabIndex = 81;
			// 
			// label28
			// 
			this.label28.Location = new System.Drawing.Point(24, 56);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(64, 23);
			this.label28.TabIndex = 82;
			this.label28.Text = "สถานะสัญญา";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.label1.Location = new System.Drawing.Point(512, 56);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 23);
			this.label1.TabIndex = 62;
			this.label1.Text = "PTB  -";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(664, 80);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(32, 16);
			this.label4.TabIndex = 61;
			this.label4.Text = "XXX";
			// 
			// label22
			// 
			this.label22.Location = new System.Drawing.Point(632, 80);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(24, 16);
			this.label22.TabIndex = 60;
			this.label22.Text = "MM";
			// 
			// label23
			// 
			this.label23.Location = new System.Drawing.Point(600, 80);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(24, 16);
			this.label23.TabIndex = 59;
			this.label23.Text = "YY";
			// 
			// txtContractNoXXX
			// 
			this.txtContractNoXXX.Location = new System.Drawing.Point(656, 56);
			this.txtContractNoXXX.MaxLength = 3;
			this.txtContractNoXXX.Name = "txtContractNoXXX";
			this.txtContractNoXXX.Size = new System.Drawing.Size(32, 20);
			this.txtContractNoXXX.TabIndex = 6;
			this.txtContractNoXXX.Text = "";
			this.txtContractNoXXX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtContractNoXXX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtContractNoXXX_KeyDown);
			this.txtContractNoXXX.TextChanged += new System.EventHandler(this.txtContractNoXXX_TextChanged);
			this.txtContractNoXXX.DoubleClick += new System.EventHandler(this.txtContractNoXXX_DoubleClick);
			// 
			// txtContractNoMM
			// 
			this.txtContractNoMM.Location = new System.Drawing.Point(624, 56);
			this.txtContractNoMM.MaxLength = 2;
			this.txtContractNoMM.Name = "txtContractNoMM";
			this.txtContractNoMM.Size = new System.Drawing.Size(32, 20);
			this.txtContractNoMM.TabIndex = 5;
			this.txtContractNoMM.Text = "";
			this.txtContractNoMM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtContractNoMM.TextChanged += new System.EventHandler(this.txtContractNoMM_TextChanged);
			// 
			// txtContractNoYY
			// 
			this.txtContractNoYY.Location = new System.Drawing.Point(592, 56);
			this.txtContractNoYY.MaxLength = 2;
			this.txtContractNoYY.Name = "txtContractNoYY";
			this.txtContractNoYY.Size = new System.Drawing.Size(32, 20);
			this.txtContractNoYY.TabIndex = 4;
			this.txtContractNoYY.Text = "";
			this.txtContractNoYY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtContractNoYY.TextChanged += new System.EventHandler(this.txtContractNoYY_TextChanged);
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.label5.Location = new System.Drawing.Point(584, 56);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(8, 23);
			this.label5.TabIndex = 55;
			this.label5.Text = "-";
			// 
			// label26
			// 
			this.label26.Location = new System.Drawing.Point(432, 56);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(64, 23);
			this.label26.TabIndex = 53;
			this.label26.Text = "เลขที่สัญญา";
			// 
			// frmServiceStaffMatchToContract
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.cmdCancel;
			this.ClientSize = new System.Drawing.Size(1028, 510);
			this.Controls.Add(this.gpbRetriveContract);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdShow);
			this.Controls.Add(this.fpsContractList);
			this.Name = "frmServiceStaffMatchToContract";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "ระบุพนักงานในสัญญา";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmServiceStaffMatchToContract_Load);
			this.Closed += new System.EventHandler(this.frmServiceStaffMatchToContract_Closed);
			((System.ComponentModel.ISupportInitialize)(this.fpsContractList)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsContractList_Sheet1)).EndInit();
			this.gpbRetriveContract.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region - Private -
		private bool isTextChange = true;
 	    private frmMain mdiParent;
		private ContractBase objContractBase;
		private DocumentNo contractNo;
		private frmServiceStaffMatchToContractDetail frmDetail;
		private ServiceStaffMatchToContractFacade facadeServiceStaffMatchToContract;

        private int SelectedRow
		{
			get{return fpsContractList_Sheet1.ActiveRowIndex;}
		}

		private string SelectedKey
		{
			get{return fpsContractList_Sheet1.Cells[SelectedRow,0].Text;}
		}

		private ContractBase SelectedContract
		{			
			get{return facadeServiceStaffMatchToContract.ObjContractList[SelectedKey];}
		}
		#endregion

//		============================= Constructor ==============================
		public frmServiceStaffMatchToContract() : base()
		{
			InitializeComponent();
			frmDetail = new frmServiceStaffMatchToContractDetail(this);	
			facadeServiceStaffMatchToContract = new ServiceStaffMatchToContractFacade();
			cboCustomerTHName.DataSource  = facadeServiceStaffMatchToContract.DataSourceCustomerName;
			cboContractType.DataSource = facadeServiceStaffMatchToContract.DataSourceContractType;
			cboContractStatus.DataSource  = facadeServiceStaffMatchToContract.DataSourceContractStatus;

            if (cboContractStatus.Items.Count > 0)
                cboContractStatus.SelectedIndex = -1;
            //D21018-BTS Contract Modification : set ค่าเริ่มต้นคือ สัญญาเช่าพนักงานขับรถ
            if (cboContractType.Items.Count > 0)
                cboContractType.SelectedIndex = 0;

			hideControl(false);
			enableControl(false);
		}

        //D21018-BTS Contract Modification : fixed to display form ID
        public override string FormID()
        {
            return UserProfile.GetFormID("miContract", "miContractDocumentServiceStaffMatchToContract");
        }

//		============================== Property ==============================
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
            //contractNo = new DocumentNo(DOCUMENT_TYPE.CONTRACT, txtContractNoYY.Text, txtContractNoMM.Text, txtContractNoXXX.Text);			
            //return contractNo;

            //D21018-BTS Contract Modification
            DocumentNo contractNo = new DocumentNo(_documentType, txtContractNoYY.Text, txtContractNoMM.Text, txtContractNoXXX.Text);
            return contractNo;

		}	
	
		public ServiceStaffMatchToContractFacade FacadeServiceStaffMatchToContract
		{
			get{return facadeServiceStaffMatchToContract;}
		}

		public ContractBase getContractBase()
		{
			return objContractBase;
		}
		
//		============================= Public Method ============================
		public override int MasterCount()
		{
			return facadeServiceStaffMatchToContract.ObjContractList.Count;
		}

//		============================= Private Method ============================
		private void setContractBase(ContractBase value)
		{	
			isTextChange = false;
			objContractBase = value;
			txtContractNoYY.Text = value.ContractNo.Year.ToString();
			txtContractNoMM.Text = value.ContractNo.Month.ToString();
			txtContractNoXXX.Text = value.ContractNo.No.ToString();
            cboCustomerTHName.Text = value.ACustomerDepartment.ACustomer.ToString();
			cboContractType.Text = GUIFunction.GetString(value.AContractType);
			cboContractStatus.Text = GUIFunction.GetString(value.AContractStatus);	
			isTextChange = true;
		}

		private void formContractList()
		{
			frmContractVDOList dialogContractList = new frmContractVDOList();	

			dialogContractList.IsDOContract = true;

			if(cboCustomerTHName.Text != "")
			{
				dialogContractList.ConditionCustomer = (Customer)cboCustomerTHName.SelectedItem;
			}
			if(cboContractType.Text != "")
			{
				dialogContractList.ConditionCONTRACT_TYPE = (ContractType)cboContractType.SelectedItem;
			}
			if(cboContractStatus.Text != "")
			{
				dialogContractList.ConditionContractStatus = (ContractStatus)cboContractStatus.SelectedItem;
			}
			if(txtContractNoYY.Text != "")
			{
				dialogContractList.ConditionYY  = txtContractNoYY.Text;
			}
			if(txtContractNoMM.Text != "")
			{
				dialogContractList.ConditionMM = txtContractNoMM.Text;
			}
			if(txtContractNoXXX.Text != "")
			{
				dialogContractList.ConditionXXX = txtContractNoXXX.Text;
			}

			dialogContractList.ShowDialog();	
		
			if(dialogContractList.Selected)
			{
				facadeServiceStaffMatchToContract.ObjContractList.Add(dialogContractList.SelectedContract);
				bindForm(dialogContractList.SelectedContract);
			}
		}

		private void bindContractList()
		{			
			if(cboCustomerTHName.Text != "")
			{
				facadeServiceStaffMatchToContract.ConditionContract.ACustomerDepartment.ACustomer = (Customer)cboCustomerTHName.SelectedItem;
			}

			if(cboContractType.Text != "")
			{
				facadeServiceStaffMatchToContract.ConditionContract.AContractType = (ContractType)cboContractType.SelectedItem;
			}

			if(cboContractStatus.Text != "")
			{
				facadeServiceStaffMatchToContract.ConditionContract.AContractStatus = (ContractStatus)cboContractStatus.SelectedItem;
			}

			if(txtContractNoYY.Text != "")
			{
				facadeServiceStaffMatchToContract.ConditionYY  = txtContractNoYY.Text;
			}

			if(txtContractNoMM.Text != "")
			{
				facadeServiceStaffMatchToContract.ConditionMM = txtContractNoMM.Text;
			}

			if(txtContractNoXXX.Text != "")
			{
				facadeServiceStaffMatchToContract.ConditionXXX = txtContractNoXXX.Text;
			}

			facadeServiceStaffMatchToContract.DisplayDriverOtherContract();
			bindForm();
		}

		private void bindForm(ContractBase value)
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

			setContractBase(value);
			hideControl(true);
			enableControl(true);
			enableGPBRetriveContract(false);

			fpsContractList_Sheet1.RowCount = 1;
			bindContract(0, value);
			mdiParent.RefreshMasterCount();
		}

		private void bindForm()
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

			hideControl(true);
			enableControl(true);
			enableGPBRetriveContract(false);

			if (facadeServiceStaffMatchToContract.ObjContractList != null)
			{
				int iRow = facadeServiceStaffMatchToContract.ObjContractList.Count;
				fpsContractList_Sheet1.RowCount = iRow;
				for(int i=0; i<iRow; i++)
				{
					bindContract(i, facadeServiceStaffMatchToContract.ObjContractList[i]);
				}			
				mdiParent.RefreshMasterCount();
			}

			if(fpsContractList_Sheet1.RowCount == 0)
			{
				cmdShow.Enabled = false;
			}
		}		

		private void bindContract(int iRow, ContractBase value)
		{
			fpsContractList_Sheet1.Cells[iRow,0].Text = GUIFunction.GetString(value.EntityKey);
			fpsContractList_Sheet1.Cells[iRow,1].Text = GUIFunction.GetString(value.AContractStatus);
			fpsContractList_Sheet1.Cells[iRow,2].Text = GUIFunction.GetString(value.ContractNo.ToString());
			fpsContractList_Sheet1.Cells[iRow,3].Text = GUIFunction.GetString(value.AContractType);
			fpsContractList_Sheet1.Cells[iRow,4].Text = GUIFunction.GetString(value.APeriod.From.Date.ToShortDateString());
			fpsContractList_Sheet1.Cells[iRow,5].Text = GUIFunction.GetShortDateString(value.APeriod.To);
			fpsContractList_Sheet1.Cells[iRow,6].Text = GUIFunction.GetString(value.ACustomerDepartment.ACustomer.AName.English);
			fpsContractList_Sheet1.Cells[iRow,7].Text = GUIFunction.GetString(value.ACustomerDepartment.ShortName);
			fpsContractList_Sheet1.Cells[iRow,8].Text = GUIFunction.GetString(value.UnitHire);
		}
	
		#region - Hide & Enable Control -
		private void hideControl(bool enable)
		{
			fpsContractList.Visible = enable;	
			cmdShow.Visible = enable;
			cmdCancel.Visible = enable;
		}
		private void enableControl(bool enable)
		{
			fpsContractList.Enabled = enable;	
			cmdShow.Enabled = enable;
			cmdCancel.Enabled = enable;	
		}
		private void enableGPBRetriveContract(bool enable)
		{
			gpbRetriveContract.Enabled = enable;
			cboContractStatus.Enabled = enable;
			cboContractType.Enabled = enable;
			cboCustomerTHName.Enabled = enable;
		}
		#endregion - Hide & Enable Control -

		#region - Validate Input ContractNo -
		private bool validateInputContractNo()
		{
			if(validatetxtContractNoYY() && validatetxtContractNoMM() && validatetxtContractNoXXX() && validateContractNo())
			{
				return true;
			}
			else
			{
				return false;
			}
			
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
			{
				return true;
			}
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
			{
				return true;
			}
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
			{
				return true;
			}
		}

		private bool validateContractNo()
		{
			objContractBase = new ContractBase();
			objContractBase = facadeServiceStaffMatchToContract.RetriveContract(getContractNo());
			if(objContractBase == null)
			{
				Message(MessageList.Error.E0004, "เลขที่สัญญา");
				txtContractNoYY.Focus();
				return false;
			}
			else
			{
                if (objContractBase.AContractType.Code == ContractType.CONTRACT_TYPE_VEHICLE)
				{
					Message(MessageList.Error.E0004, "เลขที่สัญญาสำหรับพนักงาน");
					txtContractNoYY.Focus();
					return false;
				}
				return true;			
			}
		}
		#endregion - Validate Input ContractNo -


		private void clearfpsContractList()
		{
			fpsContractList_Sheet1.RowCount = 0;
		}	

		private void clearForm()
		{
			hideControl(false);
			enableGPBRetriveContract(true);
			clearfpsContractList();
			txtContractNoYY.Text = "";
			txtContractNoMM.Text = "";
			txtContractNoXXX.Text = "";
            //cboContractStatus.SelectedIndex = -1;
            //cboContractStatus.SelectedIndex = -1;
            //cboContractType.SelectedIndex = -1;	
            //cboContractType.SelectedIndex = -1;	
		}

        //D21018 change prefix according to contract type                    
        private void ControlPrefix(ContractType contractType)
        {
            txtContractPrefix.Text = contractType.Prefix;
            switch (contractType.Code)
            {
                case ContractType.CONTRACT_TYPE_DRIVER:
                    this.DocumentType = Entity.CommonEntity.DOCUMENT_TYPE.CONTRACT_DRIVER;
                    break;
                default:
                    this.DocumentType = Entity.CommonEntity.DOCUMENT_TYPE.CONTRACT;
                    break;
            }
        }

//		============================== Base Event ==============================
		public void InitForm()
		{
			mdiParent.DisableCommand();
			clearMainMenuStatus();

			frmDetail = new frmServiceStaffMatchToContractDetail(this);	
			facadeServiceStaffMatchToContract = new ServiceStaffMatchToContractFacade();
			clearForm();
			mdiParent.RefreshMasterCount();
		}

		public void RefreshForm()
		{
			if(validateInputContractNo())
			{
				bindForm(objContractBase);		
			}
		}

		public void PrintForm()
		{
		}

		public void ExitForm()
		{
//			mdiParent.EnableNewCommand(false);
//			mdiParent.EnableDeleteCommand(false);
//			mdiParent.EnableRefreshCommand(false);
//			mdiParent.EnablePrintCommand(false);
//			mdiParent.EnableExitCommand(true);
			Dispose(true);
		}

		private void showServiceStaffContract()
		{
			try
			{				
				frmDetail.MdiParent = this.MdiParent;
				frmDetail.InitServiceStaffContract(SelectedContract);
				frmDetail.Show();
			}
			catch(SqlException sqlex)
			{Message(sqlex);}
			catch(AppExceptionBase ex)
			{Message(ex);}
			catch(Exception ex)
			{Message(ex);}		
		}
		
//		============================== Event ==============================	
		private void frmServiceStaffMatchToContract_Load(object sender, System.EventArgs e)
		{
			mdiParent = (frmMain)this.MdiParent;
			InitForm();
		}

		private void txtContractNoXXX_DoubleClick(object sender, System.EventArgs e)
		{
			formContractList();
		}

		private void txtContractNoYY_TextChanged(object sender, System.EventArgs e)
		{
			if(txtContractNoYY.Text.Length == 2)
			{
				txtContractNoMM.Focus();
			}
		}

		private void txtContractNoMM_TextChanged(object sender, System.EventArgs e)
		{
			if(txtContractNoMM.Text.Length == 2)
			{
				txtContractNoXXX.Focus();
			}
		}

		private void txtContractNoXXX_TextChanged(object sender, System.EventArgs e)
		{
			if(isTextChange && txtContractNoXXX.Text.Length == 3)
			{
				if(validateInputContractNo())
				{
					bindForm(objContractBase);
				}
			}
		}
		
		private void txtContractNoXXX_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == System.Windows.Forms.Keys.Enter)	
			{
				bindContractList();
			}
		}

		private void cmdShow_Click(object sender, System.EventArgs e)
		{
			showServiceStaffContract();
		}

		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			ExitForm();
			this.Hide();
		}

		private void fpsContractList_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
		{
			if(!e.ColumnHeader)
			{
				showServiceStaffContract();
			}
		}

		private void frmServiceStaffMatchToContract_Closed(object sender, System.EventArgs e)
		{	
			ExitForm();
		}

		private void gpbRetriveContract_Enter(object sender, System.EventArgs e)
		{
		
		}

        //D21018-BTS Contract Modification : กำหนดการแสดง Prefix เมื่อมีการเปลี่ยนสัญญา
        private void cboContractType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboContractType.SelectedIndex > -1)
            {
                ContractType contractType = (ContractType)cboContractType.SelectedItem;
                ControlPrefix(contractType);
            }

        }
	}
}