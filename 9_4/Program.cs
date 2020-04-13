using System;

namespace _9_4
{
    class Node{
        public int Key{get;set;}

        public Node Parent{get;set;}

        public Node Left{get;set;}

        public Node Right{get;set;}
    }

    class BinarySearchTree{
        private Node root;

        public BinarySearchTree(){
            this.root = null;
        }

        public void Insert(int key){
            var z = new Node();
            z.Key = key;
            z.Left = null;
            z.Right = null;

            Node x = this.root;
            Node y = null;
            while(x != null){
                y = x;
                if(z.Key < x.Key){
                    x = x.Left;
                }else{
                    x = x.Right;
                }
            }

            z.Parent = y;
            if(y == null){
                this.root = z;
            }else{
                if(z.Key < y.Key){
                    y.Left = z;
                }else{
                    y.Right = z;
                }
            }
        }

        public void Print(){
            this._InOrder(this.root);
            Console.Write("\n");
            this._PreOrder(this.root);
            Console.Write("\n");
        }

        private void _InOrder(Node u){
            if(u == null){
                return;
            }
            this._InOrder(u.Left);
            Console.Write(string.Format(" {0}",u.Key));
            this._InOrder(u.Right);
        }

        private void _PreOrder(Node u){
            if(u == null){
                return;
            }
            Console.Write(string.Format(" {0}",u.Key));
            this._PreOrder(u.Left);
            this._PreOrder(u.Right);
        }

        public Node Find(int key){
            var x = this.root;
            while(x != null && x.Key != key){
                x = x.Key > key ? x.Left : x.Right; 
            }
            return x;
        }

        private Node GetMinumum(Node x){
            while(x.Left != null){
                x = x.Left;
            }
            return x;
        }

        private Node GetSuccessor(Node x){
            if(x.Right != null){
                return this.GetMinumum(x.Right);
            }
            var y = x.Parent;
            while(y != null && x == y.Right){
                x = y;
                y = y.Parent;
            }
            return y;
        }

        public void Delete(Node z){
            var y = (z.Left == null || z.Right == null) ? z : this.GetSuccessor(z);
            var x = y.Left != null ? y.Left : y.Right;

            if(x != null){
                x.Parent = y.Parent;
            }

            if(y.Parent == null){
                this.root = x;
            }else if(y == y.Parent.Left){
                y.Parent.Left = x;
            }else{
                y.Parent.Right = x;
            }

            if(y != z){
                z.Key = y.Key;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var tree = new BinarySearchTree();
            for(var i = 0; i < n; i++){
                var q = Console.ReadLine().Split();
                if(q[0].Equals("insert")){
                    tree.Insert(int.Parse(q[1]));
                }else if(q[0].Equals("find")){
                    var x = tree.Find(int.Parse(q[1]));
                    Console.WriteLine(x != null ? "yes" : "no");
                }else if(q[0].Equals("delete")){
                    tree.Delete(tree.Find(int.Parse(q[1])));
                }else{
                    tree.Print();
                }
            }
        }
    }
}
