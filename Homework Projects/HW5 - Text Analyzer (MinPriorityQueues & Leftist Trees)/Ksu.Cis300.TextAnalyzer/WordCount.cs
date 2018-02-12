/* WordCount.cs
 * Author: Daniel Bell
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TextAnalyzer
{
    /// <summary>
    /// Determines the quantity of each word.
    /// </summary>
    public class WordCount
    {
        /// <summary>
        /// Stores the occurance of a word within a text file.
        /// </summary>
        private int[] _count;

        /// <summary>
        /// Stores a word.
        /// </summary>
        private string _word;

        /// <summary>
        /// Constructor for the WordCount object.
        /// </summary>
        /// <param name="word">String storing a word</param>
        /// <param name="numwords">int storin the number of words</param>
        public WordCount(string word, int numwords)
        {
            _word = word;
            _count = new int[numwords];
        }

        /// <summary>
        /// Property that gets the value of _word.
        /// </summary>
        public string Word
        {
            get
            {
                return _word;
            }
        }

        /// <summary>
        /// Property that gets the number of files being processed.
        /// </summary>
        public int NumberOfFiles
        {
            get
            {
                return _count.Length;
            }
        }

        /// <summary>
        /// Gets the number of occurrences of the word in a specified file.
        /// </summary>
        /// <param name="index">int storing an index</param>
        /// <returns></returns>
        public int this[int index]
        {
            get
            {
                if (index >= _count.Length || index < 0) throw new ArgumentException();
                return _count[index];
            }
        }

        /// <summary>
        /// Takes a file number and increments the number of occurrences of the word in that file.
        /// </summary>
        /// <param name="filenum">int storing the file number</param>
        public void Increment(int filenum)
        {
            if (filenum >= _count.Length || filenum < 0) throw new ArgumentException();
            _count[filenum]++;
        }
    }
}
