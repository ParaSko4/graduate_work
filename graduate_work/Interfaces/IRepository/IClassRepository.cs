using graduate_work.Models.Database;

namespace graduate_work.Interfaces.IRepository
{
    public interface IClassRepository
    {
        void Add(Class sClass);
        void Update(Class sClass);
        void Delete(int id);

        Class FindById(int id);
        bool isExist(Class sClass);
    }
}
