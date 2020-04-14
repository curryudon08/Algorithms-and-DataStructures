using System;
using System.Linq;
using System.Collections.Generic;

namespace _3_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var a = Console.ReadLine().Split().Select(i => int.Parse(i)).ToArray();

            Console.WriteLine(string.Join(" ",a.Select(t => t.ToString())));
            InsertionSort(a,n);
        }

        static void InsertionSort(int[] a, int n){
            for(var i = 1; i < n; i++){
                var v = a[i];
                var j = i - 1;
                while(j >= 0 && a[j] > v){
                    a[j + 1] = a[j];
                    j--;                
                }
                a[j + 1] = v;
                Console.WriteLine(string.Join(" ",a.Select(t => t.ToString())));
            }
        }
    }
}
