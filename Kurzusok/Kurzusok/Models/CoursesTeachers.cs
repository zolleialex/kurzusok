using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Kurzusok.Models
{
    public partial class CoursesTeachers
    {
        public int CourseId { get; set; }
        public int TeacherId { get; set; }
        public int? Loads { get; set; }

        public Courses Course { get; private set; }
        public Teachers Teacher { get; private set; }
    }
}
