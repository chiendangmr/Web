using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{    
    public class AssetTypeCreateViewModel
	{
		[Required]
		public string Name { get; set; }
        public string Description { get; set; }
		[Required]
		public bool IsBroadcast { get; set; }
		[Required]
		public bool IsIndexing { get; set; }
		[Required]
		public int Index { get; set; }
        public int? FileTypeId { get; set; }
    }   
}