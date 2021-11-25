using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Report.BLL
{
    internal class CommonCombo
    {
        #region - Const -
        public const string CUSTOMER_CODE = " ";
        public const string CUST_ENGLISH_NAME = "==All==";
        public const string CUST_THAI_NAME = "==ทั้งหมด==";
        
        public const string BRAND_CODE = " ";
        public const string BRAND_ENGLISH_NAME = "==All==";
        public const string BRAND_THAI_NAME = "==ทั้งหมด==";

        //Todsporn Modified 25/2/2020 PO. Discount
        public const string QUOTATION_STATUS = " ";
        public const string QUOTATION_STATUS_ENGLISH_NAME = "==All==";
        public const string QUOTATION_STATUS_THAI_NAME = "==ทั้งหมด==";
 

        public CommonCombo()
            : base()
        {
        } 
        #endregion
    }
}
