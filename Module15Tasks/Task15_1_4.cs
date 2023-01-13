using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module15Tasks
{
    public static class Task15_1_4
    {
        public static void SearchCommonChars(string word1, string word2)
        {
            var common = word1.Intersect(word2);

            foreach (char c in common)
                Console.WriteLine(c);
        }
    }
}
