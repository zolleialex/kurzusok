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
        private HomeViewModel _homeViewModel;
        public HomeController(KurzusokContext context, HomeViewModel homeViewModel)
        {
            _homeViewModel = homeViewModel;
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
            _homeViewModel.SemestersList = await semesters;
            int lastId = _homeViewModel.SemestersList.Last().Id;
            Task<Semester> currentSemester;
            if (!string.IsNullOrEmpty(SearchPhrase))
            {
                //Egy adott szemeszter lekérdezése tárgynév szűréssel
                currentSemester = _context.Semester.Where(c => c.Id == currentSemesterId).Include(b => b.Subjects.Where(d => d.Name.Contains(SearchPhrase))).ThenInclude(k => k.Courses).ThenInclude(b => b.TeachersLink).ThenInclude(b => b.Teacher).Include(b => b.Subjects.Where(d => d.Name.Contains(SearchPhrase))).ThenInclude(k => k.ProgrammesLink).ThenInclude(k => k.Programme).FirstOrDefaultAsync();
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
            _homeViewModel.CurrentSemester = await currentSemester;
            return View(_homeViewModel);
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
            sbj.SemesterId = _homeViewModel.CurrentSemester.Id;
            var programmes = await _context.Programmes.ToListAsync();
            ViewBag.programmes = programmes;
            return PartialView("_SubjectModalPartial", sbj);
        }

        // POST:  Create subject       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSubjectPost([Bind("Id,SemesterId,SubjectCode,Name,EHours,GyHours")] Subjects subjects, List<int> AreChecked)
        {
            Console.WriteLine("Ezazbazdmeg");
            int currentSemesterId; 
            Console.WriteLine(subjects.Name);

            if (ModelState.IsValid)
            {
                foreach (var item in AreChecked)
                {
                    SubjectProgrammes pr = new SubjectProgrammes()
                    {
                        ProgrammeId = item,
                        EducationType = "valami",
                        Subject = subjects
                    };
                    _context.Add(pr);
                    await _context.SaveChangesAsync();
                    Console.WriteLine(item);
                }
                Subjects sbj = new Subjects();
                sbj.SemesterId = _homeViewModel.CurrentSemester.Id;
                var programmes = await _context.Programmes.ToListAsync();
                ViewBag.programmes = programmes;
                return PartialView("_SubjectModalPartial", sbj);

                //currentSemesterId = subjects.SemesterId;
                //return RedirectToAction(nameof(Index), new { currentSemesterId });

            }         
            currentSemesterId  = Convert.ToInt32(HttpContext.Session.GetString("SemesterId"));
            return RedirectToAction(nameof(Index), new { currentSemesterId});
        }
        // GET: Create course
        public IActionResult CreateCourse()
        {           
            Courses crs = new Courses();
            
            return PartialView("_CourseModalPartial", crs);
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
            string NewSemesterStr = "";
            int[] CopySemesterNumbers = NewSemesterNumbers; //CopySemester, aminek elemeit le kell másolni az új félévhez
            string CopySemesterStr = "";
            for (int i = 0; i < NewSemesterNumbers.Length; i++)
            {
                if (i == 2)
                {
                    NewSemesterStr += NewSemesterNumbers[i];
                    CopySemesterStr += CopySemesterNumbers[i];
                }
                else
                {
                    NewSemesterStr += NewSemesterNumbers[i] + "/";
                    CopySemesterStr += --CopySemesterNumbers[i] + "/";
                }
            }
            Console.WriteLine(CopySemesterStr);
            var CopySemesterObject = _context.Semester.Where(c => c.Date == CopySemesterStr).Include(b => b.Subjects).ThenInclude(k => k.Courses).ThenInclude(b => b.TeachersLink).ThenInclude(b => b.Teacher).Include(b => b.Subjects).ThenInclude(k => k.ProgrammesLink).ThenInclude(k => k.Programme).FirstOrDefault();
            Semester newSemester = new Semester
            {
                Date = NewSemesterStr,
                Weeks = 13,
            };
            List<Subjects> newSubjectList = new List<Subjects>();
            foreach (var copySubject in CopySemesterObject.Subjects)
            {
                Subjects newSubject = new Subjects
                {
                    SemesterId = newSemester.Id,
                    SubjectCode = copySubject.SubjectCode,
                    EHours = copySubject.EHours,
                    GyHours = copySubject.GyHours,
                    Name = copySubject.Name,
                    Semester = newSemester
                };
                List<Courses> newCourseList = new List<Courses>();
                foreach (var copyCourse in copySubject.Courses)
                {
                    Courses newCourse = new Courses
                    {
                        Classroom = copyCourse.Classroom,
                        Comment = copyCourse.Comment,
                        CourseCode = copyCourse.CourseCode,
                        CourseType = copyCourse.CourseType,
                        Hours = copyCourse.Hours,
                        Members = copyCourse.Members,
                        Software = copyCourse.Software,
                        SubjectId = newSubject.SubjectId,
                        Subject = newSubject
                    };
                    List<CoursesTeachers> newCoursesTeachersList = new List<CoursesTeachers>();
                    foreach (var copyCoursesTeachers in copyCourse.TeachersLink)
                    {
                        CoursesTeachers newCoursesTeachers = new CoursesTeachers
                        {
                            Teacher = copyCoursesTeachers.Teacher,
                            TeacherId = copyCoursesTeachers.TeacherId,
                            Course = newCourse,
                            CourseId = newCourse.CourseId,
                            Loads = copyCoursesTeachers.Loads
                        };
                        newCoursesTeachersList.Add(newCoursesTeachers);
                    }
                    newCourse.TeachersLink = newCoursesTeachersList;
                    newCourseList.Add(newCourse);
                }
                newSubject.Courses = newCourseList;
                List<SubjectProgrammes> newSubjectProgrammesList = new List<SubjectProgrammes>();
                foreach (var copySubjectProgrammes in copySubject.ProgrammesLink)
                {
                    SubjectProgrammes newSubjectProgrammes = new SubjectProgrammes
                    {
                        EducationType = copySubjectProgrammes.EducationType,
                        Obligatory = copySubjectProgrammes.Obligatory,
                        Programme = copySubjectProgrammes.Programme,
                        ProgrammeId = copySubjectProgrammes.ProgrammeId,
                        Subject = newSubject,
                        SubjectId = newSubject.SubjectId
                    };
                    newSubjectProgrammesList.Add(newSubjectProgrammes);
                }
                newSubject.ProgrammesLink = newSubjectProgrammesList;
                newSubjectList.Add(newSubject);
            }
            newSemester.Subjects = newSubjectList;
            _context.Add(newSemester);
            await _context.SaveChangesAsync();
            HttpContext.Session.SetString("SemesterId", "");
            return RedirectToAction(nameof(Index));

        }
        // DELETE Semester
        public async Task<IActionResult> SemesterDelete(int id)
        {
            var currentSemester = await _context.Semester.Where(c => c.Id == id).FirstOrDefaultAsync();
            var currentSubjects = await _context.Subjects.Where(c => c.SemesterId == currentSemester.Id).ToListAsync();
            List<List<Courses>> currentCourses = new List<List<Courses>>();
            List<List<CoursesTeachers>> currentCoursesTeachers = new List<List<CoursesTeachers>>();
            foreach (var subject in currentSubjects)
            {
                var curCourse = _context.Courses.Where(c => c.SubjectId == subject.SubjectId).ToList();
                currentCourses.Add(curCourse);
                foreach (var course in curCourse)
                {
                    currentCoursesTeachers.Add(_context.CoursesTeachers.Where(c => c.CourseId == course.CourseId).ToList());
                }
            }

            List<List<SubjectProgrammes>> currentSubjectProgrammes = new List<List<SubjectProgrammes>>();
            foreach (var subject in currentSubjects)
            {
                currentSubjectProgrammes.Add(_context.SubjectProgrammes.Where(c => c.SubjectId == subject.SubjectId).ToList());
            }
            _context.Semester.Remove(currentSemester);
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

        // POST: Home/SubjectDeleteDelete/5
        [Route("Home/SubjectDelete/{id?}")]
        public async Task<IActionResult> SubjectDelete(int id)
        {
            var currentSubject = await _context.Subjects.Where(c => c.SubjectId == id).FirstAsync();
            var currentCourses = _context.Courses.Where(c => c.SubjectId == id).ToList();
            List<List<CoursesTeachers>> currentCoursesTeachers = new List<List<CoursesTeachers>>();
            foreach (var course in currentCourses)
            {
                currentCoursesTeachers.Add(_context.CoursesTeachers.Where(c => c.CourseId == course.CourseId).ToList());
            }
            var currentSubjectProgrammes= await _context.SubjectProgrammes.Where(c => c.SubjectId == id).ToListAsync();
            _context.Subjects.Remove(currentSubject);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool SubjectsExists(int id)
        {
            return _context.Subjects.Any(e => e.SubjectId == id);
        }

        // POST: Home/CourseDelete/5
        [Route("Home/CourseDelete/{id?}")]
        public async Task<IActionResult> CourseDelete(int id)
        {
            var currentCourses = _context.Courses.Where(c => c.CourseId == id).First();
            var currentCoursesTeachers = _context.CoursesTeachers.Where(c => c.CourseId == id).ToList();
            _context.Courses.Remove(currentCourses);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
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
