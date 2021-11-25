using System;
using ictus.SystemConnection.BizPac.Core;
using System.Collections.Generic;

using ictus.Common.Entity.General;

namespace ictus.SystemConnection.BizPac
{
    public class BizPacConnect : BizPacConnectBase
    {
        private BizPacConnectBase bizPacConnect;
        public BizPacConnect()
        {
            bizPacConnect = new BizPacCSVConnect();
        }

        public override string Connect(ListBase listData)
        {
            return bizPacConnect.Connect(listData);
        }

        public override bool Connect(string fileName, List<string> lines)
        {
            return bizPacConnect.Connect(fileName, lines);
        }
        
        // Kriangkrai A.
        public override bool Connect(string fileName)
        {
            return bizPacConnect.Connect(fileName);
        }

        public override bool ReConnect(string fileName, BizPacMappingBase data)
        {
            return bizPacConnect.ReConnect(fileName, data);
        }

        public override bool CancelConnect(string fileName)
        {
            return bizPacConnect.CancelConnect(fileName);
        }
    }
}
