using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PTB.BTS.BTS2BizPacEntity;
using ictus.Framework.ASC.AppConfig;

namespace PTB.BTS.BTS2SAP.Entity
{
    public class BTS2SAPModel
    {
        public string TransferType { get; set; }
        public string MiscItemCode { get; set; }
        public string Doc { get; set; }
        public string CompanyCode { get; set; }
        public string DocumentType { get; set; }
        public string DocumentDate { get; set; }
        public string PostingDate { get; set; }
        public string PostingPeriod { get; set; }
        public string Currency { get; set; }
        public string ExchangeRate { get; set; }
        public string Reference { get; set; }
        public string DocHeaderText { get; set; }
        public string Branch { get; set; }
        public string TransactionDate { get; set; }
        public string PostingKey { get; set; }
        public string Account { get; set; }
        public string SpGl { get; set; }
        public string AlternativeGLAccount { get; set; }
        public string AmountInDocumentCurrency { get; set; }
        public string AmountInLocalCurrency { get; set; }
        public string CalcTax { get; set; }
        public string TaxCode { get; set; }
        public string BusinessPlace { get; set; }
        public string TaxBaseAmount { get; set; }
        public string DetermineTaxBase { get; set; }
        public string PmtTerms { get; set; }
        public string BaselineDate { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentBlock { get; set; }
        public string InvoiceReference { get; set; }
        public string IndicatorIndividualPayee { get; set; }
        public string Assignment { get; set; }
        public string ItemText { get; set; }
        public string RefKey1 { get; set; }
        public string RefKey2 { get; set; }
        public string BusinessArea { get; set; }
        public string CostCenter { get; set; }
        public string ProfitCenter { get; set; }
        public string InternalOrder { get; set; }
        public string TradingPartner { get; set; }
        public string ValueDate { get; set; }
        public string AssignmentPA { get; set; }
        public string PAMaterialGroup { get; set; }
        public string PASalesGroup { get; set; }
        public string PADivision { get; set; }
        public string PACostCenter { get; set; }
        public string PASalesOffice { get; set; }
        public string WHTCode1 { get; set; }
        public string WHTBase1 { get; set; }
        public string WHTAMT1 { get; set; }
        public string WHTCode2 { get; set; }
        public string WHTBase2 { get; set; }
        public string WHTAMT2 { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public string Name3 { get; set; }
        public string Name4 { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string CountryKey { get; set; }
        public string TaxNumber1 { get; set; }
        public string TaxNumber2 { get; set; }
        public string BankKey { get; set; }
        public string BankCountryKey { get; set; }
        public string BankAccount { get; set; }
        public string TransactionType { get; set; }
        public string TaxAmount { get; set; }
        public string WithholdingTaxType1 { get; set; }
        public string WithholdingTaxType2 { get; set; }
        public string TaxNumber3 { get; set; }
        public string ReferenceKey3 { get; set; }

        public string BizPacRefNo { get; set; }
        public string PersistenceId { get; set; }

        //private string csvFormat = @"{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20}, {21}, {22}, {23}, {24}, {25}, {26}, {27}, {28}, {29}, {30}, {31}, {32}, {33}, {34}, {35}, {36}, {37}, {38}, {39}, {40}, {41}, {42}, {43}, {44}, {45}, {46}, {47}, {48}, {49}, {50}, {51}, {52}, {53}, {54}, {55}, {56}, {57}, {58}, {59}, {60}, {61}, {62}, {63}, {64}, {65}, {66}, {67}, {68}, {69}";
        private string csvFormat = @"{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23},{24},{25},{26},{27},{28},{29},{30},{31},{32},{33},{34},{35},{36},{37},{38},{39},{40},{41},{42},{43},{44},{45},{46},{47},{48},{49},{50},{51},{52},{53},{54},{55},{56},{57},{58},{59},{60},{61},{62},{63},{64},{65},{66},{67},{68},{69}";
        private string sqlFormat = @"'{0}', '{1}', '{2}', '{3}', '{4}', '{5}', {6}, {7}, '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}', {19}, '{20}', '{21}', '{22}', '{23}', {24}, '{25}', '{26}', '{27}', '{28}', '{29}', '{30}', '{31}', '{32}', '{33}', '{34}', '{35}', '{36}', '{37}', '{38}', '{39}', '{40}', '{41}', '{42}', '{43}', '{44}', '{45}', '{46}', '{47}', '{48}', {49}, {50}, '{51}', '{52}', '{53}', '{54}', '{55}', '{56}', '{57}', '{58}', '{59}', '{60}', '{61}', '{62}', '{63}', '{64}', '{65}', '{66}', '{67}', '{68}', '{69}', '{70}', '{71}', '{72}', convert(datetime, '{73}', 103), '{74}', '{75}', '{76}'";

        public override string ToString()
        {
            return string.Format(this.csvFormat, this.Doc, this.CompanyCode, this.DocumentType,
                                                 this.DocumentDate.Trim(), this.PostingDate.Trim(), this.PostingPeriod, this.Currency, this.ExchangeRate,
                                                 this.Reference, this.DocHeaderText, this.Branch, this.TransactionDate, this.PostingKey,
                                                 this.Account, this.SpGl, this.AlternativeGLAccount, this.AmountInDocumentCurrency, this.AmountInLocalCurrency,
                                                 this.CalcTax, this.TaxCode, this.BusinessPlace, this.TaxBaseAmount, this.DetermineTaxBase,
                                                 this.PmtTerms, this.BaselineDate, this.PaymentMethod, this.PaymentBlock, this.InvoiceReference,
                                                 this.IndicatorIndividualPayee, this.Assignment,
                                                 ((this.ItemText.Length > BTS2SAPConstances.SAP_CSV_ITEM_TEXT_MAX_LENGTH) ? this.ItemText.Substring(0, BTS2SAPConstances.SAP_CSV_ITEM_TEXT_MAX_LENGTH) : this.ItemText),
                                                 this.RefKey1, this.RefKey2,
                                                 this.BusinessArea, this.CostCenter, this.ProfitCenter, this.InternalOrder, this.TradingPartner,
                                                 this.ValueDate, this.AssignmentPA, this.PAMaterialGroup, this.PASalesGroup, this.PADivision,
                                                 this.PACostCenter, this.PASalesOffice, this.WHTCode1, this.WHTBase1, this.WHTAMT1,
                                                 this.WHTCode2, this.WHTBase2, this.WHTAMT2, this.Name1, this.Name2,
                                                 this.Name3, this.Name4, this.Street, this.City, this.PostalCode,
                                                 this.CountryKey, this.TaxNumber1, this.TaxNumber2, this.BankKey, this.BankCountryKey,
                                                 this.BankAccount, this.TransactionType, this.TaxAmount, this.WithholdingTaxType1, this.WithholdingTaxType2,
                                                 this.TaxNumber3, this.ReferenceKey3);
        }

        public string ToInsertSQLValues()
        {
            return string.Format(this.sqlFormat, this.BizPacRefNo, this.TransferType, this.MiscItemCode, this.Doc, this.CompanyCode,
                                                 this.DocumentType,
                                                 (string.IsNullOrEmpty(this.DocumentDate) ? "NULL" : GetSqlCmdConvertSAPCSVDateStr2DateTime(this.DocumentDate)),
                                                 (string.IsNullOrEmpty(this.PostingDate) ? "NULL" : GetSqlCmdConvertSAPCSVDateStr2DateTime(this.PostingDate)),
                                                 this.PostingPeriod, this.Currency,
                                                 this.ExchangeRate, this.Reference, this.DocHeaderText, this.Branch, this.TransactionDate,
                                                 this.PostingKey, this.Account, this.SpGl, this.AlternativeGLAccount, (string.IsNullOrEmpty(this.AmountInDocumentCurrency) ? "NULL" : this.AmountInDocumentCurrency),
                                                 this.AmountInLocalCurrency, this.CalcTax, this.TaxCode, this.BusinessPlace, (string.IsNullOrEmpty(this.TaxBaseAmount) ? "NULL" : this.TaxBaseAmount),
                                                 this.DetermineTaxBase, this.PmtTerms, this.BaselineDate, this.PaymentMethod, this.PaymentBlock,
                                                 this.InvoiceReference, this.IndicatorIndividualPayee, this.Assignment,
                                                 ((this.ItemText.Length > BTS2SAPConstances.SAP_CSV_ITEM_TEXT_MAX_LENGTH) ? this.ItemText.Substring(0, BTS2SAPConstances.SAP_CSV_ITEM_TEXT_MAX_LENGTH) : this.ItemText),
                                                 this.RefKey1, this.RefKey2, this.BusinessArea, this.CostCenter, this.ProfitCenter, this.InternalOrder,
                                                 this.TradingPartner, this.ValueDate, this.AssignmentPA, this.PAMaterialGroup, this.PASalesGroup,
                                                 this.PADivision, this.PACostCenter, this.PASalesOffice, this.WHTCode1, (string.IsNullOrEmpty(this.WHTBase1) ? "NULL" : this.WHTBase1),
                                                 (string.IsNullOrEmpty(this.WHTAMT1) ? "NULL" : this.WHTAMT1), this.WHTCode2, this.WHTBase2, this.WHTAMT2, this.Name1,
                                                 this.Name2, this.Name3, this.Name4, this.Street, this.City,
                                                 this.PostalCode, this.CountryKey, this.TaxNumber1, this.TaxNumber2, this.BankKey,
                                                 this.BankCountryKey, this.BankAccount, this.TransactionType, this.TaxAmount, this.WithholdingTaxType1,
                                                 this.WithholdingTaxType2, this.TaxNumber3, this.ReferenceKey3, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss", BTS2SAPDateFormat.SAPCSVCultureInfo()), UserProfile.UserID, "0", this.PersistenceId);
                                                 //this.WithholdingTaxType2, this.TaxNumber3, this.ReferenceKey3, "getdate()", UserProfile.UserID, "0", this.PersistenceId);
        }

        private string GetSqlCmdConvertSAPCSVDateStr2DateTime(string strDateTime)
        {
            string sqlCmd = string.Format(BTS2SAPConstances.SQL_CASTING_SAP_CSV_2_DATETIME, strDateTime.Trim());

            return sqlCmd;
        }

        //public string[] ToExcelArrayFormat()
        //{
        //    string[] lineData = new string[]{this.Doc, this.CompanyCode, this.DocumentType, this.DocumentDate.Trim(),
        //                                     this.PostingDate.Trim(), this.PostingPeriod, this.Currency, this.ExchangeRate,
        //                                     this.Reference, this.DocHeaderText, this.Branch, this.TransactionDate, this.PostingKey,
        //                                     this.Account, this.SpGl, this.AlternativeGLAccount, this.AmountInDocumentCurrency, this.AmountInLocalCurrency,
        //                                     this.CalcTax, this.TaxCode, this.BusinessPlace, this.TaxBaseAmount, this.DetermineTaxBase,
        //                                     this.PmtTerms, this.BaselineDate, this.PaymentMethod, this.PaymentBlock, this.InvoiceReference,
        //                                     this.IndicatorIndividualPayee, this.Assignment,
        //                                     ((this.ItemText.Length > BTS2SAPConstances.SAP_CSV_ITEM_TEXT_MAX_LENGTH) ? this.ItemText.Substring(0, BTS2SAPConstances.SAP_CSV_ITEM_TEXT_MAX_LENGTH) : this.ItemText),
        //                                     this.RefKey1, this.RefKey2,
        //                                     this.BusinessArea, this.CostCenter, this.ProfitCenter, this.InternalOrder, this.TradingPartner,
        //                                     this.ValueDate, this.AssignmentPA, this.PAMaterialGroup, this.PASalesGroup, this.PADivision,
        //                                     this.PACostCenter, this.PASalesOffice, this.WHTCode1, this.WHTBase1, this.WHTAMT1,
        //                                     this.WHTCode2, this.WHTBase2, this.WHTAMT2, this.Name1, this.Name2,
        //                                     this.Name3, this.Name4, this.Street, this.City, this.PostalCode,
        //                                     this.CountryKey, this.TaxNumber1, this.TaxNumber2, this.BankKey, this.BankCountryKey,
        //                                     this.BankAccount, this.TransactionType, this.TaxAmount, this.WithholdingTaxType1, this.WithholdingTaxType2,
        //                                     this.TaxNumber3, this.ReferenceKey3};

        //    return lineData;
        //}
    }
}
