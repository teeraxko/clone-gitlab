using System;
using System.Collections.Generic;
using System.Text;
using Facade.CommonFacade;
using Flow.PiFlow;
using ictus.PIS.PI.Entity;

namespace Facade.PiFacade
{
    public class SSHospitalFacade : MTBFacadeBase
    {
        public SSHospitalFacade()
            : base()
		{
			DummyCode = "ZZZZZZ";
            flowMTB = new SSHospitalFlow();
            objList = new SSHospitalList();
		}
    }
}
