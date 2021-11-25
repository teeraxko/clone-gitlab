using System;

using ictus.SystemConnection.BizPac.Core;

namespace ictus.SystemConnection.BizPac
{
    public abstract class BizPacMappingBase
    {
        protected abstract void buildHead(BizPacStringBuilder stringBuilder);
        protected abstract void buildDetail(int index, BizPacStringBuilder stringBuilder);

        public abstract int Count {get;}

        public virtual string GetLine(int index)
        { 
            BizPacStringBuilder stringBuilder = new BizPacStringBuilder();
            buildHead(stringBuilder);
            buildDetail(index, stringBuilder);
            string result = stringBuilder.ToString();
            stringBuilder = null;
            return result;
        }
    }
}
