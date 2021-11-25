using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.CommonDB;
using ictus.PIS.PI.Entity;

namespace DataAccess.PiDB
{
    public class SSHospitalDB : DualFieldDBBase
    {
        //		============================== Constructor ==============================
        public SSHospitalDB()
            : base()
		{
			tableName = "SS_Hospital";
            codeColumnName = "SS_Hospital_Code";
            descColumnNameThai = "SS_Hospital_Thai_Name";
			descColumnNameEng = "SS_Hospital_English_Name";
		} 

//		============================== Protected Method ==============================
        protected override ictus.Common.Entity.General.DualFieldBase getNew()
		{
            return new SSHospital();
		}
	}
    
}
