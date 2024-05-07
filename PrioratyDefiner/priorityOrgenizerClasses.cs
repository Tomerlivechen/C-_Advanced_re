using Common_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using Common_Classes.Common_Elements;


namespace PriorityDefiner
{
    internal class priorityOrgenizerClasses
    {
    }

    public static class  GlobalVars
    {
        const string filePath = (@"Resources\Tasklists.json");

        public static MylistOfTakLists allTaskLists = new MylistOfTakLists();

        public static void addlist(MyTaskList newTaskList)
        { bool checkName = false;
            do
            {
                var number_of_field = 1;
                var title = "Insert Name Of Task list";
                var Input_field = new Common_Classes.Input_box_field();
                Input_field.Input_label = "Enter name:";
                var input_Box = new Input_box(number_of_field, title, Input_field);
                input_Box.ShowDialog();
                newTaskList.TaskListName = UniversalVars.inputBoxReturn[0].ToString();
                checkName = false;
                foreach (MyTaskList task_list in allTaskLists.listOfLists)
                {
                   
                    if (newTaskList.TaskListName == task_list.TaskListName)
                    {
                        checkName = true;
                        MessageBox.Show("List Name alredy in use", "Name in use");
                        

                    }
                }
            } while (checkName);
            allTaskLists.listOfLists.Add(newTaskList);
        }
        public static void LoadTaks()
        {
            if (!File.Exists(filePath))
            {
                MylistOfTakLists MewTaskLists = new MylistOfTakLists();
                allTaskLists = MewTaskLists;
                return;
            }

            try
            {
                var rawData = File.ReadAllText(filePath);
                var result = JsonSerializer.Deserialize<MylistOfTakLists>(rawData);
                

                if (result == null)
                {
                    MylistOfTakLists NewTaskLists = new MylistOfTakLists();
                    allTaskLists = NewTaskLists;
                    return;
                }
                allTaskLists = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"File reading error {ex.Message}");
            }
        }
        public static void SaveTasklists()
        {
            var export = JsonSerializer.Serialize(allTaskLists);
            try
            {
                File.WriteAllText(filePath, export);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving: {ex.Message}");
            }
            LoadTaks();
        }

        public static void UpdateTaksList(MyTaskList tasklist)
        {

            foreach (MyTaskList task_list in allTaskLists.listOfLists)
            {
                if (tasklist.TaskListName == task_list.TaskListName)
                {
                    task_list.Task_List = tasklist.Task_List;

                }
            }
;
        }

        public static void SortMyTaskList()
        {
            foreach (MyTaskList tasklist in allTaskLists.listOfLists)
            {
                tasklist.Task_List = tasklist.Task_List.OrderByDescending(MyTask => MyTask.priority).ToList();
            }
        }

        public static void SortThisTaskList(MyTaskList tasklist)
        {
                tasklist.Task_List = tasklist.Task_List.OrderByDescending(MyTask => MyTask.priority).ToList();
        }

        public static void replaceTaskLists(List<MyTaskList> NewallTaskLists)
        {
            MylistOfTakLists newalltast = new MylistOfTakLists();
            newalltast.listOfLists = NewallTaskLists;
            allTaskLists = newalltast;
        }

    }



    public class MyTask
    {
        public int priority { get; set; }
        public string task { get; set; }

        public bool inProgress { get; set; }

        public bool done { get; set; }  

    }

    public class MyTaskList 
    {
        public string TaskListName { get; set; }

        public List<MyTask> Task_List { get; set; } = new List<MyTask>();
        public bool incomplete { get; set; } = true;
        public bool complete { get; set; } = false;

        public void CheckComplete()
        {int index = 0;
            foreach (MyTask item in Task_List)
            {
                if (item.done == false)
                {
                    incomplete = true;
                    index++;
                }
                
            }
            if (index == 0)
            {
                incomplete = false;
            }

            complete = !incomplete;
        }
    }

    public class MylistOfTakLists
    {
        public List<MyTaskList> listOfLists {  get; set; } = new List<MyTaskList>();
    }

}

