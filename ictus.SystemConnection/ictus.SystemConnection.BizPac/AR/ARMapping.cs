using System;

using ictus.SystemConnection.BizPac;
using ictus.SystemConnection.BizPac.Core;

namespace ictus.SystemConnection.BizPac.AR
{
    public class ARMapping : BizPacMappingBase
    {
        #region - Private -
            private IARHeader header;
        #endregion

        public ARMapping(IARHeader header)
        {
            this.header = header;
        }

        #region - Build Method -
            protected override void buildHead( BizPacStringBuilder stringBuilder)
            {
                stringBuilder.Append(header.DocumentType);
                stringBuilder.Append(header.BizPacRefNo);
                stringBuilder.Append(header.DocDate);
                stringBuilder.Append(header.CustomerCode);
                stringBuilder.Append(header.CustomerName);
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
                IARDetail detail = (IARDetail)header.GetDetail(index);
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
