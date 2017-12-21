using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HD.TVAD.ApplicationCore.Entities.ContractSchema
{
    public enum SponsorTypeEnum
    {
        [Display(Name = "Sponsor for buy copyright")]
        Copyright = 1,
        [Display(Name = "Sponsor for production")]
        Production = 2
    }
}
