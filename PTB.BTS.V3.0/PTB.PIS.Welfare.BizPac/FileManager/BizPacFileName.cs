using System;
using System.Collections.Generic;
using System.Text;

namespace PTB.PIS.Welfare.BizPac.FileManager {
    public abstract class BizPacFileName {
        protected string compName = @"PTB";
        protected string sysName = @"BTS";
        protected string moduleName;
        protected string extension = "CSV";
        protected DateTime fileDateTime;
        public BizPacFileName(DateTime fileDateTime) {
            this.fileDateTime = fileDateTime;
        }
        public BizPacFileName() {

        }

        public string RefFile() {
            return string.Format("{0}_{1}", this.moduleName, Common.FileName(this.fileDateTime));
        }


        public override string ToString() {
            return string.Format("{0}_{1}_{2}_{3}.{4}", this.compName, this.sysName, this.moduleName, Common.FileName(this.fileDateTime),this.extension);
        }
    }
}
