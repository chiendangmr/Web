using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Infrastructure
{
	public class SetThemeAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext context)
		{
			var theme = context.HttpContext.Request.Cookies["theme"];
			if (theme != "")
			{
				var controller = context.Controller as Controller;
				if (controller == null) return;
				controller.ViewBag.Theme = theme;
			}
			base.OnActionExecuting(context);
		}
	}
}
