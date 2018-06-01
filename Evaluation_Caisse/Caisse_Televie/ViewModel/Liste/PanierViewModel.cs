using Caisse_Televie.Model.Client.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.Patterns.Mediators;
using ToolBox.Patterns.MVVM.Commands;
using ToolBox.Patterns.MVVM.ViewModels;
using Caisse_Televie.Model.Client.Services;

namespace Caisse_Televie.ViewModel
{
    public class PanierViewModel : ViewModelBase
    {
        private int _ProduitId;

        public int ProduitId
        {
            get { return _ProduitId; }
            set { _ProduitId = value; }
        }
        private int _CategorieId;

        public int CategorieId
        {
            get { return _CategorieId; }
            set { _CategorieId = value; }
        }
        private string _Nom;

        public string Nom
        {
            get { return _Nom; }
            set { _Nom = value; RaisePropertyChanged(); }
        }
        private double _Prix;

        public double Prix
        {
            get { return _Prix; }
            set { _Prix = value; RaisePropertyChanged(); }
        }
        private int _Quantite;

        public int Quantite
        {
            get { return _Quantite; }
            set { _Quantite = value; RaisePropertyChanged(); }
        }
        private double _PrixSimple;

        public double PrixSimple
        {
            get { return _PrixSimple; }
            set { _PrixSimple = value; }
        }
        private double _PrixTotal;

        public double PrixTotal
        {
            get { return _PrixTotal; }
            set { _PrixTotal = value; RaisePropertyChanged(); }
        }

        private bool _IsBenenvol;

        public bool IsBenevol
        {
            get { return _IsBenenvol; }
            set { _IsBenenvol = value; }
        }
        private string _ValeurClientouBene;

        public string ValeurClientouBene
        {
            get { return _ValeurClientouBene; }
            set { _ValeurClientouBene = value;RaisePropertyChanged(); }
        }




        private ObservableCollection<ProduitViewModel> _PanierList;
        public ObservableCollection<ProduitViewModel> PanierList
        {
            get { return _PanierList ?? (_PanierList = new ObservableCollection<ProduitViewModel>()); }
        }

        private ObservableCollection<ProduitViewModel> _Ready;
        public ObservableCollection<ProduitViewModel> Ready
        {
            get { return _Ready ?? (_Ready = new ObservableCollection<ProduitViewModel>()); }
        }

        public PanierViewModel()
        {
            Mediator<int>.Instance.Register(onClick);
            Locator.Instance.Liste.GetAll(PanierList);
            ValeurClientouBene = "Client";
        }

        private void BenevolBool(bool obj)
        {
            IsBenevol = obj;
        }

        private void onClick(int obj)
        {
            {
                foreach (ProduitViewModel item in PanierList)
                {
                    if (item.ProduitId == obj)
                    {
                        if (item.Nom == Nom)
                        {
                            Quantite++;
                            Prix += PrixSimple;
                        }
                        else
                        {
                            Nom = item.Nom;
                            Quantite = 0;
                            Prix = 0;
                            Quantite++;
                            PrixSimple = item.Prix;
                            Prix += PrixSimple * Quantite;
                            CategorieId = item.CategorieId;
                        }
                    }
                }
            }
        }
        private ICommand _AjouterBtn;
        public ICommand AjouterBtn
        {
            get { return _AjouterBtn ?? (_AjouterBtn = new RelayCommand(AjouterExec,AjouterCanExec)); }
        }

        private bool AjouterCanExec()
        {
            if (Nom == null)
            {
                return false;   
            }
            else
            {
                return true;
            }
        }

        private void AjouterExec()
        {
            foreach (ProduitViewModel item in PanierList)
            {
                if (item.Nom == Nom)
                {
                    if (Ready.Contains(item))
                    {
                        foreach (ProduitViewModel ReadyContent in Ready)
                        {
                            if (item.ProduitId == ReadyContent.ProduitId)
                            {
                                ReadyContent.Quantite += Quantite;
                                ReadyContent.TestPrix += Prix;
                                PrixTotal += Prix;
                                Quantite = 1;
                                Prix = PrixSimple;
                            }
                        };
                    }
                    else
                    {
                        item.Quantite = Quantite;
                        Prix = item.Prix * Quantite;
                        item.TestPrix = Prix;
                        PrixTotal += Prix;
                        Ready.Add(item);
                        Prix = PrixSimple;
                        Quantite = 1;
                    }
                }
            }
        }
        private ICommand _AnnulationBtn;
        public ICommand AnnulationBtn
        {
            get { return _AnnulationBtn ?? (_AnnulationBtn = new RelayCommand(AnnulExec)); }
        }
        

        private void AnnulExec()
        {
            Ready.Clear();
        }

        private ICommand _PlusBtn;
        public ICommand PlusBtn
        {
            get { return _PlusBtn ?? (_PlusBtn = new RelayCommand(PlusExec,PlusCanExec)); }
        }

        private bool PlusCanExec()
        {
            if (Quantite == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private ICommand _MoinsBtn;
        public ICommand MoinsBtn
        {
            get { return _MoinsBtn ?? (_MoinsBtn = new RelayCommand(MoinsExec,MoinsCanExec)); }
        }

        private void MoinsExec()
        {
            Quantite--;
            Prix -= PrixSimple;
        }

        private bool MoinsCanExec()
        {
            if (Quantite <= 1)
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }

        private void PlusExec()
        {
            Quantite++;
            Prix += PrixSimple;
        }
        private ICommand _PayerBtn;
        public ICommand PayerBtn
        {
            get { return _PayerBtn ?? (_PayerBtn = new RelayCommand(PayerExec)); }
        }
        private List<LigneDeCommande> _InsterDb;
        public List<LigneDeCommande> InsterDb
        {
            get { return _InsterDb ?? (_InsterDb = new List<LigneDeCommande>()); }
        }
        private void PayerExec()
        {
            Mediator<bool>.Instance.Send(false);
                Commande x = new Commande(IsBenevol);
            ServiceClientLocator.Instance.Commande.Insert(x);
            foreach (var item in Ready)
            {
                LigneDeCommande Ligne = new LigneDeCommande(0,item.ProduitId, item.Quantite, item.TestPrix);
                InsterDb.Add(Ligne);
                if (Ready.Count == InsterDb.Count)
                {
                    foreach (var Insert in InsterDb)
                    {
                    ServiceClientLocator.Instance.LigneDeCommand.Insert(Insert);

                    }

                }
            }
            Ready.Clear();
            InsterDb.Clear();
            PrixTotal = 0;
        }
        private ICommand _SwitchClient_Benevol;
        public ICommand SwitchClient_Benevol
        {
            get { return _SwitchClient_Benevol ?? (_SwitchClient_Benevol = new RelayCommand(SwitchExe)); }
        }

        private void SwitchExe()
        {
            if (IsBenevol == false)
            {
                IsBenevol = true;
                ValeurClientouBene = "Benevol";
            }
            else
            {
                IsBenevol = false;
                ValeurClientouBene = "Client";
            }
        }

    }
}
