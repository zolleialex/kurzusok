using System;
using System.Collections.Generic;

#nullable disable

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
        public int Weeks { get; set; }

        public virtual ICollection<Subjects> Subjects { get; set; }
    }
}
