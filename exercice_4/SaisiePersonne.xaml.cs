using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace exercice_4
{
    /// <summary>
    /// Logique d'interaction pour SaisiePersonne.xaml
    /// </summary>
    public partial class SaisiePersonne : Window
    {
        public Annuaire annuaire = new Annuaire();
        //public List<Personne> personnes = new List<Personne>();
        public SaisiePersonne()
        {
            InitializeComponent();
            Afficher.Visibility = Visibility.Hidden;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Contructeur par défaut, initialisation des propriétés
            //Personne p = new Personne
            //{
            //    Nom = nom.Text,
            //    date_naissance = dateNaissance.SelectedDate.HasValue ? dateNaissance.SelectedDate.Value : DateTime.Now
            //};

            if (string.IsNullOrWhiteSpace(nom.Text) || nom.Text.Length < 2)
            {
                MessageBox.Show("Nom invalide");
                return;
            }
           
            else
            {
                Personne p = new Personne(nom.Text, dateNaissance.SelectedDate.HasValue ? dateNaissance.SelectedDate.Value : DateTime.Now.Date);
                //if (personnes.Contains(p))
                //{
                //    MessageBox.Show($"Je vous ai déjà dit bonjour {nom.Text} !");
                //    return;
                //}
                if (annuaire.personnes.Contains(p))
                {
                    MessageBox.Show($"Je vous ai déjà dit bonjour {nom.Text} !");
                    return;
                }
                else
                {
                    annuaire.personnes.Add(p);
                    Afficher.Visibility = Visibility.Visible;   
                    //personnes.Add(p);
                    MessageBox.Show($"Bonjour {p.Nom}\nVous êtes né le {p.date_naissance.ToShortDateString()}",
                        "Informations Personne", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
           
        
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (annuaire.personnes.Count == 0)
            {
                MessageBox.Show("Aucune personne enregistrée.", "Annuaire", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            String liste = "Liste des personnes enregistrées :\n";
            foreach (Personne p in annuaire.personnes)
            {
                liste += $"- {p.ToString()}\n";
            }  
            MessageBox.Show(liste, "Annuaire", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
