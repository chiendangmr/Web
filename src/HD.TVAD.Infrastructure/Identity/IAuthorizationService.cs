
namespace HD.TVAD.Infrastructure.Identity
{
	public interface IAuthorizationTvadService
	{
		bool CheckPermission(string userName, ModuleType module, PermissionActionType action);
	}
}