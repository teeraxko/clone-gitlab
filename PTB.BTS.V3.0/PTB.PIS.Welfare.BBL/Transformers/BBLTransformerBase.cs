using System;
using System.Collections.Generic;
using System.Text;
using PTB.PIS.Welfare.BBL.CSV;

namespace PTB.PIS.Welfare.BBL.Transformers {
    abstract class BBLTransformerBase {
        protected CSVFile csvFile = new CSVFile();
        public abstract void Tranform();
    }
}
