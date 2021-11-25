//using System;
//using System.Data;
//using System.Collections;
//
//using SystemFramework.AppException;
//
//using ictus.PIS.PI.Entity;
//
//using PTB.BTS.PI.Flow;
//
//using Facade.CommonFacade;
//
//namespace Facade.PiFacade
//{
//	public class PrintPersonalDataFacade : CommonPIFacadeBase
//	{
//		#region -Private-
//		private DepartmentFlow flowDepartment;
//        private SectionFlow flowSection;
//		#endregion -Private-
//
//		public PrintPersonalDataFacade()
//		{ 
//			flowDepartment = new DepartmentFlow();
//			flowSection = new SectionFlow();
//		}
//		public ArrayList DataSourceDepartment
//		{
//			get
//			{
//				DepartmentFlow flowDepartment = new DepartmentFlow();
//				DepartmentList DepartmentList = new DepartmentList(GetCompany());
//				flowDepartment.FillDepartment(ref DepartmentList);
//				return DepartmentList.GetArrayList();			
//			}
//		}
//		
//		public ArrayList DataSourceSection
//		{
//			get
//			{
//				SectionFlow flowSection = new SectionFlow();
//				SectionList SectionList = new SectionList(GetCompany());
//				flowSection.FillSectionList(ref SectionList);
//				return SectionList.GetArrayList();			
//			}
//		}
//	}
//}
