using graduate_work.Models.Database;

namespace graduate_work.Interfaces.IRepository
{
    public interface ILessonDurationRepository
    {
        void Add(LessonDuration lessonDuration);
        void Update(LessonDuration lessonDuration);
        void Delete(int id);

        LessonDuration FindById(int id);
        bool isExist(LessonDuration lessonDuration);
    }
}
