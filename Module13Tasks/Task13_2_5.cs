using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module13Tasks
{
    public static class Task13_2_5
    {
        public static ArrayList GetArrayList(string[] strArray, int[] intArray)
        {
            var arrayList = new ArrayList();

            foreach(var number in intArray)
            {
                arrayList.Add(strArray[number - 1]);
                arrayList.Add(number);
            }
            return arrayList;
        }
    }
}
