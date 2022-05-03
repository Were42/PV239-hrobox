using System;
using System.Collections.Generic;
using System.Text;

namespace Hrobox.Model
{
    public class FilterTagModel
    {
        public bool MatchAll { get; set; } = false;
        public int[] Values { get; set; }
    }
}
