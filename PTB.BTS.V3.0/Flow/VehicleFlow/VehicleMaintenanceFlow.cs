using System;
using System.Data.SqlClient;

using Entity.CommonEntity;
using Entity.VehicleEntities;

using DataAccess.VehicleDB;

using SystemFramework.AppException;

using ictus.Common.Entity.General;

namespace PTB.BTS.Vehicle.Flow
{
	public class VehicleMaintenanceFlow : VehicleRepairingFlowBase
	{
        #region Constructor
        public VehicleMaintenanceFlow()
            : base()
        {
        } 
        #endregion

        #region Private method
        private VehicleStatus GetStatusByMaxDate(DateTime maxRepairDate, Maintenance maintenance)
        {
            VehicleStatus vStatus = new VehicleStatus();

            if (maintenance.RepairPeriod.To.Date == DateTime.Today.Date)
            {
                if (maintenance.RepairFinishStatus)
                {
                    if (maxRepairDate > DateTime.Today.Date)
                    {
                        vStatus.Code = "3";
                    }
                    else
                    {
                        vStatus.Code = "1";
                    }
                }
                else
                {
                    vStatus.Code = "3";
                }
            }
            else if (maintenance.RepairPeriod.To.Date > DateTime.Today.Date)
            {
                vStatus.Code = "3";
            }
            else
            {
                if (maxRepairDate >= DateTime.Today.Date)
                {
                    vStatus.Code = "3";
                }
                else
                {
                    vStatus.Code = "1";
                }
            }

            return vStatus;
        }
        #endregion

        #region Public method
        public bool FillVehicleMaintenance(VehicleMaintenance value)
        {
            value.Clear();
            Maintenance maintenance = new Maintenance(value.Company);
            maintenance.RepairingNo = NullConstant.STRING;
            maintenance.VehicleInfo = value.AVehicleInfo;
            maintenance.RepairingType = REPAIRING_TYPE.MAINTENANCER;
            bool result = dbVehicleRepairingHistory.FillVehicleRepairingHistoryList(ref value, maintenance);
            maintenance = null;
            return result;
        }

        public VehicleMaintenance FillVehicleMaintenance(Entity.VehicleEntities.Vehicle vehicle)
        {
            ictus.Common.Entity.Company company = new ictus.Common.Entity.Company("12");
            new PTB.BTS.PI.Flow.CompanyFlow().FillCompany(ref company);
            VehicleMaintenance maintenance = new VehicleMaintenance(company);
            dbVehicleRepairingHistory.FillVehicleRepairingHistory(ref maintenance, vehicle);
            return maintenance;
        }

        public bool InsertMaintenance(Maintenance value)
        {
            bool result = false;
            string strResult = "";
            DateTime maxDate = getMaxRepairDate(value);

            VehicleRepairingDetailDB dbVehicleRepairingDetail;
            dbVehicleRepairingDetail = new VehicleRepairingDetailDB();
            dbVehicleRepairingDetail.TableAccess = dbVehicleRepairingHistory.TableAccess;

            VehicleDB dbVehicle = new VehicleDB();
            dbVehicle.TableAccess = dbVehicleRepairingHistory.TableAccess;

            try
            {
                dbVehicleRepairingHistory.TableAccess.OpenTransaction();

                result = dbVehicleRepairingHistory.InsertVehicleRepairingHistory(value);
                if (result)
                {
                    if (result && value.ARepairSparePartsList.Count > 0)
                    {
                        result = dbVehicleRepairingDetail.InsertVehicleRepairingDetail(value);
                        if (!result)
                        {
                            strResult = @" error : InsertVehicleRepairingDetail \n function : DeleteMaintenance";
                        }
                    }
                }
                else
                {
                    strResult = @" error : InsertVehicleRepairingHistory \n function : InsertMaintenance";
                }

                if (result)
                {
                    if (value.Mileage > value.VehicleInfo.LatestMileage)
                    {
                        value.VehicleInfo.LatestMileage = value.Mileage;
                        value.VehicleInfo.LatestMileageUpdateDate = value.RepairPeriod.From.Date;
                    }

                    if (value.VehicleInfo.AVehicleStatus.Code == "1" || value.VehicleInfo.AVehicleStatus.Code == "3")
                    {                        
                        value.VehicleInfo.AVehicleStatus = GetStatusByMaxDate(maxDate, value);
                    }

                    result = dbVehicle.UpdateVehicleInfo(value.VehicleInfo, value.VehicleInfo.AKindOfVehicle, value.ARepairSparePartsList.Company);
                    if (!result)
                    {
                        strResult = @" error : UpdateVehicle \n function : InsertMaintenance";
                    }
                }

                if (result)
                {
                    dbVehicleRepairingHistory.TableAccess.Transaction.Commit();
                }
                else
                {
                    dbVehicleRepairingHistory.TableAccess.Transaction.Rollback();
                    throw new TransactionException("VehicleMaintenanceFlow", strResult);
                }
            }
            catch (SqlException ex)
            {
                dbVehicleRepairingHistory.TableAccess.Transaction.Rollback();
                throw ex;
            }
            catch (Exception ex)
            {
                dbVehicleRepairingHistory.TableAccess.Transaction.Rollback();
                throw ex;
            }
            finally
            {
                dbVehicleRepairingDetail = null;
                dbVehicle = null;
            }

            return result;
        }

        public bool UpdateMaintenance(Maintenance value)
        {
            bool result = false;
            string strResult = "";
            DateTime maxDate = getMaxRepairDate(value);

            VehicleRepairingDetailDB dbVehicleRepairingDetail;
            dbVehicleRepairingDetail = new VehicleRepairingDetailDB();
            dbVehicleRepairingDetail.TableAccess = dbVehicleRepairingHistory.TableAccess;

            VehicleDB dbVehicle = new VehicleDB();
            dbVehicle.TableAccess = dbVehicleRepairingHistory.TableAccess;

            try
            {
                dbVehicleRepairingHistory.TableAccess.OpenTransaction();

                result = dbVehicleRepairingHistory.UpdateVehicleRepairingHistory(value);
                if (result)
                {
                    dbVehicleRepairingDetail.DeleteVehicleRepairingDetail(value);
                    if (value.ARepairSparePartsList.Count > 0)
                    {
                        result = dbVehicleRepairingDetail.InsertVehicleRepairingDetail(value);
                        if (!result)
                        {
                            strResult = @" error : InsertVehicleRepairingDetail \n function : UpdateMaintenance";
                        }
                    }
                }
                else
                {
                    strResult = @" error : UpdateVehicleRepairingHistory \n function : UpdateMaintenance";
                }

                if (result)
                {
                    if (value.Mileage > value.VehicleInfo.LatestMileage)
                    {
                        value.VehicleInfo.LatestMileage = value.Mileage;
                        value.VehicleInfo.LatestMileageUpdateDate = value.RepairPeriod.From.Date;
                    }

                    if (value.VehicleInfo.AVehicleStatus.Code == "1" || value.VehicleInfo.AVehicleStatus.Code == "3")
                    {
                        value.VehicleInfo.AVehicleStatus = GetStatusByMaxDate(maxDate, value);
                    }

                    result = dbVehicle.UpdateVehicleInfo(value.VehicleInfo, value.VehicleInfo.AKindOfVehicle, value.ARepairSparePartsList.Company);
                    if (!result)
                    {
                        strResult = @" error : UpdateVehicle case 1 \n function : UpdateMaintenance";
                    }
                }

                if (result)
                {
                    dbVehicleRepairingHistory.TableAccess.Transaction.Commit();
                }
                else
                {
                    dbVehicleRepairingHistory.TableAccess.Transaction.Rollback();
                    throw new TransactionException("VehicleMaintenanceFlow", strResult);
                }
            }
            catch (SqlException ex)
            {
                dbVehicleRepairingHistory.TableAccess.Transaction.Rollback();
                throw ex;
            }
            catch (Exception ex)
            {
                dbVehicleRepairingHistory.TableAccess.Transaction.Rollback();
                throw ex;
            }
            finally
            {
                dbVehicleRepairingDetail = null;
                dbVehicle = null;
            }

            return result;
        }

        public bool DeleteMaintenance(Maintenance value)
        {
            bool result = false;
            string strResult = "";
            DateTime maxDate = getMaxRepairDate(value);

            VehicleRepairingDetailDB dbVehicleRepairingDetail = new VehicleRepairingDetailDB();
            dbVehicleRepairingDetail.TableAccess = dbVehicleRepairingHistory.TableAccess;

            VehicleDB dbVehicle = new VehicleDB();
            dbVehicle.TableAccess = dbVehicleRepairingHistory.TableAccess;

            try
            {
                dbVehicleRepairingHistory.TableAccess.OpenTransaction();

                dbVehicleRepairingDetail.DeleteVehicleRepairingDetail(value);
                result = dbVehicleRepairingHistory.DeleteVehicleRepairingHistory(value);
                if (!result)
                {
                    strResult = @" error : DeleteVehicleRepairingHistory \n function : DeleteMaintenance";
                }

                if (result)
                {
                    if (value.VehicleInfo.AVehicleStatus.Code == "1" || value.VehicleInfo.AVehicleStatus.Code == "3")
                    {
                        VehicleStatus vStatus = new VehicleStatus();

                        if (maxDate >= DateTime.Today.Date)
                        {
                            vStatus.Code = "3";
                        }
                        else
                        {
                            vStatus.Code = "1";
                        }
                        value.VehicleInfo.AVehicleStatus = vStatus;
                        vStatus = null;
                    }

                    result = dbVehicle.UpdateVehicleInfo(value.VehicleInfo, value.VehicleInfo.AKindOfVehicle, value.ARepairSparePartsList.Company);
                    if (!result)
                    {
                        strResult = @" error : UpdateVehicle \n function : DeleteMaintenance";
                    }
                }

                if (result)
                {
                    dbVehicleRepairingHistory.TableAccess.Transaction.Commit();
                }
                else
                {
                    dbVehicleRepairingHistory.TableAccess.Transaction.Rollback();
                    throw new TransactionException("VehicleMaintenanceFlow", strResult);
                }
            }
            catch (SqlException ex)
            {
                dbVehicleRepairingHistory.TableAccess.Transaction.Rollback();
                throw ex;
            }
            catch (Exception ex)
            {
                dbVehicleRepairingHistory.TableAccess.Transaction.Rollback();
                throw ex;
            }
            finally
            {
                dbVehicleRepairingDetail = null;
                dbVehicle = null;
            }

            return result;
        }
        
        #endregion
	}
}