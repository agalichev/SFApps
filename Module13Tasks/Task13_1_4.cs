using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module13Tasks
{
    public static class Task13_1_4
    {
        public static bool CheckAscending(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i + 1] < array[i])
                    return false;
            }
            return true;
        }
    }
}
