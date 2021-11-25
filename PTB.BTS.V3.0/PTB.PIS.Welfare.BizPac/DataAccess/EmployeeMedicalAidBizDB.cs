using System;
using System.Collections.Generic;
using System.Text;
using ictus.PIS.Welfare.DataAccess.MedicalAidDB;
using ictus.PIS.Welfare.Entity.MedicalAidEntities;
using System.Data;
using ictus.Common.Entity;
using ictus.PIS.Welfare.DataAccess.CommonDB;
using ictus.PIS.PI.Entity;
using ictus.PIS.Welfare.Entity.CommonEntities;
using ictus.PIS.Welfare.DataAccess;

namespace PTB.PIS.Welfare.BizPac.DataAccess
{
    internal class EmployeeMedicalAidBizDB : BizPacDBBase
    {
        public EmployeeMedicalAidBizDB()
        {
            this.connection = DataBase.GetDataConnection();
            this.tablename = "Employee_Medical_Aid";
        }
        private enum ColIndex
        {
            Company_Code,
            Employee_No,
            Hospital_Code,
            Disease_Name,
            Treatment_Date,
            Applied_Date,
            Medical_Aid_For,
            Medical_Aid_Type,
            Child_Prefix,
            Child_Name,
            Child_Surname,
            Hospital_Name,
            Actual_Amount,
            Applied_Amount,
            Attendance_Letter_Status,
            Certificate_Status,
            Remark,
            Hospital_Invoice_No,
            BizPac_Reference_No,
            BizPac_Connection_Date,
            Process_Date, Process_User
        }

        public static List<MedicalAidApplication> FillNoBizByCompFromDateToDate(Company comp, DateTime fromDate, DateTime toDate, bool isAttendanceLetterStatus)
        {
            List<MedicalAidApplication> items = new List<MedicalAidApplication>();

            StringBuilder str = new StringBuilder();
            str.Append(" SELECT *  ");
            str.Append(" FROM Employee_Medical_Aid ");
            str.Append(" WHERE ");
            str.Append(" Company_Code = @Company_Code AND ");

            if (isAttendanceLetterStatus)
                str.Append(" Attendance_Letter_Status = 'Y' AND ");
            else
                str.Append(" Attendance_Letter_Status = 'N' AND ");

            str.Append(" (Applied_date BETWEEN @FromDate AND @ToDate) AND ");
            str.Append(" BizPac_Connection_Date is NULL  ");
            str.Append(" ORDER BY Applied_date ");

            string strSQL = str.ToString();
            IDbCommand cmd = DataBase.GetDbCommand();
            cmd.CommandText = strSQL;
            foreach (IDbDataParameter p in BizPacDBBase.GetCompanyFromToDateParameters(null, comp, fromDate, toDate)) cmd.Parameters.Add(p);
            try
            {
                if (cmd.Connection.State != ConnectionState.Open) cmd.Connection.Open();
                IDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    MedicalAidApplication item = new MedicalAidApplication();
                    Employee emp = new Employee(comp);
                    emp.EmployeeNo = dr.GetString((int)ColIndex.Employee_No);
                    item.AEmployee = emp;
                    item.AHospital = HospitalDB.FillByKey(dr.GetString((int)ColIndex.Hospital_Code));
                    item.ADisease = DiseaseDB.FillByKey(dr.GetString((int)ColIndex.Disease_Name));
                    item.AdmitDate = dr.GetDateTime((int)ColIndex.Treatment_Date);
                    item.CreateDate = dr.GetDateTime((int)ColIndex.Applied_Date);
                    item.ApplicationFor = MedicalAidForDB.FillByCode(dr.GetString((int)ColIndex.Medical_Aid_For));
                    item.ApplicationType = MedicalAidTypeDB.FillByCode(dr.GetString((int)ColIndex.Medical_Aid_Type));

                    switch (item.ApplicationFor.Code)
                    {
                        case "1":
                            Person spouse = PersonDB.FillSpouse(comp, emp)[0];
                            item.OtherPerson = spouse;
                            break;
                        case "2":
                            Person child = new Person();
                            child.Prefix = dr.GetString((int)ColIndex.Child_Prefix);
                            child.FirstName = dr.GetString((int)ColIndex.Child_Name);
                            child.LastName = dr.GetString((int)ColIndex.Child_Surname);
                            child.BirthDate = PersonDB.FillChildrenBirthDate(comp, emp, child);
                            item.OtherPerson = child;
                            break;

                        default:
                            item.OtherPerson = new Person();
                            break;
                    }
                    item.NoContractHospitalName = dr.GetString((int)ColIndex.Hospital_Name);

                    item.ActualAmount = dr.GetDecimal((int)ColIndex.Actual_Amount);

                    item.AppliedAmount = dr.GetDecimal((int)ColIndex.Applied_Amount);
                    item.AttendanceLetterStatus = dr.GetString((int)ColIndex.Attendance_Letter_Status)[0];
                    item.CertificateStatus = dr.GetString((int)ColIndex.Certificate_Status)[0];
                    item.Remark = dr.GetString((int)ColIndex.Remark);
                    item.InvoiceNo = dr.GetString((int)ColIndex.Hospital_Invoice_No);
                    items.Add(item);
                }

                return items;
            }
            catch (Exception excp)
            {
                throw excp;
            }
            finally
            {
                cmd.Connection.Close();
            }
        }


        private Company comp;
        private List<MedicalAidApplication> apps;

        public EmployeeMedicalAidBizDB(string refNo, DateTime connectDate, Company comp, List<MedicalAidApplication> apps)
            : this()
        {

            this.refNo = refNo;
            this.connectDate = connectDate;
            this.comp = comp;
            this.apps = apps;
        }


        protected override string GetCriteriaKey()
        {
            return EmployeeMedicalAidDB.CriteriaKey();
        }

        private IDbCommand BuildUpdateCommand(Company comp, MedicalAidApplication app)
        {
            IDbCommand command = DataBase.GetDbCommand(this.connection);
            command.CommandText = this.BulidStringUpdate();
            foreach (IDbDataParameter para in this.GetUpdateParameters(comp, app)) command.Parameters.Add(para);
            return command;
        }

        private List<IDbDataParameter> GetUpdateParameters(Company comp, MedicalAidApplication app)
        {
            List<IDbDataParameter> paras = new List<IDbDataParameter>();
            paras = EmployeeMedicalAidDB.GetKeyParameters(paras, comp, app);
            paras = this.GetBizParameters(paras);
            paras = this.GetProcessParameters(paras);
            return paras;
        }

        public override bool UpdateData()
        {
            bool result = false;
            try
            {
                result = true;
                this.connection.Open();
                this.transaction = this.connection.BeginTransaction();
                foreach (MedicalAidApplication app in this.apps)
                {
                    IDbCommand command = this.BuildUpdateCommand(this.comp, app);
                    command.Transaction = this.transaction;
                    result = result && (command.ExecuteNonQuery() == 1);
                }
                this.transaction.Commit();
                return result;
            }
            catch (Exception ex)
            {
                this.transaction.Rollback();
                throw ex;
            }
            finally
            {
                this.connection.Close();
            }
        }

    }
}
