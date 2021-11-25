using System;
using System.Collections.Generic;
using System.Text;
using ictus.PIS.Welfare.Entity.MedicalAidEntities;

namespace PTB.PIS.Welfare.BizPac.AP
{
    public class APJournalForMedicalAid : APJournal
    {
        private List<MedicalAidApplication> apps = new List<MedicalAidApplication>();
        public List<MedicalAidApplication> Apps
        {
            get { return apps; }
            set { apps = value; }
        }

    }
}
