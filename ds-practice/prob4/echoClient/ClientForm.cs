using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace echoClient
{
    public partial class ClientForm : Form
    {
        const int BUFFER_SIZE = 8192;
        private Socket socket;
        private byte[] buffer = new byte[BUFFER_SIZE];

        public ClientForm()
        {
            InitializeComponent();
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);

            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(localEndPoint);


            socket.BeginReceive(buffer, 0, BUFFER_SIZE, 0, new AsyncCallback(ReceiveCallback), buffer);
        }

        private void ReceiveCallback(IAsyncResult ar)
        {
            socket.EndReceive(ar);

            string msg = Encoding.ASCII.GetString(buffer);
            chatBox.AppendText(msg);

            socket.BeginReceive(buffer, 0, BUFFER_SIZE, 0, new AsyncCallback(ReceiveCallback), buffer);
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            string msg = messageBox.Text;
            messageBox.Clear();

            socket.Send(Encoding.ASCII.GetBytes(msg));
        }

        private void ClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            socket.Shutdown(SocketShutdown.Both);
            socket.Disconnect(false);
            socket.Close();
        }
    }
}
