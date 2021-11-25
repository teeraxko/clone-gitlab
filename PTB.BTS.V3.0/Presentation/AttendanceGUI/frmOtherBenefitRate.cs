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
using Entity.AttendanceEntities;

using Facade.CommonFacade;
using Facade.AttendanceFacade;

using Presentation.CommonGUI;

namespace Presentation.AttendanceGUI
{
	public class frmOtherBenefitRate : ChildFormBase, IMDIChildForm
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
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.Button cmdCancel;
		protected FarPoint.Win.Input.FpDouble fpdTaxi;
		protected FarPoint.Win.Input.FpDouble fpdFood;
		protected FarPoint.Win.Input.FpDouble fpdTravelNear;
		protected FarPoint.Win.Input.FpDouble fpdTravelFar;
		protected FarPoint.Win.Input.FpDouble fpdOvernightTrip;
		protected FarPoint.Win.Input.FpDouble fpdExtra;
		protected FarPoint.Win.Input.FpDouble fpdExtraAGT;
		protected FarPoint.Win.Input.FpDouble fpdDeductAGT;
		protected FarPoint.Win.Input.FpDouble fpdTaxiForCharge;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label18;
        private Label label20;
        protected FarPoint.Win.Input.FpDouble fpDMealAllowance;
        private Label lbtMealAllowance;

		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label20 = new System.Windows.Forms.Label();
            this.fpDMealAllowance = new FarPoint.Win.Input.FpDouble();
            this.lbtMealAllowance = new System.Windows.Forms.Label();
            this.fpdTaxiForCharge = new FarPoint.Win.Input.FpDouble();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.fpdTravelFar = new FarPoint.Win.Input.FpDouble();
            this.fpdDeductAGT = new FarPoint.Win.Input.FpDouble();
            this.fpdExtraAGT = new FarPoint.Win.Input.FpDouble();
            this.fpdExtra = new FarPoint.Win.Input.FpDouble();
            this.fpdOvernightTrip = new FarPoint.Win.Input.FpDouble();
            this.fpdFood = new FarPoint.Win.Input.FpDouble();
            this.fpdTaxi = new FarPoint.Win.Input.FpDouble();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.fpdTravelNear = new FarPoint.Win.Input.FpDouble();
            this.label12 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.fpDMealAllowance);
            this.groupBox1.Controls.Add(this.lbtMealAllowance);
            this.groupBox1.Controls.Add(this.fpdTaxiForCharge);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.fpdTravelFar);
            this.groupBox1.Controls.Add(this.fpdDeductAGT);
            this.groupBox1.Controls.Add(this.fpdExtraAGT);
            this.groupBox1.Controls.Add(this.fpdExtra);
            this.groupBox1.Controls.Add(this.fpdOvernightTrip);
            this.groupBox1.Controls.Add(this.fpdFood);
            this.groupBox1.Controls.Add(this.fpdTaxi);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(27, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(448, 318);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(368, 250);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(24, 23);
            this.label20.TabIndex = 29;
            this.label20.Text = "บาท";
            // 
            // fpDMealAllowance
            // 
            this.fpDMealAllowance.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpDMealAllowance.AllowClipboardKeys = true;
            this.fpDMealAllowance.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.fpDMealAllowance.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpDMealAllowance.DecimalPlaces = 0;
            this.fpDMealAllowance.FixedPoint = true;
            this.fpDMealAllowance.Location = new System.Drawing.Point(271, 282);
            this.fpDMealAllowance.Name = "fpDMealAllowance";
            this.fpDMealAllowance.NumberGroupSeparator = ",";
            this.fpDMealAllowance.Size = new System.Drawing.Size(80, 20);
            this.fpDMealAllowance.TabIndex = 28;
            this.fpDMealAllowance.Text = "";
            this.fpDMealAllowance.UseSeparator = true;
            // 
            // lbtMealAllowance
            // 
            this.lbtMealAllowance.Location = new System.Drawing.Point(56, 282);
            this.lbtMealAllowance.Name = "lbtMealAllowance";
            this.lbtMealAllowance.Size = new System.Drawing.Size(192, 24);
            this.lbtMealAllowance.TabIndex = 27;
            this.lbtMealAllowance.Text = "Meal Allowance ( ต่อเดือน )";
            // 
            // fpdTaxiForCharge
            // 
            this.fpdTaxiForCharge.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpdTaxiForCharge.AllowClipboardKeys = true;
            this.fpdTaxiForCharge.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.fpdTaxiForCharge.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdTaxiForCharge.DecimalPlaces = 0;
            this.fpdTaxiForCharge.FixedPoint = true;
            this.fpdTaxiForCharge.Location = new System.Drawing.Point(271, 56);
            this.fpdTaxiForCharge.Name = "fpdTaxiForCharge";
            this.fpdTaxiForCharge.NumberGroupSeparator = ",";
            this.fpdTaxiForCharge.Size = new System.Drawing.Size(80, 20);
            this.fpdTaxiForCharge.TabIndex = 2;
            this.fpdTaxiForCharge.Text = "";
            this.fpdTaxiForCharge.UseSeparator = true;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(368, 279);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(24, 23);
            this.label10.TabIndex = 17;
            this.label10.Text = "บาท";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(56, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(176, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "อัตราค่าเดินทางต่างจังหวัด ( ไป - กลับ )";
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(368, 56);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(24, 23);
            this.label17.TabIndex = 26;
            this.label17.Text = "บาท";
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(56, 56);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(176, 23);
            this.label18.TabIndex = 24;
            this.label18.Text = "อัตราค่าแท็กซี่สำหรับลูกค้า ( ต่อเที่ยว )";
            // 
            // fpdTravelFar
            // 
            this.fpdTravelFar.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpdTravelFar.AllowClipboardKeys = true;
            this.fpdTravelFar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.fpdTravelFar.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdTravelFar.DecimalPlaces = 0;
            this.fpdTravelFar.FixedPoint = true;
            this.fpdTravelFar.Location = new System.Drawing.Point(271, 121);
            this.fpdTravelFar.Name = "fpdTravelFar";
            this.fpdTravelFar.NumberGroupSeparator = ",";
            this.fpdTravelFar.Size = new System.Drawing.Size(80, 20);
            this.fpdTravelFar.TabIndex = 5;
            this.fpdTravelFar.Text = "";
            this.fpdTravelFar.UseSeparator = true;
            // 
            // fpdDeductAGT
            // 
            this.fpdDeductAGT.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpdDeductAGT.AllowClipboardKeys = true;
            this.fpdDeductAGT.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.fpdDeductAGT.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdDeductAGT.DecimalPlaces = 0;
            this.fpdDeductAGT.FixedPoint = true;
            this.fpdDeductAGT.Location = new System.Drawing.Point(271, 249);
            this.fpdDeductAGT.Name = "fpdDeductAGT";
            this.fpdDeductAGT.NumberGroupSeparator = ",";
            this.fpdDeductAGT.Size = new System.Drawing.Size(80, 20);
            this.fpdDeductAGT.TabIndex = 9;
            this.fpdDeductAGT.Text = "";
            this.fpdDeductAGT.UseSeparator = true;
            // 
            // fpdExtraAGT
            // 
            this.fpdExtraAGT.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpdExtraAGT.AllowClipboardKeys = true;
            this.fpdExtraAGT.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.fpdExtraAGT.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdExtraAGT.DecimalPlaces = 0;
            this.fpdExtraAGT.FixedPoint = true;
            this.fpdExtraAGT.Location = new System.Drawing.Point(271, 217);
            this.fpdExtraAGT.Name = "fpdExtraAGT";
            this.fpdExtraAGT.NumberGroupSeparator = ",";
            this.fpdExtraAGT.Size = new System.Drawing.Size(80, 20);
            this.fpdExtraAGT.TabIndex = 8;
            this.fpdExtraAGT.Text = "";
            this.fpdExtraAGT.UseSeparator = true;
            // 
            // fpdExtra
            // 
            this.fpdExtra.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpdExtra.AllowClipboardKeys = true;
            this.fpdExtra.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.fpdExtra.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdExtra.DecimalPlaces = 0;
            this.fpdExtra.FixedPoint = true;
            this.fpdExtra.Location = new System.Drawing.Point(271, 185);
            this.fpdExtra.Name = "fpdExtra";
            this.fpdExtra.NumberGroupSeparator = ",";
            this.fpdExtra.Size = new System.Drawing.Size(80, 20);
            this.fpdExtra.TabIndex = 7;
            this.fpdExtra.Text = "";
            this.fpdExtra.UseSeparator = true;
            // 
            // fpdOvernightTrip
            // 
            this.fpdOvernightTrip.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpdOvernightTrip.AllowClipboardKeys = true;
            this.fpdOvernightTrip.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.fpdOvernightTrip.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdOvernightTrip.DecimalPlaces = 0;
            this.fpdOvernightTrip.FixedPoint = true;
            this.fpdOvernightTrip.Location = new System.Drawing.Point(271, 153);
            this.fpdOvernightTrip.Name = "fpdOvernightTrip";
            this.fpdOvernightTrip.NumberGroupSeparator = ",";
            this.fpdOvernightTrip.Size = new System.Drawing.Size(80, 20);
            this.fpdOvernightTrip.TabIndex = 6;
            this.fpdOvernightTrip.Text = "";
            this.fpdOvernightTrip.UseSeparator = true;
            // 
            // fpdFood
            // 
            this.fpdFood.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpdFood.AllowClipboardKeys = true;
            this.fpdFood.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.fpdFood.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdFood.DecimalPlaces = 0;
            this.fpdFood.FixedPoint = true;
            this.fpdFood.Location = new System.Drawing.Point(271, 88);
            this.fpdFood.Name = "fpdFood";
            this.fpdFood.NumberGroupSeparator = ",";
            this.fpdFood.Size = new System.Drawing.Size(80, 20);
            this.fpdFood.TabIndex = 3;
            this.fpdFood.Text = "";
            this.fpdFood.UseSeparator = true;
            // 
            // fpdTaxi
            // 
            this.fpdTaxi.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpdTaxi.AllowClipboardKeys = true;
            this.fpdTaxi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.fpdTaxi.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdTaxi.DecimalPlaces = 0;
            this.fpdTaxi.FixedPoint = true;
            this.fpdTaxi.Location = new System.Drawing.Point(271, 24);
            this.fpdTaxi.Name = "fpdTaxi";
            this.fpdTaxi.NumberGroupSeparator = ",";
            this.fpdTaxi.Size = new System.Drawing.Size(80, 20);
            this.fpdTaxi.TabIndex = 1;
            this.fpdTaxi.Text = "";
            this.fpdTaxi.UseSeparator = true;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(368, 217);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(24, 23);
            this.label16.TabIndex = 23;
            this.label16.Text = "บาท";
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(368, 185);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(24, 23);
            this.label15.TabIndex = 22;
            this.label15.Text = "บาท";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(368, 153);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(24, 23);
            this.label14.TabIndex = 21;
            this.label14.Text = "บาท";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(368, 121);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(24, 23);
            this.label13.TabIndex = 20;
            this.label13.Text = "บาท";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(368, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(24, 23);
            this.label11.TabIndex = 18;
            this.label11.Text = "บาท";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(368, 88);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(24, 23);
            this.label9.TabIndex = 16;
            this.label9.Text = "บาท";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(56, 217);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(176, 23);
            this.label8.TabIndex = 7;
            this.label8.Text = "อัตราค่าเบี้ยขยัน AGT ( ต่อเดือน )";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(56, 249);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(192, 24);
            this.label7.TabIndex = 6;
            this.label7.Text = "อัตราการหักเงินเเมื่อลางาน AGT ( ต่อวัน )";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(56, 185);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(176, 23);
            this.label6.TabIndex = 5;
            this.label6.Text = "อัตราค่าเบี้ยขยัน ( ต่อเดือน )";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(56, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(176, 23);
            this.label5.TabIndex = 4;
            this.label5.Text = "อัตราค่าเดินทางค้างคืน ( ต่อวัน )";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(56, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "อัตราค่าอาหาร ( ต่อวัน )";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(56, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "อัตราค่าแท็กซี่ ( ต่อเที่ยว )";
            // 
            // fpdTravelNear
            // 
            this.fpdTravelNear.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpdTravelNear.AllowClipboardKeys = true;
            this.fpdTravelNear.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.fpdTravelNear.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdTravelNear.DecimalPlaces = 0;
            this.fpdTravelNear.FixedPoint = true;
            this.fpdTravelNear.Location = new System.Drawing.Point(640, 213);
            this.fpdTravelNear.Name = "fpdTravelNear";
            this.fpdTravelNear.NumberGroupSeparator = ",";
            this.fpdTravelNear.Size = new System.Drawing.Size(80, 20);
            this.fpdTravelNear.TabIndex = 4;
            this.fpdTravelNear.Text = "";
            this.fpdTravelNear.UseSeparator = true;
            this.fpdTravelNear.Visible = false;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(795, 197);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(24, 23);
            this.label12.TabIndex = 19;
            this.label12.Text = "บาท";
            this.label12.Visible = false;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(587, 189);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "อัตราค่าเดินทางระยะใกล้ ( ต่อเที่ยว )";
            this.label2.Visible = false;
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmdOK.Location = new System.Drawing.Point(169, 349);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 10;
            this.cmdOK.Text = "ตกลง";
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(249, 349);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 11;
            this.cmdCancel.Text = "ยกเลิก";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // frmOtherBenefitRate
            // 
            this.AcceptButton = this.cmdOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(503, 384);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.fpdTravelNear);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmOtherBenefitRate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmOtherBenefitRate_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		#region - Private -
		private bool addMode = true;
		private frmMain mdiParent;
		private OtherBenefitRateFacade facadeOtherBenefitRate;
		#endregion

//		============================== Property ==============================		
		private OtherBenefitRate objOtherBenefitRate;
		private OtherBenefitRate ObjOtherBenefitRate
		{
			get
			{
				objOtherBenefitRate = new OtherBenefitRate();
				objOtherBenefitRate.TaxiRate = Convert.ToInt16(fpdTaxi.Value);
				objOtherBenefitRate.TaxiRateForCharge = Convert.ToInt16(fpdTaxiForCharge.Value);
				objOtherBenefitRate.FoodRate = Convert.ToInt16(fpdFood.Value);
				objOtherBenefitRate.OneDayTripRateNear = Convert.ToInt16(fpdTravelNear.Value);
				objOtherBenefitRate.OneDayTripRateFar = Convert.ToInt16(fpdTravelFar.Value);
				objOtherBenefitRate.OvernightTripRate = Convert.ToInt16(fpdOvernightTrip.Value);
				objOtherBenefitRate.ExtraRate = Convert.ToInt16(fpdExtra.Value);
				objOtherBenefitRate.ExtraAGTRate = Convert.ToInt16(fpdExtraAGT.Value);
				objOtherBenefitRate.DeductionAGTPerDay = Convert.ToInt16(fpdDeductAGT.Value);
                objOtherBenefitRate.MealAllowance = Convert.ToInt16(fpDMealAllowance.Value);
				return objOtherBenefitRate;
			}
			set
			{
				objOtherBenefitRate = value;
				fpdTaxi.Value = value.TaxiRate;
				fpdTaxiForCharge.Value = value.TaxiRateForCharge;
				fpdFood.Value = value.FoodRate;
				fpdTravelNear.Value = value.OneDayTripRateNear;
				fpdTravelFar.Value = value.OneDayTripRateFar;
				fpdOvernightTrip.Value = value.OvernightTripRate;
				fpdExtra.Value = value.ExtraRate;
				fpdExtraAGT.Value = value.ExtraAGTRate;
				fpdDeductAGT.Value = value.DeductionAGTPerDay;
                fpDMealAllowance.Value = value.MealAllowance;
			}
		}

//		============================== Constructor ==============================
		public frmOtherBenefitRate() : base()
		{
			InitializeComponent();
			facadeOtherBenefitRate = new OtherBenefitRateFacade();
            title = UserProfile.GetFormName("miAttendance", "miOtherBenefitRate");
		}

//		============================== private method ==============================
		private void clearForm()
		{
			fpdTaxi.Value = 0;
			fpdTaxiForCharge.Value = 0;
			fpdFood.Value = 0;
			fpdTravelNear.Value = 0;
			fpdTravelFar.Value = 0;
			fpdOvernightTrip.Value = 0;
			fpdExtra.Value = 0;
			fpdExtraAGT.Value = 0;
			fpdDeductAGT.Value = 0;
            fpDMealAllowance.Value = 0;

			fpdTaxi.MaxValue = 9999.99;
			fpdTaxi.MinValue = 0;
			fpdTaxiForCharge.MaxValue = 9999.99;
			fpdTaxiForCharge.MinValue = 0;
			fpdFood.MaxValue = 9999.99;
			fpdFood.MinValue = 0;
			fpdTravelNear.MaxValue = 9999.99;
			fpdTravelNear.MinValue = 0;
			fpdTravelFar.MaxValue = 9999.99;
			fpdTravelFar.MinValue = 0;
			fpdOvernightTrip.MaxValue = 9999.99;
			fpdOvernightTrip.MinValue = 0;
			fpdExtra.MaxValue = 9999.99;
			fpdExtra.MinValue = 0;
			fpdExtraAGT.MaxValue = 9999.99;
			fpdExtraAGT.MinValue = 0;
			fpdDeductAGT.MaxValue = 9999.99;
			fpdDeductAGT.MinValue = 0;

            fpDMealAllowance.MaxValue = 9999.99;
            fpDMealAllowance.MinValue = 0;
		}

		private void addEvent()
		{
			try
			{				
				if(facadeOtherBenefitRate.InsertOtherBenefitRate(ObjOtherBenefitRate))
				{
					Message(MessageList.Information.I0001);
					fpdTaxi.Focus();
					addMode = false;
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

		private void editEvent()
		{
			try
			{				
				if(facadeOtherBenefitRate.UpdateOtherBenefitRate(ObjOtherBenefitRate))
				{
					Message(MessageList.Information.I0001);
					fpdTaxi.Focus();
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

//		============================== Base Event ==============================
		public void InitForm()
		{
			MainMenuNewStatus = false;
			MainMenuDeleteStatus = false;
			MainMenuRefreshStatus = true;
			MainMenuPrintStatus = true;
			mdiParent.EnableNewCommand(false);
			mdiParent.EnableDeleteCommand(false);
			mdiParent.EnableRefreshCommand(true);
			mdiParent.EnablePrintCommand(true);

			try
			{
				clearForm();

				objOtherBenefitRate = facadeOtherBenefitRate.GetOtherBenefitRate();
				if(objOtherBenefitRate != null)
				{
					ObjOtherBenefitRate = objOtherBenefitRate;
					addMode = false;
				}
				else
				{
					addMode = true;
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

			if(UserProfile.IsReadOnly("miAttendance", "miOtherBenefitRate"))
			{
				cmdOK.Enabled = false;
			}
		}

		public void RefreshForm()
		{
			InitForm();
		}

		public void PrintForm()
		{
		}

		public void ExitForm()
		{
			clearMainMenuStatus();
			Dispose(true);
		}

        public override string FormID()
        {
            return UserProfile.GetFormID("miAttendance", "miOtherBenefitRate");
        }
//		============================== event ==============================
		private void frmOtherBenefitRate_Load(object sender, System.EventArgs e)
		{
			mdiParent = (frmMain)this.MdiParent;
			InitForm();
		}

		private void cmdOK_Click(object sender, System.EventArgs e)
		{
			if(addMode)
			{
				addEvent();
			}
			else
			{
				editEvent();
			}
		}

		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			clearMainMenuStatus();
			this.Close();
		}
	}
}
