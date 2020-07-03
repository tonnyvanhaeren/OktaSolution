using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OktaSolution.config
{
    public interface IAppSettings
    {
        string MongoConnectionString { get; set; }
        string DatabaseName { get; set; }
        string OktaDomain { get; set; }
        string OktaClientId { get; set; }
        string OktaClientSecret { get; set; }
    }


    public class AppSettings : IAppSettings
    {
        public string MongoConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string OktaDomain { get; set; }
        public string OktaClientId { get; set; }
        public string OktaClientSecret { get; set; }
    }
}
