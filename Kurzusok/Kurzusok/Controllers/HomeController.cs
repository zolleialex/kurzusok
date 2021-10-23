using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Kurzusok.Data;
using Kurzusok.Models;
using Microsoft.AspNetCore.Authorization;
using Kurzusok.ViewModels;
using Microsoft.AspNetCore.Http;


namespace Kurzusok.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly KurzusokContext _context;
        private HomeViewModel homeViewModel;
        public HomeController(KurzusokContext context)
        {
            homeViewModel = new HomeViewModel();
            _context = context;
        }
        public IActionResult Index()
        {
            string SessionSemesterId = HttpContext.Session.GetString("SemesterId");
            int currentSemesterId;
            if (!string.IsNullOrEmpty(SessionSemesterId))
            {
                currentSemesterId = Convert.ToInt32(SessionSemesterId);
            }
            else
            {
                var semesters = _context.Semester.ToListAsync();
                currentSemesterId = semesters.Result.Last().Id;
            }
            return RedirectToAction(nameof(Index), new { currentSemesterId });
        }

        // GET: Home/{semester}
        [Authorize]
        [Route("{currentSemesterId}/{SearchPrase?}")]
        public async Task<IActionResult> Index(int currentSemesterId, string SearchPhrase)
        {
            //Összes szemeszter lekérdezése
            var semesters = _context.Semester.ToListAsync();
            homeViewModel.SemestersList = await semesters;
            int lastId = homeViewModel.SemestersList.Last().Id;
            Task<Semester> currentSemester;
            if (!string.IsNullOrEmpty(SearchPhrase))
            {
                //Egy adott szemeszter lekérdezése tárgynév szűréssel
                currentSemester = _context.Semester.Where(c => c.Id == currentSemesterId).Include(b => b.Subjects.Where(d => d.Name.Contains(SearchPhrase))).ThenInclude(k=>k.Courses).ThenInclude(b=>b.TeachersLink).ThenInclude(b=>b.Teacher).Include(b => b.Subjects.Where(d => d.Name.Contains(SearchPhrase))).ThenInclude(k => k.ProgrammesLink).ThenInclude(k=>k.Programme).FirstOrDefaultAsync();
            }
            else
            {
                //Egy adott szemeszter lekérdezése tárgyakkal
                currentSemester = _context.Semester.Where(c => c.Id == currentSemesterId).Include(b => b.Subjects).ThenInclude(k => k.Courses).ThenInclude(b => b.TeachersLink).ThenInclude(b => b.Teacher).Include(b => b.Subjects).ThenInclude(k => k.ProgrammesLink).ThenInclude(k => k.Programme).FirstOrDefaultAsync();
                if (currentSemester == null) //Ha nincs a megadott ID-s szemeszter akkor az utolsót kérdezzük le
                {
                    currentSemester = _context.Semester.Where(c => c.Id == lastId).Include(b => b.Subjects).ThenInclude(k => k.Courses).ThenInclude(b => b.TeachersLink).ThenInclude(b => b.Teacher).Include(b => b.Subjects).ThenInclude(k => k.ProgrammesLink).ThenInclude(k => k.Programme).FirstOrDefaultAsync();
                    HttpContext.Session.SetString("SemesterId", Convert.ToString(lastId));
                }
                else
                {
                    HttpContext.Session.SetString("SemesterId", Convert.ToString(currentSemesterId));
                }
            }
            homeViewModel.CurrentSemester = await currentSemester;
            return View(homeViewModel);
        }

        // GET: Subjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subjects = await _context.Subjects
                .FirstOrDefaultAsync(m => m.SubjectId == id);
            if (subjects == null)
            {
                return NotFound();
            }

            return View(subjects);
        }

        // GET: Create subject
        public async Task<IActionResult> CreateSubject(int id)
        {
            Console.WriteLine(id);            
            Subjects sbj = new Subjects();
            sbj.SemesterId = id;
            var programmes = await _context.Programmes.ToListAsync();
            ViewBag.programmes = programmes;
            return PartialView("_CourseModelPartial",sbj);
        }

        // POST:  Create subject       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSubjectPost([Bind("Id,SemesterId,SubjectCode,Name,EHours,GyHours")] Subjects subjects)
        {
            Console.WriteLine("HELOOOOOOOOOOOOOOOOOOOOOOO");
            int currentSemesterId;
            if (ModelState.IsValid)
            {               
                _context.Add(subjects);
                await _context.SaveChangesAsync();
                 currentSemesterId = subjects.SemesterId;
                return RedirectToAction(nameof(Index), new { currentSemesterId });
            }
            else
            {
                Console.WriteLine("Nope");
            }
             currentSemesterId = currentSemesterId = Convert.ToInt32(HttpContext.Session.GetString("SemesterId"));
            return RedirectToAction(nameof(Index), new { currentSemesterId });
        }
        //POST:  Create Semester
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSemester(string LastSemester)
        {
            int[] NewSemesterNumbers = LastSemester.Split('/').Select(int.Parse).ToArray();
            int startIteration = 0;
            if (NewSemesterNumbers[2] == 1)
            {
                startIteration = NewSemesterNumbers.Length - 1;
            }
            else
            {
                NewSemesterNumbers[2] = 0; //Ne folyjon át 3ra a szemeszter
            }
            for (int i = startIteration; i < NewSemesterNumbers.Length; i++)
            {
                NewSemesterNumbers[i]++;
            }
            string NewSemester = "";
            int[] CopySemesterNumbers = NewSemesterNumbers; //CopySemester, aminek elemeit le kell másolni az új félévhez
            string CopySemester = "";
            for (int i = 0; i < NewSemesterNumbers.Length; i++)
            {
                if (i == 2)
                {
                    NewSemester += NewSemesterNumbers[i];
                    CopySemester += CopySemesterNumbers[i];
                }
                else
                {
                    NewSemester += NewSemesterNumbers[i] + "/";
                    CopySemester += --CopySemesterNumbers[i] + "/";
                }
            }
            Semester semester = new Semester
            {
                Date = NewSemester
            };
            _context.Add(semester);
            await _context.SaveChangesAsync();
            HttpContext.Session.SetString("SemesterId", "");
            return RedirectToAction(nameof(Index));

        }
        // DELETE Semester
        public async Task<IActionResult> SemesterDelete(int id)
        {
            var subjects = await _context.Subjects.Where(c => c.SemesterId == id).ToListAsync();
            foreach (var subject in subjects)
            {
                _context.Subjects.Remove(subject);
            }
            await _context.SaveChangesAsync();
            var semester = await _context.Semester.FindAsync(id);
            _context.Semester.Remove(semester);
            await _context.SaveChangesAsync();
            HttpContext.Session.SetString("SemesterId", "");
            return RedirectToAction(nameof(Index));
        }

        // GET: Subjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subjects = await _context.Subjects.FindAsync(id);
            if (subjects == null)
            {
                return NotFound();
            }
            return View(subjects);
        }

        // POST: Subjects/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,EHours,GyHours,SubjectCode")] Subjects subjects)
        {
            if (id != subjects.SubjectId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subjects);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubjectsExists(subjects.SubjectId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(subjects);
        }

        // GET: Subjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subjects = await _context.Subjects
                .FirstOrDefaultAsync(m => m.SubjectId == id);
            if (subjects == null)
            {
                return NotFound();
            }

            return View(subjects);
        }

        // POST: Subjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subjects = await _context.Subjects.FindAsync(id);
            _context.Subjects.Remove(subjects);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubjectsExists(int id)
        {
            return _context.Subjects.Any(e => e.SubjectId == id);
        }

        // POST: Show SearchResult
        [Authorize]
        public IActionResult SearchResult(string SearchPhrase)
        {
            int currentSemesterId = Convert.ToInt32(HttpContext.Session.GetString("SemesterId"));
            return RedirectToAction(nameof(Index), new { currentSemesterId, SearchPhrase });
        }
    }
}
