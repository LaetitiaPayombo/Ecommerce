using EcommerceNEIN.DAO;
using EcommerceNEIN.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Text;

namespace EcommerceNEIN.Models
{
    public class Produit
    {

        private int id;
        private string article;
        private string categorie;
        private decimal prix;
        private int stock;
        private string url;

        public int Id { get => id; set => id = value; }
        public string Article { get => article; set => article = value; }
        public string Categorie { get => categorie; set => categorie = value; }
        public decimal Prix { get => prix; set => prix = value; }
        public int Stock { get => stock; set => stock = value; }
        public string Url { get => url; set => url = value; }


        public bool Save()
        {
            AbstractDAO<Produit> dao = new ProduitDAO();
            return dao.Create(this);
        }


        public bool Update()
        {
            AbstractDAO<Produit> dao = new ProduitDAO();
            return dao.Update(this);
        }


        public static Produit GetContactById(int id)
        {
            AbstractDAO<Produit> dao = new ProduitDAO();
            return dao.Find(id);
        }

        public bool Delete()
        {
            AbstractDAO<Produit> dao = new ProduitDAO();
            return dao.Delete(this);
        }

        public static List<Produit> GetAll()
        {
            AbstractDAO<Produit> dao = new ProduitDAO();
            return dao.FindAll();
        }

        public static List<Produit> SearchProduit(string search)
        {
            AbstractDAO<Produit> dao = new ProduitDAO();
            return dao.Find(p => p.Article.Contains(search) || p.Categorie.Contains(search));
        }



    }
}
