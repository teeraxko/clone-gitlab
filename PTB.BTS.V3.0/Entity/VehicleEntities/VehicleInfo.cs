using System;

using ictus.Common.Entity;
using ictus.Common.Entity.General;

using Entity.CommonEntity;
using Entity.ContractEntities;

namespace Entity.VehicleEntities
{
	public class VehicleInfo : Vehicle
	{
        //		============================== Property ==============================		
		protected Province plateProvince;
		public Province PlateProvince
		{		
			set{plateProvince = value;}
			get{return plateProvince;}
		}
		
		protected string engineNo = NullConstant.STRING;
		public string EngineNo
		{			
			set{engineNo = value.Trim();}
			get{return engineNo;}
		}

		protected SECOND_HAND_STATUS_TYPE isSecondHand = SECOND_HAND_STATUS_TYPE.NULL;
		public SECOND_HAND_STATUS_TYPE IsSecondHand
		{			
			set{isSecondHand = value;}
			get{return isSecondHand;}
		}
		
		protected decimal vehicleAmount = NullConstant.DECIMAL;
		public decimal VehicleAmount
		{			
			set{vehicleAmount = value;}
			get{return vehicleAmount;}
		}
		
		protected decimal optionAmount = NullConstant.DECIMAL;
		public decimal OptionAmount
		{			
			set{optionAmount = value;}
			get{return optionAmount;}
		}

		protected int latestMileage = NullConstant.INT;
		public int LatestMileage
		{			
			set{latestMileage = value;}
			get{return latestMileage;}
		}

		protected DateTime latestMileageUpdateDate = NullConstant.DATETIME;
		public DateTime LatestMileageUpdateDate
		{			
			set{latestMileageUpdateDate = value;}
			get{return latestMileageUpdateDate;}
		}
		
		protected decimal operationFee = NullConstant.DECIMAL;
		public decimal OperationFee
		{			
			set{operationFee = value;}
			get{return operationFee;}
		}

		protected Vendor aVendor;
		public Vendor AVendor
		{			
			set{aVendor = value;}
			get{return aVendor;}
		}
		
		protected string remark = NullConstant.STRING;
		public string Remark
		{			
			set{remark = value.Trim();}
			get{return remark;}
		}

		protected DateTime terminationDate = NullConstant.DATETIME;
		public DateTime TerminationDate
		{			
			set{terminationDate = value;}
			get{return terminationDate;}
		}
		//=============================== Constructor ==============================
		public VehicleInfo() : base()
		{
			plateProvince = new Province();
		}

		public VehicleInfo(string plate) : base()
		{
			plateProvince = new Province();
			string[] strPlate = plate.Split('-');
			platePrefix = strPlate[1];
			plateRunningNo = strPlate[0];
		}
	}
}
