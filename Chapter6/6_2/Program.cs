using System;
using System.Linq;

namespace _6_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var a = Console.ReadLine().Split().Select(i => int.Parse(i)).ToArray();
            var q = int.Parse(Console.ReadLine());
            var m = Console.ReadLine().Split().Select(i => int.Parse(i)).ToArray();

            for(var i = 0; i < q; i++){
                var res = Solve(a, 0, n, m[i]);
                Console.WriteLine(res ? "yes" : "no");
            }
        }

        static bool Solve(int[] a, int i, int n, int m){
            if(m == 0){
                return true;
            }else if(i >= n){
                return false;
            }
            var res = Solve(a, i + 1, n, m) || Solve(a, i + 1, n, m - a[i]);
            return res;
        }
    }
}
