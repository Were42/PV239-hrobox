using System;
using System.Collections.Generic;
using System.Text;

namespace Hrobox.Model
{
    internal class GameModel
    {
        public string Name { get; set; }
        public string Rules { get; set; }
        public Tag Tag { get; set; }
        public Duration Duration { get; set; }
        public string Version { get; set; }
        public int? MinNumPlayers { get; set; }
        public int? MaxNumPlayers { get; set; }
        public AgeGroup AgeGroups { get; set; }
    }
}
