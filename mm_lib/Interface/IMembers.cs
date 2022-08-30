
namespace mm_lib.Interface
{
    public interface IMembers
    {
        public bool AddMember(string Name, string PhoneNo, DateTime Dob, bool Gender, int orgId);
        public IEnumerable<Members> GetMembersByOrgId(int orgId);
        public IEnumerable<Members> GetMembersByMemberId(int Id);
    }
}
