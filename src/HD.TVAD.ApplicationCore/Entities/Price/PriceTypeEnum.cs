using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HD.TVAD.ApplicationCore.Entities.Price
{
    public enum PriceTypeEnum
    {
        /// <summary>
        /// Miễn phí
        /// </summary>
        [Display(Name = "Free")]
        Free = 0,
        /// <summary>
        /// Theo cận trên
        /// </summary>
        [Display(Name = "Ceiling")]
        Ceiling = 1,
        /// <summary>
        /// Theo tỉ lệ block
        /// </summary>
        [Display(Name = "Rate")]
        Rate = 2,
        /// <summary>
        /// Theo tỉ lệ của 1 block cố định
        /// </summary>
        [Display(Name = "Rate by one block")]
        RateByBlock = 3,
        /// <summary>
        /// Thu lẻ
        /// </summary>
        [Display(Name = "Retail")]
        Retail = 4,
        /// <summary>
        /// Quyền lợi phụ
        /// </summary>
        [Display(Name = "Benefit")]
        Benefit = 5,
        /// <summary>
        /// Giá trực tiếp
        /// </summary>
		[Display(Name = "Special")]
		Special = 6
	}
}
