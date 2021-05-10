using graduate_work.Databases.MySQL;
using graduate_work.Interfaces.IRepository;
using graduate_work.Models.Database;
using System;

namespace graduate_work.Databases.Repositories
{
    public class FamilyRepository : IFamilyRepository
    {
        private readonly MySQLContext db;

        public FamilyRepository(MySQLContext db)
        {
            this.db = db;
        }

        public void Add(Family family)
        {
            throw new NotImplementedException();
        }

        public void Update(Family family)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Family FindById(int id)
        {
            throw new NotImplementedException();
        }

        public bool isExist(Family family)
        {
            throw new NotImplementedException();
        }
    }
}
