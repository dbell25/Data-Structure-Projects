/* TrieWithNoChidren.cs
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
    /// A trie node with no children.
    /// </summary>
    public class TrieWithNoChildren : ITrie
    {
        /// <summary>
        /// Indicates whether the trie rooted at this node contains the empty string.
        /// </summary>
        private bool _hasEmptyString;

        /// <summary>
        /// Builds the result of adding the given string to the trie rooted at this node.
        /// </summary>
        /// <param name="s">The string to add.</param>
        /// <returns>The resulting trie.</returns>
        public ITrie Add(string s)
        {
            if (s == "")
            {
                _hasEmptyString = true;
                return this;
            }
            else
            {
                return new TrieWithOneChild(s, _hasEmptyString);
            }
        }

        /// <summary>
        /// Determines whether the trie rooted at this node contains the given string.
        /// </summary>
        /// <param name="s">The string to look up.</param>
        /// <returns>Whether this trie contains s.</returns>
        public bool Contains(string s)
        {
            if (s == "")
            {
                return _hasEmptyString;
            }
            else
            {
                return false;
            }
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
                return null;
            }
        }

        /// <summary>
        /// Adds StringBuilder values to the Ilist.
        /// </summary>
        /// <param name="prefix"></param>
        /// <param name="list"></param>
        public void AddAll(StringBuilder prefix, IList list)
        {
            if (_hasEmptyString)
            {
                list.Add(prefix.ToString());
            }
        }
    }
}
