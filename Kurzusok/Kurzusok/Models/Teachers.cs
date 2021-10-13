using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Kurzusok.Models
{
    public partial class Teachers
    {
        public int TeacherId { get; set; }
        public string Name { get; set; }
        public int? Hoursperweek { get; set; }
        public ICollection<Courses> CoursesLink { get; set; }
    }
}
