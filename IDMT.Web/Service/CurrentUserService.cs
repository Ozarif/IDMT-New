using IDMT.Application.Abstractions.Identity;
using IDMT.Web.Utilities;
using System.Security.Claims;

namespace IDMT.Web.Service
{
	public class CurrentUserService : ICurrentUserService
	{
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
		{
            _httpContextAccessor = httpContextAccessor;
		}

        public string UserName => _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.Name);
        public string UserFullName => _httpContextAccessor.HttpContext?.User.FindFirstValue(Constants.Claim_Full_Name);
		public bool IsAuthenticated => UserName != null;
	}
}
