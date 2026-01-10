
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

namespace exercice13 {
    /// <summary>
    /// Logique d'interaction pour SaisiePersonne.xaml
    /// </summary>
    public partial class SaisiePersonne : Window
    {

        PersonneViewModel p = new PersonneViewModel(String.Empty, DateTime.Now.Date,String.Empty,String.Empty);
        public SaisiePersonne()
        {
            InitializeComponent();
            this.DataContext = p;
        }
    }
}
