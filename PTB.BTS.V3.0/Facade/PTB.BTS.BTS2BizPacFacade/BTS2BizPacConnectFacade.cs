using System;
using System.Collections.Generic;
using System.Text;

using PTB.BTS.BTS2BizPacFlow;

using PTB.BTS.BTS2BizPacEntity;

using ictus.Common.Entity.General;
using Facade.PiFacade;
using System.Collections;
using PTB.BTS.Contract.Flow;
using PTB.BTS.Vehicle.Flow;
using Entity.VehicleEntities;
using Entity.AttendanceEntities;
using Entity.ContractEntities;

namespace PTB.BTS.BTS2BizPacFacade
{
    public abstract class BTS2BizPacConnectFacade : CommonPIFacadeBase
    {
        protected BTS2BizPacList listBP;
        public BTS2BizPacList ListBP
        {
            get { return listBP; }
            set { listBP = value; }
        }

        protected BTS2BizPacConnectFlow flowBP;

        //============================== Datasource ==============================
        public ArrayList DataSourceCustomer
        {
            get
            {
                CustomerFlow flowCustomer = new CustomerFlow();
                return flowCustomer.GetCustomerList(GetCompany()).GetArrayList();
            }
        }

        public ArrayList DataSourceGarage
        {
            get
            {
                GarageFlow flowGarage = new GarageFlow();
                GarageList garageList = new GarageList(GetCompany());
                Garage garage = new Garage();
                garage.Code = "ZZZ";
                garageList.Add(garage);
                flowGarage.FillGarageList(ref garageList);
                flowGarage = null;
                
                return garageList.GetArrayList();
            }
        }

        //============================== Constructor ==============================
        public BTS2BizPacConnectFacade(): base()
        {}

        //============================== Public Method ==============================
        public bool DisplayBizPacConnect()
        {
            listBP.Clear();
            return flowBP.FillBPList(listBP, GetCompany());
        }

        public bool DisplayBizPacCancel(TimePeriod period)
        {
            listBP.Clear();
            return flowBP.FillCancelBPList(listBP, period, GetCompany());
        }

        public bool BizPacRerun(Customer customer, DateTime connectDate)
        {
            listBP.Clear();
            return flowBP.BizPacRerun(listBP, customer, connectDate, GetCompany());
        }

        public bool UpdateBizPacConnect(ref string fileName)
        {
            return flowBP.Connect(listBP, ref fileName, GetCompany());
        }

        public bool UpdateBizPacCancel()
        {
            return flowBP.Cancel(listBP, GetCompany());
        }
    }
}
