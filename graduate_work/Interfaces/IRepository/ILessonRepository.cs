using graduate_work.Models.Database;

namespace graduate_work.Interfaces.IRepository
{
    public interface ILessonRepository
    {
        void Add(Lesson lesson);
        void Update(Lesson lesson);
        void Delete(int id);

        Lesson FindById(int id);
        bool isExist(Lesson lesson);
    }
}
