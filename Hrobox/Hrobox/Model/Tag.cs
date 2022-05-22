using System;
using System.Collections.Generic;
using System.Text;
using Hrobox.Utility;

namespace Hrobox.Model
{
    public class Tag
    {
        public int? Id { get; set; }
        public string NameEn { get; set; }
        public string NameCs { get; set; } = Constants.Default;
    }
}
