using System;

namespace _10_4
{
    class PriorityQueue{
        private readonly int MAX = 2000000;

        private int idx = 0;

        private int[] heap;

        public PriorityQueue(){
            this.heap = new int[MAX + 1];
        }

        public void Insert(int key){
            this.idx++;
            this.heap[idx] = int.MinValue;
            this.IncreaseKey(this.idx, key);
        }

        private void IncreaseKey(int i, int key){
            if(key < this.heap[i]){
                return;
            }
            this.heap[i] = key;
            while(i > 1 && this.heap[i / 2] < this.heap[i]){
                this.Swap(i, i / 2);
                i /= 2;
            }
        }

        private void Swap( int i, int j){
            var t = this.heap[i];
            this.heap[i] = this.heap[j];
            this.heap[j] = t;
        }

        public int Extract(){
            if(this.idx < 1){
                return int.MinValue;
            }
            var maxVal = this.heap[1];
            this.heap[1] = this.heap[this.idx--];
            this.MaxHeapify(1);
            return maxVal;
        }

        private int IndexOfParent(int i){
            return i / 2;
        }

        private int IndexOfLeft(int i){
            return i * 2;
        }

        private int IndexOfRight(int i){
            return i * 2 + 1;
        }

        private void MaxHeapify(int i){
            var l = IndexOfLeft(i);
            var largest = (l <= this.idx && this.heap[l] > this.heap[i] ? l : i);

            var r = IndexOfRight(i);
            largest = (r <= this.idx && this.heap[r] > this.heap[largest] ? r : largest);

            if(largest != i){
                this.Swap(i, largest);
                this.MaxHeapify(largest);
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            var queue = new PriorityQueue();

            while(true){
                var s = Console.ReadLine().Split();
                if(s[0].Equals("end")){
                    break;
                }else if(s[0].Equals("insert")){
                    queue.Insert(int.Parse(s[1]));
                }else if(s[0].Equals("extract")){
                    var x = queue.Extract();
                    Console.WriteLine(x);
                }
            }
        }
    }
}
