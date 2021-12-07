using System;
using System.Collections.Generic;

#nullable disable

namespace Kurzusok.Models
{
    public partial class Programmes
    {
        public Programmes()
        {
            ProgrammeDetails = new HashSet<ProgrammeDetails>();
        }
        public int ProgrammeId { get; set; }
        public string Name { get; set; }
        public string Training { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public ICollection<ProgrammeDetails> ProgrammeDetails { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public ICollection<SubjectProgrammes> SubjectLink { get; set; }
    }
}
