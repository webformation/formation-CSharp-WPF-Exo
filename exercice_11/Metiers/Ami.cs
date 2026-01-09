
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercice11
{
    internal class Ami : Personne, IInvitable
    {
        public string Hobby { get; set; }
        public Ami(string nom, DateTime date_naissance, string hobby) : base(nom, date_naissance)
        {
            Hobby = hobby;
        }
        public override string ToString()
        {
            return $"{base.ToString()}, Hobby: {Hobby}";
        }

        public bool Est_disponible(DateTime date)
        {
            int age = date.Year - date_naissance.Year;
            if (date.DayOfYear < date_naissance.DayOfYear)
                age--;
            return age >= 18;
        }

        public string Inviter(DateTime date)
        {
           return  $"Invitation envoyée à {Nom} pour le {date.ToShortDateString()}.";
        }
    }
}
