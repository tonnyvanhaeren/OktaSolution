using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OktaSolution.config
{
    public class AppSettings
    {
        public string ConnectionString { get; set; }
        public string Domain { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}
