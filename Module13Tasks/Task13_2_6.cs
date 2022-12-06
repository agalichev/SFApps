using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module13Tasks
{
    public static class Task13_2_6
    {
        public static ArrayList OptimizeArrayList(ArrayList input)
        {
            int sum = 0;

            StringBuilder stringBuilder = new StringBuilder();

            foreach(var element in input)
            {
                if (element is int number)
                {
                    sum += number;
                }

                if (element is string s)
                    stringBuilder.Append(s + " ");
            }
            ArrayList output = new ArrayList()
            {
                sum,
                stringBuilder.ToString()
            };

            return output;
        }
    }
}
