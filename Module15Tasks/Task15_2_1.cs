using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Module15Tasks
{
    public static class Task15_2_1
    {
        public static BigInteger Factorial(int number)
        {
            var nums = new List<BigInteger>(1);

            for (int i = 1; i <= number; i++)
                nums.Add(i);

            var result = nums.Aggregate((x, y) => x * y);
   
            return result;
        }
    }
}
