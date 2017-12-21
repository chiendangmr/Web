using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Storage.Models
{    
    public class AssetTypeViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string DefaultPath { get; set; }
        public Byte[] Revision { get; set; }
        public bool Editable { get; set; }        
    }   
}