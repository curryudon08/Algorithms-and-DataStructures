using System;
using System.Linq;

namespace _7_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var s = Console.ReadLine().Split().Select(i => long.Parse(i)).ToArray();

            var count = MergeSort(s, n, 0, n);
            Console.WriteLine(string.Join(" ", s.Select(i => i.ToString())));
            Console.WriteLine(count);
        }

        static long MergeSort(long[] a, int n, int left, int right){
            if(left + 1 < right){
                var mid = (left + right) / 2;
                var count = MergeSort(a, n, left, mid);
                count += MergeSort(a, n, mid, right);
                count += Merge(a, n, left, mid, right);
                return count;
            }
            return 0;
        }

        static long Max = 500000;
        static long[] l = new long[Max / 2 + 2];
        static long[] r = new long[Max / 2 + 2];

        static long Merge(long[] a, int n, int left, int mid, int right){
            for(var i = 0; i < mid - left; i++){
                l[i] = a[left + i];
            }
            l[mid - left] = long.MaxValue;

            for(var i = 0; i < right - mid; i++){
                r[i] = a[mid + i];
            }
            r[right - mid] = long.MaxValue;

            var count = 0;
            var idxl = 0;
            var idxr = 0;
            for(var i = left; i < right; i++){
                count++;
                if(l[idxl] <= r[idxr]){
                    a[i] = l[idxl];
                    idxl++;
                }else{
                    a[i] = r[idxr];
                    idxr++;
                }
            }

            return count;
        }
    }
}
