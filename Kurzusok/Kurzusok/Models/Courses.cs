using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Kurzusok.Models
{
    public partial class Courses
    {
        public int CourseId { get; set; }
        public int SubjectId { get; set; }
        public string CourseType { get; set; }
        [Range(0, 1000, ErrorMessage = "Az létszám csak 0 és 1000 között egész érték lehet!")]
        public int Members { get; set; }
        public string Classroom { get; set; }
        public string Comment { get; set; }
        public bool NeptunOk { get; set; }
        public string Software { get; set; }
        [Range(0, 100, ErrorMessage = "A kurzus óraszáma csak 0 és 100 között egész érték lehet!")]
        public int? Hours { get; set; }
        [Required(ErrorMessage = "Az kurzus kódjának megadása kötelező!")]
        [Range(0, 100, ErrorMessage = "A kurzus kódja 0 és 100 között egész érték lehet!")]
        public int CourseCode { get; set; }

        public virtual Subjects Subject { get; set; }
        public ICollection<CoursesTeachers> TeachersLink { get; set; }
    }
}
