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
    class Program
    {
        static void Main(string[] args)
        {
            HttpChannel httpChannel = new HttpChannel(12345);
            ChannelServices.RegisterChannel(httpChannel);
            RemotingConfiguration.RegisterActivatedServiceType(typeof(Utils.Catalog));

            Console.WriteLine("Server started. Press Enter to quit...");
            Console.ReadLine();
        }
    }
}
