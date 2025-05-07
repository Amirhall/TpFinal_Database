using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BD_WRC.Data;
using BD_WRC.Models;
using Microsoft.Data.SqlClient;

namespace BD_WRC.Controllers
{
    public class ClassementsController : Controller
    {
        private readonly BD_WRCContext _context;

        public ClassementsController(BD_WRCContext context)
        {
            _context = context;
        }

        // GET: Classements
        public async Task<IActionResult> Index()
        {
            var bD_WRCContext = _context.Classements.Include(c => c.Equipe).Include(c => c.Pilote).Include(c => c.Rallye).Include(c => c.Voiture);
            return View(await bD_WRCContext.ToListAsync());
        }



        public IActionResult RechercheCourse()
        {
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RechercheCourse(string nom, string prenom, DateTime dateDebut, DateTime dateFin) {
            string query = "EXEC Equipes.usp_ConsultationCoursesPilote @Nom,@Prenom, @DateDebut, @DateFin";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter{ParameterName = "@Nom", Value = nom},
                new SqlParameter{ParameterName = "@Prenom", Value = prenom},
                new SqlParameter{ParameterName = "@DateDebut", Value = dateDebut},
                new SqlParameter{ParameterName = "@DateFin", Value = dateFin},
            };
            try
            {
                var test = await _context.VwCoursesPilotes.FromSqlRaw(query, parameters.ToArray()).ToListAsync();
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Une erreur est survenur.Veuillez réessayez");
            }
            return View();
        }

        public async Task<IActionResult> VoituresRapide()
        {
            IEnumerable<VwVoituresVitesseMaxSupMoy> voitures = await _context.VwVoituresVitesseMaxSupMoys.ToListAsync();
            return View(voitures);
        }




        // GET: Classements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classement = await _context.Classements
                .Include(c => c.Equipe)
                .Include(c => c.Pilote)
                .Include(c => c.Rallye)
                .Include(c => c.Voiture)
                .FirstOrDefaultAsync(m => m.ClassementId == id);
            if (classement == null)
            {
                return NotFound();
            }

            return View(classement);
        }

        // GET: Classements/Create
        public IActionResult Create()
        {
            ViewData["EquipeId"] = new SelectList(_context.Equipes, "EquipeId", "EquipeId");
            ViewData["PiloteId"] = new SelectList(_context.Pilotes, "PiloteId", "PiloteId");
            ViewData["RallyeId"] = new SelectList(_context.Rallyes, "RallyeId", "RallyeId");
            ViewData["VoitureId"] = new SelectList(_context.Voitures, "VoitureId", "VoitureId");
            return View();
        }

        // POST: Classements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClassementId,Position,Temps,EquipeId,VoitureId,PiloteId,RallyeId")] Classement classement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(classement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EquipeId"] = new SelectList(_context.Equipes, "EquipeId", "EquipeId", classement.EquipeId);
            ViewData["PiloteId"] = new SelectList(_context.Pilotes, "PiloteId", "PiloteId", classement.PiloteId);
            ViewData["RallyeId"] = new SelectList(_context.Rallyes, "RallyeId", "RallyeId", classement.RallyeId);
            ViewData["VoitureId"] = new SelectList(_context.Voitures, "VoitureId", "VoitureId", classement.VoitureId);
            return View(classement);
        }

        // GET: Classements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classement = await _context.Classements.FindAsync(id);
            if (classement == null)
            {
                return NotFound();
            }
            ViewData["EquipeId"] = new SelectList(_context.Equipes, "EquipeId", "EquipeId", classement.EquipeId);
            ViewData["PiloteId"] = new SelectList(_context.Pilotes, "PiloteId", "PiloteId", classement.PiloteId);
            ViewData["RallyeId"] = new SelectList(_context.Rallyes, "RallyeId", "RallyeId", classement.RallyeId);
            ViewData["VoitureId"] = new SelectList(_context.Voitures, "VoitureId", "VoitureId", classement.VoitureId);
            return View(classement);
        }

        // POST: Classements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClassementId,Position,Temps,EquipeId,VoitureId,PiloteId,RallyeId")] Classement classement)
        {
            if (id != classement.ClassementId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(classement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassementExists(classement.ClassementId))
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
            ViewData["EquipeId"] = new SelectList(_context.Equipes, "EquipeId", "EquipeId", classement.EquipeId);
            ViewData["PiloteId"] = new SelectList(_context.Pilotes, "PiloteId", "PiloteId", classement.PiloteId);
            ViewData["RallyeId"] = new SelectList(_context.Rallyes, "RallyeId", "RallyeId", classement.RallyeId);
            ViewData["VoitureId"] = new SelectList(_context.Voitures, "VoitureId", "VoitureId", classement.VoitureId);
            return View(classement);
        }

        // GET: Classements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classement = await _context.Classements
                .Include(c => c.Equipe)
                .Include(c => c.Pilote)
                .Include(c => c.Rallye)
                .Include(c => c.Voiture)
                .FirstOrDefaultAsync(m => m.ClassementId == id);
            if (classement == null)
            {
                return NotFound();
            }

            return View(classement);
        }

        // POST: Classements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var classement = await _context.Classements.FindAsync(id);
            if (classement != null)
            {
                _context.Classements.Remove(classement);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassementExists(int id)
        {
            return _context.Classements.Any(e => e.ClassementId == id);
        }
    }
}
