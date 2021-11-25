using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;

using Entity.CommonEntity;
using Entity.VehicleEntities;

using Facade.VehicleFacade;

using Presentation.CommonGUI;

using SystemFramework.AppException;
using SystemFramework.AppMessage;

using ictus.Common.Entity.Time;

namespace Presentation.VehicleGUI
{
	public class frmVehicleRepairingBase : ChildFormBase, IMDIChildForm
	{
		private System.Windows.Forms.GroupBox grbVehicle;
		#region Windows Form Designer generated code

		private System.Windows.Forms.Label lblPlateNo;
		private System.Windows.Forms.Label lblPlatePrefix;
		private System.Windows.Forms.Label lblVehiclePlate;
		private System.Windows.Forms.Label lblModel;
		private System.Windows.Forms.Label lblBrand;
		private System.Windows.Forms.Label lblDashLabel;
		private System.Windows.Forms.Label lblModelType;
		private System.Windows.Forms.Label lblDashText;
		private System.Windows.Forms.Label lblCC;
		private System.Windows.Forms.Label lblAge;
		private System.Windows.Forms.Label lblNoOfSeat;
		private System.Windows.Forms.Label lblColor;
		private System.Windows.Forms.Label lblMonth;
		private System.Windows.Forms.Label lblYear;

		private System.Windows.Forms.TextBox txtPlatePrefix;
		private FarPoint.Win.Input.FpInteger fpiPlateRunningNo;
		private FarPoint.Win.Input.FpInteger fpiNoOfSeat;
		private FarPoint.Win.Input.FpInteger fpiCC;
		private FarPoint.Win.Input.FpInteger fpiAgeYear;
		private FarPoint.Win.Input.FpInteger fpiAgeMonth;
		private System.Windows.Forms.TextBox txtModelTypeName;
		private System.Windows.Forms.TextBox txtModelName;
		private System.Windows.Forms.TextBox txtBrandName;
		private System.Windows.Forms.TextBox txtColor;
		protected System.Windows.Forms.Button cmdDelete;
		protected System.Windows.Forms.Button cmdEdit;
        protected System.Windows.Forms.Button cmdAdd;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private FarPoint.Win.Input.FpInteger fpiAgeYear2;
        private FarPoint.Win.Input.FpInteger fpiAgeMonth2;
        protected ContextMenuStrip ctmDetail;
        private ToolStripMenuItem mniAdd;
        private ToolStripMenuItem mniEdit;
        private ToolStripMenuItem mniDelete;
        private IContainer components;

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

		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.grbVehicle = new System.Windows.Forms.GroupBox();
            this.fpiAgeYear2 = new FarPoint.Win.Input.FpInteger();
            this.fpiAgeMonth2 = new FarPoint.Win.Input.FpInteger();
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
            this.txtColor = new System.Windows.Forms.TextBox();
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
            this.cmdDelete = new System.Windows.Forms.Button();
            this.cmdEdit = new System.Windows.Forms.Button();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.ctmDetail = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mniAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.mniEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mniDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.grbVehicle.SuspendLayout();
            this.ctmDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbVehicle
            // 
            this.grbVehicle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.grbVehicle.Controls.Add(this.fpiAgeYear2);
            this.grbVehicle.Controls.Add(this.fpiAgeMonth2);
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
            this.grbVehicle.Controls.Add(this.txtColor);
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
            this.grbVehicle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.grbVehicle.Location = new System.Drawing.Point(24, 8);
            this.grbVehicle.Name = "grbVehicle";
            this.grbVehicle.Size = new System.Drawing.Size(976, 144);
            this.grbVehicle.TabIndex = 0;
            this.grbVehicle.TabStop = false;
            this.grbVehicle.Text = "ทะเบียนรถ";
            // 
            // fpiAgeYear2
            // 
            this.fpiAgeYear2.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Center;
            this.fpiAgeYear2.AllowClipboardKeys = true;
            this.fpiAgeYear2.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpiAgeYear2.Enabled = false;
            this.fpiAgeYear2.Location = new System.Drawing.Point(560, 112);
            this.fpiAgeYear2.Name = "fpiAgeYear2";
            this.fpiAgeYear2.Size = new System.Drawing.Size(56, 22);
            this.fpiAgeYear2.TabIndex = 11;
            this.fpiAgeYear2.Text = "";
            // 
            // fpiAgeMonth2
            // 
            this.fpiAgeMonth2.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Center;
            this.fpiAgeMonth2.AllowClipboardKeys = true;
            this.fpiAgeMonth2.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpiAgeMonth2.Enabled = false;
            this.fpiAgeMonth2.Location = new System.Drawing.Point(656, 112);
            this.fpiAgeMonth2.Name = "fpiAgeMonth2";
            this.fpiAgeMonth2.Size = new System.Drawing.Size(56, 22);
            this.fpiAgeMonth2.TabIndex = 12;
            this.fpiAgeMonth2.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(720, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 17);
            this.label1.TabIndex = 141;
            this.label1.Text = "เดือน";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(624, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 17);
            this.label2.TabIndex = 140;
            this.label2.Text = "ปี";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(440, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 17);
            this.label3.TabIndex = 139;
            this.label3.Text = "อายุรถยนต์";
            // 
            // lblDashText
            // 
            this.lblDashText.AutoSize = true;
            this.lblDashText.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblDashText.Location = new System.Drawing.Point(136, 14);
            this.lblDashText.Name = "lblDashText";
            this.lblDashText.Size = new System.Drawing.Size(19, 25);
            this.lblDashText.TabIndex = 136;
            this.lblDashText.Text = "-";
            // 
            // lblPlateNo
            // 
            this.lblPlateNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblPlateNo.Location = new System.Drawing.Point(288, 15);
            this.lblPlateNo.Name = "lblPlateNo";
            this.lblPlateNo.Size = new System.Drawing.Size(70, 24);
            this.lblPlateNo.TabIndex = 135;
            // 
            // lblDashLabel
            // 
            this.lblDashLabel.AutoSize = true;
            this.lblDashLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblDashLabel.Location = new System.Drawing.Point(272, 14);
            this.lblDashLabel.Name = "lblDashLabel";
            this.lblDashLabel.Size = new System.Drawing.Size(19, 25);
            this.lblDashLabel.TabIndex = 134;
            this.lblDashLabel.Text = "-";
            // 
            // lblPlatePrefix
            // 
            this.lblPlatePrefix.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblPlatePrefix.Location = new System.Drawing.Point(232, 15);
            this.lblPlatePrefix.Name = "lblPlatePrefix";
            this.lblPlatePrefix.Size = new System.Drawing.Size(40, 24);
            this.lblPlatePrefix.TabIndex = 133;
            // 
            // txtPlatePrefix
            // 
            this.txtPlatePrefix.Location = new System.Drawing.Point(96, 16);
            this.txtPlatePrefix.MaxLength = 3;
            this.txtPlatePrefix.Name = "txtPlatePrefix";
            this.txtPlatePrefix.Size = new System.Drawing.Size(36, 23);
            this.txtPlatePrefix.TabIndex = 1;
            this.txtPlatePrefix.TextChanged += new System.EventHandler(this.txtPlatePrefix_TextChanged);
            // 
            // fpiPlateRunningNo
            // 
            this.fpiPlateRunningNo.AllowClipboardKeys = true;
            this.fpiPlateRunningNo.AllowNull = true;
            this.fpiPlateRunningNo.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpiPlateRunningNo.Location = new System.Drawing.Point(152, 16);
            this.fpiPlateRunningNo.MaxValue = 9999;
            this.fpiPlateRunningNo.MinValue = 0;
            this.fpiPlateRunningNo.Name = "fpiPlateRunningNo";
            this.fpiPlateRunningNo.NullColor = System.Drawing.Color.Transparent;
            this.fpiPlateRunningNo.Size = new System.Drawing.Size(64, 22);
            this.fpiPlateRunningNo.TabIndex = 2;
            this.fpiPlateRunningNo.Text = "";
            this.fpiPlateRunningNo.DoubleClick += new System.EventHandler(this.fpiPlateRunningNo_DoubleClick);
            this.fpiPlateRunningNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fpiPlateRunningNo_KeyDown);
            this.fpiPlateRunningNo.TextChanged += new System.EventHandler(this.fpiPlateRunningNo_TextChanged);
            // 
            // lblVehiclePlate
            // 
            this.lblVehiclePlate.AutoSize = true;
            this.lblVehiclePlate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblVehiclePlate.Location = new System.Drawing.Point(16, 18);
            this.lblVehiclePlate.Name = "lblVehiclePlate";
            this.lblVehiclePlate.Size = new System.Drawing.Size(65, 17);
            this.lblVehiclePlate.TabIndex = 132;
            this.lblVehiclePlate.Text = "ทะเบียนรถ";
            // 
            // fpiNoOfSeat
            // 
            this.fpiNoOfSeat.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Center;
            this.fpiNoOfSeat.AllowClipboardKeys = true;
            this.fpiNoOfSeat.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpiNoOfSeat.Enabled = false;
            this.fpiNoOfSeat.Location = new System.Drawing.Point(560, 48);
            this.fpiNoOfSeat.Name = "fpiNoOfSeat";
            this.fpiNoOfSeat.Size = new System.Drawing.Size(56, 22);
            this.fpiNoOfSeat.TabIndex = 5;
            this.fpiNoOfSeat.Text = "";
            // 
            // fpiCC
            // 
            this.fpiCC.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Center;
            this.fpiCC.AllowClipboardKeys = true;
            this.fpiCC.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpiCC.Enabled = false;
            this.fpiCC.Location = new System.Drawing.Point(704, 48);
            this.fpiCC.Name = "fpiCC";
            this.fpiCC.Size = new System.Drawing.Size(104, 22);
            this.fpiCC.TabIndex = 6;
            this.fpiCC.Text = "";
            // 
            // fpiAgeYear
            // 
            this.fpiAgeYear.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Center;
            this.fpiAgeYear.AllowClipboardKeys = true;
            this.fpiAgeYear.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpiAgeYear.Enabled = false;
            this.fpiAgeYear.Location = new System.Drawing.Point(560, 80);
            this.fpiAgeYear.Name = "fpiAgeYear";
            this.fpiAgeYear.Size = new System.Drawing.Size(56, 22);
            this.fpiAgeYear.TabIndex = 8;
            this.fpiAgeYear.Text = "";
            // 
            // fpiAgeMonth
            // 
            this.fpiAgeMonth.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Center;
            this.fpiAgeMonth.AllowClipboardKeys = true;
            this.fpiAgeMonth.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpiAgeMonth.Enabled = false;
            this.fpiAgeMonth.Location = new System.Drawing.Point(656, 80);
            this.fpiAgeMonth.Name = "fpiAgeMonth";
            this.fpiAgeMonth.Size = new System.Drawing.Size(56, 22);
            this.fpiAgeMonth.TabIndex = 9;
            this.fpiAgeMonth.Text = "";
            // 
            // txtColor
            // 
            this.txtColor.Enabled = false;
            this.txtColor.Location = new System.Drawing.Point(560, 16);
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(248, 23);
            this.txtColor.TabIndex = 3;
            // 
            // txtModelTypeName
            // 
            this.txtModelTypeName.Enabled = false;
            this.txtModelTypeName.Location = new System.Drawing.Point(96, 112);
            this.txtModelTypeName.Name = "txtModelTypeName";
            this.txtModelTypeName.Size = new System.Drawing.Size(312, 23);
            this.txtModelTypeName.TabIndex = 10;
            // 
            // txtModelName
            // 
            this.txtModelName.Enabled = false;
            this.txtModelName.Location = new System.Drawing.Point(96, 80);
            this.txtModelName.Name = "txtModelName";
            this.txtModelName.Size = new System.Drawing.Size(312, 23);
            this.txtModelName.TabIndex = 7;
            // 
            // txtBrandName
            // 
            this.txtBrandName.Enabled = false;
            this.txtBrandName.Location = new System.Drawing.Point(96, 48);
            this.txtBrandName.Name = "txtBrandName";
            this.txtBrandName.Size = new System.Drawing.Size(312, 23);
            this.txtBrandName.TabIndex = 4;
            // 
            // lblCC
            // 
            this.lblCC.AutoSize = true;
            this.lblCC.Location = new System.Drawing.Point(672, 50);
            this.lblCC.Name = "lblCC";
            this.lblCC.Size = new System.Drawing.Size(28, 17);
            this.lblCC.TabIndex = 131;
            this.lblCC.Text = "ซีซี.";
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Location = new System.Drawing.Point(720, 82);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(36, 17);
            this.lblMonth.TabIndex = 130;
            this.lblMonth.Text = "เดือน";
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(624, 82);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(16, 17);
            this.lblYear.TabIndex = 129;
            this.lblYear.Text = "ปี";
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Location = new System.Drawing.Point(440, 82);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(124, 17);
            this.lblAge.TabIndex = 128;
            this.lblAge.Text = "ระยะเวลาที่ครอบครอง";
            // 
            // lblNoOfSeat
            // 
            this.lblNoOfSeat.AutoSize = true;
            this.lblNoOfSeat.Location = new System.Drawing.Point(440, 50);
            this.lblNoOfSeat.Name = "lblNoOfSeat";
            this.lblNoOfSeat.Size = new System.Drawing.Size(69, 17);
            this.lblNoOfSeat.TabIndex = 127;
            this.lblNoOfSeat.Text = "จำนวนที่นั่ง";
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Location = new System.Drawing.Point(440, 18);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(30, 17);
            this.lblColor.TabIndex = 126;
            this.lblColor.Text = "สีรถ";
            // 
            // lblModelType
            // 
            this.lblModelType.AutoSize = true;
            this.lblModelType.Location = new System.Drawing.Point(16, 114);
            this.lblModelType.Name = "lblModelType";
            this.lblModelType.Size = new System.Drawing.Size(80, 17);
            this.lblModelType.TabIndex = 125;
            this.lblModelType.Text = "ประเภทรุ่นรถ";
            // 
            // lblModel
            // 
            this.lblModel.AutoSize = true;
            this.lblModel.Location = new System.Drawing.Point(16, 82);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(39, 17);
            this.lblModel.TabIndex = 124;
            this.lblModel.Text = "รุ่นรถ";
            // 
            // lblBrand
            // 
            this.lblBrand.AutoSize = true;
            this.lblBrand.Location = new System.Drawing.Point(16, 50);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(46, 17);
            this.lblBrand.TabIndex = 123;
            this.lblBrand.Text = "ยี่ห้อรถ";
            // 
            // cmdDelete
            // 
            this.cmdDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdDelete.Location = new System.Drawing.Point(555, 432);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(75, 23);
            this.cmdDelete.TabIndex = 15;
            this.cmdDelete.Text = "ลบ";
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmdEdit
            // 
            this.cmdEdit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdEdit.Location = new System.Drawing.Point(475, 432);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(75, 23);
            this.cmdEdit.TabIndex = 14;
            this.cmdEdit.Text = "แก้ไข";
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // cmdAdd
            // 
            this.cmdAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdAdd.Location = new System.Drawing.Point(395, 432);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(75, 23);
            this.cmdAdd.TabIndex = 13;
            this.cmdAdd.Text = "เพิ่ม";
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // ctmDetail
            // 
            this.ctmDetail.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniAdd,
            this.mniEdit,
            this.mniDelete});
            this.ctmDetail.Name = "ctmMenu";
            this.ctmDetail.ShowImageMargin = false;
            this.ctmDetail.Size = new System.Drawing.Size(128, 92);
            // 
            // mniAdd
            // 
            this.mniAdd.Name = "mniAdd";
            this.mniAdd.Size = new System.Drawing.Size(127, 22);
            this.mniAdd.Text = "เพิ่ม";
            this.mniAdd.Click += new System.EventHandler(this.mniAdd_Click);
            // 
            // mniEdit
            // 
            this.mniEdit.Name = "mniEdit";
            this.mniEdit.Size = new System.Drawing.Size(127, 22);
            this.mniEdit.Text = "แก้ไข";
            this.mniEdit.Click += new System.EventHandler(this.mniEdit_Click);
            // 
            // mniDelete
            // 
            this.mniDelete.Name = "mniDelete";
            this.mniDelete.Size = new System.Drawing.Size(127, 22);
            this.mniDelete.Text = "ลบ";
            this.mniDelete.Click += new System.EventHandler(this.mniDelete_Click);
            // 
            // frmVehicleRepairingBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1024, 486);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.cmdEdit);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.grbVehicle);
            this.Name = "frmVehicleRepairingBase";
            this.Text = "frmRepairingBase";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRepairingBase_Load);
            this.grbVehicle.ResumeLayout(false);
            this.grbVehicle.PerformLayout();
            this.ctmDetail.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		#region - Private - 
		private bool isReadonly = true;
		protected frmMain mdiParent;
		protected frmVehicleRepairingEntryBase frmEntry;			
		#endregion

		#region - Property - 
			public VehicleInfo ObjVehicleInfo
			{
				get
				{
					return facadeRepairing.VehicleRepairing.AVehicleInfo;
				}
				set
				{
					facadeRepairing.VehicleRepairing.AVehicleInfo = value;
				}
			}
			
			public VehicleRepairingBase ObjVehicleRepairing
			{
				get
				{
					return facadeRepairing.VehicleRepairing;
				}
				set
				{
					facadeRepairing.VehicleRepairing = value;
				}
			}

			protected VehicleRepairingFacadeBase facadeRepairing;
			public VehicleRepairingFacadeBase FacadeRepairing
			{
				get
				{
					return  facadeRepairing;
				}
			}
		#endregion

		//============================== Constructor ==============================
		protected frmVehicleRepairingBase() : base()
		{
			InitializeComponent();
		}

		#region - Private Method -
			protected virtual void newfrmEntry()
			{}

			private void enableHeader(bool value)
			{
				txtPlatePrefix.Enabled = value;
				fpiPlateRunningNo.Enabled = value;
			}
			
			private void clearHeader()
			{
				txtPlatePrefix.Text = "";
				fpiPlateRunningNo.Text = "";
				txtBrandName.Text = "";
				txtColor.Text = "";
				txtModelName.Text = "";
				fpiNoOfSeat.Value = 0;
				fpiCC.Value = 0;
				txtModelTypeName.Text = "";
				fpiAgeYear.Value = 0;
				fpiAgeMonth.Value = 0;
				fpiAgeYear2.Value = 0;
				fpiAgeMonth2.Value = 0;
			}

			private void displayHeader()
			{
				txtBrandName.Text = ObjVehicleInfo.AModel.ABrand.AName.English;
				txtColor.Text = ObjVehicleInfo.AColor.AName.English;
				txtModelName.Text = ObjVehicleInfo.AModel.AName.English;
				fpiNoOfSeat.Value = ObjVehicleInfo.AModel.NoOfSeat;
				fpiCC.Value = ObjVehicleInfo.AModel.EngineCC;
				txtModelTypeName.Text = ObjVehicleInfo.AModel.AModelType.AName.Thai;
				YearMonth yearMonth = facadeRepairing.CalculateAge(ObjVehicleInfo.BuyDate);
				fpiAgeYear.Value = yearMonth.Year;
				fpiAgeMonth.Value = yearMonth.Month;
				yearMonth = facadeRepairing.CalculateAge(ObjVehicleInfo.RegisterDate);
				fpiAgeYear2.Value = yearMonth.Year;
				fpiAgeMonth2.Value = yearMonth.Month;
			}

			protected virtual void visibleDetail(bool value){}

			protected virtual void displayDetail(){}

			protected virtual void clearDetail(){}

			private void visibleButton(bool value)
			{
				cmdAdd.Visible = value; 
				cmdEdit.Visible = value;
				cmdDelete.Visible = value;
			}

			protected void enableButton(bool value)
			{
				cmdEdit.Enabled = value;
				cmdDelete.Enabled = value;
				mniEdit.Enabled = value;
				mniDelete.Enabled = value;
			}

			protected void setPermission(bool value)
			{
				isReadonly = value;
			}
		#endregion

		//============================== Base Event ==============================
		public void InitForm()
		{
			enableHeader(true);
			clearHeader();
			visibleDetail(false);
			visibleButton(false);
		}

		public void RefreshForm()
		{
			try
			{
				if(ObjVehicleInfo != null && ObjVehicleInfo.PlatePrefix == txtPlatePrefix.Text && ObjVehicleInfo.PlateRunningNo == fpiPlateRunningNo.Text)
				{
					display(ObjVehicleInfo);
				}
				else
				{
					if(facadeRepairing.FillVehicle(txtPlatePrefix.Text, fpiPlateRunningNo.Text))
					{
						display(ObjVehicleInfo);
					}		
					else
					{
						Message(MessageList.Error.E0004, "ทะเบียนรถ");
						fpiPlateRunningNo.Focus();
					}
				}

				if(isReadonly)
				{
					cmdAdd.Enabled = false;
					cmdDelete.Enabled = false;
					mniAdd.Enabled = false;
					mniDelete.Enabled = false;
				}
			}
			catch(SqlException ex)
			{
				Message(ex);
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

		private void display(VehicleInfo value)
		{
			facadeRepairing.VehicleRepairing.AVehicleInfo = value;
			mdiParent.EnableNewCommand(true);	
			MainMenuNewStatus = true;	
			displayHeader();
			enableHeader(false);
			this.visibleDetail(true);
			visibleButton(true);
			enableButton(false);

			if(facadeRepairing.Display() && facadeRepairing.VehicleRepairing.Count>0)
			{
				this.displayDetail();				
			}
			else
			{
				this.clearDetail();
			}
		}

		public void PrintForm()
		{}

		public void ExitForm()
		{
			this.Close();
		}

		private void callList()
		{
			try
			{
                FrmVehicleList objfrmVehicleList = new FrmVehicleList();
				objfrmVehicleList.ConditionPlatePrefix = txtPlatePrefix.Text;
				objfrmVehicleList.ConditionPlateRunningNo = fpiPlateRunningNo.Text;
				objfrmVehicleList.ShowDialog();

				if(objfrmVehicleList != null && objfrmVehicleList.Selected)
				{
					ObjVehicleInfo = facadeRepairing.GetVehicleInfo(objfrmVehicleList.SelectedVehicle.VehicleNo);
					txtPlatePrefix.Text = ObjVehicleInfo.PlatePrefix;
					fpiPlateRunningNo.Text = ObjVehicleInfo.PlateRunningNo;
//					RefreshForm();
				}
			}
			catch(SqlException ex)
			{
				Message(ex);
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

		protected void AddEvent()
		{
			try
			{
				newfrmEntry();
				frmEntry.FormParent = this;
				frmEntry.InitAddAction(ObjVehicleInfo);

				frmEntry.ShowDialog();
			}
			catch(TransactionException ex)
			{
				Message(ex);
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

		protected virtual void EditEvent()
		{
		}

		protected virtual void DeleteEvent()
		{
		}
		//============================== Public Method ==============================
        public virtual bool AddRow(RepairingInfoBase value)
		{
			if (facadeRepairing.InsertRepairing(value))
			{
				enableButton(true);
				return true;
			}
			else
			{				
				return false;
			}
		}

        public virtual bool EditRow(RepairingInfoBase value)
		{
			if (facadeRepairing.UpdateRepairing(value))
			{
				return true;
			}
			else
			{				
				return false;
			}
		}

		//============================== event ==============================
		private void frmRepairingBase_Load(object sender, System.EventArgs e)
		{
			mdiParent = (frmMain) this.MdiParent;
			InitForm();
		}

		private void txtPlatePrefix_TextChanged(object sender, System.EventArgs e)
		{
			lblPlatePrefix.Text = txtPlatePrefix.Text;
            if (txtPlatePrefix.TextLength == txtPlatePrefix.MaxLength)
			{
				fpiPlateRunningNo.Focus();
			}
		}

		private void fpiPlateRunningNo_TextChanged(object sender, System.EventArgs e)
		{
			lblPlateNo.Text = fpiPlateRunningNo.Text;
			if(fpiPlateRunningNo.Text.Length == 4 && txtPlatePrefix.TextLength == txtPlatePrefix.MaxLength)
			{
				RefreshForm();
			}
		}

		private void fpiPlateRunningNo_DoubleClick(object sender, System.EventArgs e)
		{		
			callList();
			if(txtPlatePrefix.Text.Trim()!="" && fpiPlateRunningNo.Text.Trim()!="")
			{
				RefreshForm();			
			}
		}

		private void fpiPlateRunningNo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				if(txtPlatePrefix.TextLength == 0)
				{
					Message(MessageList.Error.E0002, "ทะเบียนรถ");
					txtPlatePrefix.Focus();
				}
				else
				{
					if(fpiPlateRunningNo.Text == "")
					{
						Message(MessageList.Error.E0002, "ทะเบียนรถ");
						fpiPlateRunningNo.Focus();
					}
					else
					{
						RefreshForm();
					}
				}
			}
		}

		private void cmdAdd_Click(object sender, System.EventArgs e)
		{
			AddEvent();
		}

		private void mniAdd_Click(object sender, System.EventArgs e)
		{
			AddEvent();
		}

		private void cmdEdit_Click(object sender, System.EventArgs e)
		{
			EditEvent();
		}

		private void mniEdit_Click(object sender, System.EventArgs e)
		{
			EditEvent();
		}

		private void cmdDelete_Click(object sender, System.EventArgs e)
		{
			DeleteEvent();
		}

		private void mniDelete_Click(object sender, System.EventArgs e)
		{
			DeleteEvent();
		}
	}
}