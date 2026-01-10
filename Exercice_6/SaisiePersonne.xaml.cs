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

namespace exercice_6
{
    /// <summary>
    /// Logique d'interaction pour SaisiePersonne.xaml
    /// </summary>
    public partial class SaisiePersonne : Window
    {
        public Annuaire annuaire = new Annuaire();
        Personne p = new Personne(String.Empty, DateTime.Now.Date);
        public SaisiePersonne()
        {
            InitializeComponent();
            Afficher.Visibility = Visibility.Hidden;
            this.DataContext = p;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(nom.Text) || nom.Text.Length < 2)
            {
                MessageBox.Show("Nom invalide");
                return;
            }

            else
            {
                Personne nouveau = new Personne(p.Nom, p.date_naissance);
                if (annuaire.ContientPersonne(nouveau))
                {
                    MessageBox.Show($"Je vous ai déjà dit bonjour {nom.Text} !");
                    return;
                }
                else
                {
                    annuaire.AjouterPersonne(nouveau);
                    Afficher.Visibility = Visibility.Visible;

                    MessageBox.Show($"Bonjour {nouveau.Nom}\nVous êtes né le {nouveau.date_naissance.ToShortDateString()}",
                        "Informations Personne", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }


        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            if (annuaire.EstVide)
            {
                MessageBox.Show("Aucune personne enregistrée.", "Annuaire", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            String liste = "Liste des personnes enregistrées :\n";
            foreach (Personne p in annuaire.Personnes)
            {
                liste += $"- {p.ToString()}\n";
            }
            MessageBox.Show(liste, "Annuaire", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
