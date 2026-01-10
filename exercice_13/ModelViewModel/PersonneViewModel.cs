using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercice13
{
    internal class PersonneViewModel : INotifyPropertyChanged
    {
        private string _nom;
        public string Nom
        {
            get { return _nom; }
            set { _nom = value; OnPropertyChanged("Nom"); }
        }
        private DateTime _date_naissance;
        public DateTime Date_naissance
            {
            get { return _date_naissance; }
            set { _date_naissance = value; OnPropertyChanged("Date_naissance"); OnPropertyChanged("Age"); }
        }
        public int Age
        {
            get
            {
                DateTime now = DateTime.Now;
                int age = now.Year - Date_naissance.Year;
                if (now.Month < Date_naissance.Month || (now.Month == Date_naissance.Month && now.Day < Date_naissance.Day))
                {
                    age--;
                }
                return age;
            }
        }
        private string _hobby;  
        public string Hobby 
            {
            get { return _hobby; }
            set { _hobby = value; OnPropertyChanged("Hobby"); if (!string.IsNullOrEmpty(value))
                {
                    Relation = "";
                }
            }
        }
        private string _relation;
        public string Relation 
            {
            get { return _relation; }
            set { _relation = value; OnPropertyChanged("Relation"); if (!string.IsNullOrEmpty(value))
                {
                    Hobby = "";
                }
            }
        }
        public PersonneViewModel(string nom, DateTime date_naissance, string hobby, string relation)
        {
            Nom = nom;
            Date_naissance = date_naissance;
            Hobby = hobby;
            Relation = relation;
        }
        public Annuaire annuaire = new Annuaire();
        public ObservableCollection<Personne> Personnes
        {
            get { return annuaire.personnes; }
        }
        public bool PeutInviter         {
            get
            {
                return annuaire.personnes.Count > 0;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public RelayCommand AjouterCommand
        {
            get
            {
                return new RelayCommand(param =>
                {
                    try
                    {
                        Personne nouveau;
                        if (!string.IsNullOrWhiteSpace(Hobby))
                            nouveau = new Ami(Nom, Date_naissance, Hobby);
                        else if (!string.IsNullOrWhiteSpace(Relation))
                            nouveau = new Parent(Nom, Date_naissance, Relation);
                        else
                            nouveau = new Personne(Nom, Date_naissance);
                        if (annuaire.personnes.Contains(nouveau))
                        {
                            System.Windows.MessageBox.Show($"Je vous ai déjà dit bonjour {Nom} !");
                            return;
                        }
                        else
                        {
                            annuaire.AjouterPersonne(nouveau);
                            OnPropertyChanged("PeutInviter");
                        }
                    }
                    catch (ArgumentException ex)
                    {
                        System.Windows.MessageBox.Show(ex.Message, "Erreur de saisie", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                    }
                });
            }
        }
        public RelayCommand InviterCommand
        {
            get
            {
                return new RelayCommand(param =>
                {
                    if (annuaire.personnes.Count == 0)
                    {
                        System.Windows.MessageBox.Show("Aucune personne enregistrée.", "Annuaire", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
                        return;
                    }
                    DateTime dateInvitation = DateTime.Now.AddDays(7);
                    StringBuilder invitations = new StringBuilder();
                    foreach (var personne in annuaire.personnes)
                    {
                        if (personne is IInvitable invitable && invitable.Est_disponible(dateInvitation))
                        {
                            invitations.AppendLine(invitable.Inviter(dateInvitation));
                        }
                    }
                    System.Windows.MessageBox.Show(invitations.ToString(), "Invitations envoyées", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
                });
            }
        }
    }
}
