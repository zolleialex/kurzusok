using System;
using System.Collections.Generic;

#nullable disable

namespace Kurzusok.Models
{
    public partial class ProgrammeDetails
    {
        public int Id { get; set; }
        public int ProgrammeId { get; set; }
        public string SubjectCode { get; set; }
        public string Name { get; set; }
        public int? EHours { get; set; }
        public int? GyHours { get; set; }
        public int? LabHours { get; set; }
        public int? CorrespondHours { get; set; }
        public int Credit { get; set; }
        public int? RecommendedSemester { get; set; }
        public bool Obligatory { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public Programmes Programme { get; set; }
    }
}
