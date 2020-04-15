using System;

namespace _11_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            
            var dp = new int[50];
            dp[0] = 1;
            dp[1] = 1;

            for(var i = 2; i <=n; i++){
                dp[i] = dp[i - 1] + dp[i - 2];
            }

            Console.WriteLine(dp[n]);
        }
    }
}
