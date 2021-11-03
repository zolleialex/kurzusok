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
        [Required(ErrorMessage = "A kurzus típus megadása kötelező!")]
        public string CourseType { get; set; }
        public int? Members { get; set; }
        public string Classroom { get; set; }
        public string Comment { get; set; }
        public bool NeptunOk { get; set; }
        public string Software { get; set; }
        [Required(ErrorMessage = "A kurzus óráinak számát kötelező megadni!")]
        public int Hours { get; set; }
        [Required(ErrorMessage = "A kurzus kódjának megadása kötelező!")]
        public int CourseCode { get; set; }

        public virtual Subjects Subject { get; set; }
        public ICollection<CoursesTeachers> TeachersLink { get; set; }
    }
}
