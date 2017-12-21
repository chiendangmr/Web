using HD.TVAD.Web.Services;
using HD.TVAD.ReportLibrary;
using HD.TVAD.ReportLibrary.Asset;
using HD.TVAD.ReportLibrary.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HD.TVAD.ReportLibrary
{
    public class AssetDataSource: DataSource<AssetViewModel>
    {
		public AssetDataSource(IContentService service)
		{
			Data = service.GetAll()
				.Select(a => new AssetViewModel()
				{
					ApproveComment = "ok",
					Code = a.Code,
					Duration = a.BlockDuration,
					ProducerName = a.Producer.Name,
					ProductName = a.ProductName,
					Register = a.Register.Name
			}).ToList();
		}
    }
}
