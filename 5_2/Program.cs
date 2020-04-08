using System;

namespace _5_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());            
            var s = Console.ReadLine().Split();
            var s_ary = new long[n + 1];
            for(var i = 0; i < n; i++){
                s_ary[i] = long.Parse(s[i]);

            }

            var q = int.Parse(Console.ReadLine());            
            var t = Console.ReadLine().Split();
            var t_ary = new long[q];
            for(var i = 0; i < q; i++){
                t_ary[i] = long.Parse(t[i]);
            }

            var count = 0;
            for(var i = 0; i < q; i++){
                if(LinerSearch(s_ary, n, t_ary[i]) != -1){
                    count++;
                }
            }

            Console.WriteLine(count);
        }

        static long LinerSearch(long[] a, int n, long key){
            var i = 0;
            a[n] = key;
            while(a[i] != key){
                i++;
            }
            return i == n ? -1 : i;
        }
    }
}
