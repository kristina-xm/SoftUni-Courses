using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;

namespace Exam.TaskManager
{
    public class TaskManager : ITaskManager
    {
        Dictionary<string,Task> tasks = new Dictionary<string, Task>();
        //Queue<Task> pendingExecution = new Queue<Task>();
        LinkedList<Task> pendingExecution = new LinkedList<Task>();
        
        public void AddTask(Task task)
        {
            pendingExecution.AddLast(task);
            tasks.Add(task.Id, task);
        }

        public bool Contains(Task task)
        {
            return this.tasks.ContainsKey(task.Id);
        }

        public void DeleteTask(string taskId)
        {
            if (!this.tasks.ContainsKey(taskId))
            {
                throw new ArgumentException();
            }

            var task = tasks[taskId];

            if (pendingExecution.Contains(task))
            {
                 pendingExecution.Remove(task);
            }

            this.tasks.Remove(taskId);
        }

        public Task ExecuteTask()
        {
            var task = pendingExecution.First();

            if (!Contains(task))
            {
                throw new ArgumentException();
            }
            
            tasks[task.Id].Executed = true;

            pendingExecution.RemoveFirst();

            return task;
        }

        public IEnumerable<Task> GetAllTasksOrderedByEETThenByName()
        {
           var orderedTasks = this.tasks.Values
           .OrderByDescending(task => task.EstimatedExecutionTime)
           .ThenBy(task => task.Name.Length);

           
            if (!orderedTasks.Any())
            {
                return new List<Task>();
            }

            return orderedTasks;
        }

        public IEnumerable<Task> GetDomainTasks(string domain)
        {
            var unexecutedTasksInDomain = tasks.Values
            .Where(task => task.Executed == false && task.Domain == domain)
            .ToArray();

            if (!unexecutedTasksInDomain.Any())
            {
                throw new ArgumentException();
            }

             return unexecutedTasksInDomain;
        }

        public Task GetTask(string taskId)
        {
           if (!tasks.ContainsKey(taskId))
           {
                throw new ArgumentException();
           }

           return tasks[taskId];
        }

        public IEnumerable<Task> GetTasksInEETRange(int lowerBound, int upperBound)
        {
            var tasksInEETRange = pendingExecution
            .Where(task => task.EstimatedExecutionTime >= lowerBound && task.EstimatedExecutionTime <= upperBound && task.Executed == false)
            
            .ToArray();

            if (!tasksInEETRange.Any())
            {
                return new List<Task>();
            }


            return tasksInEETRange;
        }

        public void RescheduleTask(string taskId)
        {
            var task = tasks[taskId];

            if (task.Executed == false || task == null)
            {
                throw new ArgumentException();
            }

            tasks[taskId].Executed = false;

            pendingExecution.AddLast(task);
        }

        public int Size()
        {
            return tasks.Values.Count(task => task.Executed == false);
        }
    }
}
