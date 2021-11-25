using System;
using System.Data.SqlClient;

using Entity.AttendanceEntities;
using Entity.CommonEntity;
using Entity.ContractEntities;

using ictus.Common.Entity;
using ictus.Common.Entity.Time;
using ictus.PIS.PI.Entity;

using DataAccess.ContractDB;
using DataAccess.AttendanceDB;
using DataAccess.CommonDB;
using DataAccess.PiDB;

using PTB.BTS.Common.Flow;

namespace Flow.AttendanceFlow
{
	public class GenerateOtherBenefitFlow : FlowBase
	{
		#region - Private -
		private bool disposed = false;
		private EmployeeExtraBenefitDB dbEmployeeExtraBenefit;
		private EmployeeExtraAGTBenefitDB dbEmployeeExtraAGTBenefit;
		private EmployeeTelephoneBenefitDB dbEmployeeTelephoneBenefit;		
		private EmployeeExtraAGTBenefitDeductionDB dbEmployeeExtraAGTBenefitDeduction;
		#endregion

//		============================== Constructor ==============================
		public GenerateOtherBenefitFlow() : base()
		{
			dbEmployeeExtraBenefit = new EmployeeExtraBenefitDB();
			dbEmployeeExtraAGTBenefit = new EmployeeExtraAGTBenefitDB();
			dbEmployeeTelephoneBenefit = new EmployeeTelephoneBenefitDB();
			dbEmployeeExtraAGTBenefitDeduction = new EmployeeExtraAGTBenefitDeductionDB();
		}

//		============================== Private Method ==============================

//		============================== Public Method ==============================
		public bool GenerateOtherBenefit(DateTime forDate, Company aCompany, GENERATE_TYPE genType)
		{
			bool result = true;
			YearMonth yearMonth = new YearMonth(forDate);
			TableAccess tableAccess = new TableAccess();	
		
			ServiceStaffAssignmentDB dbServiceStaffAssignment = new ServiceStaffAssignmentDB();
			TelephoneConditionDB dbTelephoneCondition = new TelephoneConditionDB();
			EmployeeTimeCardDB dbEmployeeTimeCard = new EmployeeTimeCardDB();
			OtherBenefitRateDB dbOtherBenefitRate = new OtherBenefitRateDB();
			EmployeeDB dbEmployee = new EmployeeDB();

			ServiceStaffAssignmentList objServiceStaffAssignmentList = new ServiceStaffAssignmentList(aCompany);
			TelephoneConditionList objTelephoneConditionList = new TelephoneConditionList(aCompany);
			EmployeeList objEmployeeList = new EmployeeList(aCompany);

			ExtraAGTBenefitDeduction objExtraAGTBenefitDeduction;
			ServiceStaffAssignment objServiceStaffAssignment;
			TelephoneBenefit objTelephoneBenefit;
			OtherBenefitRate objOtherBenefitRate;
			EmployeeTimeCard objEmployeeTimeCard;
			ExtraAGTBenefit objExtraAGTBenefit;
			ExtraBenefit objExtraBenefit;
			Employee objEmployeeMain;			
			
			try
			{
				tableAccess.OpenTransaction();
				dbEmployeeTelephoneBenefit.TableAccess = tableAccess;
				dbEmployeeExtraBenefit.TableAccess = tableAccess;

				//Get_OtherBenefitRate
				objOtherBenefitRate = new OtherBenefitRate();
				dbOtherBenefitRate.FillOtherBenefitRate(ref objOtherBenefitRate, aCompany);

				if(dbTelephoneCondition.FillTelephoneConditionList(ref objTelephoneConditionList))
				{
					//Gen_Telephone
					for(int i=0; i<objTelephoneConditionList.Count; i++)
					{
						objTelephoneBenefit = new TelephoneBenefit();
						objTelephoneBenefit.AYearMonth = yearMonth;
						objTelephoneBenefit.TotalAmount = objTelephoneConditionList[i].TelephoneRate;
						objTelephoneBenefit.ABenefitPayment.PaymentStatus = PAYMENT_STATUS_TYPE.NO;

						if(genType == GENERATE_TYPE.TELEPHONE || genType == GENERATE_TYPE.OTHER)
						{
							dbEmployeeTelephoneBenefit.DeleteTelephoneBenefit(objTelephoneBenefit, objTelephoneConditionList[i].AEmployee);
							result &= dbEmployeeTelephoneBenefit.InsertTelephoneBenefit(objTelephoneBenefit, objTelephoneConditionList[i].AEmployee);
						}
					}
				}
				
				if(dbServiceStaffAssignment.FillServiceStaffAssignmentInPeriodList(ref objServiceStaffAssignmentList, yearMonth))
				{						
					for(int i=0; i<objServiceStaffAssignmentList.Count; i++)
					{
						objServiceStaffAssignment = new ServiceStaffAssignment();
						objEmployeeMain = new Employee(aCompany);
						objServiceStaffAssignment = objServiceStaffAssignmentList[i];
						objEmployeeMain = objServiceStaffAssignment.AMainServiceStaff;

						if(objServiceStaffAssignment.AContract != null && objServiceStaffAssignment.AContract.ACustomer.Code == "AAAAA" && objServiceStaffAssignment.AMainServiceStaff.AServiceStaffType.Type == "281")
						{
							objEmployeeTimeCard = new EmployeeTimeCard(objEmployeeMain, yearMonth);
							if(dbEmployeeTimeCard.FillTimeCardBenefitList(ref objEmployeeTimeCard))
							{	
								//Gen_AGTBenefit
								ExtraAGTBenefit tempExtraAGTBenefit = new ExtraAGTBenefit();
								tempExtraAGTBenefit = dbEmployeeExtraAGTBenefit.GetExtraAGTBenefit(yearMonth, objEmployeeMain);
								
								objExtraAGTBenefit = new ExtraAGTBenefit();
								objExtraAGTBenefit.AYearMonth = yearMonth;
								objExtraAGTBenefit.TotalAmount = objOtherBenefitRate.ExtraAGTRate;
								objExtraAGTBenefit.DaysDeduction = objEmployeeTimeCard.Count;
								objExtraAGTBenefit.DeductionAmountPerDay = objOtherBenefitRate.DeductionAGTPerDay;
								objExtraAGTBenefit.TotalDeductionAmount = objOtherBenefitRate.ExtraAGTRate - (objOtherBenefitRate.DeductionAGTPerDay * objEmployeeTimeCard.Count);
								objExtraAGTBenefit.ABenefitPayment.PaymentStatus = PAYMENT_STATUS_TYPE.NO;

								dbEmployeeExtraAGTBenefit.TableAccess = tableAccess;
								dbEmployeeExtraAGTBenefitDeduction.TableAccess = tableAccess;

								if(genType == GENERATE_TYPE.OTHER)
								{
									if(tempExtraAGTBenefit == null)
									{
										result &= dbEmployeeExtraAGTBenefit.InsertExtraAGTBenefit(objExtraAGTBenefit, objEmployeeMain);
									}
									else
									{
										result &= dbEmployeeExtraAGTBenefit.UpdateExtraAGTBenefit(objExtraAGTBenefit, objEmployeeMain);
									}
								}
								tempExtraAGTBenefit = null;
							}
							
							for(int j=0; j<objEmployeeTimeCard.Count; j++)
							{
								if(objServiceStaffAssignment.APeriod.From <= objEmployeeTimeCard[j].CardDate && objEmployeeTimeCard[j].CardDate <= objServiceStaffAssignment.APeriod.To)
								{
									//Gen_AGTBenefitDeduction
									objExtraAGTBenefitDeduction = new ExtraAGTBenefitDeduction();
									objExtraAGTBenefitDeduction.AYearMonth = yearMonth;
									objExtraAGTBenefitDeduction.BenefitDate = objEmployeeTimeCard[j].CardDate;
									

									if(objServiceStaffAssignment.AAssignedServiceStaff.EmployeeNo != objServiceStaffAssignment.AMainServiceStaff.EmployeeNo)
									{
										objExtraAGTBenefitDeduction.AEmployee = objServiceStaffAssignment.AAssignedServiceStaff;
										objExtraAGTBenefitDeduction.TotalAmount = objOtherBenefitRate.ExtraAGTRate;
									}
									else
									{
										objExtraAGTBenefitDeduction.AEmployee = new Employee(aCompany);
										objExtraAGTBenefitDeduction.TotalAmount = 0;
									}

									if(genType == GENERATE_TYPE.OTHER)
									{
										dbEmployeeExtraAGTBenefitDeduction.DeleteExtraAGTBenefitDeduction(objExtraAGTBenefitDeduction, objEmployeeMain);
										result &= dbEmployeeExtraAGTBenefitDeduction.InsertExtraAGTBenefitDeduction(objExtraAGTBenefitDeduction, objEmployeeMain);
									}
								}
							}
						}	

						//Gen_ExtraBenefit
						if(objServiceStaffAssignment.AContract != null && objServiceStaffAssignment.AContract.ACustomer.Code != "AAAAA" && objServiceStaffAssignment.AMainServiceStaff.AServiceStaffType.Type == "281")
						{
							objExtraBenefit = new ExtraBenefit();
							objExtraBenefit.AYearMonth = yearMonth;
							objExtraBenefit.TotalAmount = objOtherBenefitRate.ExtraRate;

							objEmployeeTimeCard = new EmployeeTimeCard(objEmployeeMain, yearMonth);
							if(dbEmployeeTimeCard.FillTimeCardBenefitList(ref objEmployeeTimeCard))
							{							
								objExtraBenefit.TotalAmount = 0;
							}

							if(genType == GENERATE_TYPE.EXTRA || genType == GENERATE_TYPE.OTHER)
							{
								dbEmployeeExtraBenefit.DeleteExtraBenefit(objExtraBenefit, objEmployeeMain);
								result &= dbEmployeeExtraBenefit.InsertExtraBenefit(objExtraBenefit, objEmployeeMain);					
							}
						}
					}					
				}

				if(result)
				{
					tableAccess.Transaction.Commit();
				}
				else
				{
					tableAccess.Transaction.Rollback();
				}
			}
			catch(SqlException ex)
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
			}

			return result;
		}

		public DateTime RetriveDate(DateTime value, Company aCompany, double countDay)
		{
			TraditionalHolidayDB dbTraditionalHoliday = new TraditionalHolidayDB();
			TraditionalHoliday objTraditionalHoliday = new TraditionalHoliday();
			objTraditionalHoliday.HolidayDate = value;

			while(	value.DayOfWeek == DayOfWeek.Saturday || value.DayOfWeek == DayOfWeek.Sunday || 
					(dbTraditionalHoliday.FillTraditionalHoliday(ref objTraditionalHoliday, aCompany)
					&& objTraditionalHoliday.ATraditionalHolidayPattern.Code == "01")
				 )
			{
				value = value.AddDays(countDay);
				objTraditionalHoliday.HolidayDate = value;
			}			

			objTraditionalHoliday = null;
			dbTraditionalHoliday = null;

			return value;
		}

		#region IDisposable Members
		protected override void Dispose(bool disposing)
		{
			if(!this.disposed)
			{
				try
				{
					if(disposing)
					{
						dbEmployeeExtraBenefit = null;
						dbEmployeeExtraAGTBenefit = null;
						dbEmployeeTelephoneBenefit = null;
						dbEmployeeExtraAGTBenefitDeduction = null;

						dbEmployeeExtraBenefit.Dispose();
						dbEmployeeExtraAGTBenefit.Dispose();
						dbEmployeeTelephoneBenefit.Dispose();
						dbEmployeeExtraAGTBenefitDeduction.Dispose();
					}
					this.disposed = true;
				}
				finally
				{
					base.Dispose(disposing);
				}
			}
		}
		#endregion
	}
}

#region - Old data -
//		public bool GenerateOtherBenefit(DateTime forDate, Company aCompany)
//		{
//			bool result = true;
//			YearMonth yearMonth = new YearMonth(forDate);
//			TableAccess tableAccess = new TableAccess();	
//		
//			ServiceStaffAssignmentDB dbServiceStaffAssignment = new ServiceStaffAssignmentDB();
//			TelephoneConditionDB dbTelephoneCondition = new TelephoneConditionDB();
//			EmployeeTimeCardDB dbEmployeeTimeCard = new EmployeeTimeCardDB();
//			OtherBenefitRateDB dbOtherBenefitRate = new OtherBenefitRateDB();
//			EmployeeDB dbEmployee = new EmployeeDB();
//
//			ServiceStaffAssignmentList objServiceStaffAssignmentList = new ServiceStaffAssignmentList(aCompany);
//			TelephoneConditionList objTelephoneConditionList = new TelephoneConditionList(aCompany);
//			EmployeeList objEmployeeList = new EmployeeList(aCompany);
//
//			ExtraAGTBenefitDeduction objExtraAGTBenefitDeduction;
//			ServiceStaffAssignment objServiceStaffAssignment;
//			TelephoneBenefit objTelephoneBenefit;
//			OtherBenefitRate objOtherBenefitRate;
//			EmployeeTimeCard objEmployeeTimeCard;
//			ExtraAGTBenefit objExtraAGTBenefit;
//			ExtraBenefit objExtraBenefit;
//			Employee objEmployeeMain;			
//			
//			try
//			{
//				tableAccess.OpenTransaction();
//				dbEmployeeTelephoneBenefit.TableAccess = tableAccess;
//				dbEmployeeExtraBenefit.TableAccess = tableAccess;
//
//				//Get_OtherBenefitRate
//				objOtherBenefitRate = new OtherBenefitRate();
//				dbOtherBenefitRate.FillOtherBenefitRate(ref objOtherBenefitRate, aCompany);
//
//				if(dbTelephoneCondition.FillTelephoneConditionList(ref objTelephoneConditionList))
//				{
//					//Gen_Telephone
//					for(int i=0; i<objTelephoneConditionList.Count; i++)
//					{
//						objTelephoneBenefit = new TelephoneBenefit();
//						objTelephoneBenefit.AYearMonth = yearMonth;
//						objTelephoneBenefit.TotalAmount = objTelephoneConditionList[i].TelephoneRate;
//						objTelephoneBenefit.ABenefitPayment.PaymentStatus = PAYMENT_STATUS_TYPE.NO;
//
//						dbEmployeeTelephoneBenefit.DeleteTelephoneBenefit(objTelephoneBenefit, objTelephoneConditionList[i].AEmployee);
//						result &= dbEmployeeTelephoneBenefit.InsertTelephoneBenefit(objTelephoneBenefit, objTelephoneConditionList[i].AEmployee);
//					}
//				}
//
//				if(dbEmployee.FillEmployeeList(ref objEmployeeList))
//				{					
//					if(dbServiceStaffAssignment.FillServiceStaffAssignmentInPeriodList(ref objServiceStaffAssignmentList, yearMonth))
//					{						
//						for(int i=0; i<objServiceStaffAssignmentList.Count; i++)
//						{
//							objServiceStaffAssignment = new ServiceStaffAssignment();
//							objEmployeeMain = new Employee(aCompany);
//							objServiceStaffAssignment = objServiceStaffAssignmentList[i];
//							objEmployeeMain = objServiceStaffAssignment.AMainServiceStaff;
//
//							if(objServiceStaffAssignment.AContract != null && objServiceStaffAssignment.AContract.ACustomer.Code == "AAAAA" && objServiceStaffAssignment.AMainServiceStaff.AServiceStaffType.Type == "281")
//							{
//								objEmployeeList.Remove(objEmployeeMain);
//
//								objEmployeeTimeCard = new EmployeeTimeCard(objEmployeeMain, yearMonth);
//								if(dbEmployeeTimeCard.FillTimeCardBenefitList(ref objEmployeeTimeCard))
//								{	
//									//Gen_AGTBenefit
//									objExtraAGTBenefit = new ExtraAGTBenefit();
//									objExtraAGTBenefit.AYearMonth = yearMonth;
//									objExtraAGTBenefit.TotalAmount = objOtherBenefitRate.ExtraAGTRate;
//									objExtraAGTBenefit.DaysDeduction = objEmployeeTimeCard.Count;
//									objExtraAGTBenefit.DeductionAmountPerDay = objOtherBenefitRate.DeductionAGTPerDay;
//									objExtraAGTBenefit.TotalDeductionAmount = objOtherBenefitRate.ExtraAGTRate - (objOtherBenefitRate.DeductionAGTPerDay * objEmployeeTimeCard.Count);
//									objExtraAGTBenefit.ABenefitPayment.PaymentStatus = PAYMENT_STATUS_TYPE.NO;
//
//									dbEmployeeExtraAGTBenefit.DeleteExtraAGTBenefit(objExtraAGTBenefit, objEmployeeMain);
//									result &= dbEmployeeExtraAGTBenefit.InsertExtraAGTBenefit(objExtraAGTBenefit, objEmployeeMain);
//								}
//								
//								for(int j=0; j<objEmployeeTimeCard.Count; j++)
//								{
//									if(objServiceStaffAssignment.APeriod.From <= objEmployeeTimeCard[j].CardDate && objEmployeeTimeCard[j].CardDate <= objServiceStaffAssignment.APeriod.To)
//									{
//										//Gen_AGTBenefitDeduction
//										objExtraAGTBenefitDeduction = new ExtraAGTBenefitDeduction();
//										objExtraAGTBenefitDeduction.AYearMonth = yearMonth;
//										objExtraAGTBenefitDeduction.BenefitDate = objEmployeeTimeCard[j].CardDate;
//										
//
//										if(objServiceStaffAssignment.AAssignedServiceStaff.EmployeeNo != objServiceStaffAssignment.AMainServiceStaff.EmployeeNo)
//										{
//											objExtraAGTBenefitDeduction.AEmployee = objServiceStaffAssignment.AAssignedServiceStaff;
//											objExtraAGTBenefitDeduction.TotalAmount = objOtherBenefitRate.ExtraAGTRate;
//										}
//										else
//										{
//											objExtraAGTBenefitDeduction.AEmployee = new Employee(aCompany);
//											objExtraAGTBenefitDeduction.TotalAmount = 0;
//										}
//
//										dbEmployeeExtraAGTBenefitDeduction.DeleteExtraAGTBenefitDeduction(objExtraAGTBenefitDeduction, objEmployeeMain);
//										result &= dbEmployeeExtraAGTBenefitDeduction.InsertExtraAGTBenefitDeduction(objExtraAGTBenefitDeduction, objEmployeeMain);
//									}
//								}
//							}							
//						}
//					}
//
//					//Gen_ExtraBenefit
//					for(int i=0; i<objEmployeeList.Count; i++)
//					{
//						objExtraBenefit = new ExtraBenefit();
//						objExtraBenefit.AYearMonth = yearMonth;
//						objExtraBenefit.TotalAmount = objOtherBenefitRate.ExtraRate;
//
//						objEmployeeTimeCard = new EmployeeTimeCard(objEmployeeList[i], yearMonth);
//						if(dbEmployeeTimeCard.FillTimeCardBenefitList(ref objEmployeeTimeCard))
//						{							
//							objExtraBenefit.TotalAmount = 0;
//						}
//
//						dbEmployeeExtraBenefit.DeleteExtraBenefit(objExtraBenefit, objEmployeeList[i]);
//						result &= dbEmployeeExtraBenefit.InsertExtraBenefit(objExtraBenefit, objEmployeeList[i]);					
//					}
//				}
//
//				if(result)
//				{
//					tableAccess.Transaction.Commit();
//				}
//				else
//				{
//					tableAccess.Transaction.Rollback();
//				}
//			}
//			catch(SqlException ex)
//			{
//				tableAccess.Transaction.Rollback();
//				throw ex;
//			}
//			finally
//			{
//				tableAccess.Close();
//			}
//
//			return result;
//		}
#endregion
