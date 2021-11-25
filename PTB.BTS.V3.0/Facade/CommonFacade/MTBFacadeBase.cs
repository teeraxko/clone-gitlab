using System;

using Entity.CommonEntity;

using PTB.BTS.Common.Flow;

using SystemFramework.AppException;

namespace Facade.CommonFacade
{
	public abstract class MTBFacadeBase : FacadeBase
	{
		#region - Private - 
		protected MTBFlowBase flowMTB;
		protected string DummyCode;
		#endregion

		protected ictus.Common.Entity.General.ListBase objList;
		public ictus.Common.Entity.General.ListBase ObjList
		{
			get{return objList;}
		}

//		============================== Constructor ==============================
		protected MTBFacadeBase() : base()
		{}

//		============================== Public Method ==============================
		public bool DisplayMTB()
		{
			objList.Clear();
			bool result = flowMTB.FillMTBList(objList);

			objList.Remove(DummyCode);
			return result;
		}

        public bool InsertMTB(ictus.Common.Entity.General.IKey value)
		{
			if (objList.Contain(value))
			{
				throw new DuplicateException("MTBFacadeBase");
			}

			if(flowMTB.InsertMTB(value))
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
			if(flowMTB.UpdateMTB(value))
			{
				objList.BaseSet(value.EntityKey, value);
				return true;
			}
			else
			{
				return false;
			}
		}

        public bool UpdateMTB(ictus.Common.Entity.General.IKey newValue, ictus.Common.Entity.General.IKey oldValue)
		{
			if (objList.Contain(newValue))
			{
				throw new DuplicateException("MTBFacadeBase");
			}
			else
			{
				if(flowMTB.DeleteMTB(oldValue))
				{
					if(flowMTB.UpdateMTB(newValue))
					{
						objList.Remove(oldValue);
						objList.Add(newValue);
						return true;
					}
				}
			}
			return false;
		}

        public bool DeleteMTB(ictus.Common.Entity.General.IKey value)
		{
			if (flowMTB.DeleteMTB(value))
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
