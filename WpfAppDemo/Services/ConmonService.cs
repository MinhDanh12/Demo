using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppDemo.Services
{
    public class ConmonService
    {
        public string GetApiUrl(string controller)
        {
            return ConfigurationManager.AppSettings["ApiUrl"] + controller ;
        }

    }
}
