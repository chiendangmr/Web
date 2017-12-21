using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Infrastructure.DataProtections
{
    public class FileSystemStorageProviderOptions
    {
        public string Location { get; set; } = "C:\\keystore";
    }
}
