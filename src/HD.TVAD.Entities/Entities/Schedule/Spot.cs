using HD.TVAD.Entities.Entities.Booking;
using HD.TVAD.Entities.Entities.System;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVAD.Entities.Entities.Schedule
{
    [Table("Spots", Schema = "Schedule")]
    public class Spot
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public DateTime BroadcastDate { get; set; }

        public Guid TimeBandSliceId { get; set; }

        [ForeignKey(nameof(TimeBandSliceId))]
        public TimeBandSlice TimeBandSlice { get; set; }

        public string Description { get; set; }

        [ForeignKey(nameof(SpotBooking.SpotId))]
        public ICollection<SpotBooking> Bookings { get; } = new HashSet<SpotBooking>();

        [ForeignKey(nameof(SpotContent.SpotId))]
        public ICollection<SpotContent> Contents { get; } = new HashSet<SpotContent>();
    }
}
