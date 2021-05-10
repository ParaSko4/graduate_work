using graduate_work.Models.Database;

namespace graduate_work.Interfaces.IRepository
{
    public interface IAuditoriumImgRepository
    {
        void Add(AuditoriumImg auditoriumImg);
        void Update(AuditoriumImg auditoriumImg);
        void Delete(int id);

        AuditoriumImg FindById(int id);
        bool isExist(AuditoriumImg auditoriumImg);
    }
}
