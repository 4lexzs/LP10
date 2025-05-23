using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using TaskManager.Models;
using TaskManager.Services;

namespace TaskManager.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly ITaskRepository _taskRepository;
        private ObservableCollection<TaskItem> _tasks = new ObservableCollection<TaskItem>();
        private ObservableCollection<TaskItem> _filteredTasks = new ObservableCollection<TaskItem>();
        private string _newTaskTitle = string.Empty;
        private string _newTaskDescription = string.Empty;
        private string _newTaskCategory = "Allgemein";
        private int _newTaskPriority = 1;
        private string _selectedCategory = "Alle";
        private bool _showCompletedTasks = true;

        public ObservableCollection<TaskItem> Tasks
        {
            get { return _tasks; }
            set
            {
                _tasks = value;
                OnPropertyChanged();
                ApplyFilters();
            }
        }

        public ObservableCollection<TaskItem> FilteredTasks
        {
            get { return _filteredTasks; }
            set
            {
                _filteredTasks = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<string> Categories { get; set; } = new ObservableCollection<string>
        {
            "Allgemein", "Arbeit", "Privat", "Studium", "Hobby"
        };

        public ObservableCollection<string> FilterCategories { get; set; } = new ObservableCollection<string>
        {
            "Alle", "Allgemein", "Arbeit", "Privat", "Studium", "Hobby"
        };

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

        public string NewTaskCategory
        {
            get { return _newTaskCategory; }
            set
            {
                _newTaskCategory = value;
                OnPropertyChanged();
            }
        }

        public int NewTaskPriority
        {
            get { return _newTaskPriority; }
            set
            {
                _newTaskPriority = value;
                OnPropertyChanged();
            }
        }

        public string SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                _selectedCategory = value;
                OnPropertyChanged();
                ApplyFilters();
            }
        }

        public bool ShowCompletedTasks
        {
            get { return _showCompletedTasks; }
            set
            {
                _showCompletedTasks = value;
                OnPropertyChanged();
                ApplyFilters();
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
                    Description = NewTaskDescription,
                    Category = NewTaskCategory,
                    Priority = NewTaskPriority
                };

                _taskRepository.AddTask(newTask);
                LoadTasks();

                // Clear input fields
                NewTaskTitle = string.Empty;
                NewTaskDescription = string.Empty;
                NewTaskCategory = "Allgemein";
                NewTaskPriority = 1;
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

        private void ApplyFilters()
        {
            var filtered = Tasks.AsEnumerable();

            // Filter by category
            if (SelectedCategory != "Alle")
            {
                filtered = filtered.Where(t => t.Category == SelectedCategory);
            }

            // Filter by completion status
            if (!ShowCompletedTasks)
            {
                filtered = filtered.Where(t => !t.IsCompleted);
            }

            // Sort by priority (high to low) and creation date
            filtered = filtered.OrderByDescending(t => t.Priority).ThenBy(t => t.CreatedAt);

            FilteredTasks = new ObservableCollection<TaskItem>(filtered);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
