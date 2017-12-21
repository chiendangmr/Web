using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities
{
    public partial class RetailContract
    {
        public RetailContract()
        {

        }

        public Guid Id { get; set; }
		
        public virtual AnnexContract AnnexContract { get; set; }		

	}
}
