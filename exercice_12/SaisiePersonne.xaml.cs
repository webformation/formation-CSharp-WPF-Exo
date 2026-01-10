
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

namespace exercice12 {
    /// <summary>
    /// Logique d'interaction pour SaisiePersonne.xaml
    /// </summary>
    public partial class SaisiePersonne : Window
    {
        public Annuaire annuaire = new Annuaire();
        Personne p = new Personne("Inconnu", DateTime.Now.Date);
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

       try
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
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            if (annuaire.EstVide)
            {
                MessageBox.Show("Aucune personne enregistrée.", "Annuaire", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            String liste = "Liste des personnes invitées :\n";
            DateTime dateInvitation = DateTime.Now.AddMonths(1);
            foreach (Personne p in annuaire.Personnes)
            {
                if (p is IInvitable invite) { 
                if (invite.Est_disponible(dateInvitation))
                        liste += $"- {invite.Inviter(dateInvitation)}\n";
            }
            }
            MessageBox.Show(liste, "Invités", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Hobby_TextChanged(object sender, TextChangedEventArgs e)
        {
            Lien.TextChanged -= Lien_TextChanged;
            Lien.Text = "";
            Lien.TextChanged += Lien_TextChanged;
        }

        private void Lien_TextChanged(object sender, TextChangedEventArgs e)
        {
            Hobby.TextChanged -= Hobby_TextChanged;
            Hobby.Text = "";
            Hobby.TextChanged += Hobby_TextChanged;
        }
    }
}
