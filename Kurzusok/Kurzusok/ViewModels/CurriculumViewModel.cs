using Kurzusok.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kurzusok.ViewModels
{
    public class CurriculumViewModel
    {
        public IList<Programmes> CurriculmList { get; set; }
        public Programmes CurrentCurriculum { get; set; }


    }
}
