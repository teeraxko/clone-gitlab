//using System;
//
//using ictus.PIS.PI.Entity;
//using Entity.CommonEntity;
//
//using DataAccess.PiDB;
//
//using PTB.BTS.Common.Flow;
//
//using SystemFramework.AppException;
//
//namespace PTB.BTS.PI.Flow
//{
//	public class FormerFlow : FlowBase
//	{
//		#region - Private -
//		private FormerTransactionDB dbFormerTransaction;
//		#endregion
//
//		#region - Property -
//		public Employee AEmployee
//		{
//			get{return dbFormerTransaction.AEmployee;}
//			set{dbFormerTransaction.AEmployee = value;}
//		}
//		public EmployeeAddress AEmployeeAddress
//		{
//			get{return dbFormerTransaction.AEmployeeAddress;}
//			set{dbFormerTransaction.AEmployeeAddress = value;}
//		}
//		public EmployeeFather AEmployeeFather
//		{
//			get{return dbFormerTransaction.AEmployeeFather;}
//			set{dbFormerTransaction.AEmployeeFather = value;}
//		}
//		public EmployeeMother AEmployeeMother
//		{
//			get{return dbFormerTransaction.AEmployeeMother;}
//			set{dbFormerTransaction.AEmployeeMother = value;}
//		}
//		public ReferencePerson AReferencePerson
//		{
//			get{return dbFormerTransaction.AReferencePerson;}
//			set{dbFormerTransaction.AReferencePerson = value;}
//		}
//		public ReferencePerson AGuarantor
//		{
//			get{return dbFormerTransaction.AGuarantor;}
//			set{dbFormerTransaction.AGuarantor = value;}
//		}
//		public EmployeeSpouse AEmployeeSpouse
//		{
//			get{return dbFormerTransaction.AEmployeeSpouse;}
//			set{dbFormerTransaction.AEmployeeSpouse = value;}
//		}
//		public Salary ASalary
//		{
//			get{return dbFormerTransaction.ASalary;}
//			set{dbFormerTransaction.ASalary = value;}
//		}
//		public EmployeeEducation AEmployeeEducation
//		{
//			get{return dbFormerTransaction.AEmployeeEducation;}
////			set{dbFormerTransaction.AEmployeeEducation = value;}
//		}
//		public EmployeeWorkBackground AEmployeeWorkBackground
//		{
//			get{return dbFormerTransaction.AEmployeeWorkBackground;}
////			set{dbFormerTransaction.AEmployeeWorkBackground = value;}
//		}
//		public EmployeeChildrenList AEmployeeChildrenList
//		{
//			get{return dbFormerTransaction.AEmployeeChildrenList;}
////			set{dbFormerTransaction.AEmployeeChildrenList = value;}
//		}
//		public EmployeeSpecialAllowance AEmployeeSpecialAllowance
//		{
//			get{return dbFormerTransaction.AEmployeeSpecialAllowance;}
////			set{dbFormerTransaction.AEmployeeSpecialAllowance = value;}
//		}
//		#endregion
//
////		============================== Constructor ==============================
//		public FormerFlow(Company value) : base()
//		{
//			dbFormerTransaction = new FormerTransactionDB(value);
//		}
//
////		============================== public Method ==============================
//		public bool Display()
//		{
//			if(dbFormerTransaction.FillFormerList())
//			{return true;}
//			else
//			{throw new EmpNotFoundException("FormerFlow");}
//		}
//		public bool Insert()
//		{
//			return dbFormerTransaction.InsertFormerTransaction();
//		}
//		public bool Update()
//		{
//			return dbFormerTransaction.UpdateFormerTransaction();
//		}
//		public bool Delete()
//		{
//			return dbFormerTransaction.DeleteTransaction();
//		}
//	}
//}
