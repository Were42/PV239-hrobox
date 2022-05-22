using System;
using System.Collections.Generic;
using System.Text;
using Hrobox.Utility;

namespace Hrobox.Model
{
    public class UserModel
    {
        public string Name { get; set; } = Constants.Default;
        public string Email { get; set; }
        public string Password { get; set; }
        public string Lang { get; set; } = Constants.Lang;
    }
}
