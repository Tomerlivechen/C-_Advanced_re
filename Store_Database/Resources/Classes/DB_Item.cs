﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Store_Database.Resources.Classes
{
    public class DB_Item
    {
        Guid guid = new Guid();
        DateTime DateTime = DateTime.Now;

        public string ID { get; set; }
        public string ItemName { get; set; }
        public string MainCategory { get; set; }
        public string SeconderyCategory { get; set; }

        public double Amount {  get; set; }

        public double MinAmount { get; set; }

        public string AddedDate { get; set; }

        public string LastUpdate { get; set; }
        public string LastUpdater { get; set; }

        public DB_Item(string itemName, string mainCategory, string seconderyCategory, double amount, double minAmount , string lastUpdater )
        {
            AddedDate = DateTime.ToString("yyyy-MM-dd");
            LastUpdate = DateTime.ToString();
            ID = Guid.NewGuid().ToString();
            ItemName = itemName;
            MainCategory = mainCategory;
            SeconderyCategory = seconderyCategory;
            Amount = amount;
            MinAmount = minAmount;
            LastUpdater = lastUpdater;
        }

        [JsonConstructor]
        public DB_Item(string ID, string ItemName, string MainCategory, string SeconderyCategory, double Amount, double MinAmount, string AddedDate, string LastUpdate, string LastUpdater)
        {
            this.ID = ID;
            this.ItemName = ItemName;
            this.MainCategory = MainCategory;
            this.SeconderyCategory = SeconderyCategory;
            this.Amount = Amount;
            this.MinAmount = MinAmount;
            this.AddedDate = AddedDate;
            this.LastUpdate = LastUpdate;
            this.LastUpdater = LastUpdater;
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
            MainCategory = _CatName;
            updateLastUpdate();
        }

        public void ChangeCat2(string _CatName)
        {
            MainCategory = _CatName;
            updateLastUpdate();
        }
    }

}