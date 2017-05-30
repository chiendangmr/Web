using System;
using System.Collections.Generic;

namespace OnAir.Data
{
    public partial class TblShapes
    {
        public int ShapeId { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string BackColor { get; set; }
        public string ForeColor { get; set; }
        public string Draw2DclassName { get; set; }
    }
}
