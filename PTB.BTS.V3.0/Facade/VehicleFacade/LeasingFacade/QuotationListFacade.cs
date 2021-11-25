using System;
using System.Collections.Generic;
using System.Text;
using Facade.PiFacade;
using Entity.VehicleEntities.Leasing;
using Flow.VehicleEntities.Leasing;

namespace Facade.VehicleFacade.LeasingFacade
{
    public class QuotationListFacade : CommonPIFacadeBase
    {
        private QuotationList listQuotation;
        public QuotationList ListQuotation
        {
            get { return listQuotation; }
        }

        private string yy = "";
        public string YY
        {
            set { yy = value; }
        }

        private string mm = "";
        public string MM
        {
            set { mm = value; }
        }

        private string xxx = "";
        public string XXX
        {
            set { xxx = value; }
        }

        private DateTime issueDate;
        public DateTime IssueDate
        {
            set { issueDate = value; }
        }

        //============================== Constructor ==============================
        public QuotationListFacade() : base()
        {

        }

        //============================== Constructor ==============================
        public bool DisplayQuotation()
        {
            listQuotation = new QuotationList(GetCompany());

            Quotation quotation = new Quotation();
            quotation.QuotationNo = new Entity.ContractEntities.DocumentNo(Entity.CommonEntity.DOCUMENT_TYPE.QUOTATION_VEHICLE, yy, mm, xxx);
            quotation.LastIssueDate = issueDate;

            using (QuotationFlow flowQuotation = new QuotationFlow())
            {
                return flowQuotation.FillQuotationMainList(listQuotation, quotation);                
            }
        }
    }
}
