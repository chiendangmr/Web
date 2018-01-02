using HD.Station;
using HD.TVAD.ApplicationCore.Entities.Security;
using HD.TVAD.ApplicationCore.Repositories.Security;

namespace HD.TVAD.Web.Services
{
    [Service(ServiceType = typeof(IUserService))]
	public class UserService : Service<User, IUserRepository>, IUserService
	{
		public UserService(IUserRepository repository) : base(repository)
		{
		}
	}
}
