using Kurzusok.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kurzusok.ViewModels
{
    public class HomeViewModel
    {
        public IList<Semester> SemestersList { get; set; }
        public Semester CurrentSemester { get; set; }
        //public IList<Teachers> Teachers { get; set; }
        //public IList<Programmes> Programmes { get; set; }
    }
}
