using graduate_work.Models.Database;

namespace graduate_work.Interfaces.IRepository
{
    public interface ITeacherRepository
    {
        void Add(Teacher teacher);
        void Update(Teacher teacher);
        void Delete(int id);

        Teacher FindById(int id);
        bool isExist(Teacher teacher);
    }
}
