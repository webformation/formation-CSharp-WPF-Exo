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

namespace exercice_8
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
            LPersonne.DataContext = annuaire;
            LPersonne.ItemsSource = annuaire.personnes;
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
                //p.Nom = nom.Text;
                //p.date_naissance = dateNaissance.SelectedDate.HasValue ? dateNaissance.SelectedDate.Value : DateTime.Now.Date;
                Personne nouveau = new Personne(p.Nom, p.date_naissance);
                if (annuaire.personnes.Contains(nouveau))
                {
                    MessageBox.Show($"Je vous ai déjà dit bonjour {nom.Text} !");
                    return;
                }
                else
                {
                    annuaire.personnes.Add(nouveau);
                    Afficher.Visibility = Visibility.Visible;

                }
            }


        }

        private void Button_Click1(object sender, RoutedEventArgs e)
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
