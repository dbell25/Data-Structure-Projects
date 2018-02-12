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
    public class BTree<TKey, TValue> : ITree
        where TKey : IComparable<TKey>
    {
        /// <summary>
        /// The maximum number of children for the nodes in the tree.
        /// </summary>
        private int _maxChildren;

        /// <summary>
        /// The maximum number of keys for each node in the tree
        /// </summary>
        private int _maxKeys;

        /// <summary>
        /// The minimum number of keys for each node in the tree.
        /// </summary>
        private int _minKeys;

        /// <summary>
        /// The minimum degree of the tree.
        /// </summary>
        private int _size;

        /// <summary>
        /// The root node of the tree.
        /// </summary>
        private BTreeNode<TKey, TValue> _root;

        /// <summary>
        /// A public property that returns the children of the root node.
        /// </summary>
        public ITree[] Children
        {
            get
            {
                return _root.Children;
            }
        }

        /// <summary>
        /// A public property that returns wether or not the root is null.
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                return (_root == null);
            }
        }

        /// <summary>
        /// A public property that gets the root of the node.
        /// </summary>
        public object Root
        {
            get
            {
                return _root;
            }
        }

        /// <summary>
        /// Public constructor that initializes all of the corresponding fields as described above.
        /// </summary>
        /// <param name="size"></param>
        public BTree(int size)
        {
            _size = size;
            _minKeys = _size -1;
            _maxKeys = _size * 2 -1;
            _maxChildren = _size * 2;
            _root = new BTreeNode<TKey, TValue>(_minKeys, _maxKeys, _maxChildren, true);
        }

        /// <summary>
        /// A helper function that calls Find on the root node.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public TValue Find(TKey key)
        {
            return _root.Find(key);
        }

        /// <summary>
        /// A method that inserts a node into the B-tree starting at the root node.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Insert(TKey key, TValue value)
        {
            if (_root.IsEmpty) _root.AddItem(key, value);
            else
            {
                if (_maxKeys == _root.KeyCount)
                {
                    BTreeNode<TKey, TValue> newRoot = new BTreeNode<TKey, TValue>(_minKeys, _maxKeys, _maxChildren, false);
                    newRoot.AddChild(0, _root);
                    newRoot.SplitChild(0);
                    newRoot.InsertNonFull(key, value);
                    _root = newRoot;
                }  
                else
                {
                    _root.InsertNonFull(key, value);
                }  
            }   
        }   
    }
}
