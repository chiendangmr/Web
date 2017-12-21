using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{    
    public class AssetTypeViewModel
    {
        public Guid Id { get; set; }
		[Required]
		public string Name { get; set; }
        public string Description { get; set; }
        public bool IsBroadcast { get; set; }
        public bool IsIndexing { get; set; }
        public int Index { get; set; }
        public int? FileTypeId { get; set; }
        public string FileTypeName { get; set; }
    }   
}