using System;

namespace Exam.TaskManager
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var taskManager = new TaskManager();

            var task1 = new Task("af", "Task1", 60, "DomainA");
            var task2 = new Task("aflk", "Task2", 30, "DomainB");
            var task3 = new Task("aflkr", "BTask333", 10, "DomainA");
            var task4 = new Task("aflmn", "ATask4", 15, "DomainA");

            taskManager.AddTask(task1);
            taskManager.AddTask(task2);
            taskManager.AddTask(task3);
            taskManager.AddTask(task4);

           
           
            var task = taskManager.GetTask("aflkr");


            var tasks = taskManager.GetTasksInEETRange(10,20);
           //task1,task2,ATask4,BTask3
        }
    }
}
