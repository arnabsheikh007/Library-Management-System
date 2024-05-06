using Library_Managemet_System_API.Data;
using Library_Managemet_System_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Library_Managemet_System_API.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly DataContext _context;

        public MemberRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Member> GetAllMembers()
        {
            return _context.Members.ToList();
        }

        public Member GetMemberById(int memberId)
        {
            return _context.Members.FirstOrDefault(m => m.MemberID == memberId);
        }

        public void AddMember(Member member)
        {
            if (member == null)
            {
                throw new ArgumentNullException(nameof(member));
            }

            _context.Members.Add(member);
            _context.SaveChanges();
        }

        public void UpdateMember(Member member)
        {
            if (member == null)
            {
                throw new ArgumentNullException(nameof(member));
            }

            _context.Entry(member).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteMember(int memberId)
        {
            var memberToDelete = _context.Members.FirstOrDefault(m => m.MemberID == memberId);
            if (memberToDelete != null)
            {
                _context.Members.Remove(memberToDelete);
                _context.SaveChanges();
            }
        }
    }
}
