using mm_lib.Interface;

namespace mm_lib.Services 
{
    public class RegisterServices : IRegister
    {
        private readonly members_managementContext _context;
        public RegisterServices(members_managementContext context)
        {
            _context = context;
        }
        public bool AddUser(Register r)
        {
            _context.Register.Add(r);
            bool newUserCreated = _context.SaveChanges() > 0;
            return newUserCreated;
        }

        public bool Login(string email, string password)
        {
            bool isUserValid = _context.Register.Where(c => c.Email == email && c.Password == password).Any();
            return isUserValid;
        }

        public int GetOrgId(string email)
        {
            int getOrgId = Convert.ToInt32((from register in _context.Register
                                            where register.Email == email
                                            select register.OrgId).FirstOrDefault());
            return getOrgId;

        }
    }
}
