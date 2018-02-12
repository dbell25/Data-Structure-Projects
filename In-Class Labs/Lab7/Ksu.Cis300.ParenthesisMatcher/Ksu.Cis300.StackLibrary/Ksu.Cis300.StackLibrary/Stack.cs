using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.StackLibrary
{
    /// <summary>
    /// Elements to be stored in the stack
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Stack<T>
    {
        private T[] arr = new T[5];
        private int count = 0;

        public int Count
        {
            get
            {
                return count;
            }
        }

        public void Push(T x)
        {
            if (count == arr.Length)
            {
                T[] temp = new T[count * 2];
                arr.CopyTo(temp, 0);
                arr = temp;
            }
            arr[count] = x;
            count++;

        }

        public T Peek()
        {
            if(count == 0)
            {
                throw new InvalidOperationException();
            }
            return arr[count - 1];
        }

        public T Pop()
        { 
            T temp = Peek();
            count--;
            arr[count] = default(T);
            return temp;
        }
    }
}
