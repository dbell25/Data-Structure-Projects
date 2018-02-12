/* NameInformation.cs
 * Author: Daniel Bell
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KansasStateUniversity.TreeViewer2;

namespace Ksu.Cis300.BTrees
{
    public class BTreeNode<TKey, TValue> : ITree
        where TKey : IComparable<TKey>
    {
        /// <summary>
        /// Keeps track of the number of children in this node.
        /// </summary>
        private int _childCount;

        /// <summary>
        /// Indicates if this node is a leaf or not.
        /// </summary>
        private bool _isLeaf;

        /// <summary>
        ///  Keeps track of how many keys are currently in this node.
        /// </summary>
        private int _keyCount = 0;

        /// <summary>
        /// An array that holds the keys of this node in ascending order.
        /// </summary>
        private TKey[] _keys;

        /// <summary>
        /// Stores the minimum number of keys this node can have.
        /// </summary>
        private int _minKeyCount;

        /// <summary>
        /// Stores the values of the corresponding keys from the _keys array.
        /// </summary>
        private TValue[] _values;

        /// <summary>
        /// An array that stores the pointers to the children of this node.
        /// </summary>
        private BTreeNode<TKey, TValue>[] _children;

        /// <summary>
        /// Returns the value of the private field _children.
        /// </summary>
        public ITree[] Children
        {
            get
            {
                return _children;
            }
        }

        /// <summary>
        /// A property that returns if the number of keys in this node is 0.
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                if (KeyCount == 0) return true;
                return false;
            }
        }

        /// <summary>
        /// A property that returns _isLeaf
        /// </summary>
        public bool IsLeaf
        {
            get
            {
                return _isLeaf;
            }
        }

        /// <summary>
        /// A public property allowing access to the private field _keyCount.
        /// </summary>
        public int KeyCount
        {
            get
            {
                return _keyCount;
            }
        }

        /// <summary>
        /// A property that returns this.
        /// </summary>
        public object Root
        {
            get
            {
                return this;
            }
        }

        /// <summary>
        /// A helper function that stores the child node in the _children array at index i and increments the number of children.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="child"></param>
        public void AddChild(int i, BTreeNode<TKey, TValue> child)
        {
            _children[i] = child;
            _childCount++;
        }

        /// <summary>
        /// Takes in a key of generic type TKey and a value of generic type TValue and adds them to _keys.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void AddItem(TKey key, TValue value)
        {
            for (int i = _keyCount - 1; i >= 0; i--)
            {
                int compare = _keys[i].CompareTo(key);
                if (compare > 0)
                {
                    _keys[i + 1] = _keys[i];
                    _values[i + 1] = _values[i];
                }
                else
                {
                    _keys[i + 1] = key;
                    _values[i + 1] = value;
                    _keyCount++;
                    return;
                }
            }
            _keys[0] = key;
            _values[0] = value;
            _keyCount++;
        }

        /// <summary>
        /// This is the constructor for the BtreeNode class.
        /// </summary>
        /// <param name="minKeyCount"></param>
        /// <param name="maxKeyCount"></param>
        /// <param name="maxChildCount"></param>
        /// <param name="leaf"></param>
        public BTreeNode(int minKeyCount, int maxKeyCount, int maxChildCount, bool leaf)
        {
            _minKeyCount = minKeyCount;
            _isLeaf = leaf;
            _keys = new TKey[maxKeyCount];
            _children = new BTreeNode<TKey, TValue>[maxChildCount];
            _values = new TValue[maxKeyCount];
        }

        /// <summary>
        /// This method implements a modified recursive binary search.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public TValue Find(TKey key)
        {
            int i = Array.IndexOf(_keys, key);
            if (i != -1) return _values[i];
            else
            {
                if (_isLeaf) return default(TValue);
                else
                {
                    int k;
                    for (k = 0; k < _keyCount; k++)
                    {
                        if (_keys[k].CompareTo(key) > 0) break;
                    }
                    return _children[k].Find(key);
                }
            }
        }

        /// <summary>
        /// This method inserts into a tree whose root node is not full.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void InsertNonFull(TKey key, TValue value)
        {
            if (IsLeaf) AddItem(key, value);
            else
            {
                int i = KeyCount - 1;
                while (i >= 0 && _keys[i].CompareTo(key) > 0)
                {
                    i--;
                }
                i++;

                if (_children[i].KeyCount == _keys.Length)
                {
                    SplitChild(i);
                    if (_keys[i].CompareTo(key) < 0) i++;
                }
                _children[i].InsertNonFull(key, value);
            }
        }

        /// <summary>
        /// Once a node in the B-tree is full, this method splits part of it into a new node
        /// </summary>
        /// <param name="index"></param>
        public void SplitChild(int index)
        {
            BTreeNode<TKey, TValue> newNode = new BTreeNode<TKey, TValue>(_minKeyCount, _keys.Length, _children.Length, _children[index].IsLeaf);
            BTreeNode<TKey, TValue> splitNode = _children[index];
            for (int i = 0, k = _minKeyCount + i + 1; i < _minKeyCount; i++, k++)
            {
                newNode.AddItem(splitNode._keys[k], splitNode._values[k]);
                splitNode._keys[k] = default(TKey);
                splitNode._values[k] = default(TValue);
            }   
            if (!newNode.IsLeaf)
            {
                for (int j = _children.Length / 2, l = 0; j < _children.Length; j++, l++)
                {
                    if (splitNode.Children[j] != null)
                    {
                        newNode.AddChild(l, splitNode._children[j]);
                        splitNode._children[j] = null;
                        splitNode._childCount--;
                    } 
                }
            }   
            splitNode._keyCount = _minKeyCount;
            for (int x = _keyCount; x >= index + 1; x--)
            {
                _children[x + 1] = _children[x];
            }   
            _children[index + 1] = newNode;
            _childCount++;
            AddItem(splitNode._keys[_minKeyCount], splitNode._values[_minKeyCount]);
            splitNode._keys[_minKeyCount] = default(TKey);
            splitNode._values[_minKeyCount] = default(TValue);
        }   

        /// <summary>
        /// Display the nodes in a user-friendly manner. 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < KeyCount; i++)
            {
                if (_keys[i] != null && !_keys[i].Equals(default(TKey)))
                {
                    if (i == KeyCount - 1) sb.Append(Convert.ToString(_keys[i]));
                    else sb.Append(Convert.ToString(_keys[i]) + " | ");
                }
            }
            return sb.ToString();
        }
    }
}