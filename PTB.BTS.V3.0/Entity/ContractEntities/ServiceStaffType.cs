using System;

using ictus.Common.Entity.General;
using ictus.PIS.PI.Entity;
using ictus.Framework.ASC.Entity.DNF20;
using ictus.Common.Entity;
using Entity.CommonEntity;

namespace Entity.ContractEntities
{
	public class ServiceStaffType : EntityBase, IKey
	{
        public static string DUMMYCODE = "ZZZ";

        #region English Description

        public static class TypeCode
        {
            public static readonly string DRIVER = "281";
            public static readonly string FAMILY_CAR_DRIVER = "282";
        }

        #endregion
        
        //		============================== Property ==============================
		private string type = NullConstant.STRING;
		public string Type
		{
			get
			{return type;}
			set
			{type = value;}
		}

		private Description aDescription;
		public Description ADescription
		{
			get
			{return aDescription;}
			set
			{aDescription = value;}
		}

		private Position aPosition;
		public Position APosition
		{
			get
			{return aPosition;}
			set
			{aPosition = value;}
		}

        private string bizPacIncomeCode = NullConstant.STRING;
        public string BizPacIncomeCode
        {
            get
            { return bizPacIncomeCode; }
            set
            { bizPacIncomeCode = value.Trim(); }
        }

        private string bizPacIncomeName = NullConstant.STRING;
        public string BizPacIncomeName
        {
            get
            { return bizPacIncomeName; }
            set
            { bizPacIncomeName = value.Trim(); }
        }


		public bool IsSpare
		{
			get
			{
				if(type.Trim().Substring(2,1).ToUpper() == "Z")
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		}

//		============================== Constructor ==============================
		public ServiceStaffType() : base()
		{
			aDescription = new Description();
			aPosition = new Position();
		}

		public ServiceStaffType(string type) : base()
		{
			this.type = type;
			aDescription = new Description();
			aPosition = new Position();
		}

//		============================== Public Method ==============================
		public override string EntityKey
		{
			get
			{return type.ToString();}
		}

		public override string  ToString()
		{
			return aDescription.English;
		}
	}
}
