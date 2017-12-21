using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVAD.Entities.Entities.Workflow
{
    [Table("ActivityProvider", Schema = "Workflow")]
    public class ActivityProvider
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid? ParentId { get; set; }

        [ForeignKey(nameof(ParentId))]
        public ActivityProvider Parent { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public byte[] Revision { get; set; }

        public string ParameterDefination { get; set; }

        public string DesignData { get; set; }

        public string ParameterDesignData { get; set; }

        [ForeignKey(nameof(Activity.ActivityProviderId))]
        public ICollection<Activity> Activities { get; } = new HashSet<Activity>();
    }
}
