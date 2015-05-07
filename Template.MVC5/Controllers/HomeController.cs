using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Template.BusinessLogic;

namespace Template.MVC.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var clinicbusiness = new ClinicBusiness();

            return View(clinicbusiness.GetAllClinics());
        }

    }
}
