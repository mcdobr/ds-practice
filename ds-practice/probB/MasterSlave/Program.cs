using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterSlave
{
    class Program
    {
        const int NO_DIVISIONS = 4;

        static void Main(string[] args)
        {
            int[] v = new int[1 << 20]; // 4 ^ 10
            for (int i = 0; i < v.Length; ++i)  // nr de la 0 la 4^10 - 1
                v[i] = i;

            List<Task<long>> tasks = new List<Task<long>>();
            for (int i = 0; i < NO_DIVISIONS; ++i)
            {
                int idx = i;
                tasks.Add(new Task<long>(() => sumSubArray(v, idx * v.Length / NO_DIVISIONS, (idx + 1) * v.Length / NO_DIVISIONS)));
            }

            foreach (var task in tasks)
                task.Start();

            foreach (var task in tasks)
                task.Wait();

            long result = 0;
            foreach (var task in tasks)
                result += task.Result;

            Console.WriteLine("Suma numerelor este {0}", result);
        }

        private static long sumSubArray(int[] v, int start, int end)
        {
            long sum = 0;
            for (int i = start; i < end; ++i)
                sum += v[i];
            return sum;
        }
    }
}
