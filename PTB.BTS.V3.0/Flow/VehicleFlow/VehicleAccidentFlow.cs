using System;
using System.Data.SqlClient;

using ictus.Common.Entity.Time;
using ictus.Common.Entity.General;
using ictus.PIS.PI.Entity;

using Entity.VehicleEntities;
using Entity.CommonEntity;

using DataAccess.VehicleDB;

using SystemFramework.AppException;

namespace PTB.BTS.Vehicle.Flow
{
	public class VehicleAccidentFlow : VehicleRepairingFlowBase
	{
		#region - Private -
		private VehicleAccidentDB dbVehicleAccident;
		#endregion

        #region Constructor
        public VehicleAccidentFlow()
            : base()
        {
            dbVehicleAccident = new VehicleAccidentDB();
        } 
        #endregion

        #region Private method
        private VehicleStatus GetStatusByMaxDate(DateTime maxRepairDate, Accident accident)
        {
            VehicleStatus vStatus = new VehicleStatus();

            if (accident.RepairPeriod.To.Date == DateTime.Today.Date)
            {
                if (accident.RepairFinishStatus)
                {
                    if (maxRepairDate > DateTime.Today.Date)
                    {
                        vStatus.Code = "2";
                    }
                    else
                    {
                        vStatus.Code = "1";
                    }
                }
                else
                {
                    vStatus.Code = "2";
                }
            }
            else if (accident.RepairPeriod.To.Date > DateTime.Today.Date)
            {
                vStatus.Code = "2";
            }
            else
            {
                if (maxRepairDate >= DateTime.Today.Date)
                {
                    vStatus.Code = "2";
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
        public bool FillVehicleAccident(VehicleAccident value)
        {
            value.Clear();
            return dbVehicleAccident.FillVehicleAccidentList(ref value);
        }

        public bool IsDuplicateWithOtherAccident(Employee employee, YearMonth yearMonth, string accidentNo)
        {
            if (yearMonth.Month == 1)
            {
                return false;
            }
            else
            {
                DriverExcessDeductionDB dbDriverExcessDeduction = new DriverExcessDeductionDB();
                bool result = dbDriverExcessDeduction.IsDuplicateWithOtherAccident(employee, yearMonth, accidentNo);
                dbDriverExcessDeduction = null;
                return result;
            }
        }

        public bool FillVehicleAccidentByYearList(VehicleAccident value, string forYear)
        {
            return dbVehicleAccident.FillVehicleAccidentByYearList(value, forYear);
        }

        public bool InsertAccident(Accident value)
        {
            bool result = false;
            string strResult = "";
            DateTime maxDate = getMaxRepairDate(value);
            dbVehicleAccident.TableAccess = dbVehicleRepairingHistory.TableAccess;

            DriverExcessDeductionDB dbDriverExcessDeduction;
            VehicleRepairingDetailDB dbVehicleRepairingDetail;

            PlaceDB dbPlace = new PlaceDB();
            dbPlace.TableAccess = dbVehicleRepairingHistory.TableAccess;
            PoliceStationDB dbPoliceStation = new PoliceStationDB();
            dbPoliceStation.TableAccess = dbVehicleRepairingHistory.TableAccess;

            VehicleDB dbVehicle = new VehicleDB();
            dbVehicle.TableAccess = dbVehicleRepairingHistory.TableAccess;

            try
            {
                dbVehicleRepairingHistory.TableAccess.OpenTransaction();

                //				------------------------------ Update Accident ------------------------------
                if (dbVehicleRepairingHistory.InsertVehicleRepairingHistory(value))
                {
                    result = dbVehicleAccident.InsertVehicleAccident(value);
                    if (!result)
                    {
                        strResult = @" error : InsertVehicleAccident \n function : InsertAccident";
                    }

                    if (result && value.ARepairSparePartsList.Count > 0)
                    {
                        dbVehicleRepairingDetail = new VehicleRepairingDetailDB();
                        dbVehicleRepairingDetail.TableAccess = dbVehicleRepairingHistory.TableAccess;
                        result = dbVehicleRepairingDetail.InsertVehicleRepairingDetail(value);
                        if (!result)
                        {
                            strResult = @" error : InsertVehicleRepairingDetail \n function : InsertAccident";
                        }
                    }

                    if (result && value.ADriverExcessDeduction.Count > 0)
                    {
                        dbDriverExcessDeduction = new DriverExcessDeductionDB();
                        dbDriverExcessDeduction.TableAccess = dbVehicleRepairingHistory.TableAccess;
                        result = dbDriverExcessDeduction.InsertDriverExcessDeduction(value.ADriverExcessDeduction);
                        if (!result)
                        {
                            strResult = @" error : InsertDriverExcessDeduction \n function : InsertAccident";
                        }
                    }
                }
                else
                {
                    strResult = @" error : InsertVehicleRepairingHistory \n function : InsertAccident";
                }

                //				------------------------------ Update MTB ------------------------------
                if (result)
                {
                    dbPlace.DeleteMTB(value.AccidentPlace);
                    dbPlace.InsertMTB(value.AccidentPlace);
                    dbPoliceStation.DeleteMTB(value.APoliceStation);
                    dbPoliceStation.InsertMTB(value.APoliceStation);
                    if (!result)
                    {
                        strResult = @" error : InsertMTB \n function : InsertAccident";
                    }
                }

                //				------------------------------ Update Vehicle ------------------------------
                if (result)
                {
                    if (value.Mileage > value.VehicleInfo.LatestMileage)
                    {
                        value.VehicleInfo.LatestMileage = value.Mileage;
                        value.VehicleInfo.LatestMileageUpdateDate = value.RepairPeriod.From.Date;
                    }

                    if (value.VehicleInfo.AVehicleStatus.Code == "1" || value.VehicleInfo.AVehicleStatus.Code == "2")
                    {
                        value.VehicleInfo.AVehicleStatus = GetStatusByMaxDate(maxDate, value);
                    }

                    result = dbVehicle.UpdateVehicleInfo(value.VehicleInfo, value.VehicleInfo.AKindOfVehicle, value.ARepairSparePartsList.Company);
                    if (!result)
                    {
                        strResult = @" error : UpdateVehicle case 1 \n function : InsertAccident";
                    }
                }

                if (result)
                {
                    dbVehicleRepairingHistory.TableAccess.Transaction.Commit();
                }
                else
                {
                    dbVehicleRepairingHistory.TableAccess.Transaction.Rollback();
                    throw new TransactionException("VehicleAccidentFlow", strResult);
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
                dbDriverExcessDeduction = null;
                dbVehicleRepairingDetail = null;

                dbPlace = null;
                dbPoliceStation = null;

                dbVehicle = null;
            }

            return result;
        }

        public bool UpdateAccident(Accident value, bool isAccident)
        {
            DateTime repairFrom = NullConstant.DATETIME;
            DateTime repairTo = NullConstant.DATETIME;
            if (value.Garage == null)
            {
                Accident accident = new Accident(value.ADriverExcessDeduction.Company);
                accident.RepairingNo = value.RepairingNo;
                if (dbVehicleAccident.FillAccident(ref accident))
                {
                    repairFrom = accident.RepairPeriod.From;
                    repairTo = accident.RepairPeriod.To;
                }
            }

            bool result = false;
            string strResult = "";

            DateTime maxDate = getMaxRepairDate(value);
            dbVehicleAccident.TableAccess = dbVehicleRepairingHistory.TableAccess;

            DriverExcessDeductionDB dbDriverExcessDeduction;
            dbDriverExcessDeduction = new DriverExcessDeductionDB();

            DriverExcessDeduction driverExcessDeduction = new DriverExcessDeduction(value.ADriverExcessDeduction.Company);
            driverExcessDeduction.AAccident = value;
            dbDriverExcessDeduction.FillDriverExcessDeduction(ref driverExcessDeduction);
            dbDriverExcessDeduction.TableAccess = dbVehicleRepairingHistory.TableAccess;

            VehicleRepairingDetailDB dbVehicleRepairingDetail;
            dbVehicleRepairingDetail = new VehicleRepairingDetailDB();
            dbVehicleRepairingDetail.TableAccess = dbVehicleRepairingHistory.TableAccess;

            PlaceDB dbPlace = new PlaceDB();
            dbPlace.TableAccess = dbVehicleRepairingHistory.TableAccess;
            PoliceStationDB dbPoliceStation = new PoliceStationDB();
            dbPoliceStation.TableAccess = dbVehicleRepairingHistory.TableAccess;

            VehicleDB dbVehicle = new VehicleDB();
            dbVehicle.TableAccess = dbVehicleRepairingHistory.TableAccess;

            try
            {
                dbVehicleRepairingHistory.TableAccess.OpenTransaction();

                //				------------------------------ Update Accident ------------------------------
                if (dbVehicleRepairingHistory.UpdateVehicleRepairingHistory(value))
                {
                    result = dbVehicleAccident.UpdateVehicleAccident(value, isAccident);
                    if (!result)
                    {
                        strResult = @" error : UpdateVehicleAccident \n function : UpdateAccident";
                    }

                    dbVehicleRepairingDetail.DeleteVehicleRepairingDetail(value);
                    if (result && value.ARepairSparePartsList.Count > 0)
                    {
                        result = dbVehicleRepairingDetail.InsertVehicleRepairingDetail(value);
                        if (!result)
                        {
                            strResult = @" error : InsertVehicleRepairingDetail \n function : UpdateAccident";
                        }
                    }

                    for (int i = 0; i < value.ADriverExcessDeduction.Count; i++)
                    {
                        if (value.ADriverExcessDeduction[i].IsPaid.Equals(true))
                        {
                            value.ADriverExcessDeduction[i].PaymentDate = driverExcessDeduction[value.ADriverExcessDeduction[i].EntityKey].PaymentDate;
                        }
                    }
                    driverExcessDeduction = null;

                    dbDriverExcessDeduction.DeleteDriverExcessDeduction(value.ADriverExcessDeduction);
                    if (result && value.ADriverExcessDeduction.Count > 0)
                    {
                        result = dbDriverExcessDeduction.InsertDriverExcessDeduction(value.ADriverExcessDeduction);
                        if (!result)
                        {
                            strResult = @" error : InsertDriverExcessDeduction \n function : UpdateAccident";
                        }
                    }
                }

                //				------------------------------ Update MTB ------------------------------
                if (result)
                {
                    dbPlace.DeleteMTB(value.AccidentPlace);
                    result = dbPlace.InsertMTB(value.AccidentPlace);
                    if (!result)
                    {
                        strResult = @" error : Insert AccidentPlace \n function : UpdateAccident";
                    }

                    dbPoliceStation.DeleteMTB(value.APoliceStation);
                    result = dbPoliceStation.InsertMTB(value.APoliceStation);
                    if (!result)
                    {
                        strResult = @" error : Insert APoliceStation \n function : UpdateAccident";
                    }
                }

                //				------------------------------ Update Vehicle ------------------------------
                if (result)
                {
                    if (value.Mileage > value.VehicleInfo.LatestMileage)
                    {
                        value.VehicleInfo.LatestMileage = value.Mileage;
                        value.VehicleInfo.LatestMileageUpdateDate = value.RepairPeriod.From.Date;
                    }

                    if (value.VehicleInfo.AVehicleStatus.Code == "1" || value.VehicleInfo.AVehicleStatus.Code == "2")
                    { 
                        value.VehicleInfo.AVehicleStatus = GetStatusByMaxDate(maxDate, value);
                    }

                    result = dbVehicle.UpdateVehicleInfo(value.VehicleInfo, value.VehicleInfo.AKindOfVehicle, value.ARepairSparePartsList.Company);
                    if (!result)
                    {
                        strResult = @" error : UpdateVehicle case 1 \n function : InsertAccident";
                    }
                }

                if (result)
                {
                    dbVehicleRepairingHistory.TableAccess.Transaction.Commit();
                }
                else
                {
                    dbVehicleRepairingHistory.TableAccess.Transaction.Rollback();
                    throw new TransactionException("VehicleAccidentFlow", strResult);
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
                dbDriverExcessDeduction = null;
                dbVehicleRepairingDetail = null;

                dbPlace = null;
                dbPoliceStation = null;

                dbVehicle = null;
            }

            return result;
        }

        public bool DeleteAccident(Accident value)
        {
            bool result = false;
            string strResult = "";
            DateTime maxDate = getMaxRepairDate(value);

            dbVehicleAccident.TableAccess = dbVehicleRepairingHistory.TableAccess;

            DriverExcessDeductionDB dbDriverExcessDeduction;
            dbDriverExcessDeduction = new DriverExcessDeductionDB();
            dbDriverExcessDeduction.TableAccess = dbVehicleRepairingHistory.TableAccess;

            VehicleRepairingDetailDB dbVehicleRepairingDetail;
            dbVehicleRepairingDetail = new VehicleRepairingDetailDB();
            dbVehicleRepairingDetail.TableAccess = dbVehicleRepairingHistory.TableAccess;

            VehicleDB dbVehicle = new VehicleDB();
            dbVehicle.TableAccess = dbVehicleRepairingHistory.TableAccess;

            try
            {
                dbVehicleRepairingHistory.TableAccess.OpenTransaction();

                dbDriverExcessDeduction.DeleteDriverExcessDeduction(value.ADriverExcessDeduction);
                dbVehicleRepairingDetail.DeleteVehicleRepairingDetail(value);

                result = dbVehicleAccident.DeleteVehicleAccident(value);
                if (!result)
                {
                    strResult = @" error : DeleteVehicleAccident \n function : DeleteAccident";
                }

                result = result && dbVehicleRepairingHistory.DeleteVehicleRepairingHistory(value);
                if (!result)
                {
                    strResult = @" error : DeleteVehicleRepairingHistory \n function : DeleteAccident";
                }

                if (result)
                {
                    if (value.VehicleInfo.AVehicleStatus.Code == "1" || value.VehicleInfo.AVehicleStatus.Code == "2")
                    {
                        VehicleStatus vStatus = new VehicleStatus();
                        if (maxDate >= DateTime.Today.Date)
                        {
                            vStatus.Code = "2";
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
                        strResult = @" error : UpdateVehicle case 1 \n function : DeleteAccident";
                    }
                }

                if (result)
                {
                    dbVehicleRepairingHistory.TableAccess.Transaction.Commit();
                }
                else
                {
                    dbVehicleRepairingHistory.TableAccess.Transaction.Rollback();
                    throw new TransactionException("VehicleAccidentFlow", strResult);
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
                dbDriverExcessDeduction = null;
                dbVehicleRepairingDetail = null;

                dbVehicle = null;
            }

            return result;
        } 
        #endregion
	}
}