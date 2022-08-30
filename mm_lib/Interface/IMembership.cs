
namespace mm_lib.Interface
{
    public interface IMembership
    {
        public int AddMembership(int orgId, int memberId, DateTime StartDate, int Duration, int AmountPaid);
    }
}
