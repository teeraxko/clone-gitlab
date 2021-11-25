using System;

using ictus.Common.Entity.General;

namespace Entity.CommonEntity
{
    public class FiscalYear
    {
        private string companyCode = NullConstant.STRING;
        public string CompanyCode
        {
            get { return companyCode; }
            set { companyCode = value; }
        }

        private string forYear = NullConstant.STRING;
        public string ForYear
        {
            get { return forYear; }
            set { forYear = value; }
        }

        private DateTime startDate = NullConstant.DATETIME;
        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }

        private DateTime endDate = NullConstant.DATETIME;
        public DateTime EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }
    }
}
