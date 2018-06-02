using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class ServerProgram
    {
        static void Main(string[] args)
        {
            HttpServerChannel httpChannel = new HttpServerChannel(12345);
            ChannelServices.RegisterChannel(httpChannel);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(Library.Catalog), "Catalog.rem", WellKnownObjectMode.Singleton);

            
            Console.WriteLine("Server started. Press enter to end...");
            Console.ReadLine();
        }
    }
}
