using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public class Catalog : MarshalByRefObject
    {
        List<string> materii = new List<string>();
        List<Student> studenti = new List<Student>();
        List<Nota> note = new List<Nota>();


        public int adaugaMaterie(string numeMaterie)
        {
            materii.Add(numeMaterie);
            return materii.Count - 1;
        }

        public int adaugaStudent(string nume, string grupa)
        {
            Student s = new Student(nume, grupa);
            studenti.Add(s);
            return studenti.Count - 1;
        }

        public void adaugaNota(int valoareNota, int studentId, int materieId)
        {
            Student s = studenti.ElementAt(studentId);
            Nota n = new Nota(valoareNota, s.Nume, materieId);
            note.Add(n);
        }

        public Nota[] returneazaNote(int materieId)
        {
            return note.Where(nota => nota.MaterieId == materieId).ToArray();
        }

        public string[] returneazaStudenti(string grupa)
        {
            return studenti.Where(student => student.Grupa == grupa).Select(student => student.Nume).ToArray();
        }

        private class Student
        {
            private string nume;
            private string grupa;

            public Student(string nume, string grupa)
            {
                this.nume = nume;
                this.grupa = grupa;
            }

            public string Grupa
            {
                get { return grupa;}
                set {grupa = value;}
            }

            public string Nume
            {
                get{ return nume; }
                set{ nume = value;}
            }
        }

        [Serializable]
        public class Nota
        {
            private int valoare;
            private string numeStudent;
            private int materieId;

            public Nota(int valoare, string numeStudent, int materieId)
            {
                this.valoare = valoare;
                this.numeStudent = numeStudent;
                this.materieId = materieId;
            }

            public int Valoare
            {
                get { return valoare;}
                set {valoare = value;}
            }

            public string NumeStudent
            {
                get {return numeStudent;}
                set {numeStudent = value; }
            }

            public int MaterieId
            {
                get { return materieId;}
                set {materieId = value;}
            }

            public override string ToString()
            {
                return string.Format("{0} a luat nota {1}", numeStudent, valoare);
            }
        }
    }
}
