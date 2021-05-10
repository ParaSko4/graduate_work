using graduate_work.Models.Database;

namespace graduate_work.Interfaces.IRepository
{
    public interface IPersonalDataRepository
    {
        void Add(PersonalData personalData);
        void Update(PersonalData personalData);
        void Delete(int id);

        PersonalData FindById(int id);
        PersonalData FindByUserId(int id);

        bool isExist(PersonalData personalData);
    }
}
