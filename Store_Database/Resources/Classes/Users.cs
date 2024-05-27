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
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool StillEmployed { get; set; }
        public bool Manager { get; set; }

        public Users(string Name, string ID, DateTime StartDate, bool StillEmployed, bool Manager)
        {
            this.Name = Name;
            this.ID = ID;
            this.StartDate = DateTime.Now;
            this.EndDate = null;
            this.StillEmployed = StillEmployed;
            this.Manager = Manager;
        }

        public Users(string Name, string ID, DateTime StartDate, DateTime EndDate, bool StillEmployed, bool Manager)
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

        public void LetGo()
        {
            EndDate = DateTime.Now;
            StillEmployed = false;
        }

        public override string ToString()
        {
            string tostring;
            tostring = $"ID:{ID} , Name:{Name} , Start Date:{StartDate} , End Date:{EndDate} , Manager:{Manager} , Still Employed:{StillEmployed}";
            return tostring;


        }
    }
}
