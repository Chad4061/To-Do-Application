using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_Do_Application
{
    public class ToDoTask
    {
        private string _taskName;

        public string TaskName
        {
            get { return _taskName; }
            set { _taskName = value; }
        }

        private string _status;

        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }

    }
}
