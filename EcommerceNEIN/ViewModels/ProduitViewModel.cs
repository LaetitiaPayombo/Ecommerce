using EcommerceNEIN.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace EcommerceNEIN.ViewModels
{
    public class ProduitViewModel : ViewModelBase
    {

        private Produit produit;
        private string contentButton;
        public string Article { get => Produit.Article; set => Produit.Article = value; }
        public string Categorie { get => Produit.Categorie; set => Produit.Categorie = value; }
        public decimal Prix { get => Produit.Prix; set => Produit.Prix = value; }
        public int Stock { get => Produit.Stock; set => Produit.Stock = value; }
        public string Url { get => Produit.Url; set => Produit.Url = value; }


        public ICommand ConfirmCommand { get; set; }

        public ObservableCollection<Produit> Produits { get; set; }

        public Produit Produit
        {
            get => produit; set
            {
                produit = value;
                if (produit != null)
                {
                    RaisePropertyChanged("Article");
                    RaisePropertyChanged("Categorie");
                    RaisePropertyChanged("Prix");
                    RaisePropertyChanged("Stock");
                    RaisePropertyChanged("Url");
                    RaisePropertyChanged("ContentButton");
                }
            }
        }


        public string ContentButton { get => Produit.Id > 0 ? "Modifier" : "Ajouter"; }


        //public ProduitViewModel()
        //{
        //    Produit = new Produit();
        //    ConfirmCommand = new RelayCommand(ActionConfirmCommand);
        //    Produits = new ObservableCollection<Produit>(Produit.GetAll());
        //}


        //private void ActionConfirmCommand()
        //{
        //    if (Produit.Id > 0)
        //    {
        //        if (Produit.Update())
        //        {
        //           MessageBox.Show("Article mis à jour avec l'id " + Produit.Id);
        //            Produits = new ObservableCollection<Produit>(Produit.GetAll());
        //            RaisePropertyChanged("Produits");
        //            Produit = new Produit();
        //        }
        //    }
        //    else
        //    {
        //        if (Produit.Save())
        //        {
        //            MessageBox.Show("Article ajouté avec l'id " + Produit.Id);
        //            Produits.Add(Produit);
        //            Produit = new Produit();
        //        }
        //        else
        //        {
        //            MessageBox.Show("Erreur ajout article");
        //        }
        //    }

        //}


    }
}
