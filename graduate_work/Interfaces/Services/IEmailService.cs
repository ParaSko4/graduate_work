using graduate_work.Common;

namespace graduate_work.Interfaces.Services
{
    public interface IEmailService
    {
        void SendMessage(ApiConfig.Options options, string userEmail, object obj = null);

        bool IsEmailValid(string email);
    }
}
