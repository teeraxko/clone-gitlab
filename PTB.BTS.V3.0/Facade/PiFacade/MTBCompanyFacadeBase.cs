using System;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;

using Entity.CommonEntity;

using PTB.BTS.PI.Flow;

using Facade.CommonFacade;

using SystemFramework.AppException;

namespace Facade.PiFacade
{
	public abstract class MTBCompanyFacadeBase : FacadeBase
	{
		#region - Private - 
		protected MTBCompanyFlowBase flowMTB;
		protected string DummyCode;
		#endregion

		//		============================== Property ==============================
		protected Company company;
		public Company GetCompany()
		{
			return company;
		}		

		protected CompanyStuffBase objList;
		public CompanyStuffBase ObjList
		{
			get
			{
				return objList;
			}
		}
//		protected override ObjList RemoveDummy
//		{
//		}
//		============================== Constructor ==============================
		protected MTBCompanyFacadeBase() : base()
		{
			company = new Company("12");
		}

//		============================== Public Method ==============================
		public bool DisplayMTB()
		{
			objList.Clear();
			bool result = flowMTB.FillMTBData(objList);
			objList.Remove(DummyCode);
			return result;
		}

        public bool InsertMTB(ictus.Common.Entity.General.IKey value)
		{
			if (objList.Contain(value))
			{
				throw new DuplicateException("MTBCompanyFacadeBase");
			}

			if(flowMTB.InsertMTB(value, objList.Company))
			{
				objList.Add(value);
				return true;
			}
			else
			{
				return false;
			}
		}

        public bool UpdateMTB(ictus.Common.Entity.General.IKey value)
		{
			if(flowMTB.UpdateMTB(value, objList.Company))
			{
				objList.BaseSet(value.EntityKey, value);
				return true;
			}
			else
			{
				return false;
			}
		}

        public bool DeleteMTB(ictus.Common.Entity.General.IKey value)
		{
			if (flowMTB.DeleteMTB(value, objList.Company))
			{
				objList.Remove(value);
				return true;
			}
			else
			{
				return true;
			}
		}
	}
}
