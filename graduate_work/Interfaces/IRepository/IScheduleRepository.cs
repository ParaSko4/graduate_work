using graduate_work.Models.Database;

namespace graduate_work.Interfaces.IRepository
{
    public interface IScheduleRepository
    {
        void Add(Schedule schedule);
        void Update(Schedule schedule);
        void Delete(int id);

        Schedule FindById(int id);
        bool isExist(Schedule schedule);
    }
}
