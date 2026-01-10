using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercice_6
{
    public class Annuaire
    {
        private List<Personne> personnes = new List<Personne>();
        public List<Personne> Personnes
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
