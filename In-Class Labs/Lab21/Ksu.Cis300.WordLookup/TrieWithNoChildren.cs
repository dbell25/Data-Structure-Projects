/* TrieWithMNoChildren.cs
 * Author: Daniel Bell
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.WordLookup
{
    public class TrieWithNoChildren : ITrie
    {
        private bool _rooted = false;
        public ITrie Add(string t)
        {
            if (t == "")
            {
                _rooted = true;
                return this;
            }
            else
            {
                return new TrieWithOneChild(t, _rooted);
            }
        }
        public bool Contains(string s)
        {
            if (s == "") return _rooted;
            return false;
        }
    }
}
