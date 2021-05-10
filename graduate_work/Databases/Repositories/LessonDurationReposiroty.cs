using graduate_work.Databases.MySQL;
using graduate_work.Interfaces.IRepository;
using graduate_work.Models.Database;
using System;

namespace graduate_work.Databases.Repositories
{
    public class LessonDurationRepository : ILessonDurationRepository
    {
        private readonly MySQLContext db;

        public LessonDurationRepository(MySQLContext db)
        {
            this.db = db;
        }

        public void Add(LessonDuration lessonDuration)
        {
            throw new NotImplementedException();
        }

        public void Update(LessonDuration lessonDuration)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public LessonDuration FindById(int id)
        {
            throw new NotImplementedException();
        }

        public bool isExist(LessonDuration lessonDuration)
        {
            throw new NotImplementedException();
        }
    }
}
