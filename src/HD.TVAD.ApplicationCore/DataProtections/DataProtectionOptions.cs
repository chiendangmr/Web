using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Infrastructure.DataProtections
{
    public class DataProtectionOptions
    {
        public KeyStorageProviders KeyStorageProvider { get; set; } = KeyStorageProviders.FileSystem;

        public FileSystemStorageProviderOptions FileSystemStorageProvider { get; set; } = new FileSystemStorageProviderOptions();
        public SqlServerStorageProviderOptions SqlServerStorageProvider { get; set; } = new SqlServerStorageProviderOptions();
    }
}
