
namespace BlazorServer.Data
{
    public sealed class MemberService
    {
        public MemberService(
            MemberDbContext memberDbContext
        )
        {
            m_memberDbContext = memberDbContext;
        }

        public async Task<int> AddMember(
            Member member
        )
        {
            if (
                m_memberDbContext.Members != null
            )
            {
                m_memberDbContext.Members.Add(
                    member
                );
                return await m_memberDbContext.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<int> EditMember(
            Member member
        )
        {
            var existingMember = m_memberDbContext.Members?.FirstOrDefault(
                m => m.MemberId == member.MemberId
            );
            if (existingMember != null)
            {
                existingMember.MemberId = member.MemberId;
                existingMember.MemberName = member.MemberName;
                existingMember.Email = member.Email;
                existingMember.Age = member.Age;
                existingMember.JoiningDate = member.JoiningDate;

                return await m_memberDbContext.SaveChangesAsync();
            }
            return 0;
        }
        
        public Member? GetMember(
            string memberId
        )
        {
            return m_memberDbContext.Members?.FirstOrDefault(
                m => m.MemberId == memberId
            );
        }

        public List<Member>? GetMembers()
        {
            return m_memberDbContext?.Members?.ToList();
        }

        private readonly MemberDbContext m_memberDbContext;
    }
}