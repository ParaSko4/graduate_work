using graduate_work.Models.Database;

namespace graduate_work.Interfaces.IRepository
{
    public interface IProgressRepository
    {
        void Add(Progress progress);
        void Update(Progress progress);
        void Delete(int id);

        Progress FindById(int id);
        bool isExist(Progress progress);
    }
}
