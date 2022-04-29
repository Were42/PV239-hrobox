using System;
using System.Collections.Generic;
using System.Text;
using CookBook.Mobile.Models;

namespace Hrobox.Model
{
    public class GameModel : ModelBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Rules { get; set; }
        public Tag Tag { get; set; }
        public Duration.DurationEnum Duration { get; set; }
        public string Version { get; set; }
        public int? MinNumPlayers { get; set; }
        public int? MaxNumPlayers { get; set; }
        public string MinMaxNumPlayers { get; set; }
        public string FirstTag { get; set; }
        public AgeGroup AgeGroups { get; set; }
    }
}
