using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.WordLookup
{
    class Trie
    {
        /// <summary>
        /// Initializes a field determining if a tree is rooted.
        /// </summary>
        private bool _rooted = false;

        /// <summary>
        /// Initializes a new tree with 26 locations.
        /// </summary>
        private Trie[]_children = new Trie[26];

        /// <summary>
        /// Determines wether or not the dictionary contains a given string.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool Contains(string s)
        {
            if (s.Equals(""))
            {
                return _rooted;
            }
            else if (s[0] < 'a' || s[0] > 'z')
            {
                return false;
            }
            else if (_children[s[0] - 'a'] == null)
            {
                return false;
            }
            else
            {
                return _children[s[0] - 'a'].Contains(s.Substring(1));
            }
        }

        /// <summary>
        /// Adds a new Trie if the first character isn't found.
        /// </summary>
        /// <param name="s"></param>
        public void Add(string s)
        {
            if (s.Equals(""))
            {
                _rooted = true;
            }
            else if (s[0] < 'a' || s[0] > 'z')
            {
                throw new Exception();
            }
            else
            {
                if (_children[s[0] - 'a'] == null)
                {
                    _children[s[0] - 'a'] = new Trie();
                }
                _children[s[0] - 'a'].Add(s.Substring(1));
            }
            
        }
    }
}