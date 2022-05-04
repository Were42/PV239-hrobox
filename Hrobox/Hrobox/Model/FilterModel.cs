using System;
using System.Collections.Generic;
using System.Text;
using CookBook.Mobile.Models;
using Newtonsoft.Json;

namespace Hrobox.Model
{
    public class FilterModel : ModelBase
    {
        public int? Limit { get; set; }
        public int? Offset { get; set; }
        public string? Lang { get; set; } = "Cs";
        public string? Author { get; set; }
        public AgeGroup AgeGroup { get; set; }
        public List<string> Duration { get; set; }
        public FilterTagModel? Tags { get; set; }
        public int? NrOfPlayers { get; set; }

        public string? Name { get; set; } = "";
    }
}