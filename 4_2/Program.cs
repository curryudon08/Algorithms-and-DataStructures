using System;
using System.Linq;

namespace _4_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = Console.ReadLine().Split();

            var stack = new Stack<int>(100);
            foreach(var x in s){
                var o = 0;
                if(int.TryParse(x, out o)){
                    stack.Push(o);
                }else{
                    var b = stack.Pop();
                    var a = stack.Pop();
                    if(x.Equals("+")){
                        stack.Push(a + b);
                    }else if(x.Equals("-")){
                        stack.Push(a - b);
                    }else if(x.Equals("*")){
                        stack.Push(a * b);
                    }
                }
            }

            var ans = stack.Pop();
            Console.WriteLine(ans);
        }
    }

    class Stack<T>{
        private int top;
        private readonly int max;
        private readonly T[] array;

        public Stack(int max){
            this.top = -1;
            this.max = max;
            this.array = new T[this.max];
        }

        public bool IsEmpty(){
            return this.top == -1;
        }

        public bool IsFull(){
            return this.top >= this.max - 1; 
        }

        public void Push(T x){
            if(this.IsFull()){
                throw new ArgumentOutOfRangeException();
            }
            this.top++;
            this.array[this.top] = x;
        }

        public T Pop(){
            if(this.IsEmpty()){
                throw new ArgumentOutOfRangeException();
            }
            top--;
            return this.array[top+1];
        }
    }
}
