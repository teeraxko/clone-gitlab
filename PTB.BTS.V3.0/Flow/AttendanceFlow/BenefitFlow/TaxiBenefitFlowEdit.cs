using System;

using Entity.AttendanceEntities.BenefitEntities;
using Entity.Constants;

namespace PTB.BTS.Attendance.Benefit.Flow
{
	public class TaxiBenefitFlowEdit : TaxiBenefitFlow
	{
        //For Contract PTB-C-0906002
        private const string SPECIAL_CONTRACT_01 = "PTB-C-0906002";

		public TaxiBenefitFlowEdit() : base()
		{
		}

		protected override bool validTaxi(WorkInfo value)
		{
            if (value.AssignContract != null)
            {
                if (value.AssignContract.ContractNo.ToString() == SPECIAL_CONTRACT_01)
                {
                    return false;
                }

                //No charge text for PPO (except PPOBA)
                if (value.AssignContract.ACustomerDepartment != null)
                {
                    switch (value.AssignContract.ACustomerDepartment.Code)
                    {
                        case CustomerDepartmentCodeValue.TIS_PPO1:
                        case CustomerDepartmentCodeValue.TIS_PPO2:
                        case CustomerDepartmentCodeValue.TIS_PPO3:
                        case CustomerDepartmentCodeValue.TIS_PPO4:
                        case CustomerDepartmentCodeValue.TIS_PPO5:
                        case CustomerDepartmentCodeValue.TIS_PPO6D:
                        case CustomerDepartmentCodeValue.TIS_PPO6N:
                        case CustomerDepartmentCodeValue.TIS_PPOCH:
                        case CustomerDepartmentCodeValue.TIS_PPOUC: //Kriangkrai A. 13/3/2019 don't calculate taxi charge for new Customer Dept. PPOUC
                            return false;
                        default:
                            return true;
                    }
                }
            }
            return true;
		}
	}
}