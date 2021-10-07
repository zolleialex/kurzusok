using Kurzusok.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kurzusok.ViewModels
{
    public class HomeViewModel
    {
        public IList<Subjects> Subjects { get; set; }
        public IList<Semester> Semester { get; set; }
        public IList<Courses> Courses { get; set; }

    }
}
