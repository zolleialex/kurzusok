using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [Required(ErrorMessage = "A tárgy név megadása kötelező!")]
        public string Name { get; set; }
        public int? EHours { get; set; }
        public int? GyHours { get; set; }
        [Required(ErrorMessage = "A tárgy kódjának megadása kötelező!")]
        public string SubjectCode { get; set; }
        public int SemesterId { get; set; }

        public virtual Semester Semester { get; set; }
        public virtual ICollection<Courses> Courses { get; set; }
        public ICollection<SubjectProgrammes> ProgrammesLink { get; set; }
    }
}
