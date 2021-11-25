using System;

using Entity.AttendanceEntities;
using Entity.AttendanceEntities.BenefitEntities;
using Entity.CommonEntity;

using Flow.AttendanceFlow;
using PTB.BTS.Attendance.Benefit.Flow;

using FarPoint.Win.Spread.CellType;

namespace Facade.AttendanceFacade
{
	public class EmployeeBenefitFacade : EmployeeAttendanceFacadeBase
	{
		#region - Private -
			private EmployeeBenefitFlow flowEmployeeBenefit;
		#endregion

		#region - Property -
			private EmployeeBenefit employeeBenefit;
			public EmployeeBenefit EmployeeBenefit
			{
				get{return employeeBenefit;}
			}
		#endregion

		#region - DataSource -
			public ComboBoxCellType DataSourceTripLocation
			{
				get
				{
					TripLocationFlow flowTripLocation = new TripLocationFlow();
					TripLocationList tripLocationList = new TripLocationList();
					TripLocation tripLocation;
					string[] items;

					flowTripLocation.FillMTBList(tripLocationList);					
					items = new string[tripLocationList.Count];
					
					for(int i=0; i<tripLocationList.Count; i++)
					{
						tripLocation = (TripLocation)tripLocationList.BaseGet(i);
						items[i] = tripLocation.Name;
					}

					ComboBoxCellType comboBox = new ComboBoxCellType();
					comboBox.Items = items;

					flowTripLocation = null;
					tripLocationList = null;
					tripLocation = null;
					items = null;

					return comboBox;
				}
			}
		#endregion

		//============================== Constructor ==============================
		public EmployeeBenefitFacade() : base()
		{
			flowEmployeeBenefit = new EmployeeBenefitFlow();
		}

		#region - Private Method -
		#endregion

		//============================== Public Method ==============================
		public new bool DisplayEmployee(string employeeNo)
		{
			employee.EmployeeNo = employeeNo;
			return flowEmployee.FillAllEmployee(ref employee);
		}

		public bool FillEmployeeBenefit(DateTime forMonth)
		{
			employeeBenefit = new EmployeeBenefit(employee, forMonth);
			return flowEmployeeBenefit.FillEmployeeBenefit(employeeBenefit);
		}

		public void CalculateBenefit()
		{
			flowEmployeeBenefit.CalculateBenefit(employeeBenefit);
		}

		public bool CalculateBenefit(int index)
		{
			return flowEmployeeBenefit.CalculateBenefit(index, employeeBenefit);
		}

		public void FillWorkSchedule()
		{
			flowEmployeeBenefit.FillWorkSchedule(employeeBenefit);
		}

		public bool UpdateEmployeeBenefit()
		{
			return flowEmployeeBenefit.UpdateEmployeeBenefit(employeeBenefit);
		}

		public bool FillCustomer(BenefitOvernightTrip value)
		{
			return flowEmployeeBenefit.FillCustomer(value, employeeBenefit);
		}

        public TimeCard GetEmployeeTimeCard(ictus.PIS.PI.Entity.Employee employee, DateTime forDate)
        {
            TimeCard timeCard = new TimeCard();
            timeCard.CardDate = forDate;
            using (EmployeeTimeCardFlow flowTimeCard = new EmployeeTimeCardFlow())
            {
                if (flowTimeCard.FillTimeCard(ref timeCard, employee))
                {
                    return timeCard;
                }
                else
                {
                    timeCard = null;
                    return null;
                }
            }
        }
	}
}