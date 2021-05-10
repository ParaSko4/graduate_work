using graduate_work.Models.Database;

namespace graduate_work.Interfaces.IRepository
{
    public interface IClassImgRepository
    {
        void Add(ClassImg classImg);
        void Update(ClassImg classImg);
        void Delete(int id);

        ClassImg FindById(int id);
        bool isExist(ClassImg classImg);
    }
}
