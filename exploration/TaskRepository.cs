using System.Collections.Generic;
using System.Linq;
using TaskManager.Models;

namespace TaskManager.Services
{
    public class TaskRepository : ITaskRepository
    {
        public List<TaskItem> GetAllTasks()
        {
            using var context = new TaskDbContext();
            context.Database.EnsureCreated();
            return context.Tasks.ToList();
        }

        public void AddTask(TaskItem task)
        {
            using var context = new TaskDbContext();
            context.Database.EnsureCreated();
            context.Tasks.Add(task);
            context.SaveChanges();
        }

        public void UpdateTask(TaskItem task)
        {
            using var context = new TaskDbContext();
            context.Database.EnsureCreated();
            context.Tasks.Update(task);
            context.SaveChanges();
        }

        public void DeleteTask(int id)
        {
            using var context = new TaskDbContext();
            context.Database.EnsureCreated();
            var task = context.Tasks.Find(id);
            if (task != null)
            {
                context.Tasks.Remove(task);
                context.SaveChanges();
            }
        }
    }
}
