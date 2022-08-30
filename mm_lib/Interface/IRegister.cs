
namespace mm_lib.Interface
{
    public interface IRegister
    {
        public bool AddUser(Register r);
        public bool Login(string email, string password);
        public int GetOrgId(string email);
    }
}
