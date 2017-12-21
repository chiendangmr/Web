using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HD.TVAD.Entities.Entities.UI
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

        public int GroupIndex { get; set; } = 99;

        public int Index { get; set; } = 99;

        public string Url { get; set; }

        public string Controller { get; set; }

        public string Action { get; set; }

        public string Area { get; set; }

        public Guid? ParentId { get; set; }

        [ForeignKey(nameof(ParentId))]
        public Menu Parent { get; set; }

        [ForeignKey(nameof(ParentId))]
        public ICollection<Menu> Childrens { get; } = new HashSet<Menu>();

        [ForeignKey(nameof(Menu_Permission.MenuId))]
        public ICollection<Menu_Permission> Menu_Permissions { get; } = new HashSet<Menu_Permission>();
        
    }
}
