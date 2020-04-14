using System;

namespace _10_3
{
    class Program
    {
        static int MAX = 2000000;

        static int IndexOfParent(int i){
            return i / 2;
        }

        static int IndexOfLeft(int i){
            return i * 2;
        }

        static int IndexOfRight(int i){
            return i * 2 + 1;
        }

        static void MaxHeapify(int[] a, int h, int i){
            var l = IndexOfLeft(i);
            var largest = (l <= h && a[l] > a[i] ? l : i);

            var r = IndexOfRight(i);
            largest = (r <= h && a[r] > a[largest] ? r : largest);

            if(largest != i){
                Swap(a, i, largest);                
                MaxHeapify(a, h, largest);
            }
        }

        static void Swap(int[] a, int i, int j){
            var t = a[i];
            a[i] = a[j];
            a[j] = t;
        }

        static void Main(string[] args)
        {
            var h = int.Parse(Console.ReadLine());
            var a = new int[MAX + 1];

            var _ = Console.ReadLine().Split();
            for(var i = 1; i <= h; i++){
                a[i] = int.Parse(_[i - 1]);
            }

            for(var i = h / 2; i >= 1; i--){
                MaxHeapify(a, h, i);
            }

            for(var i = 1; i <= h; i++){
                Console.Write(string.Format(" {0}", a[i]));
            }
            Console.Write("\n");
        }
    }
}
