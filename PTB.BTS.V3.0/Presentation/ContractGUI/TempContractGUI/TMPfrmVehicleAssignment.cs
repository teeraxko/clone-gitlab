//using System;
//using System.Drawing;
//using System.Collections;
//using System.ComponentModel;
//using System.Windows.Forms;
//using System.Data.SqlClient;

//using SystemFramework.AppMessage;
//using SystemFramework.AppException;
//using SystemFramework.AppConfig;

//using Entity.CommonEntity;
//using Entity.VehicleEntities;
//using Entity.ContractEntities;

//using Facade.CommonFacade;
//using Facade.ContractFacade;

//using Presentation.CommonGUI;
//using Presentation.VehicleGUI;

//using ictus.Common.Entity.Time;

//namespace Presentation.ContractGUI
//{
//    public class TMPfrmVehicleAssignment : ChildFormBase, IMDIChildForm
//    {
//        protected override void Dispose( bool disposing )
//        {
//            if( disposing )
//            {
//                if(components != null)
//                {
//                    components.Dispose();
//                }
//            }
//            base.Dispose( disposing );
//        }

//        #region Windows Form Designer generated code
//        private System.Windows.Forms.Button cmdAdd;
//        private System.Windows.Forms.Button cmdEdit;
//        private System.Windows.Forms.Button cmdDelete;
//        private System.Windows.Forms.ContextMenu contextMenu1;
//        private System.Windows.Forms.MenuItem mniAdd;
//        private System.Windows.Forms.MenuItem mniEdit;
//        private System.Windows.Forms.MenuItem mniDelete;
//        private FarPoint.Win.Input.FpInteger fpiNoOfSeat;
//        private FarPoint.Win.Input.FpInteger fpiCC;
//        private FarPoint.Win.Input.FpInteger fpiAgeYear;
//        private FarPoint.Win.Input.FpInteger fpiAgeMonth;
//        private System.Windows.Forms.TextBox txtColorName;
//        private System.Windows.Forms.TextBox txtModelTypeName;
//        private System.Windows.Forms.TextBox txtModelName;
//        private System.Windows.Forms.TextBox txtBrandName;
//        private System.Windows.Forms.Label label11;
//        private System.Windows.Forms.Label label10;
//        private System.Windows.Forms.Label label9;
//        private System.Windows.Forms.Label label8;
//        private System.Windows.Forms.Label label7;
//        private System.Windows.Forms.Label label6;
//        private System.Windows.Forms.Label label5;
//        private System.Windows.Forms.Label label4;
//        private System.Windows.Forms.Label label3;
//        private System.Windows.Forms.TextBox txtPlatePrefix;
//        private FarPoint.Win.Input.FpInteger fpiPlateRunningNo;
//        private System.Windows.Forms.Label label2;
//        private System.Windows.Forms.Label label1;
//        private System.Windows.Forms.GroupBox gpbVehicle;
//        private FarPoint.Win.Spread.FpSpread fpsVehicleAssignment;
//        private FarPoint.Win.Spread.SheetView fpsVehicleAssignment_Sheet1;
//        private System.Windows.Forms.Label lblPlateNo;
//        private System.Windows.Forms.Label label23;
//        private System.Windows.Forms.Label lblPlatePrefix;
//        private FarPoint.Win.Input.FpInteger fpiAgeCarYear;
//        private FarPoint.Win.Input.FpInteger fpiAgeCarMonth;
//        private System.Windows.Forms.Label label12;
//        private System.Windows.Forms.Label label13;
//        private System.Windows.Forms.Label label14;
//        private System.Windows.Forms.Label label15;
//        private System.Windows.Forms.TextBox txtContractPrefix;
//        private System.Windows.Forms.TextBox txtContractNoXXX;
//        private System.Windows.Forms.TextBox txtContractNoMM;
//        private System.Windows.Forms.TextBox txtContractNoYY;
//        private System.Windows.Forms.Label label25;
//        private System.Windows.Forms.Label label26;
//        private System.Windows.Forms.Label label16;
//        private System.Windows.Forms.Label label17;
//        private System.Windows.Forms.TextBox txtCurrentDep;
//        private System.Windows.Forms.TextBox txtCurrentCustomer;
	
//        private System.ComponentModel.Container components = null;
	
//        private void InitializeComponent()
//        {
//            this.gpbVehicle = new System.Windows.Forms.GroupBox();
//            this.txtCurrentDep = new System.Windows.Forms.TextBox();
//            this.label17 = new System.Windows.Forms.Label();
//            this.txtCurrentCustomer = new System.Windows.Forms.TextBox();
//            this.label16 = new System.Windows.Forms.Label();
//            this.label15 = new System.Windows.Forms.Label();
//            this.txtContractPrefix = new System.Windows.Forms.TextBox();
//            this.txtContractNoXXX = new System.Windows.Forms.TextBox();
//            this.txtContractNoMM = new System.Windows.Forms.TextBox();
//            this.txtContractNoYY = new System.Windows.Forms.TextBox();
//            this.label25 = new System.Windows.Forms.Label();
//            this.label26 = new System.Windows.Forms.Label();
//            this.fpiAgeCarYear = new FarPoint.Win.Input.FpInteger();
//            this.fpiAgeCarMonth = new FarPoint.Win.Input.FpInteger();
//            this.label12 = new System.Windows.Forms.Label();
//            this.label13 = new System.Windows.Forms.Label();
//            this.label14 = new System.Windows.Forms.Label();
//            this.lblPlateNo = new System.Windows.Forms.Label();
//            this.label23 = new System.Windows.Forms.Label();
//            this.lblPlatePrefix = new System.Windows.Forms.Label();
//            this.txtPlatePrefix = new System.Windows.Forms.TextBox();
//            this.fpiPlateRunningNo = new FarPoint.Win.Input.FpInteger();
//            this.label2 = new System.Windows.Forms.Label();
//            this.label1 = new System.Windows.Forms.Label();
//            this.fpiNoOfSeat = new FarPoint.Win.Input.FpInteger();
//            this.fpiCC = new FarPoint.Win.Input.FpInteger();
//            this.fpiAgeYear = new FarPoint.Win.Input.FpInteger();
//            this.fpiAgeMonth = new FarPoint.Win.Input.FpInteger();
//            this.txtColorName = new System.Windows.Forms.TextBox();
//            this.txtModelTypeName = new System.Windows.Forms.TextBox();
//            this.txtModelName = new System.Windows.Forms.TextBox();
//            this.txtBrandName = new System.Windows.Forms.TextBox();
//            this.label11 = new System.Windows.Forms.Label();
//            this.label10 = new System.Windows.Forms.Label();
//            this.label9 = new System.Windows.Forms.Label();
//            this.label8 = new System.Windows.Forms.Label();
//            this.label7 = new System.Windows.Forms.Label();
//            this.label6 = new System.Windows.Forms.Label();
//            this.label5 = new System.Windows.Forms.Label();
//            this.label4 = new System.Windows.Forms.Label();
//            this.label3 = new System.Windows.Forms.Label();
//            this.cmdAdd = new System.Windows.Forms.Button();
//            this.cmdEdit = new System.Windows.Forms.Button();
//            this.cmdDelete = new System.Windows.Forms.Button();
//            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
//            this.mniAdd = new System.Windows.Forms.MenuItem();
//            this.mniEdit = new System.Windows.Forms.MenuItem();
//            this.mniDelete = new System.Windows.Forms.MenuItem();
//            this.fpsVehicleAssignment = new FarPoint.Win.Spread.FpSpread();
//            this.fpsVehicleAssignment_Sheet1 = new FarPoint.Win.Spread.SheetView();
//            this.gpbVehicle.SuspendLayout();
//            this.SuspendLayout();
//            // 
//            // gpbVehicle
//            // 
//            this.gpbVehicle.Anchor = System.Windows.Forms.AnchorStyles.Top;
//            this.gpbVehicle.Controls.Add(this.txtCurrentDep);
//            this.gpbVehicle.Controls.Add(this.label17);
//            this.gpbVehicle.Controls.Add(this.txtCurrentCustomer);
//            this.gpbVehicle.Controls.Add(this.label16);
//            this.gpbVehicle.Controls.Add(this.label15);
//            this.gpbVehicle.Controls.Add(this.txtContractPrefix);
//            this.gpbVehicle.Controls.Add(this.txtContractNoXXX);
//            this.gpbVehicle.Controls.Add(this.txtContractNoMM);
//            this.gpbVehicle.Controls.Add(this.txtContractNoYY);
//            this.gpbVehicle.Controls.Add(this.label25);
//            this.gpbVehicle.Controls.Add(this.label26);
//            this.gpbVehicle.Controls.Add(this.fpiAgeCarYear);
//            this.gpbVehicle.Controls.Add(this.fpiAgeCarMonth);
//            this.gpbVehicle.Controls.Add(this.label12);
//            this.gpbVehicle.Controls.Add(this.label13);
//            this.gpbVehicle.Controls.Add(this.label14);
//            this.gpbVehicle.Controls.Add(this.lblPlateNo);
//            this.gpbVehicle.Controls.Add(this.label23);
//            this.gpbVehicle.Controls.Add(this.lblPlatePrefix);
//            this.gpbVehicle.Controls.Add(this.txtPlatePrefix);
//            this.gpbVehicle.Controls.Add(this.fpiPlateRunningNo);
//            this.gpbVehicle.Controls.Add(this.label2);
//            this.gpbVehicle.Controls.Add(this.label1);
//            this.gpbVehicle.Controls.Add(this.fpiNoOfSeat);
//            this.gpbVehicle.Controls.Add(this.fpiCC);
//            this.gpbVehicle.Controls.Add(this.fpiAgeYear);
//            this.gpbVehicle.Controls.Add(this.fpiAgeMonth);
//            this.gpbVehicle.Controls.Add(this.txtColorName);
//            this.gpbVehicle.Controls.Add(this.txtModelTypeName);
//            this.gpbVehicle.Controls.Add(this.txtModelName);
//            this.gpbVehicle.Controls.Add(this.txtBrandName);
//            this.gpbVehicle.Controls.Add(this.label11);
//            this.gpbVehicle.Controls.Add(this.label10);
//            this.gpbVehicle.Controls.Add(this.label9);
//            this.gpbVehicle.Controls.Add(this.label8);
//            this.gpbVehicle.Controls.Add(this.label7);
//            this.gpbVehicle.Controls.Add(this.label6);
//            this.gpbVehicle.Controls.Add(this.label5);
//            this.gpbVehicle.Controls.Add(this.label4);
//            this.gpbVehicle.Controls.Add(this.label3);
//            this.gpbVehicle.Location = new System.Drawing.Point(24, 16);
//            this.gpbVehicle.Name = "gpbVehicle";
//            this.gpbVehicle.Size = new System.Drawing.Size(888, 184);
//            this.gpbVehicle.TabIndex = 0;
//            this.gpbVehicle.TabStop = false;
//            this.gpbVehicle.Text = "ทะเบียนรถ";
//            // 
//            // txtCurrentDep
//            // 
//            this.txtCurrentDep.Enabled = false;
//            this.txtCurrentDep.Location = new System.Drawing.Point(648, 152);
//            this.txtCurrentDep.Name = "txtCurrentDep";
//            this.txtCurrentDep.Size = new System.Drawing.Size(88, 20);
//            this.txtCurrentDep.TabIndex = 139;
//            this.txtCurrentDep.Text = "";
//            // 
//            // label17
//            // 
//            this.label17.Location = new System.Drawing.Point(568, 152);
//            this.label17.Name = "label17";
//            this.label17.Size = new System.Drawing.Size(80, 23);
//            this.label17.TabIndex = 138;
//            this.label17.Text = "ฝ่ายลูกค้าปัจจุบัน";
//            // 
//            // txtCurrentCustomer
//            // 
//            this.txtCurrentCustomer.Enabled = false;
//            this.txtCurrentCustomer.Location = new System.Drawing.Point(432, 152);
//            this.txtCurrentCustomer.Name = "txtCurrentCustomer";
//            this.txtCurrentCustomer.Size = new System.Drawing.Size(96, 20);
//            this.txtCurrentCustomer.TabIndex = 137;
//            this.txtCurrentCustomer.Text = "";
//            // 
//            // label16
//            // 
//            this.label16.Location = new System.Drawing.Point(352, 152);
//            this.label16.Name = "label16";
//            this.label16.Size = new System.Drawing.Size(80, 23);
//            this.label16.TabIndex = 136;
//            this.label16.Text = "ชื่อลูกค้าปัจจุบัน";
//            // 
//            // label15
//            // 
//            this.label15.Anchor = System.Windows.Forms.AnchorStyles.Top;
//            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
//            this.label15.Location = new System.Drawing.Point(208, 152);
//            this.label15.Name = "label15";
//            this.label15.Size = new System.Drawing.Size(8, 23);
//            this.label15.TabIndex = 132;
//            this.label15.Text = "-";
//            // 
//            // txtContractPrefix
//            // 
//            this.txtContractPrefix.Anchor = System.Windows.Forms.AnchorStyles.Top;
//            this.txtContractPrefix.Enabled = false;
//            this.txtContractPrefix.Location = new System.Drawing.Point(184, 152);
//            this.txtContractPrefix.Name = "txtContractPrefix";
//            this.txtContractPrefix.Size = new System.Drawing.Size(24, 20);
//            this.txtContractPrefix.TabIndex = 131;
//            this.txtContractPrefix.TabStop = false;
//            this.txtContractPrefix.Text = "C";
//            this.txtContractPrefix.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
//            // 
//            // txtContractNoXXX
//            // 
//            this.txtContractNoXXX.Anchor = System.Windows.Forms.AnchorStyles.Top;
//            this.txtContractNoXXX.Enabled = false;
//            this.txtContractNoXXX.Location = new System.Drawing.Point(280, 152);
//            this.txtContractNoXXX.MaxLength = 3;
//            this.txtContractNoXXX.Name = "txtContractNoXXX";
//            this.txtContractNoXXX.Size = new System.Drawing.Size(32, 20);
//            this.txtContractNoXXX.TabIndex = 135;
//            this.txtContractNoXXX.Text = "";
//            this.txtContractNoXXX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
//            // 
//            // txtContractNoMM
//            // 
//            this.txtContractNoMM.Anchor = System.Windows.Forms.AnchorStyles.Top;
//            this.txtContractNoMM.Enabled = false;
//            this.txtContractNoMM.Location = new System.Drawing.Point(248, 152);
//            this.txtContractNoMM.MaxLength = 2;
//            this.txtContractNoMM.Name = "txtContractNoMM";
//            this.txtContractNoMM.Size = new System.Drawing.Size(32, 20);
//            this.txtContractNoMM.TabIndex = 134;
//            this.txtContractNoMM.Text = "";
//            this.txtContractNoMM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
//            // 
//            // txtContractNoYY
//            // 
//            this.txtContractNoYY.Anchor = System.Windows.Forms.AnchorStyles.Top;
//            this.txtContractNoYY.Enabled = false;
//            this.txtContractNoYY.Location = new System.Drawing.Point(216, 152);
//            this.txtContractNoYY.MaxLength = 2;
//            this.txtContractNoYY.Name = "txtContractNoYY";
//            this.txtContractNoYY.Size = new System.Drawing.Size(32, 20);
//            this.txtContractNoYY.TabIndex = 133;
//            this.txtContractNoYY.Text = "";
//            this.txtContractNoYY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
//            // 
//            // label25
//            // 
//            this.label25.Anchor = System.Windows.Forms.AnchorStyles.Top;
//            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
//            this.label25.Location = new System.Drawing.Point(136, 152);
//            this.label25.Name = "label25";
//            this.label25.Size = new System.Drawing.Size(48, 23);
//            this.label25.TabIndex = 130;
//            this.label25.Text = "PTB  -";
//            // 
//            // label26
//            // 
//            this.label26.Anchor = System.Windows.Forms.AnchorStyles.Top;
//            this.label26.Location = new System.Drawing.Point(40, 152);
//            this.label26.Name = "label26";
//            this.label26.Size = new System.Drawing.Size(88, 23);
//            this.label26.TabIndex = 129;
//            this.label26.Text = "เลขที่สัญญาปัจจุบัน";
//            // 
//            // fpiAgeCarYear
//            // 
//            this.fpiAgeCarYear.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Center;
//            this.fpiAgeCarYear.AllowClipboardKeys = true;
//            this.fpiAgeCarYear.ButtonMarginColor = System.Drawing.SystemColors.Control;
//            this.fpiAgeCarYear.Enabled = false;
//            this.fpiAgeCarYear.Location = new System.Drawing.Point(600, 120);
//            this.fpiAgeCarYear.MaxValue = 100;
//            this.fpiAgeCarYear.MinValue = 0;
//            this.fpiAgeCarYear.Name = "fpiAgeCarYear";
//            this.fpiAgeCarYear.Size = new System.Drawing.Size(40, 20);
//            this.fpiAgeCarYear.TabIndex = 128;
//            this.fpiAgeCarYear.Text = "";
//            this.fpiAgeCarYear.UserEntry = FarPoint.Win.Input.UserEntry.FreeFormat;
//            // 
//            // fpiAgeCarMonth
//            // 
//            this.fpiAgeCarMonth.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Center;
//            this.fpiAgeCarMonth.AllowClipboardKeys = true;
//            this.fpiAgeCarMonth.ButtonMarginColor = System.Drawing.SystemColors.Control;
//            this.fpiAgeCarMonth.Enabled = false;
//            this.fpiAgeCarMonth.Location = new System.Drawing.Point(696, 120);
//            this.fpiAgeCarMonth.MaxValue = 12;
//            this.fpiAgeCarMonth.MinValue = 0;
//            this.fpiAgeCarMonth.Name = "fpiAgeCarMonth";
//            this.fpiAgeCarMonth.Size = new System.Drawing.Size(40, 20);
//            this.fpiAgeCarMonth.TabIndex = 127;
//            this.fpiAgeCarMonth.Text = "";
//            // 
//            // label12
//            // 
//            this.label12.Location = new System.Drawing.Point(744, 120);
//            this.label12.Name = "label12";
//            this.label12.Size = new System.Drawing.Size(32, 23);
//            this.label12.TabIndex = 126;
//            this.label12.Text = "เดือน";
//            // 
//            // label13
//            // 
//            this.label13.Location = new System.Drawing.Point(656, 120);
//            this.label13.Name = "label13";
//            this.label13.Size = new System.Drawing.Size(16, 23);
//            this.label13.TabIndex = 125;
//            this.label13.Text = "ปี";
//            // 
//            // label14
//            // 
//            this.label14.Location = new System.Drawing.Point(480, 120);
//            this.label14.Name = "label14";
//            this.label14.Size = new System.Drawing.Size(72, 23);
//            this.label14.TabIndex = 124;
//            this.label14.Text = "อายุรถยนต์";
//            // 
//            // lblPlateNo
//            // 
//            this.lblPlateNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
//            this.lblPlateNo.Location = new System.Drawing.Point(312, 22);
//            this.lblPlateNo.Name = "lblPlateNo";
//            this.lblPlateNo.Size = new System.Drawing.Size(72, 24);
//            this.lblPlateNo.TabIndex = 112;
//            // 
//            // label23
//            // 
//            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
//            this.label23.Location = new System.Drawing.Point(288, 22);
//            this.label23.Name = "label23";
//            this.label23.Size = new System.Drawing.Size(8, 24);
//            this.label23.TabIndex = 111;
//            this.label23.Text = "-";
//            // 
//            // lblPlatePrefix
//            // 
//            this.lblPlatePrefix.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
//            this.lblPlatePrefix.Location = new System.Drawing.Point(256, 22);
//            this.lblPlatePrefix.Name = "lblPlatePrefix";
//            this.lblPlatePrefix.Size = new System.Drawing.Size(40, 24);
//            this.lblPlatePrefix.TabIndex = 110;
//            // 
//            // txtPlatePrefix
//            // 
//            this.txtPlatePrefix.Anchor = System.Windows.Forms.AnchorStyles.Top;
//            this.txtPlatePrefix.Location = new System.Drawing.Point(128, 24);
//            this.txtPlatePrefix.MaxLength = 2;
//            this.txtPlatePrefix.Name = "txtPlatePrefix";
//            this.txtPlatePrefix.Size = new System.Drawing.Size(36, 20);
//            this.txtPlatePrefix.TabIndex = 107;
//            this.txtPlatePrefix.Text = "";
//            this.txtPlatePrefix.TextChanged += new System.EventHandler(this.txtPlatePrefix_TextChanged);
//            // 
//            // fpiPlateRunningNo
//            // 
//            this.fpiPlateRunningNo.AllowClipboardKeys = true;
//            this.fpiPlateRunningNo.AllowNull = true;
//            this.fpiPlateRunningNo.Anchor = System.Windows.Forms.AnchorStyles.Top;
//            this.fpiPlateRunningNo.ButtonMarginColor = System.Drawing.SystemColors.Control;
//            this.fpiPlateRunningNo.Location = new System.Drawing.Point(184, 24);
//            this.fpiPlateRunningNo.MaxValue = 9999;
//            this.fpiPlateRunningNo.MinValue = 0;
//            this.fpiPlateRunningNo.Name = "fpiPlateRunningNo";
//            this.fpiPlateRunningNo.NullColor = System.Drawing.Color.Transparent;
//            this.fpiPlateRunningNo.Size = new System.Drawing.Size(48, 20);
//            this.fpiPlateRunningNo.TabIndex = 108;
//            this.fpiPlateRunningNo.Text = "";
//            this.fpiPlateRunningNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fpiPlateRunningNo_KeyDown);
//            this.fpiPlateRunningNo.DoubleClick += new System.EventHandler(this.fpiPlateRunningNo_DoubleClick);
//            this.fpiPlateRunningNo.TextChanged += new System.EventHandler(this.fpiPlateRunningNo_TextChanged);
//            // 
//            // label2
//            // 
//            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
//            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
//            this.label2.Location = new System.Drawing.Point(168, 24);
//            this.label2.Name = "label2";
//            this.label2.Size = new System.Drawing.Size(8, 16);
//            this.label2.TabIndex = 109;
//            this.label2.Text = "-";
//            // 
//            // label1
//            // 
//            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
//            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
//            this.label1.Location = new System.Drawing.Point(40, 24);
//            this.label1.Name = "label1";
//            this.label1.Size = new System.Drawing.Size(56, 23);
//            this.label1.TabIndex = 106;
//            this.label1.Text = "ทะเบียนรถ";
//            // 
//            // fpiNoOfSeat
//            // 
//            this.fpiNoOfSeat.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Center;
//            this.fpiNoOfSeat.AllowClipboardKeys = true;
//            this.fpiNoOfSeat.Anchor = System.Windows.Forms.AnchorStyles.Top;
//            this.fpiNoOfSeat.ButtonMarginColor = System.Drawing.SystemColors.Control;
//            this.fpiNoOfSeat.Enabled = false;
//            this.fpiNoOfSeat.Location = new System.Drawing.Point(600, 56);
//            this.fpiNoOfSeat.MaxValue = 999;
//            this.fpiNoOfSeat.MinValue = 0;
//            this.fpiNoOfSeat.Name = "fpiNoOfSeat";
//            this.fpiNoOfSeat.Size = new System.Drawing.Size(40, 20);
//            this.fpiNoOfSeat.TabIndex = 105;
//            this.fpiNoOfSeat.Text = "";
//            // 
//            // fpiCC
//            // 
//            this.fpiCC.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Center;
//            this.fpiCC.AllowClipboardKeys = true;
//            this.fpiCC.Anchor = System.Windows.Forms.AnchorStyles.Top;
//            this.fpiCC.ButtonMarginColor = System.Drawing.SystemColors.Control;
//            this.fpiCC.Enabled = false;
//            this.fpiCC.Location = new System.Drawing.Point(696, 56);
//            this.fpiCC.Name = "fpiCC";
//            this.fpiCC.Size = new System.Drawing.Size(48, 20);
//            this.fpiCC.TabIndex = 104;
//            this.fpiCC.Text = "";
//            // 
//            // fpiAgeYear
//            // 
//            this.fpiAgeYear.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Center;
//            this.fpiAgeYear.AllowClipboardKeys = true;
//            this.fpiAgeYear.Anchor = System.Windows.Forms.AnchorStyles.Top;
//            this.fpiAgeYear.ButtonMarginColor = System.Drawing.SystemColors.Control;
//            this.fpiAgeYear.Enabled = false;
//            this.fpiAgeYear.Location = new System.Drawing.Point(600, 88);
//            this.fpiAgeYear.Name = "fpiAgeYear";
//            this.fpiAgeYear.Size = new System.Drawing.Size(40, 20);
//            this.fpiAgeYear.TabIndex = 102;
//            this.fpiAgeYear.Text = "";
//            // 
//            // fpiAgeMonth
//            // 
//            this.fpiAgeMonth.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Center;
//            this.fpiAgeMonth.AllowClipboardKeys = true;
//            this.fpiAgeMonth.Anchor = System.Windows.Forms.AnchorStyles.Top;
//            this.fpiAgeMonth.ButtonMarginColor = System.Drawing.SystemColors.Control;
//            this.fpiAgeMonth.Enabled = false;
//            this.fpiAgeMonth.Location = new System.Drawing.Point(696, 88);
//            this.fpiAgeMonth.Name = "fpiAgeMonth";
//            this.fpiAgeMonth.Size = new System.Drawing.Size(40, 20);
//            this.fpiAgeMonth.TabIndex = 101;
//            this.fpiAgeMonth.Text = "";
//            // 
//            // txtColorName
//            // 
//            this.txtColorName.Anchor = System.Windows.Forms.AnchorStyles.Top;
//            this.txtColorName.Enabled = false;
//            this.txtColorName.Location = new System.Drawing.Point(600, 24);
//            this.txtColorName.Name = "txtColorName";
//            this.txtColorName.Size = new System.Drawing.Size(248, 20);
//            this.txtColorName.TabIndex = 96;
//            this.txtColorName.Text = "";
//            // 
//            // txtModelTypeName
//            // 
//            this.txtModelTypeName.Anchor = System.Windows.Forms.AnchorStyles.Top;
//            this.txtModelTypeName.Enabled = false;
//            this.txtModelTypeName.Location = new System.Drawing.Point(128, 120);
//            this.txtModelTypeName.Name = "txtModelTypeName";
//            this.txtModelTypeName.Size = new System.Drawing.Size(312, 20);
//            this.txtModelTypeName.TabIndex = 94;
//            this.txtModelTypeName.Text = "";
//            // 
//            // txtModelName
//            // 
//            this.txtModelName.Anchor = System.Windows.Forms.AnchorStyles.Top;
//            this.txtModelName.Enabled = false;
//            this.txtModelName.Location = new System.Drawing.Point(128, 88);
//            this.txtModelName.Name = "txtModelName";
//            this.txtModelName.Size = new System.Drawing.Size(312, 20);
//            this.txtModelName.TabIndex = 92;
//            this.txtModelName.Text = "";
//            // 
//            // txtBrandName
//            // 
//            this.txtBrandName.Anchor = System.Windows.Forms.AnchorStyles.Top;
//            this.txtBrandName.Enabled = false;
//            this.txtBrandName.Location = new System.Drawing.Point(128, 56);
//            this.txtBrandName.Name = "txtBrandName";
//            this.txtBrandName.Size = new System.Drawing.Size(312, 20);
//            this.txtBrandName.TabIndex = 90;
//            this.txtBrandName.Text = "";
//            // 
//            // label11
//            // 
//            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Top;
//            this.label11.Location = new System.Drawing.Point(672, 56);
//            this.label11.Name = "label11";
//            this.label11.Size = new System.Drawing.Size(32, 23);
//            this.label11.TabIndex = 103;
//            this.label11.Text = "ซีซี.";
//            // 
//            // label10
//            // 
//            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Top;
//            this.label10.Location = new System.Drawing.Point(744, 88);
//            this.label10.Name = "label10";
//            this.label10.Size = new System.Drawing.Size(32, 23);
//            this.label10.TabIndex = 100;
//            this.label10.Text = "เดือน";
//            // 
//            // label9
//            // 
//            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Top;
//            this.label9.Location = new System.Drawing.Point(656, 88);
//            this.label9.Name = "label9";
//            this.label9.Size = new System.Drawing.Size(16, 23);
//            this.label9.TabIndex = 99;
//            this.label9.Text = "ปี";
//            // 
//            // label8
//            // 
//            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
//            this.label8.Location = new System.Drawing.Point(480, 88);
//            this.label8.Name = "label8";
//            this.label8.Size = new System.Drawing.Size(104, 23);
//            this.label8.TabIndex = 98;
//            this.label8.Text = "ระยะเวลาที่ครอบครอง";
//            // 
//            // label7
//            // 
//            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
//            this.label7.Location = new System.Drawing.Point(480, 56);
//            this.label7.Name = "label7";
//            this.label7.Size = new System.Drawing.Size(64, 23);
//            this.label7.TabIndex = 97;
//            this.label7.Text = "จำนวนที่นั่ง";
//            // 
//            // label6
//            // 
//            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
//            this.label6.Location = new System.Drawing.Point(480, 24);
//            this.label6.Name = "label6";
//            this.label6.Size = new System.Drawing.Size(24, 23);
//            this.label6.TabIndex = 95;
//            this.label6.Text = "สีรถ";
//            // 
//            // label5
//            // 
//            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
//            this.label5.Location = new System.Drawing.Point(40, 120);
//            this.label5.Name = "label5";
//            this.label5.Size = new System.Drawing.Size(64, 23);
//            this.label5.TabIndex = 93;
//            this.label5.Text = "ประเภทรุ่นรถ";
//            // 
//            // label4
//            // 
//            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
//            this.label4.Location = new System.Drawing.Point(40, 88);
//            this.label4.Name = "label4";
//            this.label4.Size = new System.Drawing.Size(32, 23);
//            this.label4.TabIndex = 91;
//            this.label4.Text = "รุ่นรถ";
//            // 
//            // label3
//            // 
//            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
//            this.label3.Location = new System.Drawing.Point(40, 56);
//            this.label3.Name = "label3";
//            this.label3.Size = new System.Drawing.Size(40, 23);
//            this.label3.TabIndex = 89;
//            this.label3.Text = "ยี่ห้อรถ";
//            // 
//            // cmdAdd
//            // 
//            this.cmdAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
//            this.cmdAdd.Location = new System.Drawing.Point(348, 536);
//            this.cmdAdd.Name = "cmdAdd";
//            this.cmdAdd.Size = new System.Drawing.Size(72, 24);
//            this.cmdAdd.TabIndex = 4;
//            this.cmdAdd.Text = "เพิ่ม";
//            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
//            // 
//            // cmdEdit
//            // 
//            this.cmdEdit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
//            this.cmdEdit.Location = new System.Drawing.Point(428, 536);
//            this.cmdEdit.Name = "cmdEdit";
//            this.cmdEdit.Size = new System.Drawing.Size(72, 24);
//            this.cmdEdit.TabIndex = 5;
//            this.cmdEdit.Text = "แก้ไข";
//            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
//            // 
//            // cmdDelete
//            // 
//            this.cmdDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
//            this.cmdDelete.Location = new System.Drawing.Point(508, 536);
//            this.cmdDelete.Name = "cmdDelete";
//            this.cmdDelete.Size = new System.Drawing.Size(72, 24);
//            this.cmdDelete.TabIndex = 6;
//            this.cmdDelete.Text = "ลบ";
//            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
//            // 
//            // contextMenu1
//            // 
//            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
//                                                                                         this.mniAdd,
//                                                                                         this.mniEdit,
//                                                                                         this.mniDelete});
//            // 
//            // mniAdd
//            // 
//            this.mniAdd.Index = 0;
//            this.mniAdd.Text = "&เพิ่ม";
//            this.mniAdd.Click += new System.EventHandler(this.mniAdd_Click);
//            // 
//            // mniEdit
//            // 
//            this.mniEdit.Index = 1;
//            this.mniEdit.Text = "&แก้ไข";
//            this.mniEdit.Click += new System.EventHandler(this.mniEdit_Click);
//            // 
//            // mniDelete
//            // 
//            this.mniDelete.Index = 2;
//            this.mniDelete.Text = "&ลบ";
//            this.mniDelete.Click += new System.EventHandler(this.mniDelete_Click);
			
//            // 
//            // frmVehicleAssignment
//            // 
//            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
//            this.ClientSize = new System.Drawing.Size(936, 582);
//            this.Controls.Add(this.cmdDelete);
//            this.Controls.Add(this.cmdEdit);
//            this.Controls.Add(this.cmdAdd);
//            this.Controls.Add(this.gpbVehicle);
//            this.Name = "frmVehicleAssignment";
//            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
//            //this.Text = "ข้อมูลใบจ่ายงานรถ";
//            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
//            this.Load += new System.EventHandler(this.frmVehicleAssignment_Load);
//            this.Closed += new System.EventHandler(this.frmVehicleAssignment_Closed);
//            this.gpbVehicle.ResumeLayout(false);
//            this.ResumeLayout(false);

//        }
//        #endregion

//        #region - Private -
//        private bool isReadonly = true;
//        private bool isSetText = true;
//        private frmMain mdiParent;
//        private FrmVehicleAssignmentEntry frmEntry;
//        private VehicleAssignment objVehicleAssignment;

//        private int SelectedRow
//        {
//            get{return fpsVehicleAssignment_Sheet1.ActiveRowIndex;}
//        }

//        private string SelectedKey
//        {
//            get{return fpsVehicleAssignment_Sheet1.Cells[SelectedRow,0].Text;}
//        }

//        private VehicleAssignment selectedVehicleAssignment
//        {
//            get{return facadeVehicleAssignment.ObjVehicleAssignmentList[SelectedKey];}
//        }

//        private Vehicle getVehicle()
//        {
//            return facadeVehicleAssignment.GetVehicle(txtPlatePrefix.Text, fpiPlateRunningNo.Text);
//        }
//        #endregion

////		============================== Property ==============================
//        private VehicleAssignmentFacade facadeVehicleAssignment;	
//        public VehicleAssignmentFacade FacadeVehicleAssignment
//        {
//            get{return facadeVehicleAssignment;}
//        }

//        private Vehicle aVehicle;
//        private Vehicle AVehicle
//        {
//            set
//            {
//                isSetText = false;
//                txtPlatePrefix.Text = value.PlatePrefix;
//                fpiPlateRunningNo.Value = value.PlateRunningNo;
//                txtBrandName.Text = value.AModel.ABrand.AName.English;
//                txtColorName.Text = value.AColor.AName.English;
//                txtModelName.Text = value.AModel.AName.English;
//                txtModelTypeName.Text = value.AModel.AModelType.AName.Thai;
//                fpiNoOfSeat.Value = value.AModel.NoOfSeat;
//                fpiCC.Value = value.AModel.EngineCC;

//                YearMonth yearMonth1 = facadeVehicleAssignment.CalculateAge(value.BuyDate);
//                fpiAgeYear.Value = yearMonth1.Year;
//                fpiAgeMonth.Value = yearMonth1.Month;

//                YearMonth yearMonth2 = facadeVehicleAssignment.CalculateAge(value.RegisterDate);
//                fpiAgeCarYear.Value = yearMonth2.Year;
//                fpiAgeCarMonth.Value = yearMonth2.Month;

//                ContractBase contractBase = facadeVehicleAssignment.GetCurrentVehicleContract(value);

//                if(value.AKindOfVehicle.Code != "Z" && contractBase != null && contractBase.ContractNo != null)
//                {
////					value.ACurrentContract = (VehicleContract)contractBase;
//                    txtContractNoYY.Text = contractBase.ContractNo.Year;
//                    txtContractNoMM.Text = contractBase.ContractNo.Month;
//                    txtContractNoXXX.Text = contractBase.ContractNo.No;  
//                    txtCurrentCustomer.Text = contractBase.ACustomerDepartment.ACustomer.ShortName;
//                    txtCurrentDep.Text = contractBase.ACustomerDepartment.ShortName;
//                }

//                aVehicle = value;
//                isSetText = true;
//            }
//            get
//            {
//                return aVehicle;
//            }
//        }
		
////		============================== Constructor ==============================
//        public TMPfrmVehicleAssignment(): base()
//        {
//            InitializeComponent();
//            newObject();
//            isReadonly = UserProfile.IsReadOnly("miContract", "miContractAssignmentHistoryVehicelAssignment");
//            this.title = UserProfile.GetFormName("miContract", "miContractAssignmentHistoryVehicelAssignment");

//        }
//        public override string FormID()
//        {
//            return UserProfile.GetFormID("miContract", "miContractAssignmentHistoryVehicelAssignment");
//        }
////		==============================Private method ==============================
//        #region - Enable & Disable Control -
//        private void enableVehicle(bool enabled)
//        {
//            txtPlatePrefix.Enabled = enabled;
//            fpiPlateRunningNo.Enabled = enabled;
//        }

//        private void clearVehicle()
//        {
//            txtBrandName.Text = "";
//            txtColorName.Text = "";
//            txtModelName.Text = "";
//            txtModelTypeName.Text = "";
//            txtContractNoYY.Text = "";
//            txtContractNoMM.Text = "";
//            txtContractNoXXX.Text = "";
//            txtCurrentCustomer.Text = "";
//            txtCurrentDep.Text = "";

//            fpiNoOfSeat.Value = 0;
//            fpiCC.Value = 0;
//            fpiAgeYear.Value = 0;
//            fpiAgeMonth.Value = 0;
//            fpiAgeCarYear.Value = 0;
//            fpiAgeCarMonth.Value = 0;
//        }
//        private void visibleButton(bool visible)
//        {
//            cmdAdd.Visible = visible;
//            cmdEdit.Visible = visible;
//            cmdDelete.Visible = visible;
//        }

//        private void enableButton(bool enable)
//        {
//            mniEdit.Enabled = enable;
//            cmdEdit.Enabled = enable;
//            mniDelete.Enabled = enable;
//            cmdDelete.Enabled = enable;
//        }

//        private void clearForm()
//        {
//            fpsVehicleAssignment_Sheet1.RowCount = 0;
//            fpsVehicleAssignment.Enabled = true;
//            cmdAdd.Enabled = true;
//            mniAdd.Enabled = true;
//            enableButton(false);
//        }

//        private void clearAll()
//        {
//            clearVehicle();
//            clearForm();
//            fpsVehicleAssignment.Visible = false;			
//            visibleButton(false);
//            enableVehicle(true);
//            txtPlatePrefix.Focus();
//        }

//        private void setForm()
//        {
//            fpsVehicleAssignment_Sheet1.RowCount = 0;
//            fpsVehicleAssignment.Visible = true;
//            enableVehicle(false);
//        }

//        #endregion - Enable & Disable Control -

//        #region - Validate Checking - 
//        private bool validateVehiclePlate()
//        {
//            if(txtPlatePrefix.Text == "")
//            {
//                Message(MessageList.Error.E0002, "ทะเบียนรถ");
//                txtPlatePrefix.Focus();
//                return false;
//            }
//            else if(fpiPlateRunningNo.Text == "")
//            {
//                Message(MessageList.Error.E0002, "ทะเบียนรถ");
//                fpiPlateRunningNo.Focus();
//                return false;
//            }
//            else
//            {return true;}
//        }

//        private bool validateAddEvent()
//        {
//            if(aVehicle.AVehicleStatus.Code != "1")
//            {
//                Message(MessageList.Error.E0013, "จ่ายงานให้รถคันนี้ได้","รถไม่อยู่ในสถานะที่พร้อมจะจ่ายงาน");
//                txtPlatePrefix.Focus();
//                return false;		
//            }
//            return true;
//        }

//        #endregion - Validate Checking - 
		
//        private VehicleAssignment getVehicleAssignment(Vehicle value)
//        {
//            objVehicleAssignment = new VehicleAssignment();
//            objVehicleAssignment.AAssignedVehicle = value;
//            return objVehicleAssignment;
//        }

//        private void newObject()	
//        {
//            facadeVehicleAssignment = new VehicleAssignmentFacade();
//            frmEntry = new FrmVehicleAssignmentEntry(this);
//        }
		
//        private void formVehicleList()
//        {
//            FrmVehicleList dialogVehicleList = new FrmVehicleList();
//            dialogVehicleList.ConditionPlatePrefix = txtPlatePrefix.Text;		
//            dialogVehicleList.ConditionPlateRunningNo = fpiPlateRunningNo.Text;
//            dialogVehicleList.ShowDialog();			

//            if(dialogVehicleList.Selected)
//            {
//                AVehicle = dialogVehicleList.SelectedVehicle;
//                RefreshForm();
//            }
//        }
		
//        private void bindForm()
//        {
//            if (facadeVehicleAssignment.ObjVehicleAssignmentList.Count > 0)
//            {
//                enableButton(true);

//                int iRow = facadeVehicleAssignment.ObjVehicleAssignmentList.Count;
//                fpsVehicleAssignment_Sheet1.RowCount = iRow;
//                for(int i=0; i<iRow; i++)
//                {
//                    bindVehicleAssignment(i, facadeVehicleAssignment.ObjVehicleAssignmentList[i]);			
//                }
//                fpsVehicleAssignment_Sheet1.SetActiveCell(fpsVehicleAssignment_Sheet1.RowCount, 0);
//            }
//            else
//            {
//                fpsVehicleAssignment_Sheet1.RowCount = 0;
//                enableButton(false);
//            }	

//            //if(aVehicle.AKindOfVehicle.Code == "Z")
//            //{
//            //    if(fpsVehicleAssignment_Sheet1.RowCount == 0)
//            //    {
//            //        enableButton(false);
//            //    }
//            //    else
//            //    {
//            //        enableButton(true);	
//            //    }
//            //}
//            //else
//            //{
//            //    enableButton(false);
//            //    cmdAdd.Enabled = false;
//            //    mniAdd.Enabled = false;
//            //}

//            mdiParent.RefreshMasterCount();
//        }

//        private void bindVehicleAssignment(int row, VehicleAssignment value)
//        {
//            fpsVehicleAssignment_Sheet1.Cells[row,0].Text = value.EntityKey;
//            fpsVehicleAssignment_Sheet1.Cells[row,1].Text = GUIFunction.GetString(value.APeriod.From.Date.ToShortDateString());
//            fpsVehicleAssignment_Sheet1.Cells[row,2].Text = GUIFunction.GetString(value.APeriod.To.Date.ToShortDateString());
//            fpsVehicleAssignment_Sheet1.Cells[row,3].Text = GUIFunction.GetString(value.AMainVehicle.PlateNumber);
//            fpsVehicleAssignment_Sheet1.Cells[row,4].Text = GUIFunction.GetString(value.AContract.ContractNo.ToString());
//            fpsVehicleAssignment_Sheet1.Cells[row,5].Text = GUIFunction.GetString(value.AContract.ACustomerDepartment.ACustomer.ShortName);
//            fpsVehicleAssignment_Sheet1.Cells[row,6].Text = GUIFunction.GetString(value.AContract.ACustomerDepartment.ShortName);
//            fpsVehicleAssignment_Sheet1.Cells[row,7].Text = GUIFunction.GetString(value.AHirer.Name);
//            fpsVehicleAssignment_Sheet1.Cells[row,8].Text = GUIFunction.GetString(value.AAssignmentReason.Name);
//        }

////      ============================== Public Method  ============================
//        public bool AddRow(VehicleAssignment value)
//        {
//            if (facadeVehicleAssignment.InsertVehicleAssignment(value))
//            {
//                if(fpsVehicleAssignment_Sheet1.RowCount == 0)
//                {
//                    fpsVehicleAssignment.Visible = true;
//                }

//                fpsVehicleAssignment_Sheet1.RowCount++;
//                bindVehicleAssignment(fpsVehicleAssignment_Sheet1.RowCount-1, value);
//                fpsVehicleAssignment_Sheet1.SetActiveCell(fpsVehicleAssignment_Sheet1.RowCount, 0);
//                enableButton(true);
//                mdiParent.RefreshMasterCount();
//                return true;
//            }
//            return false;
//        }

//        public bool UpdateRow(VehicleAssignment oldVehicleAssignment, VehicleAssignment newVehicleAssignment)
//        {
//            if (facadeVehicleAssignment.UpdateVehicleAssignment(oldVehicleAssignment, newVehicleAssignment))
//            {
//                bindVehicleAssignment(SelectedRow, newVehicleAssignment);				
//                return true;
//            }
//            return false;
//        }

//        private void deleteRow()
//        {
//            if (facadeVehicleAssignment.DeleteVehicleAssignment(selectedVehicleAssignment))
//            {
//                if(fpsVehicleAssignment_Sheet1.RowCount > 1)
//                {
//                    fpsVehicleAssignment.ActiveSheet.Rows.Remove(SelectedRow,1);
//                }
//                else
//                {clearForm();}	
//                mdiParent.RefreshMasterCount();
//            }
//        }

//        public override int MasterCount()
//        {
//            return facadeVehicleAssignment.ObjVehicleAssignmentList.Count;
//        }

////      ============================== Base Event ==============================
//        public void InitForm()
//        {
//            mdiParent.DisableCommand();
//            clearMainMenuStatus();

//            txtPlatePrefix.Text = "";
//            fpiPlateRunningNo.Text = "";
//            newObject();
//            clearAll();			
//            mdiParent.RefreshMasterCount();
//        }

//        public void RefreshForm()
//        {
//            try
//            {
//                if(aVehicle!=null && validateVehiclePlate())
//                {
//                    visibleButton(true);
//                    facadeVehicleAssignment.DisplayVehicleAssignment(getVehicleAssignment(aVehicle));
					
//                    setForm();
//                    bindForm();

//                    MainMenuNewStatus = true;
//                    MainMenuDeleteStatus = false;
//                    MainMenuRefreshStatus = true;
//                    MainMenuPrintStatus = false;

//                    mdiParent.EnableNewCommand(true);
//                    mdiParent.EnableDeleteCommand(false);
//                    mdiParent.EnableRefreshCommand(true);
//                    mdiParent.EnablePrintCommand(false);
//                }
//            }
//            catch(SqlException sqlex)
//            {Message(sqlex);}
//            catch(AppExceptionBase ex)
//            {Message(ex);}
//            catch(Exception ex)
//            {Message(ex);}

//            if(isReadonly)
//            {
//                cmdAdd.Enabled = false;
//                mniAdd.Enabled = false;
//                cmdDelete.Enabled = false;
//                mniDelete.Enabled = false;
//            }
//        }

//        public void PrintForm()
//        {
//        }

//        public void ExitForm()
//        {
//            Dispose(true);
//        }

//        private void addEvent()
//        {
//            try
//            {
//                if(validateAddEvent())
//                {
//                    frmEntry = new FrmVehicleAssignmentEntry(this);
//                    frmEntry.InitAddAction(aVehicle);
//                    frmEntry.ShowDialog();
//                }			
//            }
//            catch(SqlException sqlex)
//            {Message(sqlex);}
//            catch(AppExceptionBase ex)
//            {Message(ex);}
//            catch(Exception ex)
//            {Message(ex);}
//        }

//        private void editEvent()
//        {
//            try
//            {
//                frmEntry = new FrmVehicleAssignmentEntry(this);
//                frmEntry.InitEditAction(selectedVehicleAssignment, aVehicle);
//                frmEntry.ShowDialog();			
//            }
//            catch(SqlException sqlex)
//            {Message(sqlex);}
//            catch(AppExceptionBase ex)
//            {Message(ex);}
//            catch(Exception ex)
//            {Message(ex);}
//        }
	
//        private void deleteEvent()
//        {
//            try
//            {
//                if (Message(MessageList.Question.Q0001) == DialogResult.Yes)
//                {
//                    deleteRow();
//                }
//            }
//            catch(SqlException sqlex)
//            {Message(sqlex);}
//            catch(AppExceptionBase ex)
//            {Message(ex);}
//            catch(Exception ex)
//            {Message(ex);}		
//        }

////      ============================== Event ==============================
//        private void frmVehicleAssignment_Load(object sender, System.EventArgs e)
//        {
//            mdiParent = (frmMain)this.MdiParent;
//            InitForm();
//        }

//        private void mniAdd_Click(object sender, System.EventArgs e)
//        {
//            addEvent();
//        }

//        private void mniEdit_Click(object sender, System.EventArgs e)
//        {
//            editEvent();
//        }

//        private void mniDelete_Click(object sender, System.EventArgs e)
//        {
//            deleteEvent();
//        }

//        private void cmdAdd_Click(object sender, System.EventArgs e)
//        {
//            addEvent();
//        }

//        private void cmdEdit_Click(object sender, System.EventArgs e)
//        {
//            editEvent();
//        }

//        private void cmdDelete_Click(object sender, System.EventArgs e)
//        {
//            deleteEvent();
//        }
		
//        private void frmVehicleAssignment_Closed(object sender, System.EventArgs e)
//        {
//            ExitForm();
//        }
		
//        private void fpiPlateRunningNo_DoubleClick(object sender, System.EventArgs e)
//        {
//            formVehicleList();
//        }

//        private void fpiPlateRunningNo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
//        {
//            if(e.KeyCode == System.Windows.Forms.Keys.Enter)
//            {
//                if(validateVehiclePlate())
//                {
//                    Vehicle vehicle = getVehicle();
//                    if(vehicle != null)
//                    {
//                        AVehicle = vehicle;
//                        RefreshForm();
//                    }
//                    else
//                    {
//                        Message(MessageList.Error.E0004, "เลขทะเบียนรถ");
//                        txtPlatePrefix.Focus();
//                        clearAll();
//                    }
//                    vehicle = null;
//                }
//            }
//        }
//        private void fpiPlateRunningNo_TextChanged(object sender, System.EventArgs e)
//        {
//            lblPlateNo.Text = fpiPlateRunningNo.Text;
//            if(isSetText)
//            {
//                lblPlateNo.Text = fpiPlateRunningNo.Text;
//                if(fpiPlateRunningNo.Text.Length == 4)
//                {
//                    if(validateVehiclePlate())
//                    {
//                        Vehicle vehicle = getVehicle();
//                        if(vehicle != null)
//                        {
//                            AVehicle = vehicle;
//                            RefreshForm();
//                        }
//                        else
//                        {
//                            Message(MessageList.Error.E0004, "เลขทะเบียนรถ");
//                            txtPlatePrefix.Focus();
//                            clearAll();
//                        }
//                        vehicle = null;
//                    }
//                }
//            }
//        }

//        private void txtPlatePrefix_TextChanged(object sender, System.EventArgs e)
//        {
//            lblPlatePrefix.Text = txtPlatePrefix.Text;
//            if(txtPlatePrefix.Text.Length == 2)
//            {
//                fpiPlateRunningNo.Focus();
//            }
//        }
		
//        private void fpsVehicleAssignment_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
//        {
//            if(!e.ColumnHeader & cmdEdit.Enabled)
//            {
//                editEvent();
//            }
//        }
//    }
//}
