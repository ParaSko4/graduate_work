using Microsoft.IdentityModel.Tokens;
using System.IO;
using System.Text;

namespace graduate_work.Common
{
    public static class ApiConfig
    {
        public enum Options
        {
            SchoolRegistration, SchoolRegistrationSuccess, 
            SchoolMemberRegistration, SchoolMemberRegistrationSuccess, 
            Restore, RestoreSuccess
        }

        public const int DEFAULT_ID = -1;

        #region Roles
        public const string ROLE_ADMIN = "ADMIN";
        public const string ROLE_TEACHER = "TEACHER";
        public const string ROLE_STUDENT = "STUDENT";
        #endregion

        #region JWT
        private const string KEY = "mysupersecret_secretkey!123";
        public const string COOKIE = "Cookies";

        public const string COOKIE_NAME = "auth_cookie";
        public const string ISSUER = "SCHOOL_CRM_PRIVATE_API";
        public const string AUDIENCE = "SCHOOL_CRM_USER";
        public const int LIFETIME = 10; // время жизни токена - 10 минут

        public const string ClaimTypeExpiryToken = "exp";

        public const string ClaimTypeUserId = "UserId";
        public const string ClaimTypeLogin = "Login";
        public const string ClaimTypePassword = "Password";
        public const string ClaimTypeUserEmail = "UserEmail";
        public const string ClaimTypeUserRole = "Role";
        public const string ClaimTypeSchoolId = "SchoolId";
        public const string ClaimTypeSchoolName = "SchoolName";
        public const string ClaimTypeSchoolLocation = "SchoolLocation";
        public const string ClaimTypeSchoolEmail = "SchoolEmail";
        public const string ClaimTypeSchoolNumber = "SchoolNumber";

        public const string ClaimTypeUserNewPassword = "UserNewPassword";

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
        #endregion

        #region Email
        public const string Subject = "Registration on service";
        public const string BotEmail = "schoolcrmbot@gmail.com";
        public const string PasswordEmail = "123445566321";

        public static string EmailRegistrationMessageTemplate = "";
        public static string EmailRestoreMessageTemplate = "";
        public static string EmailRestoreSuccessMessageTemplate = "";

        public const string TagToken = "[URL]";

        private const string Path = @"C:\Users\Mages\source\repos\graduate_work\graduate_work\Common\Static\";
        private const string ConfirmingMessageTemplateFileName = "ConfirmingMessage.txt";
        private const string RestoreMessageTemplateFileName = "RestoreMessage.txt";
        private const string RestoreSuccessMessageTemplateFileName = "RestoreSuccessMessage.txt";

        public static void LoadMessagesTemplate()
        {
            EmailRegistrationMessageTemplate = File.ReadAllText(Path + ConfirmingMessageTemplateFileName);
            EmailRestoreMessageTemplate = File.ReadAllText(Path + RestoreMessageTemplateFileName);
            EmailRestoreSuccessMessageTemplate = File.ReadAllText(Path + RestoreSuccessMessageTemplateFileName);
        }
        #endregion
    }
}