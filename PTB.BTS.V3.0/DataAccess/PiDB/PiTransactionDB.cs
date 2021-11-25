using System;
using System.Data.SqlClient;

using ictus.PIS.PI.Entity;

using DataAccess.CommonDB;


using SystemFramework.AppException;

using ictus.Common.Entity;

namespace DataAccess.PiDB
{
	public class PiTransactionDB : PITransactionBase
	{
		#region - private -
		private EmployeeDB dbEmployee;
		private EmployeeParentDB dbEmployeeParent;
		private EmployeeReferencePersonDB dbEmployeeReferencePerson;
		private EmployeeGuarantorDB dbEmployeeGuarantor;
		private EmployeeSalaryDB dbEmployeeSalary;
		private EmployeeAddressDB dbEmployeeAddress;
		private EmployeeSpouseDB dbEmployeeSpouse;
		private EmployeeEducationDB dbEmployeeEducation;
		private EmployeeWorkBackgroundDB dbEmployeeWorkBackground;
		private EmployeeChildrenDB dbEmployeeChildren;
		private EmployeeSpecialAllowanceDB  dbEmployeeSpecialAllowance;
		#endregion

//		============================== Constructor ==============================
		public PiTransactionDB(Company value) : base()
		{
			ReNew(value);
			dbEmployee = new EmployeeDB();
			dbEmployeeEducation = new EmployeeEducationDB();
			dbEmployeeAddress = new EmployeeAddressDB();
			dbEmployeeParent = new EmployeeParentDB();
			dbEmployeeReferencePerson = new EmployeeReferencePersonDB();
			dbEmployeeGuarantor = new EmployeeGuarantorDB();
			dbEmployeeSalary = new EmployeeSalaryDB();
			dbEmployeeSpouse = new EmployeeSpouseDB();
			dbEmployeeWorkBackground = new EmployeeWorkBackgroundDB();
			dbEmployeeChildren = new EmployeeChildrenDB();
			dbEmployeeSpecialAllowance = new EmployeeSpecialAllowanceDB();
		}

//		============================== private Method ==============================
		#region - private Method - 
			private void setTableAccess(TableAccess value)
			{
				dbEmployee.TableAccess = value;
				dbEmployeeEducation.TableAccess = value;
				dbEmployeeAddress.TableAccess = value;
				dbEmployeeParent.TableAccess = value;
				dbEmployeeReferencePerson.TableAccess = value;
				dbEmployeeGuarantor.TableAccess = value;
				dbEmployeeSalary.TableAccess = value;
				dbEmployeeSpouse.TableAccess = value;
				dbEmployeeWorkBackground.TableAccess = value;
				dbEmployeeChildren.TableAccess = value;
				dbEmployeeSpecialAllowance.TableAccess = value;
			}
		#endregion

//		============================== Public Method ==============================
		public override bool FillList()
		{
			if(dbEmployee.FillAllEmployeeInfo(ref aEmployeeInfo))
			{
				FillList(aEmployeeInfo);
				return true;
			}		
			else 
			{
				throw new EmpNotFoundException(aEmployeeInfo.EmployeeNo);
//				return false;
			}			
		}

		public override void FillList(Employee value)
		{
			dbEmployeeAddress.FillEmployeeAddress(ref aEmployeeAddress);
			dbEmployeeParent.FillEmployeeParent(ref aEmployeeFather, ref aEmployeeMother, aEmployeeInfo);
			dbEmployeeReferencePerson.FillEmployeeReferencePerson(ref aReferencePerson, aEmployeeInfo);
			dbEmployeeGuarantor.FillEmployeeGuarantor(ref aGuarantor, aEmployeeInfo);
			dbEmployeeSalary.FillEmployeeSalary(ref aSalary, aEmployeeInfo);
			dbEmployeeSpouse.FillEmployeeSpouse(ref aEmployeeSpouse);
			dbEmployeeEducation.FillEmployeeEducationList(ref aEmployeeEducation);
			dbEmployeeWorkBackground.FillEmployeeWorkBackgroundList(ref aEmployeeWorkBackground);
			dbEmployeeChildren.FillEmployeeChildrenList(ref aEmployeeChildrenList);
			dbEmployeeSpecialAllowance.FillEmployeeSpecialAllowanceList(ref aEmployeeSpecialAllowance);	
		}

		public override bool InsertTransaction(TableAccess tableAccess)
		{
			bool result = false;
			EmployeeDB dbEmployee = new EmployeeDB();
			EmployeeParentDB dbEmployeeParent = new EmployeeParentDB();
			EmployeeReferencePersonDB dbEmployeeReferencePerson = new EmployeeReferencePersonDB();
			EmployeeGuarantorDB dbEmployeeGuarantor = new EmployeeGuarantorDB();
			EmployeeSalaryDB dbEmployeeSalary = new EmployeeSalaryDB();
			EmployeeAddressDB dbEmployeeAddress = new EmployeeAddressDB();
			EmployeeSpouseDB dbEmployeeSpouse = new EmployeeSpouseDB();
			EmployeeEducationDB dbEmployeeEducation = new EmployeeEducationDB();
			EmployeeWorkBackgroundDB dbEmployeeWorkBackground = new EmployeeWorkBackgroundDB();
			EmployeeChildrenDB dbEmployeeChildren = new EmployeeChildrenDB();
			EmployeeSpecialAllowanceDB  dbEmployeeSpecialAllowance = new EmployeeSpecialAllowanceDB();

			dbEmployee.TableAccess = tableAccess;
			dbEmployeeEducation.TableAccess = tableAccess;
			dbEmployeeAddress.TableAccess = tableAccess;
			dbEmployeeParent.TableAccess = tableAccess;
			dbEmployeeReferencePerson.TableAccess = tableAccess;
			dbEmployeeGuarantor.TableAccess = tableAccess;
			dbEmployeeSalary.TableAccess = tableAccess;
			dbEmployeeSpouse.TableAccess = tableAccess;
			dbEmployeeWorkBackground.TableAccess = tableAccess;
			dbEmployeeChildren.TableAccess = tableAccess;
			dbEmployeeSpecialAllowance.TableAccess = tableAccess;


			if(IsNotNULL(aEmployeeInfo.EmployeeNo))
			{
				dbEmployee.InsertEmployee(aEmployeeInfo);
						
				if(employeeParentChange && (IsNotNULL(aEmployeeFather.AEmployee.EmployeeNo)) && (IsNotNULL(aEmployeeMother.AEmployee.EmployeeNo)))
				{					
					dbEmployeeParent.MaintainEmployeeParent(aEmployeeFather, aEmployeeMother, aEmployeeInfo);
				}
				if(referencePersonChange && IsNotNULL(aReferencePerson.AName.Thai))
				{
					dbEmployeeReferencePerson.MaintainEmployeeReferencePerson(aReferencePerson, aEmployeeInfo);
				}
				if(guarantorChange && IsNotNULL(aGuarantor.AName.Thai))
				{
					dbEmployeeGuarantor.MaintainEmployeeGuarantor(aGuarantor, aEmployeeInfo);
				}
				if(salaryChange && (aSalary != null))
				{
					dbEmployeeSalary.MaintainEmployeeSalary(aSalary, aEmployeeInfo);
				}
				if(employeeAddressChange && IsNotNULL(aEmployeeAddress.AEmployee.EmployeeNo))
				{
					dbEmployeeAddress.MaintainEmployeeAddress(aEmployeeAddress);
				}
				if(employeeSpouseChange && IsNotNULL(aEmployeeSpouse.AEmployee.EmployeeNo))
				{
					dbEmployeeSpouse.MaintainEmployeeSpouse(aEmployeeSpouse);
				}
				if(employeeEducationChange && IsNotNULL(aEmployeeEducation))
				{
					dbEmployeeEducation.MaintainEmployeeEducation(aEmployeeEducation);
				}
				if(employeeWorkBackgroundChange && IsNotNULL(aEmployeeWorkBackground))
				{
					dbEmployeeWorkBackground.MaintainEmployeeWorkBackground(aEmployeeWorkBackground);
				}
				if(employeeChildrenListChange && IsNotNULL(aEmployeeChildrenList))
				{
					dbEmployeeChildren.MaintainEmployeeChildren(aEmployeeChildrenList);
				}
				if(employeeSpecialAllowanceChange && IsNotNULL(aEmployeeSpecialAllowance))
				{
					dbEmployeeSpecialAllowance.MaintainEmployeeSpecialAllowance(aEmployeeSpecialAllowance);
				}
				result = true;
			}

			dbEmployee = null;
			dbEmployeeAddress = null;
			dbEmployeeChildren = null;
			dbEmployeeEducation = null;
			dbEmployeeGuarantor = null;
			dbEmployeeParent = null;
			dbEmployeeReferencePerson = null;
			dbEmployeeSalary = null;
			dbEmployeeSpecialAllowance = null;
			dbEmployeeSpouse = null;
			dbEmployeeWorkBackground = null;

			return result;
		}

		public override bool UpdateTransaction(TableAccess tableAccess)
		{
			bool result = false;
			EmployeeDB dbEmployee = new EmployeeDB();
			EmployeeParentDB dbEmployeeParent = new EmployeeParentDB();
			EmployeeReferencePersonDB dbEmployeeReferencePerson = new EmployeeReferencePersonDB();
			EmployeeGuarantorDB dbEmployeeGuarantor = new EmployeeGuarantorDB();
			EmployeeSalaryDB dbEmployeeSalary = new EmployeeSalaryDB();
			EmployeeAddressDB dbEmployeeAddress = new EmployeeAddressDB();
			EmployeeSpouseDB dbEmployeeSpouse = new EmployeeSpouseDB();
			EmployeeEducationDB dbEmployeeEducation = new EmployeeEducationDB();
			EmployeeWorkBackgroundDB dbEmployeeWorkBackground = new EmployeeWorkBackgroundDB();
			EmployeeChildrenDB dbEmployeeChildren = new EmployeeChildrenDB();
			EmployeeSpecialAllowanceDB  dbEmployeeSpecialAllowance = new EmployeeSpecialAllowanceDB();

			dbEmployee.TableAccess = tableAccess;
			dbEmployeeEducation.TableAccess = tableAccess;
			dbEmployeeAddress.TableAccess = tableAccess;
			dbEmployeeParent.TableAccess = tableAccess;
			dbEmployeeReferencePerson.TableAccess = tableAccess;
			dbEmployeeGuarantor.TableAccess = tableAccess;
			dbEmployeeSalary.TableAccess = tableAccess;
			dbEmployeeSpouse.TableAccess = tableAccess;
			dbEmployeeWorkBackground.TableAccess = tableAccess;
			dbEmployeeChildren.TableAccess = tableAccess;
			dbEmployeeSpecialAllowance.TableAccess = tableAccess;

			if(IsNotNULL(aEmployeeInfo.EmployeeNo))
			{		
				if (employeeChange)
				{
					dbEmployee.UpdateEmployee(aEmployeeInfo);
				}
				if(employeeParentChange)
				{
					dbEmployeeParent.MaintainEmployeeParent(aEmployeeFather, aEmployeeMother, aEmployeeInfo);
				}
				if(referencePersonChange && IsNotNULL(aReferencePerson.AName.Thai))
				{
					dbEmployeeReferencePerson.DeleteEmployeeReferencePerson(aReferencePerson, aEmployeeInfo);
					dbEmployeeReferencePerson.InsertEmployeeReferencePerson(aReferencePerson, aEmployeeInfo);
				}
				if(guarantorChange && IsNotNULL(aGuarantor.AName.Thai))
				{
					dbEmployeeGuarantor.DeleteEmployeeGuarantor(aGuarantor, aEmployeeInfo);
					dbEmployeeGuarantor.InsertEmployeeGuarantor(aGuarantor, aEmployeeInfo);
				}
				if(salaryChange && (aSalary != null))
				{
					dbEmployeeSalary.MaintainEmployeeSalary(aSalary, aEmployeeInfo);
				}
				if(employeeAddressChange)
				{
					dbEmployeeAddress.MaintainEmployeeAddress(aEmployeeAddress);
				}
				if(employeeSpouseChange)
				{
                    if (aEmployeeSpouse.AName.Thai == "")
                    {
                        dbEmployeeSpouse.DeleteEmployeeSpouse(aEmployeeSpouse);
                    }
                    else
                    {
					    dbEmployeeSpouse.MaintainEmployeeSpouse(aEmployeeSpouse);
                    }
				}
				if(employeeEducationChange)
				{
					dbEmployeeEducation.MaintainEmployeeEducation(aEmployeeEducation);
				}
				if(employeeWorkBackgroundChange)
				{
					dbEmployeeWorkBackground.MaintainEmployeeWorkBackground(aEmployeeWorkBackground);
				}
				if(employeeChildrenListChange)
				{
					dbEmployeeChildren.MaintainEmployeeChildren(aEmployeeChildrenList);
				}
				if(employeeSpecialAllowanceChange)
				{
					dbEmployeeSpecialAllowance.MaintainEmployeeSpecialAllowance(aEmployeeSpecialAllowance);
				}
				result = true;
			}
			dbEmployee = null;
			dbEmployeeAddress = null;
			dbEmployeeChildren = null;
			dbEmployeeEducation = null;
			dbEmployeeGuarantor = null;
			dbEmployeeParent = null;
			dbEmployeeReferencePerson = null;
			dbEmployeeSalary = null;
			dbEmployeeSpecialAllowance = null;
			dbEmployeeSpouse = null;
			dbEmployeeWorkBackground = null;

			return result;
		}

		public override bool DeleteTransaction(TableAccess tableAccess)
		{
			bool result = false;
			EmployeeDB dbEmployee = new EmployeeDB();
			EmployeeParentDB dbEmployeeParent = new EmployeeParentDB();
			EmployeeReferencePersonDB dbEmployeeReferencePerson = new EmployeeReferencePersonDB();
			EmployeeGuarantorDB dbEmployeeGuarantor = new EmployeeGuarantorDB();
			EmployeeSalaryDB dbEmployeeSalary = new EmployeeSalaryDB();
			EmployeeAddressDB dbEmployeeAddress = new EmployeeAddressDB();
			EmployeeSpouseDB dbEmployeeSpouse = new EmployeeSpouseDB();
			EmployeeEducationDB dbEmployeeEducation = new EmployeeEducationDB();
			EmployeeWorkBackgroundDB dbEmployeeWorkBackground = new EmployeeWorkBackgroundDB();
			EmployeeChildrenDB dbEmployeeChildren = new EmployeeChildrenDB();
			EmployeeSpecialAllowanceDB  dbEmployeeSpecialAllowance = new EmployeeSpecialAllowanceDB();

			dbEmployee.TableAccess = tableAccess;
			dbEmployeeEducation.TableAccess = tableAccess;
			dbEmployeeAddress.TableAccess = tableAccess;
			dbEmployeeParent.TableAccess = tableAccess;
			dbEmployeeReferencePerson.TableAccess = tableAccess;
			dbEmployeeGuarantor.TableAccess = tableAccess;
			dbEmployeeSalary.TableAccess = tableAccess;
			dbEmployeeSpouse.TableAccess = tableAccess;
			dbEmployeeWorkBackground.TableAccess = tableAccess;
			dbEmployeeChildren.TableAccess = tableAccess;
			dbEmployeeSpecialAllowance.TableAccess = tableAccess;

			if(IsNotNULL(aEmployeeInfo.EmployeeNo))
			{										
				dbEmployeeParent.DeleteEmployeeParent(aEmployeeFather, aEmployeeMother, aEmployeeInfo);
				dbEmployeeReferencePerson.DeleteEmployeeReferencePerson(aReferencePerson, aEmployeeInfo);
				dbEmployeeGuarantor.DeleteEmployeeGuarantor(aGuarantor, aEmployeeInfo);
				dbEmployeeSalary.DeleteEmployeeSalary(aSalary, aEmployeeInfo);
				dbEmployeeAddress.DeleteEmployeeAddress(aEmployeeAddress);
				dbEmployeeSpouse.DeleteEmployeeSpouse(aEmployeeSpouse);
				dbEmployeeEducation.DeleteEmployeeEducation(aEmployeeEducation);
				dbEmployeeWorkBackground.DeleteEmployeeWorkBackground(aEmployeeWorkBackground);
				dbEmployeeChildren.DeleteEmployeeChildren(aEmployeeChildrenList);
				dbEmployeeSpecialAllowance.DeleteEmployeeSpecialAllowance(aEmployeeSpecialAllowance);
				dbEmployee.DeleteEmployee(aEmployeeInfo);	
				result = true;
			}
			dbEmployee = null;
			dbEmployeeAddress = null;
			dbEmployeeChildren = null;
			dbEmployeeEducation = null;
			dbEmployeeGuarantor = null;
			dbEmployeeParent = null;
			dbEmployeeReferencePerson = null;
			dbEmployeeSalary = null;
			dbEmployeeSpecialAllowance = null;
			dbEmployeeSpouse = null;
			dbEmployeeWorkBackground = null;
			return result;
		}
	}
}
