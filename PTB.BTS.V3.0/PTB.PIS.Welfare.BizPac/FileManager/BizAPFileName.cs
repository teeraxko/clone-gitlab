using System;
using System.Collections.Generic;
using System.Text;

namespace PTB.PIS.Welfare.BizPac.FileManager {
    public class BizAPFileName : BizPacFileName {

        public BizAPFileName() {

        }

        public BizAPFileName(DateTime fileDateTime)
            : base(fileDateTime) {
            this.moduleName = "AP";

        }
    }
}
