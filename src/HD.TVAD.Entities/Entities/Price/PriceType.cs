using HD.TVAD.Entities.Entities.Booking;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVAD.Entities.Entities.Price
{
    [Table("PriceTypes", Schema = "Price")]
    public class PriceType
    {
        [Key]
        public PriceTypeEnum Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [ForeignKey(nameof(BookingType_PriceType.PriceTypeId))]
        public ICollection<BookingType_PriceType> BookingTypes { get; } = new HashSet<BookingType_PriceType>();

        [ForeignKey(nameof(PriceTypeDetail.TypeId))]
        public ICollection<PriceTypeDetail> Details { get; } = new HashSet<PriceTypeDetail>();
    }

    public enum PriceTypeEnum : int
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
