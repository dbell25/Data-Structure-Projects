/* UserInterface.cs
 * Author: Daniel Bell
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ksu.Cis300.LinkedListLibrary;

namespace Ksu.Cis300.Nim
{
    public class Dictionary<TKey, TValue>
    {
        /// <summary>
        /// Initializes a new hash table.
        /// </summary>
        private LinkedListCell<KeyValuePair<TKey, TValue>>[] _hashtable = new LinkedListCell<KeyValuePair<TKey, TValue>>[3209];

        /// <summary>
        /// This method determines whether the given key is null.
        /// </summary>
        /// <param name="k"></param>
        private void CheckKey(TKey k)
        {
            if (k == null) throw new ArgumentNullException();
        }

        /// <summary>
        /// This method computes and returns the table location at which the given key belongs.
        /// </summary>
        /// <param name="k"></param>
        /// <returns></returns>
        private int GetLocation(TKey k)
        {
            int temp = k.GetHashCode();
            temp = temp & 0x7fffffff;
            return temp % _hashtable.Length;
        }

        /// <summary>
        /// Finds and returns the cell with the given key in the given linked list.
        /// </summary>
        /// <param name="k"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        private LinkedListCell<KeyValuePair<TKey, TValue>> GetCell(TKey k, LinkedListCell<KeyValuePair<TKey, TValue>> list)
        {
            while(list != null)
            {
                if (list.Data.Key.Equals(k)) return list;
                list = list.Next;
            }
            return null;
        }

        /// <summary>
        /// Inserts the given cell into the beginning of the linked list at the given location of the table.
        /// </summary>
        /// <param name="cell"></param>
        /// <param name="loc"></param>
        private void Insert(LinkedListCell<KeyValuePair<TKey, TValue>> cell, int loc)
        {
            cell.Next = _hashtable[loc];
            _hashtable[loc] = cell;
        }

        /// <summary>
        /// Inserts the given cell into the beginning of the linked list at the given location of the table.
        /// </summary>
        /// <param name="k"></param>
        /// <param name="v"></param>
        /// <param name="loc"></param>
        private void Insert(TKey k, TValue v, int loc)
        {
            LinkedListCell<KeyValuePair<TKey, TValue>> temp = new LinkedListCell<KeyValuePair<TKey, TValue>>();
            temp.Data = new KeyValuePair<TKey, TValue>(k, v);
            Insert(temp, loc);
        }

        /// <summary>
        /// Implements the same functionality as the TryGetValue method.
        /// </summary>
        /// <param name="k"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        public bool TryGetValue(TKey k, out TValue v)
        {
            CheckKey(k);
            int loc = GetLocation(k);
            LinkedListCell<KeyValuePair<TKey, TValue>> temp = GetCell(k, _hashtable[loc]);
            if (temp == null)
            {
                v = default(TValue);
                return false;
            }
            v = temp.Data.Value;
            return true;
        }

        /// <summary>
        /// Implements the same functionality as the Add method.
        /// </summary>
        /// <param name="k"></param>
        /// <param name="v"></param>
        public void Add(TKey k, TValue v)
        {
            CheckKey(k);
            int loc = GetLocation(k);
            LinkedListCell<KeyValuePair<TKey, TValue>> temp = GetCell(k, _hashtable[loc]);
            if (temp == null) Insert(k, v, loc);
            else throw new ArgumentException();
        }
    }
}
