using graduate_work.Models.Database;

namespace graduate_work.Interfaces.IRepository
{
    public interface IPersonalImgRepository
    {
        void Add(PersonalImg personalImg);
        void Update(PersonalImg personalImg);
        void Delete(int id);

        PersonalImg FindById(int id);
        bool isExist(PersonalImg personalImg);
    }
}
