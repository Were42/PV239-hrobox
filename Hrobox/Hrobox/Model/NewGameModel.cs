using System;
using System.Collections.Generic;
using System.Text;

namespace Hrobox.Model
{
    public class NewGameModel
    {
        public string NameEn { get; set; }
        public string NameCs { get; set; }
        public string RulesEn { get; set; }
        public string RulesCs { get; set; }
        public NrOfPlayers NrOfPlayers { get; set; }
        public string Duration { get; set; }
        public List<string> AgeGroups { get; set; }
        public List<int> Tags { get; set; }

    }
}
