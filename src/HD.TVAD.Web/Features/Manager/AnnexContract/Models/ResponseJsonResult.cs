using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class ResponseJsonResult
	{
		public ResponseJsonResult()
		{
		}
		public bool Succeeded;
		public Guid Id;
		public object Data;
		public string Message;
	}
}
