using System;

using Entity.CommonEntity;

using ictus.Common.Entity;
using ictus.Common.Entity.General;
using ictus.Framework.ASC.Entity.DNF20;

namespace Entity.VehicleEntities
{
	public class Model : EntityBase, IKey
	{
//		============================== Property ==============================
		private string code = NullConstant.STRING;
		public string Code
		{
			set{code = value;}
			get{return code;}
		}

		private Brand aBrand;
		public Brand ABrand
		{			
			set{aBrand = value;}
			get{return aBrand;}
		}

		private int engineCC = NullConstant.INT;
		public int EngineCC
		{
			set{engineCC = value;}
			get{return engineCC;}			
		}

		private GEAR_TYPE gearType = GEAR_TYPE.NULL;
		public GEAR_TYPE GearType
		{
			set{gearType = value;}
			get{return gearType;}			
		}

		private GasolineType aGasolineType;
		public GasolineType AGasolineType
		{			
			set{aGasolineType = value;}
			get{return aGasolineType;}
		}

		private BREAK_TYPE breakType = BREAK_TYPE.NULL;
		public BREAK_TYPE BreakType
		{
			set{breakType = value;}
			get{return breakType;}	
		}

		private ModelType aModelType;
		public ModelType AModelType
		{			
			set{aModelType = value;}
			get{return aModelType;}
		}

		private int noOfSeat = NullConstant.INT;
		public int NoOfSeat
		{			
			set{noOfSeat = value;}
			get{return noOfSeat;}
		}

		private Description aName;
		public Description AName
		{			
			set{aName = value;}
			get{return aName;}
		}

//		============================== Constructor ==============================
		public Model() : base()
		{
			aBrand = new Brand();
			aName = new Description();
		}


        public Model(Brand b) {
            aBrand = b;
        }

//		============================== Public Method ==============================
		public override string EntityKey
		{
			get
			{return code;}
		}

		public override string ToString()
		{
			return aName.English;
		}
	}
}
