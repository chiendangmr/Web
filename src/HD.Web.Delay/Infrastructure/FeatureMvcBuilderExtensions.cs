using HD.Station.Infrastructure.Conventions.Features;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Infrastructure
{
    public static class FeatureMvcBuilderExtensions
    {
        public static IMvcBuilder AddFeatureViewLayout(this IMvcBuilder builder)
        {
            builder.AddMvcOptions(opt => opt.Conventions.Add(new FeatureConvention()));
            builder.AddRazorOptions(opt =>
            {
                opt.ViewLocationFormats.Insert(0, "/Features/Shared/{0}.cshtml");
                opt.ViewLocationFormats.Insert(0, "/Features/Shared/Views/{0}.cshtml");
                opt.ViewLocationFormats.Insert(0, "/Features/{feature}/{0}.cshtml");
                opt.ViewLocationFormats.Insert(0, "/Features/{feature}/Views/{0}.cshtml");
                opt.ViewLocationFormats.Insert(0, "/Features/{feature}/{1}/{0}.cshtml");
                opt.ViewLocationFormats.Insert(0, "/Features/{feature}/{1}/Views/{0}.cshtml");

                opt.AreaViewLocationFormats.Insert(0, "/Features/Shared/{0}.cshtml");
                opt.AreaViewLocationFormats.Insert(0, "/Features/Shared/Views/{0}.cshtml");
                opt.AreaViewLocationFormats.Insert(0, "/Features/{feature:shared}/Shared/{0}.cshtml");
                opt.AreaViewLocationFormats.Insert(0, "/Features/{feature:shared}/Shared/Views/{0}.cshtml");
                opt.AreaViewLocationFormats.Insert(0, "/Features/{feature}/{0}.cshtml");
                opt.AreaViewLocationFormats.Insert(0, "/Features/{feature}/Views/{0}.cshtml");
                opt.AreaViewLocationFormats.Insert(0, "/Features/{feature}/{1}/{0}.cshtml");

                // TODO: should remove after migrate all
                opt.AreaViewLocationFormats.Insert(0, "/Features/{2}/Shared/{0}.cshtml");
                opt.AreaViewLocationFormats.Insert(0, "/Features/{2}/Shared/Views/{0}.cshtml");
                opt.AreaViewLocationFormats.Insert(0, "/Features/{2}/{1}/{0}.cshtml");
                opt.AreaViewLocationFormats.Insert(0, "/Features/{2}/{1}/Views/{0}.cshtml");

                opt.ViewLocationExpanders.Add(new FeatureViewLocationExpander());
            });

            return builder;
        }
    }
}
