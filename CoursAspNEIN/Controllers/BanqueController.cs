using CoursAspNEIN.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoursAspNEIN.Controllers
{
    public class BanqueController : Controller
    {

        public IActionResult Index(int id)
        {
            Compte compte = Compte.RechercherCompte(id);
            return View(compte);
        }

        public IActionResult Detail(int id)
        {
            Compte compte = Compte.RechercherCompte(id);
            return View(compte);
        }

       

        public IActionResult Form(int? id)
        {
            Compte compte = (id != null) ? Compte.RechercherCompte((int)id) : null;
            return View(compte);

        }
        public IActionResult SubmitForm(Compte compte)
        {
            //Contact contact = new Contact { FirstName = firstName, LastName = lastName, Phone = phone };
            if (compte.Id > 0)
            {
                compte.MiseAJourCompte();
            }
            else
            {
                compte.AjouterCompte();
            }
            //on peut faire une redirection vers l'action index
            return RedirectToAction("Index", "Banque");
        }




    }
}
