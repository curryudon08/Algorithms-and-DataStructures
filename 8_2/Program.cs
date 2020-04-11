using System;
using System.Linq;
using System.Text;

namespace _8_2
{
    struct Node{
        public int Parent{get; set;}
        public int Left{get; set;}
        public int Right{get; set;}
    }

    class Program
    {
        static int MAX = 100005;
        
        static int NIL = -1;
        
        static Node[] T = new Node[MAX];

        static int[] D = new int[MAX];

        static int[] H = new int[MAX];

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            for(var i = 0; i < n; i++){
                T[i].Parent = NIL;
                T[i].Left = NIL;
                T[i].Right = NIL;
            }

            for(var i = 0; i < n; i++){
                var s = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
                var id = s[0];
                var k = s[1];
                var l = 0;
                for(var j = 0; j < k; j++){
                    var c = s[j + 2];
                    if(j == 0){
                        T[id].Left = c;
                    }else{
                        T[l].Right = c;
                    }
                    l = c;
                    T[l].Parent = id;
                }
            }

            var r = 0;
            for(var i = 0; i < n; i++){
                if(T[i].Parent == NIL){
                    r = i;
                }
            }
            SetDepth(r, 0);

            for(var i = 0; i < n; i++){
                Print(i);
            }
        }

        static void SetDepth(int idx, int d){
            D[idx] = d;
            if(T[idx].Right != NIL){
                SetDepth(T[idx].Right, d);
            }
            if(T[idx].Left != NIL){
                SetDepth(T[idx].Left, d + 1);
            }
        }

        static void Print(int idx){
            var t1 = "";
            if(T[idx].Parent == NIL){
                t1 = "root";
            }else if(T[idx].Left == NIL){
                t1 = "leaf";
            }else{
                t1 = "internal node";
            }

            var flag = false;
            var t2 = new StringBuilder("[");
            for(var c = T[idx].Left; c != NIL; c = T[c].Right){
                if(flag){
                    t2.Append(", ");
                }
                t2.Append(c.ToString());
                flag = true;
            }
            t2.Append("]");

            var s = string.Format(
                "node {0}: parent = {1}, depth = {2}, {3}, {4}",
                idx, T[idx].Parent, D[idx], t1, t2.ToString());
            Console.WriteLine(s);
        }
    }
}
