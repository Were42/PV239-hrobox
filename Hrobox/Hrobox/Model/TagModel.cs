using System;
using System.Collections.Generic;
using System.Text;
using CookBook.Mobile.Models;

namespace Hrobox.Model
{
    public class TagModel : ModelBase
    {
        public string Name { get; set; }
        public bool IsSelected { get; set; }
    }
}
