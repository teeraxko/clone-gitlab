using System;

using Entity.ContractEntities;
using Entity.AttendanceEntities;
using Entity.CommonEntity;

using ictus.Common.Entity.General;
using ictus.Framework.ASC.Entity.DNF20;
using ictus.PIS.PI.Entity;
using ictus.Common.Entity;

namespace Entity.VehicleEntities
{
    public class RepairingInfoBase : RepairingBase
	{
//		============================== Property ==============================
		protected Employee aReporter;
		public Employee AReporter
		{
			get{return aReporter;}
			set{aReporter = value;}
		}

		protected int mileage = NullConstant.INT;
		public int Mileage
		{
			get{return mileage;}
			set{mileage = value;}
		}

		protected VehicleContract aVehicleContract;
		public VehicleContract AVehicleContract
		{
			get{return aVehicleContract;}
			set{aVehicleContract = value;}
		}

		protected Customer aCustomer;
		public Customer ACustomer
		{
			get{return aCustomer;}
			set{aCustomer = value;}
		}

		protected CustomerDepartment aCustomerDepartment;
		public CustomerDepartment ACustomerDepartment
		{
			get{return aCustomerDepartment;}
			set{aCustomerDepartment = value;}
		}

		protected Hirer aHirer;
		public Hirer AHirer
		{
			get{return aHirer;}
			set{aHirer = value;}
		}

		protected string driverName = NullConstant.STRING;
		public string DriverName
		{
			get{return driverName;}
			set{driverName = value.Trim();}
		}
		
		protected Employee aDriver;
		public Employee ADriver
		{
			get{return aDriver;}
			set
			{
				value.EmployeeNo = value.EmployeeNo.Trim();
				aDriver = value;
			}
		}

		protected string garageInchargeName = NullConstant.STRING;
		public string GarageInchargeName
		{
			get{return garageInchargeName;}
			set{garageInchargeName = value.Trim();}
		}

		protected string garageTelNo = NullConstant.STRING;
		public string GarageTelNo
		{
			get{return garageTelNo;}
			set{garageTelNo = value.Trim();}
		}

        protected string invoiceNo = NullConstant.STRING;
        public string InvoiceNo
        {
            get { return invoiceNo; }
            set { invoiceNo = value; }
        }

        protected DateTime invoiceDate = NullConstant.DATETIME;
        public DateTime InvoiceDate
        {
            get { return invoiceDate; }
            set { invoiceDate = value; }
        }

		protected Employee aReceiver;
		public Employee AReceiver
		{
			get{return aReceiver;}
			set{aReceiver = value;}
		}   

		protected RepairingSparePartsList aRepairSparePartsList;
		public RepairingSparePartsList ARepairSparePartsList
		{
			get{return aRepairSparePartsList;}
			set{aRepairSparePartsList = value;}
		}

		protected bool maintainStatus = false;
		public bool MaintainStatus
		{
			get{return maintainStatus;}
			set{maintainStatus = value;}
		}

		protected bool repairFinishStatus = false;
		public bool RepairFinishStatus
		{
			get{return repairFinishStatus;}
			set{repairFinishStatus = value;}
		}

        //Use in process stamp dummy code.
        protected string bpRefNo = "";
        public string BPRefNo
        {
            get { return bpRefNo; }
            set { bpRefNo = value.Trim(); }
        }

//		============================== Constructor ==============================
        public RepairingInfoBase(ictus.Common.Entity.Company value)
            : base()
		{
			aRepairSparePartsList = new RepairingSparePartsList(value);
			
			aHirer = new Hirer();
		}


		#region IKey Members
		public override string EntityKey
		{
			get{return repairingNo.ToString();}
		}
		#endregion
	}

    public class Class1
    {
    }
}
