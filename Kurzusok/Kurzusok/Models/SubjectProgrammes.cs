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
        [Newtonsoft.Json.JsonIgnore]
        public  Programmes Programme { get; set; }
        public  Subjects Subject { get; set; }
    }
}
