using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class PreviewViewModel
    {
        public List<string> LstPreviewUrl{ get; set; }
        public long? MarkIn { get; set; }		
		public long? MarkOut { get; set; }        
    }
}