using graduate_work.Databases.MySQL;
using graduate_work.Interfaces.IRepository;
using graduate_work.Models.Database;
using System;

namespace graduate_work.Databases.Repositories
{
    public class ClassImgRepository : IClassImgRepository
    {
        private readonly MySQLContext db;

        public ClassImgRepository(MySQLContext db)
        {
            this.db = db;
        }

        public void Add(ClassImg classImg)
        {
            throw new NotImplementedException();
        }

        public void Update(ClassImg classImg)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ClassImg FindById(int id)
        {
            throw new NotImplementedException();
        }

        public bool isExist(ClassImg classImg)
        {
            throw new NotImplementedException();
        }
    }
}
