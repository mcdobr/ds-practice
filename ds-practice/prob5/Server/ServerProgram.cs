using SharedCommons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    class ServerProgram
    {
        private const string QUEUE_PATH = @".\private$\studentsQueue";
        private static Timer timer;
        private static MessageQueue mq;

        static void Main(string[] args)
        {
            if (MessageQueue.Exists(QUEUE_PATH))
                mq = new MessageQueue(QUEUE_PATH);
            else
                mq = MessageQueue.Create(QUEUE_PATH);
            timer = new Timer(sendStudent, null, 0, 3000);

            Console.WriteLine("Press enter to quit...");
            Console.ReadLine();

            if (MessageQueue.Exists(QUEUE_PATH))
                MessageQueue.Delete(QUEUE_PATH);
        }


        private static void sendStudent(object state)
        {
            Student student = new Student();
            student.Nume = "Simpson";
            student.Prenume = "Homer";
            student.Grupa = "1307b";

            mq.Send(student);
            Console.WriteLine("Wrote to message queue: " + student.ToString());
        }
    }
}
