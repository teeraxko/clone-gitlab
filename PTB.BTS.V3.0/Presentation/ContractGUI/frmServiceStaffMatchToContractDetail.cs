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
	public class frmServiceStaffMatchToContractDetail  : ChildFormBase, IMDIChildForm
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
		private System.Windows.Forms.Label label1;
		private FarPoint.Win.Spread.FpSpread fpsServiceStaff;
		private FarPoint.Win.Spread.SheetView fpsServiceStaff_Sheet1;
		private System.Windows.Forms.Button cmdAdd;
		private System.Windows.Forms.Button cmdEdit;
		private System.Windows.Forms.Button cmdDelete;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox txtContractPrefix;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.TextBox txtContractNoXXX;
		private System.Windows.Forms.TextBox txtContractNoMM;
		private System.Windows.Forms.TextBox txtContractNoYY;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.GroupBox gpbContract;
		private System.Windows.Forms.Button cmdPrevious;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem mniAdd;
		private System.Windows.Forms.MenuItem mniEdit;
		private System.Windows.Forms.MenuItem mniDelete;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.DateTimePicker dtpEndDate;
		private System.Windows.Forms.DateTimePicker dtpStartDate;
		private System.Windows.Forms.TextBox txtUnitHire;
		private System.Windows.Forms.TextBox txtContractType;
		private System.Windows.Forms.TextBox txtCustomerTHName;
		private System.Windows.Forms.TextBox txtContractStatus;
		private System.Windows.Forms.Label label8;
	
		private System.ComponentModel.Container components = null;

		
		private void InitializeComponent()
		{
			FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType5 = new FarPoint.Win.Spread.CellType.TextCellType();
			this.gpbContract = new System.Windows.Forms.GroupBox();
			this.label8 = new System.Windows.Forms.Label();
			this.txtUnitHire = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
			this.label6 = new System.Windows.Forms.Label();
			this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
			this.label5 = new System.Windows.Forms.Label();
			this.txtContractType = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtContractStatus = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtCustomerTHName = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.txtContractPrefix = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
			this.label23 = new System.Windows.Forms.Label();
			this.txtContractNoXXX = new System.Windows.Forms.TextBox();
			this.txtContractNoMM = new System.Windows.Forms.TextBox();
			this.txtContractNoYY = new System.Windows.Forms.TextBox();
			this.label25 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.fpsServiceStaff = new FarPoint.Win.Spread.FpSpread();
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.mniAdd = new System.Windows.Forms.MenuItem();
			this.mniEdit = new System.Windows.Forms.MenuItem();
			this.mniDelete = new System.Windows.Forms.MenuItem();
			this.fpsServiceStaff_Sheet1 = new FarPoint.Win.Spread.SheetView();
			this.cmdAdd = new System.Windows.Forms.Button();
			this.cmdEdit = new System.Windows.Forms.Button();
			this.cmdDelete = new System.Windows.Forms.Button();
			this.cmdPrevious = new System.Windows.Forms.Button();
			this.gpbContract.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.fpsServiceStaff)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsServiceStaff_Sheet1)).BeginInit();
			this.SuspendLayout();
			// 
			// gpbContract
			// 
			this.gpbContract.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.gpbContract.Controls.Add(this.label8);
			this.gpbContract.Controls.Add(this.txtUnitHire);
			this.gpbContract.Controls.Add(this.label7);
			this.gpbContract.Controls.Add(this.dtpEndDate);
			this.gpbContract.Controls.Add(this.label6);
			this.gpbContract.Controls.Add(this.dtpStartDate);
			this.gpbContract.Controls.Add(this.label5);
			this.gpbContract.Controls.Add(this.txtContractType);
			this.gpbContract.Controls.Add(this.label4);
			this.gpbContract.Controls.Add(this.txtContractStatus);
			this.gpbContract.Controls.Add(this.label3);
			this.gpbContract.Controls.Add(this.txtCustomerTHName);
			this.gpbContract.Controls.Add(this.label2);
			this.gpbContract.Controls.Add(this.label12);
			this.gpbContract.Controls.Add(this.txtContractPrefix);
			this.gpbContract.Controls.Add(this.label15);
			this.gpbContract.Controls.Add(this.label22);
			this.gpbContract.Controls.Add(this.label23);
			this.gpbContract.Controls.Add(this.txtContractNoXXX);
			this.gpbContract.Controls.Add(this.txtContractNoMM);
			this.gpbContract.Controls.Add(this.txtContractNoYY);
			this.gpbContract.Controls.Add(this.label25);
			this.gpbContract.Controls.Add(this.label1);
			this.gpbContract.Enabled = false;
			this.gpbContract.Location = new System.Drawing.Point(122, 16);
			this.gpbContract.Name = "gpbContract";
			this.gpbContract.Size = new System.Drawing.Size(692, 144);
			this.gpbContract.TabIndex = 0;
			this.gpbContract.TabStop = false;
			this.gpbContract.Text = "รายละเอียดในสัญญา";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(520, 104);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(24, 23);
			this.label8.TabIndex = 57;
			this.label8.Text = "คน";
			// 
			// txtUnitHire
			// 
			this.txtUnitHire.Enabled = false;
			this.txtUnitHire.Location = new System.Drawing.Point(448, 104);
			this.txtUnitHire.Name = "txtUnitHire";
			this.txtUnitHire.Size = new System.Drawing.Size(56, 20);
			this.txtUnitHire.TabIndex = 56;
			this.txtUnitHire.Text = "";
			this.txtUnitHire.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(400, 104);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(40, 23);
			this.label7.TabIndex = 55;
			this.label7.Text = "จำนวน";
			// 
			// dtpEndDate
			// 
			this.dtpEndDate.CustomFormat = "dd/MM/yyyy";
			this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpEndDate.Location = new System.Drawing.Point(276, 104);
			this.dtpEndDate.Name = "dtpEndDate";
			this.dtpEndDate.Size = new System.Drawing.Size(96, 20);
			this.dtpEndDate.TabIndex = 54;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(212, 104);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(56, 23);
			this.label6.TabIndex = 53;
			this.label6.Text = "วันที่สิ้นสุด";
			// 
			// dtpStartDate
			// 
			this.dtpStartDate.CustomFormat = "dd/MM/yyyy";
			this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpStartDate.Location = new System.Drawing.Point(92, 104);
			this.dtpStartDate.Name = "dtpStartDate";
			this.dtpStartDate.Size = new System.Drawing.Size(96, 20);
			this.dtpStartDate.TabIndex = 52;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(20, 104);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(64, 23);
			this.label5.TabIndex = 51;
			this.label5.Text = "วันที่เริ่มต้น";
			// 
			// txtContractType
			// 
			this.txtContractType.Location = new System.Drawing.Point(396, 64);
			this.txtContractType.Name = "txtContractType";
			this.txtContractType.Size = new System.Drawing.Size(280, 20);
			this.txtContractType.TabIndex = 50;
			this.txtContractType.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(316, 64);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(72, 23);
			this.label4.TabIndex = 49;
			this.label4.Text = "ประเภทสัญญา";
			// 
			// txtContractStatus
			// 
			this.txtContractStatus.Location = new System.Drawing.Point(92, 64);
			this.txtContractStatus.Name = "txtContractStatus";
			this.txtContractStatus.Size = new System.Drawing.Size(168, 20);
			this.txtContractStatus.TabIndex = 48;
			this.txtContractStatus.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(20, 64);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 23);
			this.label3.TabIndex = 47;
			this.label3.Text = "สถานะสัญญา";
			// 
			// txtCustomerTHName
			// 
			this.txtCustomerTHName.Location = new System.Drawing.Point(396, 24);
			this.txtCustomerTHName.Name = "txtCustomerTHName";
			this.txtCustomerTHName.Size = new System.Drawing.Size(280, 20);
			this.txtCustomerTHName.TabIndex = 46;
			this.txtCustomerTHName.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(340, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 23);
			this.label2.TabIndex = 45;
			this.label2.Text = "ชื่อลูกค้า";
			// 
			// label12
			// 
			this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.label12.Location = new System.Drawing.Point(156, 24);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(8, 23);
			this.label12.TabIndex = 44;
			this.label12.Text = "-";
			// 
			// txtContractPrefix
			// 
			this.txtContractPrefix.Enabled = false;
			this.txtContractPrefix.Location = new System.Drawing.Point(132, 24);
			this.txtContractPrefix.Name = "txtContractPrefix";
			this.txtContractPrefix.Size = new System.Drawing.Size(24, 20);
			this.txtContractPrefix.TabIndex = 0;
			this.txtContractPrefix.TabStop = false;
			this.txtContractPrefix.Text = "C";            
			this.txtContractPrefix.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(236, 48);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(32, 16);
			this.label15.TabIndex = 42;
			this.label15.Text = "XXX";
			// 
			// label22
			// 
			this.label22.Location = new System.Drawing.Point(204, 48);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(24, 16);
			this.label22.TabIndex = 41;
			this.label22.Text = "MM";
			// 
			// label23
			// 
			this.label23.Location = new System.Drawing.Point(172, 48);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(24, 16);
			this.label23.TabIndex = 40;
			this.label23.Text = "YY";
			// 
			// txtContractNoXXX
			// 
			this.txtContractNoXXX.Location = new System.Drawing.Point(228, 24);
			this.txtContractNoXXX.MaxLength = 3;
			this.txtContractNoXXX.Name = "txtContractNoXXX";
			this.txtContractNoXXX.Size = new System.Drawing.Size(32, 20);
			this.txtContractNoXXX.TabIndex = 0;
			this.txtContractNoXXX.TabStop = false;
			this.txtContractNoXXX.Text = "";
			this.txtContractNoXXX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txtContractNoMM
			// 
			this.txtContractNoMM.Location = new System.Drawing.Point(196, 24);
			this.txtContractNoMM.MaxLength = 2;
			this.txtContractNoMM.Name = "txtContractNoMM";
			this.txtContractNoMM.Size = new System.Drawing.Size(32, 20);
			this.txtContractNoMM.TabIndex = 0;
			this.txtContractNoMM.TabStop = false;
			this.txtContractNoMM.Text = "";
			this.txtContractNoMM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txtContractNoYY
			// 
			this.txtContractNoYY.Location = new System.Drawing.Point(164, 24);
			this.txtContractNoYY.MaxLength = 2;
			this.txtContractNoYY.Name = "txtContractNoYY";
			this.txtContractNoYY.Size = new System.Drawing.Size(32, 20);
			this.txtContractNoYY.TabIndex = 0;
			this.txtContractNoYY.TabStop = false;
			this.txtContractNoYY.Text = "";
			this.txtContractNoYY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label25
			// 
			this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.label25.Location = new System.Drawing.Point(92, 24);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(40, 23);
			this.label25.TabIndex = 39;
			this.label25.Text = "PTB -";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(20, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "เลขที่สัญญา";
			// 
			// fpsServiceStaff
			// 
			this.fpsServiceStaff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.fpsServiceStaff.ContextMenu = this.contextMenu1;
			this.fpsServiceStaff.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
			this.fpsServiceStaff.Location = new System.Drawing.Point(8, 176);
			this.fpsServiceStaff.Name = "fpsServiceStaff";
			this.fpsServiceStaff.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
																						 this.fpsServiceStaff_Sheet1});
			this.fpsServiceStaff.Size = new System.Drawing.Size(921, 336);
			this.fpsServiceStaff.TabIndex = 1;
			this.fpsServiceStaff.TabStop = false;
			this.fpsServiceStaff.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpsServiceStaff_CellDoubleClick);
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
			this.mniAdd.Text = "เพิ่ม      ";
			this.mniAdd.Click += new System.EventHandler(this.mniAdd_Click);
			// 
			// mniEdit
			// 
			this.mniEdit.Index = 1;
			this.mniEdit.Text = "แก้ไข    ";
			this.mniEdit.Click += new System.EventHandler(this.mniEdit_Click);
			// 
			// mniDelete
			// 
			this.mniDelete.Index = 2;
			this.mniDelete.Text = "ลบ";
			this.mniDelete.Click += new System.EventHandler(this.mniDelete_Click);
			// 
			// fpsServiceStaff_Sheet1
			// 
			this.fpsServiceStaff_Sheet1.Reset();
			// Formulas and custom names must be loaded with R1C1 reference style
			this.fpsServiceStaff_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
			this.fpsServiceStaff_Sheet1.ColumnCount = 6;
			this.fpsServiceStaff_Sheet1.RowCount = 1;
			this.fpsServiceStaff_Sheet1.ColumnHeader.Cells.Get(0, 1).Text = "รหัสพนักงาน";
			this.fpsServiceStaff_Sheet1.ColumnHeader.Cells.Get(0, 2).Text = "ชื่อพนักงาน";
			this.fpsServiceStaff_Sheet1.ColumnHeader.Cells.Get(0, 3).Text = "ตำแหน่ง";
			this.fpsServiceStaff_Sheet1.ColumnHeader.Cells.Get(0, 4).Text = "ประเภทพนักงาน";
			this.fpsServiceStaff_Sheet1.ColumnHeader.Cells.Get(0, 5).Text = "ชื่อนายจ้าง";
			this.fpsServiceStaff_Sheet1.ColumnHeader.Columns.Default.Resizable = false;
			this.fpsServiceStaff_Sheet1.Columns.Default.Resizable = false;
			textCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType1.DropDownButton = false;
			this.fpsServiceStaff_Sheet1.Columns.Get(0).CellType = textCellType1;
			this.fpsServiceStaff_Sheet1.Columns.Get(0).Visible = false;
			this.fpsServiceStaff_Sheet1.Columns.Get(1).AllowAutoSort = true;
			textCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType2.DropDownButton = false;
			this.fpsServiceStaff_Sheet1.Columns.Get(1).CellType = textCellType2;
			this.fpsServiceStaff_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsServiceStaff_Sheet1.Columns.Get(1).Label = "รหัสพนักงาน";
			this.fpsServiceStaff_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
			this.fpsServiceStaff_Sheet1.Columns.Get(1).Width = 75F;
			this.fpsServiceStaff_Sheet1.Columns.Get(2).AllowAutoSort = true;
			textCellType3.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType3.DropDownButton = false;
			this.fpsServiceStaff_Sheet1.Columns.Get(2).CellType = textCellType3;
			this.fpsServiceStaff_Sheet1.Columns.Get(2).Label = "ชื่อพนักงาน";
			this.fpsServiceStaff_Sheet1.Columns.Get(2).Width = 159F;
			this.fpsServiceStaff_Sheet1.Columns.Get(3).AllowAutoSort = true;
			textCellType4.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType4.DropDownButton = false;
			this.fpsServiceStaff_Sheet1.Columns.Get(3).CellType = textCellType4;
			this.fpsServiceStaff_Sheet1.Columns.Get(3).Label = "ตำแหน่ง";
			this.fpsServiceStaff_Sheet1.Columns.Get(3).Width = 230F;
			this.fpsServiceStaff_Sheet1.Columns.Get(4).AllowAutoSort = true;
			this.fpsServiceStaff_Sheet1.Columns.Get(4).Label = "ประเภทพนักงาน";
			this.fpsServiceStaff_Sheet1.Columns.Get(4).Width = 242F;
			this.fpsServiceStaff_Sheet1.Columns.Get(5).AllowAutoSort = true;
			textCellType5.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType5.DropDownButton = false;
			this.fpsServiceStaff_Sheet1.Columns.Get(5).CellType = textCellType5;
			this.fpsServiceStaff_Sheet1.Columns.Get(5).Label = "ชื่อนายจ้าง";
			this.fpsServiceStaff_Sheet1.Columns.Get(5).Width = 159F;
			this.fpsServiceStaff_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
			this.fpsServiceStaff_Sheet1.RowHeader.Columns.Default.Resizable = false;
			this.fpsServiceStaff_Sheet1.RowHeader.Rows.Default.Resizable = false;
			this.fpsServiceStaff_Sheet1.Rows.Default.Resizable = false;
			this.fpsServiceStaff_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
			this.fpsServiceStaff_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
			this.fpsServiceStaff_Sheet1.SheetName = "Sheet1";
			this.fpsServiceStaff_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
			// 
			// cmdAdd
			// 
			this.cmdAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdAdd.Location = new System.Drawing.Point(351, 528);
			this.cmdAdd.Name = "cmdAdd";
			this.cmdAdd.TabIndex = 2;
			this.cmdAdd.Text = "เพิ่ม";
			this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
			// 
			// cmdEdit
			// 
			this.cmdEdit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdEdit.Location = new System.Drawing.Point(431, 528);
			this.cmdEdit.Name = "cmdEdit";
			this.cmdEdit.TabIndex = 3;
			this.cmdEdit.Text = "แก้ไข";
			this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
			// 
			// cmdDelete
			// 
			this.cmdDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdDelete.Location = new System.Drawing.Point(511, 528);
			this.cmdDelete.Name = "cmdDelete";
			this.cmdDelete.TabIndex = 4;
			this.cmdDelete.Text = "ลบ";
			this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
			// 
			// cmdPrevious
			// 
			this.cmdPrevious.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdPrevious.Location = new System.Drawing.Point(820, 528);
			this.cmdPrevious.Name = "cmdPrevious";
			this.cmdPrevious.Size = new System.Drawing.Size(88, 23);
			this.cmdPrevious.TabIndex = 1;
			this.cmdPrevious.Text = "กลับไปก่อนหน้า";
			this.cmdPrevious.Click += new System.EventHandler(this.cmdPrevious_Click);
			// 
			// frmServiceStaffMatchToContractDetail
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(936, 566);
			this.Controls.Add(this.cmdPrevious);
			this.Controls.Add(this.cmdDelete);
			this.Controls.Add(this.cmdEdit);
			this.Controls.Add(this.cmdAdd);
			this.Controls.Add(this.fpsServiceStaff);
			this.Controls.Add(this.gpbContract);
			this.Name = "frmServiceStaffMatchToContractDetail";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "ระบุพนักงานในสัญญา";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmServiceStaffMatchToContractDetail_Load);
			this.gpbContract.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.fpsServiceStaff)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsServiceStaff_Sheet1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region - private -	
		private bool isReadonly = true;	
		private ServiceStaffAssignment objServiceStaffAssignment;
		private frmMain mdiParent;
		private DocumentNo contractNo;
		private frmServiceStaffMatchToContract parentForm;
		private frmServiceStaffMatchToContractEntry frmEntry;
		#endregion

//		=============================== Property =================================
		private ServiceStaffContract objServiceStaffContract;
		public ServiceStaffContract ObjServiceStaffContract
		{
			set
			{
				objServiceStaffContract = value;
				txtContractNoYY.Text = value.ContractNo.Year.ToString();
				txtContractNoMM.Text = value.ContractNo.Month.ToString();
				txtContractNoXXX.Text = value.ContractNo.No.ToString();
				txtContractStatus.Text = value.AContractStatus.AName.Thai;
				txtContractType.Text = value.AContractType.AName.Thai;
                txtContractPrefix.Text = value.AContractTypeAbbreviation;
				txtCustomerTHName.Text = value.ACustomerDepartment.ACustomer.AName.English;
				txtUnitHire.Text = Convert.ToString(value.UnitHire);
				dtpStartDate.Value = value.APeriod.From.Date;
				dtpEndDate.Value = value.APeriod.To.Date;			
			}
			get
			{			
				return objServiceStaffContract;
			}		
		}

		private int selectedRow
		{
			get{return fpsServiceStaff_Sheet1.ActiveRowIndex;}
		}

		private string selectedKey
		{
			get{return fpsServiceStaff_Sheet1.Cells[selectedRow,0].Text;}
		}

		private ServiceStaffRole selectedServiceStaffRole
		{
			get{return objServiceStaffContract.ALatestServiceStaffRoleList[selectedKey];}
		}

		public ServiceStaffMatchToContractFacade FacadeServiceStaffMatchToContract
		{
			get{return parentForm.FacadeServiceStaffMatchToContract;}
		}

//		============================ Constructor ==============================
		public frmServiceStaffMatchToContractDetail(frmServiceStaffMatchToContract parentForm): base()
		{
			InitializeComponent();			
			this.parentForm = parentForm;
			frmEntry = new frmServiceStaffMatchToContractEntry(this);
			isReadonly = UserProfile.IsReadOnly("miContract", "miContractDocumentServiceStaffMatchToContract");
            this.title = UserProfile.GetFormName("miContract", "miContractDocumentServiceStaffMatchToContract");

		}
        public override string FormID()
        {
            return UserProfile.GetFormID("miContract", "miContractDocumentServiceStaffMatchToContract");
        }

//		============================== Private Method =================================
		private DocumentNo getContractNo()
		{
			contractNo = new DocumentNo(DOCUMENT_TYPE.CONTRACT, txtContractNoYY.Text, txtContractNoMM.Text, txtContractNoXXX.Text);
			return contractNo;
		}

		private ServiceStaffAssignment getServiceStaffAssignment(ServiceStaffContract aServiceStaffContract, ServiceStaffRole aServiceStaffRole)
		{	
			objServiceStaffAssignment = new ServiceStaffAssignment();
			objServiceStaffAssignment.AContract = aServiceStaffContract;
			objServiceStaffAssignment.APeriod.From = aServiceStaffContract.APeriod.From;
			objServiceStaffAssignment.APeriod.To = aServiceStaffContract.APeriod.To;
			objServiceStaffAssignment.AAssignedServiceStaff = aServiceStaffRole.AServiceStaff;
			return objServiceStaffAssignment;
		}

		private ServiceStaffAssignment getServiceStaffAssignment(ServiceStaffRole aServiceStaffRole, ServiceStaffContract aServiceStaffContract)
		{
			ServiceStaffAssignment serviceStaffAssignment = new ServiceStaffAssignment();
			serviceStaffAssignment.AAssignedServiceStaff = aServiceStaffRole.AServiceStaff;
			serviceStaffAssignment.AMainServiceStaff = aServiceStaffRole.AServiceStaff;
			serviceStaffAssignment.AContract = aServiceStaffContract;
			parentForm.FacadeServiceStaffMatchToContract.FillServiceStaffAssignment(ref serviceStaffAssignment);
			return serviceStaffAssignment;
		}

		private void bindForm(ServiceStaffContract value)
		{
			if (objServiceStaffContract.ALatestServiceStaffRoleList.Count != 0)
			{
				enableButton(true);
				fpsServiceStaff.Enabled = true;

				int iRow = objServiceStaffContract.ALatestServiceStaffRoleList.Count;
				fpsServiceStaff_Sheet1.RowCount = iRow;

				for(int i=0; i<iRow; i++)
				{
					bindServiceStaff(i, objServiceStaffContract.ALatestServiceStaffRoleList[i]);
				}

				if(value.AContractStatus.Code == "2")
				{
					enableCaseApprove(true);
				}
				else
				{
					enableCaseApprove(false);
				}
			}
			else
			{
				enableCaseApprove(true);
				fpsServiceStaff_Sheet1.RowCount = 0;				
				enableButton(false);				

				if(value.AContractStatus.Code != "2")
				{
					cmdAdd.Enabled = false;
					mniAdd.Enabled = false;
					cmdPrevious.Enabled = false;
					fpsServiceStaff.Enabled = false;
				}
			}			
		}	

		private void bindServiceStaff(int iRow, ServiceStaffRole value)
		{	
			fpsServiceStaff_Sheet1.Cells[iRow,0].Text = GUIFunction.GetString(value.EntityKey);
			fpsServiceStaff_Sheet1.Cells[iRow,1].Text = GUIFunction.GetString(value.AServiceStaff.EmployeeNo);
			fpsServiceStaff_Sheet1.Cells[iRow,2].Text = GUIFunction.GetString(value.AServiceStaff.EmployeeName);
			fpsServiceStaff_Sheet1.Cells[iRow,3].Text = GUIFunction.GetString(value.AServiceStaff.APosition.AName.Thai);
			fpsServiceStaff_Sheet1.Cells[iRow,4].Text = GUIFunction.GetString(value.AServiceStaffType.ADescription.English);

			ServiceStaffAssignment serviceStaffAssignment = getServiceStaffAssignment(value, objServiceStaffContract);
			if(serviceStaffAssignment != null && serviceStaffAssignment.AHirer != null)
			{
				fpsServiceStaff_Sheet1.Cells[iRow,5].Text = GUIFunction.GetString(serviceStaffAssignment.AHirer.Name);
			}
			serviceStaffAssignment = null;
		}
		
		private void clearForm()
		{
			txtContractNoYY.Text = "";
			txtContractNoMM.Text = "";
			txtContractNoXXX.Text = "";
			fpsServiceStaff_Sheet1.RowCount = 0;
			enableButton(true);
			cmdAdd.Enabled = true;
			mniAdd.Enabled = true;
			cmdPrevious.Enabled = true;
		}

		private void enableButton(bool enable)
		{
			cmdEdit.Enabled = enable;
			cmdDelete.Enabled = enable;
			mniEdit.Enabled = enable;
			mniDelete.Enabled = enable;
		}

		private void enableCaseApprove(bool enable)
		{
			cmdPrevious.Enabled = !enable;
			fpsServiceStaff.Enabled = enable;
			cmdAdd.Enabled = enable;
			cmdEdit.Enabled = enable;
			cmdDelete.Enabled = enable;
			mniAdd.Enabled = enable;
			mniEdit.Enabled = enable;
			mniDelete.Enabled = enable;
		}

        private void ControlPrefix(ContractType contractType)
        {
            txtContractPrefix.Text = contractType.Prefix;
        }

//		============================== Public Method =================================
		public void InitServiceStaffContract(ContractBase value)
		{	
			mdiParent = (frmMain)this.MdiParent;

			mdiParent.DisableCommand();
			clearMainMenuStatus();

            //this.Text = "ระบุพนักงานในสัญญา";
			clearForm();
			ObjServiceStaffContract = (ServiceStaffContract)value;
			bindForm(objServiceStaffContract);

			if(isReadonly)
			{
				cmdAdd.Enabled = false;
				mniAdd.Enabled = false;
				cmdDelete.Enabled = false;
				mniDelete.Enabled = false;
			}
		}

		public bool AddRow(ServiceStaff aServiceStaff, ServiceStaffAssignment aServiceStaffAssignment)
		{	
			ServiceStaffRole serviceStaffRole = new ServiceStaffRole();
			serviceStaffRole.AServiceStaff = aServiceStaff;
			serviceStaffRole.AServiceStaffType = aServiceStaff.AServiceStaffType;
			serviceStaffRole.ServiceStaffOrder = objServiceStaffContract.ALatestServiceStaffRoleList.Count + 1;

			aServiceStaffAssignment.EmployeeOrder = objServiceStaffContract.ALatestServiceStaffRoleList.Count + 1;

			aServiceStaff.ACurrentContract = objServiceStaffContract;

			objServiceStaffContract.ALatestServiceStaffRoleList.Add(serviceStaffRole);

			if(parentForm.FacadeServiceStaffMatchToContract.InsertServiceStaffMatchToContract(objServiceStaffContract, aServiceStaffAssignment, aServiceStaff))
			{
				bindForm(objServiceStaffContract);
				mdiParent.RefreshMasterCount();
				return true;
			}
			return false;
		}

		public bool UpdateRow(ServiceStaffRole aServiceStaffRole, ServiceStaffAssignment aServiceStaffAssignment, ServiceStaff aServiceStaff)
		{
			objServiceStaffContract.ALatestServiceStaffRoleList[aServiceStaffRole.EntityKey] = aServiceStaffRole;

			aServiceStaff.ACurrentContract = objServiceStaffContract;

			if (parentForm.FacadeServiceStaffMatchToContract.UpdateServiceStaffMatchToContract(objServiceStaffContract, aServiceStaffAssignment, aServiceStaff))
			{
				bindForm(objServiceStaffContract);	
				mdiParent.RefreshMasterCount();
				return true;
			}			
			return false;
		}

		public override int MasterCount()
		{
			return objServiceStaffContract.ALatestServiceStaffRoleList.Count;
		}

//		============================== Base Event ==============================
		public void InitForm()
		{
			mdiParent.DisableCommand();
			clearMainMenuStatus();
			mdiParent.RefreshMasterCount();
		}

		public void RefreshForm()
		{
		
		}

		public void PrintForm()
		{
		}

		public void ExitForm()
		{
//			mdiParent.EnableNewCommand(true);
//			mdiParent.EnableDeleteCommand(false);
//			mdiParent.EnableRefreshCommand(false);
//			mdiParent.EnablePrintCommand(false);
//			mdiParent.EnableExitCommand(true);	
			clearForm();
			this.Hide();
		}

		private void addEvent()
		{
			try
			{
				if(fpsServiceStaff_Sheet1.RowCount >= objServiceStaffContract.UnitHire)
				{
					Message(MessageList.Error.E0011, "จำนวนพนักงาน","จำนวนพนักงานในสัญญา");
				}
				else
				{
					frmEntry = new frmServiceStaffMatchToContractEntry(this);
					frmEntry.InitAddAction();
					frmEntry.ShowDialog();
				}
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
				ServiceStaffAssignment serviceStaffAssignment = getServiceStaffAssignment(ObjServiceStaffContract, selectedServiceStaffRole);

				if(!parentForm.FacadeServiceStaffMatchToContract.FillServiceStaffAssignment(ref serviceStaffAssignment))
				{
					Message(MessageList.Error.E0013, "แก้ไขรายการนี้ได้","พนักงานคนนี้ถูกจ่ายงานไปแล้ว");
				}
				else
				{
					frmEntry = new frmServiceStaffMatchToContractEntry(this);
					frmEntry.InitEditAction(selectedServiceStaffRole, serviceStaffAssignment);
					frmEntry.ShowDialog();				
				}
			}
			catch(SqlException sqlex)
			{Message(sqlex);}
			catch(AppExceptionBase ex)
			{Message(ex);}
			catch(Exception ex)
			{Message(ex);}		
		}

		private void deleteEvent()
		{
			try
			{
				ServiceStaffAssignment serviceStaffAssignment = getServiceStaffAssignment(objServiceStaffContract, selectedServiceStaffRole);

				if(!parentForm.FacadeServiceStaffMatchToContract.FillServiceStaffAssignment(ref serviceStaffAssignment))
				{
					Message(MessageList.Error.E0013, "ลบรายการนี้ได้","พนักงานคนนี้ถูกจ่ายงานไปแล้ว");
				}
				else if(objServiceStaffContract.AContractType.Code.Equals("D") && parentForm.FacadeServiceStaffMatchToContract.FillVDcontract(objServiceStaffContract))
				{
					Message(MessageList.Error.E0012, "ลบรายการนี้ได้","พนักงานคนนี้ถูกจับคู่กับรถยนต์ไปแล้ว", "ลบการจับคู่ของพนักงานคนนี้ก่อน");
				}
				else
				{
					if (Message(MessageList.Question.Q0001) == DialogResult.Yes)
					{
						if (FacadeServiceStaffMatchToContract.DeleteServiceStaffMatchToContract(objServiceStaffContract, selectedServiceStaffRole, serviceStaffAssignment))
						{
							ObjServiceStaffContract.ALatestServiceStaffRoleList.Remove(selectedServiceStaffRole);

							if(fpsServiceStaff_Sheet1.RowCount > 1)
							{
								fpsServiceStaff.ActiveSheet.Rows.Remove(selectedRow,1);
							}
							else
							{
								fpsServiceStaff_Sheet1.RowCount = 0;
								enableButton(false);
							}				
						}
					}
				}
				serviceStaffAssignment = null;
			}
			catch(SqlException sqlex)
			{Message(sqlex);}
			catch(AppExceptionBase ex)
			{Message(ex);}
			catch(Exception ex)
			{Message(ex);}		
		}
		
//		============================== Event =================================
		private void frmServiceStaffMatchToContractDetail_Load(object sender, System.EventArgs e)
		{
			mdiParent = (frmMain)this.MdiParent;
			InitForm();		
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

		private void mniAdd_Click(object sender, System.EventArgs e)
		{
			addEvent();
		}

		private void mniEdit_Click(object sender, System.EventArgs e)
		{
			editEvent();
		}

		private void mniDelete_Click(object sender, System.EventArgs e)
		{
			deleteEvent();
		}

		private void cmdPrevious_Click(object sender, System.EventArgs e)
		{
			ExitForm();
		}

		private void fpsServiceStaff_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
		{
			if(!e.ColumnHeader)
			{
				editEvent();
			}
		}	
	}
}
