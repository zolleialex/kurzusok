using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Kurzusok.Models
{
    public partial class CoursesTeachers
    {
        public int CoursesId { get; set; }
        public int TeachersId { get; set; }
        public int? Load { get; set; }

        public virtual Courses Courses { get; set; }
        public virtual Teachers Teachers { get; set; }
    }
}
