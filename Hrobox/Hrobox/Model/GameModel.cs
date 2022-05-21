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
        public List<Tag> Tags { get; set; }
        public string Duration { get; set; }
        public string Version { get; set; }
        public int? MinNumPlayers { get; set; }
        public int? MaxNumPlayers { get; set; }
        public string FirstTag { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedAt { get; set; }
        public string AgeGroups { get; set; }
    }
}
