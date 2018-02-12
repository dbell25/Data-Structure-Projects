using System;
using Ksu.Cis300.LinkedListLibrary;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.ParenthesisMatcher
{
    public class Stack<T>
    {
        private LinkedListCell<T> _Stack1;
        private int _Count = 0;

        public int Count()
        {
            return _Count;
        }
        
        /// <summary>
        /// Adds a new link to the list
        /// </summary>
        /// <param name="x"></param>
        public void Push(T x)
        {
            LinkedListCell<T> temp = new LinkedListCell<T>();
            temp.Data = x;
            temp.Next = _Stack1;
            
            _Count++;
            _Stack1 = temp;
        }

        /// <summary>
        /// Returns the first link in the list without removing it
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            T temp = default(T);
            if (_Count > 0)
            {
               temp = _Stack1.Data;
            }
            else
            {
                throw new InvalidOperationException();
            }
            return temp;
        }
        /// <summary>
        /// Returns the first link in the list and sets the second link as the first
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            if (_Count > 0)
            {
                T temp = Peek();
                _Stack1 = _Stack1.Next;
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
