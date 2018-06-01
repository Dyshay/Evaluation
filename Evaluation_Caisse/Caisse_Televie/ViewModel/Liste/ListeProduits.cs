using Caisse_Televie.Model.Client.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Caisse_Televie.ViewModel
{
    public class ListeProduits
    {
        public void RecuperationProduit(ObservableCollection<ProduitViewModel> ListProduit,int CategorieID)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:51550/api/");
            HttpResponseMessage reponse = client.GetAsync("Produit/").Result;
            if (reponse.IsSuccessStatusCode)
            {
                string text = reponse.Content.ReadAsStringAsync().Result;
                var tempConvert = JsonConvert.DeserializeObject<ObservableCollection<ProduitViewModel>>(text).Where(c => c.CategorieId == CategorieID);
                foreach (var item in tempConvert)
                {
                    ListProduit.Add(item);
                    //Locator.Instance.Boisson.ID = item.Id;
                }
            }
        }
        public ObservableCollection<ProduitViewModel> GetAll(ObservableCollection<ProduitViewModel> ListProduit)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:51550/api/");
            HttpResponseMessage reponse = client.GetAsync("Produit/").Result;
            if (reponse.IsSuccessStatusCode)
            {
                string textrecup = reponse.Content.ReadAsStringAsync().Result;
                var tempConvertUID = JsonConvert.DeserializeObject<ObservableCollection<ProduitViewModel>>(textrecup);
                foreach (var item in tempConvertUID)
                {
                    ListProduit.Add(item);
                }
                return ListProduit;
            }
            else
            {
                return null;
            }
        }
        public void RecuperationCommande(ObservableCollection<LigneDeCommande> ListProduit)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:51550/api/");
            HttpResponseMessage reponse = client.GetAsync("OrderLine/").Result;
            if (reponse.IsSuccessStatusCode)
            {
                string text = reponse.Content.ReadAsStringAsync().Result;
                var tempConvert = JsonConvert.DeserializeObject<ObservableCollection<LigneDeCommande>>(text);
                foreach (var item in tempConvert)
                {
                    ListProduit.Add(item);
                }
            }
        }
    }
}