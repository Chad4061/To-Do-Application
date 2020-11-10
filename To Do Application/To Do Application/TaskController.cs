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

        private ObservableCollection<string> tasks;

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ObservableCollection<string> Tasks
        {
            get { return tasks; }
            set 
            {
                tasks = value;
                RaisePropertyChanged("Tasks");
            }
        }

        public TaskController(MainWindow window)
        {
            _window = window;
            Tasks = new ObservableCollection<string>();
            _window.TasksDataGrid.ItemsSource = Tasks;
            
        }

        public void AddTaskToList()
        {
            string newTask = _window.TaskTextbox.Text;
            _window.TaskTextbox.Clear();

            if (string.IsNullOrWhiteSpace(newTask))
                return;

            Tasks.Add(newTask);
        }

        public void MarkTaskAsComplete()
        {

        }

        public void RemoveTaskFromList()
        {
            Tasks.Remove((string)_window.TasksDataGrid.SelectedItem);
        }

    }
}
