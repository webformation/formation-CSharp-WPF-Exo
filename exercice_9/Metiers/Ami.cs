using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercice_9
{
    internal class Ami : Personne
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
    }
}
