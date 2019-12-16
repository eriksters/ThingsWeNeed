using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThingsWeNeed.Service.Controllers.Registration
{
    public class RegistrationViewModel
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string PasswordValidation { get; set; }
    }
}