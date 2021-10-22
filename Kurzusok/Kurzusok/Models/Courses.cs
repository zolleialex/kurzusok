﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Kurzusok.Models
{
    public partial class Courses
    {
        public int CourseId { get; set; }
        public int SubjectId { get; set; }
        public string CourseType { get; set; }
        public int? Members { get; set; }
        public string Classroom { get; set; }
        public string Comment { get; set; }
        public bool NeptunOk { get; set; }
        public string Software { get; set; }
        public int? Hours { get; set; }
        public string CourseCode { get; set; }

        public virtual Subjects Subject { get; set; }
        public ICollection<Teachers> TeachersLink { get; set; }
    }
}