using System;

namespace _7_3
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            
            var a = new Tuple<string, int>[n];
            var b = new Tuple<string, int>[n];
            for(var i = 0; i < n; i++){
                var _ = Console.ReadLine().Split();
                a[i] = Tuple.Create(_[0], int.Parse(_[1]));
                b[i] = Tuple.Create(_[0], int.Parse(_[1]));
            }

            MergeSort(a, n, 0, n);
            QuickSort(b, n, 0, n - 1);

            var flag = true;
            for(var i = 0; i < n; i++){
                if(a[i].Item1 == b[i].Item1 && a[i].Item2 == b[i].Item2){
                    continue;
                }else{
                    flag = false;
                    break;
                }
            }

            Console.WriteLine(flag ? "Stable" : "Not stable");
            for(var i = 0; i < n; i++){
                Console.WriteLine(string.Format("{0} {1}", b[i].Item1, b[i].Item2));
            }
        }

        static void QuickSort(Tuple<string, int>[] a, int n, int p, int r){
            if(p < r){
                var q = Partition(a, p ,r);
                QuickSort(a, n, p, q - 1);
                QuickSort(a, n, q  + 1, r);
            }
        }

        static int Partition(Tuple<string, int>[] a, int p, int r){
            var x = a[r];
            var i = p - 1;
            for(var j = p; j < r; j++){
                if(a[j].Item2 <= x.Item2){
                    i++;
                    Swap(a, i, j);
                }
            }
            Swap(a, i + 1, r);
            return i + 1;
        }

        static void Swap(Tuple<string, int>[] a, int i, int j){
            var t = a[i];
            a[i] = a[j];
            a[j] = t;
        }

        static void MergeSort(Tuple<string, int>[] a, int n, int left, int right){
            if(left + 1 < right){
                var mid = (left + right) / 2;
                MergeSort(a, n, left, mid);
                MergeSort(a, n, mid, right);
                Merge(a, n, left, mid, right);
            }
        }

        static long Max = 500000;
        static Tuple<string, int>[] l = new Tuple<string, int>[Max / 2 + 2];
        static Tuple<string, int>[] r = new Tuple<string, int>[Max / 2 + 2];

        static void Merge(Tuple<string, int>[] a, int n, int left, int mid, int right){
            for(var i = 0; i < mid - left; i++){
                l[i] = a[left + i];
            }
            l[mid - left] = Tuple.Create("", int.MaxValue);

            for(var i = 0; i < right - mid; i++){
                r[i] = a[mid + i];
            }
            r[right - mid] = Tuple.Create("", int.MaxValue);

            var idxl = 0;
            var idxr = 0;
            for(var i = left; i < right; i++){
                if(l[idxl].Item2 <= r[idxr].Item2){
                    a[i] = l[idxl];
                    idxl++;
                }else{
                    a[i] = r[idxr];
                    idxr++;
                }
            }
        }
    }
}
