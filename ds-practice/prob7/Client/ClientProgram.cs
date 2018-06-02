using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Text;
using System.Threading.Tasks;
using static Library.Catalog;

namespace Client
{
    class ClientProgram
    {
        static void Main(string[] args)
        {
            HttpClientChannel httpChannel = new HttpClientChannel();
            ChannelServices.RegisterChannel(httpChannel);
            WellKnownClientTypeEntry remoteType = new WellKnownClientTypeEntry(typeof(Library.Catalog), "http://localhost:12345/Catalog.rem");
            RemotingConfiguration.RegisterWellKnownClientType(remoteType);


            Catalog catalog = new Catalog();
            int id_materie1 = catalog.adaugaMaterie("sd");
            int id_materie2 = catalog.adaugaMaterie("asc");
            int id_materie3 = catalog.adaugaMaterie("pl");

            int id_student1 = catalog.adaugaStudent("mircea dobreanu", "1307b");
            int id_student2 = catalog.adaugaStudent("andrei covas", "1307b");
            int id_student3 = catalog.adaugaStudent("anonimus", "1310a");

            
            catalog.adaugaNota(3, id_student1, id_materie1);
            catalog.adaugaNota(2, id_student1, id_materie2);
            catalog.adaugaNota(1, id_student1, id_materie3);

            catalog.adaugaNota(10, id_student2, id_materie1);
            catalog.adaugaNota(9, id_student2, id_materie2);
            catalog.adaugaNota(8, id_student2, id_materie3);
            
            catalog.adaugaNota(5, id_student3, id_materie1);
            catalog.adaugaNota(4, id_student3, id_materie2);
            catalog.adaugaNota(3, id_student3, id_materie3);

            Console.WriteLine("grupa 1307b");
            foreach (string student in catalog.returneazaStudenti("1307b"))
                Console.WriteLine(student);

            foreach (Nota nota in catalog.returneazaNote(id_materie2))
                Console.WriteLine(nota.ToString());

            //RemotingConfiguration.Configure("Client.exe.config");
            //RemotingConfiguration.RegisterWellKnownClientType(typeof(Library.Catalog), "http://localhost:12345/Catalog.rem");
        }
    }
}
