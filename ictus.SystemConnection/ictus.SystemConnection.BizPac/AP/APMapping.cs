using System;

using ictus.SystemConnection.BizPac.Core;

namespace ictus.SystemConnection.BizPac.AP
{
    public class APMapping : BizPacMappingBase
    {
        #region - Private -
            private IAPHeader header;
        #endregion

        public APMapping(IAPHeader header)
        {
            this.header = header;
        }

        #region - Build Method -
            protected override void buildHead(BizPacStringBuilder stringBuilder)
            {
                stringBuilder.Append(header.DocumentType);
                stringBuilder.Append(header.BizPacRefNo);
                //Change to docdate for user input : woranai 30/05/2007
                //stringBuilder.Append(header.BizPacRefDate);
                stringBuilder.Append(header.DocDate);
                stringBuilder.Append(header.VendorCode);
                stringBuilder.Append(header.VendorName);
                stringBuilder.Append(header.VendorInvoice);
                stringBuilder.Append(header.VendorDate);
                stringBuilder.Append(header.VATCode);
                stringBuilder.Append(header.VATType);
                stringBuilder.Append(header.VATCalcType);
                stringBuilder.Append(header.DueDate);
                stringBuilder.Append(header.BusinessPlace);
                stringBuilder.Append(header.BizPacRemark1);
                stringBuilder.Append(header.InvoiceType);
                stringBuilder.Append(header.BaseAmount);
                stringBuilder.Append(header.VATAmount);
                stringBuilder.Append(header.NetAmount);
            }

            protected override void buildDetail(int index, BizPacStringBuilder stringBuilder)
            {
                IAPDetail detail = (IAPDetail)header.GetDetail(index);
                stringBuilder.Append(detail.SeqNo);
                stringBuilder.Append(detail.MiscItemCode);
                stringBuilder.Append(detail.ItemDescription);
                stringBuilder.Append(detail.Quantity);
                stringBuilder.Append(detail.Price);
                stringBuilder.Append(detail.Amount);
                stringBuilder.Append(detail.BusinessUnit);
                stringBuilder.Append(detail.BizPacRemark2);
                detail = null;
            }
        #endregion

        public override int Count
        {
            get{return header.BizPacCount;}
        }
    }
}
