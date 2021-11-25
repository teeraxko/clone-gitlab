using System;

namespace FixFtp_OnDemand
{
    class Program
    {
        static void Main(string[] args)
        {
            BizPacOndemand bp = new BizPacOndemand();
            bp.MoveFile();
            bp = null;
        }
    }
}
