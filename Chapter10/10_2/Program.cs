using System;
using System.Linq;

namespace _10_2
{
    class Program
    {
        static int MAX = 100000;

        static void Main(string[] args)
        {
            var h = int.Parse(Console.ReadLine());
            var a = new int[MAX + 1];

            var _ = Console.ReadLine().Split();
            for(var i = 1; i <= h; i++){
                a[i] = int.Parse(_[i - 1]);
            }

            for(var i = 1; i <= h; i++){
                var s = string.Format("node {0}: key = {1}, ", i, a[i]);
                
                if(IndexOfParent(i) >= 1){
                    s += string.Format("parent key = {0}, ", a[IndexOfParent(i)]);
                }

                if(IndexOfLeft(i) <= h){
                    s += string.Format("left key = {0}, ", a[IndexOfLeft(i)]);
                }

                if(IndexOfRight(i) <= h){
                    s += string.Format("right key = {0}, ", a[IndexOfRight(i)]);
                }

                Console.WriteLine(s);
            }
        }

        static int IndexOfParent(int i){
            return i / 2;
        }

        static int IndexOfLeft(int i){
            return i * 2;
        }

        static int IndexOfRight(int i){
            return i * 2 + 1;
        }
    }
}
