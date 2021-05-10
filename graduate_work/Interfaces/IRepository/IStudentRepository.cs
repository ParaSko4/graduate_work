using graduate_work.Models.Database;

namespace graduate_work.Interfaces.IRepository
{
    public interface IStudentRepository
    {
        void Add(Student student);
        void Update(Student student);
        void Delete(int id);

        Student FindById(int id);
        bool isExist(Student student);
    }
}
