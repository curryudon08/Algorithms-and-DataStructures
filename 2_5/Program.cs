using System;
using System.Linq;

namespace _2_5
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = long.Parse(Console.ReadLine());

            var maxVal = long.MinValue;
            var minVal = long.Parse(Console.ReadLine());
            for(var i = 1; i < n; i++){
                var r = long.Parse(Console.ReadLine());
                maxVal = Math.Max(maxVal, r - minVal);
                minVal = Math.Min(minVal, r);
            }

            Console.WriteLine(maxVal);
        }
    }
}
