using System;
using System.Collections.Generic;
using System.Text;

namespace Hrobox.Model
{
    internal class SignInUserModel
    {
        public string jwt { get; set; }
        public string role { get; set; }
        public string lang { get; set; }
    }
}
