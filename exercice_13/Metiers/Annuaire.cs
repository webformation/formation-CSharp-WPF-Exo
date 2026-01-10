using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercice13
{
    public class Annuaire
    {
        private ObservableCollection<Personne> personnes = new ObservableCollection<Personne>();
        public ObservableCollection<Personne> Personnes
        {
            get
            {
                return personnes;
            }
        }
        public void AjouterPersonne(Personne p)
        {
            personnes.Add(p);
        }
        public bool ContientPersonne(Personne p)
        {
            return personnes.Contains(p);
        }
        public bool EstVide
        {
            get
            {
                return personnes.Count == 0;
            }
        }
    }
}
