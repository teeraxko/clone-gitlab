using System;
using System.Data.SqlClient;

using ictus.PIS.PI.Entity;

using DataAccess.CommonDB;

namespace DataAccess.PiDB
{
	public class FormerTransactionDB : PITransactionBase
	{
		#region - Private -
		private FormerEmployeeDB dbFormerEmployee;
		private FormerEmployeeParentDB dbFormerEmployeeParent;
		private FormerEmployeeReferencePersonDB dbFormerEmployeeReferencePerson;
		private FormerEmployeeGuarantorDB dbFormerEmployeeGuarantor;
		private FormerEmployeeSalaryDB dbFormerEmployeeSalary;
		private FormerEmployeeAddressDB dbFormerEmployeeAddress;
		private FormerEmployeeSpouseDB dbFormerEmployeeSpouse;
		private FormerEmployeeEducationDB dbFormerEmployeeEducation;
		private FormerEmployeeWorkBackgroundDB dbFormerEmployeeWorkBackground;
		private FormerEmployeeChildrenDB dbFormerEmployeeChildren;
		private FormerEmployeeSpecialAllowanceDB  dbFormerEmployeeSpecialAllowance;
		#endregion

//		============================== Constructor ==============================
        public FormerTransactionDB(ictus.Common.Entity.Company value)
            : base()
		{
			ReNew(value);
			dbFormerEmployee = new FormerEmployeeDB();
			dbFormerEmployeeEducation = new FormerEmployeeEducationDB();
			dbFormerEmployeeAddress = new FormerEmployeeAddressDB();
			dbFormerEmployeeParent = new FormerEmployeeParentDB();
			dbFormerEmployeeReferencePerson = new FormerEmployeeReferencePersonDB();
			dbFormerEmployeeGuarantor = new FormerEmployeeGuarantorDB();
			dbFormerEmployeeSalary = new FormerEmployeeSalaryDB();
			dbFormerEmployeeSpouse = new FormerEmployeeSpouseDB();
			dbFormerEmployeeWorkBackground = new FormerEmployeeWorkBackgroundDB();
			dbFormerEmployeeChildren = new FormerEmployeeChildrenDB();
			dbFormerEmployeeSpecialAllowance = new FormerEmployeeSpecialAllowanceDB();
		}

//		============================== Private Method ==============================
		#region - Private - 
			private void setTableAccess(TableAccess value)
			{
				dbFormerEmployee.TableAccess = value;
				dbFormerEmployeeEducation.TableAccess = value;
				dbFormerEmployeeAddress.TableAccess = value;
				dbFormerEmployeeParent.TableAccess = value;
				dbFormerEmployeeReferencePerson.TableAccess = value;
				dbFormerEmployeeGuarantor.TableAccess = value;
				dbFormerEmployeeSalary.TableAccess = value;
				dbFormerEmployeeSpouse.TableAccess = value;
				dbFormerEmployeeWorkBackground.TableAccess = value;
				dbFormerEmployeeChildren.TableAccess = value;
				dbFormerEmployeeSpecialAllowance.TableAccess = value;
			}
		#endregion

//		============================== Public Method ==============================
		public override bool FillList()
		{
			if(dbFormerEmployee.FillFormerEmployeeInfo(ref aEmployeeInfo))
			{
				FillList(aEmployeeInfo);
				return true;
			}		
			else 
			{return false;}			
		}

		public override void FillList(Employee value)
		{
			dbFormerEmployeeAddress.FillFormerEmployeeAddress(ref aEmployeeAddress);
			dbFormerEmployeeParent.FillFormerEmployeeParent(ref aEmployeeFather, ref aEmployeeMother, value);
			dbFormerEmployeeReferencePerson.FillFormerEmployeeReferencePerson(ref aReferencePerson, value);
			dbFormerEmployeeGuarantor.FillFormerEmployeeGuarantor(ref aGuarantor, value);
			dbFormerEmployeeSalary.FillFormerEmployeeSalary(ref aSalary, value);
			dbFormerEmployeeSpouse.FillFormerEmployeeSpouse(ref aEmployeeSpouse);

			dbFormerEmployeeEducation.FillFormerEmployeeEducationList(ref aEmployeeEducation);
			dbFormerEmployeeWorkBackground.FillFormerEmployeeWorkBackgroundList(ref aEmployeeWorkBackground);
			dbFormerEmployeeChildren.FillFormerEmployeeChildrenList(ref aEmployeeChildrenList);
			dbFormerEmployeeSpecialAllowance.FillFormerEmployeeSpecialAllowanceList(ref aEmployeeSpecialAllowance);		
		}

		public override bool InsertTransaction(TableAccess tableAccess)
		{
			setTableAccess(tableAccess);
			if(IsNotNULL(aEmployeeInfo.EmployeeNo))
			{
				dbFormerEmployee.InsertFormerEmployee(aEmployeeInfo);
						
				if(aEmployeeFather.IsNotNull && aEmployeeMother.IsNotNull)
				{
					dbFormerEmployeeParent.InsertFormerEmployeeParent(aEmployeeFather, aEmployeeMother, aEmployeeInfo);
				}
				if(IsNotNULL(aReferencePerson.AName.Thai))
				{
					dbFormerEmployeeReferencePerson.InsertFormerEmployeeReferencePerson(aReferencePerson, aEmployeeInfo);
				}
				if(IsNotNULL(aGuarantor.AName.Thai))
				{
					dbFormerEmployeeGuarantor.InsertFormerEmployeeGuarantor(aGuarantor, aEmployeeInfo);
				}
				if(aSalary.IsNotNULL)
				{
					dbFormerEmployeeSalary.InsertFormerEmployeeSalary(aSalary, aEmployeeInfo);
				}
				if(aEmployeeAddress.IsNotNull)
				{
					dbFormerEmployeeAddress.InsertFormerEmployeeAddress(aEmployeeAddress);
				}
				if(aEmployeeSpouse.IsNotNull)
				{
					dbFormerEmployeeSpouse.InsertFormerEmployeeSpouse(aEmployeeSpouse);
				}
				if(IsNotNULL(aEmployeeEducation))
				{
					dbFormerEmployeeEducation.MaintainFormerEmployeeEducation(aEmployeeEducation);
				}
				if(IsNotNULL(aEmployeeWorkBackground))
				{
					dbFormerEmployeeWorkBackground.MaintainFormerEmployeeWorkBackground(aEmployeeWorkBackground);
				}
				if(IsNotNULL(aEmployeeChildrenList))
				{
					dbFormerEmployeeChildren.MaintainFormerEmployeeChildren(aEmployeeChildrenList);
				}
				if(IsNotNULL(aEmployeeSpecialAllowance))
				{
					dbFormerEmployeeSpecialAllowance.MaintainFormerEmployeeSpecialAllowance(aEmployeeSpecialAllowance);
				}
			}
			return true;
		}

		public override bool UpdateTransaction(TableAccess tableAccess)
		{
			return false;
		}

		public override bool DeleteTransaction(TableAccess tableAccess)
		{
			return false;
		}

		#region - Old Data -
		#region - Property FillChange -
//		private bool employeeFillChange = false;
//		public bool EmployeeFillChange
//		{
//			set{employeeFillChange = value;}
//			get{return employeeFillChange;}
//		}
//		private bool employeeParentFillChange = false;
//		public bool EmployeeParentFillChange
//		{
//			set{employeeParentFillChange = value;}
//			get{return employeeParentFillChange;}
//		}
//		private bool referencePersonFillChange = false;
//		public bool ReferencePersonFillChange
//		{
//			set{referencePersonFillChange = value;}
//			get{return referencePersonFillChange;}
//		}
//		private bool guarantorFillChange = false;
//		public bool GuarantorFillChange
//		{
//			set{guarantorFillChange = value;}
//			get{return guarantorFillChange;}
//		}
//		private bool employeeAddressFillChange = false;
//		public bool EmployeeAddressFillChange
//		{
//			set{employeeAddressFillChange = value;}
//			get{return employeeAddressFillChange;}
//		}
//		private bool employeeSpouseFillChange = false;
//		public bool EmployeeSpouseFillChange
//		{
//			set{employeeSpouseFillChange = value;}
//			get{return employeeSpouseFillChange;}
//		}
//		private bool employeeWorkBackgroundFillChange = false;
//		public bool EmployeeWorkBackgroundFillChange
//		{
//			set{employeeWorkBackgroundFillChange = value;}
//			get{return employeeWorkBackgroundFillChange;}
//		}
//		private bool employeeChildrenListFillChange = false;
//		public bool EmployeeChildrenListFillChange
//		{
//			set{employeeChildrenListFillChange = value;}
//			get{return employeeChildrenListFillChange;}
//		}
//		private bool employeeEducationFillChange = false;
//		public bool EmployeeEducationFillChange
//		{
//			set{employeeEducationFillChange = value;}
//			get{return employeeEducationFillChange;}
//		}
//		private bool salaryFillChange = false;
//		public bool SalaryFillChange
//		{
//			set{salaryFillChange = value;}
//			get{return salaryFillChange;}
//		}
//		private bool employeeSpecialAllowanceFillChange = false;
//		public bool EmployeeSpecialAllowanceFillChange
//		{
//			set{employeeSpecialAllowanceFillChange = value;}
//			get{return employeeSpecialAllowanceFillChange;}
//		}
		#endregion

		#region - Delete - 
	//		public override bool DeleteTransaction()
	//		{
	////			bool result;
	////			SqlTransaction transaction = tableAccess.GetTransaction();
	////						
	////			try
	////			{
	////				if(IsNotNULL(aEmployee.EmployeeNo))
	////				{					
	////					if((IsNotNULL(aEmployeeFather.AEmployee.EmployeeNo)) && (IsNotNULL(aEmployeeMother.AEmployee.EmployeeNo)))
	////					{
	////						dbFormerEmployeeParent.DeleteFormerEmployeeParent(aEmployeeFather, aEmployeeMother, aEmployee, transaction);				
	////					}
	////					if(IsNotNULL(aReferencePerson.AName.Thai))
	////					{
	////						dbFormerEmployeeReferencePerson.DeleteFormerEmployeeReferencePerson(aReferencePerson, aEmployee, transaction);
	////					}
	////					if(IsNotNULL(aGuarantor.AName.Thai))
	////					{
	////						dbFormerEmployeeGuarantor.DeleteFormerEmployeeGuarantor(aGuarantor, aEmployee, transaction);
	////					}
	////					if(aSalary != null)
	////					{
	////						dbFormerEmployeeSalary.DeleteFormerEmployeeSalary(aSalary, aEmployee, transaction);
	////					}
	////					if(IsNotNULL(aEmployeeAddress.AEmployee.EmployeeNo))
	////					{
	////						dbFormerEmployeeAddress.DeleteFormerEmployeeAddress(aEmployeeAddress, transaction);
	////					}
	////					if(IsNotNULL(aEmployeeSpouse.AEmployee.EmployeeNo))
	////					{
	////						dbFormerEmployeeSpouse.DeleteFormerEmployeeSpouse(aEmployeeSpouse, transaction);
	////					}
	////					if(IsNotNULL(aEmployeeEducation))
	////					{
	////						dbFormerEmployeeEducation.MaintainFormerEmployeeEducation(aEmployeeEducation, transaction);
	////					}
	////					if(IsNotNULL(aEmployeeWorkBackground))
	////					{
	////						dbFormerEmployeeWorkBackground.MaintainFormerEmployeeWorkBackground(aEmployeeWorkBackground, transaction);
	////					}
	////					if(IsNotNULL(aEmployeeChildrenList))
	////					{
	////						dbFormerEmployeeChildren.MaintainFormerEmployeeChildren(aEmployeeChildrenList, transaction);
	////					}
	////					if(IsNotNULL(aEmployeeSpecialAllowance))
	////					{
	////						dbFormerEmployeeSpecialAllowance.MaintainFormerEmployeeSpecialAllowance(aEmployeeSpecialAllowance, transaction);
	////					}
	////
	////					dbFormerEmployee.DeleteFormerEmployee(aEmployee, transaction);				
	////				}
	////				transaction.Commit();
	////				result = true;
	////			}
	////			catch(SqlException sqlEx)
	////			{
	////				string errorMessage = sqlEx.Message;
	////				transaction.Rollback();
	////				result = false;
	////			}
	////			finally 
	////			{
	////				tableAccess.Close();
	////			}
	//
	//			return false;
	//		}
		#endregion

		#region - Update -
//		public override bool UpdateTransaction(TableAccess tableAccess)
//		{
//			setTableAccess(tableAccess);
//			if(IsNotNULL(aEmployee.EmployeeNo))
//			{
//				if (employeeChange)
//				{
//					dbFormerEmployee.UpdateFormerEmployee(aEmployee);
//				}					
//				if(employeeParentChange)
//				{
//					dbFormerEmployeeParent.UpdateFormerEmployeeParent(aEmployeeFather, aEmployeeMother, aEmployee);
//				}
//				if(referencePersonChange && IsNotNULL(aReferencePerson.AName.Thai))
//				{
//					dbFormerEmployeeReferencePerson.UpdateFormerEmployeeReferencePerson(aReferencePerson, aEmployee);
//				}
//				if(guarantorChange && IsNotNULL(aGuarantor.AName.Thai))
//				{
//					dbFormerEmployeeGuarantor.UpdateFormerEmployeeGuarantor(aGuarantor, aEmployee);
//				}
//				if(salaryChange && (aSalary != null))
//				{
//					dbFormerEmployeeSalary.UpdateFormerEmployeeSalary(aSalary, aEmployee);
//				}
//				if(employeeAddressChange)
//				{
//					dbFormerEmployeeAddress.UpdateFormerEmployeeAddress(aEmployeeAddress);
//				}
//				if(employeeSpouseChange)
//				{
//					dbFormerEmployeeSpouse.UpdateFormerEmployeeSpouse(aEmployeeSpouse);
//				}
//				if(employeeEducationChange && IsNotNULL(aEmployeeEducation))
//				{
//					dbFormerEmployeeEducation.MaintainFormerEmployeeEducation(aEmployeeEducation);
//				}
//				if(employeeWorkBackgroundChange && IsNotNULL(aEmployeeWorkBackground))
//				{
//					dbFormerEmployeeWorkBackground.MaintainFormerEmployeeWorkBackground(aEmployeeWorkBackground);
//				}
//				if(employeeChildrenListChange && IsNotNULL(aEmployeeChildrenList))
//				{
//					dbFormerEmployeeChildren.MaintainFormerEmployeeChildren(aEmployeeChildrenList);
//				}
//				if(employeeSpecialAllowanceChange && IsNotNULL(aEmployeeSpecialAllowance))
//				{
//					dbFormerEmployeeSpecialAllowance.MaintainFormerEmployeeSpecialAllowance(aEmployeeSpecialAllowance);
//				}
//			}
//			return false;
//		}
		#endregion
		#endregion

	}
}
