//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using BD_WRC.Data;
//using BD_WRC.Models;
//using Microsoft.AspNetCore.Authentication.Cookies;
//using Microsoft.AspNetCore.Authentication;
//using Microsoft.Data.SqlClient;
//using System.Security.Claims;
//using System.Security.Principal;

//namespace BD_WRC.Controllers
//{
//    public class UtilisateursController : Controller
//    {
//        private readonly BD_WRCContext _context;

//        public UtilisateursController(BD_WRCContext context)
//        {
//            _context = context;
//        }

//        public IActionResult Inscription()
//        {
//            return View();
//        }

//        // Inscription en requête post
//        [HttpPost]
//        public async Task<IActionResult> Inscription(InscriptionViewModel ivm)
//        {
//            // A COMPLETER LORS DE L'ETAPE 1
//            bool existeDeja = await _context.Utilisateurs.AnyAsync(x => x.Courriel == ivm.Courriel);
//            if (existeDeja)
//            {
//                ModelState.AddModelError("Courriel", "Ce courriel est déja utilisé.");
//                return View(ivm);
//            }
//            string query = "EXEC Clients.USP_CreerClient @Nom,@Prenom,@Courriel,@MotDePasse";
//            List<SqlParameter> parameters = new List<SqlParameter>
//            {
//                new SqlParameter{ParameterName = "@Nom", Value = ivm.Nom},
//                new SqlParameter{ParameterName = "@Prenom", Value = ivm.Prenom},
//                new SqlParameter{ParameterName = "@Courriel", Value = ivm.Courriel},
//                new SqlParameter{ParameterName = "@MotDePasse", Value = ivm.MotDePasse},
//            };
//            try
//            {
//                await _context.Database.ExecuteSqlRawAsync(query, parameters.ToArray());
//            }
//            catch (Exception)
//            {
//                ModelState.AddModelError("", "Une erreur est survenur.Veuillez réessayez");
//                return View(ivm);
//            }

//            return RedirectToAction("Spectacles/Index");
//        }

//        public IActionResult Connexion()
//        {

//            return View();
//        }

//        [HttpPost]
//        public async Task<IActionResult> Connexion(ConnexionViewModel cvm)
//        {
//            // A COMPLETER LORS DE L'ÉTAPE 1
//            //exécution de la procédure pour la connection d'un utilisateur

//            string query = "EXEC Clients.USP_AuthClient @Courriel,@MotDePasse";
//            List<SqlParameter> parameters = new List<SqlParameter>
//            {
//                new SqlParameter{ParameterName = "@Courriel", Value = cvm.Courriel},
//                new SqlParameter{ParameterName = "@MotDePasse", Value = cvm.MotDePasse},
//            };
//            Utilisateur? utilisateur = (await _context.Utilisateurs.FromSqlRaw(query, parameters.ToArray()).ToListAsync()).FirstOrDefault();
//            if (utilisateur == null)
//            {
//                ModelState.AddModelError("", "Courriel ou mot de passe est invalide");
//                return View(cvm);
//            }



//            // Construction du cookie d'authentification 
//            List<Claim> claims = new List<Claim>
//            {
//                new Claim(ClaimTypes.NameIdentifier, utilisateur.UtilisateursId.ToString()),
//                new Claim(ClaimTypes.Name, utilisateur.Courriel)
//            };

//            ClaimsIdentity identite = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
//            ClaimsPrincipal principal = new ClaimsPrincipal(identite);

//            // Cette ligne fournit le cookie à l'utilisateur
//            await HttpContext.SignInAsync(principal);
//            return RedirectToAction("Classements/Index");
//        }

//        [HttpGet]
//        public async Task<IActionResult> Deconnexion()
//        {
//            // Cette ligne mange le cookie 🍪 Slurp
//            await HttpContext.SignOutAsync();
//            return RedirectToAction("Classements/Index");
//        }

//    }
//}
