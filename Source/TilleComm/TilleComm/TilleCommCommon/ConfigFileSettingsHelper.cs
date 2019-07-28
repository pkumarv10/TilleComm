using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TilleCommCommon
{
    public static class ConfigFileSettingsHelper
    {
        public static string API_URL
        {
            get
            {
                return ConfigurationManager.AppSettings["API_URL"].ToString();
            }
        }
    }
}
