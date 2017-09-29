using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class Menus
    {
        public Menus()
        {
            MenuPermissions = new HashSet<MenuPermissions>();
        }

        public Guid Id { get; set; }
        public Guid? ParentId { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public int GroupIndex { get; set; }
        public int Index { get; set; }
        public string Url { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Area { get; set; }

        public virtual ICollection<MenuPermissions> MenuPermissions { get; set; }
        public virtual Menus Parent { get; set; }
        public virtual ICollection<Menus> InverseParent { get; set; }
    }
}
