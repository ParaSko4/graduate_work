using graduate_work.Databases.MySQL;
using graduate_work.Interfaces.IRepository;
using graduate_work.Models.Database;
using System;

namespace graduate_work.Databases.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly MySQLContext db;

        public StudentRepository(MySQLContext db)
        {
            this.db = db;
        }

        public void Add(Student student)
        {
            throw new NotImplementedException();
        }

        public void Update(Student student)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Student FindById(int id)
        {
            throw new NotImplementedException();
        }

        public bool isExist(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
