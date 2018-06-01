using SharedCommons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class ClientProgram
    {
        private const string QUEUE_PATH = @".\private$\studentsQueue";
        private static MessageQueue mq;
        private static int messageNumber = 0;

        static void Main(string[] args)
        {
            if (MessageQueue.Exists(QUEUE_PATH))
                mq = new MessageQueue(QUEUE_PATH);
            else
                mq = MessageQueue.Create(QUEUE_PATH);

            mq.Formatter = new XmlMessageFormatter(new Type[] { typeof(Student) });

            Message msg = new Message();
            mq.BeginReceive(TimeSpan.FromSeconds(5), ++messageNumber, ReceiveCallback);
            
            Console.WriteLine("Press enter to quit...");
            Console.ReadLine();
        }

        private static void ReceiveCallback(IAsyncResult ar)
        {
            Message msg = mq.EndReceive(ar);
            Console.WriteLine("Received message no {0}: {1}", 
                (int)ar.AsyncState, ((Student)msg.Body).ToString());

            mq.BeginReceive(TimeSpan.FromSeconds(5), ++messageNumber, ReceiveCallback);
        }
    }
}
