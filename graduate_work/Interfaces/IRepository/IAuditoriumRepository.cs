using graduate_work.Models.Database;

namespace graduate_work.Interfaces.IRepository
{
    public interface IAuditoriumRepository
    {
        void Add(Auditorium auditorium);
        void Update(Auditorium auditorium);
        void Delete(int id);

        Auditorium FindById(int id);
        bool isExist(Auditorium auditorium);
    }
}
