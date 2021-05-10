using graduate_work.Databases.MySQL;
using graduate_work.Interfaces.IRepository;
using graduate_work.Models.Database;
using System;

namespace graduate_work.Databases.Repositories
{
    public class LessonRepository : ILessonRepository
    {
        private readonly MySQLContext db;

        public LessonRepository(MySQLContext db)
        {
            this.db = db;
        }

        public void Add(Lesson lesson)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Lesson FindById(int id)
        {
            throw new NotImplementedException();
        }

        public bool isExist(Lesson lesson)
        {
            throw new NotImplementedException();
        }

        public void Update(Lesson lesson)
        {
            throw new NotImplementedException();
        }
    }
}
