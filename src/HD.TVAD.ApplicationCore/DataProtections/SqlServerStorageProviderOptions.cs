using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Infrastructure.DataProtections
{
    public class SqlServerStorageProviderOptions
    {
        public string ConnectionString { get; set; }

        public string Schema { get; set; } = "Security";
        public string TableName { get; set; } = "DataProtectionKeys";
    }
}
