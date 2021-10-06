using Kurzusok.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kurzusok.ViewModels
{
    public class HomeViewModel
    {
        private int semesterId;
        public IList<Subjects> Subjects { get; set; }
        public IList<Semester> Semester { get; set; }
        public IList<Courses> Courses { get; set; }
        public int GetSemesterId()
        {
            return semesterId;
        }
        public void SetSemesterId(int id)
        {
            semesterId = id;
        }

    }
}
