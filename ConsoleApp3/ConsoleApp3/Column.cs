using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{

    public class Column
    {
        public string columnId { get; set; }
        public string columnName { get; set; }
        public bool tasksLimited { get; set; }
        public Task[] tasks { get; set; }
    }

    public class Task
    {
        public string _id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string color { get; set; }
        public string columnId { get; set; }
        public int totalSecondsSpent { get; set; }
        public int totalSecondsEstimate { get; set; }
        public string responsibleUserId { get; set; }
        public Date[] dates { get; set; }
        public Label[] labels { get; set; }
        public Subtask[] subTasks { get; set; }
    }

    public class Date
    {
        public string targetColumnId { get; set; }
        public string status { get; set; }
        public string dateType { get; set; }
        public DateTime dueTimestamp { get; set; }
        public DateTime dueTimestampLocal { get; set; }
    }

    public class Label
    {
        public string name { get; set; }
        public bool pinned { get; set; }
    }

    public class Subtask
    {
        public string name { get; set; }
        public bool finished { get; set; }
        public DateTime dueDateTimestamp { get; set; }
        public DateTime dueDateTimestampLocal { get; set; }
    }

}
