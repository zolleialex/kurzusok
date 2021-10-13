﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Kurzusok.Models
{
    public partial class Programmes
    {
        public int ProgrammeId { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string Training { get; set; }
        public string Levels { get; set; }
        public virtual ICollection<Subjects> SubjectLink { get; set; }
    }
}
