using System;
using System.Collections.Generic;

#nullable disable

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
        public ICollection<SubjectProgrammes> ProgrammesLink { get; set; }
    }
}
