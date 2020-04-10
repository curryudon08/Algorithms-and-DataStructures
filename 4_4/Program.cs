using System;

namespace _4_4
{
    class Node{
        public long Key{get; set;}
        public Node Next{get; set;}
        public Node Prev{get; set;}

    }

    class DoublyLinkedList{
        private Node nil;

        public DoublyLinkedList(){
            this.nil = new Node();
            this.nil.Prev = this.nil;
            this.nil.Next = this.nil;
        }

        public void Print(){
            var cur = this.nil.Next;
            var isf = false;
            while(true){
                if(cur == this.nil){
                    break;
                }
                if(isf){
                    Console.Write(" ");
                }else{
                    isf = true;
                }
                Console.Write(cur.Key.ToString());
                cur = cur.Next;
            }    
            Console.Write("\n");
        }

        private Node Search(long key){
            var cur = this.nil.Next;
            while(cur != this.nil && cur.Key != key){
                cur = cur.Next;
            }
            return cur;
        }

        public void Insert(long key){
            var node = new Node();
            node.Key = key;
            node.Next = this.nil.Next;
            this.nil.Next.Prev = node;
            this.nil.Next = node;
            node.Prev = nil;
        }

        private void Delete(Node t){
            if(t == this.nil){
                return;
            }
            t.Prev.Next = t.Next;
            t.Next.Prev = t.Prev;
        }

        public void DeleteFirst(){
            this.Delete(this.nil.Next);
        }

        public void DeleteLast(){
            this.Delete(this.nil.Prev);
        }

        public void DeleteKey(long key){
            this.Delete(this.Search(key));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var l = new DoublyLinkedList();
            for(var i = 0; i < n; i++){
                var cmd = Console.ReadLine().Split();
                if(cmd[0].Equals("insert")){
                    l.Insert(long.Parse(cmd[1]));
                }else if(cmd[0].Equals("delete")){
                    l.DeleteKey(long.Parse(cmd[1]));
                }else if(cmd[0].Equals("deleteFirst")){
                    l.DeleteFirst();
                }else if(cmd[0].Equals("deleteLast")){
                    l.DeleteLast();
                }
            }
            l.Print();
        }
    }
}
