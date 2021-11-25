using System;
using System.Collections.Generic;
using System.Text;

using ictus.Common.Entity;
using ictus.Common.Entity.General;

namespace Entity.WelfareEntities {
    public class ContractHospital : DualFieldBase,IHospital  {
        #region IHospital Members
        string IHospital.ToString() {
            return aName.ToString();
        }

        #endregion
    }
}
