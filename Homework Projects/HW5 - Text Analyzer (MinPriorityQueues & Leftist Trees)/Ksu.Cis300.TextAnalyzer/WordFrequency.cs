/* WordFrequency.cs
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
    /// Public struct that determines the frequencies of individual words. 
    /// </summary>
    public struct WordFrequency
    {
        /// <summary>
        /// Field for storing a word.
        /// </summary>
        private string _word;

        /// <summary>
        /// Stores the frequency of a word in each file.
        /// </summary>
        private float[] _frequency;

        /// <summary>
        /// Constructor for the word frequency object.
        /// </summary>
        public WordFrequency(WordCount count, int[] words)
        {
            if (words.Length != count.NumberOfFiles) throw new ArgumentException();
            _frequency = new float[words.Length];
            _word = count.Word;

            for(int i = 0; i < words.Length; i++)
            {
                _frequency[i] = count[i] / (float)words[i];
            }
        }

        /// <summary>
        /// A public property to get the word.
        /// </summary>
        public string Word
        {
            get
            {
                return _word;
            }
        }

        /// <summary>
        /// Indexer to get the frequency of a word from the specified file.
        /// </summary>
        /// <param name="index">int storing an index</param>
        /// <returns></returns>
        public float this[int index]
        {
            get
            {
                if (index >= _frequency.Length || index < 0) throw new ArgumentException();
                return _frequency[index];
            }
        }
    }
}
