using System;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity.General;

namespace Entity.ContractEntities
{
	public class OfficeStaff : Employee, IKey
	{
//  =============================Constructor========================
		public OfficeStaff(Employee value) :  base(value.Company)
		{
			this.aName.English = value.AName.English;
            this.aName.Thai = value.AName.Thai;
			this.aPrefix.English = value.APrefix.English;
            this.aPrefix.Thai = value.APrefix.Thai;
            this.aSurname.English = value.ASurname.English; 
            this.aSurname.Thai = value.ASurname.Thai;
            //			this.century = value.Century;
			this.company = value.Company;
			this.employeeNo = value.EmployeeNo;
			this.hireDate = value.HireDate;
//			this.kindOfOT = value.KindOfOT;
			this.aPosition = value.APosition;
//			this.shiftNo = value.ShiftNo;
		}

		public new string EntityKey
		{
			get
			{
				return base.EntityKey;
			}
		}
	}
}
