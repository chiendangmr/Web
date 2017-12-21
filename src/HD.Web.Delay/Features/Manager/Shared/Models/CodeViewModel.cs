using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;
using HD.TVAD.ApplicationCore.Entities;

namespace HD.TVAD.Web.Models
{
    public class CodeViewModel
    {
		
		public Guid Id { get; set; }
		[Display(Name = "Code")]
		public int Code { get; set; }
		public string StringCode { get; set; }
	}
}
