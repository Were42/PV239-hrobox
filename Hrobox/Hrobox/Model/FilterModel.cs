using System;
using System.Collections.Generic;
using System.Text;
using CookBook.Mobile.Models;

namespace Hrobox.Model
{
    public class FilterModel : ModelBase
    {
        public bool IsQuarter { get; set; }
        public bool IsHalf { get; set; }
        public bool IsHour { get; set; }
        public bool IsAll { get; set; } = true;
        public bool IsKids { get; set; }
        public bool IsSchool { get; set; }
        public bool IsTeen { get; set; }
        public bool IsAdult { get; set; }

        public string KeyWord { get; set; } = "";
    }
}
