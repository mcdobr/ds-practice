using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace echoClient
{
    public partial class ClientForm : Form
    {
        const int PORT_NO = 11000;
        private Socket socket;

        public ClientForm()
        {
            InitializeComponent();
        }
        
        private void ClientForm_Load(object sender, EventArgs e)
        {
            IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint ipe = new IPEndPoint(ipAddress, PORT_NO);

            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(ipe);

            (new Thread(() => GetMessages())).Start();

        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            string msg = messageBox.Text;
            messageBox.Clear();

            socket.Send(Encoding.ASCII.GetBytes(msg));
        }

        private void GetMessages()
        {
            byte[] bytes = new byte[8192];
            while (true)
            {
                socket.Receive(bytes);
                string msg = Encoding.ASCII.GetString(bytes) + Environment.NewLine;

                chatBox.AppendText(msg);
            }
        }

        private void ClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            socket.Close();
        }
    }
}
