using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Catalog : MarshalByRefObject
    {
        private List<string> materii;
        private List<Nota> note;
        private List<Student> studenti;

        public Catalog()
        {
            materii = new List<string>();
            note = new List<Nota>();
            studenti = new List<Student>();
        }


        public int adaugaMaterie(string numeMaterie)
        {
            materii.Add(numeMaterie);
            return materii.Count - 1;
        }

        public int adaugaStudent(string nume, string grupa)
        {
            Student student = new Student(nume, grupa);
            studenti.Add(student);
            return studenti.Count - 1;
        }

        public void adaugaNota(int nota, int studentId, int materieId)
        {
            Nota notaStudent = new Nota(materieId, studenti.ElementAt(studentId).Nume, nota);
            //Console.WriteLine(studenti.ElementAt(studentId));
            studenti.ForEach(i => Console.Write("{0}\t", i.ToString()));
            Console.Write('\n');

            Console.WriteLine(studentId);

            //Console.WriteLine(notaStudent);

            note.Add(notaStudent);
        }

        public Nota[] returneazaNote(int materieId)
        {
            var noteLaMaterie = note.Where(nota => nota.MaterieId == materieId).ToList();
            noteLaMaterie.ForEach(nota => Console.Write("{0}\t", nota));
            Console.Write('\n');

            return note.Where(nota => nota.MaterieId == materieId).ToArray();
        }

        public string[] returneazaStudenti(string grupa)
        {
            return studenti.Where(student => student.Grupa == grupa).Select(student => student.Nume).ToArray();
        }

        [Serializable]
        public class Nota
        {
            private int materieId;
            private string student;
            private int valoare;

            public Nota(int materieId, string student, int valoare)
            {
                MaterieId = materieId;
                Student = student;
                Valoare = valoare;
            }

            public int MaterieId
            {
                get
                {
                    return materieId;
                }

                set
                {
                    materieId = value;
                }
            }

            public string Student
            {
                get
                {
                    return student;
                }

                set
                {
                    student = value;
                }
            }

            public int Valoare
            {
                get
                {
                    return valoare;
                }

                set
                {
                    valoare = value;
                }
            }

            public override string ToString()
            {
                return string.Format("({0}, {1}, {2})", Student, MaterieId, Valoare);
            }
        }

        public class Student
        {
            private string nume;
            private string grupa;

            public Student(string nume, string grupa)
            {
                Nume = nume;
                Grupa = grupa;
            }
            

            public string Nume
            {
                get
                {
                    return nume;
                }

                set
                {
                    nume = value;
                }
            }

            public string Grupa
            {
                get
                {
                    return grupa;
                }

                set
                {
                    grupa = value;
                }
            }

            public override string ToString()
            {
                return string.Format("{0} {1}", Nume, Grupa);
            }
        }
    }
}
