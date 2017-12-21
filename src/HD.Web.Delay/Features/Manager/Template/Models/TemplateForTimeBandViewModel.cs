using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class TemplateForTimeBandViewModel
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public ICollection<TemplateItemViewModel> TemplateItems { get; set; }
	}
}
