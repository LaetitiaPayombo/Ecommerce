using EcommerceNEIN.Models;
using EcommerceNEIN.Tools;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace EcommerceNEIN.DAO
{
    class ProduitDAO : AbstractDAO<Produit>
    {


        public override bool Create(Produit element)
        {
            request = "INSERT INTO produit(article, categorie, prix, stock, url) " +
                "OUTPUT INSERTED.ID values (@article, @categorie, @prix, @stock, @url)";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@article", element.Article));
            command.Parameters.Add(new SqlParameter("@categorie", element.Categorie));
            command.Parameters.Add(new SqlParameter("@prix", element.Prix));
            command.Parameters.Add(new SqlParameter("@stock", element.Stock));
            command.Parameters.Add(new SqlParameter("@url", element.Url));
            connection.Open();
            element.Id = (int)command.ExecuteScalar();
            command.Dispose();
            connection.Close();
            return element.Id > 0;
        }


        public override bool Delete(Produit element)
        {
            request = "delete from produit where id=@id";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@id", element.Id));
            connection.Open();
            int nbrLigne = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbrLigne > 0;
        }



        public override Produit Find(int index)
        {
            Produit produit = null;
            request = "SELECT id, article, categorie, prix, stock, url from produit where id=@id";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@id", index));
            connection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                produit = new Produit
                {
                    Id = index,
                    Article = reader.GetString(1),
                    Categorie = reader.GetString(2),
                    Prix = reader.GetDecimal(3),
                    Stock = reader.GetInt32(4),
                    Url = reader.GetString(5)
                };
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return produit;
        }



        public override List<Produit> Find(Func<Produit, bool> criteria)
        {
            List<Produit> produits = new List<Produit>();
            FindAll().ForEach(p =>
            {
                if (criteria(p))
                {
                    produits.Add(p);
                }
            });
            return produits;
        }


        public override List<Produit> FindAll()
        {
            List<Produit> produits = new List<Produit>();
            request = " id, article, categorie, prix, stock, url from produit";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Produit c = new Produit
                {
                    Id = reader.GetInt32(0),
                    Article = reader.GetString(1),
                    Categorie = reader.GetString(2),
                    Prix = reader.GetDecimal(3),
                    Stock = reader.GetInt32(4),
                    Url = reader.GetString(5)
                };
                produits.Add(c);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return produits;
        }



        public override bool Update(Produit element)
        {
            request = "UPDATE produit set article = @article, categorie = @categorie, prix = @prix, stock = @stock, url = @url, where id=@id";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@article", element.Article));
            command.Parameters.Add(new SqlParameter("@categorie", element.Categorie));
            command.Parameters.Add(new SqlParameter("@prix", element.Prix));
            command.Parameters.Add(new SqlParameter("@stock", element.Stock));
            command.Parameters.Add(new SqlParameter("@url", element.Stock));
            connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbRow == 1;
        }






    }
}
