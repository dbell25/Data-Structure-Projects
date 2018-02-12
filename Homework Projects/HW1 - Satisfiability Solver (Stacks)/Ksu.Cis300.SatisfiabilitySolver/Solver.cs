using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Ksu.Cis300.SatisfiabilitySolver
{
    static class Solver
    {
        /// <summary>
        /// Determines wether or not the imput text is valid formula
        /// </summary>
        /// <param name="a"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        private static bool IsValidFormula(string[] a, int count)
        {
            for (int i = 1; i < a.Length; i++)
            {
                foreach(char j in a[i])
                {
                    if (((j < 'a') || (j > 'a' + (count - 1))) 
                        && ((j < 'A') || (j > 'A' + (count - 1))))
                        {
                            return false;
                        }
                }
            }
            return true;
        }

        /// <summary>
        /// Initializes the entire bool stack to false
        /// </summary>
        /// <param name="a"></param>
        /// <param name="max"></param>
        private static void FillStack(Stack<bool> a, int max)
        {
            while(a.Count < max)
            {
                a.Push(false);
            }
        }

        /// <summary>
        /// Determines whether an assignment satisfies a formula
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private static bool IsSolution(bool[] a, string[] b)
        {
            int temp; bool check = false;

            for (int i = 1; i < b.Length; i++)
            {
                check = false;
                for (int j = 0; j < b[i].Length; j++)
                {
                    if (Char.IsLower(b[i], j))
                    {
                        temp = b[i][j] - 'a';
                        if (a[temp])
                        {
                            check = true;
                            break;
                        }
                    }
                    if (Char.IsUpper(b[i], j))
                    {
                        temp = b[i][j] - 'A';
                        if (!a[temp])
                        {
                            check = true;
                            break;
                        }
                    }

                }
                if (!check) return false;
            }
            return true;
        }

        /// <summary>
        /// Finds a satisfying argument
        /// </summary>
        /// <param name="input"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static bool[] Solve(string[] input, int count)
        {
            Stack<bool> Stack1 = new Stack<bool>();
            if (count > 26 || count <= 0) throw new IOException("The number of variables must be a positive integer no greater than 26.");
            if (!IsValidFormula(input, count)) throw new IOException("The Formula is invalid");
            FillStack(Stack1, count);

            while (Stack1.Count > 0)
            {
                if (Stack1.Count == count)
                {
                    bool[] temp = Stack1.ToArray();
                    if (IsSolution(temp, input))
                    {
                        return temp;
                    }
                }   
                bool j = Stack1.Pop();
                if (!j)
                {
                    Stack1.Push(true);
                    FillStack(Stack1, count);
                }
            }
            return null;
        }
    }
}