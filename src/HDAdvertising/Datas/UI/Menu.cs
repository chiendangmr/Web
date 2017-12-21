using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HDAdvertising.Datas.UI
{
    /// <summary>
    /// Menu object
    /// </summary>
    public partial class Menu
    {
        public Menu()
        {
            Id = Guid.NewGuid();
            GroupIndex = -1;
        }

        /// <summary>
        /// Id of menu
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Id of parent menu
        /// </summary>
        public Guid? ParentId { get; set; }

        /// <summary>
        /// Parent menu
        /// </summary>
        public Menu Parent { get; set; }

        /// <summary>
        /// Childrens menu
        /// </summary>
        public ICollection<Menu> Childrens { get; } = new List<Menu>();

        /// <summary>
        /// Name of menu
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Icon of menu
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// Group index
        /// </summary>
        public int GroupIndex { get; set; }

        /// <summary>
        /// Visible index on parent
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// Url call
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Permissions request
        /// </summary>
        public ICollection<Menu_Permission> Permissions { get; } = new List<Menu_Permission>();
    }
}
