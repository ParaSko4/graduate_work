using graduate_work.Common;
using graduate_work.Interfaces.Services;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace graduate_work.Utils
{
    public class EmailService : IEmailService
    {
        private readonly JwtService jwtService;

        private int urlPosition;
         
        public EmailService()
        {
            jwtService = new JwtService();
        }

        public void SendMessage(ApiConfig.Options options, string userEmail, object obj = null)
        {
            using (MailMessage mm = new MailMessage(ApiConfig.BotEmail, userEmail))
            {
                mm.Subject = ApiConfig.Subject;
                mm.IsBodyHtml = false;

                switch (options)
                {
                    case ApiConfig.Options.SchoolRegistration:
                        urlPosition = ApiConfig.EmailRegistrationMessageTemplate.IndexOf(ApiConfig.TagUrl);
                        mm.Body = ApiConfig.EmailRegistrationMessageTemplate.Remove(urlPosition, ApiConfig.TagUrl.Length).Insert(urlPosition, ApiConfig.registrationUrl + jwtService.GetJwt(options, obj));
                        break;
                    case ApiConfig.Options.SchoolRegistrationSuccess:
                        mm.Body = "ADMIN";
                        break;
                    case ApiConfig.Options.Restore:
                        urlPosition = ApiConfig.EmailRestoreMessageTemplate.IndexOf(ApiConfig.TagUrl);
                        mm.Body = ApiConfig.EmailRestoreMessageTemplate.Remove(urlPosition, ApiConfig.TagUrl.Length).Insert(urlPosition, ApiConfig.restoreUrl + jwtService.GetJwt(options, userEmail));
                        break;
                    case ApiConfig.Options.RestoreSuccess:
                        mm.Body = ApiConfig.EmailRestoreSuccessMessageTemplate;
                        break;
                }

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.UseDefaultCredentials = false;
                    smtp.EnableSsl = true;
                    smtp.Credentials = new NetworkCredential(ApiConfig.BotEmail, ApiConfig.PasswordEmail);
                    smtp.Send(mm);
                }
            }
        }

        public bool IsEmailValid(string email)
        {
            return Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        }
    }
}