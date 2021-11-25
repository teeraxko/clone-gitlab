using System;
using System.Collections;
using System.Data;

using ictus.PIS.PI.Entity;

using PTB.BTS.PI.Flow;

using Facade.PiFacade;
using Facade.CommonFacade;

using SystemFramework.AppException;


namespace Facade.PiFacade
{
	
	public class SectionFacade : CommonPIFacadeBase
	{
		#region - Private -
		private SectionFlow flowSection;
		#endregion

//		============================== Property ==============================
		private SectionList objSectionList;
		public SectionList ObjSectionList
		{
			get{return objSectionList;}
		}

//		============================== DataSource ==============================
		public ArrayList DataSourceDepartment
		{
			get
			{
				DepartmentFlow flowDepartment = new DepartmentFlow();
				DepartmentList departmentList = new DepartmentList(GetCompany());
				flowDepartment.FillDepartment(ref departmentList);
				flowDepartment = null;
				return departmentList.GetArrayList();
			}
		}

//		============================== Constructor ==============================
		public SectionFacade()
		{
			flowSection = new SectionFlow();	
		}
//		============================== Public Method ==============================

		public bool DisplaySection()
		{
			objSectionList = new SectionList(GetCompany());

			return flowSection.FillSectionList(ref objSectionList);
		}

		public bool InsertSection(Section aSection)
		{
			if (objSectionList.Contain(aSection))
			{
				throw new DuplicateException("SectionFacade");
			}
			else
			{
				return flowSection.InsertSection(ref objSectionList, aSection);
			}
		}

		public bool UpdateSection(Section aSection)
		{
			return flowSection.UpdateSection(ref objSectionList, aSection);
		}

		public bool DeleteSection(Section aSection)
		{
			return flowSection.DeleteSection(ref objSectionList, aSection);
		}


	}
}
