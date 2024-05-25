using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Store_Database.Resources.Classes
{
    public class Static_Data
    {
        public static List<Categories> MainCatagories { get; set; } 
        public static List<Categories> SeconderyCatagories { get; set; }

        public static List<DB_Item> BDItems { get; set; } = new List<DB_Item>();

        public static void LoadStoredDataBase()
        {
            string RawJSON = File.ReadAllText("Resources/Products.json");
            BDItems = JsonSerializer.Deserialize<List<DB_Item>>(RawJSON);

        }



    }
}
