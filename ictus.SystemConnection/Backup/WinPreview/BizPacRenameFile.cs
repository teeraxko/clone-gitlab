//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Windows.Forms;
//using System.IO;

//namespace WinPreview
//{
//    public class BizPacRenameFile
//    {
//        const string thePath = @"c:\BizPac\";

//        public static void RenameFile()
//        {
//            try
//            {
//                DirectoryInfo directoryInfo = new DirectoryInfo(thePath);
//                FileInfo[] fileInfo = directoryInfo.GetFiles("*.csv");

//                foreach (FileInfo infoDetail in fileInfo)
//                {
//                    string[] token = infoDetail.FullName.Split('.');
//                    string csvName = token[0] + DateTime.Now.ToString("yyMMddHHmmss");
//                    string newPath = Path.ChangeExtension(csvName, infoDetail.Extension);
//                    infoDetail.MoveTo(newPath);
//                }

//                directoryInfo = null;
//                fileInfo = null;
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show(ex.Message);
//            }
//        }
//    }
//}
