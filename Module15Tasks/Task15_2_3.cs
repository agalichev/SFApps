using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module15Tasks
{
    public static class Task15_2_3
    {
        public static double Average(int[] numbers)
        {
            return numbers.Sum(x => x)/(double)numbers.Length;
        }
    }
}
