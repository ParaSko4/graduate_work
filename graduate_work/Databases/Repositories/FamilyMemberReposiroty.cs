using graduate_work.Databases.MySQL;
using graduate_work.Interfaces.IRepository;
using graduate_work.Models.Database;
using System;

namespace graduate_work.Databases.Repositories
{
    public class FamilyMemberRepository : IFamilyMemberRepository
    {
        private readonly MySQLContext db;

        public FamilyMemberRepository(MySQLContext db)
        {
            this.db = db;
        }

        public void Add(FamilyMember familyMember)
        {
            throw new NotImplementedException();
        }

        public void Update(FamilyMember familyMember)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public FamilyMember FindById(int id)
        {
            throw new NotImplementedException();
        }

        public bool isExist(FamilyMember familyMember)
        {
            throw new NotImplementedException();
        }
    }
}
