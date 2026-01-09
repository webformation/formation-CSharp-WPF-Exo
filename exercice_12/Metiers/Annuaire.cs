using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercice12
{
    public class Annuaire
    {
        public ObservableCollection<Personne> personnes = new ObservableCollection<Personne>();
         void AjouterPersonne(Personne p)
        {
            personnes.Add(p);
        }
        public bool ContientPersonne(Personne p)
        {
            return personnes.Contains(p);
        }
    }
}
