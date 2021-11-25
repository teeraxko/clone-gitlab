using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

using DataAccess.CommonDB;
using DataAccess.VehicleDB;
using DataAccess.VehicleDB.VehicleLeasingDB;

using Entity.VehicleEntities;
using Entity.ContractEntities;
using Entity.VehicleEntities.VehicleLeasing;

using Flow.VehicleFlow.LeasingFlow;

using ictus.Framework.ASC.VBFuntion;
using ictus.PIS.PI.Entity;
using ictus.Common.Entity;

using PTB.BTS.Common.Flow;
using ictus.Common.Entity.General;

namespace Flow.VehicleFlow.VehicleLeasingFlow
{
    public class VehicleCalculationFlow : FlowBase
    {
        
        #region Private
        private VehicleCalculationDB dbVehicleCalculation;
        #endregion

        //================================= Private Method =============================

        private static decimal round2digits(decimal value)
        {
            decimal tempVal = value * 100;
            decimal remain = decimal.Remainder(tempVal, 1);
            if (remain >= 0.5m)
            {
                return decimal.Ceiling(tempVal) / 100;
            }
            else
            {
                return decimal.Floor(tempVal) / 100;
            }
        }

        private bool calculateInterestCost(VehicleCalculation value, bool hasContract)
        {
            value.VehicleInterestCostList = new VehicleInterestCostList();
            //following line edit by Nuttapol S. 5/3/2009     
            value.VehicleInterestCostList.Rate = (hasContract && value.LeasingCalculation.RateOfReturnActual != 0) ? value.LeasingCalculation.RateOfReturnActual : value.LeasingCalculation.RateOfReturnEstimate;
            value.VehicleInterestCostList.TotalCost = value.VehiclePrice;
            value.VehicleInterestCostList.LeaseTerm = value.LeasingCalculation.LeaseTerm;
            value.VehicleInterestCostList.PercentResidualValue = value.LeasingCalculation.PercentResidual;

            VehicleInterestCost interestCost;
            value.VehicleInterestCostList.InterestCostList = new List<VehicleInterestCost>();

            decimal rate = value.VehicleInterestCostList.Rate / 1200;
            value.VehicleInterestCostList.PVofResidualValue = Financial.NegativePV(rate, value.VehicleInterestCostList.LeaseTerm, 0, value.VehicleInterestCostList.ResidualValue);

            decimal carryValue = value.VehicleInterestCostList.TotalCost;

            for (int i = 1; i <= value.VehicleInterestCostList.LeaseTerm; i++)
            {
                interestCost = new VehicleInterestCost();
                interestCost.Year = (i - 1) / 12;
                interestCost.Month = i;
                interestCost.Payment = Financial.NegativePMT(rate, value.VehicleInterestCostList.LeaseTerm, value.VehicleInterestCostList.PVofAnnuity);
                interestCost.Interest = carryValue * value.VehicleInterestCostList.Rate / 1200;
                interestCost.CarryingValue = carryValue - interestCost.Cost;

                
                value.VehicleInterestCostList.InterestCostList.Add(interestCost);

                carryValue = interestCost.CarryingValue;
            }
            return true;

        }

        private bool calculateProfit(VehicleCalculation value, bool hasContract)
        {
            VehicleProfitCalDetail vehicleProfitCalDetail;
            value.VehicleProfitCalDetailList = new List<VehicleProfitCalDetail>();
            int year = value.LeasingCalculation.LeaseTerm / 12;

            vehicleProfitCalDetail = new VehicleProfitCalDetail();
            vehicleProfitCalDetail.GroupCode = 1;
            vehicleProfitCalDetail.Line = 1;
            vehicleProfitCalDetail.Item = "Yearly Charge " + value.LeasingCalculation.MonthlyCharge.ToString("#,##0.00") + "*12";
            vehicleProfitCalDetail.Year1 = value.LeasingCalculation.MonthlyCharge * 12;
            value.VehicleProfitCalDetailList.Add(vehicleProfitCalDetail);

            vehicleProfitCalDetail = new VehicleProfitCalDetail();
            vehicleProfitCalDetail.GroupCode = 1;
            vehicleProfitCalDetail.Line = 2;
            vehicleProfitCalDetail.Item = "Residual Value";
            vehicleProfitCalDetail.Year1 = 0;
            value.VehicleProfitCalDetailList.Add(vehicleProfitCalDetail);

            vehicleProfitCalDetail = new VehicleProfitCalDetail();
            vehicleProfitCalDetail.GroupCode = 2;
            vehicleProfitCalDetail.Line = 3;
            vehicleProfitCalDetail.Item = "Book Value";
            vehicleProfitCalDetail.Year1 = 0;
            value.VehicleProfitCalDetailList.Add(vehicleProfitCalDetail);

            vehicleProfitCalDetail = new VehicleProfitCalDetail();
            vehicleProfitCalDetail.GroupCode = 2;
            vehicleProfitCalDetail.Line = 4;
            vehicleProfitCalDetail.Item = "Depreciation";
            vehicleProfitCalDetail.Year1 = value.VehiclePrice * value.Depreciation / 100m; 
            value.VehicleProfitCalDetailList.Add(vehicleProfitCalDetail);

            vehicleProfitCalDetail = new VehicleProfitCalDetail();
            vehicleProfitCalDetail.GroupCode = 2;
            vehicleProfitCalDetail.Line = 5;
            vehicleProfitCalDetail.Item = "Insurance";
            vehicleProfitCalDetail.Year1 = value.LeasingCalculation.InsurancePremium;
            value.VehicleProfitCalDetailList.Add(vehicleProfitCalDetail);

            vehicleProfitCalDetail = new VehicleProfitCalDetail();
            vehicleProfitCalDetail.GroupCode = 2;
            vehicleProfitCalDetail.Line = 6;
            vehicleProfitCalDetail.Item = "Vehicle Tax";
            vehicleProfitCalDetail.Year1 = value.LeasingCalculation.TaxRegister;
            value.VehicleProfitCalDetailList.Add(vehicleProfitCalDetail);

            vehicleProfitCalDetail = new VehicleProfitCalDetail();
            vehicleProfitCalDetail.GroupCode = 2;
            vehicleProfitCalDetail.Line = 7;
            vehicleProfitCalDetail.Item = "Maintenance";
            vehicleProfitCalDetail.Year1 = value.LeasingCalculation.Maintenance*12;
            value.VehicleProfitCalDetailList.Add(vehicleProfitCalDetail);

            copyYear(value.VehicleProfitCalDetailList, value.ForYear);

            vehicleProfitCalDetail = new VehicleProfitCalDetail();
            vehicleProfitCalDetail.GroupCode = 2;
            vehicleProfitCalDetail.Line = 8;

            if (hasContract && value.LeasingCalculation.RateOfReturnActual != 0)
            {
                vehicleProfitCalDetail.Item = "Interest " + value.LeasingCalculation.RateOfReturnActual.ToString() + "%";
            }
            else
            {
                vehicleProfitCalDetail.Item = "Interest " + value.LeasingCalculation.RateOfReturnEstimate.ToString() + "%";
            }

            foreach (VehicleInterestCost entity in value.VehicleInterestCostList.InterestCostList)
            {
                switch (entity.Year)
                {
                    case 0:
                        {
                            vehicleProfitCalDetail.Year1 += entity.Interest;
                            break;
                        }
                    case 1:
                        {
                            vehicleProfitCalDetail.Year2 += entity.Interest;
                            break;
                        }
                    case 2:
                        {
                            vehicleProfitCalDetail.Year3 += entity.Interest;
                            break;
                        }
                    case 3:
                        {
                            vehicleProfitCalDetail.Year4 += entity.Interest;
                            break;
                        }
                    default:
                        {
                            vehicleProfitCalDetail.Year5 += entity.Interest;
                            break;
                        }
                }
            }
            value.VehicleProfitCalDetailList.Add(vehicleProfitCalDetail);

            //Calculate book value : Woranai 2009/07/28
            decimal bookValue;
            switch (value.ForYear)
            {
                case 0:
                case 1:
                    {
                        value.VehicleProfitCalDetailList[1].Year1 = value.RealResidualValue;
                        bookValue = (100 - 1 * value.Depreciation) * value.VehiclePrice / 100;
                        if (bookValue < 0)
                        {
                            bookValue = 0;
                        }
                        value.VehicleProfitCalDetailList[2].Year1 = bookValue;
                        break;
                    }
                case 2:
                    {
                        value.VehicleProfitCalDetailList[1].Year2 = value.RealResidualValue;
                        bookValue = (100 - 2 * value.Depreciation) * value.VehiclePrice / 100;
                        if (bookValue < 0)
                        {
                            bookValue = 0;
                        }
                        value.VehicleProfitCalDetailList[2].Year2 = bookValue;
                        break;
                    }
                case 3:
                    {
                        value.VehicleProfitCalDetailList[1].Year3 = value.RealResidualValue;
                        bookValue = (100 - 3 * value.Depreciation) * value.VehiclePrice / 100;
                        if (bookValue < 0)
                        {
                            bookValue = 0;
                        }
                        value.VehicleProfitCalDetailList[2].Year3 = bookValue;
                        break;
                    }
                case 4:
                    {
                        value.VehicleProfitCalDetailList[1].Year4 = value.RealResidualValue;
                        bookValue = (100 - 4 * value.Depreciation) * value.VehiclePrice / 100;
                        if (bookValue < 0)
                        {
                            bookValue = 0;
                        }
                        value.VehicleProfitCalDetailList[2].Year4 = bookValue;
                        break;
                    }
                default:
                    {
                        value.VehicleProfitCalDetailList[1].Year5 = value.RealResidualValue;
                        bookValue = (100 - 5 * value.Depreciation) * value.VehiclePrice / 100;
                        if (bookValue < 0)
                        {
                            bookValue = 0;
                        }
                        value.VehicleProfitCalDetailList[2].Year5 = bookValue;
                        break;
                    }
            }

            return true;
        }

        private void copyYear(List<VehicleProfitCalDetail> value, int year)
        {
            switch (year)
            {
                case 5:
                    {
                        for (int i = 0; i < value.Count; i++)
                        {
                            value[i].Year5 = value[i].Year1;
                        }
                        goto case 4;
                    }
                case 4:
                    {
                        for (int i = 0; i < value.Count; i++)
                        {
                            value[i].Year4 = value[i].Year1;
                        }
                        goto case 3;
                    }
                case 3:
                    {
                        for (int i = 0; i < value.Count; i++)
                        {
                            value[i].Year3 = value[i].Year1;
                        }
                        goto case 2;
                    }
                case 2:
                    {
                        for (int i = 0; i < value.Count; i++)
                        {
                            value[i].Year2 = value[i].Year1;
                        }
                        goto case 1;
                    }
                case 1:
                case 0:
                    {
                        return;
                    }
                default:
                    {
                        goto case 5;
                    }
            }
        }

        //================================= Constructor ================================
        public VehicleCalculationFlow() : base()
        {
            dbVehicleCalculation = new VehicleCalculationDB();
        }

        // ================================public Method=====================
        public List<Entity.VehicleEntities.VehicleLeasing.VehicleCalculation> GetListVehicleCalculation()
        {
            using (VehicleCalculationDB dbVehicleCalculation = new VehicleCalculationDB())
            {              
                return dbVehicleCalculation.GetListVehicleCalculation();
            }
        }

        public List<VehicleCalculation> GetVehicleSearchCalculation(Customer aCustomer, Brand aBrand, Model aModel,string quotationNo, Company aCompany)
        {
            using (VehicleCalculationDB dbVehicle = new VehicleCalculationDB())
            {
                return dbVehicle.GetVehicleSearchCalculation(aCustomer, aBrand, aModel,quotationNo, aCompany);
            }            
        }

        public List<VehicleCalculation> GetVehicleSearchCalculationQuotation(Customer aCustomer, Brand aBrand, Model aModel, Company aCompany)
        {
            using (VehicleCalculationDB dbVehicle = new VehicleCalculationDB())
            {
                return dbVehicle.GetVehicleSearchCalculationQuotation(aCustomer, aBrand, aModel, aCompany);
            }
        }

        public List<VehicleCalculation> GetVehicleSearchConditionByPlateNo(string plateNoPrefix, string plateNoRunning, Company aCompany)
        {
            using (VehicleCalculationDB dbVehicle = new VehicleCalculationDB())
            {
                return dbVehicle.GetVehicleSearchConditionByPlateNo(plateNoPrefix, plateNoRunning,aCompany);
            }
        }

        public VehicleCalculation GetVehicleCalculationByPlateNo(string plateNoPrefix, string plateNoRunning, Company company)
        {
            using (VehicleCalculationDB dbVehicle = new VehicleCalculationDB())
            {
                return dbVehicle.GetVehicleCalculationByPlateNo(plateNoPrefix, plateNoRunning, company);
            }
        }

        public List<VehicleCalculation> GetVehicleSearchConditionListByQuotationNo(DocumentNo documentNo,Company aCompany)
        {
            using (VehicleCalculationDB dbVehicle = new VehicleCalculationDB())
            {
                return dbVehicle.GetVehicleSearchConditionListByQuotationNo(documentNo,aCompany);
            }
        }

        public VehicleCalculation GetVehicleSearchConditionByQuotationNo(DocumentNo documentNo, Company aCompany)
        {
            using (VehicleCalculationDB dbVehicle = new VehicleCalculationDB())
            {
                return dbVehicle.GetVehicleSearchConditionByQuotationNo(documentNo, aCompany);
            }
        }

        public VehicleCalculation GetVehicleCalculationByCalculationNo(VehicleCalculation vehicleCalculation, Company aCompany)
        {
            using (VehicleCalculationDB dbVehicle = new VehicleCalculationDB())
            {
                return dbVehicle.GetVehicleCalculationByCalculationNo(vehicleCalculation, aCompany);
            }
        }

        public VehicleCalculation GetVehicleConditionByQuotationNo(DocumentNo documentNo,Customer aCustomer,Brand aBrand,Model aModel, Company aCompany)
        {
            using (VehicleCalculationDB dbVehicle = new VehicleCalculationDB())
            {
                return dbVehicle.GetVehicleConditionByQuotationNo(documentNo,aCustomer,aBrand,aModel, aCompany);
            }
        }

        public List<VehicleCalculation> GetVehicleUpdateCondition(VehicleCalculation vehicleCalculation,Company aCompany)
        {
            using (VehicleCalculationDB dbVehicle = new VehicleCalculationDB())
            {
                return dbVehicle.GetVehicleUpdateCondition(vehicleCalculation,aCompany);
            }
        }

        public bool InsertVehicleCalculation(VehicleCalculation vehicleCalculation,Company aCompany)
        {
            using (VehicleCalculationDB dbVehicleCalculation = new VehicleCalculationDB())
            {
                return dbVehicleCalculation.InsertVehicleCalculation(vehicleCalculation,aCompany);
            }
        }

        public bool DeleteVehicleCalculation(VehicleCalculation value, Company aCompany)
        {
            using (VehicleCalculationDB dbVehicleCalculation = new VehicleCalculationDB())
            {
                return dbVehicleCalculation.DeleteVehicleCalculation(value, aCompany);
            }
        }

        public bool UpdateVehicleCalculation(VehicleCalculation vehicleCalculation, Company aCompany)
        {
            using (VehicleCalculationDB dbVehicleCalculation = new VehicleCalculationDB())
            {
                return dbVehicleCalculation.UpdateVehicleCalculation(vehicleCalculation, aCompany);
            }
        }

        /// <summary>
        /// Function    : Calculate monthly charge
        /// Author      : Thawatchai B.
        /// Create date : 09/10/08
        /// </summary>
        /// <param name="vehicleCalculation"></param>
        /// <returns>calculated vehicle leasing </returns>
        public VehicleLeasingCalculation Calculate(VehicleCalculation vehicleCalculation)
        {
            decimal rate = vehicleCalculation.LeasingCalculation.RateOfReturnEstimate / 1200;
            vehicleCalculation.LeasingCalculation.ResidualValue = (vehicleCalculation.BodyCost + vehicleCalculation.ModifyCost) * vehicleCalculation.LeasingCalculation.PercentResidual / 100;

            vehicleCalculation.LeasingCalculation.PV = round2digits(Financial.NegativePV(rate, vehicleCalculation.LeasingCalculation.LeaseTerm, 0m, vehicleCalculation.LeasingCalculation.ResidualValue));
            vehicleCalculation.LeasingCalculation.PMT = round2digits(Financial.NegativePMT(rate, vehicleCalculation.LeasingCalculation.LeaseTerm, (vehicleCalculation.BodyCost + vehicleCalculation.ModifyCost) - vehicleCalculation.LeasingCalculation.PV));

            vehicleCalculation.LeasingCalculation.MonthlyChargeActual = vehicleCalculation.LeasingCalculation.PMT + (vehicleCalculation.LeasingCalculation.InsurancePremium / 12) + (vehicleCalculation.LeasingCalculation.TaxRegister / 12) + vehicleCalculation.LeasingCalculation.Maintenance;

            //int round = (int)Math.Round(vehicleCalculation.LeasingCalculation.MonthlyChargeActual / 1000);
            //vehicleCalculation.LeasingCalculation.MonthlyCharge = round * 1000;

            decimal charge = vehicleCalculation.LeasingCalculation.MonthlyChargeActual;
            decimal resultCharge;

            if (charge > 1000)
            {
                resultCharge = charge - (decimal.Floor(charge / 1000) * 1000);
            }
            else
            {
                resultCharge = charge;
            }

            if (resultCharge < 250)
            {
                resultCharge = decimal.Zero;
            }
            else if (resultCharge >= 250 && resultCharge <= 750)
            {
                resultCharge = 500;
            }
            else
            {
                resultCharge = 1000;
            }

            if (charge > 1000)
            {
                resultCharge = (decimal.Floor(charge / 1000) * 1000) + resultCharge;
            }

            vehicleCalculation.LeasingCalculation.MonthlyCharge = resultCharge;

            return vehicleCalculation.LeasingCalculation;
        }
        
        public bool CalculateProfit(VehicleCalculation value, Company aCompany, VehicleInfo vehicleInfo)
        {
            //check rate of return, estimate or actual (true = Actual, false = Estimate)
            bool hasContract = false;

            if (value.Quotation != null && vehicleInfo.AVehicleStatus != null && vehicleInfo.AVehicleStatus.Code == "4")
            {
                using (VehicleQuotationDB db = new VehicleQuotationDB())
                {
                    VehicleQuotation vehicleQuotation = new VehicleQuotation();
                    vehicleQuotation = db.GetQuotationByQuotationNo(value.Quotation.QuotationNo.ToString(), aCompany);
                    if (vehicleQuotation.VehicleContract.ContractNo != null)
                    {
                        hasContract = true;
                    }
                    else if (vehicleQuotation.Purchasing.PurchasNo != null)
                    {
                        using (VehiclePurchaseContractDB dbPurchaseContract = new VehiclePurchaseContractDB())
                        {
                            VehiclePurchasingContract vehiclePurchaseContract = new VehiclePurchasingContract();
                            vehiclePurchaseContract = dbPurchaseContract.GetPurchasingContractByPurchasing(vehicleQuotation.Purchasing, aCompany);
                            if (vehiclePurchaseContract.Contract != null)
                            {
                                hasContract = true;
                            }
                        }
                    }
                }
            }

            bool result = calculateInterestCost(value, hasContract);
            result &= calculateProfit(value, hasContract);

            if (result)
            {
                if (hasContract)
                {
                    CalculateAcutalValue(value, vehicleInfo);
                }

                UpdateValueintoDB(result, value);
            }

            return hasContract;
        }

        /// <summary>
        /// Calculate vehicle price
        /// </summary>
        /// <param name="vehicleCalculation"></param>
        /// <returns></returns>
        public decimal CalculateVehiclePrice(VehicleCalculation vehicleCalculation)
        {
            return vehicleCalculation.BodyCost + vehicleCalculation.ModifyCost;
        }

        /// <summary>
        /// Get Vehicle info by quotation no.
        /// </summary>
        /// <param name="quotationNo"></param>
        /// <param name="company"></param>
        /// <returns></returns>
        public VehicleInfo GetVehicleInfoByQuotation(DocumentNo quotationNo, Company company)
        {
            VehicleInfo vehicleInfo = new VehicleInfo();
            using (VehicleQuotationDB dbVehicleQuotation = new VehicleQuotationDB())
            {
                VehicleQuotation vehicleQuotation = new VehicleQuotation();
                vehicleQuotation = dbVehicleQuotation.GetQuotationByQuotationNo(quotationNo.ToString(), company);
                if (vehicleQuotation.Purchasing.PurchasNo != null)
                {
                    using (VehiclePurchaseContractDB dbPurchaseContract = new VehiclePurchaseContractDB())
                    {
                        VehiclePurchasingContract vehiclePurchasingContract = new VehiclePurchasingContract();
                        vehiclePurchasingContract = dbPurchaseContract.GetPurchasingContractByPurchasing(vehicleQuotation.Purchasing, company);
                        if (vehiclePurchasingContract.Vehicle != null)
                        {
                            using (VehicleDB dbVehicle = new VehicleDB())
                            {
                                vehicleInfo = dbVehicle.GetVehicleInfo(vehiclePurchasingContract.Vehicle.VehicleNo, company);
                            }
                        }
                    }
                }
            }
            return vehicleInfo;
        }

        public void CalculateAcutalValue(VehicleCalculation value, VehicleInfo vehicleInfo)
        {
            Company company = new Company("12");
            new PTB.BTS.PI.Flow.CompanyFlow().FillCompany(ref company);
            VehicleTaxList vehicleTaxList = new VehicleTaxList(company);
            VehicleTax vehicleTax = new VehicleTax();
            vehicleTax.AVehicle = new Vehicle();
            vehicleTax.AVehicle.VehicleNo = vehicleInfo.VehicleNo;
            VehicleInsuranceList vehicleInsuranceList = new VehicleInsuranceList(company);
            VehicleSelling vehicleSelling = new VehicleSellingPlanFlow().FillVehicleSelling(vehicleInfo.VehicleNo,company);
            new PTB.BTS.Vehicle.Flow.VehicleInsuranceTypeOneFlow().FillInsuranceTypeOneDetailList(ref vehicleInsuranceList, vehicleInfo);
            new PTB.BTS.Vehicle.Flow.VehicleTaxFlow().FillVehicleTaxList(ref vehicleTaxList, vehicleTax, true);
            VehicleMaintenance vehicleMaintenanceList = new PTB.BTS.Vehicle.Flow.VehicleMaintenanceFlow().FillVehicleMaintenance(vehicleInfo);

            decimal actualInsurance;

            switch (value.ForYear)
            {
                case 0:
                case 1:
                    {
                        value.VehicleProfitCalDetailList[1].Year1 = vehicleSelling.SellingPrice;
                        value.VehicleProfitCalDetailList[2].Year1 = vehicleSelling.BV;
                        break;
                    }
                case 2:
                    {
                        value.VehicleProfitCalDetailList[1].Year2 = vehicleSelling.SellingPrice;
                        value.VehicleProfitCalDetailList[2].Year2 = vehicleSelling.BV;
                        break;
                    }
                case 3:
                    {
                        value.VehicleProfitCalDetailList[1].Year3 = vehicleSelling.SellingPrice;
                        value.VehicleProfitCalDetailList[2].Year3 = vehicleSelling.BV;
                        break;
                    }
                case 4:
                    {
                        value.VehicleProfitCalDetailList[1].Year4 = vehicleSelling.SellingPrice;
                        value.VehicleProfitCalDetailList[2].Year4 = vehicleSelling.BV;
                        break;
                    }
                default:
                    {
                        value.VehicleProfitCalDetailList[1].Year5 = vehicleSelling.SellingPrice;
                        value.VehicleProfitCalDetailList[2].Year5 = vehicleSelling.BV;
                        break;
                    }
            }

            if (vehicleInsuranceList.Count > 0)
            {
                value.VehicleProfitCalDetailList[4].Year1 = value.VehicleProfitCalDetailList[4].Year2 = value.VehicleProfitCalDetailList[4].Year3 = value.VehicleProfitCalDetailList[4].Year4 = value.VehicleProfitCalDetailList[4].Year5 = 0;
                
                for (int i = 0; i < vehicleInsuranceList.Count; ++i)
                {
                    actualInsurance = vehicleInsuranceList[i].PremiumAmount + vehicleInsuranceList[i].VatAmount + vehicleInsuranceList[i].RevenueStampFee;

                    switch (i)
                    {
                        case 0:
                            {
                                value.VehicleProfitCalDetailList[4].Year1 = actualInsurance;
                                break;
                            }
                        case 1:
                            {
                                value.VehicleProfitCalDetailList[4].Year2 = actualInsurance;
                                break;
                            }
                        case 2:
                            {
                                value.VehicleProfitCalDetailList[4].Year3 = actualInsurance;
                                break;
                            }
                        case 3:
                            {
                                value.VehicleProfitCalDetailList[4].Year4 = actualInsurance;
                                break;
                            }
                        default:
                            {
                                value.VehicleProfitCalDetailList[4].Year5 = actualInsurance;
                                break;
                            }
                    }
                }
            }

            if (vehicleTaxList.Count > 0)
            {
                value.VehicleProfitCalDetailList[5].Year1 = value.VehicleProfitCalDetailList[5].Year2 = value.VehicleProfitCalDetailList[5].Year3 = value.VehicleProfitCalDetailList[5].Year4 = value.VehicleProfitCalDetailList[5].Year5 = 0;

                for (int i = 0; i < vehicleTaxList.Count; ++i)
                {
                    switch (i)
                    {
                        case 0:
                            {
                                value.VehicleProfitCalDetailList[5].Year1 = vehicleTaxList[i].TaxAmount;
                                break;
                            }
                        case 1:
                            {
                                value.VehicleProfitCalDetailList[5].Year2 = vehicleTaxList[i].TaxAmount;
                                break;
                            }
                        case 2:
                            {
                                value.VehicleProfitCalDetailList[5].Year3 = vehicleTaxList[i].TaxAmount;
                                break;
                            }
                        case 3:
                            {
                                value.VehicleProfitCalDetailList[5].Year4 = vehicleTaxList[i].TaxAmount;
                                break;
                            }
                        default:
                            {
                                value.VehicleProfitCalDetailList[5].Year5 = vehicleTaxList[i].TaxAmount;
                                break;
                            }
                    }
                }
            }

            if (vehicleMaintenanceList.Count > 0 && vehicleInfo.RegisterDate != null && vehicleInfo.RegisterDate != NullConstant.DATETIME)
            {
                value.VehicleProfitCalDetailList[6].Year1 = value.VehicleProfitCalDetailList[6].Year2 = value.VehicleProfitCalDetailList[6].Year3 = value.VehicleProfitCalDetailList[6].Year4 = value.VehicleProfitCalDetailList[6].Year5 = 0;

                for (int i = 0; i < vehicleMaintenanceList.Count; ++i)
                {
                    if (vehicleMaintenanceList[i].RepairPeriod.From != NullConstant.DATETIME)
                    {
                        if (vehicleInfo.RegisterDate <= vehicleMaintenanceList[i].RepairPeriod.From && vehicleMaintenanceList[i].RepairPeriod.From <= vehicleInfo.RegisterDate.AddYears(1))
                        {
                            value.VehicleProfitCalDetailList[6].Year1 += vehicleMaintenanceList[i].TotalAmount;
                        }
                        else if (vehicleInfo.RegisterDate.AddDays(1).AddYears(1) <= vehicleMaintenanceList[i].RepairPeriod.From && vehicleMaintenanceList[i].RepairPeriod.From <= vehicleInfo.RegisterDate.AddDays(1).AddYears(2))
                        {
                            value.VehicleProfitCalDetailList[6].Year2 += vehicleMaintenanceList[i].TotalAmount;
                        }
                        else if (vehicleInfo.RegisterDate.AddDays(2).AddYears(2) <= vehicleMaintenanceList[i].RepairPeriod.From && vehicleMaintenanceList[i].RepairPeriod.From <= vehicleInfo.RegisterDate.AddDays(2).AddYears(3))
                        {
                            value.VehicleProfitCalDetailList[6].Year3 += vehicleMaintenanceList[i].TotalAmount;
                        }
                        else if (vehicleInfo.RegisterDate.AddDays(3).AddYears(3) <= vehicleMaintenanceList[i].RepairPeriod.From && vehicleMaintenanceList[i].RepairPeriod.From <= vehicleInfo.RegisterDate.AddDays(3).AddYears(4))
                        {
                            value.VehicleProfitCalDetailList[6].Year4 += vehicleMaintenanceList[i].TotalAmount;
                        }
                        else if (vehicleInfo.RegisterDate.AddDays(4).AddYears(4) <= vehicleMaintenanceList[i].RepairPeriod.From && vehicleMaintenanceList[i].RepairPeriod.From <= vehicleInfo.RegisterDate.AddDays(4).AddYears(5))
                        {
                            value.VehicleProfitCalDetailList[6].Year5 += vehicleMaintenanceList[i].TotalAmount;
                        }
                    }
                }
            }
        }

        private void UpdateValueintoDB(bool result, VehicleCalculation value)
        {
            TableAccess tableAccess = new TableAccess();
            VehicleTrInterestCostHeadDB dbCostHead = new VehicleTrInterestCostHeadDB();
            VehicleTrInterestCostDetailDB dbCostDetail = new VehicleTrInterestCostDetailDB();
            VehicleTrProfitCalculationHeadDB dbTrProfitCalHeader = new VehicleTrProfitCalculationHeadDB();
            VehicleTrProfitCalculationDetailDB dbTrProfitCalDetail = new VehicleTrProfitCalculationDetailDB();

            try
            {
                tableAccess.OpenTransaction();
                dbCostHead.TableAccess = tableAccess;
                dbCostDetail.TableAccess = tableAccess;
                dbTrProfitCalHeader.TableAccess = tableAccess;
                dbTrProfitCalDetail.TableAccess = tableAccess;

                dbCostHead.DeleteInterestCostHead();
                dbCostDetail.DeleteInterestCostDetail();

                result &= dbCostHead.InsertInterestCostHead(value.VehicleInterestCostList);
                result &= dbCostDetail.InsertInterestCostDetail(value.VehicleInterestCostList.InterestCostList);
                result &= dbTrProfitCalHeader.InsertProfitCalDetail(value);
                result &= dbTrProfitCalDetail.InsertProfitCalDetail(value.VehicleProfitCalDetailList);

                if (result)
                {
                    tableAccess.Transaction.Commit();
                }
                else
                {
                    tableAccess.Transaction.Rollback();
                }
            }
            catch (SqlException ex)
            {
                tableAccess.Transaction.Rollback();
                throw ex;
            }
            catch (Exception ex)
            {
                tableAccess.Transaction.Rollback();
                throw ex;
            }
            finally
            {
                tableAccess.CloseConnection();

                dbCostHead = null;
                dbCostDetail = null;
                dbTrProfitCalHeader = null;
                dbTrProfitCalDetail = null;
            }
        }
    }
}
