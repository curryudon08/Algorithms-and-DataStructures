using System;
using System.Linq;

namespace _8_3
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

        static int[] D = new int[MAX];

        static int[] H = new int[MAX];

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
            SetDepth(root, 0);
            SetHeight(root);

            for(var i = 0; i < n; i++){
                Print(i);
            }
        }

        static void SetDepth(int idx, int d){
            if(idx == NIL){
                return;
            }
            D[idx] = d;
            SetDepth(T[idx].Left, d + 1);
            SetDepth(T[idx].Right, d + 1);
        }

        static int SetHeight(int idx){
            var h1 = T[idx].Left != NIL ? SetHeight(T[idx].Left) + 1 : 0;
            var h2 = T[idx].Right != NIL ? SetHeight(T[idx].Right) + 1 : 0;
            H[idx] = Math.Max(h1, h2);
            return H[idx];
        }

        static void Print(int idx){
            var deg = T[idx].Left != NIL ? 1 : 0;
            deg += T[idx].Right != NIL ? 1 : 0;

            var t = "";
            if(T[idx].Parent == NIL){
                t = "root";
            }else if(T[idx].Left == NIL && T[idx].Right == NIL){
                t = "leaf";
            }else{
                t = "internal node";
            }

            var s = string.Format(
                "node {0}: parent = {1}, sibling = {2}, degree = {3}, depth = {4}, height = {5}, {6}",
                idx, T[idx].Parent, GetSibling(idx), deg, D[idx], H[idx], t);
            Console.WriteLine(s);
        }

        static int GetSibling(int idx){
            if(T[idx].Parent == NIL){
                return NIL;
            }
            if(T[T[idx].Parent].Left != idx && T[T[idx].Parent].Left != NIL){
                return T[T[idx].Parent].Left;
            }
            if(T[T[idx].Parent].Right != idx && T[T[idx].Parent].Right != NIL){
                return T[T[idx].Parent].Right;
            }
            return NIL;
        }
    }
}
