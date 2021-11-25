//using System;
//using System.Data.SqlClient;
//using System.Collections;
//using System.ComponentModel;
//using System.Drawing;
//using System.Windows.Forms;

//using Entity.ContractEntities;

//using SystemFramework.AppMessage;
//using SystemFramework.AppException;
//using SystemFramework.AppConfig;

//namespace Presentation.ContractGUI
//{
//    public class TMPfrmContractDriver : Presentation.ContractGUI.TMPfrmContract
//    {
//        #region Designer generated code

//        private System.Windows.Forms.Label label20;
//        private System.Windows.Forms.Label label19;
//        private System.Windows.Forms.Label label18;
//        private System.Windows.Forms.Label label16;
//        private System.Windows.Forms.Label label14;
//        private System.Windows.Forms.Button btnCreate;
//        private System.Windows.Forms.Button btnCal6;
//        private System.Windows.Forms.DateTimePicker dtpCCTo6;
//        private System.Windows.Forms.DateTimePicker dtpCCForm6;
//        private System.Windows.Forms.Button btnCal5;
//        private System.Windows.Forms.DateTimePicker dtpCCTo5;
//        private System.Windows.Forms.DateTimePicker dtpCCForm5;
//        private System.Windows.Forms.Button btnCal4;
//        private System.Windows.Forms.DateTimePicker dtpCCTo4;
//        private System.Windows.Forms.DateTimePicker dtpCCForm4;
//        private System.Windows.Forms.Button btnCal3;
//        private System.Windows.Forms.DateTimePicker dtpCCTo3;
//        private System.Windows.Forms.DateTimePicker dtpCCForm3;
//        private System.Windows.Forms.Button btnCal2;
//        private System.Windows.Forms.DateTimePicker dtpCCTo2;
//        private System.Windows.Forms.DateTimePicker dtpCCForm2;
//        private System.Windows.Forms.Button btnCal1;
//        private System.Windows.Forms.DateTimePicker dtpCCTo1;
//        private System.Windows.Forms.DateTimePicker dtpCCForm1;
//        private Presentation.ContractGUI.UCTContractCharge uctContractCharge1;
//        private Presentation.ContractGUI.UCTContractCharge uctContractCharge2;
//        private Presentation.ContractGUI.UCTContractCharge uctContractCharge3;
//        private Presentation.ContractGUI.UCTContractCharge uctContractCharge4;
//        private Presentation.ContractGUI.UCTContractCharge uctContractCharge5;
//        private Presentation.ContractGUI.UCTContractCharge uctContractCharge6;
//        private System.Windows.Forms.GroupBox grbServiceCharge;
//        private System.Windows.Forms.Label lblYear6;
//        private System.Windows.Forms.Label lblYear5;
//        private System.Windows.Forms.Label lblYear4;
//        private System.Windows.Forms.Label lblYear3;
//        private System.Windows.Forms.Label lblYear2;
//        private System.Windows.Forms.Label lblYear1;
//        private System.ComponentModel.IContainer components = null;

//        protected override void Dispose( bool disposing )
//        {
//            if( disposing )
//            {
//                if (components != null) 
//                {
//                    components.Dispose();
//                }
//            }
//            base.Dispose( disposing );
//        }

//        private void InitializeComponent()
//        {
//            this.grbServiceCharge = new System.Windows.Forms.GroupBox();
//            this.label16 = new System.Windows.Forms.Label();
//            this.label18 = new System.Windows.Forms.Label();
//            this.label14 = new System.Windows.Forms.Label();
//            this.label20 = new System.Windows.Forms.Label();
//            this.uctContractCharge6 = new Presentation.ContractGUI.UCTContractCharge();
//            this.uctContractCharge5 = new Presentation.ContractGUI.UCTContractCharge();
//            this.uctContractCharge4 = new Presentation.ContractGUI.UCTContractCharge();
//            this.uctContractCharge3 = new Presentation.ContractGUI.UCTContractCharge();
//            this.uctContractCharge2 = new Presentation.ContractGUI.UCTContractCharge();
//            this.uctContractCharge1 = new Presentation.ContractGUI.UCTContractCharge();
//            this.btnCreate = new System.Windows.Forms.Button();
//            this.lblYear6 = new System.Windows.Forms.Label();
//            this.lblYear5 = new System.Windows.Forms.Label();
//            this.lblYear4 = new System.Windows.Forms.Label();
//            this.lblYear3 = new System.Windows.Forms.Label();
//            this.lblYear2 = new System.Windows.Forms.Label();
//            this.lblYear1 = new System.Windows.Forms.Label();
//            this.btnCal6 = new System.Windows.Forms.Button();
//            this.dtpCCTo6 = new System.Windows.Forms.DateTimePicker();
//            this.dtpCCForm6 = new System.Windows.Forms.DateTimePicker();
//            this.btnCal5 = new System.Windows.Forms.Button();
//            this.dtpCCTo5 = new System.Windows.Forms.DateTimePicker();
//            this.dtpCCForm5 = new System.Windows.Forms.DateTimePicker();
//            this.btnCal4 = new System.Windows.Forms.Button();
//            this.dtpCCTo4 = new System.Windows.Forms.DateTimePicker();
//            this.dtpCCForm4 = new System.Windows.Forms.DateTimePicker();
//            this.btnCal3 = new System.Windows.Forms.Button();
//            this.dtpCCTo3 = new System.Windows.Forms.DateTimePicker();
//            this.dtpCCForm3 = new System.Windows.Forms.DateTimePicker();
//            this.btnCal2 = new System.Windows.Forms.Button();
//            this.dtpCCTo2 = new System.Windows.Forms.DateTimePicker();
//            this.dtpCCForm2 = new System.Windows.Forms.DateTimePicker();
//            this.btnCal1 = new System.Windows.Forms.Button();
//            this.dtpCCTo1 = new System.Windows.Forms.DateTimePicker();
//            this.dtpCCForm1 = new System.Windows.Forms.DateTimePicker();
//            this.label19 = new System.Windows.Forms.Label();
//            this.grbServiceCharge.SuspendLayout();
//            this.SuspendLayout();
//            // 
//            // gpbAssignment
//            // 
//            this.gpbAssignment.Location = new System.Drawing.Point(328, 432);
//            this.gpbAssignment.Name = "gpbAssignment";
//            // 
//            // dtpContractEnd
//            // 
//            this.dtpContractEnd.Name = "dtpContractEnd";
//            // 
//            // dtpContractStart
//            // 
//            this.dtpContractStart.Name = "dtpContractStart";
//            // 
//            // gpbDeleteContract
//            // 
//            this.gpbDeleteContract.Location = new System.Drawing.Point(24, 432);
//            this.gpbDeleteContract.Name = "gpbDeleteContract";
//            // 
//            // rdoMonth
//            // 
//            this.rdoMonth.Name = "rdoMonth";
//            // 
//            // rdoDay
//            // 
//            this.rdoDay.Name = "rdoDay";
//            // 
//            // grbServiceCharge
//            // 
//            this.grbServiceCharge.Anchor = System.Windows.Forms.AnchorStyles.Top;
//            this.grbServiceCharge.Controls.Add(this.label16);
//            this.grbServiceCharge.Controls.Add(this.label18);
//            this.grbServiceCharge.Controls.Add(this.label14);
//            this.grbServiceCharge.Controls.Add(this.label20);
//            this.grbServiceCharge.Controls.Add(this.uctContractCharge6);
//            this.grbServiceCharge.Controls.Add(this.uctContractCharge5);
//            this.grbServiceCharge.Controls.Add(this.uctContractCharge4);
//            this.grbServiceCharge.Controls.Add(this.uctContractCharge3);
//            this.grbServiceCharge.Controls.Add(this.uctContractCharge2);
//            this.grbServiceCharge.Controls.Add(this.uctContractCharge1);
//            this.grbServiceCharge.Controls.Add(this.btnCreate);
//            this.grbServiceCharge.Controls.Add(this.lblYear6);
//            this.grbServiceCharge.Controls.Add(this.lblYear5);
//            this.grbServiceCharge.Controls.Add(this.lblYear4);
//            this.grbServiceCharge.Controls.Add(this.lblYear3);
//            this.grbServiceCharge.Controls.Add(this.lblYear2);
//            this.grbServiceCharge.Controls.Add(this.lblYear1);
//            this.grbServiceCharge.Controls.Add(this.btnCal6);
//            this.grbServiceCharge.Controls.Add(this.dtpCCTo6);
//            this.grbServiceCharge.Controls.Add(this.dtpCCForm6);
//            this.grbServiceCharge.Controls.Add(this.btnCal5);
//            this.grbServiceCharge.Controls.Add(this.dtpCCTo5);
//            this.grbServiceCharge.Controls.Add(this.dtpCCForm5);
//            this.grbServiceCharge.Controls.Add(this.btnCal4);
//            this.grbServiceCharge.Controls.Add(this.dtpCCTo4);
//            this.grbServiceCharge.Controls.Add(this.dtpCCForm4);
//            this.grbServiceCharge.Controls.Add(this.btnCal3);
//            this.grbServiceCharge.Controls.Add(this.dtpCCTo3);
//            this.grbServiceCharge.Controls.Add(this.dtpCCForm3);
//            this.grbServiceCharge.Controls.Add(this.btnCal2);
//            this.grbServiceCharge.Controls.Add(this.dtpCCTo2);
//            this.grbServiceCharge.Controls.Add(this.dtpCCForm2);
//            this.grbServiceCharge.Controls.Add(this.btnCal1);
//            this.grbServiceCharge.Controls.Add(this.dtpCCTo1);
//            this.grbServiceCharge.Controls.Add(this.dtpCCForm1);
//            this.grbServiceCharge.Controls.Add(this.label19);
//            this.grbServiceCharge.Location = new System.Drawing.Point(23, 192);
//            this.grbServiceCharge.Name = "grbServiceCharge";
//            this.grbServiceCharge.Size = new System.Drawing.Size(776, 240);
//            this.grbServiceCharge.TabIndex = 35;
//            this.grbServiceCharge.TabStop = false;
//            this.grbServiceCharge.Text = "ค่าบริการ";
//            // 
//            // label16
//            // 
//            this.label16.BackColor = System.Drawing.SystemColors.AppWorkspace;
//            this.label16.Location = new System.Drawing.Point(664, 16);
//            this.label16.Name = "label16";
//            this.label16.Size = new System.Drawing.Size(88, 23);
//            this.label16.TabIndex = 41;
//            this.label16.Text = "เดือนสุดท้าย";
//            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
//            // 
//            // label18
//            // 
//            this.label18.BackColor = System.Drawing.SystemColors.AppWorkspace;
//            this.label18.Location = new System.Drawing.Point(560, 16);
//            this.label18.Name = "label18";
//            this.label18.Size = new System.Drawing.Size(88, 23);
//            this.label18.TabIndex = 40;
//            this.label18.Text = "เดือนถัดไป";
//            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
//            // 
//            // label14
//            // 
//            this.label14.BackColor = System.Drawing.SystemColors.AppWorkspace;
//            this.label14.Location = new System.Drawing.Point(456, 16);
//            this.label14.Name = "label14";
//            this.label14.Size = new System.Drawing.Size(88, 23);
//            this.label14.TabIndex = 39;
//            this.label14.Text = "เดือนแรก";
//            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
//            // 
//            // label20
//            // 
//            this.label20.BackColor = System.Drawing.SystemColors.AppWorkspace;
//            this.label20.Location = new System.Drawing.Point(344, 16);
//            this.label20.Name = "label20";
//            this.label20.Size = new System.Drawing.Size(96, 23);
//            this.label20.TabIndex = 38;
//            this.label20.Text = "อัตราค่าบริการ";
//            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
//            // 
//            // uctContractCharge6
//            // 
//            this.uctContractCharge6.DateForm = new System.DateTime(((long)(0)));
//            this.uctContractCharge6.DateTo = new System.DateTime(((long)(0)));
//            this.uctContractCharge6.FirstMonth = new System.Decimal(new int[] {
//                                                                                  0,
//                                                                                  0,
//                                                                                  0,
//                                                                                  0});
//            this.uctContractCharge6.LastMonth = new System.Decimal(new int[] {
//                                                                                 0,
//                                                                                 0,
//                                                                                 0,
//                                                                                 0});
//            this.uctContractCharge6.Location = new System.Drawing.Point(336, 200);
//            this.uctContractCharge6.Name = "uctContractCharge6";
//            this.uctContractCharge6.NextMonth = new System.Decimal(new int[] {
//                                                                                 0,
//                                                                                 0,
//                                                                                 0,
//                                                                                 0});
//            this.uctContractCharge6.RateAmount = new System.Decimal(new int[] {
//                                                                                  0,
//                                                                                  0,
//                                                                                  0,
//                                                                                  0});
//            this.uctContractCharge6.RateAmountTag = new System.Decimal(new int[] {
//                                                                                     1,
//                                                                                     0,
//                                                                                     0,
//                                                                                     -2147483648});
//            this.uctContractCharge6.RateStatusByMonth = false;
//            this.uctContractCharge6.Size = new System.Drawing.Size(424, 32);
//            this.uctContractCharge6.TabIndex = 71;
//            this.uctContractCharge6.UnitChargeEnable = true;
//            // 
//            // uctContractCharge5
//            // 
//            this.uctContractCharge5.DateForm = new System.DateTime(((long)(0)));
//            this.uctContractCharge5.DateTo = new System.DateTime(((long)(0)));
//            this.uctContractCharge5.FirstMonth = new System.Decimal(new int[] {
//                                                                                  0,
//                                                                                  0,
//                                                                                  0,
//                                                                                  0});
//            this.uctContractCharge5.LastMonth = new System.Decimal(new int[] {
//                                                                                 0,
//                                                                                 0,
//                                                                                 0,
//                                                                                 0});
//            this.uctContractCharge5.Location = new System.Drawing.Point(336, 168);
//            this.uctContractCharge5.Name = "uctContractCharge5";
//            this.uctContractCharge5.NextMonth = new System.Decimal(new int[] {
//                                                                                 0,
//                                                                                 0,
//                                                                                 0,
//                                                                                 0});
//            this.uctContractCharge5.RateAmount = new System.Decimal(new int[] {
//                                                                                  0,
//                                                                                  0,
//                                                                                  0,
//                                                                                  0});
//            this.uctContractCharge5.RateAmountTag = new System.Decimal(new int[] {
//                                                                                     1,
//                                                                                     0,
//                                                                                     0,
//                                                                                     -2147483648});
//            this.uctContractCharge5.RateStatusByMonth = false;
//            this.uctContractCharge5.Size = new System.Drawing.Size(424, 32);
//            this.uctContractCharge5.TabIndex = 66;
//            this.uctContractCharge5.UnitChargeEnable = true;
//            // 
//            // uctContractCharge4
//            // 
//            this.uctContractCharge4.DateForm = new System.DateTime(((long)(0)));
//            this.uctContractCharge4.DateTo = new System.DateTime(((long)(0)));
//            this.uctContractCharge4.FirstMonth = new System.Decimal(new int[] {
//                                                                                  0,
//                                                                                  0,
//                                                                                  0,
//                                                                                  0});
//            this.uctContractCharge4.LastMonth = new System.Decimal(new int[] {
//                                                                                 0,
//                                                                                 0,
//                                                                                 0,
//                                                                                 0});
//            this.uctContractCharge4.Location = new System.Drawing.Point(336, 136);
//            this.uctContractCharge4.Name = "uctContractCharge4";
//            this.uctContractCharge4.NextMonth = new System.Decimal(new int[] {
//                                                                                 0,
//                                                                                 0,
//                                                                                 0,
//                                                                                 0});
//            this.uctContractCharge4.RateAmount = new System.Decimal(new int[] {
//                                                                                  0,
//                                                                                  0,
//                                                                                  0,
//                                                                                  0});
//            this.uctContractCharge4.RateAmountTag = new System.Decimal(new int[] {
//                                                                                     1,
//                                                                                     0,
//                                                                                     0,
//                                                                                     -2147483648});
//            this.uctContractCharge4.RateStatusByMonth = false;
//            this.uctContractCharge4.Size = new System.Drawing.Size(424, 32);
//            this.uctContractCharge4.TabIndex = 61;
//            this.uctContractCharge4.UnitChargeEnable = true;
//            // 
//            // uctContractCharge3
//            // 
//            this.uctContractCharge3.DateForm = new System.DateTime(((long)(0)));
//            this.uctContractCharge3.DateTo = new System.DateTime(((long)(0)));
//            this.uctContractCharge3.FirstMonth = new System.Decimal(new int[] {
//                                                                                  0,
//                                                                                  0,
//                                                                                  0,
//                                                                                  0});
//            this.uctContractCharge3.LastMonth = new System.Decimal(new int[] {
//                                                                                 0,
//                                                                                 0,
//                                                                                 0,
//                                                                                 0});
//            this.uctContractCharge3.Location = new System.Drawing.Point(336, 104);
//            this.uctContractCharge3.Name = "uctContractCharge3";
//            this.uctContractCharge3.NextMonth = new System.Decimal(new int[] {
//                                                                                 0,
//                                                                                 0,
//                                                                                 0,
//                                                                                 0});
//            this.uctContractCharge3.RateAmount = new System.Decimal(new int[] {
//                                                                                  0,
//                                                                                  0,
//                                                                                  0,
//                                                                                  0});
//            this.uctContractCharge3.RateAmountTag = new System.Decimal(new int[] {
//                                                                                     1,
//                                                                                     0,
//                                                                                     0,
//                                                                                     -2147483648});
//            this.uctContractCharge3.RateStatusByMonth = false;
//            this.uctContractCharge3.Size = new System.Drawing.Size(424, 32);
//            this.uctContractCharge3.TabIndex = 56;
//            this.uctContractCharge3.UnitChargeEnable = true;
//            // 
//            // uctContractCharge2
//            // 
//            this.uctContractCharge2.DateForm = new System.DateTime(((long)(0)));
//            this.uctContractCharge2.DateTo = new System.DateTime(((long)(0)));
//            this.uctContractCharge2.FirstMonth = new System.Decimal(new int[] {
//                                                                                  0,
//                                                                                  0,
//                                                                                  0,
//                                                                                  0});
//            this.uctContractCharge2.LastMonth = new System.Decimal(new int[] {
//                                                                                 0,
//                                                                                 0,
//                                                                                 0,
//                                                                                 0});
//            this.uctContractCharge2.Location = new System.Drawing.Point(336, 72);
//            this.uctContractCharge2.Name = "uctContractCharge2";
//            this.uctContractCharge2.NextMonth = new System.Decimal(new int[] {
//                                                                                 0,
//                                                                                 0,
//                                                                                 0,
//                                                                                 0});
//            this.uctContractCharge2.RateAmount = new System.Decimal(new int[] {
//                                                                                  0,
//                                                                                  0,
//                                                                                  0,
//                                                                                  0});
//            this.uctContractCharge2.RateAmountTag = new System.Decimal(new int[] {
//                                                                                     1,
//                                                                                     0,
//                                                                                     0,
//                                                                                     -2147483648});
//            this.uctContractCharge2.RateStatusByMonth = false;
//            this.uctContractCharge2.Size = new System.Drawing.Size(424, 32);
//            this.uctContractCharge2.TabIndex = 51;
//            this.uctContractCharge2.UnitChargeEnable = true;
//            // 
//            // uctContractCharge1
//            // 
//            this.uctContractCharge1.DateForm = new System.DateTime(((long)(0)));
//            this.uctContractCharge1.DateTo = new System.DateTime(((long)(0)));
//            this.uctContractCharge1.FirstMonth = new System.Decimal(new int[] {
//                                                                                  0,
//                                                                                  0,
//                                                                                  0,
//                                                                                  0});
//            this.uctContractCharge1.LastMonth = new System.Decimal(new int[] {
//                                                                                 0,
//                                                                                 0,
//                                                                                 0,
//                                                                                 0});
//            this.uctContractCharge1.Location = new System.Drawing.Point(336, 40);
//            this.uctContractCharge1.Name = "uctContractCharge1";
//            this.uctContractCharge1.NextMonth = new System.Decimal(new int[] {
//                                                                                 0,
//                                                                                 0,
//                                                                                 0,
//                                                                                 0});
//            this.uctContractCharge1.RateAmount = new System.Decimal(new int[] {
//                                                                                  0,
//                                                                                  0,
//                                                                                  0,
//                                                                                  0});
//            this.uctContractCharge1.RateAmountTag = new System.Decimal(new int[] {
//                                                                                     1,
//                                                                                     0,
//                                                                                     0,
//                                                                                     -2147483648});
//            this.uctContractCharge1.RateStatusByMonth = false;
//            this.uctContractCharge1.Size = new System.Drawing.Size(424, 32);
//            this.uctContractCharge1.TabIndex = 46;
//            this.uctContractCharge1.UnitChargeEnable = true;
//            // 
//            // btnCreate
//            // 
//            this.btnCreate.Location = new System.Drawing.Point(16, 16);
//            this.btnCreate.Name = "btnCreate";
//            this.btnCreate.Size = new System.Drawing.Size(88, 23);
//            this.btnCreate.TabIndex = 36;
//            this.btnCreate.Text = "สร้างรายการ";
//            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
//            // 
//            // lblYear6
//            // 
//            this.lblYear6.Location = new System.Drawing.Point(32, 208);
//            this.lblYear6.Name = "lblYear6";
//            this.lblYear6.Size = new System.Drawing.Size(16, 23);
//            this.lblYear6.TabIndex = 67;
//            this.lblYear6.Text = "6.";
//            // 
//            // lblYear5
//            // 
//            this.lblYear5.Location = new System.Drawing.Point(32, 176);
//            this.lblYear5.Name = "lblYear5";
//            this.lblYear5.Size = new System.Drawing.Size(16, 23);
//            this.lblYear5.TabIndex = 62;
//            this.lblYear5.Text = "5.";
//            // 
//            // lblYear4
//            // 
//            this.lblYear4.Location = new System.Drawing.Point(32, 144);
//            this.lblYear4.Name = "lblYear4";
//            this.lblYear4.Size = new System.Drawing.Size(16, 23);
//            this.lblYear4.TabIndex = 57;
//            this.lblYear4.Text = "4.";
//            // 
//            // lblYear3
//            // 
//            this.lblYear3.Location = new System.Drawing.Point(32, 112);
//            this.lblYear3.Name = "lblYear3";
//            this.lblYear3.Size = new System.Drawing.Size(16, 23);
//            this.lblYear3.TabIndex = 52;
//            this.lblYear3.Text = "3.";
//            // 
//            // lblYear2
//            // 
//            this.lblYear2.Location = new System.Drawing.Point(32, 80);
//            this.lblYear2.Name = "lblYear2";
//            this.lblYear2.Size = new System.Drawing.Size(16, 23);
//            this.lblYear2.TabIndex = 47;
//            this.lblYear2.Text = "2.";
//            // 
//            // lblYear1
//            // 
//            this.lblYear1.Location = new System.Drawing.Point(32, 48);
//            this.lblYear1.Name = "lblYear1";
//            this.lblYear1.Size = new System.Drawing.Size(16, 23);
//            this.lblYear1.TabIndex = 42;
//            this.lblYear1.Text = "1.";
//            // 
//            // btnCal6
//            // 
//            this.btnCal6.Enabled = false;
//            this.btnCal6.Location = new System.Drawing.Point(56, 208);
//            this.btnCal6.Name = "btnCal6";
//            this.btnCal6.Size = new System.Drawing.Size(48, 23);
//            this.btnCal6.TabIndex = 68;
//            this.btnCal6.Text = "คำนวณ";
//            this.btnCal6.Click += new System.EventHandler(this.btnCal6_Click);
//            // 
//            // dtpCCTo6
//            // 
//            this.dtpCCTo6.CustomFormat = "dd/MM/yyyy";
//            this.dtpCCTo6.Enabled = false;
//            this.dtpCCTo6.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
//            this.dtpCCTo6.Location = new System.Drawing.Point(232, 208);
//            this.dtpCCTo6.Name = "dtpCCTo6";
//            this.dtpCCTo6.Size = new System.Drawing.Size(96, 20);
//            this.dtpCCTo6.TabIndex = 70;
//            // 
//            // dtpCCForm6
//            // 
//            this.dtpCCForm6.CustomFormat = "dd/MM/yyyy";
//            this.dtpCCForm6.Enabled = false;
//            this.dtpCCForm6.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
//            this.dtpCCForm6.Location = new System.Drawing.Point(120, 208);
//            this.dtpCCForm6.Name = "dtpCCForm6";
//            this.dtpCCForm6.Size = new System.Drawing.Size(96, 20);
//            this.dtpCCForm6.TabIndex = 69;
//            // 
//            // btnCal5
//            // 
//            this.btnCal5.Enabled = false;
//            this.btnCal5.Location = new System.Drawing.Point(56, 176);
//            this.btnCal5.Name = "btnCal5";
//            this.btnCal5.Size = new System.Drawing.Size(48, 23);
//            this.btnCal5.TabIndex = 63;
//            this.btnCal5.Text = "คำนวณ";
//            this.btnCal5.Click += new System.EventHandler(this.btnCal5_Click);
//            // 
//            // dtpCCTo5
//            // 
//            this.dtpCCTo5.CustomFormat = "dd/MM/yyyy";
//            this.dtpCCTo5.Enabled = false;
//            this.dtpCCTo5.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
//            this.dtpCCTo5.Location = new System.Drawing.Point(232, 176);
//            this.dtpCCTo5.Name = "dtpCCTo5";
//            this.dtpCCTo5.Size = new System.Drawing.Size(96, 20);
//            this.dtpCCTo5.TabIndex = 65;
//            this.dtpCCTo5.ValueChanged += new System.EventHandler(this.dtpCCTo5_ValueChanged);
//            // 
//            // dtpCCForm5
//            // 
//            this.dtpCCForm5.CustomFormat = "dd/MM/yyyy";
//            this.dtpCCForm5.Enabled = false;
//            this.dtpCCForm5.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
//            this.dtpCCForm5.Location = new System.Drawing.Point(120, 176);
//            this.dtpCCForm5.Name = "dtpCCForm5";
//            this.dtpCCForm5.Size = new System.Drawing.Size(96, 20);
//            this.dtpCCForm5.TabIndex = 64;
//            // 
//            // btnCal4
//            // 
//            this.btnCal4.Enabled = false;
//            this.btnCal4.Location = new System.Drawing.Point(56, 144);
//            this.btnCal4.Name = "btnCal4";
//            this.btnCal4.Size = new System.Drawing.Size(48, 23);
//            this.btnCal4.TabIndex = 58;
//            this.btnCal4.Text = "คำนวณ";
//            this.btnCal4.Click += new System.EventHandler(this.btnCal4_Click);
//            // 
//            // dtpCCTo4
//            // 
//            this.dtpCCTo4.CustomFormat = "dd/MM/yyyy";
//            this.dtpCCTo4.Enabled = false;
//            this.dtpCCTo4.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
//            this.dtpCCTo4.Location = new System.Drawing.Point(232, 144);
//            this.dtpCCTo4.Name = "dtpCCTo4";
//            this.dtpCCTo4.Size = new System.Drawing.Size(96, 20);
//            this.dtpCCTo4.TabIndex = 60;
//            this.dtpCCTo4.ValueChanged += new System.EventHandler(this.dtpCCTo4_ValueChanged);
//            // 
//            // dtpCCForm4
//            // 
//            this.dtpCCForm4.CustomFormat = "dd/MM/yyyy";
//            this.dtpCCForm4.Enabled = false;
//            this.dtpCCForm4.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
//            this.dtpCCForm4.Location = new System.Drawing.Point(120, 144);
//            this.dtpCCForm4.Name = "dtpCCForm4";
//            this.dtpCCForm4.Size = new System.Drawing.Size(96, 20);
//            this.dtpCCForm4.TabIndex = 59;
//            // 
//            // btnCal3
//            // 
//            this.btnCal3.Enabled = false;
//            this.btnCal3.Location = new System.Drawing.Point(56, 112);
//            this.btnCal3.Name = "btnCal3";
//            this.btnCal3.Size = new System.Drawing.Size(48, 23);
//            this.btnCal3.TabIndex = 53;
//            this.btnCal3.Text = "คำนวณ";
//            this.btnCal3.Click += new System.EventHandler(this.btnCal3_Click);
//            // 
//            // dtpCCTo3
//            // 
//            this.dtpCCTo3.CustomFormat = "dd/MM/yyyy";
//            this.dtpCCTo3.Enabled = false;
//            this.dtpCCTo3.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
//            this.dtpCCTo3.Location = new System.Drawing.Point(232, 112);
//            this.dtpCCTo3.Name = "dtpCCTo3";
//            this.dtpCCTo3.Size = new System.Drawing.Size(96, 20);
//            this.dtpCCTo3.TabIndex = 55;
//            this.dtpCCTo3.ValueChanged += new System.EventHandler(this.dtpCCTo3_ValueChanged);
//            // 
//            // dtpCCForm3
//            // 
//            this.dtpCCForm3.CustomFormat = "dd/MM/yyyy";
//            this.dtpCCForm3.Enabled = false;
//            this.dtpCCForm3.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
//            this.dtpCCForm3.Location = new System.Drawing.Point(120, 112);
//            this.dtpCCForm3.Name = "dtpCCForm3";
//            this.dtpCCForm3.Size = new System.Drawing.Size(96, 20);
//            this.dtpCCForm3.TabIndex = 54;
//            // 
//            // btnCal2
//            // 
//            this.btnCal2.Enabled = false;
//            this.btnCal2.Location = new System.Drawing.Point(56, 80);
//            this.btnCal2.Name = "btnCal2";
//            this.btnCal2.Size = new System.Drawing.Size(48, 23);
//            this.btnCal2.TabIndex = 48;
//            this.btnCal2.Text = "คำนวณ";
//            this.btnCal2.Click += new System.EventHandler(this.btnCal2_Click);
//            // 
//            // dtpCCTo2
//            // 
//            this.dtpCCTo2.CustomFormat = "dd/MM/yyyy";
//            this.dtpCCTo2.Enabled = false;
//            this.dtpCCTo2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
//            this.dtpCCTo2.Location = new System.Drawing.Point(232, 80);
//            this.dtpCCTo2.Name = "dtpCCTo2";
//            this.dtpCCTo2.Size = new System.Drawing.Size(96, 20);
//            this.dtpCCTo2.TabIndex = 50;
//            this.dtpCCTo2.ValueChanged += new System.EventHandler(this.dtpCCTo2_ValueChanged);
//            // 
//            // dtpCCForm2
//            // 
//            this.dtpCCForm2.CustomFormat = "dd/MM/yyyy";
//            this.dtpCCForm2.Enabled = false;
//            this.dtpCCForm2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
//            this.dtpCCForm2.Location = new System.Drawing.Point(120, 80);
//            this.dtpCCForm2.Name = "dtpCCForm2";
//            this.dtpCCForm2.Size = new System.Drawing.Size(96, 20);
//            this.dtpCCForm2.TabIndex = 49;
//            // 
//            // btnCal1
//            // 
//            this.btnCal1.Enabled = false;
//            this.btnCal1.Location = new System.Drawing.Point(56, 48);
//            this.btnCal1.Name = "btnCal1";
//            this.btnCal1.Size = new System.Drawing.Size(48, 23);
//            this.btnCal1.TabIndex = 43;
//            this.btnCal1.Text = "คำนวณ";
//            this.btnCal1.Click += new System.EventHandler(this.btnCal1_Click);
//            // 
//            // dtpCCTo1
//            // 
//            this.dtpCCTo1.CustomFormat = "dd/MM/yyyy";
//            this.dtpCCTo1.Enabled = false;
//            this.dtpCCTo1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
//            this.dtpCCTo1.Location = new System.Drawing.Point(232, 48);
//            this.dtpCCTo1.Name = "dtpCCTo1";
//            this.dtpCCTo1.Size = new System.Drawing.Size(96, 20);
//            this.dtpCCTo1.TabIndex = 45;
//            this.dtpCCTo1.ValueChanged += new System.EventHandler(this.dtpCCTo1_ValueChanged);
//            // 
//            // dtpCCForm1
//            // 
//            this.dtpCCForm1.CustomFormat = "dd/MM/yyyy";
//            this.dtpCCForm1.Enabled = false;
//            this.dtpCCForm1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
//            this.dtpCCForm1.Location = new System.Drawing.Point(120, 48);
//            this.dtpCCForm1.Name = "dtpCCForm1";
//            this.dtpCCForm1.Size = new System.Drawing.Size(96, 20);
//            this.dtpCCForm1.TabIndex = 44;
//            // 
//            // label19
//            // 
//            this.label19.BackColor = System.Drawing.SystemColors.AppWorkspace;
//            this.label19.Location = new System.Drawing.Point(120, 16);
//            this.label19.Name = "label19";
//            this.label19.Size = new System.Drawing.Size(208, 23);
//            this.label19.TabIndex = 37;
//            this.label19.Text = "สัญญาระหว่างวันที่";
//            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
//            // 
//            // frmContractDriver
//            // 
//            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
//            this.ClientSize = new System.Drawing.Size(822, 628);
//            this.Controls.Add(this.grbServiceCharge);
//            this.Name = "frmContractDriver";
//            //this.Text = "ข้อมูลเอกสารสัญญาสำหรับพนักงานขับรถ";
//            this.Load += new System.EventHandler(this.frmContractDriver_Load);
//            this.Controls.SetChildIndex(this.gpbAssignment, 0);
//            this.Controls.SetChildIndex(this.gpbDeleteContract, 0);
//            this.Controls.SetChildIndex(this.grbServiceCharge, 0);
//            this.grbServiceCharge.ResumeLayout(false);
//            this.ResumeLayout(false);

//        }
//        #endregion

//        #region - Constant -
//            const int NUMBER_OF_CONTRACT_CHARGE = 6;
//        #endregion

//        #region - Private -
//            private struct ContractChargeControl
//            {
//                public Label yearLabel;
//                public Button CalculateButton;
//                public DateTimePicker FormDateDTP;
//                public DateTimePicker ToDateDTP;
//                public UCTContractCharge UCTContractCharge;
//            }

//            private bool isReadonly = true;
//            private DateTime[] chargeDate = new DateTime[6];
//            private int chargeDateIndex = 0;
//            private DateTimePicker lastDateTimePicker;
//        #endregion

//        //==============================  Constructor  ==============================
//        public TMPfrmContractDriver() : base()
//        {
//            InitializeComponent();
//            isReadonly = UserProfile.IsReadOnly("miContract", "miContractDriver");
//            this.title = UserProfile.GetFormName("miContract", "miContractDriver");

//        }
//        public override string FormID()
//        {
//            return UserProfile.GetFormID("miContract", "miContractDriver");
//        }

//        #region - Validate -
//        private bool validateContract()
//        {
//            if(dtpContractStart.Value.Date > dtpContractEnd.Value.Date)
//            {
//                Message(MessageList.Error.E0011,"วันที่เริ่มต้นสัญญา","วันที่สิ้นสุดสัญญา");
//                dtpContractStart.Focus();
//                return false; 
//            }

//            if(rdoDay.Checked)
//            {
//                DateTime cosiderMonth = dtpContractStart.Value.AddMonths(2);
//                if(getYearMonth(dtpContractEnd.Value)>getYearMonth(cosiderMonth))
//                {
//                    Message(MessageList.Error.E0005, "ช่วงสัญญาไม่เกิน 3 เดือน");
//                    dtpContractEnd.Focus();
//                    return false;
//                }
//            }
//            else
//            {
//                int yearCount = calculateYear(dtpContractStart.Value.Date, dtpContractEnd.Value.Date);
//                if(yearCount>6)
//                {
//                    Message(MessageList.Error.E0005, "ช่วงสัญญาไม่เกิน 5 ปี");
//                    dtpContractEnd.Focus();
//                    return false;
//                }
//            }

//            return true;
//        }

//        private bool validateInputContractChagre(ContractChargeControl control)
//        {
//            if(control.FormDateDTP.Value>control.ToDateDTP.Value)
//            {
//                Message(MessageList.Error.E0011,"วันที่เริ่มต้น","วันที่สิ้นสุด");
//                control.ToDateDTP.Focus();
//                return false; 
//            }

//            if (control.UCTContractCharge.RateAmount == 0)
//            {
//                DialogResult dialog = Message(MessageList.Warning.W0001);

//                if (dialog.Equals(DialogResult.Cancel))
//                {
//                    control.UCTContractCharge.Focus();
//                    return false;
//                }
//            }

//            if(rdoDay.Checked && control.UCTContractCharge.RateAmount>32000)
//            {
//                Message(MessageList.Error.E0041);
//                control.UCTContractCharge.Focus();
//                return false;
//            }

//            return true;
//        }
		
//        private bool validateUCTContractChagre(ContractChargeControl control)
//        {
//            bool result = false;

//            if(control.FormDateDTP.Value.Date>control.ToDateDTP.Value.Date)
//            {
//                Message(MessageList.Error.E0011, "วันที่เริ่มต้น", "วันที่สิ้นสุด");
//                control.ToDateDTP.Focus();
//                return false;
//            }

//            if(control.UCTContractCharge.RateAmount == 0)
//            {
//                return true;
//            }
//            else
//            {
//                if(control.UCTContractCharge.FirstMonth != 0)
//                {
//                    if(control.UCTContractCharge.RateAmountTag == control.UCTContractCharge.RateAmount)
//                    {
//                        if(control.UCTContractCharge.DateForm == control.FormDateDTP.Value.Date)
//                        {
//                            if(control.UCTContractCharge.DateTo == control.ToDateDTP.Value.Date)
//                            {
//                                if(control.UCTContractCharge.RateStatusByMonth == rdoMonth.Checked)
//                                {
//                                    result = true;
//                                }
//                            }
//                        }
//                    }			
//                }
//                else
//                {
//                    result = false;
//                }

//                if(!result)
//                {
//                    Message(MessageList.Error.E0017);
//                    control.CalculateButton.Focus();
//                    return false;
//                }		
//            }

//            return result;
//        }

//        protected override bool validateContractCharge()
//        {
//            if(!validateContract())
//            {
//                return false;
//            }

//            if(flagDateForm != dtpContractStart.Value.Date)
//            {
//                Message(MessageList.Error.E0042, "");
//                btnCreate.Focus();
//                return false;
//            }
//            if(flagDateTo != dtpContractEnd.Value.Date)
//            {
//                Message(MessageList.Error.E0042, "");
//                btnCreate.Focus();
//                return false;
//            }

//            if(lastDateTimePicker.Value!=dtpContractEnd.Value)
//            {
//                Message(MessageList.Error.E0042);
//                btnCreate.Focus();
//                return false;
//            }

//            if (uctContractCharge1.RateAmount == 0)
//            {
//                DialogResult dialog = Message(MessageList.Warning.W0001);

//                if (dialog.Equals(DialogResult.Cancel))
//                {
//                    uctContractCharge1.Focus();
//                    return false;
//                }
//            }

//            //if(uctContractCharge1.RateAmount==0)
//            //{
//            //    Message(MessageList.Error.E0002, "อัตราค่าบริการ");
//            //    uctContractCharge1.Focus();
//            //    return false;
//            //}

//            ContractChargeControl control;
//            for(int i=0; i<6; i++)
//            {
//                control = getControl(i);
//                if(control.UCTContractCharge.UnitChargeEnable)
//                {
//                    if(!validateUCTContractChagre(control))
//                    {
//                        return false;					
//                    }
//                }
//            }

//            return true;
//        }

//        #endregion

//        protected override void setContractBase(ContractBase value)
//        {
//            base.setContractBase(value);
//            flagDateForm = value.AContractChargeList[0].APeriod.From;
//            flagDateTo = value.AContractChargeList[value.AContractChargeList.Count-1].APeriod.To;
//            setUCT(0, value.AContractChargeList);
			
//            if(isReadonly)
//            {
//                grbServiceCharge.Enabled = false;
//                IsMustQuestion = false;
//            }
//        }

//        private void fillContractCharge(ContractChargeControl control, int index, ContractChargeList value)
//        {
//            visibleContractCharge(control, true);
//            enableContractChargeControl(control, index, value.Count);
////			control.CalculateButton.Enabled = true;

//            ContractCharge contractCharge = value[index];

//            bindContractCharge(control.UCTContractCharge, contractCharge);

//            control.FormDateDTP.Value = contractCharge.APeriod.From.Date;
//            control.ToDateDTP.Value = contractCharge.APeriod.To.Date;

//            contractCharge = null;
//        }

//        private void setUCT(int index, ContractChargeList value)
//        {
//            ContractChargeControl control = getControl(index);
//            fillContractCharge(control, index, value);			

//            if(index == value.Count-1)
//            {
//                lastDateTimePicker = control.ToDateDTP;
//                return;
//            }
//            else
//            {
//                setUCT(index+1, value);
//            }
//        }

//        private void fillUCTContractCharge(ContractChargeControl control)
//        {
//            control.UCTContractCharge.RateAmountTag = control.UCTContractCharge.RateAmount;
//            control.UCTContractCharge.DateForm = control.FormDateDTP.Value.Date;
//            control.UCTContractCharge.DateTo = control.ToDateDTP.Value.Date;
//            control.UCTContractCharge.RateStatusByMonth = rdoMonth.Checked;
//            control.UCTContractCharge.UnitChargeAmountByMonth();			
//        }

//        private void getUCT(int index, ContractChargeList value)
//        {
//            if(index<NUMBER_OF_CONTRACT_CHARGE)
//            {
//                ContractChargeControl control = getControl(index);
//                if(control.UCTContractCharge.UnitChargeEnable)
//                {
//                    fillUCTContractCharge(control);
//                    value.Add(getContractCharge(control.UCTContractCharge));
//                    getUCT(index+1, value);
//                }
//                else
//                {
//                    return;
//                }			
//            }
//            else
//            {
//                return;
//            }
//        }

//        #region - Private -
//            private void setIsMustQuestion()
//            {
//                if (isReadonly)
//                    IsMustQuestion = false;
//                else
//                    IsMustQuestion = true;
//            }

//            private int getYearMonth(DateTime value)
//            {
//                int result = value.Year * 100;
//                result = result + value.Month;
//                return result;
//            }

//            #region - Clear & Visible Control -
//                private void clearContractCharge(ContractChargeControl control)
//                {
//                    control.CalculateButton.Enabled = false;
//                    control.FormDateDTP.Value = DateTime.Today.Date;
//                    control.ToDateDTP.Value = DateTime.Today.Date;
//                    control.ToDateDTP.Enabled = false;
//                    control.UCTContractCharge.Clear();
//                    control.UCTContractCharge.UnitChargeEnable = false;

//                    visibleContractCharge(control, false);
//                }

//                private void visibleContractCharge(ContractChargeControl control, bool visible)
//                {
//                    control.yearLabel.Visible = visible;
//                    control.CalculateButton.Visible = visible;
//                    control.FormDateDTP.Visible = visible;
//                    control.ToDateDTP.Visible = visible;
//                    control.UCTContractCharge.Visible = visible;
//                }

//                private void enableContractChargeControl(ContractChargeControl control, int index, int count)
//                {
//                    control.CalculateButton.Enabled = true;
//                    control.UCTContractCharge.UnitChargeEnable = true;


//                    control.ToDateDTP.Enabled = true;
////					if(index == count-1)
////					{
////						control.ToDateDTP.Enabled = false;
////					}
////					else
////					{
////						control.ToDateDTP.Enabled = true;
////					}
//                }
//            #endregion

//            #region - Get Control -
//                private ContractChargeControl getControl(int index)
//                {
//                    ContractChargeControl contractChargeControl = new ContractChargeControl();
//                    switch(index)
//                    {
//                        case 0:
//                        {
//                            contractChargeControl.yearLabel = lblYear1;
//                            contractChargeControl.CalculateButton = btnCal1;
//                            contractChargeControl.FormDateDTP = dtpCCForm1;
//                            contractChargeControl.ToDateDTP = dtpCCTo1;
//                            contractChargeControl.UCTContractCharge = uctContractCharge1;
//                            break;
//                        }
//                        case 1:
//                        {
//                            contractChargeControl.yearLabel = lblYear2;
//                            contractChargeControl.CalculateButton = btnCal2;
//                            contractChargeControl.FormDateDTP = dtpCCForm2;
//                            contractChargeControl.ToDateDTP = dtpCCTo2;
//                            contractChargeControl.UCTContractCharge = uctContractCharge2;
//                            break;
//                        }
//                        case 2:
//                        {
//                            contractChargeControl.yearLabel = lblYear3;
//                            contractChargeControl.CalculateButton = btnCal3;
//                            contractChargeControl.FormDateDTP = dtpCCForm3;
//                            contractChargeControl.ToDateDTP = dtpCCTo3;
//                            contractChargeControl.UCTContractCharge = uctContractCharge3;
//                            break;
//                        }
//                        case 3:
//                        {
//                            contractChargeControl.yearLabel = lblYear4;
//                            contractChargeControl.CalculateButton = btnCal4;
//                            contractChargeControl.FormDateDTP = dtpCCForm4;
//                            contractChargeControl.ToDateDTP = dtpCCTo4;
//                            contractChargeControl.UCTContractCharge = uctContractCharge4;
//                            break;
//                        }
//                        case 4:
//                        {
//                            contractChargeControl.yearLabel = lblYear5;
//                            contractChargeControl.CalculateButton = btnCal5;
//                            contractChargeControl.FormDateDTP = dtpCCForm5;
//                            contractChargeControl.ToDateDTP = dtpCCTo5;
//                            contractChargeControl.UCTContractCharge = uctContractCharge5;
//                            break;
//                        }
//                        case 5:
//                        {
//                            contractChargeControl.yearLabel = lblYear6;
//                            contractChargeControl.CalculateButton = btnCal6;
//                            contractChargeControl.FormDateDTP = dtpCCForm6;
//                            contractChargeControl.ToDateDTP = dtpCCTo6;
//                            contractChargeControl.UCTContractCharge = uctContractCharge6;
//                            break;
//                        }
//                    }
//                    return contractChargeControl;
//                }
//            #endregion

//            #region - Calculate & Bind Year -
//                private DateTime getChangeRateDate(DateTime value)
//                {
//                    if(value.Month<5)
//                    {
//                        return new DateTime(value.Year, 5, 1);
//                    }
//                    else
//                    {
//                        return new DateTime(value.Year+1, 5, 1);
//                    }
//                }

//                private int calculateYear(DateTime value, DateTime toDate)
//                {
//                    if(value<=toDate)
//                    {
//                        DateTime changeRateDate = getChangeRateDate(value);
//                        if(chargeDateIndex<NUMBER_OF_CONTRACT_CHARGE)
//                        {
//                            chargeDate[chargeDateIndex++] = changeRateDate.AddDays(-1);
//                        }
//                        if(value<changeRateDate)
//                        {
//                            return calculateYear(changeRateDate, toDate) + 1;
//                        }
//                        else
//                        {
//                            return calculateYear(changeRateDate.AddYears(1), toDate) + 1;
//                        }
//                    }
//                    else
//                    {
//                        return 0;
//                    }
//                }

//                private void bindYear(int index, int count)
//                {
//                    ContractChargeControl contractChargeControl = getControl(index);
//                    visibleContractCharge(contractChargeControl, true);
//                    enableContractChargeControl(contractChargeControl, index, count);

//                    if(index == count-1)
//                    {
//                        dtpCCForm1.Value = dtpContractStart.Value;
//                        contractChargeControl.ToDateDTP.Value = dtpContractEnd.Value;
//                        lastDateTimePicker = contractChargeControl.ToDateDTP;
//                    }
//                    else
//                    {
//                        contractChargeControl.ToDateDTP.Value = chargeDate[index];
//                        bindYear(index+1, count);
//                    }
//                }
//            #endregion
//        #endregion

//        #region - protected Method -
//            protected override void visibleChild(bool visible)
//            {
//                grbServiceCharge.Visible = visible;
//            }

//            protected override void addCase()
//            {
//                base.addCase();
//                grbServiceCharge.Visible = true;
//            }

//            protected override void enableCalculate(bool enable)
//            {
//                btnCreate.Enabled = enable;
//                if(!enable)
//                {
//                    enableContractCharge(false);
//                }
//            }

//            protected override void enableContractCharge(bool enable)
//            {
//                if(!enable)
//                {
//                    ContractChargeControl contractChargeControl;
//                    for(int i=0; i<6; i++)
//                    {
//                        contractChargeControl = getControl(i);
//                        contractChargeControl.CalculateButton.Enabled = false;
//                        contractChargeControl.ToDateDTP.Enabled = false;
//                        contractChargeControl.UCTContractCharge.UnitChargeEnable = false;
//                    }
//                }
//            }

//            protected override void addContractCharge(ContractBase value)
//            {
//                value.AContractChargeList.Clear();
//                getUCT(0, value.AContractChargeList);
//            }

//            protected override void ClearContractCharge()
//            {
//                clearContractCharge(getControl(0));
//                clearContractCharge(getControl(1));
//                clearContractCharge(getControl(2));
//                clearContractCharge(getControl(3));
//                clearContractCharge(getControl(4));
//                clearContractCharge(getControl(5));	
//            }
//        #endregion

//        //==============================  Base Event   ==============================
//        private DateTime flagDateForm;
//        private DateTime flagDateTo;
		
//        private void calculateEnableCharge()
//        {
//            chargeDateIndex = 0;
//            try
//            {
//                int enableCount = calculateYear(dtpContractStart.Value.Date, dtpContractEnd.Value.Date);
//                if(enableCount>0 && enableCount<7)
//                {
//                    bindYear(0, enableCount);
//                }
//                flagDateForm = dtpContractStart.Value.Date;
//                flagDateTo = dtpContractEnd.Value.Date;
//            }
//            catch(SqlException sqlex)
//            {
//                Message(sqlex);
//            }
//            catch(AppExceptionBase ex)
//            {
//                Message(ex);
//            }
//            catch(Exception ex)
//            {
//                Message(ex);
//            }
//            finally
//            {}
//        }

//        private void claculateClick(int index)
//        {
//            if(lastDateTimePicker.Value!=dtpContractEnd.Value)
//            {
//                Message(MessageList.Error.E0042);
//                btnCreate.Focus();
//                return;
//            }

//            ContractChargeControl control = getControl(index);
//            if(control.UCTContractCharge.UnitChargeEnable && !validateInputContractChagre(control))
//            {
//                return;
//            }

//            try
//            {
//                fillUCTContractCharge(control);
//            }
//            catch(SqlException sqlex)
//            {
//                Message(sqlex);
//            }
//            catch(AppExceptionBase ex)
//            {
//                Message(ex);
//            }
//            catch(Exception ex)
//            {
//                Message(ex);
//            }
//            finally
//            {}
//        }

//        //============================== Public Method ==============================
		
//        //==============================     event     ==============================
//        private void frmContractDriver_Load(object sender, System.EventArgs e)
//        {
//            setPermission(isReadonly);
//            InitForm();
//            initCombo();
//            selectContract("D");
//        }

//        private void btnCreate_Click(object sender, System.EventArgs e)
//        {
//            setIsMustQuestion();
//            if(validateContract())
//            {
//                if(uctContractCharge1.Visible)
//                {
//                    if (Message(MessageList.Question.Q0008) == DialogResult.Yes)
//                    {
//                        ClearContractCharge();
//                        calculateEnableCharge();
//                    }
//                }
//                else
//                {
//                    ClearContractCharge();
//                    calculateEnableCharge();
//                }
//            }
//        }

//        #region - btnCalX_Click -
//            private void btnCal1_Click(object sender, System.EventArgs e)
//            {
//                setIsMustQuestion();
//                claculateClick(0);
//            }

//            private void btnCal2_Click(object sender, System.EventArgs e)
//            {
//                setIsMustQuestion();
//                claculateClick(1);
//            }

//            private void btnCal3_Click(object sender, System.EventArgs e)
//            {
//                setIsMustQuestion();
//                claculateClick(2);
//            }

//            private void btnCal4_Click(object sender, System.EventArgs e)
//            {
//                setIsMustQuestion();
//                claculateClick(3);
//            }

//            private void btnCal5_Click(object sender, System.EventArgs e)
//            {
//                setIsMustQuestion();
//                claculateClick(4);
//            }

//            private void btnCal6_Click(object sender, System.EventArgs e)
//            {
//                setIsMustQuestion();
//                claculateClick(5);
//            }
//        #endregion

//        #region - dtpCCToX_ValueChanged -
//            private void dtpCCTo1_ValueChanged(object sender, System.EventArgs e)
//            {
//                setIsMustQuestion();
//                dtpCCForm2.Value = dtpCCTo1.Value.AddDays(1);
//            }

//            private void dtpCCTo2_ValueChanged(object sender, System.EventArgs e)
//            {
//                setIsMustQuestion();
//                dtpCCForm3.Value = dtpCCTo2.Value.AddDays(1);
//            }

//            private void dtpCCTo3_ValueChanged(object sender, System.EventArgs e)
//            {
//                setIsMustQuestion();
//                dtpCCForm4.Value = dtpCCTo3.Value.AddDays(1);
//            }

//            private void dtpCCTo4_ValueChanged(object sender, System.EventArgs e)
//            {
//                setIsMustQuestion();
//                dtpCCForm5.Value = dtpCCTo4.Value.AddDays(1);
//            }

//            private void dtpCCTo5_ValueChanged(object sender, System.EventArgs e)
//            {
//                setIsMustQuestion();
//                dtpCCForm6.Value = dtpCCTo5.Value.AddDays(1);
//            }
//        #endregion

//    }
//}