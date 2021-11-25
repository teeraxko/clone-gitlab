using System;
using System.Collections.Generic;
using System.Text;
using PTB.BTS.BTS2BizPacFlow.VehicleContractChargeFlow;
using PTB.BTS.BTS2BizPacDB.BizPacImplementDB;
using PTB.BTS.BTS2BizPacFlow.VehicleDebitNoteCreateFlow;
using PTB.BTS.BTS2BizPacEntity;
using ictus.Common.Entity;
using Entity.ContractEntities;
using System.Data.SqlClient;
using DataAccess.CommonDB;
using DataAccess.ContractDB;

namespace PTB.BTS.Contract.Flow
{
    public class VehicleChargeDiffFlow : VehicleContractChargeBPFlow
    {
        private VDNCreaterManager VDNCreaterManager;

        //============================== Constructor ==============================
        public VehicleChargeDiffFlow()
            : base()
        {
            dbConnect = new ContractChargeDetailBPDB(ContractChargeDetailBPDB.CONTRACTTYPEBP.VEHICLE);
            VDNCreaterManager = new VDNCreaterManager();
            VDNCreaterManager.RefFlow = this;
        }

        //============================== Public method ==============================
        public bool GenerateChargeDiff(DateTime date, Company company)
        {
            TrVehicleChargeDifferenceDB dbVehicleDiff = new TrVehicleChargeDifferenceDB();
            bool result = false;

            try
            {               
                VehicleChargeDiff vehicleCharge;
                BTS2BizPacList listBP;
                BTS2BizPacList resultListBP;
                BTS2BizPacList resultListBTS;
                VehicleChargeDiffList listChargeCurrent = new VehicleChargeDiffList();
                VehicleChargeDiffList listChargePrevious = new VehicleChargeDiffList();

                //## Fill list current ##
                listBP = new BTS2BizPacList();
                resultListBP = new BTS2BizPacList();
                resultListBTS = new BTS2BizPacList();

                if (FillRerunBPList(listBP, date, company))
                {
                    SpecificConnect(listBP, resultListBTS, resultListBP);

                    foreach (VehicleContractChargeBP vehicleBP in resultListBTS)
                    {
                        foreach (VehicleRole vehicleRole in vehicleBP.AVehicleRoleList)
                        {
                            vehicleCharge = new VehicleChargeDiff();
                            vehicleCharge.VehicleNo = vehicleRole.AVehicle.VehicleNo;
                            vehicleCharge.CustomerCode = vehicleBP.ACustomer.Code;
                            vehicleCharge.ChargeCurrent = vehicleBP.ChargeAmount;
                            vehicleCharge.AssignCurrent = vehicleBP.APeriod;
                            vehicleCharge.AssignmentCurrentCount = 1;
                            if (vehicleRole.AVehicle.AModel != null)
                                vehicleCharge.Description = vehicleRole.AVehicle.AModel.AName.English;

                            string key = vehicleCharge.EntityKey;
                            if (listChargeCurrent.Contain(key))
                            {
                                VehicleChargeDiff tempChargeDiff = listChargeCurrent[key];
                                tempChargeDiff.ChargeCurrent += vehicleCharge.ChargeCurrent;
                                tempChargeDiff.AssignmentCurrentCount += vehicleCharge.AssignmentCurrentCount;

                                if (tempChargeDiff.AssignCurrent.To < vehicleCharge.AssignCurrent.To)
                                {
                                    tempChargeDiff.AssignCurrent = vehicleCharge.AssignCurrent;
                                }
                            }
                            else
                            {
                                listChargeCurrent.Add(vehicleCharge);
                            }
                        }
                    }
                }

                //## Fill list previous ##
                listBP = new BTS2BizPacList();
                resultListBP = new BTS2BizPacList();
                resultListBTS = new BTS2BizPacList();

                if (FillRerunBPList(listBP, date.AddMonths(-1), company))
                {
                    SpecificConnect(listBP, resultListBTS, resultListBP);

                    foreach (VehicleContractChargeBP vehicleBP in resultListBTS)
                    {
                        foreach (VehicleRole vehicleRole in vehicleBP.AVehicleRoleList)
                        {
                            vehicleCharge = new VehicleChargeDiff();
                            vehicleCharge.VehicleNo = vehicleRole.AVehicle.VehicleNo;
                            vehicleCharge.CustomerCode = vehicleBP.ACustomer.Code;
                            vehicleCharge.ChargePrevious = vehicleBP.ChargeAmount;
                            vehicleCharge.AssignPrevious = vehicleBP.APeriod;
                            vehicleCharge.AssignmentPreviousCount = 1;
                            if (vehicleRole.AVehicle.AModel != null)
                                vehicleCharge.Description = vehicleRole.AVehicle.AModel.AName.English;

                            string key = vehicleCharge.EntityKey;
                            if (listChargePrevious.Contain(key))
                            {
                                VehicleChargeDiff tempChargeDiff = listChargePrevious[key];
                                tempChargeDiff.ChargePrevious += vehicleCharge.ChargePrevious;

                                tempChargeDiff.AssignmentPreviousCount += vehicleCharge.AssignmentPreviousCount;

                                if (tempChargeDiff.AssignPrevious.To < vehicleCharge.AssignPrevious.To)
                                {
                                    tempChargeDiff.AssignPrevious = vehicleCharge.AssignPrevious;
                                }
                            }
                            else
                            {
                                listChargePrevious.Add(vehicleCharge);
                            }
                        }
                    }
                }

                //## Merge current and previous ##
                foreach (VehicleChargeDiff chargePrevious in listChargePrevious)
                {
                    string key = chargePrevious.EntityKey;
                    if (listChargeCurrent.Contain(key))
                    {
                        VehicleChargeDiff tempChargeDiff = listChargeCurrent[key];
                        tempChargeDiff.ChargePrevious = chargePrevious.ChargePrevious;
                        tempChargeDiff.AssignPrevious = chargePrevious.AssignPrevious;
                        tempChargeDiff.AssignmentPreviousCount = chargePrevious.AssignmentPreviousCount;
                    }
                    else
                    {
                        listChargeCurrent.Add(chargePrevious);
                    }
                }

                //## Execute command ##
                StringBuilder stringCommand = new StringBuilder();
                dbVehicleDiff.TableAccess.OpenTransaction();

                if (listChargeCurrent.Count > 0)
                {
                    foreach (VehicleChargeDiff vehicleChargeDiff in listChargeCurrent)
                    {
                        if (vehicleChargeDiff.ChargeDiff != decimal.Zero)
                        {
                            vehicleChargeDiff.DifferenceStatus = Entity.CommonEntity.DIFFERENCE_STATUS_TYPE.YES;
                        }
                        else if (vehicleChargeDiff.AssignCurrent.From.Date != vehicleChargeDiff.AssignPrevious.From.Date)
                        {
                            vehicleChargeDiff.DifferenceStatus = Entity.CommonEntity.DIFFERENCE_STATUS_TYPE.YES;
                        }

                        stringCommand.Append(dbVehicleDiff.CommandInsertTrVehicleChargeDifference(vehicleChargeDiff));
                    }

                    if (stringCommand.ToString() != string.Empty)
                    {
                        dbVehicleDiff.DeleteTrVehicleChargeDifference();
                        result = dbVehicleDiff.ExecuteCommand(stringCommand.ToString());
                    }
                }

                if (result)
                {
                    dbVehicleDiff.TableAccess.Transaction.Commit();
                }
                else
                {
                    dbVehicleDiff.TableAccess.Transaction.Rollback();
                }
            }
            catch (SqlException ex)
            {
                dbVehicleDiff.TableAccess.Transaction.Rollback();
                throw ex;
            }
            catch (Exception ex)
            {
                dbVehicleDiff.TableAccess.Transaction.Rollback();
                throw ex;
            }
            finally
            {
                dbVehicleDiff.TableAccess.CloseConnection();
            }

            return result;
        }
    }
}
