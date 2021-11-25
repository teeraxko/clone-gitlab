using System;
using System.Collections.Generic;
using System.Text;
using Entity.AttendanceEntities;
using Facade.PiFacade;
using Flow.AttendanceFlow;

namespace Facade.AttendanceFacade
{
    public class AnnualLeaveControlFacade : CommonPIFacadeBase
    {
        public AnnualLeaveControl GetAnnualLeaveControl(int year)
        {
            using (AnnualLeaveControlFlow flow = new AnnualLeaveControlFlow())
            {
                return flow.GetAnnualLeaveControl(year, GetCompany());
            }
        }
    }
}
