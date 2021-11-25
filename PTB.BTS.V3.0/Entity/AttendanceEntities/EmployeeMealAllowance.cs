using System;

using ictus.Common.Entity.General;using ictus.Framework.ASC.Entity.DNF20;
using ictus.PIS.PI.Entity;

namespace Entity.AttendanceEntities
{
	public class EmployeeMealAllowance : EntityBase, IKey
	{
//		============================== Property ==============================
		private Employee aEmployee;
		public Employee AEmployee
		{
			get{return aEmployee;}
			set{aEmployee = value;}
		}

		private decimal mealAllowance = NullConstant.DECIMAL;
        public decimal MealAllowance
		{
            get { return mealAllowance; }
            set { mealAllowance = value; }
		}

        private int benefit_Year = NullConstant.INT;
        public int Benefit_Year
        {
            get { return benefit_Year; }
            set { benefit_Year = value; }
        }

        private int benefit_Month = NullConstant.INT;
        public int Benefit_Month
        {
            get { return benefit_Month; }
            set { benefit_Month = value; }
        }
		
//		============================== Constructor ==============================
        public EmployeeMealAllowance()
            : base()
		{
		}

//		============================== Public Method ==============================
		public override string EntityKey
		{
			get{return aEmployee.EntityKey;}
		}
	}
}
