using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml.Linq;

namespace System_manager.Resources
{
    class System_Manager_Classes
    {
    }


    public class Person : INotifyPropertyChanged
    {

        private string _ID;
        private string _name;
        private int _age;


        public Person(string id, string Name, int Age)
        {
            ID = id;
            name = Name;
            age = Age;
        }

        public string ID
        {
            get { return _ID; }
            set
            {
                if (_ID != value)
                {
                    _ID = value;
                    OnPropertyChanged(nameof(ID));
                }
            }
        }
        public string name        {
            get { return _name; }
    set
        {
            if (_name != value)
            {
                _name = value;
                OnPropertyChanged(nameof(name));
}
        }
    }
        public int age { get { return _age; }
            set
            {
                if (_age != value)
                {
                    _age = value;
                    OnPropertyChanged(nameof(age));
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


}
