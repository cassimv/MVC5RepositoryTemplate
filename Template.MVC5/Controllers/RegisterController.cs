using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using Template.BusinessLogic;
using Template.Model;

namespace Template.MVC5.Controllers
{
    public class RegisterController : Controller
    {
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> Index(RegisterModel objRegisterModel)
        {
            var registerbusiness = new Template.BusinessLogic.RegisterBusiness();

            if (registerbusiness.FindUser(objRegisterModel.UserName, AuthenticationManager))
            {
                ModelState.AddModelError("", "User already exists");
                return View(objRegisterModel);
            }

            var result = await registerbusiness.RegisterUser(objRegisterModel, AuthenticationManager);

            if (result)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", result.ToString());
            }

            return View(objRegisterModel);
        }

        public ActionResult TestInsert()
        {
            var clinicbusiness = new ClinicBusiness();

            clinicbusiness.AddClinic(
                new ClinicView()
                {
                    ClinicId = 0,
                    ClinicName = "Test",
                    User = new RegisterModel() {UserName = "cassimv", Password = "password"}
                }, AuthenticationManager);

            return RedirectToAction("Index");
        }
    }
}