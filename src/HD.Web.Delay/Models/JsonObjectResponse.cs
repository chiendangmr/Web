using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class JsonObjectResponse
	{
		public JsonObjectResponse()
		{

		}
		public JsonObjectResponse(string result, object _object)
		{
			Result = result;
			Object = _object;
		}
		public string Result { get; set; }
		public object Object { get; set; }
    }
}
