using System;
using System.Linq;

namespace _8_4
{
    struct Node{
        public int Parent{get; set;}
        public int Left{get; set;}
        public int Right{get; set;}
    }

    class Program
    {
        static int MAX = 10000;
        
        static int NIL = -1;
        
        static Node[] T = new Node[MAX];

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            for(var i = 0; i < n; i++){
                T[i].Parent = NIL;
            }

            for(var i = 0; i < n; i++){
                var _ = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
                var p = _[0];
                var l = _[1];
                var r = _[2];
                T[p].Left = l;
                T[p].Right = r;
                if(l != NIL){
                    T[l].Parent = p;
                }
                if(r != NIL){
                    T[r].Parent = p;
                }
            }

            var root = 0;
            for(var i = 0; i < n; i++){
                if(T[i].Parent == NIL){
                    root = i;
                }
            }

            Console.WriteLine("Preorder");
            PreParse(root);
            Console.Write("\n");

            Console.WriteLine("Inorder");
            InParse(root);
            Console.Write("\n");

            Console.WriteLine("Postorder");
            PostParse(root);
            Console.Write("\n");
        }

        static void PreParse(int u){
            if(u == NIL){
                return;
            }
            Console.Write(string.Format(" {0}",u));
            PreParse(T[u].Left);
            PreParse(T[u].Right);
        }

        static void InParse(int u){
            if(u == NIL){
                return;
            }
            InParse(T[u].Left);
            Console.Write(string.Format(" {0}",u));
            InParse(T[u].Right);
        }

        static void PostParse(int u){
            if(u == NIL){
                return;
            }
            PostParse(T[u].Left);
            PostParse(T[u].Right);
            Console.Write(string.Format(" {0}",u));
        }
    }
}
