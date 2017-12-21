using HD.TVAD.Entities.Entities.Booking;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVAD.Entities.Entities.Schedule
{
    [Table("SpotAssetByBookings", Schema = "Schedule")]
    public class SpotContentByBooking
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [ForeignKey(nameof(Id))]
        public SpotContent BaseSpotContent { get; set; }

        [ForeignKey(nameof(Id))]
        public SpotBooking Booking { get; set; }

        public SpotContentByBooking()
        {
            BaseSpotContent = new SpotContent
            {
                Id = this.Id,
                ByBooking = this
            };

            Booking = new SpotBooking
            {
                Id = this.Id,
                SpotContent = this
            };
        }
    }
}
