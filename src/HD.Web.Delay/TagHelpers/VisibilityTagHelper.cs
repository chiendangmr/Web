using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace HD.Station.TagHelpers
{
    [HtmlTargetElement("div", Attributes = VisibleWhenAttributeName)]
    [HtmlTargetElement("ul", Attributes = VisibleWhenAttributeName)]
	[HtmlTargetElement("li", Attributes = VisibleWhenAttributeName)]
	public class VisibilityTagHelper : TagHelper
    {
        private const string VisibleWhenAttributeName = "visible-when";
        public bool VisibleWhen { get; set; } = true;
        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            if (!VisibleWhen)
            {
                output.SuppressOutput();
            }

            return base.ProcessAsync(context, output);
        }
    }
}
