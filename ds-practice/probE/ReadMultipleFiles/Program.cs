using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReadMultipleFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            List<StreamReader> readers = new List<StreamReader>();
            readers.Add(new StreamReader("input1.txt"));
            readers.Add(new StreamReader("input2.txt"));
            readers.Add(new StreamReader("input3.txt"));

            List<Thread> threads = new List<Thread>();
            StreamWriter writer = new StreamWriter("output.txt");

            foreach (var reader in readers)
                threads.Add(new Thread(() => readWholeFileAndOutput(reader, writer)));

            foreach (var thread in threads)
                thread.Start();

            foreach (var thread in threads)
                thread.Join();
        }

        // Daca vrea linii intercalate gen: linie_fisier1, linie_fisier3, linie_fisier1, linie_fisier2. Daca vrea fisier intreg, fisier intreg, lock-ul deasupra while
        private static void readWholeFileAndOutput(StreamReader reader, StreamWriter writer)
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
