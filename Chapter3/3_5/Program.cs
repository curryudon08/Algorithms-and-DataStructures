using System;
using System.Linq;
using System.Collections.Generic;

namespace _3_5
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var a1 = Console.ReadLine().Split().Select(i => Tuple.Create(i[0], int.Parse(i[1].ToString()))).ToArray();

            var a2 = new Tuple<char, int>[n];
            for(var i = 0; i < n; i++){
                a2[i] = Tuple.Create(a1[i].Item1, a1[i].Item2);
            }

            var count1 = BubbleSort(a1, n);
            var count2 = SelectionSort(a2, n);

            Console.WriteLine(string.Join(" ",a1.Select(t => t.Item1.ToString() + t.Item2.ToString())));
            Console.WriteLine("Stable");

            Console.WriteLine(string.Join(" ",a2.Select(t => t.Item1.ToString() + t.Item2.ToString())));
            Console.WriteLine(Check(a1, a2, n) ? "Stable" : "Not stable");
        }

        static bool Check(Tuple<char, int>[] a1, Tuple<char, int>[] a2, int n){
            for(var i = 0; i < n; i++){
                if(a1[i].Item1 != a2[i].Item1){
                    return false;
                }
            }
            return true;
        }

        static int BubbleSort(Tuple<char, int>[] a, int n){
            var count = 0;
            var flag = true;
            while(flag){
                flag = false;
                for(var i = n - 1; i > 0; i--){
                    if(a[i].Item2 < a[i-1].Item2){
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

        static int SelectionSort(Tuple<char, int>[] a, int n){
            var count = 0;
            for(var i = 0; i < n - 1; i++){
                var idx = i;
                for(var j = i; j < n; j++){
                    if(a[j].Item2 < a[idx].Item2){
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
