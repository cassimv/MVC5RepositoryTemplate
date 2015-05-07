using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Template.Data
{
    public class ApplicationUser:IdentityUser
    {
        public string FullName { get; set; }
    }
}