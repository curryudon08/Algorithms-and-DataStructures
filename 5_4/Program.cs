using System;
using System.Linq;

namespace _5_4
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var h = new char[M][];
            for(var i = 0; i < M; i++){
                h[i] = new char[0];
            }

            for(var i = 0; i < n; i++){
                var o = Console.ReadLine().Split();
                if(o[0][0] == 'i'){
                    Insert(h, o[1].ToCharArray());
                }else{
                    var ret = Find(h, o[1].ToCharArray());
                    Console.WriteLine(ret == 1 ? "yes" : "no");
                }
            }
        }

        static long M = 1046527;

        static int Find(char[][] h, char[] str){
            var key = GetKey(str);
            for(var i = 0L; true; i++){
                var idx = (H1(key) + i * H2(key)) % M;
                if(h[idx].SequenceEqual(str)){
                    return 1;
                }else if(h[idx].Length == 0){
                    return 0;
                }
            }
        }

        static int Insert(char[][] h, char[] str){
            var key = GetKey(str);
            for(var i = 0L; true; i++){
                var idx = (H1(key) + i * H2(key)) % M;
                if(h[idx].SequenceEqual(str)){
                    return 1;
                }else if(h[idx].Length == 0){
                    h[idx] = str;
                    return 0;
                }
            }
        }

        static int GetChar(char ch){
            var ret = 0;
            if(ch == 'A'){
                ret = 1;
            }else if(ch == 'C'){
                ret = 2;
            }else if(ch == 'G'){
                ret = 3;
            }else if(ch == 'T'){
                ret = 4;
            }
            return ret;
        }

        static long GetKey(char[] str){
            var sum = 0L;
            var p = 1L;
            for(var i = 0; i < str.Length; i++){
                sum += p * GetChar(str[i]);
                p *= 5;
            }
            return sum;
        }

        static long H1(long key){
            return key % M;
        }

        static long H2(long key){
            return 1 + (key % (M - 1));
        }
    }
}
