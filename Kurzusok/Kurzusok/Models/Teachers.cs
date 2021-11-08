using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Kurzusok.Models
{
    public partial class Teachers
    {
        public int TeacherId { get; set; }

        [Required(ErrorMessage = "Az oktató nevének megadása kötelező!")]
        public string Name { get; set; }
        //[Required(ErrorMessage = "Az oktató terheltségének megadása kötelező!")]
        //[Range(1, 100, ErrorMessage = "Az oktató terheltsége csak 1 és 100 között egész érték lehet!")]
        public int Hoursperweek { get; set; }
        public ICollection<CoursesTeachers> CoursesLink { get; set; }
    }
}
