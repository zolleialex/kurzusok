using Kurzusok.Models;
using System;
using System.Collections.Generic;

namespace Kurzusok.ViewModels
{
    public class TeacherViewModel
    {
        public IList<Teachers> TeachersList { get; set; }

        public int LastSemesterWeek;

        public IList<Semester> LastTwoSemester { get; set; } 

        public IList<Positions> Positions { get; set; }
    }
}
