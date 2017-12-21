using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class JsonResponse
	{
		public JsonResponse()
		{

		}
		public JsonResponse(string result,string message)
		{
			this.result = result;
			this.message = message;
		}
		public JsonResponse(string result, string message, Guid id)
		{
			this.result = result;
			this.message = message;
			this.id = id;
		}
		public JsonResponse(string result, string message, Guid id, object data)
		{
			this.result = result;
			this.message = message;
			this.id = id;
			this.data = data;
		}
		public string result { get; set; }
		public string message { get; set; }
		public object data { get; set; }
		public Guid id { get; set; }
	}
}
