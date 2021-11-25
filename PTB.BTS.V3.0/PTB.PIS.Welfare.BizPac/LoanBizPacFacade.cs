using System;
using System.Collections.Generic;
using System.Text;
using ictus.PIS.Welfare.Entity.LoanEntities;
using PTB.PIS.Welfare.BizPac.BizPacFlows;
using PTB.PIS.Welfare.BizPac.BizPacEntities;

namespace PTB.PIS.Welfare.BizPac
{
    public class LoanBizPacFacade
    {
        public static List<LoanApplication> FillNoBizPacByFromDateToDAte(DateTime fromDate, DateTime toDate)
        {
            return new LoanApplicationBizFlow().FillNoBizPacByFromDateToDAte(Common.CurrentCompany, fromDate, toDate);
        }
        public static ConnectBizPacResult Update(List<LoanApplication> apps, DateTime paymentDate)
        {
            LoanApplicationBizFlow flow = new LoanApplicationBizFlow();
            return flow.UpdateBiz(Common.CurrentCompany, apps, paymentDate);
        }

        public static List<ConnectBizPacDetail> GetConnectHistoryByDate(DateTime fromDate, DateTime toDate)
        {
            return new LoanApplicationBizFlow().GetConnectHistory(Common.CurrentCompany, fromDate, toDate);
        }

        public static List<ConnectBizPacDetail> GetConnectHistoryByRefNo(string refNo)
        {
            return new LoanApplicationBizFlow().GetConnectHistory(Common.CurrentCompany, refNo);
        }

        public static bool CancelBiz(List<ConnectBizPacDetail> details)
        {
            return new LoanApplicationBizFlow().CancelConnect(Common.CurrentCompany, details);
        }


    }
}
