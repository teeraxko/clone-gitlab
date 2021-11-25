using System;
using System.IO;
using System.Collections;

namespace YST_DLV
{
    public class BizPacRenameFile
    {
        const string thePath = @"c:\BizPac\";

        public void RenameFile()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(thePath);
            FileInfo[] fileInfo = directoryInfo.GetFiles("*.csv");

            foreach (FileInfo infoDetail in fileInfo)
            {
                string[] token = infoDetail.FullName.Split('.');
                string csvName = token[0] + DateTime.Now.ToString("yyMMddHHmmss");
                string newPath = Path.ChangeExtension(csvName, infoDetail.Extension);
                infoDetail.MoveTo(newPath);
            }

            YST_Ftp ftp = new YST_Ftp();
            fileInfo = directoryInfo.GetFiles("*.csv");
            ArrayList names = new ArrayList();
            foreach (FileInfo infoDetail in fileInfo)
            {
                names.Add(infoDetail.Name);
            }

            foreach (string name in names)
            {
                ftp.Upload(name);
            }
                
            directoryInfo = null;
            fileInfo = null;
        }
    }
}
