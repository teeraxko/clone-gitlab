using System;

using ictus.Common.Entity.General;using ictus.Framework.ASC.Entity.DNF20;

namespace Entity.AttendanceEntities
{
	public class OTPatternConditionBase : EntityBase, IKey
	{
//		============================== Property ==============================
		protected OTPattern aOTPattern;
		public  OTPattern AOTPattern
		{
			get{return aOTPattern;}
			set{aOTPattern = value;}
		}
//		============================== Constructor ==============================
		public OTPatternConditionBase() : base()
		{
			aOTPattern = new OTPattern();
		}

		#region IKey Members

		public override string EntityKey
		{
			get{return aOTPattern.EntityKey;}
		}

		#endregion
	}
}
