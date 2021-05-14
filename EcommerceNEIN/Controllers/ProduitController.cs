using EcommerceNEIN.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceNEIN.Controllers
{
    public class ProduitController : Controller
    {
        IWebHostEnvironment _env;

        public ProduitController(IWebHostEnvironment env)
        {
            _env = env;
        }


        //public IActionResult Index(string search)
        //{
        //    List<Produit> produits = search == null ? Produit.GetAll() : Produit.SearchProduit(search);
        //    return View(produits);

        //}

        
        public IActionResult Details(int id)
        {
            Produit produit = Produit.GetContactById(id);
            return View(produit);
        }


        public IActionResult ConfirmDelete(int id)
        {
            Produit produit = Produit.GetContactById(id);
            return View(produit);
        }

        public IActionResult Delete(int id)
        {
            Produit produit = Produit.GetContactById(id);
            return View(produit != null ? produit.Delete() : false);
        }

        public IActionResult Form(int? id)
        {
            Produit produit = (id != null) ? Produit.GetContactById((int)id) : null;
            return View(produit);
        }

        //public IActionResult SubmitForm(string article, string categorie, etc)
        public IActionResult SubmitForm(Produit produit, IFormFile avatar)
        {
            //Produit produit = new Produit { Article = article, Categorie = categorie, Prix = prix };
            if (produit.Id > 0)
            {
                produit.Update();
            }
            else
            {
                produit.Url = Upload(avatar);
                produit.Save();
            }
            //on peut faire une redirection vers l'action index
            return RedirectToAction("Index", "Ecommerce");
        }

        private string Upload(IFormFile image)
        {
            string salt = Guid.NewGuid().ToString();
            string path = Path.Combine(_env.WebRootPath, "images", salt + "-" + image.FileName);
            //Création d'un flux vers le chemin cible
            Stream stream = System.IO.File.Create(path);
            image.CopyTo(stream);
            stream.Close();
            //stocker le chemin dans un viewBag, ou dans une base de données
            return "images/" + salt + "-" + image.FileName;
        }










    }
}
