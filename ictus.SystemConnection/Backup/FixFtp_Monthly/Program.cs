using System;

namespace FixFtp_Monthly
{
    class Program
    {
        static void Main(string[] args)
        {
            BizPacMonthly bp = new BizPacMonthly();
            bp.MoveFile();
            bp = null;
        }
    }
}
