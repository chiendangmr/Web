using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Storage.Models
{   
    public class StorageLocationAccessZoneViewModel
    {
        public Guid Id { get; set; }
        public Guid StorageLocationAccessId { get; set; }
        public string StorageLocationAccessName { get; set; }
        public Guid AccessZoneId { get; set; }
        public string AccessZoneName { get; set; }
    }   
}