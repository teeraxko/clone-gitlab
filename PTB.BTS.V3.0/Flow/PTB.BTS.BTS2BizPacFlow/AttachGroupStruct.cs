using System;

namespace PTB.BTS.BTS2BizPacFlow
{
    public struct AttachGroupStruct
    {
        public int groupCode;
        public int GroupCode
        {
            get { return groupCode; }
            set { groupCode = value; }
        }

        public string groupDescription;
        public string GroupDescription
        {
            get { return groupDescription; }
            set { groupDescription = value; }
        }

        public string customerCode;
        public string CustomerCode
        {
            get { return customerCode; }
            set { customerCode = value; }
        }

        public string debitNote;
        public string DebitNote
        {
            get { return debitNote; }
            set { debitNote = value; }
        }
    }
}
