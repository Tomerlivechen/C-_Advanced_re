using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Database.Resources.Classes
{
    public class DB_Item
    {
        Guid guid = new Guid();
        DateTime DateTime = DateTime.Now;

        public string ID { get; set; }
        public string ItemName { get; set; }
        public string MainCatigory { get; set; }
        public string SeconderyCatigory { get; set; }

        public double Amount {  get; set; }

        public double MinAmount { get; set; }

        public string AddedDate { get; set; }

        public string LastUpdate { get; set; }

        public DB_Item(string _ItemName, string _MainCatigory, string _SeconderyCatigory, double _Amount, double _MinAmount )
        {
            AddedDate = DateTime.ToString("yyyy-MM-dd");
            LastUpdate = DateTime.ToString();
            ID = Guid.NewGuid().ToString();
            ItemName = _ItemName;
            MainCatigory = _MainCatigory;
            SeconderyCatigory = _SeconderyCatigory;
            Amount = _Amount;
            MinAmount = _MinAmount;
        }

        public void AddAmount(double _Amount)
        {
            Amount += _Amount;
            updateLastUpdate();
        }

        public void RemoveAmount(double _Amount)
        {
            Amount -= _Amount;
            updateLastUpdate();
        }

        public void UpdateMinAmount (double _Amount)
        {
            MinAmount = _Amount;
            updateLastUpdate();
        }


        public void updateLastUpdate()
        {
            DateTime DateTime = DateTime.Now;
            LastUpdate = DateTime.ToString();
        }

        public void ChangeCat1(string _CatName)
        {
            MainCatigory = _CatName;
            updateLastUpdate();
        }

        public void ChangeCat2(string _CatName)
        {
            MainCatigory = _CatName;
            updateLastUpdate();
        }
    }

}
