/* DoubleLinkedListCell.cs
 * Author: Daniel Bell
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.ConnectFour
{
    class DoubleLinkedListCell<T>
    {
        /// <summary>
        /// Private fields for storing data.
        /// </summary>
        private DoubleLinkedListCell<T> _next = null;
        private DoubleLinkedListCell<T> _prev = null;
        private T _data = default(T);
        private string _id;

        /// <summary>
        /// Constructor for DoubleLinkedListCells
        /// </summary>
        /// <param name="identifier"></param>
        public DoubleLinkedListCell(string identifier)
        {
            _id = identifier;
        }

        /// <summary>
        /// Gets and sets the references for following cells.
        /// </summary>
        public DoubleLinkedListCell<T> Next
        {
            get
            {
                return _next;
            }
            set
            {
                _next = value;
            }
        }

        /// <summary>
        /// Gets and sets references for previous cells.
        /// </summary>
        public DoubleLinkedListCell<T> Prev
        {
            get
            {
                return _prev;
            }
            set
            {
                _prev = value;
            }
        }

        /// <summary>
        /// Gets and sets cell data.
        /// </summary>
        public T Data
        {
            get
            {
                return _data;
            }
            set
            {
                _data = value;
            }
        }

        /// <summary>
        /// Gets and sets the string id.
        /// </summary>
        public string Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
    }
}