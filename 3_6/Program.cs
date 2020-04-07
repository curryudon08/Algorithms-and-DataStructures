using System;
using System.Linq;
using System.Collections.Generic;

namespace _3_6
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var a = new int[n];
            for(var i = 0; i < n; i++){
                a[i] = int.Parse(Console.ReadLine());
            }

            var count = ShellSort(a, n);
            Console.WriteLine(count);

            foreach(var i in a){
                Console.WriteLine(i);
            }

        }

        static int InsertionSort(int[] a, int n, int g){
            var count = 0;
            for(var i = g; i < n; i++){
                var v = a[i];
                var j = i - g;
                while(j >= 0 && a[j] > v){
                    a[j + g] = a[j];
                    j -= g;
                    count++;
                }
                a[j + g] = v;
            }
            return count;
        }

        static int ShellSort(int[] a, int n){
            var g = new List<int>();
            var h = 1;
            while(h <= n){
                g.Add(h);
                h = 3 * h + 1;
            }
            g.Reverse();
            var m = g.Count();

            Console.WriteLine(m);
            Console.WriteLine(string.Join(" ", g.Select(i => i.ToString())));

            var count = 0;
            for(var i = 0; i < m; i++){
                count += InsertionSort(a, n, g[i]);
            }
            return count;
        }
    }
}
