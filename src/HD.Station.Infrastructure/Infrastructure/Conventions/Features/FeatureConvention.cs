using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace HD.Station.Infrastructure.Conventions.Features
{
    public class FeatureConvention : IControllerModelConvention
    {
        internal const string FeatureKey = "feature";
        internal const string PathKey = "path";

        public void Apply(ControllerModel controller)
        {
            if (!controller.ControllerType.Namespace.StartsWith("HD.Station"))
                return;

            var features = GetFeatures(controller.ControllerType);

            var featureName = features.FirstOrDefault() ?? string.Empty;
            var path = string.Join("/", features);

            controller.Properties.Add(FeatureKey, featureName);
            controller.Properties.Add(PathKey, path);

            var area = features.FirstOrDefault();
            if (!string.IsNullOrEmpty(area) && area != "Home")
            {
                if (!controller.RouteValues.ContainsKey("area"))
                {
                    controller.RouteValues.Add("area", features.FirstOrDefault());
                }

                if (controller.Selectors.All(selector => selector.AttributeRouteModel == null)) {
                    foreach(var selector in controller.Selectors)
                    {
                        selector.AttributeRouteModel = new AttributeRouteModel
                        {
                            Template = "[area]/[controller]"
                        };
                    }
                }
            }
        }

        private IEnumerable<string> GetFeatures(TypeInfo controllerType)
        {
            string[] tokens = controllerType.Namespace.Split('.');

            return tokens
              .SkipWhile(t => t != "Features")
              .Skip(1);
        }
    }
}
