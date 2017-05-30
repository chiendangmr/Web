using System;
using System.Collections.Generic;

namespace OnAir.Data
{
    public partial class TblMcsservers
    {
        public TblMcsservers()
        {
            V4branch = new HashSet<V4branch>();
        }

        public int Mcsid { get; set; }
        public string Mcsname { get; set; }
        public string Mcsdescription { get; set; }
        public string Mcsipaddress { get; set; }
        public int McscontrolPort { get; set; }
        public int? McsinputPort { get; set; }
        public int? McsinputRouterId { get; set; }
        public int? McsoutputPort { get; set; }
        public int? McsoutputRouterId { get; set; }
        public int? Mcsstatus { get; set; }
        public string McsclassName { get; set; }
        public string McsdllName { get; set; }

        public virtual ICollection<V4branch> V4branch { get; set; }
    }
}
