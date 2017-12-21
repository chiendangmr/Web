using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Features.Home.Menu.Models
{
    public class MenuViewModel
    {
        public string originText { get; set; }

        /// <summary>
        /// Text to display
        /// </summary>
        public string text { get; set; }

        /// <summary>
        /// Disable
        /// </summary>
        public bool disabled { get; set; }

        /// <summary>
        /// Icon
        /// </summary>
        public string icon { get; set; }

        /// <summary>
        /// Begin of group
        /// </summary>
        public bool beginGroup { get; set; }

        /// <summary>
        /// Controller name
        /// </summary>
        public string url { get; set; }

        public string controllerName { get; set; }

        public string actionName { get; set; }

        public string areaName { get; set; }

        /// <summary>
        /// Sub menu
        /// </summary>
        public List<MenuViewModel> items { get; set; } = new List<MenuViewModel>();
    }
}
