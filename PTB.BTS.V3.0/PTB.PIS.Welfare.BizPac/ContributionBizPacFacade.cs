using System;
using System.Collections.Generic;
using System.Text;
using ictus.PIS.Welfare.Entity.ContributionEntities;
using ictus.PIS.Welfare.Flow.ContributionFlows;
using PTB.PIS.Welfare.BizPac.BizPacFlows;
using PTB.PIS.Welfare.BizPac.BizPacEntities;

namespace PTB.PIS.Welfare.BizPac
{
    public class ContributionBizPacFacade
    {
        public static List<ContributionApplication> FillNoBizPacByFromDateToDAte(DateTime fromDate, DateTime toDate)
        {
            return new ContributionApplicationBizFlow().FillNoBizPacByFromDateToDAte(Common.CurrentCompany, fromDate, toDate);
        }

        // Kriangkrai A.
        // For not pay to Acc.
        // for SAP use same function thie function will not use
        //public static ConnectBizPacResult Update(List<ContributionApplication> apps)
        //{
        //    ContributionApplicationBizFlow flow = new ContributionApplicationBizFlow();
        //    return flow.UpdateBiz(Common.CurrentCompany, apps);
        //}

        public static List<ConnectBizPacDetail> GetConnectHistoryByDate(DateTime fromDate, DateTime toDate)
        {
            return new ContributionApplicationBizFlow().GetConnectHistory(Common.CurrentCompany, fromDate, toDate);
        }

        public static List<ConnectBizPacDetail> GetConnectHistoryByRefNo(string refNo)
        {
            return new ContributionApplicationBizFlow().GetConnectHistory(Common.CurrentCompany, refNo);
        }

        public static bool CancelBiz(List<ConnectBizPacDetail> details)
        {
            return new ContributionApplicationBizFlow().CancelConnect(Common.CurrentCompany, details);
        }

        public static DateTime RetriveDate(DateTime value)
        {
            Flow.AttendanceFlow.GenerateOtherBenefitFlow flow = new Flow.AttendanceFlow.GenerateOtherBenefitFlow();

            return flow.RetriveDate(value, Common.CurrentCompany, -1);
        }


        public static ConnectBizPacResult Update(List<ContributionApplication> apps, DateTime paymentDate)
        {
            ContributionApplicationBizFlow flow = new ContributionApplicationBizFlow();
            return flow.UpdateBiz(Common.CurrentCompany, apps, paymentDate);
        }
    }
}
