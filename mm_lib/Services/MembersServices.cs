using mm_lib.Interface;

namespace mm_lib.Services
{
    public class MembersServices : IMembers
    {
        private readonly members_managementContext _context;
        public MembersServices(members_managementContext context)
        {
            _context = context;
        }
        public bool AddMember(string Name, string PhoneNo, DateTime Dob, bool Gender, int orgId)
        {
            Members addMembers = new Members();
            addMembers.Name = Name;
            addMembers.PhoneNo = PhoneNo;
            addMembers.Dob = Dob;
            addMembers.Gender = Gender;
            addMembers.OrgId = orgId;
            _context.Members.Add(addMembers);
            bool isMembersAdded = _context.SaveChanges() > 0;
            return isMembersAdded;
        }
        public IEnumerable<Members> GetMembersByOrgId(int orgId)
        {
            var getMembersByOrgId = _context.Members.Where(m => m.OrgId == orgId);
            return getMembersByOrgId;
        }
        public IEnumerable<Members> GetMembersByMemberId(int memberId)
        {
            var getMembersByMemberId = _context.Members.Where(m => m.MemberId == memberId);
            return getMembersByMemberId;
        }        
    }
}
