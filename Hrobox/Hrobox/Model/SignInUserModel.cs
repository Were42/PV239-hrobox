using System;
using System.Collections.Generic;
using System.Text;

namespace Hrobox.Model
{
    public class SignInUserModel
    {
        public string Jwt { get; set; }
        public string Role { get; set; }
        public string Lang { get; set; }
    }
}
