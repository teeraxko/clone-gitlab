//using System;
//using System.Collections;
//using System.ComponentModel;
//using System.Drawing;
//using System.Windows.Forms;

//using Entity.ContractEntities;

//using SystemFramework.AppMessage;
//using SystemFramework.AppConfig;

//namespace Presentation.ContractGUI
//{
//    public class TMPfrmContractOtherServiceStaff : Presentation.ContractGUI.TMPfrmContract
//    {
//        #region Designer generated code
//        private System.Windows.Forms.GroupBox grbServiceCharge;
//        private System.Windows.Forms.Label label8;
//        private System.Windows.Forms.Label label18;
//        private System.Windows.Forms.Label label16;
//        private System.Windows.Forms.Label label14;
//        private System.Windows.Forms.Button btnCal;
//        private Presentation.ContractGUI.UCTContractCharge uctContractCharge1;
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
//            this.label8 = new System.Windows.Forms.Label();
//            this.label18 = new System.Windows.Forms.Label();
//            this.label16 = new System.Windows.Forms.Label();
//            this.label14 = new System.Windows.Forms.Label();
//            this.btnCal = new System.Windows.Forms.Button();
//            this.uctContractCharge1 = new Presentation.ContractGUI.UCTContractCharge();
//            this.grbServiceCharge.SuspendLayout();
//            this.SuspendLayout();
//            // 
//            // gpbAssignment
//            // 
//            this.gpbAssignment.Location = new System.Drawing.Point(328, 272);
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
//            this.gpbDeleteContract.Location = new System.Drawing.Point(24, 272);
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
//            this.grbServiceCharge.Controls.Add(this.label8);
//            this.grbServiceCharge.Controls.Add(this.label18);
//            this.grbServiceCharge.Controls.Add(this.label16);
//            this.grbServiceCharge.Controls.Add(this.label14);
//            this.grbServiceCharge.Controls.Add(this.btnCal);
//            this.grbServiceCharge.Controls.Add(this.uctContractCharge1);
//            this.grbServiceCharge.Location = new System.Drawing.Point(23, 192);
//            this.grbServiceCharge.Name = "grbServiceCharge";
//            this.grbServiceCharge.Size = new System.Drawing.Size(776, 80);
//            this.grbServiceCharge.TabIndex = 40;
//            this.grbServiceCharge.TabStop = false;
//            this.grbServiceCharge.Text = "ค่าบริการ";
//            this.grbServiceCharge.Visible = false;
//            // 
//            // label8
//            // 
//            this.label8.BackColor = System.Drawing.SystemColors.AppWorkspace;
//            this.label8.Location = new System.Drawing.Point(344, 16);
//            this.label8.Name = "label8";
//            this.label8.Size = new System.Drawing.Size(96, 23);
//            this.label8.TabIndex = 41;
//            this.label8.Text = "อัตราค่าบริการ";
//            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
//            // 
//            // label18
//            // 
//            this.label18.BackColor = System.Drawing.SystemColors.AppWorkspace;
//            this.label18.Location = new System.Drawing.Point(560, 16);
//            this.label18.Name = "label18";
//            this.label18.Size = new System.Drawing.Size(88, 23);
//            this.label18.TabIndex = 43;
//            this.label18.Text = "เดือนถัดไป";
//            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
//            // 
//            // label16
//            // 
//            this.label16.BackColor = System.Drawing.SystemColors.AppWorkspace;
//            this.label16.Location = new System.Drawing.Point(664, 16);
//            this.label16.Name = "label16";
//            this.label16.Size = new System.Drawing.Size(88, 23);
//            this.label16.TabIndex = 44;
//            this.label16.Text = "เดือนสุดท้าย";
//            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
//            // 
//            // label14
//            // 
//            this.label14.BackColor = System.Drawing.SystemColors.AppWorkspace;
//            this.label14.Location = new System.Drawing.Point(456, 16);
//            this.label14.Name = "label14";
//            this.label14.Size = new System.Drawing.Size(88, 23);
//            this.label14.TabIndex = 42;
//            this.label14.Text = "เดือนแรก";
//            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
//            // 
//            // btnCal
//            // 
//            this.btnCal.Enabled = false;
//            this.btnCal.Location = new System.Drawing.Point(264, 48);
//            this.btnCal.Name = "btnCal";
//            this.btnCal.Size = new System.Drawing.Size(72, 23);
//            this.btnCal.TabIndex = 45;
//            this.btnCal.Text = "คำนวณ";
//            this.btnCal.Click += new System.EventHandler(this.btnCal_Click);
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
//            // frmContractOtherServiceStaff
//            // 
//            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
//            this.ClientSize = new System.Drawing.Size(822, 628);
//            this.Controls.Add(this.grbServiceCharge);
//            this.Name = "frmContractOtherServiceStaff";
//            //this.Text = "ข้อมูลเอกสารสัญญาสำหรับพนักงานบริการอื่น ๆ";
//            this.Load += new System.EventHandler(this.frmContractOtherServiceStaff_Load);
//            this.Controls.SetChildIndex(this.gpbAssignment, 0);
//            this.Controls.SetChildIndex(this.gpbDeleteContract, 0);
//            this.Controls.SetChildIndex(this.grbServiceCharge, 0);
//            this.grbServiceCharge.ResumeLayout(false);
//            this.ResumeLayout(false);

//        }
//        #endregion

//        private bool isReadonly = true;

//        //==============================  Constructor  ==============================
//        public TMPfrmContractOtherServiceStaff() : base()
//        {
//            InitializeComponent();
//            visibleChild(false);
//            isReadonly = UserProfile.IsReadOnly("miContract", "miContractOtherServiceStaft");
//            this.title = UserProfile.GetFormName("miContract", "miContractOtherServiceStaft");

//        }
//        public override string FormID()
//        {
//            return UserProfile.GetFormID("miContract", "miContractOtherServiceStaft");
//        }
//        #region - Private Method -
//        private void setIsMustQuestion()
//        {
//            if (isReadonly)
//                IsMustQuestion = false;
//            else
//                IsMustQuestion = true;
//        }

//        private int getYearMonth(DateTime value)
//        {
//            int result = value.Year * 100;
//            result = result + value.Month;
//            return result;
//        }

//        private bool validateContractChageInput()
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

//            if(uctContractCharge1.RateAmount==0)
//            {
//                Message(MessageList.Error.E0002, "อัตราค่าบริการ");
//                uctContractCharge1.Focus();
//                return false;
//            }

//            if(rdoDay.Checked && uctContractCharge1.RateAmount>32000)
//            {
//                Message(MessageList.Error.E0041);
//                uctContractCharge1.Focus();
//                return false;
//            }

//            return true;
//        }
//        #endregion

//        #region - Validate -
//        protected override bool validateContractCharge()
//        {
//            bool result = validateContractChageInput();
//            if(!result)
//            {
//                return false;
//            }

//            result = false;
//            if(uctContractCharge1.FirstMonth != 0)
//            {
//                if(uctContractCharge1.RateAmountTag == uctContractCharge1.RateAmount)
//                {
//                    if(uctContractCharge1.DateForm == dtpContractStart.Value.Date)
//                    {
//                        if(uctContractCharge1.DateTo == dtpContractEnd.Value.Date)
//                        {
//                            if(uctContractCharge1.RateStatusByMonth == rdoMonth.Checked)
//                            {
//                                result = true;
//                            }
//                        }
//                    }
//                }			
//            }
//            else
//            {
//                result = false;
//            }

//            if(!result)
//            {
//                Message(MessageList.Error.E0017);
//                btnCal.Focus();
//                return false;
//            }

//            return result;
//        }

//        #endregion

//        #region - protected Method -
//        protected override void addCase()
//        {
//            base.addCase();
//            grbServiceCharge.Visible = true;
//        }

//        protected override void setContractBase(ContractBase value)
//        {
//            base.setContractBase(value);
//            bindContractCharge(uctContractCharge1, value.AContractChargeList[0]);
//        }
			
//        protected override void visibleChild(bool visible)
//        {
//            grbServiceCharge.Visible = visible;
//        }

//        protected override void enableCalculate(bool enable)
//        {
//            btnCal.Enabled = enable;
//        }

//        protected override void enableContractCharge(bool enable)
//        {
//            uctContractCharge1.UnitChargeEnable = enable;
//        }

//        protected override void addContractCharge(ContractBase value)
//        {
//            value.AContractChargeList.Clear();
//            value.AContractChargeList.Add(getContractCharge(uctContractCharge1));
//        }

//        protected override void ClearContractCharge()
//        {
//            uctContractCharge1.Clear();
//        }
//        #endregion

//        //==============================  Base Event   ==============================

//        //============================== Public Method ==============================
		
//        //==============================     event     ==============================
//        private void frmContractOtherServiceStaff_Load(object sender, System.EventArgs e)
//        {
//            setPermission(isReadonly);
//            InitForm();
//            initCombo();
//            selectContract("O");			
//        }

//        private void btnCal_Click(object sender, System.EventArgs e)
//        {
//            setIsMustQuestion();
//            if(!validateContractChageInput())
//            {
//                return;
//            }

//            uctContractCharge1.RateAmountTag = uctContractCharge1.RateAmount;

//            uctContractCharge1.DateForm = dtpContractStart.Value.Date;
//            uctContractCharge1.DateTo = dtpContractEnd.Value.Date;
//            uctContractCharge1.RateStatusByMonth = rdoMonth.Checked;
//            uctContractCharge1.UnitChargeAmountByMonth();
//        }
//    }
//}