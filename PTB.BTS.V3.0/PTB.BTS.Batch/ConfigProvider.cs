using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity.CommonEntity;
using System.Configuration;

namespace PTB.BTS.Batch
{
    public static class ConfigProvider
    {
        private static List<ApplicationConfiguration> configurationList;

        static ConfigProvider()
        {
            LoadConfigurations();
        }

        public static List<ApplicationConfiguration> ConfigurationList
        {
            get
            {
                return configurationList;
            }
        }

        private static void LoadConfigurations()
        {
            if (configurationList == null || configurationList.Count == 0)
            {
                DbConfigReader configReader = new DbConfigReader();
                try
                {
                    configurationList = configReader.LoadConfigs(String.Empty, String.Empty);
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
        }

        public static T GetConfigValue<T>(string module, string configCode)
        {
            ApplicationConfiguration config = configurationList.Where(c => c.Module.Equals(module)
                                                                  && c.ConfigCode.Equals(configCode))
                                                            .FirstOrDefault();
            if (config == null)
            {
                throw new Exception(String.Format("Configuration not found {0}:{1}", typeof(T), config.ValueType));
            }

            string messageTypeNotMatch = "Type {0} from user is not match with Value Type {1}.";
            switch (config.ValueType)
            {
                case "BOOLEAN":
                    if (typeof(T) != typeof(Boolean))
                    {
                        throw new Exception(String.Format(messageTypeNotMatch, typeof(T), config.ValueType));
                    }
                    else if (config.ConfigValue.Equals("0"))
                    {
                        config.ConfigValue = "false";
                    }
                    else if (config.ConfigValue.Equals("1"))
                    {
                        config.ConfigValue = "true";
                    }
                    break;

                case "DATETIME":
                    if (typeof(T) != typeof(DateTime))
                    {
                        throw new Exception(String.Format(messageTypeNotMatch, typeof(T), config.ValueType));
                    }
                    break;

                case "DOUBLE":
                    if (typeof(T) != typeof(Double))
                    {
                        throw new Exception(String.Format(messageTypeNotMatch, typeof(T), config.ValueType));
                    }
                    break;

                case "INTEGER":
                    if (typeof(T) != typeof(Int32))
                    {
                        throw new Exception(String.Format(messageTypeNotMatch, typeof(T), config.ValueType));
                    }
                    break;

                case "STRING":
                    if (typeof(T) != typeof(String))
                    {
                        throw new Exception(String.Format(messageTypeNotMatch, typeof(T), config.ValueType));
                    }
                    break;

                default:
                    throw new Exception(String.Format(messageTypeNotMatch, typeof(T), config.ValueType));
            }
            return (T)Convert.ChangeType(config.ConfigValue, typeof(T));
        }
    }
}
