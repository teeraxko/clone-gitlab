using System;
using ictus.Framework.ASC.VBFuntion;

namespace Entity.VehicleEntities
{
    public class SMCompulsoryDocNo : CompulsoryDocNoBase
    {
        public SMCompulsoryDocNo() : base()
        {
        }


        public override string DefaultPrefix
        {
            get { return "SMD"; }
        }

        public override string DefaultFullPrefix
        {
            get { return "SMD/VC/" + yearString; }
        }

        public override string DefaultEndorsement
        {
            get { return "00"; }
        }
        
        public override string GetTaxInvoiceNo(CompulsoryFragment value)
        {
            string temp;
            if (value.Prefix.Length >= 9)
            {
                temp = value.Prefix.Substring(7, 2);
            }
            else
            {
                temp = yearString;
            }

            return "VC" + temp + "/SM-" + value.Number.ToString() + "-" + value.Endorsement;
        }

        public override string GetTaxInvoiceNo(string prefix, string number, string endorsement)
        {
            string temp;
            if (prefix.Length >= 9)
            {
                temp = prefix.Substring(7, 2);
            }
            else
            {
                temp = yearString;
            }

            return "VC" + temp + "/SM-" + number.ToString() + "-" + endorsement;
        }

        public override string GetCompulsoryNo(CompulsoryFragment value)
        {
            return value.Prefix + "-" + value.Number + "-" + value.Endorsement;
        }

        public override string GetCompulsoryNo(string prefix, string number, string endorsement)
        {
            return prefix + "-" + number + "-" + endorsement;
        }

        public override CompulsoryFragment GetCompulsoryFragment(string compulsoryNo)
        {
            CompulsoryFragment compulsoryFragment = new CompulsoryFragment();
            string[] token = compulsoryNo.Split('-');
            compulsoryFragment.Prefix = token[0];
            if (token.Length > 1)
            {
                compulsoryFragment.Number = token[1];
            }
            if (token.Length > 2)
            {
                compulsoryFragment.Endorsement = token[2];
            }
            token = null;
            return compulsoryFragment;
        }
    }
}
