using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpChannel channel = new HttpChannel();
            ChannelServices.RegisterChannel(channel);
            RemotingConfiguration.RegisterActivatedClientType(
                typeof(Utils.Catalog),
                "http://localhost:12345/");

            Catalog catalog = new Catalog();
            int materie1 = catalog.adaugaMaterie("sd");
            int materie2 = catalog.adaugaMaterie("asc");
            int materie3 = catalog.adaugaMaterie("pl");

            int stud1 = catalog.adaugaStudent("dobreanu mircea", "1307b");
            int stud2 = catalog.adaugaStudent("vladimir lenin", "1307b");
            int stud3 = catalog.adaugaStudent("anna pauker", "1307a");

            // Note pt stud 1
            catalog.adaugaNota(1, stud1, materie1);
            catalog.adaugaNota(2, stud1, materie2);
            catalog.adaugaNota(3, stud1, materie3);

            // Note pt stud 2
            catalog.adaugaNota(4, stud2, materie1);
            catalog.adaugaNota(5, stud2, materie2);
            catalog.adaugaNota(6, stud2, materie3);

            // Note pt stud 3
            catalog.adaugaNota(7, stud3, materie1);
            catalog.adaugaNota(8, stud3, materie2);
            catalog.adaugaNota(9, stud3, materie3);

            Console.WriteLine("Notele la ASC");
            foreach (var nota in catalog.returneazaNote(2))
                Console.WriteLine(nota.ToString());

            Console.WriteLine("grupa 1307b");
            foreach (var numeStudent in catalog.returneazaStudenti("1307b"))
                Console.WriteLine(numeStudent);
        }
    }
}
