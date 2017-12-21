using AutoMapper;
using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web
{
	public static class Bootstrapper
	{
		public static void Initital()
		{
			Mapper.Initialize(cfg =>
			{
				cfg.CreateMap<SpotBlockViewModel, SpotBlock>()
					.ForMember(sb => sb.Id,
								a => a.MapFrom(src => src.Id))
					.ForMember(sb => sb.Duration,
								a => a.MapFrom(src => src.Length))
					.ForMember(sb => sb.Description,
								a => a.MapFrom(src => src.Description));
				cfg.CreateMap<SpotBlock, SpotBlockViewModel>()
					.ForMember(sb => sb.Id,
								a => a.MapFrom(src => src.Id))
					.ForMember(sb => sb.Length,
								a => a.MapFrom(src => src.Duration))
					.ForMember(sb => sb.Description,
								a => a.MapFrom(src => src.Description));

				cfg.CreateMap<TimeBand, TimeBandViewModel>()
					.ForMember(sb => sb.Id,
								a => a.MapFrom(src => src.Id))
					.ForMember(sb => sb.Name,
								a => a.MapFrom(src => src.TimeBandBase.Name)) 
					.ForMember(sb => sb.Description,
								a => a.MapFrom(src => src.TimeBandBase.Description))
					.ForMember(sb => sb.ChannelName,
								a => a.MapFrom(src => src.TimeBandBase.Parent.Name))
					.ForMember(sb => sb.ChannelId,
								a => a.MapFrom(src => src.TimeBandBase.Parent.Id))
					.ForMember(sb => sb.TimeBandDescription,
								a => a.MapFrom(src => src.TimeBandDescriptions.Where(t => t.StartDate <= DateTime.Today).OrderByDescending(t => t.StartDate).FirstOrDefault().Description))
					.ForMember(sb => sb.DayOfWeeks,
								a => a.MapFrom(src => src.TimeBandDays.Where(t => t.StartDate <= DateTime.Today).OrderByDescending(t => t.StartDate).FirstOrDefault().DayOfWeeks))
					.ForMember(sb => sb.StartTimeOfDay,
								a => a.MapFrom(src => src.TimeBandTimes.Where(t => t.StartDate <= DateTime.Today).OrderByDescending(t => t.StartDate).FirstOrDefault().StartTimeOfDay))
					.ForMember(sb => sb.Duration,
								a => a.MapFrom(src => src.TimeBandTimes.Where(t => t.StartDate <= DateTime.Today).OrderByDescending(t => t.StartDate).FirstOrDefault().Duration));

				cfg.CreateMap<TimeBandSlice, TimeBandSliceViewModel>()
					.ForMember(sb => sb.Id,
								a => a.MapFrom(src => src.Id))
					.ForMember(sb => sb.Name,
								a => a.MapFrom(src => src.Name))
					.ForMember(sb => sb.TimeBandName,
								a => a.MapFrom(src => src.TimeBand.TimeBandBase.Name))
					.ForMember(sb => sb.Description,
								a => a.MapFrom(src => src.TimeBandSliceDescriptions.Where(t => t.StartDate <= DateTime.Today).OrderByDescending(t => t.StartDate).FirstOrDefault().Description))
					.ForMember(sb => sb.MaxDuration,
								a => a.MapFrom(src => src.TimeBandSliceDurations.Where(t => t.StartDate <= DateTime.Today).OrderByDescending(t => t.StartDate).FirstOrDefault().Duration))
					.ForMember(sb => sb.MaxDurationId,
								a => a.MapFrom(src => src.TimeBandSliceDurations.Where(t => t.StartDate <= DateTime.Today).OrderByDescending(t => t.StartDate).FirstOrDefault().Id))
					;
				cfg.CreateMap<Customer, CustomerViewModel>()
					.ForMember(sb => sb.Id,
								a => a.MapFrom(src => src.Id))
					.ForMember(sb => sb.Name,
								a => a.MapFrom(src => src.Name))
					.ForMember(sb => sb.Code,
								a => a.MapFrom(src => src.CustomerPartners.Code))
					.ForMember(sb => sb.Address,
								a => a.MapFrom(src => src.Address))
					.ForMember(sb => sb.ParentId,
								a => a.MapFrom(src => src.CustomerPartners.ParentId))
					.ForMember(sb => sb.TypeName,
								a => a.MapFrom(src => src.Type.Name))
								;

				cfg.CreateMap<AnnexContract, AnnexContractViewModel>()
					.ForMember(sb => sb.Id,
								a => a.MapFrom(src => src.Id))
					.ForMember(sb => sb.CustomerId,
								a => a.MapFrom(src => src.CustomerId))
					.ForMember(sb => sb.CustomerName,
								a => a.MapFrom(src => src.Customer.Name))
					.ForMember(sb => sb.BookingTypeName,
								a => a.MapFrom(src => src.BookingType.Name))
					.ForMember(sb => sb.Code,
								a => a.MapFrom(src => src.Code))
					.ForMember(sb => sb.ScheduleCampaign,
								a => a.MapFrom(src => src.AnnexContractPartners.ScheduleCampaign))
					.ForMember(sb => sb.Content,
								a => a.MapFrom(src => src.AnnexContractPartners.Content))
					.ForMember(sb => sb.ReceiveDate,
								a => a.MapFrom(src => src.ReceiveDate))
					.ForMember(sb => sb.SignDate,
								a => a.MapFrom(src => src.AnnexContractPartners.SignDate))
					.ForMember(sb => sb.SponsorProgramName,
								a => a.MapFrom(src => src.AnnexContractPartners.SponsorProgram.Name))
					.ForMember(sb => sb.SponsorProgramId,
								a => a.MapFrom(src => src.AnnexContractPartners.SponsorProgramId))
					.ForMember(sb => sb.SponsorTypeName,
								a => a.MapFrom(src => src.AnnexContractPartners.SponsorType.Name))
					.ForMember(sb => sb.SponsorTypeId,
								a => a.MapFrom(src => src.AnnexContractPartners.SponsorTypeId))
								;

				cfg.CreateMap<TimeBandPrice, TimeBandPriceViewModel>()
					.ForMember(sb => sb.Id,
								a => a.MapFrom(src => src.Id))
					.ForMember(sb => sb.Price,
								a => a.MapFrom(src => src.Price))
					.ForMember(sb => sb.SpotBlockId,
								a => a.MapFrom(src => src.SpotBlockId))
					.ForMember(sb => sb.TimeBandId,
								a => a.MapFrom(src => src.TimeBandId))
					.ForMember(sb => sb.TimeBandName,
								a => a.MapFrom(src => src.TimeBand.TimeBandBase.Name))
					.ForMember(sb => sb.SpotBlockDuration,
								a => a.MapFrom(src => src.SpotBlock.Duration));
				cfg.CreateMap<SpotBlockRate, SpotBlockRateViewModel>()
					.ForMember(sb => sb.Id,
								a => a.MapFrom(src => src.Id))
					.ForMember(sb => sb.Rate,
								a => a.MapFrom(src => src.Rate))
					.ForMember(sb => sb.SpotBlockId,
								a => a.MapFrom(src => src.SpotBlockId))
					.ForMember(sb => sb.Description,
								a => a.MapFrom(src => src.Description))
					.ForMember(sb => sb.SpotBlockDuration,
								a => a.MapFrom(src => src.SpotBlock.Duration));

				cfg.CreateMap<RateSpotBlock, RateSpotBlockViewModel>()
					.ForMember(sb => sb.Id,
								a => a.MapFrom(src => src.Id))
					.ForMember(sb => sb.Rate,
								a => a.MapFrom(src => src.Rate))
					.ForMember(sb => sb.SpotBlockId,
								a => a.MapFrom(src => src.SpotBlockId))
					.ForMember(sb => sb.SpotBlockDuration,
								a => a.MapFrom(src => src.SpotBlock.Duration))
					.ForMember(sb => sb.TypeId,
								a => a.MapFrom(src => src.TypeDetail.TypeId))
					.ForMember(sb => sb.Name,
								a => a.MapFrom(src => src.TypeDetail.Name))
					.ForMember(sb => sb.TypeName,
								a => a.MapFrom(src => src.TypeDetail.Type.Name));

				cfg.CreateMap<PositionRate, PositionRateViewModel>()
					.ForMember(sb => sb.Id,
								a => a.MapFrom(src => src.Id))
					.ForMember(sb => sb.Rate,
								a => a.MapFrom(src => src.Rate))
					.ForMember(sb => sb.TimeBandId,
								a => a.MapFrom(src => src.TimeBandId))
					.ForMember(sb => sb.TimeBandName,
								a => a.MapFrom(src => src.TimeBand.TimeBandBase.Name))
					.ForMember(sb => sb.StartDate,
								a => a.MapFrom(src => src.StartDate))
					.ForMember(sb => sb.EndDate,
								a => a.MapFrom(src => src.EndDate))
					//.ForAllMembers(opt => opt.Condition((source, destination, sourceMember, destMember) => (sourceMember != null)))
					;
				cfg.CreateMap<DiscountCustomer, DiscountCustomerViewModel>()
					.ForMember(sb => sb.Id,
								a => a.MapFrom(src => src.Id))
					.ForMember(sb => sb.Rate,
								a => a.MapFrom(src => src.Rate))
					.ForMember(sb => sb.CustomerId,
								a => a.MapFrom(src => src.CustomerId))
					.ForMember(sb => sb.CustomerName,
								a => a.MapFrom(src =>$"{src.Customer.CustomerPartners.Code} - {src.Customer.Name}" ))
					.ForMember(sb => sb.CustomerCode,
								a => a.MapFrom(src => src.Customer.CustomerPartners.Code))
					.ForMember(sb => sb.StartDate,
								a => a.MapFrom(src => src.StartDate))
					.ForMember(sb => sb.EndDate,
								a => a.MapFrom(src => src.EndDate))
					.ForMember(sb => sb.Description,
								a => a.MapFrom(src => src.Description))
					;
				cfg.CreateMap<DiscountSponsorProgram, DiscountSponsorProgramViewModel>()
					.ForMember(sb => sb.Id,
								a => a.MapFrom(src => src.Id))
					.ForMember(sb => sb.Rate,
								a => a.MapFrom(src => src.Rate))
					.ForMember(sb => sb.ProgramId,
								a => a.MapFrom(src => src.ProgramId))
					.ForMember(sb => sb.ProgramName,
								a => a.MapFrom(src => src.Program.Name))
					.ForMember(sb => sb.StartDate,
								a => a.MapFrom(src => src.StartDate))
					.ForMember(sb => sb.EndDate,
								a => a.MapFrom(src => src.EndDate))
					.ForMember(sb => sb.Description,
								a => a.MapFrom(src => src.Description))
					;
				cfg.CreateMap<DiscountAnnexContract, DiscountAnnexContractViewModel>()
					.ForMember(sb => sb.Id,
								a => a.MapFrom(src => src.Id))
					.ForMember(sb => sb.Rate,
								a => a.MapFrom(src => src.Rate))
					.ForMember(sb => sb.AnnexContractId,
								a => a.MapFrom(src => src.AnnexContractId))
					.ForMember(sb => sb.AnnexContractCode,
								a => a.MapFrom(src => src.AnnexContract.AnnexContract.Code))
					.ForMember(sb => sb.StartDate,
								a => a.MapFrom(src => src.StartDate))
					.ForMember(sb => sb.EndDate,
								a => a.MapFrom(src => src.EndDate))
					.ForMember(sb => sb.Description,
								a => a.MapFrom(src => src.Description))
					;
				cfg.CreateMap<Template, TemplateViewModel>()
					.ForMember(sb => sb.Id,
								a => a.MapFrom(src => src.Id))
					.ForMember(sb => sb.Name,
								a => a.MapFrom(src => src.Name))
					;
				cfg.CreateMap<TemplateItem, TemplateItemViewModel>()
					.ForMember(sb => sb.Id,
								a => a.MapFrom(src => src.Id))
					.ForMember(sb => sb.Name,
								a => a.MapFrom(src => src.Name))
					.ForMember(sb => sb.Index,
								a => a.MapFrom(src => src.Index))
					;
				cfg.CreateMap<TemplateItemAssetTypeRequest, TemplateItemAssetTypeRequestViewModel>()
					.ForMember(sb => sb.Id,
								a => a.MapFrom(src => src.Id))
					.ForMember(sb => sb.AssetTypeName,
								a => a.MapFrom(src => src.AssetType.Name))
					.ForMember(sb => sb.MinCount,
								a => a.MapFrom(src => src.MinCount))
					.ForMember(sb => sb.MaxCount,
								a => a.MapFrom(src => src.MaxCount))
					;
				cfg.CreateMap<TimeBandBaseScheduleTemplate, TimeBandBaseScheduleTemplateViewModel>()
					.ForMember(sb => sb.Id,
								a => a.MapFrom(src => src.Id))
					.ForMember(sb => sb.TimeBandBaseName,
								a => a.MapFrom(src => src.TimeBandBase.Name))
					.ForMember(sb => sb.StartDate,
								a => a.MapFrom(src => src.StartDate))
					.ForMember(sb => sb.EndDate,
								a => a.MapFrom(src => src.EndDate))
					;
				cfg.CreateMap<AnnexContractPartnerPriceAtSignDate, AnnexContractPartnerPriceAtSignDateViewModel>()
					.ForMember(sb => sb.Id,
								a => a.MapFrom(src => src.Id))
					.ForMember(sb => sb.AnnexContractId,
								a => a.MapFrom(src => src.AnnexContractId))
					.ForMember(sb => sb.AnnexContractCode,
								a => a.MapFrom(src => src.AnnexContract.AnnexContract.Code))
					.ForMember(sb => sb.StartDate,
								a => a.MapFrom(src => src.StartDate))
					.ForMember(sb => sb.EndDate,
								a => a.MapFrom(src => src.EndDate))
					;
			});
		}
	}
}
