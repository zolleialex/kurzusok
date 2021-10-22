using System;
using System.Collections.Generic;

#nullable disable

namespace Kurzusok.Models
{
    public partial class Programmes
    {
        public int ProgrammeId { get; set; }
        public string Name { get; set; }
        public string Training { get; set; }
        public string Levels { get; set; }
        public ICollection<SubjectProgrammes> SubjectLink { get; set; }
    }
}
