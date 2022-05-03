using System;
using System.Collections.Generic;
using System.Text;
using CookBook.Mobile.Models;

namespace Hrobox.Model
{
    public class FilterModel : ModelBase
    {
        public int? Limit { get; set; }
        public int? Offset { get; set; } = 0;
        public string? Lang { get; set; }
        public string? Author { get; set; }
        public AgeGroups? AgeGroup { get; set; }
        public List<string> Duration { get; set; }
        public FilterTagModel? Tags { get; set; }

        public string? Name { get; set; } = "";
    }
}
