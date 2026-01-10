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

namespace exercice_9{
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
            LPersonne.ItemsSource = annuaire.Personnes;
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
                Personne nouveau;
                if (Hobby.Text.Length > 0) 
                    nouveau = new Ami(p.Nom, p.date_naissance,Hobby.Text);
                else if (Lien.Text.Length > 0)
                    nouveau = new Parent(p.Nom, p.date_naissance, Lien.Text);
                else
                    nouveau = new Personne(p.Nom, p.date_naissance);

                if (annuaire.ContientPersonne(nouveau))
                {
                    MessageBox.Show($"Je vous ai déjà dit bonjour {nom.Text} !");
                    return;
                }
                else
                {
                    annuaire.AjouterPersonne(nouveau);
                    Afficher.Visibility = Visibility.Visible;

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

        private void Hobby_TextChanged(object sender, TextChangedEventArgs e)
        {
            Lien.Text = "";
        }

        private void Lien_TextChanged(object sender, TextChangedEventArgs e)
        {
            Hobby.Text = "";
        }
    }
}
