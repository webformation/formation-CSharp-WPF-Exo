using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml.Linq;

namespace exercice_5
{
    public class Personne
    {
        public string Nom { get; set; }
        public DateTime date_naissance { get; set; }
        public int Age 
        { 
            get 
            {
                int age = DateTime.Now.Year - date_naissance.Year;
                if (DateTime.Now.DayOfYear < date_naissance.DayOfYear)
                    age--;
                return age;
            }
        }
        public Personne(string nom, DateTime date_naissance)
        {
            Nom = nom;
            this.date_naissance = date_naissance;
        }
        public override string ToString()
        {
            return $"{Nom}, né(e) le {date_naissance.ToShortDateString()} (Âge: {Age} ans)";
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Personne p = (Personne)obj;
            return Nom == p.Nom && date_naissance == p.date_naissance;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + (Nom?.GetHashCode() ?? 0);
                hash = hash * 23 + date_naissance.GetHashCode();
                return hash;
            }
        }
    }
}
