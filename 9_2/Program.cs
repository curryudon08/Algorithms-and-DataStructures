using System;

namespace _9_2
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

        public void InOrder(){
            this._InOrder(this.root);
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

        public void PreOrder(){
            this._PreOrder(this.root);
            Console.Write("\n");
        }

        private void _PreOrder(Node u){
            if(u == null){
                return;
            }
            Console.Write(string.Format(" {0}",u.Key));
            this._PreOrder(u.Left);
            this._PreOrder(u.Right);
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
                }else{
                    tree.InOrder();
                    tree.PreOrder();
                }
            }
        }
    }
}
