using graduate_work.Databases.MySQL;
using graduate_work.Interfaces.IRepository;
using graduate_work.Models.Database;
using System;

namespace graduate_work.Databases.Repositories
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly MySQLContext db;

        public ScheduleRepository(MySQLContext db)
        {
            this.db = db;
        }

        public void Add(Schedule schedule)
        {
            throw new NotImplementedException();
        }

        public void Update(Schedule schedule)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Schedule FindById(int id)
        {
            throw new NotImplementedException();
        }

        public bool isExist(Schedule schedule)
        {
            throw new NotImplementedException();
        }
    }
}
