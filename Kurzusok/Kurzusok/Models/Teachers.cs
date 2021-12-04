using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Kurzusok.Models
{
    public partial class Teachers
    {
        public int TeacherId { get; set; }

        [Required(ErrorMessage = "Az oktató nevének megadása kötelező!")]
        public string Name { get; set; }
        public int PositionId { get; set; }
        public bool IsWorking { get; set; }
        [NotMapped]
        public int[] LastTwoSemHours { get; set; }
        [NotMapped]
        public int[] LastSemHours { get; set; }
        public Positions Position { get; set; }
        public ICollection<CoursesTeachers> CoursesLink { get; set; }
    }
}
