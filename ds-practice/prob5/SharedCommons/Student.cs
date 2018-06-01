using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedCommons
{
    public class Student
    {
        private string nume;
        private string prenume;
        private string grupa;

        public string Nume {get; set;}
        public string Prenume { get; set; }
        public string Grupa { get; set; }


        public override string ToString()
        {
            return string.Format("({0} {1}, {2})", Nume, Prenume, Grupa);
        }
    }
}
