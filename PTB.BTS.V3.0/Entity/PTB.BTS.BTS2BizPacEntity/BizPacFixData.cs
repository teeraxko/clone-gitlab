using System;

using ictus.Common.Entity.Time;

namespace PTB.BTS.BTS2BizPacEntity
{
    public static class BizPacFixData
    {
        public const string DOCUMENT_TYPE_AP = "P2";
        public const string DOCUMENT_TYPE_AR = "R2";
        public const string VAT_CALC_TYPE = "E";
        public const string VAT_CODE_AP = "V7";
        public const string NO_VAT_CODE_AP = "VX";
        public const string VAT_CODE_AR = "O7";
        public const string VAT_TYPE = "Y";
        public const string NO_VAT_TYPE = "N";
        public const string BUSINESS_PLACE = "0000";
        public static DateTime MID_DATE_OF_MONTH
        {
            get
            {
                YearMonth yearMonth = new YearMonth(DateTime.Today);
                return yearMonth.GetDate(15);
            }
        }

        public static DateTime BACK_END_DATE_OF_MONTH
        {
            get
            {
                YearMonth yearMonth = new YearMonth(DateTime.Today.AddMonths(-1));
                return yearMonth.MaxDateOfMonth;
            }
        }

        public static DateTime NEXT_MID_DATE_OF_MONTH
        {
            get
            {
                DateTime midDate = MID_DATE_OF_MONTH;
                if (midDate < DateTime.Today)
                {
                    YearMonth yearMonth = new YearMonth(DateTime.Today.AddMonths(1));
                    return yearMonth.GetDate(15);
                }
                else
                {
                    return midDate;
                }
            }
        }
        public static DateTime END_DATE_OF_MONTH
        {
            get
            {
                YearMonth yearMonth = new YearMonth(DateTime.Today);
                return yearMonth.MaxDateOfMonth;
            }
        }

        public const string BIZPAC_DUMMY_REF_NO = "CNT-Z-0000000";
        public const string BIZPAC_DUMMY_GARAGE_VAT = "050";
        public const string BIZPAC_DUMMY_GARAGE_NONVAT = "054";
    }
}


        //DateTime DueDate { get;}
        //string Remark1 { get;}
        //string InvoiceType { get;}
        //decimal BaseAmount { get;}
        //decimal VATAmount { get;}
        //decimal NetAmount { get;}