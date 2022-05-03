using System.Collections.Generic;

namespace Hrobox.Model
{
    public class AgeGroups
    {
        public bool MatchAll { get; set; } = false;
        public List<AgeGroup> Values { get; set; }
        public enum AgeGroup
        {
            K,
            S,
            T,
            A

        }
    }
}