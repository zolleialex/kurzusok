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
            if (SessionSemesterId != null)
            {
                int semester = Convert.ToInt32(SessionSemesterId);
                return RedirectToAction(nameof(Index), new { semester });
            }
            else
            {
                return RedirectToAction(nameof(Index),null);
            }
        }

        // GET: Home/{semester}
        [Authorize]
        [Route("{semester?}")]
        public async Task<IActionResult> Index(int? semester)
        {
            var semesters = _context.Semester.ToListAsync();
            homeViewModel.Semester = await semesters;
            int lastId = homeViewModel.Semester.Last().Id;
            Task<List<Subjects>> subjects;
            if (semester == null)
            {
                subjects = _context.Subjects.Where(s => s.SemesterId == lastId).ToListAsync();
                HttpContext.Session.SetString("SemesterId", Convert.ToString(lastId));
            }
            else
            {
                subjects = _context.Subjects.Where(c => c.SemesterId == semester).ToListAsync();
                if (subjects.Result.Count() == 0)
                {
                    subjects = _context.Subjects.Where(s => s.SemesterId == lastId).ToListAsync();
                }
                else
                {
                    HttpContext.Session.SetString("SemesterId", Convert.ToString(semester));
                }
            }
            homeViewModel.Subjects = await subjects;
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
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subjects == null)
            {
                return NotFound();
            }

            return View(subjects);
        }

        // GET: Subjects/Create
        public IActionResult Create(int? id)
        {
            ViewBag.SemesterId = id;
            return View();
        }

        // POST: Subjects/Create        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,EHours,GyHours,SubjectCode,SemesterId")] Subjects subjects)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subjects);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
        //POST:  Create Semester
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSemester(string SemesterName)
        {
            string SessionSemesterId = SemesterName;
            Semester semester = new Semester { 
                Date=SemesterName
            };
            _context.Add(semester);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
        // DELETE Semester
        public async Task<IActionResult> SemsterDelete(int id)
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
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,EHours,GyHours,SubjectCode")] Subjects subjects)
        {
            if (id != subjects.Id)
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
                    if (!SubjectsExists(subjects.Id))
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
                .FirstOrDefaultAsync(m => m.Id == id);
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
            return _context.Subjects.Any(e => e.Id == id);
        }

        // POST: Show SearchResult
        [Authorize]
        public async Task<IActionResult> SearchResult(String SearchPhrase)
        {
            return View("Index", await _context.Subjects.Where(j => j.Name.Contains(SearchPhrase)).ToListAsync());
        }
        //GET: URL Param
        [HttpGet()]
        public IActionResult GetParam([FromQuery(Name = "sem")] string sem)
        {
            return Content(sem);
        }
    }
}
