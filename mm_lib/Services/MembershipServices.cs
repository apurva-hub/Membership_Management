using mm_lib.Interface;

namespace mm_lib.Services
{
    public class MembershipServices : IMembership
    {
        private readonly members_managementContext _context;
        public MembershipServices(members_managementContext context)
        {
            _context = context;
        }
        public int AddMembership(int orgId, int memberId, DateTime StartDate, int Duration, int AmountPaid)
        {
            Membership addMembership = new Membership();
            addMembership.OrgId = orgId;
            addMembership.MemberId = memberId;
            addMembership.StartDate = StartDate;
            addMembership.AmountPaid = AmountPaid;

            _context.Membership.Add(addMembership);
            int isMembershipAdded = _context.SaveChanges();
            return isMembershipAdded;
        }
    }
}
