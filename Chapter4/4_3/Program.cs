using System;
using System.Linq;

namespace _4_3
{
    class Program
    {
        static void Main(string[] args)
        {
            var _ = Console.ReadLine().Split();
            var n = int.Parse(_[0]);
            var q = int.Parse(_[1]);

            var queue = new Queue<Tuple<string, int>>(n);
            for(var i = 0; i < n; i++){
                var t = Console.ReadLine().Split();
                var name = t[0];
                var time = int.Parse(t[1]);

                queue.Enqueue(Tuple.Create(name, time));
            }

            var count = 0;
            while(!queue.IsEmpty()){
                var t = queue.Dequeue();
                if(t.Item2 - q > 0){
                    count += q;
                    queue.Enqueue(Tuple.Create(t.Item1, t.Item2 - q));
                }else{
                    count += t.Item2;
                    Console.WriteLine(string.Format("{0} {1}",t.Item1, count));
                }
            }
        }
    }

    class Queue<T>{
        private int head;
        private int tail;
        private readonly int max;
        private readonly T[] array;
        public Queue(int max){
            this.head = 0;
            this.tail = 0;
            this.max = max + 1;
            this.array = new T[this.max];
        }

        public bool IsEmpty(){
            return this.head == this.tail;
        }

        public bool IsFull(){
            return head == (tail + 1) % this.max;
        }

        public void Enqueue(T x){
            if(this.IsFull()){
                throw new ArgumentOutOfRangeException();
            }
            this.array[this.tail] = x;
            this.tail = (this.tail + 1) % this.max;
        }

        public T Dequeue(){
            if(this.IsEmpty()){
                throw new ArgumentOutOfRangeException();
            }
            var x = this.array[this.head];
            this.head = (this.head + 1) % this.max;
            return x;
        }
    }
}
