using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Entity.CommonEntity;
using Entity.VehicleEntities;

using DataAccess.CommonDB;

using SystemFramework.AppConfig;

using ictus.Common.Entity;
using ictus.PIS.PI.Entity;
using ictus.Common.Entity.General;
using System.Collections.Generic;

namespace DataAccess.VehicleDB
{
    public class BidderDB : PISDataAccessBase<Bidder, Company>
    {
        #region Constructor
        public BidderDB()
            : base()
        {
        } 
        #endregion

        #region Public Method
        public List<Bidder> GetAll()
        {
            string strSQL = "SELECT * FROM Bidder ORDER BY Bidder_Name";
            SqlCommand command = tableAccess.CreateCommand(strSQL);
            command.CommandType = CommandType.Text;
            return FillList(command);
        }
        #endregion

        #region Protected Method
        protected override string TableName
        {
            get { return "Bidder"; }
        }

        protected override string[] KeyFields
        {
            get { return new string[] { "Company_Code", "Bidder_Code" }; }
        }

        protected override string[] OtherFields
        {
            get { return new string[] { "Bidder_Name", "Address", "Tel_No", "Remark" }; }
        }

        protected override void AddKeyParameters(SqlParameterCollection parameters, Bidder entity, Company company)
        {
            parameters.Add(tableAccess.CreateParameter("Company_Code", company.CompanyCode));
            parameters.Add(tableAccess.CreateParameter("Bidder_Code", entity.BidderCode));
        }

        protected override void AddParameters(SqlParameterCollection parameters, Bidder entity)
        {
            parameters.Add(tableAccess.CreateParameter("Bidder_Name", entity.BidderName));
            parameters.Add(tableAccess.CreateParameter("Address", entity.Address));
            parameters.Add(tableAccess.CreateParameter("Tel_No", entity.TelNo));
            parameters.Add(tableAccess.CreateParameter("Remark", entity.Remark));
        }

        protected override void FillDetail(Bidder entity, SqlDataReader dataReader)
        {
            entity.BidderCode = (string)dataReader["Bidder_Code"];
            entity.BidderName = (string)dataReader["Bidder_Name"];
            entity.Address = (string)dataReader["Address"];
            entity.TelNo = (string)dataReader["Tel_No"];
            entity.Remark = (string)dataReader["Remark"];
        }

        private Bidder Fill(SqlCommand command, Company company)
        {
            Bidder entity = new Bidder();
            SqlDataReader dataReader = tableAccess.ExecuteDataReader(command);

                try
                {
                    while (dataReader.Read())
                    {
                        FillDetail(entity, dataReader);
                    }
                }
                catch (IndexOutOfRangeException ein)
                {
                    throw ein;
                }
                finally
                {
                    if (command.Connection.State != ConnectionState.Closed)
                    {
                        command.Connection.Close();
                    }

                    dataReader.Close();
                    tableAccess.CloseDataReader();
                }
            return entity;
        }

        #endregion

        public Bidder GetBidderByBidderCode(Bidder bidder, Company company)
        {
            SqlCommand command = tableAccess.CreateCommand("SSearchBidderByBidderCode");
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(tableAccess.CreateParameter("@Bidder_Code", bidder.BidderCode));

            return Fill(command,company);
        }


    }
}
