using mm_lib;
using Microsoft.AspNetCore.Mvc;
using mm_lib.Interface;

namespace membership_management.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRegister _registerServices;
        private readonly IMembers _membersServices;
        private readonly IMembership _membershipServices;
        public HomeController(IRegister RegisterServices, IMembers MembersServices, IMembership MembershipServices)
        {
            _registerServices = RegisterServices;
            _membersServices = MembersServices;
            _membershipServices = MembershipServices;
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Register r)
        {
            bool isNewUserCreated = _registerServices.AddUser(r);
            if (isNewUserCreated)
            {
                ViewData["Message"] = "User created successfully";
            }
            else
            {
                ViewData["Message"] = "User not created, fill it again";
            }
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            bool isUserValid = _registerServices.Login(email, password);
            
            if (isUserValid)
            {
                int orgId = Convert.ToInt32(_registerServices.GetOrgId(email));
                HttpContext.Session.SetInt32("login_orgId", orgId);
                HttpContext.Session.SetString("login_email", email);
                return RedirectToAction("home");
            }
            else
            {
                ViewData["Message"] = "Invalid user";
            }
            return View();
        }
        public ActionResult Home()
        {
            if (HttpContext.Session.GetString("login_email") == null)
            {
                return RedirectToAction("Login");
            }  
            return View();
        }
        [HttpGet]
        public ActionResult AddMember()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddMember(string Name, string PhoneNo, DateTime Dob, bool Gender)
        {
            if (ModelState.IsValid)
            {
                int orgId = Convert.ToInt32(HttpContext.Session.GetInt32("login_orgId"));
                bool areMembersCreated = _membersServices.AddMember(Name, PhoneNo, Dob, Gender, orgId);
                if (areMembersCreated)
                {
                    ViewData["Message"] = "Added successfully";
                }
                else
                {
                    ViewData["Message"] = "Not successfull.Try again";
                }

                return View();
            }
            
            return View();
        }
        public ActionResult Members()
        {
            int orgId = Convert.ToInt32(HttpContext.Session.GetInt32("login_orgId"));
            var displayAllMembers = _membersServices.GetMembersByOrgId(orgId);
            ViewBag.displayAllMembers = displayAllMembers;
            return View();
        }
        [HttpGet]
        /* [Route("Home/AddMembership/{memberId:int}")] */
        public ActionResult AddMembership(int orgId,int memberId)
        {
            var displayMembersById = _membersServices.GetMembersByMemberId(memberId);
            ViewBag.displayMembersById = displayMembersById;
            TempData["orgId"] = orgId;
            TempData["memberId"] = memberId;
            TempData.Keep("orgId");
            TempData.Keep("memberId");
            return View();
        }
      
        [HttpPost]
        public ActionResult AddMembership(DateTime StartDate, int Duration, int AmountPaid)
        {
            int orgId = (int)TempData["orgId"];
            int memberId = (int)TempData["memberId"];
            var displayMembersById = _membersServices.GetMembersByMemberId(memberId);
            ViewBag.displayMembersById = displayMembersById;
            
            int isMembershipAdded = _membershipServices.AddMembership(orgId, memberId, StartDate, Duration, AmountPaid);
            if (isMembershipAdded > 0)
            {
                ViewBag.Message = "Added successfully";
            }
            else
            {
                ViewBag.Message = "Not successfully";
            }
            return View("Members");
        }               
    }
}