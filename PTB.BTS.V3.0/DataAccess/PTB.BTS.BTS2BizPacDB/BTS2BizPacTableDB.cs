using System;
using System.Text;
using System.Data.SqlClient;

using ictus.Common.Entity.General;
using ictus.Common.Entity;

using SystemFramework.AppConfig;
using PTB.BTS.BTS2BizPacEntity;
using Entity.AttendanceEntities;

namespace PTB.BTS.BTS2BizPacDB
{
    public class BizPacConnectTableDB : DataAccess.CommonDB.DataAccessBase
    {
        //============================= Constructor =============================
        public BizPacConnectTableDB()
        { }

        //============================= Method =============================
        protected string getSQLUpdate(IBizPacConnectDB value, string refNo, DateTime connectDate)
        {
            StringBuilder stringBuilder = new StringBuilder(" UPDATE ");
            stringBuilder.Append(value.TableName);
            stringBuilder.Append(" SET ");

            stringBuilder.Append(value.RefNoFieldName);
            stringBuilder.Append(" = ");
            stringBuilder.Append(GetDB(refNo));
            stringBuilder.Append(" , ");

            stringBuilder.Append(value.RefDateFiledName);
            stringBuilder.Append(" = ");
            if (IsNotNULL(connectDate))
            {
                stringBuilder.Append(GetDB(connectDate));
            }
            else
            {
                stringBuilder.Append(GetDB(NullConstant.DATETIME));
            }
            stringBuilder.Append(" , ");

            stringBuilder.Append(" Process_Date = ");
            stringBuilder.Append(GetDateDB());
            stringBuilder.Append(" , ");

            stringBuilder.Append(" Process_User = ");
            stringBuilder.Append(GetDB(UserProfile.UserID));

            return stringBuilder.ToString();
        }

        private string getSelectCondition(IBizPacConnectDB dbConnect)
        {
            return " AND (" + dbConnect.RefNoFieldName + " = '') ";
        }

        private string getSelectCancelCondition(IBizPacConnectDB dbConnect, TimePeriod period)
        {
            StringBuilder stringBuilder = new StringBuilder(" AND ( ");
            stringBuilder.Append(dbConnect.RefNoFieldName);
            stringBuilder.Append(" <> '') AND ( ");
            stringBuilder.Append(dbConnect.RefNoFieldName);
            stringBuilder.Append(" <> '");
            stringBuilder.Append(BizPacFixData.BIZPAC_DUMMY_REF_NO);
            stringBuilder.Append("') AND ( ");
            stringBuilder.Append(dbConnect.RefDateFiledName);
            stringBuilder.Append(" <= ");
            stringBuilder.Append(GetDB(period.To));
            stringBuilder.Append(") AND ( ");
            stringBuilder.Append(dbConnect.RefDateFiledName);
            stringBuilder.Append(" >= ");
            stringBuilder.Append(GetDB(period.From));
            stringBuilder.Append(" ) ");

            return stringBuilder.ToString();
        }

        private string getSelectRerunCondition(IBizPacConnectDB dbConnect, DateTime connectDate)
        {
            StringBuilder stringBuilder = new StringBuilder(" AND ( ");
            stringBuilder.Append(dbConnect.RefNoFieldName);
            stringBuilder.Append(" <> '') AND ( ");
            stringBuilder.Append(dbConnect.RefNoFieldName);
            stringBuilder.Append(" <> '");
            stringBuilder.Append(BizPacFixData.BIZPAC_DUMMY_REF_NO);
            stringBuilder.Append("')");
            stringBuilder.Append(" AND (YEAR(");
            stringBuilder.Append(dbConnect.RefDateFiledName);
            stringBuilder.Append(" ) = ");
            stringBuilder.Append(GetDB(connectDate.Year));
            stringBuilder.Append(" ) AND (MONTH(");
            stringBuilder.Append(dbConnect.RefDateFiledName);
            stringBuilder.Append(" ) = ");
            stringBuilder.Append(GetDB(connectDate.Month));
            stringBuilder.Append(" ) ");
            //stringBuilder.Append(" ) AND (DAY(");
            //stringBuilder.Append(dbConnect.RefDateFiledName);
            //stringBuilder.Append(" ) = ");
            //stringBuilder.Append(GetDB(connectDate.Day));
            //stringBuilder.Append(" ) ");

            return stringBuilder.ToString();
        }

        private bool fillBPList(IBizPacConnectDB dbConnect, BTS2BizPacList listBP, Company company, string sql)
        {
            bool result = false;
            SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
            try
            {
                result = dbConnect.FillIBPList(listBP, company, dataReader);
            }
            catch (IndexOutOfRangeException ein)
            {
                throw ein;
            }

            finally
            {
                tableAccess.CloseDataReader();
                tableAccess.Transaction = null;
            }
            return result;
        }

        //[Napat C.] 18/02/2019 add this to set get sql for cancel transfer
        protected string getSQLUpdateSAP(IBizPacConnectDB value)
        {
            StringBuilder stringBuilder = new StringBuilder(" UPDATE [TR_SAP_Transaction] ");
            stringBuilder.Append("SET IsDelete = 1, ");
            stringBuilder.Append("Cancel_Date = CURRENT_TIMESTAMP, ");
            stringBuilder.Append("Cancel_User = '");
            stringBuilder.Append(UserProfile.UserID.ToString().Trim());
            stringBuilder.Append("' WHERE Reference_No IN ");
            // Kriangkrai A. 22/02/2019 select refNoFieldName from DBConnection due to page VehicleExcess have many bizpac Ref no.
            //stringBuilder.Append("(SELECT bizpac_reference_no FROM ");
            stringBuilder.Append("(SELECT ");
            stringBuilder.Append(value.RefNoFieldName);
            stringBuilder.Append(" FROM ");
            stringBuilder.Append(value.TableName);

            return stringBuilder.ToString();
        }

        //============================= Public method =============================
        public bool FillBPList(IBizPacConnectDB dbConnect, BTS2BizPacList listBP, Company company)
        {
            StringBuilder stringBuilder = new StringBuilder(dbConnect.GetSQLSelectBP);
            stringBuilder.Append(dbConnect.GetBaseConditionBP(company));
            stringBuilder.Append(getSelectCondition(dbConnect));
            stringBuilder.Append(dbConnect.GetSpecificSelectConditionBP);
            stringBuilder.Append(dbConnect.GetOrderByBP);

            return fillBPList(dbConnect, listBP, company, stringBuilder.ToString());
        }

        public string Connect(IBizPacConnectDB dbConnect, IBTS2BizPacHeader condition, Company company)
        {
            try
            {
                StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(dbConnect, condition.BizPacRefNo, condition.BizPacRefDate));
                stringBuilder.Append(getBaseCondition(company));
                stringBuilder.Append(dbConnect.GetKeyConditionBP(condition));

                return stringBuilder.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool FillCancelBPList(IBizPacConnectDB dbConnect, BTS2BizPacList listBP, TimePeriod period, Company company)
        {
            StringBuilder stringBuilder = new StringBuilder(dbConnect.GetSQLSelectBP);
            stringBuilder.Append(dbConnect.GetBaseConditionBP(company));
            stringBuilder.Append(getSelectCancelCondition(dbConnect, period));
            stringBuilder.Append(dbConnect.GetSpecificSelectConditionBP);
            stringBuilder.Append(dbConnect.GetOrderByBP);
            //Console.WriteLine(stringBuilder.ToString());
            return fillBPList(dbConnect, listBP, company, stringBuilder.ToString());
        }

        public bool FillRerunBPList(IBizPacConnectDB dbConnect, BTS2BizPacList listBP, DateTime connectDate, Company company)
        {
            StringBuilder stringBuilder = new StringBuilder(dbConnect.GetSQLSelectBP);
            stringBuilder.Append(dbConnect.GetBaseConditionBP(company));
            stringBuilder.Append(getSelectRerunCondition(dbConnect, connectDate));
            stringBuilder.Append(dbConnect.GetSpecificSelectConditionBP);
            stringBuilder.Append(dbConnect.GetOrderByBP);

            return fillBPList(dbConnect, listBP, company, stringBuilder.ToString());
        }

        public string Cancel(IBizPacConnectDB dbConnect, IBTS2BizPacHeader condition, Company company)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(dbConnect, "", NullConstant.DATETIME));
            stringBuilder.Append(getBaseCondition(company));
            stringBuilder.Append(dbConnect.GetKeyConditionBP(condition));

            return stringBuilder.ToString();
        }

        //[Napat C.] 18/02/2019 add this to get sql for cancel transfer
        public string CancelSAP(IBizPacConnectDB dbConnect, IBTS2BizPacHeader condition, Company company)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLUpdateSAP(dbConnect));
            stringBuilder.Append(getBaseCondition(company));
            stringBuilder.Append(dbConnect.GetKeyConditionBP(condition));
            stringBuilder.Append(")");

            return stringBuilder.ToString();
        }

        public bool ExecuteCommand(string strCommand)
        {
            return (tableAccess.ExecuteSQL(strCommand) > 0);
        }
    }
}
