using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Kurzusok.Models
{
    public partial class CoursesTeachers
    {
        public int CourseId { get; set; }
        public int TeacherId { get; set; }
        [Required(ErrorMessage = "Az oktató terheltségének megadása kötelező!")]
        [Range(1, 100, ErrorMessage = "Az oktató terheltsége csak 1 és 100 között egész érték lehet!")]
        public int Loads { get; set; }
        public double? HoursPerSemester { get; set; }
        public virtual Courses Course { get; set; }
        public virtual Teachers Teacher { get; set; }
    }
}
