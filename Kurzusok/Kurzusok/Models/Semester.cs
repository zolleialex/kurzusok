using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Kurzusok.Models
{
    public partial class Semester
    {
        public Semester()
        {
            Subjects = new HashSet<Subjects>();
        }

        public int Id { get; set; }
        public string Date { get; set; }

        public virtual ICollection<Subjects> Subjects { get; set; }
    }
}
