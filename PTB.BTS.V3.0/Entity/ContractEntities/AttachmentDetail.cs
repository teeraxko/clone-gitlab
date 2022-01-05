using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ictus.Framework.ASC.Entity.DNF20;
using ictus.Common.Entity.General;
using Entity.VehicleEntities;
using ictus.Common.Entity;

namespace Entity.ContractEntities
{
    public class AttachmentDetail : EntityBase, IKey
    {
        private DocumentNo contractNo;
        public DocumentNo ContractNo
        {
            get { 
                return contractNo; 
            }
            set { 
                contractNo = value; 
            }
        }

        private VehicleContract vehicleContract;
        public VehicleContract AVehicleContract
        {
            get
            {
                return vehicleContract;
            }
            set
            {
                vehicleContract = value;
            }
        }

        private ContractBase contract;
        public ContractBase AContract
        {
            get
            {
                return contract;
            }
            set
            {
                contract = value;
            }
        }

        //============================== Public method ==============================
        public override string EntityKey
        {
            get { return this.contractNo.ToString(); }
        }  
    }
}
