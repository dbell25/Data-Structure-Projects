/* TextAnalyzer.cs
 * Author: Daniel Bell
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using Ksu.Cis300.Sort;

namespace Ksu.Cis300.TextAnalyzer
{
    /// <summary>
    /// Determines how similiar two sets of text are.
    /// </summary>
    public static class TextAnalyzer
    {
        /// <summary>
        /// Reads the given file and updates the dictionary with words from the given file, returns the number of words.
        /// </summary>
        /// <param name="name">string storing a file name</param>
        /// <param name="filenum">int storing the number of the file</param>
        public static int ProcessFile(string name, int filenum, Dictionary<string, WordCount> lookup)
        {
            int count = 0;
            using (StreamReader input = new StreamReader(name))
            {
                while (!input.EndOfStream)
                {
                    string text = input.ReadLine().ToLower();
                    string[] temp = Regex.Split(text, "[^abcdefghijklmnopqrstuvwxyz]+");
                    foreach (string i in temp)
                    {
                        if (i != "")
                        {
                            WordCount wordcount;
                            if (!(lookup.TryGetValue(i, out wordcount)))
                            {
                                wordcount = new WordCount(i, 2);
                                lookup.Add(i, wordcount);
                            }
                            wordcount.Increment(filenum);
                            count++;
                        }
                    }
                }
            }
            return count;
        }

        /// <summary>
        /// Returns a MinPriorityQueue whose elements contain the frequencies in each file of the most common words.
        /// </summary>
        /// <param name="input">Dictionary containing a string and a WordCount object</param>
        /// <param name="words">int array storing words</param>
        /// <param name="num">int for comparing against count</param>
        /// <returns></returns>
        public static MinPriorityQueue<float, WordFrequency> GetMostCommonWord(Dictionary<string, WordCount> input, int[] words, int num)
        {
            MinPriorityQueue<float, WordFrequency> queue = new MinPriorityQueue<float, WordFrequency>();
            foreach (KeyValuePair<string, WordCount> pair in input)
            {
                WordFrequency temp = new WordFrequency(pair.Value, words);
                queue.Add(temp[0] + temp[1], temp);
                if (queue.Count > num) queue.RemoveMinimumPriority();
            }
            return queue;
        }

        /// <summary>
        /// Returns a float giving the difference measure.
        /// </summary>
        /// <param name="data">MinPriorirtyQueue contain a float(priority) and a Word frequency object</param>
        /// <returns></returns>
        public static float GetDifference(MinPriorityQueue<float, WordFrequency> data)
        {
            float accumulator = 0;
            while(data.Count > 0)
            {
                WordFrequency x = data.RemoveMinimumPriority();
                accumulator += ((x[0] - x[1]) * (x[0] - x[1]));
            }
            return (100 * ((float)Math.Sqrt(accumulator)));
        }
    }
}
