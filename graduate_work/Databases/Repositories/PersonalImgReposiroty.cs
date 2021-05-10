using graduate_work.Databases.MySQL;
using graduate_work.Interfaces.IRepository;
using graduate_work.Models.Database;
using System;

namespace graduate_work.Databases.Repositories
{
    public class PersonalImgRepository : IPersonalImgRepository
    {
        private readonly MySQLContext db;

        public PersonalImgRepository(MySQLContext db)
        {
            this.db = db;
        }

        public void Add(PersonalImg personalImg)
        {
            throw new NotImplementedException();
        }

        public void Update(PersonalImg personalImg)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public PersonalImg FindById(int id)
        {
            throw new NotImplementedException();
        }

        public bool isExist(PersonalImg personalImg)
        {
            throw new NotImplementedException();
        }
    }
}
