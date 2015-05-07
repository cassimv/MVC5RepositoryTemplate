using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Template.BusinessLogic
{
    public interface IClinicBusiness
    {
        List<Template.Model.ClinicView> GetAllClinics();
    }
}
