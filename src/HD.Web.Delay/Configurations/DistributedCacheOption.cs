using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.Station.Configurations
{
    public enum DistributedCacheProvider
    {
        SqlServer,
        Redis
    }

    public class DistributedCacheSqlServerOption
    {
        public string ConnectionString { get; set; }
        public string SchemaName { get; set; }
        public string TableName { get; set; }
    }

    public class DistributedCacheOption
    {
        public DistributedCacheProvider Provider { get; set; }
        public DistributedCacheSqlServerOption SqlServer { get; set; }
    }
}