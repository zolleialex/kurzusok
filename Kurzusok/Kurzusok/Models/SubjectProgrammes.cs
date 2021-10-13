using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Kurzusok.Models
{
    public partial class SubjectProgrammes
    {
        public int SubjectId { get; set; }
        public int ProgrammeId { get; set; }

        public  Programmes Programme { get; private set; }
        public Subjects Subject { get; private set; }
    }
}
