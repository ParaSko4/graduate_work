using graduate_work.Databases.MySQL;
using graduate_work.Interfaces.IRepository;
using graduate_work.Models.Database;
using System;
namespace graduate_work.Databases.Repositories
{
    public class AuditoriumImgRepository : IAuditoriumImgRepository
    {
        private readonly MySQLContext db;

        public AuditoriumImgRepository(MySQLContext db)
        {
            this.db = db;
        }

        public void Add(AuditoriumImg auditoriumImg)
        {
            throw new NotImplementedException();
        }

        public void Update(AuditoriumImg auditoriumImg)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public AuditoriumImg FindById(int id)
        {
            throw new NotImplementedException();
        }

        public bool isExist(AuditoriumImg auditoriumImg)
        {
            throw new NotImplementedException();
        }
    }
}
