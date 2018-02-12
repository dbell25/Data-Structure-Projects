/* TrieWithOneChild.cs
 * Author: Daniel Bell
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.WordLookup
{
    public class TrieWithOneChild : ITrie
    {
        private bool _empty;
        private ITrie _child;
        private char _label;

        public ITrie Add(string t)
        {
            if (t == "")
            {
                _empty = true;
                return this;
            }
            else if(t[0] == _label)
            {
                _child.Add(t.Substring(1));
            }
            else
            {
                return new TrieWithManyChildren(t, _empty, _label, _child);
            }
            return this;
        }

        public bool Contains(string s)
        {
            if (s == "") return _empty;
            if (s.Equals(_label)) Contains(s.Substring(1));
            return false;
        }

        public TrieWithOneChild(string x, bool empty)
        {
        
            if (empty || x[0] > 'z' || x[0] < 'a') throw new Exception();
            _empty = empty;
            _label = x[0];
            _child = new TrieWithNoChildren().Add(x.Substring(1));
        }
    }
}