using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Storage.Models
{
    public class StorageLocationAccessViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }        
        public Guid StorageLocationId { get; set; }
        public string StorageLocationName { get; set; }
        public Guid StorageLocationAccessTypeId { get; set; }
        public string StorageLocationAccessTypeName { get; set; }
        public string Identity { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int? Port { get; set; }
        public string Path { get; set; }
        public bool Readable { get; set; }
        public bool Writeable { get; set; }
    }
}