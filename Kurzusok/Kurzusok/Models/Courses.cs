using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Kurzusok.Models
{
    public partial class Courses
    {
        public int Id { get; set; }
        public string CourseType { get; set; }
        public int Members { get; set; }
        public string Classroom { get; set; }
        public string Comment { get; set; }
        public bool NeptunOk { get; set; }
        public string Softvware { get; set; }
        public int? Hours { get; set; }
        public string CourseCode { get; set; }
        public int SubjectId { get; set; }

        public virtual Subjects Subject { get; set; }
    }
}
