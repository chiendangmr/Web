using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HD.TVAD.ApplicationCore.Entities.UI
{
    [Table("Menus", Schema = "UI")]
    public partial class Menu
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public string Icon { get; set; }

        public int GroupIndex { get; set; }

        public int Index { get; set; }

        public string Url { get; set; }

        public Guid? ParentId { get; set; }

        [ForeignKey(nameof(ParentId))]
        public virtual Menu Parent { get; set; }

        [ForeignKey(nameof(ParentId))]
        public virtual ICollection<Menu> Childrens { get; } = new HashSet<Menu>();

        [ForeignKey("MenuId")]
        public virtual ICollection<Menu_Permission> Menu_Permissions { get; } = new HashSet<Menu_Permission>();
        
    }
}
