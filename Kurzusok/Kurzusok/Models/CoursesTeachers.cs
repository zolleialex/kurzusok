using System;
using System.Collections.Generic;

#nullable disable

namespace Kurzusok.Models
{
    public partial class CoursesTeachers
    {
        public int CourseId { get; set; }
        public int TeacherId { get; set; }
        public int? Loads { get; set; }

        public virtual Courses Course { get; set; }
        public virtual Teachers Teacher { get; set; }
    }
}
