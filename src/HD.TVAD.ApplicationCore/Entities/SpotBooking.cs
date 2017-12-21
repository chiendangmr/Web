using HD.TVAD.ApplicationCore.Entities.Booking;
using HD.TVAD.ApplicationCore.Entities.ContractSchema;
using HD.TVAD.ApplicationCore.Entities.Price;
using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities
{
	public partial class SpotBooking
	{
		public Guid Id { get; set; }
		public Guid AnnexContractAssetId { get; set; }
		public Guid SpotId { get; set; }
		public int? Position { get; set; }
		public int? TmpOrder { get; set; }
		//   public int? PositionApprove { get; set; }
		public DateTime BookingDate { get; set; }
		public bool? IsPositionCost { get; set; }
		public decimal? CardRateSet { get; set; }
		public decimal? PositionRateSet { get; set; }
		public decimal? DiscountRateSet { get; set; }
		public decimal? CardRateCalc { get; set; }
		public decimal? PositionRateCalc { get; set; }
		public decimal? DiscountRateCalc { get; set; }
		public DateTime? CalcTime { get; set; }
		public Guid? SpotBookingRequestId { get; set; }

		public virtual SpotApprove SpotApproves { get; set; }
		public virtual AnnexContractAsset AnnexContractAsset { get; set; }
		public virtual SpotBooking SpotBookingRequest { get; set; }
		public virtual SpotAssetByBooking SpotAssetByBookings { get; set; }

		public virtual ICollection<SpotBooking> InverseSpotBookingRequest { get; set; }
		public virtual Spot Spot { get; set; }

		public void ChangeAnnexContractAsset(Guid newAnnexContractAssetId) {
			AnnexContractAssetId = newAnnexContractAssetId;
		}

		public int BookingTypeId
		{
			get
			{
				return AnnexContractAsset.AnnexContract.BookingTypeId;
			}
		}
		public BookingTypeEnum BookingType
		{
			get
			{
				return (BookingTypeEnum)AnnexContractAsset.AnnexContract.BookingTypeId;
			}
		}
		public Guid TimeBandId => Spot.TimeBandId;
		public string BookingTypeName
		{
			get
			{
				return AnnexContractAsset.AnnexContract.BookingType.Name;
			}
		}
		public string ProductGroupName
		{
			get
			{
				return AnnexContractAsset.Content.ProductGroup != null? AnnexContractAsset.Content.ProductGroup.Name: "Not set";
			}
		}
		public string ProducerName
		{
			get
			{
				return AnnexContractAsset.Content.Producer != null ? AnnexContractAsset.Content.Producer.Name : "Not set";
			}
		}
		public int? SponsorTypeId
		{
			get
			{
				return AnnexContractAsset.AnnexContract.AnnexContractPartners.SponsorTypeId;
			}
		}
		public int AssetDuration
		{
			get
			{
				return AnnexContractAsset.Content.BlockDuration;
			}
		}

		public bool IsFreeBooking
		{
			get
			{
				return AnnexContractAsset.PriceTypeDetail.TypeId == (int)PriceTypeEnum.Free;
			}
		}

		public bool IsNormalContractBooking
		{
			get
			{
				return AnnexContractAsset.AnnexContract.BookingTypeId == (int)BookingTypeEnum.Contract_Booking;
			}
		}
		public bool IsInProgramBooking
		{
			get
			{
				return AnnexContractAsset.AnnexContract.BookingTypeId == (int)BookingTypeEnum.Contract_Sponsor_InProgram;
			}
		}
		public bool IsOutProgramBooking
		{
			get
			{
				return AnnexContractAsset.AnnexContract.BookingTypeId == (int)BookingTypeEnum.Contract_Sponsor_OutProgram;
			}
		}
		public Guid PriceTypeDetailId
		{
			get
			{
				return AnnexContractAsset.PriceTypeDetail.Id;
			}
		}
		public bool IsNotFreeBooking
		{
			get
			{
				return AnnexContractAsset.PriceTypeDetail.TypeId != (int)PriceTypeEnum.Free;
			}
		}
		public PriceTypeEnum PriceType
		{
			get
			{
				return (PriceTypeEnum)AnnexContractAsset.PriceTypeDetail.TypeId;
			}
		}
		public string AssetCode
		{
			get
			{
				return AnnexContractAsset.Content.Code;
			}
		}
		public Guid ContentId
		{
			get
			{
				return AnnexContractAsset.Content.Id;
			}
		}
		public string CustomerCode
		{
			get
			{
				return AnnexContractAsset.AnnexContract.Customer?.CustomerPartners?.Code;
			}
		}

		public string ContractCode
		{
			get
			{
				return AnnexContractAsset.AnnexContract.Code;
			}
		}

		public Guid AnnexContractId
		{
			get
			{
				return AnnexContractAsset.AnnexContract.Id;
			}
		}
		public string CustomerName
		{
			get
			{
				return AnnexContractAsset.AnnexContract.Customer.Name;
			}
		}
		public Guid CustomerId
		{
			get
			{
				return AnnexContractAsset.AnnexContract.Customer.Id;
			}
		}
		public CustomerTypeEnum CustomerType
		{
			get
			{
				return (CustomerTypeEnum)AnnexContractAsset.AnnexContract.Customer.TypeId;
			}
		}
		public bool IsApproved
		{
			get
			{
				if (SpotAssetByBookings == null)
					return false;
				return (SpotAssetByBookings.SpotAsset != null) && (SpotAssetByBookings.SpotAsset.SpotId == SpotId);
			}
		}
		public bool IsNormalBooking
		{
			get
			{
				return AnnexContractAsset.AnnexContract.IsPartnerContract;
			}
		}
		public bool IsRetailBooking
		{
			get
			{
				return !AnnexContractAsset.AnnexContract.IsPartnerContract;
			}
		}
		public string SponsorProgramName
		{
			get
			{
				return AnnexContractAsset.AnnexContract.AnnexContractPartners?.SponsorProgram?.Name;
			}
		}
		public Guid? SponsorProgramId
		{
			get
			{
				return AnnexContractAsset.AnnexContract.AnnexContractPartners?.SponsorProgram?.Id;
			}
		}
		public string SponsorProgramCode
		{
			get
			{
				return AnnexContractAsset.AnnexContract.AnnexContractPartners?.SponsorProgram?.Code;
			}
		}
		public bool HasSponsorProgram
		{
			get
			{
				return AnnexContractAsset.AnnexContract.AnnexContractPartners.HasSponsorProgram;
			}
		}
	}
}
