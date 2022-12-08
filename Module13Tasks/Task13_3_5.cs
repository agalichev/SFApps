using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module13Tasks
{
    public static class Task13_3_5
    {
        public static void ModifyCollection(List<string> list, ArrayList arrayList)
        {
            var missedArray = new string[7];
            arrayList.GetRange(4, 7).CopyTo(missedArray);
            list.AddRange(missedArray);

            foreach (var item in list)
                Console.WriteLine(item);
        }
    }
}
