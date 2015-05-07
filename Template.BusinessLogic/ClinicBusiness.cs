using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Template.Data;
using Template.Model;
using Template.Service;

namespace Template.BusinessLogic
{
    public class ClinicBusiness : IClinicBusiness
    {
        public UserManager<Template.Data.ApplicationUser> UserManager { get; set; }

        public ClinicBusiness()
        {
            UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new DataContext()));
        }

        public List<ClinicView> GetAllClinics()
        {
            using (var clinicrepo = new ClinicRepository())
            {
                return clinicrepo.GetAll().Select(x => new ClinicView() { ClinicId = x.ClinicId, ClinicName = x.ClinicName }).ToList();
            }
        }

        public void AddClinic(ClinicView objClinicView, IAuthenticationManager authenticationManager)
        {
            using (var clinicrepo = new ClinicRepository())
            {
                var newuser = new Template.Data.ApplicationUser()
               {
                   Id = objClinicView.User.UserName,
                   UserName = objClinicView.User.UserName,
                   Email = objClinicView.User.UserName,
                   PasswordHash = UserManager.PasswordHasher.HashPassword(objClinicView.User.Password),
                   SecurityStamp = Guid.NewGuid().ToString()
               };

                var clinic = new Clinic { ClinicId = objClinicView.ClinicId, ClinicName = objClinicView.ClinicName, User = newuser };
                clinicrepo.Insert(clinic);
            }
        }
    }
}
