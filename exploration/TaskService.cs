using System.Collections.Generic;
using System.Linq;
using TaskManager.Models;

namespace TaskManager.Services
{
    public class TaskService
    {
        public List<TaskItem> GetAllTasks()
        {
            using (var context = new TaskDbContext())
            {
                return context.Tasks.ToList();
            }
        }

        public TaskItem GetTaskById(int id)
        {
            using (var context = new TaskDbContext())
            {
                return context.Tasks.Find(id);
            }
        }

        public void AddTask(TaskItem task)
        {
            using (var context = new TaskDbContext())
            {
                context.Tasks.Add(task);
                context.SaveChanges();
            }
        }

        public void UpdateTask(TaskItem task)
        {
            using (var context = new TaskDbContext())
            {
                context.Tasks.Update(task);
                context.SaveChanges();
            }
        }

        public void DeleteTask(int id)
        {
            using (var context = new TaskDbContext())
            {
                var task = context.Tasks.Find(id);
                if (task != null)
                {
                    context.Tasks.Remove(task);
                    context.SaveChanges();
                }
            }
        }
    }
}
