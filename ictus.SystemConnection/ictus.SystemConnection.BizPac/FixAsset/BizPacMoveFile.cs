using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.IO;

namespace ictus.SystemConnection.BizPac.FixAsset
{
    public class BizPacMoveFile
    {
        #region Constant
        protected const string FTP_PATH = @"ftp://bizpacftp:password@172.30.2.164:21/TIS/TEST/";
        //protected const string FTP_PATH = @"ftp://bizpacftp:password@172.30.2.164:21/TIS/";
        const string LOCAL_PATH = @"C:\FIX_FTP\";
        #endregion

        protected virtual Hashtable GetFileFixAsset()
        {
            return null;
        }

        public void MoveFile()
        {
            //Get all file fix asset
            Hashtable fixFile = GetFileFixAsset();

            Ftp ftp = new Ftp();
            Uri serverFileNameUri = null, serverPathBackupUri = null;

            foreach (DictionaryEntry value in fixFile)
            {
                //Rename file
                string[] token = value.Value.ToString().Split('.');
                string fileName = string.Concat(token[0], DateTime.Now.ToString("yyyyMMddHHmmss", System.Globalization.CultureInfo.CreateSpecificCulture("en-US")), ".", token[1]);
                string localFileName = string.Concat(LOCAL_PATH, fileName);
                string ftpBackupPath = value.Key.ToString().Replace(value.Value.ToString(), @"Backup/");
                //Create uri of server

                serverPathBackupUri = new Uri(string.Concat(ftpBackupPath, fileName));
                serverFileNameUri = new Uri(value.Key.ToString());

                //Dowload from server to local
                if (ftp.DownloadXLS(serverFileNameUri, localFileName))
                {
                    //Upload from local to server
                    if (ftp.UploadXLS(serverPathBackupUri, localFileName))
                    {
                        //Delete file on local
                        File.Delete(localFileName);

                        //Delete file on server
                        ftp.DeleteXLS(serverFileNameUri);
                    }
                }
            }

            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
        }
    }
}
