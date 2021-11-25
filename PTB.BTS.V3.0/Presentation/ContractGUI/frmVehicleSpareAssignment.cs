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
using Facade.ContractFacade;

using Presentation.CommonGUI;
using Presentation.VehicleGUI;

using ictus.Common.Entity.Time;

namespace Presentation.ContractGUI
{
	public class frmVehicleSpareAssignment : ChildFormBase, IMDIChildForm
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
		private System.Windows.Forms.GroupBox grbVehicle;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lblDashText;
		private System.Windows.Forms.Label lblPlateNo;
		private System.Windows.Forms.Label lblDashLabel;
		private System.Windows.Forms.Label lblPlatePrefix;
		private System.Windows.Forms.TextBox txtPlatePrefix;
		private FarPoint.Win.Input.FpInteger fpiPlateRunningNo;
		private System.Windows.Forms.Label lblVehiclePlate;
		private FarPoint.Win.Input.FpInteger fpiNoOfSeat;
		private FarPoint.Win.Input.FpInteger fpiCC;
		private FarPoint.Win.Input.FpInteger fpiAgeYear;
		private FarPoint.Win.Input.FpInteger fpiAgeMonth;
		private System.Windows.Forms.TextBox txtModelTypeName;
		private System.Windows.Forms.TextBox txtModelName;
		private System.Windows.Forms.TextBox txtBrandName;
		private System.Windows.Forms.Label lblCC;
		private System.Windows.Forms.Label lblMonth;
		private System.Windows.Forms.Label lblYear;
		private System.Windows.Forms.Label lblAge;
		private System.Windows.Forms.Label lblNoOfSeat;
		private System.Windows.Forms.Label lblColor;
		private System.Windows.Forms.Label lblModelType;
		private System.Windows.Forms.Label lblModel;
		private System.Windows.Forms.Label lblBrand;
		private FarPoint.Win.Spread.FpSpread fpsVehicleSpareAssignment;
		private FarPoint.Win.Spread.SheetView fpsVehicleSpareAssignment_Sheet1;
		private System.Windows.Forms.Button cmdDelete;
		private System.Windows.Forms.Button cmdEdit;
		private System.Windows.Forms.Button cmdAdd;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem mniAdd;
		private System.Windows.Forms.MenuItem mniEdit;
		private System.Windows.Forms.MenuItem mniDelete;
		private System.Windows.Forms.TextBox txtColorName;
		private FarPoint.Win.Input.FpInteger fpiAgeCarYear;
		private FarPoint.Win.Input.FpInteger fpiAgeCarMonth;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
			FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType1 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmVehicleSpareAssignment));
			FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType2 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
			this.grbVehicle = new System.Windows.Forms.GroupBox();
			this.fpiAgeCarYear = new FarPoint.Win.Input.FpInteger();
			this.fpiAgeCarMonth = new FarPoint.Win.Input.FpInteger();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.lblDashText = new System.Windows.Forms.Label();
			this.lblPlateNo = new System.Windows.Forms.Label();
			this.lblDashLabel = new System.Windows.Forms.Label();
			this.lblPlatePrefix = new System.Windows.Forms.Label();
			this.txtPlatePrefix = new System.Windows.Forms.TextBox();
			this.fpiPlateRunningNo = new FarPoint.Win.Input.FpInteger();
			this.lblVehiclePlate = new System.Windows.Forms.Label();
			this.fpiNoOfSeat = new FarPoint.Win.Input.FpInteger();
			this.fpiCC = new FarPoint.Win.Input.FpInteger();
			this.fpiAgeYear = new FarPoint.Win.Input.FpInteger();
			this.fpiAgeMonth = new FarPoint.Win.Input.FpInteger();
			this.txtColorName = new System.Windows.Forms.TextBox();
			this.txtModelTypeName = new System.Windows.Forms.TextBox();
			this.txtModelName = new System.Windows.Forms.TextBox();
			this.txtBrandName = new System.Windows.Forms.TextBox();
			this.lblCC = new System.Windows.Forms.Label();
			this.lblMonth = new System.Windows.Forms.Label();
			this.lblYear = new System.Windows.Forms.Label();
			this.lblAge = new System.Windows.Forms.Label();
			this.lblNoOfSeat = new System.Windows.Forms.Label();
			this.lblColor = new System.Windows.Forms.Label();
			this.lblModelType = new System.Windows.Forms.Label();
			this.lblModel = new System.Windows.Forms.Label();
			this.lblBrand = new System.Windows.Forms.Label();
			this.fpsVehicleSpareAssignment = new FarPoint.Win.Spread.FpSpread();
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.mniAdd = new System.Windows.Forms.MenuItem();
			this.mniEdit = new System.Windows.Forms.MenuItem();
			this.mniDelete = new System.Windows.Forms.MenuItem();
			this.fpsVehicleSpareAssignment_Sheet1 = new FarPoint.Win.Spread.SheetView();
			this.cmdDelete = new System.Windows.Forms.Button();
			this.cmdEdit = new System.Windows.Forms.Button();
			this.cmdAdd = new System.Windows.Forms.Button();
			this.grbVehicle.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.fpsVehicleSpareAssignment)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsVehicleSpareAssignment_Sheet1)).BeginInit();
			this.SuspendLayout();
			// 
			// grbVehicle
			// 
			this.grbVehicle.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.grbVehicle.Controls.Add(this.fpiAgeCarYear);
			this.grbVehicle.Controls.Add(this.fpiAgeCarMonth);
			this.grbVehicle.Controls.Add(this.label1);
			this.grbVehicle.Controls.Add(this.label2);
			this.grbVehicle.Controls.Add(this.label3);
			this.grbVehicle.Controls.Add(this.lblDashText);
			this.grbVehicle.Controls.Add(this.lblPlateNo);
			this.grbVehicle.Controls.Add(this.lblDashLabel);
			this.grbVehicle.Controls.Add(this.lblPlatePrefix);
			this.grbVehicle.Controls.Add(this.txtPlatePrefix);
			this.grbVehicle.Controls.Add(this.fpiPlateRunningNo);
			this.grbVehicle.Controls.Add(this.lblVehiclePlate);
			this.grbVehicle.Controls.Add(this.fpiNoOfSeat);
			this.grbVehicle.Controls.Add(this.fpiCC);
			this.grbVehicle.Controls.Add(this.fpiAgeYear);
			this.grbVehicle.Controls.Add(this.fpiAgeMonth);
			this.grbVehicle.Controls.Add(this.txtColorName);
			this.grbVehicle.Controls.Add(this.txtModelTypeName);
			this.grbVehicle.Controls.Add(this.txtModelName);
			this.grbVehicle.Controls.Add(this.txtBrandName);
			this.grbVehicle.Controls.Add(this.lblCC);
			this.grbVehicle.Controls.Add(this.lblMonth);
			this.grbVehicle.Controls.Add(this.lblYear);
			this.grbVehicle.Controls.Add(this.lblAge);
			this.grbVehicle.Controls.Add(this.lblNoOfSeat);
			this.grbVehicle.Controls.Add(this.lblColor);
			this.grbVehicle.Controls.Add(this.lblModelType);
			this.grbVehicle.Controls.Add(this.lblModel);
			this.grbVehicle.Controls.Add(this.lblBrand);
			this.grbVehicle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.grbVehicle.Location = new System.Drawing.Point(14, 8);
			this.grbVehicle.Name = "grbVehicle";
			this.grbVehicle.Size = new System.Drawing.Size(662, 152);
			this.grbVehicle.TabIndex = 1;
			this.grbVehicle.TabStop = false;
			this.grbVehicle.Text = "ทะเบียนรถ";
			// 
			// fpiAgeCarYear
			// 
			this.fpiAgeCarYear.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Center;
			this.fpiAgeCarYear.AllowClipboardKeys = true;
			this.fpiAgeCarYear.ButtonMarginColor = System.Drawing.SystemColors.Control;
			this.fpiAgeCarYear.Enabled = false;
			this.fpiAgeCarYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.fpiAgeCarYear.Location = new System.Drawing.Point(488, 120);
			this.fpiAgeCarYear.Name = "fpiAgeCarYear";
			this.fpiAgeCarYear.Size = new System.Drawing.Size(40, 20);
			this.fpiAgeCarYear.TabIndex = 11;
			this.fpiAgeCarYear.Text = "";
			// 
			// fpiAgeCarMonth
			// 
			this.fpiAgeCarMonth.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Center;
			this.fpiAgeCarMonth.AllowClipboardKeys = true;
			this.fpiAgeCarMonth.ButtonMarginColor = System.Drawing.SystemColors.Control;
			this.fpiAgeCarMonth.Enabled = false;
			this.fpiAgeCarMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.fpiAgeCarMonth.Location = new System.Drawing.Point(568, 120);
			this.fpiAgeCarMonth.Name = "fpiAgeCarMonth";
			this.fpiAgeCarMonth.Size = new System.Drawing.Size(40, 20);
			this.fpiAgeCarMonth.TabIndex = 12;
			this.fpiAgeCarMonth.Text = "";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.label1.Location = new System.Drawing.Point(616, 120);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(27, 16);
			this.label1.TabIndex = 141;
			this.label1.Text = "เดือน";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.label2.Location = new System.Drawing.Point(536, 120);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(11, 16);
			this.label2.TabIndex = 140;
			this.label2.Text = "ปี";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.label3.Location = new System.Drawing.Point(376, 120);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(51, 16);
			this.label3.TabIndex = 139;
			this.label3.Text = "อายุรถยนต์";
			// 
			// lblDashText
			// 
			this.lblDashText.AutoSize = true;
			this.lblDashText.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.lblDashText.Location = new System.Drawing.Point(126, 21);
			this.lblDashText.Name = "lblDashText";
			this.lblDashText.Size = new System.Drawing.Size(15, 27);
			this.lblDashText.TabIndex = 136;
			this.lblDashText.Text = "-";
			// 
			// lblPlateNo
			// 
			this.lblPlateNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.lblPlateNo.Location = new System.Drawing.Point(279, 22);
			this.lblPlateNo.Name = "lblPlateNo";
			this.lblPlateNo.Size = new System.Drawing.Size(64, 24);
			this.lblPlateNo.TabIndex = 135;
			// 
			// lblDashLabel
			// 
			this.lblDashLabel.AutoSize = true;
			this.lblDashLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.lblDashLabel.Location = new System.Drawing.Point(264, 21);
			this.lblDashLabel.Name = "lblDashLabel";
			this.lblDashLabel.Size = new System.Drawing.Size(15, 27);
			this.lblDashLabel.TabIndex = 134;
			this.lblDashLabel.Text = "-";
			// 
			// lblPlatePrefix
			// 
			this.lblPlatePrefix.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.lblPlatePrefix.Location = new System.Drawing.Point(224, 22);
			this.lblPlatePrefix.Name = "lblPlatePrefix";
			this.lblPlatePrefix.Size = new System.Drawing.Size(40, 24);
			this.lblPlatePrefix.TabIndex = 133;
			// 
			// txtPlatePrefix
			// 
			this.txtPlatePrefix.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.txtPlatePrefix.Location = new System.Drawing.Point(88, 24);
			this.txtPlatePrefix.MaxLength = 3;
			this.txtPlatePrefix.Name = "txtPlatePrefix";
			this.txtPlatePrefix.Size = new System.Drawing.Size(36, 20);
			this.txtPlatePrefix.TabIndex = 1;
			this.txtPlatePrefix.Text = "";
			this.txtPlatePrefix.TextChanged += new System.EventHandler(this.txtPlatePrefix_TextChanged);
			// 
			// fpiPlateRunningNo
			// 
			this.fpiPlateRunningNo.AllowClipboardKeys = true;
			this.fpiPlateRunningNo.AllowNull = true;
			this.fpiPlateRunningNo.ButtonMarginColor = System.Drawing.SystemColors.Control;
			this.fpiPlateRunningNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.fpiPlateRunningNo.Location = new System.Drawing.Point(143, 24);
			this.fpiPlateRunningNo.MaxValue = 9999;
			this.fpiPlateRunningNo.MinValue = 0;
			this.fpiPlateRunningNo.Name = "fpiPlateRunningNo";
			this.fpiPlateRunningNo.NullColor = System.Drawing.Color.Transparent;
			this.fpiPlateRunningNo.Size = new System.Drawing.Size(65, 20);
			this.fpiPlateRunningNo.TabIndex = 2;
			this.fpiPlateRunningNo.Text = "";
			this.fpiPlateRunningNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fpiPlateRunningNo_KeyDown);
			this.fpiPlateRunningNo.DoubleClick += new System.EventHandler(this.fpiPlateRunningNo_DoubleClick);
			this.fpiPlateRunningNo.TextChanged += new System.EventHandler(this.fpiPlateRunningNo_TextChanged);
			// 
			// lblVehiclePlate
			// 
			this.lblVehiclePlate.AutoSize = true;
			this.lblVehiclePlate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.lblVehiclePlate.Location = new System.Drawing.Point(16, 24);
			this.lblVehiclePlate.Name = "lblVehiclePlate";
			this.lblVehiclePlate.Size = new System.Drawing.Size(50, 16);
			this.lblVehiclePlate.TabIndex = 132;
			this.lblVehiclePlate.Text = "ทะเบียนรถ";
			// 
			// fpiNoOfSeat
			// 
			this.fpiNoOfSeat.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Center;
			this.fpiNoOfSeat.AllowClipboardKeys = true;
			this.fpiNoOfSeat.ButtonMarginColor = System.Drawing.SystemColors.Control;
			this.fpiNoOfSeat.Enabled = false;
			this.fpiNoOfSeat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.fpiNoOfSeat.Location = new System.Drawing.Point(488, 56);
			this.fpiNoOfSeat.Name = "fpiNoOfSeat";
			this.fpiNoOfSeat.Size = new System.Drawing.Size(40, 20);
			this.fpiNoOfSeat.TabIndex = 5;
			this.fpiNoOfSeat.Text = "";
			// 
			// fpiCC
			// 
			this.fpiCC.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Center;
			this.fpiCC.AllowClipboardKeys = true;
			this.fpiCC.ButtonMarginColor = System.Drawing.SystemColors.Control;
			this.fpiCC.Enabled = false;
			this.fpiCC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.fpiCC.Location = new System.Drawing.Point(600, 56);
			this.fpiCC.Name = "fpiCC";
			this.fpiCC.Size = new System.Drawing.Size(48, 20);
			this.fpiCC.TabIndex = 6;
			this.fpiCC.Text = "";
			// 
			// fpiAgeYear
			// 
			this.fpiAgeYear.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Center;
			this.fpiAgeYear.AllowClipboardKeys = true;
			this.fpiAgeYear.ButtonMarginColor = System.Drawing.SystemColors.Control;
			this.fpiAgeYear.Enabled = false;
			this.fpiAgeYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.fpiAgeYear.Location = new System.Drawing.Point(488, 88);
			this.fpiAgeYear.Name = "fpiAgeYear";
			this.fpiAgeYear.Size = new System.Drawing.Size(40, 20);
			this.fpiAgeYear.TabIndex = 8;
			this.fpiAgeYear.Text = "";
			// 
			// fpiAgeMonth
			// 
			this.fpiAgeMonth.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Center;
			this.fpiAgeMonth.AllowClipboardKeys = true;
			this.fpiAgeMonth.ButtonMarginColor = System.Drawing.SystemColors.Control;
			this.fpiAgeMonth.Enabled = false;
			this.fpiAgeMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.fpiAgeMonth.Location = new System.Drawing.Point(568, 88);
			this.fpiAgeMonth.Name = "fpiAgeMonth";
			this.fpiAgeMonth.Size = new System.Drawing.Size(40, 20);
			this.fpiAgeMonth.TabIndex = 9;
			this.fpiAgeMonth.Text = "";
			// 
			// txtColorName
			// 
			this.txtColorName.Enabled = false;
			this.txtColorName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.txtColorName.Location = new System.Drawing.Point(488, 24);
			this.txtColorName.Name = "txtColorName";
			this.txtColorName.Size = new System.Drawing.Size(160, 20);
			this.txtColorName.TabIndex = 3;
			this.txtColorName.Text = "";
			// 
			// txtModelTypeName
			// 
			this.txtModelTypeName.Enabled = false;
			this.txtModelTypeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.txtModelTypeName.Location = new System.Drawing.Point(88, 120);
			this.txtModelTypeName.Name = "txtModelTypeName";
			this.txtModelTypeName.Size = new System.Drawing.Size(256, 20);
			this.txtModelTypeName.TabIndex = 10;
			this.txtModelTypeName.Text = "";
			// 
			// txtModelName
			// 
			this.txtModelName.Enabled = false;
			this.txtModelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.txtModelName.Location = new System.Drawing.Point(88, 88);
			this.txtModelName.Name = "txtModelName";
			this.txtModelName.Size = new System.Drawing.Size(256, 20);
			this.txtModelName.TabIndex = 7;
			this.txtModelName.Text = "";
			// 
			// txtBrandName
			// 
			this.txtBrandName.Enabled = false;
			this.txtBrandName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.txtBrandName.Location = new System.Drawing.Point(88, 56);
			this.txtBrandName.Name = "txtBrandName";
			this.txtBrandName.Size = new System.Drawing.Size(256, 20);
			this.txtBrandName.TabIndex = 4;
			this.txtBrandName.Text = "";
			// 
			// lblCC
			// 
			this.lblCC.AutoSize = true;
			this.lblCC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.lblCC.Location = new System.Drawing.Point(568, 56);
			this.lblCC.Name = "lblCC";
			this.lblCC.Size = new System.Drawing.Size(21, 16);
			this.lblCC.TabIndex = 131;
			this.lblCC.Text = "ซีซี.";
			// 
			// lblMonth
			// 
			this.lblMonth.AutoSize = true;
			this.lblMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.lblMonth.Location = new System.Drawing.Point(616, 88);
			this.lblMonth.Name = "lblMonth";
			this.lblMonth.Size = new System.Drawing.Size(27, 16);
			this.lblMonth.TabIndex = 130;
			this.lblMonth.Text = "เดือน";
			// 
			// lblYear
			// 
			this.lblYear.AutoSize = true;
			this.lblYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.lblYear.Location = new System.Drawing.Point(536, 88);
			this.lblYear.Name = "lblYear";
			this.lblYear.Size = new System.Drawing.Size(11, 16);
			this.lblYear.TabIndex = 129;
			this.lblYear.Text = "ปี";
			// 
			// lblAge
			// 
			this.lblAge.AutoSize = true;
			this.lblAge.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.lblAge.Location = new System.Drawing.Point(376, 88);
			this.lblAge.Name = "lblAge";
			this.lblAge.Size = new System.Drawing.Size(98, 16);
			this.lblAge.TabIndex = 128;
			this.lblAge.Text = "ระยะเวลาที่ครอบครอง";
			// 
			// lblNoOfSeat
			// 
			this.lblNoOfSeat.AutoSize = true;
			this.lblNoOfSeat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.lblNoOfSeat.Location = new System.Drawing.Point(376, 56);
			this.lblNoOfSeat.Name = "lblNoOfSeat";
			this.lblNoOfSeat.Size = new System.Drawing.Size(52, 16);
			this.lblNoOfSeat.TabIndex = 127;
			this.lblNoOfSeat.Text = "จำนวนที่นั่ง";
			// 
			// lblColor
			// 
			this.lblColor.AutoSize = true;
			this.lblColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.lblColor.Location = new System.Drawing.Point(376, 24);
			this.lblColor.Name = "lblColor";
			this.lblColor.Size = new System.Drawing.Size(22, 16);
			this.lblColor.TabIndex = 126;
			this.lblColor.Text = "สีรถ";
			// 
			// lblModelType
			// 
			this.lblModelType.AutoSize = true;
			this.lblModelType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.lblModelType.Location = new System.Drawing.Point(16, 120);
			this.lblModelType.Name = "lblModelType";
			this.lblModelType.Size = new System.Drawing.Size(62, 16);
			this.lblModelType.TabIndex = 125;
			this.lblModelType.Text = "ประเภทรุ่นรถ";
			// 
			// lblModel
			// 
			this.lblModel.AutoSize = true;
			this.lblModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.lblModel.Location = new System.Drawing.Point(16, 88);
			this.lblModel.Name = "lblModel";
			this.lblModel.Size = new System.Drawing.Size(28, 16);
			this.lblModel.TabIndex = 124;
			this.lblModel.Text = "รุ่นรถ";
			// 
			// lblBrand
			// 
			this.lblBrand.AutoSize = true;
			this.lblBrand.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.lblBrand.Location = new System.Drawing.Point(16, 56);
			this.lblBrand.Name = "lblBrand";
			this.lblBrand.Size = new System.Drawing.Size(34, 16);
			this.lblBrand.TabIndex = 123;
			this.lblBrand.Text = "ยี่ห้อรถ";
			// 
			// fpsVehicleSpareAssignment
			// 
			this.fpsVehicleSpareAssignment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.fpsVehicleSpareAssignment.ContextMenu = this.contextMenu1;
			this.fpsVehicleSpareAssignment.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
			this.fpsVehicleSpareAssignment.Location = new System.Drawing.Point(42, 168);
			this.fpsVehicleSpareAssignment.Name = "fpsVehicleSpareAssignment";
			this.fpsVehicleSpareAssignment.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
																								   this.fpsVehicleSpareAssignment_Sheet1});
			this.fpsVehicleSpareAssignment.Size = new System.Drawing.Size(606, 160);
			this.fpsVehicleSpareAssignment.TabIndex = 52;
			this.fpsVehicleSpareAssignment.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpsVehicleSpareAssignment_CellDoubleClick);
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
			// fpsVehicleSpareAssignment_Sheet1
			// 
			this.fpsVehicleSpareAssignment_Sheet1.Reset();
			// Formulas and custom names must be loaded with R1C1 reference style
			this.fpsVehicleSpareAssignment_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
			this.fpsVehicleSpareAssignment_Sheet1.ColumnCount = 4;
			this.fpsVehicleSpareAssignment_Sheet1.ColumnHeader.RowCount = 2;
			this.fpsVehicleSpareAssignment_Sheet1.RowCount = 1;
			this.fpsVehicleSpareAssignment_Sheet1.ColumnHeader.Cells.Get(0, 1).ColumnSpan = 2;
			this.fpsVehicleSpareAssignment_Sheet1.ColumnHeader.Cells.Get(0, 1).Text = "ระยะเวลาการใช้";
			this.fpsVehicleSpareAssignment_Sheet1.ColumnHeader.Cells.Get(0, 3).RowSpan = 2;
			this.fpsVehicleSpareAssignment_Sheet1.ColumnHeader.Cells.Get(0, 3).Text = "หมายเหตุ";
			this.fpsVehicleSpareAssignment_Sheet1.ColumnHeader.Cells.Get(1, 1).Text = "ตั้งแต่";
			this.fpsVehicleSpareAssignment_Sheet1.ColumnHeader.Cells.Get(1, 2).Text = "จนถึง";
			this.fpsVehicleSpareAssignment_Sheet1.ColumnHeader.Columns.Default.Resizable = false;
			this.fpsVehicleSpareAssignment_Sheet1.Columns.Default.Resizable = false;
			textCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType1.DropDownButton = false;
			this.fpsVehicleSpareAssignment_Sheet1.Columns.Get(0).CellType = textCellType1;
			this.fpsVehicleSpareAssignment_Sheet1.Columns.Get(0).Visible = false;
			this.fpsVehicleSpareAssignment_Sheet1.Columns.Get(1).AllowAutoSort = true;
			dateTimeCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			dateTimeCellType1.Calendar = new System.Globalization.GregorianCalendar(System.Globalization.GregorianCalendarTypes.Localized);
			dateTimeCellType1.DateDefault = new System.DateTime(2006, 5, 29, 13, 51, 26, 0);
			dateTimeCellType1.DropDownButton = false;
			dateTimeCellType1.TimeDefault = new System.DateTime(2006, 5, 29, 13, 51, 26, 0);
			this.fpsVehicleSpareAssignment_Sheet1.Columns.Get(1).CellType = dateTimeCellType1;
			this.fpsVehicleSpareAssignment_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsVehicleSpareAssignment_Sheet1.Columns.Get(1).Label = "ตั้งแต่";
			this.fpsVehicleSpareAssignment_Sheet1.Columns.Get(1).Width = 100F;
			this.fpsVehicleSpareAssignment_Sheet1.Columns.Get(2).AllowAutoSort = true;
			dateTimeCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			dateTimeCellType2.Calendar = new System.Globalization.GregorianCalendar(System.Globalization.GregorianCalendarTypes.Localized);
			dateTimeCellType2.DateDefault = new System.DateTime(2006, 5, 29, 13, 51, 30, 0);
			dateTimeCellType2.DropDownButton = false;
			dateTimeCellType2.TimeDefault = new System.DateTime(2006, 5, 29, 13, 51, 30, 0);
			this.fpsVehicleSpareAssignment_Sheet1.Columns.Get(2).CellType = dateTimeCellType2;
			this.fpsVehicleSpareAssignment_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsVehicleSpareAssignment_Sheet1.Columns.Get(2).Label = "จนถึง";
			this.fpsVehicleSpareAssignment_Sheet1.Columns.Get(2).Width = 100F;
			this.fpsVehicleSpareAssignment_Sheet1.Columns.Get(3).AllowAutoSort = true;
			textCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType2.DropDownButton = false;
			this.fpsVehicleSpareAssignment_Sheet1.Columns.Get(3).CellType = textCellType2;
			this.fpsVehicleSpareAssignment_Sheet1.Columns.Get(3).Width = 350F;
			this.fpsVehicleSpareAssignment_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.ReadOnly;
			this.fpsVehicleSpareAssignment_Sheet1.RowHeader.Columns.Default.Resizable = false;
			this.fpsVehicleSpareAssignment_Sheet1.RowHeader.Rows.Default.Resizable = false;
			this.fpsVehicleSpareAssignment_Sheet1.Rows.Default.Resizable = false;
			this.fpsVehicleSpareAssignment_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
			this.fpsVehicleSpareAssignment_Sheet1.SheetName = "Sheet1";
			this.fpsVehicleSpareAssignment_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
			// 
			// cmdDelete
			// 
			this.cmdDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cmdDelete.Location = new System.Drawing.Point(389, 344);
			this.cmdDelete.Name = "cmdDelete";
			this.cmdDelete.Size = new System.Drawing.Size(72, 24);
			this.cmdDelete.TabIndex = 55;
			this.cmdDelete.Text = "ลบ";
			this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
			// 
			// cmdEdit
			// 
			this.cmdEdit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cmdEdit.Location = new System.Drawing.Point(309, 344);
			this.cmdEdit.Name = "cmdEdit";
			this.cmdEdit.Size = new System.Drawing.Size(72, 24);
			this.cmdEdit.TabIndex = 54;
			this.cmdEdit.Text = "แก้ไข";
			this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
			// 
			// cmdAdd
			// 
			this.cmdAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cmdAdd.Location = new System.Drawing.Point(229, 344);
			this.cmdAdd.Name = "cmdAdd";
			this.cmdAdd.Size = new System.Drawing.Size(72, 24);
			this.cmdAdd.TabIndex = 53;
			this.cmdAdd.Text = "เพิ่ม";
			this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
			// 
			// frmVehicleSpareAssignment
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(690, 382);
			this.Controls.Add(this.cmdDelete);
			this.Controls.Add(this.cmdEdit);
			this.Controls.Add(this.cmdAdd);
			this.Controls.Add(this.grbVehicle);
			this.Controls.Add(this.fpsVehicleSpareAssignment);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "frmVehicleSpareAssignment";
            //this.Text = "การจ่ายงานภายในให้รถ Spare";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmVehicleSpareAssignment_Load);
			this.grbVehicle.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.fpsVehicleSpareAssignment)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsVehicleSpareAssignment_Sheet1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region - Private -
		private bool isReadonly = true;
		private bool isSetText = true;
		private frmMain mdiParent;
		private frmVehicleSpareAssignmentEntry frmEntry;

		private int SelectedRow
		{
			get{return fpsVehicleSpareAssignment_Sheet1.ActiveRowIndex;}
		}

		private string SelectedKey
		{
			get{return fpsVehicleSpareAssignment_Sheet1.Cells[SelectedRow,0].Text;}
		}

		private VehicleAssignment selectedVehicleAssignment
		{
			get{return facadeVehicleSpareAssignment.ObjVehicleAssignmentList[SelectedKey];}
		}

		private Vehicle getVehicle()
		{
			return facadeVehicleSpareAssignment.GetVehicle(txtPlatePrefix.Text, fpiPlateRunningNo.Text);
		}
		#endregion

		//		============================== Property ==============================
		private VehicleSpareAssignmentFacade facadeVehicleSpareAssignment;	
		public VehicleSpareAssignmentFacade FacadeVehicleSpareAssignment
		{
			get{return facadeVehicleSpareAssignment;}
		}

		private Vehicle aVehicle;
		private Vehicle AVehicle
		{
			set
			{
				isSetText = false;
				txtPlatePrefix.Text = value.PlatePrefix;
				fpiPlateRunningNo.Value = value.PlateRunningNo;
				txtBrandName.Text = value.AModel.ABrand.AName.English;
				txtColorName.Text = value.AColor.AName.English;
				txtModelName.Text = value.AModel.AName.English;
				txtModelTypeName.Text = value.AModel.AModelType.AName.Thai;
				fpiNoOfSeat.Value = value.AModel.NoOfSeat;
				fpiCC.Value = value.AModel.EngineCC;

				YearMonth yearMonth1 = facadeVehicleSpareAssignment.CalculateAge(value.BuyDate);
				fpiAgeYear.Value = yearMonth1.Year;
				fpiAgeMonth.Value = yearMonth1.Month;

				YearMonth yearMonth2 = facadeVehicleSpareAssignment.CalculateAge(value.RegisterDate);
				fpiAgeCarYear.Value = yearMonth2.Year;
				fpiAgeCarMonth.Value = yearMonth2.Month;

				aVehicle = value;
				isSetText = true;
			}
		}
		
//		============================== Constructor ==============================
		public frmVehicleSpareAssignment() : base()
		{
			InitializeComponent();
			isReadonly = UserProfile.IsReadOnly("miContract", "miContractAssignmentHistoryVehicelAssignment");
            this.title = UserProfile.GetFormName("miContract", "miContractAssignmentHistoryVehicelAssignment");

		}
        public override string FormID()
        {
            return UserProfile.GetFormID("miContract", "miContractAssignmentHistoryVehicelAssignment");
        }
//		==============================Private method ==============================
		#region - Enable Form -
		private void enableVehicle(bool enabled)
		{
			txtPlatePrefix.Enabled = enabled;
			fpiPlateRunningNo.Enabled = enabled;
		}

		private void clearVehicle()
		{
			txtBrandName.Text = "";
			txtColorName.Text = "";
			txtModelName.Text = "";
			txtModelTypeName.Text = "";

			fpiNoOfSeat.Value = 0;
			fpiCC.Value = 0;
			fpiAgeYear.Value = 0;
			fpiAgeMonth.Value = 0;
			fpiAgeCarYear.Value = 0;
			fpiAgeCarMonth.Value = 0;
		}
		private void visibleButton(bool visible)
		{
			cmdAdd.Visible = visible;
			cmdEdit.Visible = visible;
			cmdDelete.Visible = visible;
		}

		private void enableButton(bool enable)
		{
			mniEdit.Enabled = enable;
			cmdEdit.Enabled = enable;
			mniDelete.Enabled = enable;
			cmdDelete.Enabled = enable;
		}

		private void clearForm()
		{
			fpsVehicleSpareAssignment_Sheet1.RowCount = 0;
			fpsVehicleSpareAssignment.Enabled = true;
			cmdAdd.Enabled = true;
			mniAdd.Enabled = true;
			enableButton(false);
		}

		private void clearAll()
		{
			clearVehicle();
			clearForm();
			fpsVehicleSpareAssignment.Visible = false;			
			visibleButton(false);
			enableVehicle(true);
			txtPlatePrefix.Focus();
		}

		private void setForm()
		{
			fpsVehicleSpareAssignment_Sheet1.RowCount = 0;
			fpsVehicleSpareAssignment.Visible = true;
			enableVehicle(false);
		}

		#endregion - Enable Form -

		#region - validate -
		private bool validateVehiclePlate()
		{
			if(txtPlatePrefix.Text == "")
			{
				Message(MessageList.Error.E0002, "ทะเบียนรถ");
				txtPlatePrefix.Focus();
				return false;
			}
			else if(fpiPlateRunningNo.Text == "")
			{
				Message(MessageList.Error.E0002, "ทะเบียนรถ");
				fpiPlateRunningNo.Focus();
				return false;
			}
			else
			{return true;}
		}

		private bool validateAddEvent()
		{
			if(aVehicle.AVehicleStatus.Code != "1")
			{
				Message(MessageList.Error.E0013, "จ่ายงานให้รถคันนี้ได้","รถไม่อยู่ในสถานะที่พร้อมจะจ่ายงาน");
				txtPlatePrefix.Focus();
				return false;		
			}
			return true;
		}
		#endregion

		private VehicleAssignment getVehicleAssignment(Vehicle value)
		{
			VehicleAssignment objVehicleAssignment = new VehicleAssignment();
			objVehicleAssignment.AAssignedVehicle = value;
			objVehicleAssignment.AContract = new ContractBase();
			objVehicleAssignment.AContract.ContractNo = new DocumentNo("PTB-C-0000000");
			return objVehicleAssignment;
		}

		private void formVehicleList()
		{
            FrmVehicleList dialogVehicleList = new FrmVehicleList();
			dialogVehicleList.ConditionPlatePrefix = txtPlatePrefix.Text;		
			dialogVehicleList.ConditionPlateRunningNo = fpiPlateRunningNo.Text;
			dialogVehicleList.ShowDialog();			

			if(dialogVehicleList.Selected)
			{
				AVehicle = dialogVehicleList.SelectedVehicle;
				RefreshForm();
			}
		}
		
		private void bindForm()
		{
			if (facadeVehicleSpareAssignment.ObjVehicleAssignmentList.Count > 0)
			{	
				int iRow = facadeVehicleSpareAssignment.ObjVehicleAssignmentList.Count;
				fpsVehicleSpareAssignment_Sheet1.RowCount = iRow;
				for(int i=0; i<iRow; i++)
				{
					bindVehicleSpareAssignment(i, facadeVehicleSpareAssignment.ObjVehicleAssignmentList[i]);			
				}
                fpsVehicleSpareAssignment_Sheet1.SetActiveCell(fpsVehicleSpareAssignment_Sheet1.RowCount, 0);
			}
			else
			{
				fpsVehicleSpareAssignment_Sheet1.RowCount = 0;
				enableButton(false);
			}

            if (fpsVehicleSpareAssignment_Sheet1.RowCount == 0)
            {
                enableButton(false);
            }
            else
            {
                enableButton(true);
            }

            //Case advance assign vehicle : woranai 2008/10/30

            //if(aVehicle.AKindOfVehicle.Code == "Z")
            //{
            //    if(fpsVehicleSpareAssignment_Sheet1.RowCount == 0)
            //    {
            //        enableButton(false);
            //    }
            //    else
            //    {
            //        enableButton(true);	
            //    }
            //}
            //else
            //{
            //    enableButton(false);
            //    cmdAdd.Enabled = false;
            //    mniAdd.Enabled = false;
            //}

			mdiParent.RefreshMasterCount();
		}

		private void bindVehicleSpareAssignment(int row, VehicleAssignment value)
		{
			fpsVehicleSpareAssignment_Sheet1.Cells[row,0].Text = value.EntityKey;
			fpsVehicleSpareAssignment_Sheet1.Cells[row,1].Text = GUIFunction.GetString(value.APeriod.From.Date.ToShortDateString());
			fpsVehicleSpareAssignment_Sheet1.Cells[row,2].Text = GUIFunction.GetString(value.APeriod.To.Date.ToShortDateString());
			fpsVehicleSpareAssignment_Sheet1.Cells[row,3].Text = GUIFunction.GetString(value.AAssignmentReason.Name);
		}

//      ============================== Public Method  ============================
		public bool AddRow(VehicleAssignment value)
		{
			if (facadeVehicleSpareAssignment.InsertVehicleAssignment(value))
			{
				if(fpsVehicleSpareAssignment_Sheet1.RowCount == 0)
				{
					fpsVehicleSpareAssignment.Visible = true;
				}

				fpsVehicleSpareAssignment_Sheet1.RowCount++;
				bindVehicleSpareAssignment(fpsVehicleSpareAssignment_Sheet1.RowCount-1, value);
                fpsVehicleSpareAssignment_Sheet1.SetActiveCell(fpsVehicleSpareAssignment_Sheet1.RowCount, 0);
				enableButton(true);
				mdiParent.RefreshMasterCount();
				return true;
			}
			return false;
		}

		public bool UpdateRow(VehicleAssignment oldVehicleAssignment, VehicleAssignment newVehicleAssignment)
		{
			if (facadeVehicleSpareAssignment.UpdateVehicleAssignment(oldVehicleAssignment, newVehicleAssignment))
			{
				bindVehicleSpareAssignment(SelectedRow, newVehicleAssignment);				
				return true;
			}
			return false;
		}

		private void deleteRow()
		{
			if (facadeVehicleSpareAssignment.DeleteVehicleAssignment(selectedVehicleAssignment))
			{
				if(fpsVehicleSpareAssignment_Sheet1.RowCount > 1)
				{
					fpsVehicleSpareAssignment.ActiveSheet.Rows.Remove(SelectedRow,1);
				}
				else
				{clearForm();}	

				mdiParent.RefreshMasterCount();
			}
		}

		public override int MasterCount()
		{
			return facadeVehicleSpareAssignment.ObjVehicleAssignmentList.Count;
		}

//      ============================== Base Event ==============================
		public void InitForm()
		{
			mdiParent.DisableCommand();
			clearMainMenuStatus();
			txtPlatePrefix.Text = "";
			fpiPlateRunningNo.Text = "";
			clearAll();			
			facadeVehicleSpareAssignment = new VehicleSpareAssignmentFacade();
			frmEntry = new frmVehicleSpareAssignmentEntry(this);
			mdiParent.RefreshMasterCount();
		}

		public void RefreshForm()
		{
			try
			{
				if(aVehicle!=null && validateVehiclePlate())
				{
					visibleButton(true);
					facadeVehicleSpareAssignment.DisplayVehicleSpareAssignment(getVehicleAssignment(aVehicle));
					
					setForm();
					bindForm();

					MainMenuNewStatus = true;
					MainMenuDeleteStatus = false;
					MainMenuRefreshStatus = true;
					MainMenuPrintStatus = false;

					mdiParent.EnableNewCommand(true);
					mdiParent.EnableDeleteCommand(false);
					mdiParent.EnableRefreshCommand(true);
					mdiParent.EnablePrintCommand(false);
				}
			}
			catch(SqlException sqlex)
			{Message(sqlex);}
			catch(AppExceptionBase ex)
			{Message(ex);}
			catch(Exception ex)
			{Message(ex);}

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

		private void addEvent()
		{
			try
			{
				if(validateAddEvent())
				{
					frmEntry = new frmVehicleSpareAssignmentEntry(this);
					frmEntry.InitAddAction(aVehicle);
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
				frmEntry = new frmVehicleSpareAssignmentEntry(this);
				frmEntry.InitEditAction(selectedVehicleAssignment);
				frmEntry.ShowDialog();			
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
				if (Message(MessageList.Question.Q0001) == DialogResult.Yes)
				{
					deleteRow();
				}
			}
			catch(SqlException sqlex)
			{Message(sqlex);}
			catch(AppExceptionBase ex)
			{Message(ex);}
			catch(Exception ex)
			{Message(ex);}		
		}

//      ============================== Event ==============================
		private void frmVehicleSpareAssignment_Load(object sender, System.EventArgs e)
		{
			mdiParent = (frmMain)this.MdiParent;
			InitForm();
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

		private void fpsVehicleSpareAssignment_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
		{
			if(!e.ColumnHeader & cmdEdit.Enabled)
			{
				editEvent();
			}
		}

		private void fpiPlateRunningNo_DoubleClick(object sender, System.EventArgs e)
		{
			formVehicleList();
		}

		private void txtPlatePrefix_TextChanged(object sender, System.EventArgs e)
		{
			lblPlatePrefix.Text = txtPlatePrefix.Text;
            if (txtPlatePrefix.Text.Length == txtPlatePrefix.MaxLength)
			{
				fpiPlateRunningNo.Focus();
			}
		}

		private void fpiPlateRunningNo_TextChanged(object sender, System.EventArgs e)
		{
			lblPlateNo.Text = fpiPlateRunningNo.Text;
			if(isSetText)
			{
				lblPlateNo.Text = fpiPlateRunningNo.Text;
				if(fpiPlateRunningNo.Text.Length == 4)
				{
					if(validateVehiclePlate())
					{
						Vehicle vehicle = getVehicle();
						if(vehicle != null)
						{
							AVehicle = vehicle;
							RefreshForm();
						}
						else
						{
							Message(MessageList.Error.E0004, "เลขทะเบียนรถ");
							txtPlatePrefix.Focus();
							clearAll();
						}
						vehicle = null;
					}
				}
			}		
		}

		private void fpiPlateRunningNo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == System.Windows.Forms.Keys.Enter)
			{
				if(validateVehiclePlate())
				{
					Vehicle vehicle = getVehicle();
					if(vehicle != null)
					{
						AVehicle = vehicle;
						RefreshForm();
					}
					else
					{
						Message(MessageList.Error.E0004, "เลขทะเบียนรถ");
						txtPlatePrefix.Focus();
						clearAll();
					}
					vehicle = null;
				}
			}
		}
	}
}
