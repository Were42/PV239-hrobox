using System;
using System.Collections.Generic;
using System.Text;
using CookBook.Mobile.Models;

namespace Hrobox.Model
{
    public class OutputGameModel : ModelBase
    {
        public int Id { get; set; }

        public int Version { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedAt { get; set; }
        public NrOfPlayers NrOfPlayers { get; set; }
        public string Duration { get; set; }
        public string[] AgeGroups { get; set; }
        public string[] Tags { get; set; }
    }
}
