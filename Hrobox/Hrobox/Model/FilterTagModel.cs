using System;
using System.Collections.Generic;
using System.Text;

namespace Hrobox.Model
{
    public class FilterTagModel
    {
        public bool MatchAll { get; set; } = false;
        public List<int> Values { get; set; }
    }
}