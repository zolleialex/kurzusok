using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Kurzusok.Models
{
    public partial class Subjects
    {
        public Subjects()
        {
            Courses = new HashSet<Courses>();
        }

        public int SubjectId { get; set; }
        public string Name { get; set; }
        public int? EHours { get; set; }
        public int? GyHours { get; set; }
        public string SubjectCode { get; set; }
        public int SemesterId { get; set; }

        public virtual Semester Semester { get; set; }
        public virtual ICollection<Courses> Courses { get; set; }
        public virtual ICollection<Programmes> ProgrammesLink { get; set; }
    }
}
