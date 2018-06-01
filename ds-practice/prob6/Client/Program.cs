using Client.localhost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            FacultateWebService fws = new FacultateWebService();

            string command = null;
            while (true)
            {
                command = Console.ReadLine();
                switch (command.ToLower())
                {
                    case "exit":
                        {
                            Environment.Exit(0);
                            break;
                        }
                    case "adaugamaterie":
                        {
                            Console.WriteLine("Introdu numele materiei: ");
                            string materie = Console.ReadLine();
                            Console.WriteLine("S-a adaugat materia cu id-ul {0}", fws.adaugaMaterie(materie));
                            break;
                        }
                    case "adaugastudent":
                        {
                            Console.WriteLine("Introdu numele studentului: ");
                            string student = Console.ReadLine();
                            Console.WriteLine("Introdu grupa studentului: ");
                            string grupa = Console.ReadLine();

                            Console.WriteLine("S-a adaugat materia cu id-ul {0}", fws.adaugaStudent(student, grupa));
                            break;
                        }

                    case "adauganota":
                        {
                            Console.WriteLine("Introdu nota: ");
                            int nota = int.Parse(Console.ReadLine());
                            Console.WriteLine("Introdu idul studentului: ");
                            int studentId = int.Parse(Console.ReadLine());
                            Console.WriteLine("Introdu idul materiei: ");
                            int materieId = int.Parse(Console.ReadLine());

                            fws.adaugaNota(nota, studentId, materieId);
                            Console.WriteLine("S-a adaugat nota");

                            break;
                        }
                    case "returneazanote":
                        {
                            Console.WriteLine("Introdu materiaId: ");
                            int materiaId = int.Parse(Console.ReadLine());

                            foreach (var kvp in fws.returneazaNote(materiaId))
                                Console.WriteLine("{0} are nota {1}", kvp.key, kvp.value);
                        break;
                        }
                    case "returneazastudenti":
                        {
                            Console.WriteLine("Introdu grupa: ");
                            string grupa = Console.ReadLine();

                            foreach (string nume in fws.returneazaStudenti(grupa))
                                Console.WriteLine(nume);

                            break;
                        }
                }
            }
        }
    }
}
