using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using ictus.Framework.ASC.AppConfig;
using System.Collections;

namespace ictus.SystemConnection.BizPac
{
    public class Ftp
    {
        #region Protected Method
        protected virtual string ftpURL
        {
            get { return ApplicationProfile.FTP_URL; }
        }

        protected virtual Encoding StreamEncode
        {
            get { return Encoding.UTF8; }
        }

        #endregion

        #region Public Method
        public void Upload(string fileName)
        {
            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpURL + fileName);
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Proxy = null;
            // This example assumes the FTP site uses anonymous logon.
            //request.Credentials = new NetworkCredential ("anonymous","janeDoe@contoso.com");

            // Copy the contents of the file to the request stream.
            StreamReader readStream = new StreamReader(fileName, StreamEncode);
            byte[] fileContents = Encoding.UTF8.GetBytes(readStream.ReadToEnd());
            readStream.Close();
            request.ContentLength = fileContents.Length;

            Stream requestStream = request.GetRequestStream();
            requestStream.Write(fileContents, 0, fileContents.Length);
            requestStream.Close();

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();

            Console.WriteLine("Upload File Complete, status {0}", response.StatusDescription);

            response.Close();
        }
        #endregion

        #region Public method for fix asset
        public bool UploadXLS(Uri serverFileNameUri, string fileName)
        {
            // The serverUri parameter should start with the ftp:// scheme.
            if (serverFileNameUri.Scheme != Uri.UriSchemeFtp)
            {
                return false;
            }

            FtpWebRequest request = null;
            FtpWebResponse response = null;

            try
            {
                // Get the object used to communicate with the server.
                request = (FtpWebRequest)WebRequest.Create(string.Concat(serverFileNameUri.ToString()));
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Proxy = null;
                request.UseBinary = true;

                //Selection of file to be uploaded
                FileInfo fileInfo = new FileInfo(fileName);
                byte[] fileContents = new byte[fileInfo.Length];

                using (FileStream fileStrem = fileInfo.OpenRead())
                {
                    fileStrem.Read(fileContents, 0, Convert.ToInt32(fileInfo.Length));
                }

                using (Stream writer = request.GetRequestStream())
                {
                    writer.Write(fileContents, 0, fileContents.Length);
                }

                response = (FtpWebResponse)request.GetResponse();
                Console.WriteLine("Upload File {0} Complete, status {1}", serverFileNameUri.AbsolutePath, response.StatusDescription);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Upload File {0} Fail, description {1}", serverFileNameUri.AbsolutePath, ex.Message);
                return false;
            }
            finally
            {
                if (response != null)
                {
                    response.Close();
                }
                response = null;
                request = null;
            }
            return true;
        }

        public bool DownloadXLS(Uri serverFileNameUri, string localFileName)
        {
            // The serverUri parameter should start with the ftp:// scheme.
            if (serverFileNameUri.Scheme != Uri.UriSchemeFtp)
            {
                return false;
            }

            FtpWebRequest request = null;
            FtpWebResponse response = null;

            try
            {
                request = (FtpWebRequest)WebRequest.Create(serverFileNameUri.ToString());
                request.Method = WebRequestMethods.Ftp.DownloadFile;

                response = (FtpWebResponse)request.GetResponse();

                using (BinaryReader reader = new BinaryReader(response.GetResponseStream()))
                {
                    using (BinaryWriter writer = new BinaryWriter(File.Open(localFileName, FileMode.Create)))
                    {
                        byte[] buffer = new byte[2048];
                        int count = reader.Read(buffer, 0, buffer.Length);

                        while (count != 0)
                        {
                            writer.Write(buffer, 0, count);
                            count = reader.Read(buffer, 0, buffer.Length);
                        }
                    }
                }

                Console.WriteLine("Dowload File {0} Complete, status : {1}", serverFileNameUri.AbsolutePath, response.StatusDescription);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Dowload File {0} Fail, description {1}", serverFileNameUri.AbsolutePath, ex.Message);
                return false;
            }
            finally
            {
                if (response != null)
                {
                    response.Close();
                }
                response = null;
                request = null;
            }
            return true;
        }

        public bool DeleteXLS(Uri serverFileNameUri)
        {
            // The serverUri parameter should use the ftp:// scheme.
            if (serverFileNameUri.Scheme != Uri.UriSchemeFtp)
            {
                return false;
            }

            FtpWebRequest request = null;
            FtpWebResponse response = null;

            try
            {
                // Get the object used to communicate with the server.
                request = (FtpWebRequest)WebRequest.Create(serverFileNameUri);
                request.Method = WebRequestMethods.Ftp.DeleteFile;

                response = (FtpWebResponse)request.GetResponse();

                Console.WriteLine("Delete File {0} Complete, status : {1}", serverFileNameUri.AbsolutePath, response.StatusDescription);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Delete File {0} Fail, description {1}", serverFileNameUri.AbsolutePath, ex.Message);
                return false;
            }
            finally
            {
                if (response != null)
                {
                    response.Close();
                }
                request = null;
                response = null;
            }

            return true;
        }
        #endregion

        #region
        // Kriangkrai A. Change encoding/decoding method to upload XLSX file
        public bool UploadXLSX(string filePath)
        {
            FtpWebRequest request = null;
            FtpWebResponse response = null;

            try
            {
                FileInfo fileInfo = new FileInfo(filePath);
                //byte[] fileContents = new byte[fileInfo.Length];

                string fileName = fileInfo.Name;

                request = (FtpWebRequest)WebRequest.Create(ftpURL + fileName);
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Proxy = null;

                StreamReader reader = new StreamReader(filePath);

                byte[] fileContents = File.ReadAllBytes(fileName);
                request.ContentLength = fileContents.Length;

                reader.Close();

                Stream requestStream = request.GetRequestStream();
                requestStream.Write(fileContents, 0, fileContents.Length);
                requestStream.Close();

                response = (FtpWebResponse)request.GetResponse();

                Console.WriteLine("Upload File Complete, status {0}", response.StatusDescription);

                response.Close();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Delete File {0} Fail, description {1}", filePath, ex.Message);
                return false;
            }
            finally
            {
                if (response != null)
                {
                    response.Close();
                }
                request = null;
                response = null;
            }
        }
        #endregion
    }
}
