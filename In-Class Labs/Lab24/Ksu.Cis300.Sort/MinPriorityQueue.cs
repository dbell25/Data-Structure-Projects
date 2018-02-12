using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KansasStateUniversity.TreeViewer2;

namespace Ksu.Cis300.Sort
{
    public class MinPriorityQueue<TPriority, TValue> where TPriority : IComparable<TPriority>
    {
        /// <summary>
        /// A leftist heap storing the elements and their priorities.
        /// </summary>
        private LeftistTree<KeyValuePair<TPriority, TValue>> _elements = null;

        /// <summary>
        /// The number of elements in the queue.
        /// </summary>
        private int _count = 0;

        /// <summary>
        /// Gets the number of elements.
        /// </summary>
        public int Count
        {
            get
            {
                return _count;
            }
        }

        /// <summary>
        /// Adds the given element with the given priority.
        /// </summary>
        /// <param name="p">The priority of the element.</param>
        /// <param name="x">The element to add.</param>
        public void Add(TPriority p, TValue x)
        {
            LeftistTree<KeyValuePair<TPriority, TValue>> node =
                new LeftistTree<KeyValuePair<TPriority, TValue>>(new KeyValuePair<TPriority, TValue>(p, x), null, null);
            _elements = Merge(_elements, node);
            _count++;
        }

        /// <summary>
        /// Gets a drawing of the min-heap.
        /// </summary>
        public TreeForm HeapDrawing
        {
            get
            {
                return new TreeForm(_elements, 100);
            }
        }

        /// <summary>
        /// Returns the minimum priority of the leftist tree.
        /// </summary>
        public TPriority MinimumPriority
        {
            get
            {
                if (_count == 0) throw new InvalidOperationException();
                return _elements.Data.Key;
            }
        }

        /// <summary>
        /// Merges the leftist tree.
        /// </summary>
        /// <param name="h1"></param>
        /// <param name="h2"></param>
        /// <returns></returns>
        private static LeftistTree<KeyValuePair<TPriority, TValue>> Merge(LeftistTree<KeyValuePair<TPriority, TValue>> h1,
            LeftistTree<KeyValuePair<TPriority, TValue>> h2)
        {
            if (h1 == null) return h2;
            else if (h2 == null) return h1;
            else
            {
                LeftistTree<KeyValuePair<TPriority, TValue>> smaller = h1;
                LeftistTree<KeyValuePair<TPriority, TValue>> larger = h2;
                int temp = smaller.Data.Key.CompareTo(larger.Data.Key);
                if(temp > 0)
                {
                    smaller = h2;
                    larger = h1;
                }
                return new LeftistTree<KeyValuePair<TPriority, TValue>>(smaller.Data, smaller.LeftChild, Merge(smaller.RightChild, larger));
            }
        }

        /// <summary>
        /// Removes the element with minimum priority.
        /// </summary>
        /// <returns></returns>
        public TValue RemoveMinimumPriority()
        {
            if (_elements == null) throw new InvalidOperationException();
            else
            {
                TValue temp = _elements.Data.Value;
                _elements = Merge(_elements.LeftChild, _elements.RightChild);
                _count--;
                return temp;
            }
        }
    }
}
