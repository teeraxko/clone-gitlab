using System;
using System.Collections.Generic;
using System.Text;
using ictus.Common.Entity;

namespace PTB.PIS.Welfare.Facade {
    public abstract class FacadeBase {
        public enum Status {
            Idle, Insert, Update, Delete
        }

        protected  static readonly Company CurrentCompany = new Company("12");

    }
}
