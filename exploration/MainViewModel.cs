using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TaskManager.Models;
using TaskManager.Services;

namespace TaskManager.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly ITaskRepository _taskRepository;
        private ObservableCollection<TaskItem> _tasks = new ObservableCollection<TaskItem>();
        private string _newTaskTitle = string.Empty;
        private string _newTaskDescription = string.Empty;

        public ObservableCollection<TaskItem> Tasks
        {
            get { return _tasks; }
            set
            {
                _tasks = value;
                OnPropertyChanged();
            }
        }

        public string NewTaskTitle
        {
            get { return _newTaskTitle; }
            set
            {
                _newTaskTitle = value;
                OnPropertyChanged();
            }
        }

        public string NewTaskDescription
        {
            get { return _newTaskDescription; }
            set
            {
                _newTaskDescription = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            _taskRepository = new TaskRepository();
            LoadTasks();
        }

        public void LoadTasks()
        {
            var taskList = _taskRepository.GetAllTasks();
            Tasks = new ObservableCollection<TaskItem>(taskList);
        }

        public void AddTask()
        {
            if (!string.IsNullOrWhiteSpace(NewTaskTitle))
            {
                var newTask = new TaskItem
                {
                    Title = NewTaskTitle,
                    Description = NewTaskDescription
                };

                _taskRepository.AddTask(newTask);
                LoadTasks();

                // Clear input fields
                NewTaskTitle = string.Empty;
                NewTaskDescription = string.Empty;
            }
        }

        public void DeleteTask(TaskItem task)
        {
            if (task != null)
            {
                _taskRepository.DeleteTask(task.Id);
                LoadTasks();
            }
        }

        public void ToggleTaskCompletion(TaskItem task)
        {
            if (task != null)
            {
                task.IsCompleted = !task.IsCompleted;
                if (task.IsCompleted)
                {
                    task.CompletedAt = System.DateTime.Now;
                }
                else
                {
                    task.CompletedAt = null;
                }
                _taskRepository.UpdateTask(task);
                LoadTasks();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
