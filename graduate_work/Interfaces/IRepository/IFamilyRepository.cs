using graduate_work.Models.Database;

namespace graduate_work.Interfaces.IRepository
{
    public interface IFamilyRepository
    {
        void Add(Family family);
        void Update(Family family);
        void Delete(int id);

        Family FindById(int id);
        bool isExist(Family family);
    }
}
