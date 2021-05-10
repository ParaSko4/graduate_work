using graduate_work.Models.Database;

namespace graduate_work.Interfaces.IRepository
{
    public interface IFamilyMemberRepository
    {
        void Add(FamilyMember familyMember);
        void Update(FamilyMember familyMember);
        void Delete(int id);

        FamilyMember FindById(int id);
        bool isExist(FamilyMember familyMember);
    }
}
