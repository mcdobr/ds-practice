using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReadMultipleFilesDelegate
{
    class Program
    {
        delegate void readAndWriteDelegate(StreamReader reader, StreamWriter writer);

        static void Main(string[] args)
        {
            List<StreamReader> readers = new List<StreamReader>();
            readers.Add(new StreamReader("input1.txt"));
            readers.Add(new StreamReader("input2.txt"));
            readers.Add(new StreamReader("input3.txt"));

            StreamWriter writer = new StreamWriter("output.txt");
            List<WaitHandle> waitHandles = new List<WaitHandle>();

            foreach (var reader in readers)
            {
                readAndWriteDelegate mode = new readAndWriteDelegate(readAndWrite);
                var ar = mode.BeginInvoke(reader, writer, null, null);

                waitHandles.Add(ar.AsyncWaitHandle);
            }

            WaitHandle.WaitAll(waitHandles.ToArray());
        }

        private static void readAndWrite(StreamReader reader, StreamWriter writer)
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                lock (writer)
                {
                    writer.WriteLine(line);
                }
            }
        }
    }
}
