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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace exercice_4
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] Noms = new string[10];
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Valider_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nom.Text) || nom.Text.Length < 2)
            {
                MessageBox.Show("Nom invalide");
                return;
            }
            else
            {
                if (Noms.Contains(nom.Text))
                {
                    MessageBox.Show($"Je vous ai déjà dit bonjour {nom.Text} !");
                    return;
                }
                else
                {
                    for (int i = 0; i < Noms.Length; i++)
                    {
                        if (Noms[i] == null)
                        {
                            Noms[i] = nom.Text;
                            break;
                        }
                    }
                    message.Content = "Bonjour " + nom.Text + " !";
                }
            }
        }

        private void nom_TextChanged(object sender, TextChangedEventArgs e)
        {
            message.Content = "";
        }
    }
}
