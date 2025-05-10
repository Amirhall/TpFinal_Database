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
using System.Security.Claims;
using System.Security.Principal;
using BD_WRC.ViewModels;

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
            ViewData["Courriel"] = "Visiteur";
            IIdentity? identite = HttpContext.User.Identity;
            if (identite != null && identite.IsAuthenticated)
            {
                string courriel = HttpContext.User.FindFirstValue(ClaimTypes.Name);
                Utilisateur? utilisateur = await _context.Utilisateurs.FirstOrDefaultAsync(x => x.Courriel == courriel);
                if (utilisateur != null)
                {
                    // Pour dire "Bonjour X" sur l'index
                    ViewData["Courriel"] = utilisateur.Courriel;
                }
            }
            var bD_WRCContext = _context.Classements.Include(c => c.Equipe).Include(c => c.Pilote).Include(c => c.Rallye).Include(c => c.Voiture);
            var pilotes = _context.Pilotes;
            return View(await pilotes.ToListAsync());
        }
        public async Task<IActionResult> StatistiquePilote(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pilote = await _context.Pilotes
                .FirstOrDefaultAsync(m => m.PiloteId == id);
            if (pilote == null)
            {
                return NotFound();
            }

            VwPilotesStatistiquesAvancee vwPilotesStatistiquesAvancee = await _context.VwPilotesStatistiquesAvancees.Where(x => x.PiloteId == id).FirstOrDefaultAsync();
            string imageString = await _context.PhotoPilotes
                .Where(a => a.PiloteId == pilote.PiloteId)
                .Select(a => a.PilotePhotoContent == null ? null : $"data:image/png;base64, {Convert.ToBase64String(a.PilotePhotoContent)}")
                .FirstOrDefaultAsync();


            StatistiquePiloteViewModel statistiquePiloteViewModel = new StatistiquePiloteViewModel()

            {
                vwPilotesStatistiquesAvancee = vwPilotesStatistiquesAvancee,
                PhotoContent = imageString

            };


            return View(statistiquePiloteViewModel);
        }


        public IActionResult RechercheCourse()
        {
            IIdentity? identite = HttpContext.User.Identity;
            if (identite != null && identite.IsAuthenticated)
            {
                // return value like is IsAuthenticated
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RechercheCourse(string nom, string prenom, DateTime dateDebut, DateTime dateFin)
        {
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
                     List<VwCoursesPilote> classements = await _context.VwCoursesPilotes.FromSqlRaw(query, parameters.ToArray()).ToListAsync();
                   return View(classements);

            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Une erreur est survenur.Veuillez réessayez");
            }
            return View();
        }





        }
}
