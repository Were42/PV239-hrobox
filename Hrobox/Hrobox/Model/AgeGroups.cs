using System.Collections.Generic;

namespace Hrobox.Model
{
    public class AgeGroup
    {
        public bool MatchAll { get; set; } = false;
        public List<string> Values { get; set; }
    }
}