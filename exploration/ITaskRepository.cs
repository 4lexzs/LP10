using System.Collections.Generic;
using TaskManager.Models;

namespace TaskManager.Services
{
    public interface ITaskRepository
    {
        List<TaskItem> GetAllTasks();
        void AddTask(TaskItem task);
        void UpdateTask(TaskItem task);
        void DeleteTask(int id);
    }
}
