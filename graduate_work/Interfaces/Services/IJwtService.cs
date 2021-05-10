using graduate_work.Common;
using System.Security.Claims;

namespace graduate_work.Interfaces.Services
{
    public interface IJwtService
    {
        object GetDataFromJwt(ApiConfig.Options options, string jwt);
        string GetJwt(ApiConfig.Options options, object obj);
        ClaimsPrincipal GetClaimsForCookies(int userId, int schoolId, string role, string email);

        bool CheckExpiryTime(string jwt);
    }
}
