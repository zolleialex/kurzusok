using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Kurzusok.Data;
using Kurzusok.Models;
using Kurzusok.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Kurzusok.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TeachersController : Controller
    {
        private readonly KurzusokContext _context;
#pragma warning disable IDE0044 // Add readonly modifier
        private TeacherViewModel _teacherViewModel;
#pragma warning restore IDE0044 // Add readonly modifier

        public TeachersController(KurzusokContext context)
        {
            _context = context;
            _teacherViewModel = new TeacherViewModel();
        }

        [Route("Teachers")]
        public async Task<IActionResult> Index(bool justData, string search)
        {
            _teacherViewModel.LastTwoSemester = await _context.Semester.OrderByDescending(b => b.Date).Take(2).ToListAsync();
            _teacherViewModel.LastSemesterWeek = _teacherViewModel.LastTwoSemester.Where(b => b.Id == _teacherViewModel.LastTwoSemester.Max(b => b.Id)).Select(b => b.Weeks).FirstOrDefault();
            _teacherViewModel.Positions = await _context.Positions.AsNoTracking().Include(b => b.Teachers.Where(c => c.IsWorking)).ToListAsync();
            List<Teachers> teachers = new List<Teachers>();
            if (!string.IsNullOrEmpty(search))
            {
                teachers = await _context.Teachers.AsNoTracking().Where(b => b.Name.Contains(search)).OrderByDescending(b => b.IsWorking).Include(b => b.Position).Include(b => b.CoursesLink).ThenInclude(c => c.Course).ThenInclude(b => b.Subject).ThenInclude(k => k.Semester).Include(b => b.CoursesLink).ThenInclude(c => c.Course).ThenInclude(b => b.Subject).ThenInclude(v => v.ProgrammesLink).ThenInclude(i => i.Programme).ToListAsync();
            }
            else
            {
                teachers = await _context.Teachers.AsNoTracking().OrderByDescending(b => b.IsWorking).Include(b=>b.Position).Include(b => b.CoursesLink).ThenInclude(c => c.Course).ThenInclude(b => b.Subject).ThenInclude(k => k.Semester).Include(b => b.CoursesLink).ThenInclude(c => c.Course).ThenInclude(b => b.Subject).ThenInclude(v => v.ProgrammesLink).ThenInclude(i => i.Programme).ToListAsync();
            }
            _teacherViewModel.TeachersList = teachers;
            if (justData != true)
            {
                return View(_teacherViewModel);
            }
            else
            {
                return new EmptyResult();
            }

        }

        // GET: Teachers/Create
        public IActionResult AddTeacher()
        {
            Teachers t = new Teachers
            {
                IsWorking = true,
                Position = new Positions()
            };
            return PartialView("_TeacherModalPartial", t);
        }

        // POST: Teachers/AddTeacher
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddTeacherPost([Bind("TeacherId,Name,IsWorking,PositionId")] Teachers teacher)
        {
            if (ModelState.IsValid)
            {
                var isThere = await _context.Teachers.Where(b => b.Name == teacher.Name && b.Position == teacher.Position).FirstOrDefaultAsync();
                if (isThere == null)
                {
                    _context.Add(teacher);
                    await _context.SaveChangesAsync();
                    return Json(new { isvalid = true });
                }
                else
                {
                    string responseText = "Ilyen nevű oktató már szerepel az adatbázisban!";
                    return Json(new { isvalid = false, responseText });
                }
            }
            return Json(new { isvalid = false });
        }

        // GET: Teachers/EditTeacher
        public async Task<IActionResult> EditTeacher(int id)
        {
            var teacher = await _context.Teachers.Where(b => b.TeacherId == id).Include(b => b.Position).FirstOrDefaultAsync();
            if (teacher == null)
            {
                return NotFound();
            }
            return PartialView("_EditTeacherModalPartial", teacher);
        }

        // POST: Teachers/EditTeacher
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditTeacherPost([Bind("TeacherId,Name,IsWorking,PositionId")] Teachers teacher)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teacher);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeachersExists(teacher.TeacherId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Json(new { isvalid = true });
            }
            string responseText = "Hiba történt";
            return Json(new { isvalid = false, responseText });
        }

        // GET: Teachers/TeacherLeft
        public async Task<IActionResult> TeacherLeft(int id)
        {
            int? teacherid = await _context.Teachers.Where(m => m.TeacherId == id).Select(b => b.TeacherId).FirstOrDefaultAsync(); ;
            if (teacherid == null)
            {
                return NotFound();
            }
            return PartialView("_TeacherLeftModalPartial", teacherid);
        }

        // POST: Teachers/TeacherLeft/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TeacherLeftPost(int id)
        {
            var teacher = await _context.Teachers.FirstOrDefaultAsync(m => m.TeacherId == id);
            if (teacher == null)
            {
                return Json(new { isvalid = false, responseText = "Nem található az oktató az adatbázisban." });
            }
            else
            {
                teacher.IsWorking = false;
                _context.Teachers.Update(teacher);
                await _context.SaveChangesAsync();
                return Json(new { isvalid = true });
            }

        }
        public async Task<IActionResult> TeacherBack(int id)
        {
            int? teacherid = await _context.Teachers.Where(m => m.TeacherId == id).Select(b => b.TeacherId).FirstOrDefaultAsync(); ;
            if (teacherid == null)
            {
                return NotFound();
            }
            return PartialView("_TeacherBackModalPartial", teacherid);
        }

        // POST: Teachers/TeacherLeft/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TeacherBackPost(int id)
        {
            var teacher = await _context.Teachers.FirstOrDefaultAsync(m => m.TeacherId == id);
            if (teacher == null)
            {
                return Json(new { isvalid = false, responseText = "Nem található az oktató az adatbázisban." });
            }
            else
            {
                teacher.IsWorking = true;
                _context.Teachers.Update(teacher);
                await _context.SaveChangesAsync();
                return Json(new { isvalid = true });
            }

        }
        private bool TeachersExists(int id)
        {
            return _context.Teachers.Any(e => e.TeacherId == id);
        }

        public IActionResult Search(string search)
        {
            return RedirectToAction(nameof(Index), new { search });
        }

        public async Task<IActionResult> NextPosition(int posId)
        {
            await Index(true, null);
            var pos = await _context.Positions.Where(b => b.PositionId == posId).FirstOrDefaultAsync();
            string currentposName = pos.PositionName;
            int currentposWeek = pos.Hoursperweek;
            string visualdata = "[";
            bool notNull = false;
            foreach (Teachers teacher in _teacherViewModel.TeachersList)
            {
                if (teacher.IsWorking && teacher.PositionId == posId)
                {
                    notNull = true;
                    double? fullhours = 0;
                    double? parthours = 0;
                    double? subjecthours = 0;
                    foreach (var courselink in teacher.CoursesLink)
                    {
                        if (courselink.Course.Subject.Semester.Id == _teacherViewModel.LastTwoSemester[0].Id && (courselink.Course.CourseType == "Gyakorlat" || courselink.Course.CourseType == "Elmélet" || courselink.Course.CourseType == "Labor"))
                        {
                            foreach (var programme in courselink.Course.Subject.ProgrammesLink)
                            {

                                if (programme.Programme.Training == "nappali")
                                {
                                    if (courselink.Course.CourseType == "Gyakorlat")
                                    {
                                        subjecthours = courselink.Course.Subject.GyHours;
                                    }
                                    else if (courselink.Course.CourseType == "Elmélet")
                                    {
                                        subjecthours = courselink.Course.Subject.EHours;
                                    }
                                    else
                                    {
                                        subjecthours = courselink.Course.Subject.LHours;
                                    }

                                    fullhours += Convert.ToDouble(courselink.Loads) / 100 * subjecthours;
                                }
                                else
                                {
                                    double semWeek = _teacherViewModel.LastTwoSemester[0].Weeks;
                                    subjecthours = courselink.Course.Subject.CorrespondHours;
                                    parthours += Convert.ToDouble(courselink.Loads) / 100 * (subjecthours/semWeek);
                                }
                            }

                        }
                    }
                    string fullhoursStr = fullhours.ToString();
                    fullhoursStr=fullhoursStr.Replace(',', '.');
                    string parthoursStr = parthours.ToString();
                    parthoursStr = parthoursStr.Replace(',', '.');
                    visualdata += $"[\"{teacher.Name}\", {fullhoursStr},{parthoursStr}],";
                }
            }
            if (notNull)
            {
                visualdata = visualdata.Remove(visualdata.Length - 1, 1);
                visualdata += "]";
                return Json(new {isvalid=true, currentposName, currentposWeek, visualdata });
            }
            else
            {
                return Json(new { isvalid=false ,response = "A "+currentposName+" munkakörhöz nincs oktató rendelve." });
            }

        }
    }
}
