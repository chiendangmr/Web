using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
	public class UpdateContentJsonResult
	{
		public bool Succeeded { get; set; }
		public Guid? Id { get; set; }
		public string Message { get; set; }
		public string DebugMessage { get; set; }
		public IEnumerable<string> Errors { get; set; }
    }
}