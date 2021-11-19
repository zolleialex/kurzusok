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
using HtmlAgilityPack;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace Kurzusok.Controllers
{
    [Authorize]
    public class SyllabusController : Controller
    {
        private readonly KurzusokContext _context;
#pragma warning disable IDE0044 // Add readonly modifier
        private SyllabusViewModel _syllabusViewModel;
#pragma warning restore IDE0044 // Add readonly modifier

        public SyllabusController(KurzusokContext context)
        {
            _syllabusViewModel = new SyllabusViewModel();
            _context = context;
        }
        public IActionResult Index()
        {
            string SessionSyllabusId = HttpContext.Session.GetString("SyllabusId");

            int currentSyllabusId;
            if (!string.IsNullOrEmpty(SessionSyllabusId))
            {
                currentSyllabusId = Convert.ToInt32(SessionSyllabusId);
            }
            else
            {
                var semesters = _context.Semester.ToListAsync();
                currentSyllabusId = semesters.Result.Last().Id;
                HttpContext.Session.SetString("SyllabusId", Convert.ToString(currentSyllabusId));
            }
            return RedirectToAction(nameof(Index), new { currentSyllabusId });
        }
        [Route("Syllabus/{currentSyllabusId}")]
        public async Task<IActionResult> Index(int currentSyllabusId)
        {
            if (TempData.ContainsKey("ErrorMessage"))
            {
                ModelState.AddModelError("ReadError", TempData["ErrorMessage"].ToString());
            }
            var SyllabusList = _context.Programmes.ToListAsync();
            _syllabusViewModel.SyllabusList = await SyllabusList;
            int lastId = _syllabusViewModel.SyllabusList.Last().ProgrammeId;
            Programmes CurrentSyllabus;
            CurrentSyllabus = await _context.Programmes.Where(c => c.ProgrammeId == currentSyllabusId).Include(b => b.ProgrammeDetails).FirstOrDefaultAsync();
            if (CurrentSyllabus == null) //Ha nincs a megadott ID-s mintatanterv akkor az utolsót kérdezzük le
            {
                CurrentSyllabus = await _context.Programmes.Where(c => c.ProgrammeId == lastId).Include(b => b.ProgrammeDetails).FirstOrDefaultAsync();
                HttpContext.Session.SetString("SyllabusId", Convert.ToString(lastId));
            }
            else
            {
                HttpContext.Session.SetString("SyllabusId", Convert.ToString(currentSyllabusId));
            }
            _syllabusViewModel.CurrentSyllabus = CurrentSyllabus;
            return View(_syllabusViewModel);
        }
        // GET: Create syllabus
        public IActionResult CreateSubjectToSyllabus(int id)
        {
            ProgrammeDetails prDetails = new ProgrammeDetails
            {
                ProgrammeId = id
            };

            return PartialView("_CreateSubjectToSyllabus", prDetails);
        }

        // POST:  Create syllabus
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSubjectPost([Bind("Id,SemesterId,SubjectCode,Name,EHours,GyHours,LHours,CorrespondHours,EducationType")] Subjects subjects, List<int> programmes)
        {
            if (ModelState.IsValid && programmes.Count() > 0)
            {
                List<ProgrammeDetails> prgDetails = new List<ProgrammeDetails>();
                for (int i = 0; i < programmes.Count(); i++)//Leelenőrizni, hogy van-e ilyen a mintatantervbe
                {
                    int id = programmes[i];
                    var prSubject = await _context.ProgrammeDetails.Where(c => c.ProgrammeId == programmes[i] && c.Name == subjects.Name && c.SubjectCode == subjects.SubjectCode).FirstOrDefaultAsync();//Megkeresi a tantrágyat
                    if (prSubject == null)//Ha nincs, akkor hibával visszatér
                    {
                        var prog = await _context.Programmes.Where(c => c.ProgrammeId == programmes[i]).FirstOrDefaultAsync();
                        string responseText = "A " + prog.Name + " " + prog.Training + " mintatantervben nem szerepel a megadott tárgy ilyen tárgynévvel vagy kóddal.";
                        return Json(new { isvalid = false, responseText });
                    }
                    else
                    {// Ha van, akkor hozzáadja a listához, később kelleni fog
                        prgDetails.Add(prSubject);
                    }
                }
                for (int i = 0; i < programmes.Count(); i++)
                {
                    SubjectProgrammes pr = new SubjectProgrammes()
                    {
                        ProgrammeId = programmes[i],
                        Obligatory = prgDetails[i].Obligatory,// Hozzáadja a mintatantervből, hogy kötelező-e
                        Subject = subjects
                    };
                    _context.Add(pr);
                    await _context.SaveChangesAsync();
                }
                string subjectId = Convert.ToString(subjects.SubjectId);
                return Json(new { isvalid = true, createCourse = true, subjectid = subjectId });
            }
            return Json(new { isvalid = false });
        }

        public async Task<IActionResult> ReadFromWeb(int id, string url, string training)
        {
            var web = new HtmlWeb
            {
                OverrideEncoding = Encoding.UTF8
            };
            var doc = web.Load(url);
            var tables = doc.DocumentNode.SelectNodes("//*[@id='gen-content']/table");
            if (tables!=null)
            {
                bool delete = true;
                foreach (HtmlNode table in tables)
                {
                    int? code = null; int? name = null; int? gyhour = null; int? ehour = null; int? labhour = null; int? corrhour = null; int? cred = null; int? sem = null;
                    if (table.SelectSingleNode("preceding-sibling::b[1]").InnerText.ToLower().Contains("szakmai") || table.SelectSingleNode("preceding-sibling::b[1]").InnerText.ToLower().Contains("kötelező"))
                    {
                        var head = table.SelectNodes(".//thead/tr/child::*");
                        for (int i = 0; i < head.Count; i++)
                        {
                            if (head[i].HasChildNodes)
                            {
                                if (head[i].SelectSingleNode(".//b").InnerText.ToLower().Contains("kód"))
                                {
                                    code = i + 1;
                                }
                                else if (head[i].SelectSingleNode(".//b").InnerText.ToLower().Contains("nev"))
                                {
                                    name = i + 1;
                                }
                                else if (head[i].SelectSingleNode(".//b").InnerText.ToLower().Contains("elm."))
                                {
                                    if (training == "full")
                                    {
                                        ehour = i + 1;
                                    }
                                    else
                                    {
                                        corrhour = i + 1;
                                    }
                                }
                                else if (head[i].SelectSingleNode(".//b").InnerText.ToLower().Contains("gyak"))
                                {
                                    gyhour = i + 1;
                                }
                                else if (head[i].SelectSingleNode(".//b").InnerText.ToLower().Contains("lab"))
                                {
                                    labhour = i + 1;
                                }
                                else if (head[i].SelectSingleNode(".//b").InnerText.ToLower().Contains("krp"))
                                {
                                    cred = i + 1;
                                }
                                else if (head[i].SelectSingleNode(".//b").InnerText.ToLower().Contains("af"))
                                {
                                    sem = i + 1;
                                }
                            }
                        }
                        //Ha valami rossz a tábla struktúrába
                        if (code == null || name == null || cred == null)
                        {
                            TempData["ErrorMessage"] = "Nem sikerült lekérni a táblázatot az oldalról!";
                            return RedirectToAction("Index");
                        }
                        if (training == "full" && (ehour == null || gyhour == null || labhour == null))
                        {
                            TempData["ErrorMessage"] = "Nem sikerült lekérni a táblázatot az oldalról!";
                            return RedirectToAction("Index");
                        }
                        else if (training == "part" && corrhour == null)
                        {
                            TempData["ErrorMessage"] = "Nem sikerült lekérni a táblázatot az oldalról!";
                            return RedirectToAction("Index");
                        }
                        if (table.SelectSingleNode("preceding-sibling::b[1]").InnerText.ToLower().Contains("kötelező") && sem == null)
                        {
                            TempData["ErrorMessage"] = "Nem sikerült lekérni a táblázatot az oldalról!";
                            return RedirectToAction("Index");
                        }
                        var node = table.SelectNodes("tr");
                        foreach (HtmlNode row in node)
                        {
                            ProgrammeDetails prDetails;
                            HtmlNode subjectcode = row.SelectSingleNode($"td[{code}]");
                            if (subjectcode.InnerText.Contains("INT"))
                            {
                                HtmlNode subjectname = row.SelectSingleNode($"td[{name}]");
                                HtmlNode credit = row.SelectSingleNode($"td[{cred}]");
                                int? semester = null;
                                bool oblig = false;
                                if (sem != null)
                                {
                                    oblig = true;
                                    semester = int.Parse(row.SelectSingleNode($"td[{sem}]").InnerText);
                                }
                                if (training == "full")
                                {
                                    HtmlNode ehours = row.SelectSingleNode($"td[{ehour}]");
                                    HtmlNode gyhours = row.SelectSingleNode($"td[{gyhour}]");
                                    HtmlNode lhours = row.SelectSingleNode($"td[{labhour}]");
                                    prDetails = new ProgrammeDetails
                                    {
                                        ProgrammeId = id,
                                        SubjectCode = subjectcode.InnerText,
                                        Name = subjectname.InnerText,
                                        EHours = int.Parse(ehours.InnerText),
                                        GyHours = int.Parse(gyhours.InnerText),
                                        LabHours = int.Parse(lhours.InnerText),
                                        Obligatory = oblig,
                                        Credit = int.Parse(credit.InnerText),
                                        RecommendedSemester = semester
                                    };
                                }
                                else
                                {
                                    HtmlNode corrhours = row.SelectSingleNode($"td[{corrhour}]");
                                    prDetails = new ProgrammeDetails
                                    {
                                        ProgrammeId = id,
                                        SubjectCode = subjectcode.InnerText,
                                        Name = subjectname.InnerText,
                                        CorrespondHours = int.Parse(corrhours.InnerText),
                                        Obligatory = oblig,
                                        Credit = int.Parse(credit.InnerText),
                                        RecommendedSemester = semester
                                    };
                                }
                                if (delete)
                                {
                                    var deletethisprogramme = await _context.ProgrammeDetails.Where(b => b.ProgrammeId == id).ToListAsync();
                                    _context.ProgrammeDetails.RemoveRange(deletethisprogramme);
                                    delete = false;
                                }
                                _context.ProgrammeDetails.Add(prDetails);
                                await _context.SaveChangesAsync();
                            }
                        }
                    }
                }
            }
            else
            {
                TempData["ErrorMessage"] = "Nem megfelelő weboldal!";
            }
            return RedirectToAction("Index");
        }
    }
}
