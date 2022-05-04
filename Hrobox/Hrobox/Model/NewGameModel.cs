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
        public NumberOfPlayers NumberOfPlayers { get; set; }
        public List<string> Duration { get; set; }
        public List<string> AgeGroups { get; set; }
        public List<Tag> Tags { get; set; }

    }
}
