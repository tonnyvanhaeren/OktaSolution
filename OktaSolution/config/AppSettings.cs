using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OktaSolution.config
{
    public class AppSettings
    {
        public string MongoConnectionString { get; set; }
        public string OktaDomain { get; set; }
        public string OktaClientId { get; set; }
        public string OktaClientSecret { get; set; }
    }
}
