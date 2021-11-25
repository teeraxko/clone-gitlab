using System;
using System.Collections.Generic;
using System.Text;

namespace PTB.PIS.Welfare.BizPac.BizPacAccount {
    class Account {
        protected string code;
        public string Code {
            get { return code; }
            set { code = value; }
        }

        protected string name;
        public string Name {
            get { return name; }
            set { name = value; }
        }


    }
}
