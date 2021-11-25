using System;
using System.Collections.Generic;
using System.Text;
using PTB.BTS.Common.Flow;
using DataAccess.ContractDB.ContractChargeRateDB;
using PTB.BTS.ContractEntities.ContractChargeRate;
using Entity.ContractEntities;
using ictus.Common.Entity;
using SystemFramework.AppException;
using DataAccess.ContractDB;

namespace Flow.ContractFlow.ContractChargeRateFlow
{
    public class CustomerChargeFlowBase : FlowBase
    {
        private MinimumOTChargeList minOTChargeList;

        //============================== Constructor ==============================
        public CustomerChargeFlowBase()
            : base()
        {}

        //============================== Protected method ==============================
        protected ChargeRate GetChargeRate(ContractBase contract, Company company)
        {
            ChargeRateByContractDB dbChargeRateByContract = new ChargeRateByContractDB();
            ChargeRateByServiceStaffTypeDB dbChargeRateByServiceStaffType = new ChargeRateByServiceStaffTypeDB();
            ChargeRate chargeRate = new ChargeRate();
            ChargeRateByContract chargeRateByContract = new ChargeRateByContract();
            chargeRateByContract.ContractBase = contract;

            ChargeRateByServiceStaffType chargeRateByServiceStaffType;

            if (dbChargeRateByContract.FillChargeRateByContract(chargeRateByContract, company))
            {
                chargeRate = chargeRateByContract.ChargeRate;
            }
            else
            {
                if (((ServiceStaffContract)contract).ALatestServiceStaffRoleList.Count > 0)
                {
                    chargeRateByServiceStaffType = new ChargeRateByServiceStaffType();
                    chargeRateByServiceStaffType.ServiceStaffType = ((ServiceStaffContract)contract).ALatestServiceStaffRoleList[0].AServiceStaffType;
                    chargeRateByServiceStaffType.Customer = contract.ACustomer;
                    using (VDContractMatchDB dbVDContractMatch = new VDContractMatchDB())
                    {
                        chargeRateByServiceStaffType.DriverOnlyStatus = (dbVDContractMatch.FillVDContractMatch(contract.ContractNo, company) == -1);
                    }

                    if (dbChargeRateByServiceStaffType.FillChargeRateByServiceStaffType(chargeRateByServiceStaffType, company))
                    {
                        chargeRate = chargeRateByServiceStaffType.ChargeRate;
                    }
                    else
                    {
                        chargeRateByServiceStaffType = new ChargeRateByServiceStaffType();
                        chargeRateByServiceStaffType.ServiceStaffType = ((ServiceStaffContract)contract).ALatestServiceStaffRoleList[0].AServiceStaffType;
                        chargeRateByServiceStaffType.Customer = new Customer(Customer.DUMMYCODE);
                        if (contract.AContractType.Code == ContractType.CONTRACT_TYPE_DRIVER)
                        {
                            using (VDContractMatchDB dbVDContractMatch = new VDContractMatchDB())
                            {
                                chargeRateByServiceStaffType.DriverOnlyStatus = (dbVDContractMatch.FillVDContractMatch(contract.ContractNo, company) == -1);
                            }
                        }

                        if (dbChargeRateByServiceStaffType.FillChargeRateByServiceStaffType(chargeRateByServiceStaffType, company))
                        {
                            chargeRate = chargeRateByServiceStaffType.ChargeRate;
                        }
                        else
                        {
                            AppExceptionBase appExceptionBase = new AppExceptionBase("CustomerChargeFlowBase : GetCharge()");
                            appExceptionBase.SetMessage("ไม่พบค่าบริการสำหรับลูกค้า");
                            throw appExceptionBase;
                        }
                    }
                }
            }

            chargeRateByContract = null;
            chargeRateByServiceStaffType = null;
            dbChargeRateByContract = null;
            dbChargeRateByServiceStaffType = null;

            return chargeRate;
        }

        protected decimal GetMinOTAmount(ContractBase contract, Company company)
        {
            int vehicleNo = 0;

            if (minOTChargeList == null)
            {
                minOTChargeList = new MinimumOTChargeList(company);

                using (DataAccess.ContractDB.ContractChargeRateDB.MinimumOTChargeDB dbMinimumOTCharge = new DataAccess.ContractDB.ContractChargeRateDB.MinimumOTChargeDB())
                {
                    if (dbMinimumOTCharge.FillMinimumOTChargeList(minOTChargeList))
                    {
                        if (minOTChargeList.Count != 2)
                        {
                            AppExceptionBase appExceptionBase = new AppExceptionBase("CustomerChargeFlowBase : GetMinOTAmount()");
                            appExceptionBase.SetMessage("กรุณากำหนดอัตราค่าล่วงเวลาขั้นต่ำสำหรับพนักงานบริการ");
                            throw appExceptionBase;
                        }
                    }
                }
            }

            using (VDContractMatchDB dbVDContractMatch = new VDContractMatchDB())
            {
                vehicleNo = dbVDContractMatch.FillVDContractMatch(contract.ContractNo, company);
            }

            if (vehicleNo != -1)
            {
                return minOTChargeList["'N'"].MinOTAmount;
            }
            else
            {
                return minOTChargeList["'Y'"].MinOTAmount;
            }
        }
    }
}
