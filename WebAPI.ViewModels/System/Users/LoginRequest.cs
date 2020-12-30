using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.ViewModels.System.Users
{
    public class LoginRequest
    {

        public string Password { get; set; }

        public bool RememberMe { get; set; }

        public string Email { get; set; }
    }
}
