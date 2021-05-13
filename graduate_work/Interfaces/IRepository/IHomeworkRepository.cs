using graduate_work.Models.Database;

namespace graduate_work.Interfaces.IRepository
{
    public interface IHomeworkRepository
    {
        void Add(Homework homework);
        void Update(Homework homework);
        void Delete(int id);

        Homework FindById(int id);
        bool isExist(Homework homework);
    }
}
