using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module15Tasks
{
    public static class Task15_1_5
    {
        public static IEnumerable<string> GetUniqueList(List<string> list1, List<string> list2)
        {
            var unique = list1.Union(list2);

            return unique;
        }
    }
}
