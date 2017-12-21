using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CopyMediaFromOld.DAO
{
    public class tblClip : tblBang
    {
        public string RealTCIn { get; set; }

        public string RealTCOut { get; set; }

        public string TCIn { get; set; }

        public string TCOut { get; set; }

        public bool HasDownLoad { get; set; }

        public DateTime RecordDate { get; set; }
    }
}
