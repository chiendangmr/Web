using HD.TVAD.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using HD.TVAD.ApplicationCore.Repositories;
using HD.TVAD.ApplicationCore.Entities;

namespace HD.TVAD.Web
{
    public static class RegisterRepository
    {
		public static IServiceCollection AddRepositories(this IServiceCollection services)
		{
		//	services.AddScoped<IUserRepository, UserRepository>();
		//	services.AddScoped<IUserGroupRepository, UserGroupRepository>();
		////	services.AddScoped<ISpotBlockRepository, SpotBlockRepository>();
		//	services.AddScoped<IChannelRepository, ChannelRepository>();
		//	services.AddScoped<ITimeBandRepository, TimeBandRepository>();
		//	services.AddScoped<ITimeBandSliceRepository, TimeBandSliceRepository>();
		//	services.AddScoped<ICustomerRepository, CustomerRepository>();
		//	services.AddScoped<IAssetRepository, AssetRepository>();
		//	services.AddScoped<ISponorProgramRepository, SponorProgramRepository>();
		//	services.AddScoped<ISpotBookingRepository, SpotBookingRepository>();
		//	services.AddScoped<ISpotRepository, SpotRepository>();
		//	services.AddScoped<IAnnexContractRepository, AnnexContractRepository>();
		//	services.AddScoped<IAnnexContractAssetRepository, AnnexContractAssetRepository>();
		//	services.AddScoped<ITimeBandPriceRepository, TimeBandPriceRepository>();
		//	services.AddScoped<IPositionRateRepository, PositionRateRepository>();
		//	services.AddScoped<IDiscountCustomerRepository, DiscountCustomerRepository>();
		//	services.AddScoped<IDiscountAnnexContractRepository, DiscountAnnexContractRepository>();
		//	services.AddScoped<IDiscountSponsorProgramRepository, DiscountSponsorProgramRepository>();
		//	services.AddScoped<ISpotBlockRateRepository, SpotBlockRateRepository>();
		//	services.AddScoped<IRateSpotBlockRepository, RateSpotBlockRepository>();
		//	services.AddScoped<ITimeBandSliceDurationRepository, TimeBandSliceDurationRepository>();
		//	services.AddScoped<ITimeBandSliceDurationByTypeRepository, TimeBandSliceDurationByTypeRepository>();
		//	services.AddScoped<ITimeBandSliceForTypeRepository, TimeBandSliceForTypeRepository>();
		//	services.AddScoped<IRetailPriceRepository, RetailPriceRepository>();
		//	services.AddScoped<ITemplateRepository, TemplateRepository>();
		//	services.AddScoped<ITemplateItemRepository, TemplateItemRepository>();
		//	services.AddScoped<ITemplateItemAssetTypeRequestRepository, TemplateItemAssetTypeRequestRepository>();
		//	services.AddScoped<ITimeBandBaseScheduleTemplateRepository, TimeBandBaseScheduleTemplateRepository>();

			return services;
		}
	}
}
