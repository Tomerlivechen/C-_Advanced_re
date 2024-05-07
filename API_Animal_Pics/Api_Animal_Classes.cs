using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using Common_Classes.Common_Elements;
using Common_Classes;
using System.Xml.Linq;
using System.Windows.Media.Imaging;

namespace API_Animal_Pics
{
    class Api_Animal_Classes
    {
    }


    public class AnimalPic
    {
        public string? id { get; set; } = null;
        public string? url { get; set; } = null;
        public int width { get; set; }
        public int height { get; set; }
        public string? image { get; set; } = null;
        public string? link { get; set; } = null;

    }

    public class Animallist
    {
        public string? Name { get; set;} 

        public List<AnimalPic> animalPics { get; set; } = new List<AnimalPic>();
    }

    public class Animallists
    {
        public List<Animallist> animalPiclists { get; set; } = new List<Animallist>();
    }

    public static class GlobalVars
    {

        const string filePath = (@"Resources\Piclists.json");

        public static Animallists animalPiclists = new Animallists();
        public static void LoadPicLists()
        {
            if (!File.Exists(filePath))
            {
                Animallists NewAnimallists = new Animallists();
                animalPiclists = NewAnimallists;
                return;
            }

            try
            {
                var rawData = File.ReadAllText(filePath);
                var result = JsonSerializer.Deserialize<Animallists>(rawData);
                animalPiclists = result;

                if (result == null)
                {
                    Animallists NewAnimallists = new Animallists();
                    animalPiclists = NewAnimallists;
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"File reading error {ex.Message}");
            }
        }

        public static void SavePiclists()
        {
            var export = JsonSerializer.Serialize(animalPiclists);
            try
            {
                File.WriteAllText(filePath, export);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving: {ex.Message}");
            }
            LoadPicLists();
        }

        public static void AddPicList()
        {
            {
                bool checkName = false;
                Animallist animallist = new Animallist();
                do
                {
                    var number_of_field = 1;
                    var title = "Insert Name Of Picture list";
                    var Input_field = new Common_Classes.Input_box_field();
                    Input_field.Input_label = "Enter name:";
                    var input_Box = new Input_box(number_of_field, title, Input_field);
                    input_Box.ShowDialog();
                    animallist.Name = UniversalVars.inputBoxReturn[0].ToString();
                    checkName = false;
                    foreach (Animallist pic_list in animalPiclists.animalPiclists)
                    {

                        if (pic_list.Name == animallist.Name)
                        {
                            checkName = true;
                            MessageBox.Show("List Name alredy in use", "Name in use");


                        }
                    }
                } while (checkName);
                animalPiclists.animalPiclists.Add(animallist);
            }
        }

        public static void AddPic(string animallist, AnimalPic pic)
        {
            Animallist selectedanimallist = animalPiclists.animalPiclists.Find(list => list.Name == animallist);
            if (selectedanimallist != null)
            {
                selectedanimallist.animalPics.Add(pic);
            }
        }

        public static void RemovePic(string animallist, AnimalPic pic)
        {
            Animallist selectedanimallist = animalPiclists.animalPiclists.Find(list => list.Name == animallist);
            if (selectedanimallist != null)
            {
                selectedanimallist.animalPics.Remove(pic);
            }
        }

        public static void CheckDuplicate()
        {

            foreach (Animallist list in animalPiclists.animalPiclists)
            {
                List<AnimalPic> imagesToRemove = new List<AnimalPic>();
                foreach (AnimalPic test_image in list.animalPics)
                {

                    int index = 0;
                    foreach (AnimalPic image in list.animalPics)
                    {
                        if (image.id == test_image.id)
                        {
                            index++;
                        }
                        if (index >= 2)
                        {
                            imagesToRemove.Add(image);
                            index--;
                        }
                    }
                }
                    foreach (AnimalPic image in imagesToRemove)
                    {
                        list.animalPics.Remove(image);
                    }
                }
            }

        }
            

}
