using System;
using System.Linq;

namespace _5_3
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var s = Console.ReadLine().Split().Select(i => long.Parse(i)).ToArray();

            var q = int.Parse(Console.ReadLine());
            var t = Console.ReadLine().Split().Select(i => long.Parse(i)).ToArray();

            var count = 0;
            for(var i = 0; i < q; i++){
                if(BinarySearch(s, n, t[i]) != -1){
                    count++;
                }
            }

            Console.WriteLine(count);
        }

        static long BinarySearch(long[] a, int n, long key){
            var left = 0;
            var right = n;
            while(left < right){
                var mid = (left + right) / 2;
                if(a[mid] == key){
                    return mid;
                }else if(a[mid] > key){
                    right = mid;
                }else{
                    left = mid + 1;
                }
            }
            return -1;
        }
    }
}
