using System;
using System.Data;

using ictus.PIS.PI.Entity;

using DataAccess.PiDB;

using PTB.BTS.Common.Flow;

using ictus.Common.Entity;

namespace PTB.BTS.PI.Flow
{
	public class PositionTypeFlow
	{
		#region - Private -
		private PositionTypeDB dbPositionType;
		#endregion

//  ================================Constructor=====================
		public PositionTypeFlow()
		{
			dbPositionType = new PositionTypeDB();
		}

		public PositionTypeList GetPositionTypeList(Company value)
		{
			PositionTypeList positionTypeList = new PositionTypeList(value);
			dbPositionType.FillPositionTypeList(ref positionTypeList);
			return positionTypeList;
		}

		public PositionType GetPositionType(string positionType, Company aCompany)
		{
			return dbPositionType.GetPositionType(positionType, aCompany);
		}
	}
}
