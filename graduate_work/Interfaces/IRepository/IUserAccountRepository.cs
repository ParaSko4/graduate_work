using graduate_work.Models.Database;

namespace graduate_work.Interfaces.IRepository
{
    public interface IUserAccountRepository
    {
        void Add(UserAccount user);
        void Add(string Login, string Password, string Email, string Role);
        void Update(UserAccount user);
        void Delete(int id);

        UserAccount FindById(int id);
        UserAccount FindByCredential(string login, string password);
        UserAccount FindByEmail(string email);

        bool isExistById(int id);
        bool isExistByLogin(string login);
        bool isExistByEmail(string email);
    }
}
