/* TrieWithManyChildren.cs
 * Author: Rod Howell
 * Modified By: Daniel Bell
 */
using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.WordLookup
{
    /// <summary>
    /// Implements a single node of a trie.
    /// </summary>
    public class TrieWithManyChildren : ITrie
    {
        /// <summary>
        /// Indicates whether the trie rooted at this node contains the empty string.
        /// </summary>
        private bool _hasEmptyString = false;

        /// <summary>
        /// The children of this node.
        /// </summary>
        private ITrie[] _children = new ITrie[26];

        /// <summary>
        /// Constructs a trie containing the given string and having the given child at the given label.
        /// If s contains any characters other than lower-case English letters,
        /// throws an ArgumentException.
        /// If childLabel is not a lower-case English letter, throws an ArgumentException.
        /// </summary>
        /// <param name="s">The string to include.</param>
        /// <param name="hasEmpty">Indicates whether this trie should contain the empty string.</param>
        /// <param name="childLabel">The label of the child.</param>
        /// <param name="child">The child labeled childLabel.</param>
        public TrieWithManyChildren(string s, bool hasEmpty, char childLabel, ITrie child)
        {
            if (childLabel < 'a' | childLabel > 'z')
            {
                throw new ArgumentException();
            }
            _hasEmptyString = hasEmpty;
            _children[childLabel - 'a'] = child;
            Add(s);
        }

        /// <summary>
        /// Determines whether the trie rooted at this node contains the given string.
        /// </summary>
        /// <param name="s">The string to look up.</param>
        /// <returns>Whether the trie contains s.</returns>
        public bool Contains(string s)
        {
            if (s == "")
            {
                return _hasEmptyString;
            }
            else
            {
                int loc = s[0] - 'a';
                if (loc < 0 || loc >= _children.Length || _children[loc] == null)
                {
                    return false;
                }
                else
                {
                    return _children[loc].Contains(s.Substring(1));
                }
            }
        }

        /// <summary>
        /// Adds the given string to the trie rooted at this node.
        /// If the string contains a character that is not a lower-case English
        /// letter, throws an ArgumentException.
        /// </summary>
        /// <param name="s">The string to add.</param>
        public ITrie Add(string s)
        {
            if (s == "")
            {
                _hasEmptyString = true;
            }
            else
            {
                int loc = s[0] - 'a';
                if (loc < 0 || loc >= _children.Length)
                {
                    throw new ArgumentException();
                }
                if (_children[loc] == null)
                {
                    _children[loc] = new TrieWithNoChildren();
                }
                _children[loc] = _children[loc].Add(s.Substring(1));
            }
            return this;
        }

        /// <summary>
        /// Finds completions for the string preifx.
        /// </summary>
        /// <param name="prefix"></param>
        /// <returns></returns>
        public ITrie GetCompletions(string prefix)
        {
            if (prefix == "")
            {
                return this;
            }
            else
            {
                int loc = prefix[0] - 'a';
                if (loc < 0 || loc >= _children.Length || _children[loc] == null)
                {
                    return null;
                }
                else
                {
                    return _children[loc].GetCompletions(prefix.Substring(1));
                }
            }
        }

        /// <summary>
        /// Adds StringBuilder values to the Ilist.
        /// </summary>
        /// <param name="prefix"></param>
        /// <param name="list"></param>
        public void AddAll(StringBuilder prefix, IList list)
        {
            
            for(int i = 0; i < _children.Length; i++)
            {
                if (_hasEmptyString)
                {
                    list.Add(prefix.ToString());
                }

                if(_children[i] != null)
                {
                    prefix.Append((char)(i + 'a'));
                    _children[i].AddAll(prefix, list);
                    prefix.Length--;
                }
            }
        }
    }
}
