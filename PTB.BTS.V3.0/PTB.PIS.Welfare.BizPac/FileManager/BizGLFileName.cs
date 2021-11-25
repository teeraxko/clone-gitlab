using System;
using System.Collections.Generic;
using System.Text;

namespace PTB.PIS.Welfare.BizPac.FileManager {
    public class BizGLFileName : BizPacFileName {

        public BizGLFileName() {

        }

        public BizGLFileName(DateTime fileDateTime):base(fileDateTime) {
            this.moduleName = "GL";

        }


    }
}
