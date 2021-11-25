using System;

namespace ictus.SystemConnection.BizPac.Core
{
    public interface IAccountHeader
    {
        //Gen for stamp
        string BizPacRefNo { get; set;} //= DocNo
        DateTime BizPacRefDate { get; set;} //=DocDate

        //for BizPac
        string DocumentType { get;}
        DateTime DocDate { get;}
        //diference for child
        string VATCode { get;}
        string VATType { get;}
        string VATCalcType { get;}
        DateTime DueDate { get;}
        string BusinessPlace { get;}
        string BizPacRemark1 { get;}
        string InvoiceType { get;}
        decimal BaseAmount { get;}
        decimal VATAmount { get;}
        decimal NetAmount { get;}

        //for Count
        int BizPacCount { get; }

        //for create CSV
        IAccountDetail GetDetail(int index);

        //for future use
        string TaxInvoiceNo { get;}
        DateTime TaxInvoiceDate { get;}

    }
}
