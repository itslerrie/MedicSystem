using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicSystem.Filters
{
    public class FilterByAttribute : Attribute
    {
        public string DisplayName { get; set; }
    }
}