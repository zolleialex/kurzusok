using Kurzusok.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kurzusok.ViewModels
{
    public class SyllabusViewModel
    {
        public IList<Programmes> SyllabusList { get; set; }
        public Programmes CurrentSyllabus { get; set; }


    }
}
