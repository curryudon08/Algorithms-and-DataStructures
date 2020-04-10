using System;
using System.Linq;

namespace _7_4
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var s = Console.ReadLine().Split();
            var a = new int[n + 1];
            for(var i = 0; i < n; i++){
                a[i + 1] = int.Parse(s[i]);
            }

            var b = new int[n + 1];
            CountingSort(a, b, n);

            var ans = Enumerable.Range(1,n).Select(i => b[i].ToString());
            Console.WriteLine(string.Join(" ", ans));
        }

        static int MaxVal = 10000;

        static void CountingSort(int[] a, int[] b, int n){
            var c = new int[MaxVal + 1];
            for(var i = 0; i <= MaxVal; i++){
                c[i] = 0;
            }

            for(var i = 1; i <= n; i++){
                c[a[i]]++;
            }

            for(var i = 1; i <= MaxVal; i++){
                c[i] += c[i - 1];
            }

            for(var i = n; i >= 1; i--){
                b[c[a[i]]] = a[i];
                c[a[i]]--;
            }
        }
    }
}
