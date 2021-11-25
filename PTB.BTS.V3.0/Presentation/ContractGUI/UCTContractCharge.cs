using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using PTB.BTS.ContractEntities.ContractChargeRate;

namespace Presentation.ContractGUI
{
	public class UCTContractCharge : System.Windows.Forms.UserControl
	{
		#region Component Designer generated code
        private FarPoint.Win.Input.FpDouble fpdUnitChargeAmt;
        protected internal FarPoint.Win.Input.FpDouble fpdNextMonth;
        protected internal FarPoint.Win.Input.FpDouble fpdLastMonth;
        protected internal FarPoint.Win.Input.FpDouble fpdFirstMonth;
		private System.ComponentModel.Container components = null;

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
            this.fpdNextMonth = new FarPoint.Win.Input.FpDouble();
            this.fpdLastMonth = new FarPoint.Win.Input.FpDouble();
            this.fpdFirstMonth = new FarPoint.Win.Input.FpDouble();
            this.fpdUnitChargeAmt = new FarPoint.Win.Input.FpDouble();
            this.SuspendLayout();
            // 
            // fpdNextMonth
            // 
            this.fpdNextMonth.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpdNextMonth.AllowClipboardKeys = true;
            this.fpdNextMonth.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdNextMonth.DecimalPlaces = 2;
            this.fpdNextMonth.DecimalSeparator = ".";
            this.fpdNextMonth.Enabled = false;
            this.fpdNextMonth.FixedPoint = true;
            this.fpdNextMonth.Location = new System.Drawing.Point(224, 8);
            this.fpdNextMonth.Name = "fpdNextMonth";
            this.fpdNextMonth.Size = new System.Drawing.Size(88, 20);
            this.fpdNextMonth.TabIndex = 76;
            this.fpdNextMonth.Text = "";
            this.fpdNextMonth.UseSeparator = true;
            // 
            // fpdLastMonth
            // 
            this.fpdLastMonth.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpdLastMonth.AllowClipboardKeys = true;
            this.fpdLastMonth.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdLastMonth.DecimalPlaces = 2;
            this.fpdLastMonth.DecimalSeparator = ".";
            this.fpdLastMonth.Enabled = false;
            this.fpdLastMonth.FixedPoint = true;
            this.fpdLastMonth.Location = new System.Drawing.Point(328, 8);
            this.fpdLastMonth.Name = "fpdLastMonth";
            this.fpdLastMonth.Size = new System.Drawing.Size(88, 20);
            this.fpdLastMonth.TabIndex = 75;
            this.fpdLastMonth.Text = "";
            this.fpdLastMonth.UseSeparator = true;
            // 
            // fpdFirstMonth
            // 
            this.fpdFirstMonth.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpdFirstMonth.AllowClipboardKeys = true;
            this.fpdFirstMonth.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdFirstMonth.DecimalPlaces = 2;
            this.fpdFirstMonth.DecimalSeparator = ".";
            this.fpdFirstMonth.Enabled = false;
            this.fpdFirstMonth.FixedPoint = true;
            this.fpdFirstMonth.Location = new System.Drawing.Point(120, 8);
            this.fpdFirstMonth.Name = "fpdFirstMonth";
            this.fpdFirstMonth.Size = new System.Drawing.Size(88, 20);
            this.fpdFirstMonth.TabIndex = 74;
            this.fpdFirstMonth.Text = "";
            this.fpdFirstMonth.UseSeparator = true;
            // 
            // fpdUnitChargeAmt
            // 
            this.fpdUnitChargeAmt.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpdUnitChargeAmt.AllowClipboardKeys = true;
            this.fpdUnitChargeAmt.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdUnitChargeAmt.DecimalPlaces = 2;
            this.fpdUnitChargeAmt.DecimalSeparator = ".";
            this.fpdUnitChargeAmt.FixedPoint = true;
            this.fpdUnitChargeAmt.Location = new System.Drawing.Point(8, 8);
            this.fpdUnitChargeAmt.Name = "fpdUnitChargeAmt";
            this.fpdUnitChargeAmt.Size = new System.Drawing.Size(96, 20);
            this.fpdUnitChargeAmt.TabIndex = 73;
            this.fpdUnitChargeAmt.Text = "";
            this.fpdUnitChargeAmt.UseSeparator = true;
            // 
            // UCTContractCharge
            // 
            this.Controls.Add(this.fpdNextMonth);
            this.Controls.Add(this.fpdLastMonth);
            this.Controls.Add(this.fpdFirstMonth);
            this.Controls.Add(this.fpdUnitChargeAmt);
            this.Name = "UCTContractCharge";
            this.Size = new System.Drawing.Size(424, 32);
            this.Load += new System.EventHandler(this.UCTContractCharge_Load);
            this.ResumeLayout(false);

		}
		#endregion

		#region - Constant -
		public enum RateStatusType
		{
			ByDay,
			ByMonth,
		}
		#endregion

		#region - Property -
		private DateTime dateForm;
		public DateTime DateForm
		{
			set
			{
				dateForm = value;
			}
			get
			{
				return dateForm;
			}
		}

		private DateTime dateTo;
		public DateTime DateTo
		{
			set
			{
				dateTo = value;
			}
			get
			{
				return dateTo;
			}
		}

		private RateStatusType rateStatus;
		public bool RateStatusByMonth
		{
			set
			{
				if(value)
				{
					rateStatus = RateStatusType.ByMonth;
				}
				else
				{
					rateStatus = RateStatusType.ByDay;
				}				
			}
			get
			{
				return rateStatus == RateStatusType.ByMonth;
			}
		}

		public decimal RateAmount
		{
			get
			{
				return Convert.ToDecimal(fpdUnitChargeAmt.Value);
			}
			set
			{
				fpdUnitChargeAmt.Value = value;
			}
		}

		private decimal rateAmountTag = -1;
		public decimal RateAmountTag
		{
			get
			{
				return rateAmountTag;
			}
			set
			{
				rateAmountTag = value;
			}
		}

		private decimal firstMonth = 0;
		public decimal FirstMonth
		{
			get
			{
                //return firstMonth;
                return Convert.ToDecimal(fpdFirstMonth.Value);
			}
			set
			{
				firstMonth = value;
				fpdFirstMonth.Value = value;
			}
		}

		private decimal nextMonth = 0;
		public decimal NextMonth
		{
			get
			{
                //return nextMonth;
                return Convert.ToDecimal(fpdNextMonth.Value);
			}
			set
			{
				nextMonth = value;
				fpdNextMonth.Value = value; 
			}
		}

		private decimal lastMonth = 0;
		public decimal LastMonth
		{
			get
			{
                //return lastMonth;
                return Convert.ToDecimal(fpdLastMonth.Value);
			}
			set
			{
				lastMonth = value;
				fpdLastMonth.Value = value;
			}
		}

        private int _absentDeduct = 0;
        public int AbsentDeduct
        {
            get {return _absentDeduct;}
            set {_absentDeduct = value;}
        }
	
		#endregion

		//==============================  Constructor  ==============================
		public UCTContractCharge()
		{
			InitializeComponent();
			fpdUnitChargeAmt.MinValue = 0;
			fpdUnitChargeAmt.MaxValue = 999999;
			
			fpdFirstMonth.MinValue = 0;
			fpdFirstMonth.MaxValue = 999999;

			fpdNextMonth.MinValue = 0;
			fpdNextMonth.MaxValue = 999999;

			fpdLastMonth.MinValue = 0;
			fpdLastMonth.MaxValue = 999999;
		}

		#region - Private Method -
        private bool isSameMonth(DateTime from, DateTime to)
			{
                return (from.Month == to.Month && from.Year == to.Year);
			}

			private int getDays(int form, int to)
			{
				return to - form + 1;
			}

			private decimal getChargeStaff(int days)
			{
				if(rateStatus == RateStatusType.ByDay)
				{
					return decimal.Multiply(RateAmount, days);
				}
				else
				{
                    return Math.Round(decimal.Multiply(RateAmount, decimal.Divide(days, 30)), MidpointRounding.AwayFromZero);
				}
			}

            private decimal getChargeDriver(int days)
            {
                if (rateStatus == RateStatusType.ByDay)
                {
                    return decimal.Multiply(RateAmount, days);
                }
                else
                {
                    if (RateAmount == decimal.Zero)
                    {
                        return decimal.Zero;
                    }
                    else
                    {
                        return decimal.Multiply(days, _absentDeduct);
                    }
                }
            }

            private decimal getCharge(int days, int dayInMonth)
            {
                if (rateStatus == RateStatusType.ByDay)
                {
                    return decimal.Multiply(RateAmount, days);
                }
                else
                {
                    return Math.Round(decimal.Multiply(RateAmount, decimal.Divide(days, dayInMonth)), MidpointRounding.AwayFromZero);
                }
            }

			private int getDaysInMonth(DateTime value)
			{
				return DateTime.DaysInMonth(value.Year, value.Month);
			}

			private void clearCharge()
			{
				FirstMonth = 0;
				NextMonth = 0;
				LastMonth = 0;
			}
		#endregion

		//==============================  Base Event   ==============================
        public void UnitChargeAmountByMonthForDriver()
        {
            int daysInMonth;
            int days;

            clearCharge();

            if (isSameMonth(dateForm, dateTo))
            {
                daysInMonth = getDaysInMonth(dateForm);
                if (dateForm.Day == 1 && dateTo.Day == daysInMonth)
                {
                    FirstMonth = RateAmount;
                }
                else
                {
                    days = getDays(dateForm.Day, dateTo.Day);
                    FirstMonth = getChargeDriver(days);
                }
            }
            else
            {
                if (dateForm.Day == 1)
                {
                    FirstMonth = RateAmount;
                }
                else
                {
                    daysInMonth = getDaysInMonth(dateForm);

                    days = getDays(dateForm.Day, daysInMonth);
                    FirstMonth = getChargeDriver(days);
                }


                daysInMonth = getDaysInMonth(dateTo);
                if (dateTo.Day == daysInMonth)
                {
                    LastMonth = RateAmount;
                }
                else
                {
                    LastMonth = getChargeDriver(dateTo.Day);
                }

                DateTime tempDate = dateForm.AddMonths(1);
                if (!isSameMonth(tempDate, dateTo))
                {
                    NextMonth = RateAmount;
                }
            }
        }

		public void UnitChargeAmountByMonthForOtherStaff()
		{
			int daysInMonth;
			int days;

			clearCharge();

			if(isSameMonth(dateForm, dateTo))
			{
                daysInMonth = getDaysInMonth(dateForm);
                if (dateForm.Day == 1 && dateTo.Day == daysInMonth)
                {
                    FirstMonth = RateAmount;
                }
                else
                { 
				    days = getDays(dateForm.Day, dateTo.Day);
				    FirstMonth = getChargeStaff(days);                
                }
			}
			else
			{
                if (dateForm.Day == 1)
                {
                    FirstMonth = RateAmount;
                }
                else
                { 
				    daysInMonth = getDaysInMonth(dateForm);

				    days = getDays(dateForm.Day, daysInMonth);
				    FirstMonth = getChargeStaff(days);                
                }

				
                daysInMonth = getDaysInMonth(dateTo);
                if (dateTo.Day == daysInMonth)
                {
                    LastMonth = RateAmount;
                }
                else
                {
                    LastMonth = getChargeStaff(dateTo.Day);
                }

                DateTime tempDate = dateForm.AddMonths(1);
				if(!isSameMonth(tempDate, dateTo))
				{
                    NextMonth = RateAmount;
				}
			}
		}

        public void UnitChargeAmountByActualMonth()
        {
            int daysInMonth;
            int days;

            clearCharge();

            if (isSameMonth(dateForm, dateTo))
            {
                daysInMonth = getDaysInMonth(dateForm);
                days = getDays(dateForm.Day, dateTo.Day);
                FirstMonth = getCharge(days, daysInMonth);
            }
            else
            {
                daysInMonth = getDaysInMonth(dateForm);
                days = getDays(dateForm.Day, daysInMonth);
                FirstMonth = getCharge(days, daysInMonth);

                DateTime tempDate = dateForm.AddMonths(1);
                if (isSameMonth(tempDate, dateTo))
                {
                    daysInMonth = getDaysInMonth(dateTo);
                    LastMonth = getCharge(dateTo.Day, daysInMonth);
                }
                else
                {
                    daysInMonth = getDaysInMonth(tempDate);
                    NextMonth = getCharge(daysInMonth, daysInMonth);
                    daysInMonth = getDaysInMonth(dateTo);
                    LastMonth = getCharge(dateTo.Day, daysInMonth);
                }
            }
        }

		public bool UnitChargeEnable
		{
			set
			{
				fpdUnitChargeAmt.Enabled = value;
			}
			get
			{
				return fpdUnitChargeAmt.Enabled;
			}
		}

		public void Clear()
		{
            clearCharge();
			fpdUnitChargeAmt.Value = 0;
		}

		//==============================     event     ==============================
		private void UCTContractCharge_Load(object sender, System.EventArgs e)
		{
		}
	}
}