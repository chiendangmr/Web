using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HD.TVAD.ApplicationCore.Entities.ContractSchema
{
    public enum CustomerTypeEnum
    {
        [Display(Name = "Retail customer")]
        Retail = 0,
        [Display(Name = "Permanent customer")]
        Permanent = 1,
        [Display(Name = "No permanent customer")]
        NoPermanent = 2
    }
}
