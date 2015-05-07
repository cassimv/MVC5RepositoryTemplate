using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Template.Model
{
    public class ClinicView
    {
        public int ClinicId { get; set; }
        public string ClinicName { get; set; }
        public RegisterModel User { get; set; }
    }
}

