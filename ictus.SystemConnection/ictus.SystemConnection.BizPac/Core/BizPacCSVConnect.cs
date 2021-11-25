using System;
using System.Text;
using System.Collections.Generic;
using System.IO;

using ictus.Common.Entity.General;
using System.Net;

namespace ictus.SystemConnection.BizPac.Core
{
    public class BizPacCSVConnect : BizPacConnectBase
    {
        #region - Private -
        // [TODO] Kriangkrai A. 13/2/2019 Allow other method call to get filename 
        private static string getFileName(BizPacMappingBase header)
        //public static string getFileName(BizPacMappingBase header)
        {
            StringBuilder stringBuilder = new StringBuilder("PTB_BTS_");
            switch (Common.GetBizPacConnectType(header))
            {
                case BizPacConnectType.AP:
                    {
                        stringBuilder.Append("AP_");
                        break;
                    }
                case BizPacConnectType.AR:
                    {
                        stringBuilder.Append("AR_");
                        break;
                    }
                default:
                    {
                        throw new Exception("Create New BizPacMappingBase");
                    }
            }
            stringBuilder.Append(DateTime.Now.ToString("yyMMddHHmmss"));
            stringBuilder.Append(".CSV");
            return stringBuilder.ToString();
        }
        #endregion

        //=================================== private method ===================================
        private string createCSV(string fileName, ListBase listData)
        {
            string result = "";

            using (StreamWriter writeSm = new StreamWriter(fileName))
            {
                BizPacMappingBase data;
                writeSm.Flush();

                foreach (IAccountHeader item in listData)
                {
                    data = ObjectCreater.GetBizPacMapping(item);
                    for (int j = 0; j < data.Count; j++)
                    {
                        writeSm.WriteLine(data.GetLine(j));
                        result = fileName;
                    }
                }
            }

            return result;
        }

        private static bool createCSV(string fileName, List<string> lines)
        {
            bool result = false;

            using (StreamWriter writeSm = new StreamWriter(fileName))
            {
                writeSm.Flush();

                foreach (string item in lines)
                {
                    writeSm.WriteLine(item);
                    result = true;
                }
            }

            return result;
        }

        //=================================== Public method ===================================
        public override string Connect(ListBase listData)
        {
            string fileName = createCSV(getFileName(ObjectCreater.GetBizPacMapping((IAccountHeader)listData.BaseGet(0))), listData);
            //return fileName;
            try
            {
                if (fileName == "")
                {
                    return fileName;
                }
                else
                {
                    //paez upload file to bizpac ftp
                    Ftp ftp = new Ftp();
                    ftp.Upload(fileName);

                    // delete file in local
                    FileInfo f = new FileInfo(fileName);
                    f.Delete();

                    return fileName;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public override bool Connect(string fileName, List<string> lines)
        {
            bool writeFileCompleted = createCSV(fileName, lines);
            //return writeFileCompleted;
            try
            {
                if (writeFileCompleted)
                {
                    //paez upload file to bizpac ftp
                    Ftp ftp = new Ftp();
                    ftp.Upload(fileName);

                    // delete file in local
                    FileInfo f = new FileInfo(fileName);
                    f.Delete();

                    return writeFileCompleted;
                }
                else
                {
                    return writeFileCompleted;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Kriangkrai A. 13/2/2019 Change to connect to SAP
        public override bool Connect(string fileName)
        {
            try
            {
                if (fileName == "")
                {
                    return false;
                }
                else
                {
                    FileInfo f = new FileInfo(fileName);
                    Ftp ftp = new Ftp();

                    if (f.Extension.ToLower().Equals(".csv"))
                    {
                        //paez upload file to bizpac ftp
                        ftp.Upload(fileName);
                    }
                    else
                    {
                        ftp.UploadXLSX(fileName);
                    }

                    // delete file in local
                    f.Delete();
                }

                return true;
            }
            catch (WebException e)
            {
                String status = ((FtpWebResponse)e.Response).StatusDescription + "FileName: " + fileName;

                //throw e;
                throw new Exception(status);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public override bool ReConnect(string fileName, BizPacMappingBase data)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override bool CancelConnect(string fileName)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
