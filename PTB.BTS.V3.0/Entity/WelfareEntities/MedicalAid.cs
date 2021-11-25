using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.WelfareEntities {
    public class MedicalAid {

        private IHospital hospital;
        public IHospital Hospital {
            get { return hospital; }
            set { hospital = value; }
        }



    }
}
