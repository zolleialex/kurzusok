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

        [Range(0, 100, ErrorMessage = "Az elméleti órák száma 0 és 100 közötti egész szám lehet!")]
        public int? EHours { get; set; }

        [Range(0, 100, ErrorMessage = "A gyakorlati órák száma 0 és 100 közötti egész szám lehet!")]
        public int? GyHours { get; set; }
        [Range(0, 100, ErrorMessage = "A labor órák száma 0 és 100 közötti egész szám lehet!")]
        public int? LHours { get; set; }

        [Required(ErrorMessage = "A tárgy kódjának megadása kötelező!")]
        public string SubjectCode { get; set; }
        public int SemesterId { get; set; }
        public string EducationType { get; set; }
        [Range(0, 100, ErrorMessage = "A levelezős órák száma 0 és 100 közötti egész szám lehet!")]
        public int? CorrespondHours { get; set; }

        public virtual Semester Semester { get; set; }
        public virtual ICollection<Courses> Courses { get; set; }
        public ICollection<SubjectProgrammes> ProgrammesLink { get; set; }
    }
}
