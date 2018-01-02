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
			return services;
		}
	}
}
