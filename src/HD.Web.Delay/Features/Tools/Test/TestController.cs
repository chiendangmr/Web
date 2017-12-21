using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using HD.TVAD.Web.Features.Tools.Test.Models;
using HD.TVAD.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace HD.TVAD.Web.Features.Tools.Test
{
    [Area("Tools")]
    public class TestController : Controller
    {
        readonly ITimeBandBaseService _timeBandService;
        public TestController(ITimeBandBaseService timeBandService)
        {
            _timeBandService = timeBandService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public object Get(DataSourceLoadOptions loaderOption)
        {
            //var query = new List<TestModel>()
            //{
            //    new TestModel
            //    {
            //        Id = 1,
            //        Code = "1",
            //        Name = "1"
            //    },
            //    new TestModel
            //    {
            //        Id = 2,
            //        Code = "2",
            //        Name = "2"
            //    },
            //    new TestModel
            //    {
            //        Id = 3,
            //        Code = "10",
            //        Name = "10"
            //    },
            //    new TestModel
            //    {
            //        Id = 4,
            //        Code = "A1",
            //        Name = "A1"
            //    },
            //    new TestModel
            //    {
            //        Id = 5,
            //        Code = "A2",
            //        Name = "A2"
            //    },
            //    new TestModel
            //    {
            //        Id = 6,
            //        Code = "A10",
            //        Name = "A10"
            //    },
            //    new TestModel
            //    {
            //        Id = 7,
            //        Code = "B1",
            //        Name = "B1"
            //    },
            //    new TestModel
            //    {
            //        Id = 8,
            //        Code = "B2",
            //        Name = "B2"
            //    },
            //    new TestModel
            //    {
            //        Id = 9,
            //        Code = "B10",
            //        Name = "B10"
            //    },
            //    new TestModel
            //    {
            //        Id = 10,
            //        Code = "1A",
            //        Name = "1A"
            //    },
            //    new TestModel
            //    {
            //        Id = 11,
            //        Code = "2A",
            //        Name = "2A"
            //    },
            //    new TestModel
            //    {
            //        Id = 12,
            //        Code = "10A",
            //        Name = "10A"
            //    }
            //};

            var query = _timeBandService.GetAll()
                .Select(t => new TestModel
                {
                    Id = t.Id,
                    ParentId = t.ParentId,
                    Code = t.Name,
                    Name = t.Name
                });
            return DataSourceLoader.Load(query, loaderOption);
        }
    }
}
