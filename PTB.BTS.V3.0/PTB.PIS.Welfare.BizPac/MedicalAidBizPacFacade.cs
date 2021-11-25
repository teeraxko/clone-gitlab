using System;
using System.Collections.Generic;
using System.Text;
using ictus.PIS.Welfare.Entity.MedicalAidEntities;
using PTB.PIS.Welfare.BizPac.BizPacFlows;
using PTB.PIS.Welfare.BizPac.BizPacEntities;

namespace PTB.PIS.Welfare.BizPac
{
    public class MedicalAidBizPacFacade
    {

        public static List<MedicalAidApplication> FillNoBizPacByFromDateToDateNoAtt(DateTime fromDate, DateTime toDate)
        {
            return new MedicalAidApplicationBizFlow().FillNoBizPacByFromDateToDAte(Common.CurrentCompany, fromDate, toDate, false);
        }

        public static List<MedicalAidApplication> FillNoBizPacByFromDateToDateAtt(DateTime fromDate, DateTime toDate)
        {
            return new MedicalAidApplicationBizFlow().FillNoBizPacByFromDateToDAte(Common.CurrentCompany, fromDate, toDate, true);
        }

        // Kriangkrai A. 18/2/2018 Modify to transfer to SAP and allow user select posting date from screen
        // For Med Aid w/o att change to do same as with Att
        public static ConnectBizPacResult Update(List<MedicalAidApplication> apps, DateTime paymentDate)
        {
            MedicalAidApplicationBizFlow flow = new MedicalAidApplicationBizFlow();
            //return flow.UpdateBiz(Common.CurrentCompany, apps, paymentDate);

            return flow.UpdateBiz(Common.CurrentCompany, apps, paymentDate);
        }

        // Kriangkrai A. 18/2/2018 Modify to transfer to SAP and allow user select posting date from screen
        // For Med Aid with Att
        public static ConnectBizPacResult UpdateAtt(List<MedicalAidApplication> apps, DateTime postingDate)
        {
            MedicalAidApplicationBizFlow flow = new MedicalAidApplicationBizFlow();
            return flow.UpdateBizAtt(Common.CurrentCompany, apps, postingDate);
        }

        public static List<ConnectBizPacDetail> GetConnectHistoryByDate(DateTime fromDate, DateTime toDate)
        {
            return new MedicalAidApplicationBizFlow().GetConnectHistory(Common.CurrentCompany, fromDate, toDate);
        }

        public static List<ConnectBizPacDetail> GetConnectHistoryByRefNo(string refNo)
        {
            return new MedicalAidApplicationBizFlow().GetConnectHistory(Common.CurrentCompany, refNo);
        }

        public static bool CancelBiz(List<ConnectBizPacDetail> details)
        {
            return new MedicalAidApplicationBizFlow().CancelConnect(Common.CurrentCompany, details);
        }

        public static DateTime RetriveDate(DateTime value)
        {
            Flow.AttendanceFlow.GenerateOtherBenefitFlow flow = new Flow.AttendanceFlow.GenerateOtherBenefitFlow();

            return flow.RetriveDate(value, Common.CurrentCompany, -1);
        }
    }
}
