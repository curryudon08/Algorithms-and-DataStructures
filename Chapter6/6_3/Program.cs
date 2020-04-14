using System;

namespace _6_3
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var p1 = Tuple.Create(0.0, 0.0);
            var p2 = Tuple.Create(100.0, 0.0);

            Console.WriteLine(string.Format("{0:f8} {1:f8}",p1.Item1, p1.Item2));
            Koch(n, p1, p2);
            Console.WriteLine(string.Format("{0:f8} {1:f8}",p2.Item1, p2.Item2));
        }

        static double TH  =Math.PI * 60 / 180;

        static void Koch(int n, Tuple<double,double> p1, Tuple<double,double> p2){
            if(n == 0){
                return;
            }

            var x1 = (2.0 * p1.Item1 + 1.0 * p2.Item1) / 3.0;
            var y1 = (2.0 * p1.Item2 + 1.0 * p2.Item2) / 3.0;
            var s = Tuple.Create(x1, y1);
            var x2 = (1.0 * p1.Item1 + 2.0 * p2.Item1) / 3.0;
            var y2 = (1.0 * p1.Item2 + 2.0 * p2.Item2) / 3.0;
            var t = Tuple.Create(x2, y2);
            var x3 = (t.Item1 - s.Item1) * Math.Cos(TH) - (t.Item2 - s.Item2) * Math.Sin(TH) + s.Item1;
            var y3 = (t.Item1 - s.Item1) * Math.Sin(TH) + (t.Item2 - s.Item2) * Math.Cos(TH) + s.Item2;
            var u = Tuple.Create(x3, y3);

            Koch(n - 1, p1, s);
            Console.WriteLine(string.Format("{0:f8} {1:f8}",s.Item1, s.Item2));

            Koch(n - 1, s, u);
            Console.WriteLine(string.Format("{0:f8} {1:f8}",u.Item1, u.Item2));

            Koch(n - 1, u, t);
            Console.WriteLine(string.Format("{0:f8} {1:f8}",t.Item1, t.Item2));

            Koch(n - 1, t, p2);
        }
    }
}
