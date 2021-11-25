using System;
using System.Collections.Generic;
using System.Text;
using PTB.PIS.Welfare.BizPac.FileManager;
using System.Globalization;

namespace PTB.PIS.Welfare.BizPac.Transformers {
    public abstract class Transformer {
        
        protected List<string> listOfRefNo = new List<string>();
        public List<string> ListOfRefNo {
            get { return listOfRefNo; }
            set { listOfRefNo = value; }
        }

        // Kriangkrai A.
        //protected BizPacFile bizPacFile = new BizPacFile();
        //public BizPacFile BizPacFile {
        //    get { return this.bizPacFile; }
        //}

        protected string bizPacFile = string.Empty;
        public string BizPacFile
        {
            get { return bizPacFile; }
            set { bizPacFile = value; }
        }

        protected DateTime connectDateTime;
        public Transformer(DateTime connectDateTime) {
            this.connectDateTime = connectDateTime;
        }
        public abstract bool Transform();
        public CultureInfo currentCultureInfo;
        //public abstract bool PrepareTextStream();
        //public abstract bool WriteTextStream();
        //public abstract BizPacFile file { get;}

    }
}
