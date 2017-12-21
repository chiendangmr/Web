using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;
using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.ApplicationCore.Entities.Booking;

namespace HD.TVAD.Web.Models
{
    public class ChangeToBookingInFromBookingOutViewModel
	{
		[Required]
		public Guid Id { get; set; }
	}
}
