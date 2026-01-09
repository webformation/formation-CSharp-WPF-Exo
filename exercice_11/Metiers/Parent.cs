using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercice11
{
    internal class Parent : Personne
    {
        public string Relation { get; set; }
        public Parent(string nom, DateTime date_naissance, string relation) : base(nom, date_naissance)
        {
            Relation = relation;
        }
        public override string ToString()
        {
            return $"{base.ToString()}, Relation: {Relation}";
        }
    }
}
