using System;

namespace _11_3
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = int.Parse(Console.ReadLine());

            for(var i = 0; i < x; i++){
                var m = Console.ReadLine();
                var n = Console.ReadLine();
                Console.WriteLine(Lcs(1001, m, n));
            }
        }

        static int Lcs(int size, string m, string n){
            var c = new int[size,size];
            var x =  " " + m;
            var y =  " " + n;

            var maxLen = 0;
            for(var i = 1; i <= m.Length; i++){
                for(var j = 1; j <= n.Length; j++){
                    if(x[i] == y[j]){
                        c[i, j] = c[i - 1, j - 1] + 1;
                    }else{
                        c[i, j] = Math.Max(c[i - 1, j], c[i, j - 1]);
                    }
                    maxLen = Math.Max(maxLen, c[i, j]);
                }
            }

            return maxLen;
        }
    }
}
