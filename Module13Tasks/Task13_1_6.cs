using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module13Tasks
{
    public static class Task13_1_6
    {
        public static int GetWordsNumber(string path)
        {   
            if (File.Exists(path))
            {
                string text = File.ReadAllText(path);

                char[] delimeters = new char[] { ' ', '\r', '\n' };

                var words = text.Split(delimeters, StringSplitOptions.RemoveEmptyEntries);

                return words.Length;
            }
            return 0;
            
        }
        
    }
}
