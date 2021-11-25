using System;
using System.Collections.Generic;
using DataAccess.CommonDB;
using Entity.AttendanceEntities;
using Entity.Constants;
using Entity.ContractEntities;
using Flow.ContractFlow;
using ictus.Common.Entity;
using PTB.BTS.BTS2BizPacDB.BizPacImplementDB;
using PTB.BTS.BTS2BizPacDB.BizPacReportDB;
using PTB.BTS.BTS2BizPacEntity;
using PTB.BTS.BTS2BizPacFlow.VehicleDebitNoteCreateFlow;
using Flow.Comparer;
using PTB.BTS.BTS2SAP;

namespace PTB.BTS.BTS2BizPacFlow.VehicleContractChargeFlow
{
    public class VehicleContractChargeBPFlow : BTS2BizPacConnectFlow
    {
        #region Private Variable
        private VDNCreaterManager VDNCreaterManager;
        #endregion

        #region Constructor
        public VehicleContractChargeBPFlow()
            : base()
        {
            dbConnect = new ContractChargeDetailBPDB(ContractChargeDetailBPDB.CONTRACTTYPEBP.VEHICLE);
        } 
        #endregion

        #region Private Method

        private void generateTrVehicleDNAttach(BTS2BizPacList listBP, BTS2BizPacList vehicleAttachList, Company company)
        {
            vehicleAttachList.Clear();
            VehicleContractChargeBP vehicleContractChargeBP;
            VehicleDNAttach vehicleDNAttach;

            for (int i = 0; i < listBP.Count; i++)
            {            
                VehicleRole vehicleRole;
                vehicleDNAttach = new VehicleDNAttach(company);
                vehicleContractChargeBP = (VehicleContractChargeBP)listBP[i];

                for (int j = 0; j < vehicleContractChargeBP.AVehicleRoleList.Count; j++)
                {
                    vehicleRole = vehicleContractChargeBP.AVehicleRoleList[j];

                    vehicleDNAttach.AttachGroup = vehicleContractChargeBP.AttachGroup;
                    vehicleDNAttach.AKindOfContract = vehicleContractChargeBP.AKindOfContract;
                    vehicleDNAttach.ACustomer = vehicleContractChargeBP.ACustomer;
                    vehicleDNAttach.BizPacRefNo = vehicleContractChargeBP.BizPacRefNo;
                    vehicleDNAttach.ACustomerDepartment = vehicleContractChargeBP.ACustomerDepartment;
                    vehicleDNAttach.ContractNo = vehicleContractChargeBP.ContractNo;
                    vehicleDNAttach.VATAmount = vehicleContractChargeBP.VATAmount;
                    vehicleDNAttach.ChargeAmount = vehicleContractChargeBP.ChargeAmount;
                    vehicleDNAttach.Vehicle = vehicleRole.AVehicle;
                    vehicleDNAttach.Hirer = vehicleRole.AHirer;
                    vehicleDNAttach.ContractCharge = vehicleContractChargeBP.ContractCharge;
                    vehicleDNAttach.RateStatus = vehicleContractChargeBP.RateStatus;

                    //contractCharge = dbContractCharge.GetContractCharge(vehicleContractChargeBP.ContractNo, company);

                    //if (contractCharge != null)
                    //{
                    //    vehicleDNAttach.MonthlyCharge = contractCharge.MonthlyCharge;
                    //}

                    vehicleAttachList.Add(vehicleDNAttach);
                }
                vehicleRole = null;
            }
            vehicleDNAttach = null;
        }

        /// <summary>
        /// Collect contract and separate TIS Department
        /// </summary>
        /// <param name="listBP"></param>
        /// <param name="result"></param>
        private void collectContract(BTS2BizPacList listBP, BTS2BizPacList resultList)
        {
            foreach (VehicleContractChargeBP vehicleChargeBP in listBP)
            {
                List<VehicleContractChargeBP> listVehicleChargeBP = new List<VehicleContractChargeBP>();

                fillContractDepartmentAssignment(vehicleChargeBP);

                //Separate TIS Department
                if (vehicleChargeBP.AssignedDepartmentList != null && vehicleChargeBP.AssignedDepartmentList.Count > 1)
                {
                    foreach (VehicleContractChargeBP item in separateDepartmentContract(vehicleChargeBP))
                    {
                        listVehicleChargeBP.Add(item);
                    }
                }
                else
                {
                    listVehicleChargeBP.Add(vehicleChargeBP);                
                }

                //Loop for collect charge amount
                foreach (VehicleContractChargeBP item in listVehicleChargeBP)
                {
                    string key = vehicleChargeBP.ContractNo.ToString();

                    //item.AVehicleRoleList[0].AVehicle.PlateNumber;

                    if (item.ACustomer.Code == CustomerCodeValue.TIS)
                    {
                        key += item.ACustomerDepartment.Code;

                    }

                    if (resultList.Contain(key))
                    {
                        VehicleContractChargeBP data = (VehicleContractChargeBP)resultList[key];
                        data.ChargeAmount += item.ChargeAmount;
                    }
                    else
                    {
                        resultList.Add(key, item);
                    }
                }                
            }

            listBP.Clear();
        }

        /// <summary>
        /// Separate vehicle contract charge by department assignment 
        /// </summary>
        /// <param name="vehicleCharge"></param>
        /// <returns></returns>
        private List<VehicleContractChargeBP> separateDepartmentContract(VehicleContractChargeBP conditionVehicleBP)
        {
            List<VehicleContractChargeBP> vehicleBPList = new List<VehicleContractChargeBP>();
            VehicleContractChargeBP vehicleBP = null;
            TimePeriod assignPeriod = null;

            decimal totalChargeAmount = decimal.Zero, diffChargAmount = decimal.Zero;
            decimal initChargeAmount = conditionVehicleBP.ChargeAmount;
            decimal chargePerDay = decimal.Divide(initChargeAmount, GetDays(conditionVehicleBP.APeriod, conditionVehicleBP.YearMonth));

            //Order item in list
            ContractDepartmentAssignmentComparer comparer = new ContractDepartmentAssignmentComparer();
            comparer.CompareType = ContractDepartmentAssignment.DataPropertyName.ASSIGN_FROM_DATE;

            conditionVehicleBP.AssignedDepartmentList.Sort(comparer);

            foreach (Entity.ContractEntities.ContractDepartmentAssignment deptAssign in conditionVehicleBP.AssignedDepartmentList)
            {
                assignPeriod = GetAssignPeriod(deptAssign.AssignPeriod, conditionVehicleBP.YearMonth);

                vehicleBP = conditionVehicleBP.CloneVehicleCharge(conditionVehicleBP);
                vehicleBP.ACustomerDepartment = deptAssign.AssignDepartment;
                vehicleBP.ChargeAmount = decimal.Round(decimal.Multiply(assignPeriod.DayDiff, chargePerDay), MidpointRounding.AwayFromZero);
                totalChargeAmount += vehicleBP.ChargeAmount;

                vehicleBPList.Add(vehicleBP);
            }

            //Adjust diff of charge amount to last contract
            if (!totalChargeAmount.Equals(initChargeAmount))
            {
                diffChargAmount = decimal.Subtract(totalChargeAmount, initChargeAmount);
                vehicleBPList[vehicleBPList.Count - 1].ChargeAmount -= diffChargAmount;
            }

            return vehicleBPList;
        }

        /// <summary>
        /// Fill contract department assignment by period 
        /// </summary>
        /// <param name="vehicleChargeBP"></param>
        private void fillContractDepartmentAssignment(VehicleContractChargeBP vehicleChargeBP)
        {
            TimePeriod timePeriod = new TimePeriod(vehicleChargeBP.YearMonth.MinDateOfMonth, vehicleChargeBP.YearMonth.MaxDateOfMonth);

            using (ContractDepartmentAssignmentFlow flow = new ContractDepartmentAssignmentFlow(vehicleChargeBP.AContractChargeList.Company))
            {
                vehicleChargeBP.AssignedDepartmentList = flow.GetListByContractPeriod(vehicleChargeBP.ContractNo.ToString(), timePeriod);

                if (vehicleChargeBP.AssignedDepartmentList != null && vehicleChargeBP.AssignedDepartmentList.Count == 1)
                {
                    vehicleChargeBP.ACustomerDepartment = vehicleChargeBP.AssignedDepartmentList[0].AssignDepartment;
                }
            }
        }
        #endregion

        #region Protected Method
        protected override bool SpecificConnect(BTS2BizPacList listBP, BTS2BizPacList resultListBTS, BTS2BizPacList resultListBP)
        {
            VDNCreaterManager = new VDNCreaterManager();
            VDNCreaterManager.RefFlow = this;

            BTS2BizPacList collectListBP = new BTS2BizPacList();
            collectContract(listBP, collectListBP);

            IBTS2BizPacHeader header;
            for (int i = 0; i < collectListBP.Count; i++)
            {
                header = collectListBP[i];

                //Round charge amount
                ((VehicleContractChargeBP)header).BaseAmount = Math.Round(((VehicleContractChargeBP)header).BaseAmount);

                //Separate group of debit note
                VDNCreaterManager.Add(header);

                //Separate TIS Departmentin
                string key = header.EntityKey;

                if (((VehicleContractChargeBP)header).ACustomer.Code == CustomerCodeValue.TIS)
                {
                    key += ((VehicleContractChargeBP)header).ACustomerDepartment.Code;
                }

                resultListBTS.Add(key, header);
            }
            VDNCreaterManager.FillVehicleDebitNote(resultListBP);

            header = null;
            collectListBP = null;
            return true;
        }

        protected override bool TRConnect(BTS2BizPacList listBP, TableAccess tableAccess, Company company)
        {
            bool result = false;
            BTS2BizPacList vehicleAttachList = new BTS2BizPacList();
            TrVehicleDNAttachDB dbTrVehicleDNAttach = new TrVehicleDNAttachDB();

            generateTrVehicleDNAttach(listBP, vehicleAttachList, company);

            dbTrVehicleDNAttach.TableAccess = tableAccess;
            dbTrVehicleDNAttach.DeleteTrVehicleDNAttach();
            result = dbTrVehicleDNAttach.InsertTrVehicleDNAttach(vehicleAttachList);

            return result;
        }

        //Napat C. 14/02/2019
        protected override string GenerateCSV2SAP(BTS2BizPacList listBP, DateTime connectDate)
            // [TODO] Kriangkrai A.
        //protected override string GenerateCSV2SAP(BTS2BizPacList listBP, TableAccess tableAccess)
        {
            ConnectVehicelContractCharge2SAP sapConnection = new ConnectVehicelContractCharge2SAP();
            string filename = sapConnection.GetVehicelContractChargeSAPDataFile(listBP, connectDate.ToString("ddMMyyyy"));

            return filename;
        }
        #endregion
    }
}
