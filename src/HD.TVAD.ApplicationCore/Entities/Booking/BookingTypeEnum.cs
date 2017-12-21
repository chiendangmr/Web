using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HD.TVAD.ApplicationCore.Entities.Booking
{
    public enum BookingTypeEnum
	{
		[Display(Name = "All")]
		All = 0,
		[Display(Name = "Booking has contract")]
        Contract = 1,
        [Display(Name = "Retail booking")]
        Retail = 2,
        [Display(Name = "Booking")]
        Contract_Booking = 3,
        [Display(Name = "Booking with sponsor")]
        Contract_Sponsor = 4,
        [Display(Name = "Booking in sponsor program")]
        Contract_Sponsor_InProgram = 5,
        [Display(Name = "Booking out sponsor program")]
        Contract_Sponsor_OutProgram = 6,
        [Display(Name = "Trailer booking")]
        Contract_Sponsor_Trailer = 7,
        [Display(Name = "Benefit")]
        Contract_Sponsor_Benefit = 8
    }
}
