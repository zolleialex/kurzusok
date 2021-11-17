using Kurzusok.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using Kurzusok.Models;
using Kurzusok.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Kurzusok.Controllers
{
    [Authorize]
    public class CurriculumController : Controller
    {
        private readonly KurzusokContext _context;
        private CurriculumViewModel _curriculumViewModel;

        public CurriculumController(KurzusokContext context)
        {
            _curriculumViewModel = new CurriculumViewModel();
            _context = context;
        }
        public async Task<IActionResult> Index(int currentProgrammesId)
        {
            var CurriculmList = _context.Programmes.ToListAsync();
            _curriculumViewModel.CurriculmList = await CurriculmList;
            int lastId = _curriculumViewModel.CurriculmList.Last().ProgrammeId;
            Console.WriteLine(currentProgrammesId);
            Programmes CurrentCurriculum;
            CurrentCurriculum = await _context.Programmes.Where(c => c.ProgrammeId == currentProgrammesId).Include(b => b.ProgrammeDetails).FirstOrDefaultAsync();
            if (CurrentCurriculum == null) //Ha nincs a megadott ID-s szemeszter akkor az utolsót kérdezzük le
            {
                CurrentCurriculum = await _context.Programmes.Where(c => c.ProgrammeId == lastId).Include(b => b.ProgrammeDetails).FirstOrDefaultAsync();
            }

            _curriculumViewModel.CurrentCurriculum = CurrentCurriculum;


            return View(_curriculumViewModel);
        }
        // GET: Create subject
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateSubjectToCurr(int id)
        {
            Console.WriteLine(id);
            ProgrammeDetails prDetails = new ProgrammeDetails
            {
                ProgrammeId = id
            };
            
            return PartialView("_CreateSubjectToCurr", prDetails);
        }

    }
}
