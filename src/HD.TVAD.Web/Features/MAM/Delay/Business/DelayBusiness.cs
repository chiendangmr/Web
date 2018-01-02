using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.Web.Models;
using HD.TVAD.Web.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Features.MAM.Content.Business
{
    public class DelayBusiness
    {
        private readonly IOptions<Settings> _settings;        
        private readonly IHostingEnvironment _hostingEnvironment;        
        public DelayBusiness(IHostingEnvironment hostingEnvironment, IOptions<Settings> settings)
        {           
            _hostingEnvironment = hostingEnvironment;
            _settings = settings;
        }       
    }
}
