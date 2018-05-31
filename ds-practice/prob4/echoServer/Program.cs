using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace echoServer
{
    class Program
    {
        class ReadState
        {
            public const int BUFFER_SIZE = 8192;

            public Socket socket;
            public byte[] buffer = new byte[BUFFER_SIZE];
        }

        private static List<Socket> clients = new List<Socket>();

        static void Main(string[] args)
        {
            IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);
            
            // Creeaza socket-ul de server
            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(localEndPoint);
            listener.Listen(10);

            Console.WriteLine("Started server on {0}...", localEndPoint.ToString());
            while (true)
            {
                Socket client = listener.Accept();
                clients.Add(client);
                Console.WriteLine("S-a conectat {0}...", client.RemoteEndPoint.ToString());


                ReadState rs = new ReadState();
                rs.socket = client;

                try
                {
                    client.BeginReceive(rs.buffer, 0, ReadState.BUFFER_SIZE, 0,
                                new AsyncCallback(ReceiveCallback), rs);
                }
                catch (Exception e)
                {
                    clients.Remove(client);
                    Console.WriteLine("S-a deconectat {0}...", client.RemoteEndPoint.ToString());
                }
            }
            
        }

        private static void ReceiveCallback(IAsyncResult ar)
        {
            ReadState rs = ar.AsyncState as ReadState;
            Socket client = rs.socket;
            byte[] buffer = rs.buffer;

            // Termina de primit mesajul si transmite la clientii mesajul primit
            try
            {
                client.EndReceive(ar);
            }
            catch (Exception e)
            {
                clients.Remove(client);
                Console.WriteLine("S-a deconectat {0}...", client.RemoteEndPoint.ToString());
            }


            foreach (Socket s in clients)
            {
                try
                {
                    string msg = string.Format("[{0}]: {1}", client.RemoteEndPoint.ToString(), Encoding.ASCII.GetString(buffer));
                    s.Send(Encoding.ASCII.GetBytes(msg));
                }
                catch (Exception e)
                {
                    clients.Remove(s);
                    Console.WriteLine("S-a deconectat {0}...", s.RemoteEndPoint.ToString());
                }
            }


            // Initializeaza din nou un Receive
            ReadState newRs = new ReadState();
            newRs.socket = client;

            try
            {
                client.BeginReceive(newRs.buffer, 0, ReadState.BUFFER_SIZE, 0,
                            new AsyncCallback(ReceiveCallback), newRs);
            }
            catch (Exception e)
            {
                clients.Remove(client);
                Console.WriteLine("S-a deconectat {0}...", client.RemoteEndPoint.ToString());
            }
        }
    }
}
