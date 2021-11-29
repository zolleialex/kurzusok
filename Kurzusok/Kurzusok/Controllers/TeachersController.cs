using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Kurzusok.Data;
using Kurzusok.Models;
using System;

namespace Kurzusok.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TeachersController : Controller
    {
        private readonly KurzusokContext _context;

        public TeachersController(KurzusokContext context)
        {
            _context = context;
        }

        [Route("Teachers")]
        public async Task<IActionResult> Index(string search)
        {
            if (!string.IsNullOrEmpty(search))
            {
                return View(await _context.Teachers.Where(b=>b.Name.Contains(search)).OrderByDescending(b => b.IsWorking).Include(b => b.Position).ToListAsync());
            }
            else
            {
                return View(await _context.Teachers.OrderByDescending(b => b.IsWorking).Include(b=>b.Position).ToListAsync());
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
                if (isThere==null)
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
            var teacher = await _context.Teachers.Where(b=>b.TeacherId==id).Include(b=>b.Position).FirstOrDefaultAsync();
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
            if (teacher==null)
            {
                return Json(new { isvalid = false, responseText ="Nem található az oktató az adatbázisban." });
            }
            else
            {
                teacher.IsWorking = false;
                _context.Teachers.Update(teacher);
                await _context.SaveChangesAsync();
                return Json(new { isvalid = true});
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
    }
}
