using System;
using System.Text;
using System.Globalization;

namespace ictus.SystemConnection.BizPac.Core
{
    public class BizPacStringBuilder
    {
        StringBuilder stringBuilder;
        private static CultureInfo cultureInfo = new CultureInfo("en-GB");

        public BizPacStringBuilder()
        {
            stringBuilder = new StringBuilder();
        }

        #region - Private Method -
            private string getString(string value)
            {
                return value.Replace(',', ' '); 
            }

            private string getString(DateTime value)
            {
                return value.ToString("yyyyMMdd", cultureInfo);
            }

            private string getString(decimal value)
            {
                return value.ToString();
            }

            private void append(string value)
            {
                if (stringBuilder.ToString().Trim() != "")
                { 
                    stringBuilder.Append(",");
                }
                stringBuilder.Append(value);
            }
        #endregion

        public void Append(string value)
        {
            append(getString(value));
        }

        public void Append(DateTime value)
        {
            append(getString(value));
        }

        public void Append(decimal value)
        {
            append(getString(value));
        }

        public override string ToString()
        {
            return stringBuilder.ToString();
        }
    }
}
