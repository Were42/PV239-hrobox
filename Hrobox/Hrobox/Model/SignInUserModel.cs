using System;
using System.Collections.Generic;
using System.Text;

namespace Hrobox.Model
{
    public class SignInUserModel
    {
        public string jwt { get; set; }
        public string role { get; set; }
        public string lang { get; set; }
    }
}
