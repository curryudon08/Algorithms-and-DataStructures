using System;
using System.Linq;
using System.Text;

namespace _7_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var a = Console.ReadLine().Split().Select(i => int.Parse(i)).ToArray();

            var idx = Partition(a, 0, n - 1);


            var s = Enumerable.Range(0,n).Select(i => i == idx ? "[" + a[i].ToString() + "]" : a[i].ToString());
            Console.WriteLine(string.Join(" ",s));
        }

        static int Partition(int[] a, int p, int r){
            var x = a[r];
            var i = p - 1;
            for(var j = p; j < r; j++){
                if(a[j] <= x){
                    i++;
                    Swap(a, i, j);
                }
            }
            Swap(a, i + 1, r);
            return i + 1;
        }

        static void Swap(int[] a, int i, int j){
            var t = a[i];
            a[i] = a[j];
            a[j] = t;
        }
    }
}
