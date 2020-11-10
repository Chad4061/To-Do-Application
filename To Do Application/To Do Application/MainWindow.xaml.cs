using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace To_Do_Application
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TaskController taskController;
        public MainWindow()
        {
            InitializeComponent();
            taskController = new TaskController(this);
            DataContext = taskController;
        }

        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            taskController.AddTaskToList();
        }

        private void TaskTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                taskController.AddTaskToList();
            }
        }

        private void DeleteTaskButton_Click(object sender, RoutedEventArgs e)
        {
            taskController.RemoveTaskFromList();
        }

        private void MarkAsCompleteButton_Click(object sender, RoutedEventArgs e)
        {
            taskController.MarkTaskAsComplete();
        }
    }
}
