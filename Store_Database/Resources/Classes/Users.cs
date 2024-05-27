using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Database.Resources.Classes
{
    public class Users
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public bool StillEmployed { get; set; }
        public bool Manager { get; set; }

        public Users(string Name, string ID, string StartDate, string EndDate, bool StillEmployed, bool Manager)
        {
            this.Name = Name;
            this.ID = ID;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.StillEmployed = StillEmployed;
            this.Manager = Manager;
        }
        public Users()
        {
        }

    }
}
