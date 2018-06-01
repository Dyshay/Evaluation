using Caisse_Televie.Model.Client.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ToolBox.Patterns.MVVM.ViewModels;

namespace Caisse_Televie.ViewModel
{
    public class HistoriqueViewModel : ViewModelBase
    {
        private ObservableCollection<LigneDeCommande> _ListeCommand;
        public ObservableCollection<LigneDeCommande> ListCommand
        {
            get { return _ListeCommand ?? (_ListeCommand = new ObservableCollection<LigneDeCommande>()); }
        }

        public HistoriqueViewModel()
        {
            Locator.Instance.Liste.RecuperationCommande(ListCommand);
            MessageBox.Show("Implementation non terminée");
        }
    }
}
