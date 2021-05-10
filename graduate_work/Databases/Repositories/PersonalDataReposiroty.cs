using graduate_work.Databases.MySQL;
using graduate_work.Interfaces.IRepository;
using graduate_work.Models.Database;
using System;
using System.Linq;

namespace graduate_work.Databases.Repositories
{
    public class PersonalDataRepository : IPersonalDataRepository
    {
        private readonly MySQLContext db;

        public PersonalDataRepository(MySQLContext db)
        {
            this.db = db;
        }

        public void Add(PersonalData personalData)
        {
            throw new NotImplementedException();
        }

        public void Update(PersonalData personalData)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public PersonalData FindById(int id)
        {
            throw new NotImplementedException();
        }

        public PersonalData FindByUserId(int id)
        {
            return db.PersonalDatas.Where(pd => pd.UserAccountId == id).FirstOrDefault();
        }

        public bool isExist(PersonalData personalData)
        {
            throw new NotImplementedException();
        }
    }
}
