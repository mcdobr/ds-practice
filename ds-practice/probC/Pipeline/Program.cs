using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pipeline
{
    class Program
    {
        static void Main(string[] args)
        {
            int alpha = 3;
            int[] v = new int[1 << 10];

            for (int i = 0; i < v.Length; ++i)
                v[i] = v.Length - i;

            Task multiplyByAlpha = new Task(() => v = v.Select(x => x = x * alpha).ToArray());
            Task sortArray = new Task(() => Array.Sort(v));
            Task printAsCoordinates = new Task(() => printArrayAsPairsOfCoords(v));
            
            multiplyByAlpha.Start();
            multiplyByAlpha.Wait();

            sortArray.Start();
            sortArray.Wait();

            printAsCoordinates.Start();
            printAsCoordinates.Wait();

        }

        static void printArrayAsPairsOfCoords(int[] v)
        {
            for (int i = 0; i < v.Length; i += 2)
                Console.WriteLine("({0}, {1})", v[i], v[i + 1]);
        }
    }
}
