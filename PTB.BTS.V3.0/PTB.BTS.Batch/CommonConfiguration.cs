using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity.CommonEntity;

namespace PTB.BTS.Batch
{
    public static class CommonConfiguration
    {
        public static string MODULE_GEN = "GEN";

        public static string CONFIG_CODE_EIR_MAIL_TO = "ExpectedIncomeReport_Mail_To";
        public static string CONFIG_CODE_EIR_MAIL_CC = "ExpectedIncomeReport_Mail_CC";
        public static string CONFIG_CODE_TPITADMIN = "TPITAdmin";

        //default variable 
        private const string DF_SMTP_SERVER = "172.30.2.203";
        private const int DF_SMTP_PORT = 25;

        public static List<ApplicationConfiguration> ConfigurationProvider
        {
            get
            {
                return ConfigProvider.ConfigurationList;
            }
        }
        /// <summary>
        /// Smtp server ip or name
        /// </summary>
        public static string SmtpServer
        {
            get
            {
                try
                {
                    string configValue = ConfigProvider.GetConfigValue<string>(MODULE_GEN, "SmtpServer");

                    return configValue;
                }
                catch
                {
                    return DF_SMTP_SERVER;
                }
            }
        }

        /// <summary>
        /// Smtp server ip or name
        /// </summary>
        public static int SmtpPort
        {
            get
            {
                try
                {
                    int configValue = ConfigProvider.GetConfigValue<int>(MODULE_GEN, "SmtpPort");

                    return configValue;
                }
                catch
                {
                    return DF_SMTP_PORT;
                }
            }
        }

        /// <summary>
        /// Smtp enable SSL
        /// </summary>
        public static bool SmtpEnableSSL
        {
            get
            {
                try
                {
                    bool configValue = ConfigProvider.GetConfigValue<bool>(MODULE_GEN, "SmtpEnableSSL");

                    return configValue;
                }
                catch
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// UseDefaultCredentials
        /// </summary>
        public static bool UseDefaultCredentials
        {
            get
            {
                try
                {
                    bool configValue = ConfigProvider.GetConfigValue<bool>(MODULE_GEN, "UseDefaultCredentials");

                    return configValue;
                }
                catch
                {
                    return true;
                }
            }
        }

        /// <summary>
        /// Username to verify with SMTP server
        /// </summary>
        public static string SmtpUsername
        {
            get
            {
                try
                {
                    string configValue = ConfigProvider.GetConfigValue<string>(MODULE_GEN, "SmtpUsername");

                    return configValue;
                }
                catch
                {
                    return String.Empty;
                }
            }
        }

        /// <summary>
        /// Username's password to verify with SMTP server
        /// </summary>
        public static string SmtpPassword
        {
            get
            {
                try
                {
                    string configValue = ConfigProvider.GetConfigValue<string>(MODULE_GEN, "SmtpPassword");

                    return configValue;
                }
                catch
                {
                    return String.Empty;
                }
            }
        }

        /// <summary>
        /// The name to show on the email as sender's name
        /// </summary>
        public static string SmtpSenderDisplayName
        {
            get
            {
                try
                {
                    string configValue = ConfigProvider.GetConfigValue<string>(MODULE_GEN, "SmtpSenderDisplayName");

                    return configValue;
                }
                catch
                {
                    return String.Empty;
                }
            }
        }

        /// <summary>
        /// Email whome will receive the report
        /// </summary>
        public static string ExpectedIncomeReport_Mail_To
        {
            get
            {
                try
                {
                    string configValue = ConfigProvider.GetConfigValue<string>(MODULE_GEN, CONFIG_CODE_EIR_MAIL_TO);

                    return configValue;
                }
                catch
                {
                    return String.Empty;
                }
            }
        }

        /// <summary>
        /// Email drop in CC of sending report 
        /// </summary>
        public static string ExpectedIncomeReport_Mail_Cc
        {
            get
            {
                try
                {
                    string configValue = ConfigProvider.GetConfigValue<string>(MODULE_GEN, CONFIG_CODE_EIR_MAIL_CC);

                    return configValue;
                }
                catch
                {
                    return String.Empty;
                }
            }
        }
        
        /// <summary>
        /// TPITAdmin
        /// </summary>
        public static string TPITAdmin
        {
            get
            {
                try
                {
                    string configValue = ConfigProvider.GetConfigValue<string>(MODULE_GEN, CONFIG_CODE_TPITADMIN);

                    return configValue;
                }
                catch
                {
                    return String.Empty;
                }
            }
        }

        /// <summary>
        /// The sentence to show at the end of email
        /// </summary>
        public static string CommonEmailFooter
        {
            get
            {
                try
                {
                    string configValue = ConfigProvider.GetConfigValue<string>(MODULE_GEN, "CommonEmailFooter");

                    return configValue;
                }
                catch
                {
                    return String.Empty;
                }
            }
        }

        /// <summary>
        /// The folder store the template file
        /// </summary>
        public static string FileTemplatePath
        {
            get
            {
                try
                {
                    string configValue = ConfigProvider.GetConfigValue<string>(MODULE_GEN, "FileTemplatePath");

                    return configValue;
                }
                catch
                {
                    return String.Empty;
                }
            }
        }

         /// <summary>
        /// Temporary_Folder
        /// </summary>
        public static string TempFolder
        {
            get
            {
                try
                {
                    string configValue = ConfigProvider.GetConfigValue<string>(MODULE_GEN, "TempFolder");

                    return configValue;
                }
                catch
                {
                    return String.Empty;
                }
            }
        }

         /// <summary>
        /// Temporary_Folder
        /// </summary>
        public static string ExpectedIncomeReportNamePattern
        {
            get
            {
                try
                {
                    string configValue = ConfigProvider.GetConfigValue<string>(MODULE_GEN, "ExpectedIncomeReport_FileName");

                    return configValue;
                }
                catch
                {
                    return String.Empty;
                }
            }
        }
        
    }
}
