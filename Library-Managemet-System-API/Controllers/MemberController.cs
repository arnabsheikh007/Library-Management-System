using Library_Managemet_System_API.Models;
using Library_Managemet_System_API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Library_Managemet_System_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberRepository _memberRepository;

        public MemberController(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        [HttpGet]
        public IEnumerable<Member> GetMembers()
        {
            return _memberRepository.GetAllMembers();
        }

        [HttpGet("{id}")]
        public ActionResult<Member> GetMember(int id)
        {
            var member = _memberRepository.GetMemberById(id);

            if (member == null)
            {
                return NotFound();
            }

            return member;
        }

        [HttpPut("{id}")]
        public IActionResult PutMember(int id, Member member)
        {
            if (id != member.MemberID)
            {
                return BadRequest();
            }

            _memberRepository.UpdateMember(member);

            return NoContent();
        }

        [HttpPost]
        public ActionResult<Member> PostMember(Member member)
        {
            _memberRepository.AddMember(member);

            return CreatedAtAction("GetMember", new { id = member.MemberID }, member);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMember(int id)
        {
            _memberRepository.DeleteMember(id);

            return NoContent();
        }   
    }
}
