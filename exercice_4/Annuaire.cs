using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercice_4
{
    public class Annuaire
    {
        public List<Personne> personnes = new List<Personne>();
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
