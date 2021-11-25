using System;

using ictus.PIS.PI.Entity;
using Entity.CommonEntity;
using Entity.ContractEntities;
using Entity.AttendanceEntities;

using DataAccess.CommonDB;
using DataAccess.PiDB;

namespace DataAccess.AttendanceDB
{
	public class AttendanceStatusDB : DualFieldCompanyDBBase
	{
//		============================== Constructor ==============================
		public AttendanceStatusDB(): base()
		{
			tableName = "Attendance_Status";
			codeColumnName = "Attendance_Status";
			descColumnNameEng = "English_Name";
			descColumnNameThai = "Thai_Name";
		}

        protected override ictus.Common.Entity.General.DualFieldBase getNew()
		{
			return new AttendanceStatus();
		}
	}
}
