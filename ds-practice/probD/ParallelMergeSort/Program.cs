using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelMergeSort
{
    class Program
    {
        static void MergeSort(int[] v)
        {
            if (v.Length == 1)
                return;

            int[] left = v.Take(v.Length / 2).ToArray();
            int[] right = v.Skip(v.Length / 2).ToArray();

            // Ruleaza sortarea partii din dreapta pe un nou thread
            Task sortRight = new Task(() => MergeSort(right));
            sortRight.Start();

            // trebuie ca ambele sa se fi terminat
            MergeSort(left);
            sortRight.Wait();

            int idx = 0, l = 0, r = 0;
            while (l < left.Length && r < right.Length)
            {
                if (left[l] <= right[r])
                    v[idx++] = left[l++];
                else
                    v[idx++] = right[r++];
            }
            while (l < left.Length)
                v[idx++] = left[l++];
            while (r < right.Length)
                v[idx++] = right[r++];

        }

        static void Main(string[] args)
        {
            int[] v = new int[1024];
            for (int i = 0; i < v.Length; ++i)
                v[i] = v.Length - i;


            //Console.WriteLine("[{0}]", string.Join(", ", v));
            MergeSort(v);
            Console.WriteLine("[{0}]", string.Join(", ", v));
        }
    }
}
