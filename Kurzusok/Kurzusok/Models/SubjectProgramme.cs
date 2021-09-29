using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Kurzusok.Models
{
    public partial class SubjectProgramme
    {
        public int SubjectsId { get; set; }
        public int SzakokId { get; set; }

        public virtual Subjects Subjects { get; set; }
        public virtual Programmes Szakok { get; set; }
    }
}
