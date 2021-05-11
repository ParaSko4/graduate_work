using graduate_work.Common;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using graduate_work.Interfaces.Services;
using graduate_work.Models.Api;

namespace graduate_work.Utils
{
    public class JwtService : IJwtService
    {
        private JwtSecurityToken jwtSecurityToken = null;
        private JwtSecurityTokenHandler jwtSecurityTokenHandler = null;

        public JwtService()
        {
            jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        }

        public object GetDataFromJwt(ApiConfig.Options options, string jwt)
        {
            object obj = null;

            switch (options)
            {
                case ApiConfig.Options.SchoolRegistration:
                    obj = new SchoolRegistrationInfo(
                        jwtSecurityToken.Claims.First(claim => claim.Type == ApiConfig.ClaimTypeLogin).Value,
                        jwtSecurityToken.Claims.First(claim => claim.Type == ApiConfig.ClaimTypePassword).Value,
                        jwtSecurityToken.Claims.First(claim => claim.Type == ApiConfig.ClaimTypeUserEmail).Value,
                        jwtSecurityToken.Claims.First(claim => claim.Type == ApiConfig.ClaimTypeSchoolName).Value,
                        jwtSecurityToken.Claims.First(claim => claim.Type == ApiConfig.ClaimTypeSchoolLocation).Value,
                        jwtSecurityToken.Claims.First(claim => claim.Type == ApiConfig.ClaimTypeSchoolEmail).Value,
                        jwtSecurityToken.Claims.First(claim => claim.Type == ApiConfig.ClaimTypeSchoolNumber).Value
                    );
                    break;
                case ApiConfig.Options.Restore:
                    obj = jwtSecurityToken.Claims.First(claim => claim.Type == ApiConfig.ClaimTypeUserEmail).Value;
                    break;
                default:
                    break;
            }

            return obj;
        }

        public string GetJwt(ApiConfig.Options options, object obj)
        {
            List<Claim> claims = null;

            switch (options)
            {
                case ApiConfig.Options.SchoolRegistration:
                    SchoolRegistrationInfo regInfo = obj as SchoolRegistrationInfo;
                    claims = new List<Claim>
                    {
                        new Claim(ApiConfig.ClaimTypeLogin, regInfo.Login),
                        new Claim(ApiConfig.ClaimTypePassword, regInfo.Password),
                        new Claim(ApiConfig.ClaimTypeUserEmail, regInfo.Email),
                        new Claim(ApiConfig.ClaimTypeSchoolName, regInfo.SchoolName),
                        new Claim(ApiConfig.ClaimTypeSchoolLocation, regInfo.SchoolLocation),
                        new Claim(ApiConfig.ClaimTypeSchoolEmail, regInfo.SchoolEmail),
                        new Claim(ApiConfig.ClaimTypeSchoolNumber, regInfo.SchoolNumber),
                    };
                    break;
                case ApiConfig.Options.Restore:
                    claims = new List<Claim>
                    {
                        new Claim(ApiConfig.ClaimTypeUserEmail, obj as string),
                    };
                    break;
                default:
                    break;
            }

            DateTime now = DateTime.UtcNow;
            jwtSecurityToken = new JwtSecurityToken(
                    issuer: ApiConfig.ISSUER,
                    audience: ApiConfig.AUDIENCE,
                    notBefore: now,
                    claims: claims,
                    expires: now.Add(TimeSpan.FromMinutes(ApiConfig.LIFETIME)),
                    signingCredentials: new SigningCredentials(ApiConfig.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            return jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);
        }

        public CookieInfo GetCookieInfo(ClaimsPrincipal claimsPrincipal)
        {
            return new CookieInfo(
                int.Parse(claimsPrincipal.Claims.Where(c => c.Type == ApiConfig.ClaimTypeUserId).Select(c => c.Value).FirstOrDefault()),
                int.Parse(claimsPrincipal.Claims.Where(c => c.Type == ApiConfig.ClaimTypeSchoolId).Select(c => c.Value).FirstOrDefault()),
                claimsPrincipal.Claims.Where(c => c.Type == ApiConfig.ClaimTypeUserRole).Select(c => c.Value).FirstOrDefault(),
                claimsPrincipal.Claims.Where(c => c.Type == ApiConfig.ClaimTypeUserEmail).Select(c => c.Value).FirstOrDefault()
            );
        }

        public ClaimsPrincipal GetClaimsForCookies(int userId, int schoolId, string role, string email)
        {
            var claimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim(ApiConfig.ClaimTypeUserId, userId.ToString()),
                new Claim(ApiConfig.ClaimTypeSchoolId, schoolId.ToString()),
                new Claim(ClaimTypes.Role, role),
                new Claim(ApiConfig.ClaimTypeUserEmail, email),
            }, "Cookies");

            return new ClaimsPrincipal(new ClaimsPrincipal(claimsIdentity));
        }

        public bool CheckExpiryTime(string jwt)
        {
            jwtSecurityToken = jwtSecurityTokenHandler.ReadToken(jwt) as JwtSecurityToken;

            var expClaim = jwtSecurityToken.Claims.First(claim => claim.Type == "exp").Value;
            var tokenExpiryTime = Convert.ToDouble(expClaim).UnixTimeStampToDateTime();

            return tokenExpiryTime > DateTime.UtcNow.ToLocalTime();
        }
    }
}
