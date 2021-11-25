using System;

namespace YST_DLV
{
    class Program
    {
        static void Main(string[] args)
        {
            BizPacRenameFile bizPacRenameFile = new BizPacRenameFile();
            bizPacRenameFile.RenameFile();
            bizPacRenameFile = null;
        }
    }
}
