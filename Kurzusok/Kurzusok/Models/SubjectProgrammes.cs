using System;
using System.Collections.Generic;

#nullable disable

namespace Kurzusok.Models
{
    public partial class SubjectProgrammes
    {
        public int SubjectId { get; set; }
        public int ProgrammeId { get; set; }
        public bool Obligatory { get; set; }
        public string EducationType { get; set; }

        public virtual Programmes Programme { get; set; }
        public virtual Subjects Subject { get; set; }
    }
}
