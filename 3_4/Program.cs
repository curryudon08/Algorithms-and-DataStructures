using System;
using System.Linq;
using System.Collections.Generic;

namespace _3_4
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var a = Console.ReadLine().Split().Select(i => int.Parse(i)).ToArray();

            var count = SelectionSort(a,n);
            Console.WriteLine(string.Join(" ",a.Select(t => t.ToString())));
            Console.WriteLine(count);
        }

        static int SelectionSort(int[] a, int n){
            var count = 0;
            for(var i = 0; i < n - 1; i++){
                var idx = i;
                for(var j = i; j < n; j++){
                    if(a[j] < a[idx]){
                        idx = j;
                    }
                }
                if(i != idx){
                    var t = a[i];
                    a[i] = a[idx];
                    a[idx] = t;
                    count++;
                }
            }
            return count;
        }
    }
}
