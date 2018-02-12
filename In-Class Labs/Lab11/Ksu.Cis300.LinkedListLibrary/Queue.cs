using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.LinkedListLibrary
{
    public class Queue<T>
    {
        private LinkedListCell<T> _front;
        private LinkedListCell<T> _back;
        private int _Count = 0;

        public int Count()
        {
            return _Count;
        }

        /// <summary>
        /// Adds a new link to the list at the back
        /// </summary>
        /// <param name="x"></param>
        public void Enqueue(T x)
        {
            LinkedListCell<T> temp = new LinkedListCell<T>();
            if (_Count == 0)
            {
                _front = temp;
                _back = temp;
            }
            else
            {
                _back.Next = temp;
                _back = temp;
            }
            _back.Data = x;
            _Count++;
        }

        /// <summary>
        /// Returns the front of the queue without removing it
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            T temp = default(T);
            if (_Count > 0)
            {
                temp = _front.Data;
            }
            else
            {
                throw new InvalidOperationException();
            }
            return temp;
        }

        /// <summary>
        /// Returns the value at the front of the queue
        /// </summary>
        /// <returns></returns>
        public T Dequeue()
        {
            if (_Count > 0)
            {
                T temp = Peek();
                _front = _front.Next;
                _Count--;
                return temp;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}
