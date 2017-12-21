using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities
{
	public partial class AnnexContractType
	{
		public AnnexContractType()
		{
			AnnexContracts = new HashSet<AnnexContract>();
			SponsorPrograms = new HashSet<SponsorProgram>();
		}

		public Guid Id { get; set; }
		public Guid? ParentId { get; set; }
		public int BookingTypeId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }

		public virtual ICollection<AnnexContract> AnnexContracts { get; set; }
		public virtual BookingType BookingType { get; set; }
		public virtual AnnexContractType Parent { get; set; }
		public virtual ICollection<AnnexContractType> InverseParent { get; set; }
		public virtual ICollection<SponsorProgram> SponsorPrograms { get; set; }
	}
}
