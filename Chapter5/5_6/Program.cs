using System;
using System.Linq;

namespace _5_6
{
    class Program
    {
        static void Main(string[] args)
        {
            var _ = Console.ReadLine().Split();
            var n = int.Parse(_[0]);
            var k = int.Parse(_[1]);
            var w = new int[n];
            for(var i = 0; i < n; i++){
                w[i] = int.Parse(Console.ReadLine());
            }

            var left = 0L;
            var right = 100000L * 10000L;
            while(right - left > 1){
                var mid = (left + right) / 2;
                var v = Check(w, n, k, mid);
                if(v >= n){
                    right = mid;
                }else{
                    left = mid;
                }
            }

            Console.WriteLine(right);
        }

        static int Check(int[] w, int n, int k, long p){
            var idx = 0;
            for(var i = 0; i < k; i++){
                var s = 0L;
                while(s + w[idx] <= p){
                    s += w[idx];
                    idx++;
                    if(idx == n){
                        return idx;
                    }
                }
            }
            return idx;
        }
    }
}
