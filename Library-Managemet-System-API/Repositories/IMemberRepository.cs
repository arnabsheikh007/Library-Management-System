using Library_Managemet_System_API.Models;

namespace Library_Managemet_System_API.Repositories
{
    public interface IMemberRepository
    {
        void AddMember(Member member);
        void DeleteMember(int memberId);
        IEnumerable<Member> GetAllMembers();
        Member GetMemberById(int memberId);
        void UpdateMember(Member member);
    }
}