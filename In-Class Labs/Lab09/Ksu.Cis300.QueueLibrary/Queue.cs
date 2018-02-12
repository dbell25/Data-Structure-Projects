using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.QueueLibrary
{
    public class Queue<T>
    {
        private T[] _Q1 = new T[5];
        private int _NumElements = 0, _index = 0;

        /// <summary>
        /// returns the count of elements in the queue
        /// </summary>
        public int Count
        {
            get
            {
                return _NumElements;
            }
        }

        /// <summary>
        /// adds elements to the queue
        /// </summary>
        /// <param name="x"></param>
        public void Enqueue(T x)
        {
            if(_Q1.Length ==_NumElements)
            {
                T[] Q2 = new T[_NumElements * 2];
                Array.Copy(_Q1, _index, Q2, 0, _NumElements - _index);
                Array.Copy(_Q1, 0, Q2, _NumElements , _index);
                _Q1 = Q2;
            }

            int back = _index + Count;
            
                if(_index >= _Q1.Length)
                {
                back = back - _Q1.Length;
                }
            _Q1[back] = x;
            _NumElements++;

        }

        /// <summary>
        /// returns the last element without removing it
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            if (_NumElements == 0) throw new InvalidOperationException();
            return _Q1[_index];
        }

        /// <summary>
        /// removes elements from the queue
        /// </summary>
        /// <returns></returns>
        public T Dequeue()
        {
            if(_Q1.Length == 0)
            {
                throw new InvalidOperationException();
            }
            else
            {
                T temp = _Q1[_index];
                _index--;
                _Q1[_index] = default(T);
                return temp;
            }
        }
    }
}
