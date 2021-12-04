using Kurzusok.Models;
using System;
using System.Collections.Generic;

namespace Kurzusok.ViewModels
{
    public class TeacherViewModel
    {
        public IList<Teachers> TeachersList { get; set; }

        public int LastSemesterWeek;

        public string[] LastTwoSemesterName = new string[2];

        public IList<Positions> Positions { get; set; }
    }
}
