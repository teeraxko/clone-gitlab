using System;
using System.Data;

using ictus.PIS.PI.Entity;

using DataAccess.PiDB;

using PTB.BTS.Common.Flow;

namespace PTB.BTS.PI.Flow
{
	
	public class DepartmentFlow : FlowBase
	{
		#region Private
		private DepartmentDB dbDepartment;
		//private bool disposed = false;
		#endregion

		//  ================================Constructor=====================

		public DepartmentFlow() : base()
		{
			dbDepartment = new DepartmentDB();
		}
		
		//  ================================public Method=====================
//		public DepartmentList GetDepartmentList(Company value)
//		{
//			DepartmentList departmentList = new DepartmentList(value);
//			dbDepartment.FillDepartmentData(ref departmentList);
//			return departmentList;
//		}

		public bool FillDepartment(ref DepartmentList aDepartmentList)
		{
			return dbDepartment.FillDepartmentList(ref aDepartmentList);
		}

		public bool InsertDepartment(ref DepartmentList aDepartmentList, Department aDepartment)
		{
			if (dbDepartment.InsertDepartment(aDepartment, aDepartmentList.Company))
			{
				aDepartmentList.Add(aDepartment);
				return true;
			}
			else
			{
				return false;
			}
		}

		public bool UpdateDepartment(ref DepartmentList aDepartmentList, Department aDepartment)
		{
			if (dbDepartment.UpdateDepartment(aDepartment, aDepartmentList.Company))
			{
				aDepartmentList[aDepartment.EntityKey] = aDepartment;
				return true;
			}
			else
			{
				return false;
			}
		}

		public bool DeleteDepartment(ref DepartmentList aDepartmentList, Department aDepartment)
		{
			if (dbDepartment.DeleteDepartment(aDepartment, aDepartmentList.Company))
			{
				aDepartmentList.Remove(aDepartment);
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}