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
        const int PORT_NO = 11000;
        private static List<Socket> clients = new List<Socket>();

        static void Main(string[] args)
        {
            // Help snippet
            IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, PORT_NO);

            // Creeaza socket-ul si stai si cu 1024 clienti
            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(localEndPoint);
            listener.Listen(10);

            Console.WriteLine("Server started on {0}...", localEndPoint.ToString());

            Socket clientSocket = null;
            while (true)
            {
                clientSocket = listener.Accept();
                clients.Add(clientSocket);

                (new Thread(() => HandleClient(clientSocket))).Start();
            }
        }

        static void HandleClient(Socket clientSocket)
        {
            Console.WriteLine("S-a conectat {0}", clientSocket.RemoteEndPoint.ToString());
            byte[] bytes = new byte[8192];
            
            while (true)
            {
                string msg = null;
                try
                {
                    clientSocket.Receive(bytes);
                    msg = Encoding.ASCII.GetString(bytes);
                }
                catch (Exception e)
                {
                    // Daca nu pot primi inseamna ca s-a deconectat
                    clients.Remove(clientSocket);
                    Console.WriteLine("S-a deconectat {0}", clientSocket.RemoteEndPoint.ToString());
                    return;
                }

                msg = string.Format("[{0}]: {1}", clientSocket.RemoteEndPoint.ToString(), msg);
                foreach (Socket s in clients)
                {
                    try
                    {
                        s.Send(Encoding.ASCII.GetBytes(msg));
                    }
                    catch (Exception e)
                    {
                        // Daca nu pot trimite inseamna ca s-a deconectat
                        clients.Remove(s);
                        Console.WriteLine("S-a deconectat {0}", clientSocket.RemoteEndPoint.ToString());
                    }
                }
            }
        }
    }
}