using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.LinkedListLibrary
{
    public class LinkedListCell<T>
    {
        public T _Data;
        private LinkedListCell<T> _Next;

        /// <summary>
        /// Gets and sets the Data
        /// </summary>
        public T Data
        {
            get
            {
                return _Data;
            }
            set
            {
                _Data = value;
            }
        }

        /// <summary>
        /// Gets and sets the reference location
        /// </summary>
        public LinkedListCell<T> Next
        {
            get
            {
                return _Next;
            }
            set
            {
                _Next = value;
            }
        }

    }
}
