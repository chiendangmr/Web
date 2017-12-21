using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Features.Tools.Menu.Models
{
    public class MenuViewModel
    {
        [Display(Name = "Id")]
        public Guid id { get; set; }

        [Display(Name = "Parent Id")]
        public Guid? parentId { get; set; }

        [Display(Name = "Name")]
        public string name { get; set; }

        [Display(Name = "Icon")]
        public string icon { get; set; }

        [Display(Name = "Group index")]
        public int groupIndex { get; set; }

        [Display(Name = "Index")]
        public int index { get; set; }

        [Display(Name = "Url")]
        public string url { get; set; }

        [Display(Name = "Controller name")]
        public string controlerName { get; set; }

        [Display(Name = "Action name")]
        public string actionName { get; set; }

        [Display(Name = "Area name")]
        public string areaName { get; set; }
    }
}
