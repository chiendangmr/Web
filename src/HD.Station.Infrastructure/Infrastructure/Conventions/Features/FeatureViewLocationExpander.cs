using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Razor;

namespace HD.Station.Infrastructure.Conventions.Features
{
    public class FeatureViewLocationExpander : IViewLocationExpander
    {

        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            var actionDescriptor = context.ActionContext.ActionDescriptor as ControllerActionDescriptor;

            var featureName = string.Empty;
            var path = string.Empty;
            if (actionDescriptor != null && actionDescriptor.Properties.ContainsKey(FeatureConvention.FeatureKey))
            {
               featureName = actionDescriptor.Properties[FeatureConvention.FeatureKey] as string;
               path = actionDescriptor.Properties[FeatureConvention.PathKey] as string;
            }

            foreach (var location in viewLocations)
            {
                yield return location.Replace("{feature:shared}", featureName).Replace("{feature}", path);
            }
        }

        public void PopulateValues(ViewLocationExpanderContext context)
        {
            // Do no thing
        }
    }
}
