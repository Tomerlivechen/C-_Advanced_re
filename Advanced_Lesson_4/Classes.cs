using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace Advanced_Lesson_4
{
    class Classes
    {
    }


    public class Subclass
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public int Priority { get; set; }
        public bool Active { get; set; }


        public static List<Subclass> GetListFromFile()
        {
            string rawdata = File.ReadAllText("list1.json");
            List<Subclass> resultList =JsonSerializer.Deserialize<List<Subclass>>(rawdata);

            return resultList;

        }
    }

}
