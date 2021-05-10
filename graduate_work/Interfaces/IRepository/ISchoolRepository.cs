using graduate_work.Models.Database;

namespace graduate_work.Interfaces.IRepository
{
    public interface ISchoolRepository
    {
        void Add(School school);
        void Add(string Name, string Location, string Email, string Number, int UserAccountId);
        void Update(School school);
        void Delete(int id);

        School FindById(int id);
        School FindByUserId(int id);

        bool isExist(int id);
        bool isExistByName(string name);
    }
}
