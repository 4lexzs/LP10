using System.Collections.Generic;
using System.Linq;
using TaskManager.Models;

namespace TaskManager.Services
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskDbContext _context;

        public TaskRepository()
        {
            _context = new TaskDbContext();
            _context.Database.EnsureCreated();
        }

        public List<TaskItem> GetAllTasks()
        {
            return _context.Tasks.ToList();
        }

        public TaskItem GetTaskById(int id)
        {
            return _context.Tasks.Find(id);
        }

        public void AddTask(TaskItem task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }

        public void UpdateTask(TaskItem task)
        {
            _context.Tasks.Update(task);
            _context.SaveChanges();
        }

        public void DeleteTask(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                _context.SaveChanges();
            }
        }
    }
}
