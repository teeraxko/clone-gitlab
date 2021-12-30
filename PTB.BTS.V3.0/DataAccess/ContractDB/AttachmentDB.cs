using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.CommonDB;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using Entity.VehicleEntities;
using Entity.ContractEntities;

namespace DataAccess.ContractDB
{
    public class AttachmentDB : DataAccessBase
    {
        private AttachmentList objAttachmentList;

//      ============================== Constructor ==============================
        public AttachmentDB()
            : base()
		{			
		}

        private string getSQLSelect()
        {
            return "SELECT c.Contract_Type, c.Contract_No, c.Contract_Date, c.Kind_Of_Contract, c.Contract_Start_Date, c.Contract_End_Date, c.Customer_Code , c.Customer_Department_Code, c.Unit_Hire, c.Rate_Status, c.Contract_Status, c.Contract_Cancel_Date, c.Contract_Cancel_Reason, c.Remark, c.Driver_Deduct_Type, c.Deduct_Amount_Per_Day FROM Contract AS c ";
        }

        private string getSQLJoin()
        {
            return "INNER JOIN Vehicle_Contract AS vc ON vc.Contract_No = c.Contract_No INNER JOIN Vehicle AS v ON v.Vehicle_No = vc.Vehicle_No INNER JOIN Model AS m ON m.Model_Code = v.Model_Code INNER JOIN Model_Type AS mt ON mt.Model_Type = m.Model_Type ";
        }

        private string getOrderby()
        {
            return " ORDER BY Contract_No ";
        }

        public ArrayList GetModelVehicleType()
        {
            SqlCommand cmd = this.tableAccess.CreateCommand("spGetModelTypeOfContractAttachment");
            cmd.CommandType = CommandType.StoredProcedure;

            return FillModelVehicleTypeList(cmd);
        }

        private ArrayList FillModelVehicleTypeList(SqlCommand cmd)
        {
            ArrayList result = new ArrayList();
            SqlDataReader dataReader = tableAccess.ExecuteDataReader(cmd);

            try
            {
                while (dataReader.Read())
                {
                    ModelType entity = new ModelType();

                    entity.Model_Type = dataReader["Model_Type"].ToString();
                    entity.ThaiDescription = dataReader["Thai_Description"].ToString();
                    entity.EnglishDescription = dataReader["English_Description"].ToString();
                    entity.ProcessDate = (DateTime)dataReader["Process_Date"];
                    entity.ProcessUser = dataReader["Process_User"].ToString();

                    result.Add(entity);
                }
            }
            catch (IndexOutOfRangeException ein)
            {
                throw ein;
            }
            finally
            {
                if (cmd.Connection.State != ConnectionState.Closed)
                {
                    cmd.Connection.Close();
                }

                dataReader.Close();
                tableAccess.CloseDataReader();
            }
            return result;
        }

        //public bool FillAttachmentList(ref AttachmentList attachmentList, string customerCode, string modelType)
        //{
        //    StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
        //    stringBuilder.Append(getSQLJoin);
        //    stringBuilder.Append("WHERE Contract_Type='V' ");
        //    stringBuilder.Append(string.Format("AND c.Customer_Code = '{0}' "),customerCode);
        //    stringBuilder.Append("AND Contract_Status = 2 ");
        //    stringBuilder.Append(string.Format("AND mt.Model_Type = '{0}' "), modelType);
        //    stringBuilder.Append(getOrderby());

        //    return fillAttachmentList(ref attachmentList, stringBuilder.ToString());
        //}

        //private bool fillAttachmentList(ref AttachmentList value, string sql)
        //{
        //    bool result = false;
        //    SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
        //    try
        //    {
        //        while (dataReader.Read())
        //        {
        //            result = true;

        //            value = new AttachmentList();
        //            value.ContractType = dataReader["Contraact_Type"].ToString();
        //            value.ContractNo = dataReader["Contraact_No"].ToString();
        //            value.ContractDate = (DateTime)dataReader["Contract_Date"];
        //            value.KindOfContract = dataReader["Kind_Of_Contract"].ToString();
        //            value.ContractStartDate = (DateTime)dataReader["Contract_Start_Date"];
        //            value.ContractEndDate = (DateTime)dataReader["Contract_End_Date"];
        //            value.CustomerCode = dataReader["Customer_Code"].ToString();
        //            value.CustomerDepartmentCode = dataReader["Customer_Department_Code"].ToString();
        //            value.UnitHire = dataReader["Unit_Hire"].ToString();
        //            value.RateStatus = dataReader["Rate_Status"].ToString();
        //            value.ContractStatus = dataReader["Contract_Status"].ToString();
        //            value.ContractCancelDate = (DateTime)dataReader["Contract_Cancel_Date"];
        //            value.ContractCancelRason = dataReader["Contract_Cancel_Reason"].ToString();
        //            value.Remark = dataReader["Remark"].ToString();
        //            value.DriverDeductType = dataReader["Driver_Deduct_Type"].ToString();
        //            value.DeductAmountPerDay = dataReader["Deduct_Amount_Per_Day"].ToString();

        //            value.Add(objAttachmentList);
        //        }
        //    }
        //    catch (IndexOutOfRangeException ein)
        //    {
        //        throw ein;
        //    }
        //    finally
        //    {
        //        tableAccess.CloseDataReader();
        //    }
        //    return result;
        //}       

    }
}
