using System;
using System.Linq;
using System.Collections.Generic;

namespace _3_3
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var a = Console.ReadLine().Split().Select(i => int.Parse(i)).ToArray();

            var count = BubbleSort(a,n);
            Console.WriteLine(string.Join(" ",a.Select(t => t.ToString())));
            Console.WriteLine(count);
        }

        static int BubbleSort(int[] a, int n){
            var count = 0;
            var flag = true;
            while(flag){
                flag = false;
                for(var i = n - 1; i > 0; i--){
                    if(a[i] < a[i-1]){
                        var t = a[i];
                        a[i] = a[i-1];
                        a[i-1] = t;

                        flag = true;
                        count++;
                    }
                }
            }
            return count;
        }
    }
}
