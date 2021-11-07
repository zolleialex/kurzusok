using System;
using System.Collections.Generic;

#nullable disable

namespace Kurzusok.Models
{
    public partial class Teachers
    {
        public int TeacherId { get; set; }
        public string Name { get; set; }
        public int? Hoursperweek { get; set; }
    }
}
