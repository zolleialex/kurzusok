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
        [Newtonsoft.Json.JsonIgnore]
        public Courses Course { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public Teachers Teacher { get; set; }
    }
}
