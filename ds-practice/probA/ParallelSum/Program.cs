using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelSum
{
    class Program
    {
        static StreamWriter sw = new StreamWriter("output.txt");

        static void Main(string[] args)
        {
            int n = 1024;
            int[] v = new int[n];
            for (int i = 0; i < v.Length; ++i)
                v[i] = i + 1;

            for (int phase = 1; v.Length > 1; ++phase)
                v = sumStep(v, phase);

            sw.Flush();
            sw.Close();
        }

        static int[] sumStep(int[] v, int phase)
        {
            sw.WriteLine("Etapa {0}", phase);

            int[] a = new int[v.Length / 2];

            List<Thread> threads = new List<Thread>();
            for (int i = 0; i < a.Length; ++i)
            {
                int copyI = i;
                Thread thr = new Thread(() => microSum(out a[copyI], v, copyI * 2, copyI * 2 + 1));
                threads.Add(thr);
            }

            foreach (Thread thr in threads)
                thr.Start();

            foreach (Thread thr in threads)
                thr.Join();

            return a;
        }

        static void microSum(out int result, int[] v, int idx1, int idx2)
        {
            lock (sw)
            {
                sw.WriteLine("{0} + {1} = {2}", v[idx1], v[idx2], v[idx1] + v[idx2]);
                result = v[idx1] + v[idx2];
            }
        }
    }
}
