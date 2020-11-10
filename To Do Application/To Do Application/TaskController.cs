using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace To_Do_Application
{
    public class TaskController : INotifyPropertyChanged
    {
        private MainWindow _window;

        private ObservableCollection<ToDoTask> _tasks;

        public event PropertyChangedEventHandler PropertyChanged;
        private ToDoTask _toDoTask;

        public ToDoTask toDoTask
        {
            get { return _toDoTask; }
            set 
            { 
                _toDoTask = value;
                RaisePropertyChanged("toDoTask");
            }
        }

        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ObservableCollection<ToDoTask> Tasks
        {
            get { return _tasks; }
            set 
            {
                _tasks = value;
                RaisePropertyChanged("Tasks");
            }
        }

        public TaskController(MainWindow window)
        {
            _window = window;
            Tasks = new ObservableCollection<ToDoTask>();
            _window.TasksDataGrid.ItemsSource = Tasks;
            
        }

        public void AddTaskToList()
        {
            string taskName = _window.TaskTextbox.Text;
            ToDoTask newTask = new ToDoTask { TaskName = taskName, Status = "Not_Done" };
            _window.TaskTextbox.Clear();

            if (string.IsNullOrWhiteSpace(taskName))
                return;

            Tasks.Add(newTask);
        }

        public void MarkTaskAsComplete()
        {
            if (_window.TasksDataGrid.SelectedItem == null)
                return;

            toDoTask = (ToDoTask)_window.TasksDataGrid.SelectedItem;

            if (toDoTask.Status == "Done")
                toDoTask.Status = "Not_Done";
            else
                toDoTask.Status = "Done";

            _window.TasksDataGrid.ItemsSource = null;
            _window.TasksDataGrid.ItemsSource = Tasks;
        }

        public void RemoveTaskFromList()
        {
            toDoTask = (ToDoTask)_window.TasksDataGrid.SelectedItem;
            Tasks.Remove(toDoTask);
        }

    }
}
