using System;
using System.Collections.Generic;
using System.Text;
using ictus.Common.Entity.General;
using ictus.Framework.ASC.Entity.DNF20;
using Entity.AttendanceEntities;

namespace PTB.BTS.BTS2BizPacEntity
{
    public class CompulsoryExpense : CompulsoryInsuranceBP
    {
        //============================== Property ==============================

        //============================== Constructor ==============================
        public CompulsoryExpense()
            : base()
        {
        }

        //============================== public method ==============================
        public override string EntityKey
        {
            get { return policyNo; }
        }
    }
}
