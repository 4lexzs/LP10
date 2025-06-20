using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using TaskManager.Models;

namespace TaskManager.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _newTaskTitle = string.Empty;
        private string _newTaskDescription = string.Empty;
        private string _newTaskCategory = "Allgemein";
        private int _newTaskPriority = 1;
        private DateTime? _newTaskDueDate;
        private string _searchText = string.Empty;
        private string _selectedCategory = "Alle";
        private bool _showCompletedTasks = false;

        public MainViewModel()
        {
            Tasks = new ObservableCollection<TaskItem>();
            FilteredTasks = new ObservableCollection<TaskItem>();
            Categories = new ObservableCollection<string> { "Allgemein", "Arbeit", "Privat", "Shopping", "Lernen" };
            FilterCategories = new ObservableCollection<string> { "Alle", "Allgemein", "Arbeit", "Privat", "Shopping", "Lernen" };

            // Sample data für Demo
            AddSampleData();
        }

        // Collections
        public ObservableCollection<TaskItem> Tasks { get; }
        public ObservableCollection<TaskItem> FilteredTasks { get; }
        public ObservableCollection<string> Categories { get; }
        public ObservableCollection<string> FilterCategories { get; }

        // Statistik Properties
        public int TotalTasks => Tasks.Count;
        public int CompletedTasks => Tasks.Count(t => t.IsCompleted);
        public int PendingTasks => Tasks.Count(t => !t.IsCompleted);
        public int OverdueTasks => Tasks.Count(t => t.IsOverdue);
        public string ProgressText => $"{CompletedTasks} von {TotalTasks} erledigt";

        // Properties für neue Aufgabe
        public string NewTaskTitle
        {
            get => _newTaskTitle;
            set => SetProperty(ref _newTaskTitle, value);
        }

        public string NewTaskDescription
        {
            get => _newTaskDescription;
            set => SetProperty(ref _newTaskDescription, value);
        }

        public string NewTaskCategory
        {
            get => _newTaskCategory;
            set => SetProperty(ref _newTaskCategory, value);
        }

        public int NewTaskPriority
        {
            get => _newTaskPriority;
            set => SetProperty(ref _newTaskPriority, value);
        }

        public DateTime? NewTaskDueDate
        {
            get => _newTaskDueDate;
            set => SetProperty(ref _newTaskDueDate, value);
        }

        // Filter Properties
        public string SearchText
        {
            get => _searchText;
            set
            {
                if (SetProperty(ref _searchText, value))
                {
                    FilterTasks();
                }
            }
        }

        public string SelectedCategory
        {
            get => _selectedCategory;
            set
            {
                if (SetProperty(ref _selectedCategory, value))
                {
                    FilterTasks();
                }
            }
        }

        public bool ShowCompletedTasks
        {
            get => _showCompletedTasks;
            set
            {
                if (SetProperty(ref _showCompletedTasks, value))
                {
                    FilterTasks();
                }
            }
        }

        // Methods
        public void AddTask()
        {
            if (string.IsNullOrWhiteSpace(NewTaskTitle))
            {
                MessageBox.Show("Bitte geben Sie einen Titel für die Aufgabe ein.",
                              "Fehler", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var newTask = new TaskItem
            {
                Id = Tasks.Count > 0 ? Tasks.Max(t => t.Id) + 1 : 1,
                Title = NewTaskTitle.Trim(),
                Description = NewTaskDescription?.Trim() ?? string.Empty,
                Category = NewTaskCategory ?? "Allgemein",
                Priority = NewTaskPriority,
                DueDate = NewTaskDueDate,
                CreatedAt = DateTime.Now,
                IsCompleted = false
            };

            Tasks.Add(newTask);

            // Felder zurücksetzen
            NewTaskTitle = string.Empty;
            NewTaskDescription = string.Empty;
            NewTaskCategory = "Allgemein";
            NewTaskPriority = 1;
            NewTaskDueDate = null;

            FilterTasks();
            UpdateStatistics();
        }

        public void DeleteTask(TaskItem task)
        {
            if (task != null)
            {
                Tasks.Remove(task);
                FilterTasks();
                UpdateStatistics();
            }
        }

        public void ToggleTaskCompletion(TaskItem task)
        {
            if (task != null)
            {
                task.IsCompleted = !task.IsCompleted;
                FilterTasks();
                UpdateStatistics();
            }
        }

        private void FilterTasks()
        {
            var filteredTasks = Tasks.AsEnumerable();

            // Filter nach Kategorie
            if (!string.IsNullOrEmpty(SelectedCategory) && SelectedCategory != "Alle")
            {
                filteredTasks = filteredTasks.Where(t => t.Category == SelectedCategory);
            }

            // Filter nach Suchtext
            if (!string.IsNullOrWhiteSpace(SearchText))
            {
                var searchLower = SearchText.ToLower();
                filteredTasks = filteredTasks.Where(t =>
                    t.Title.ToLower().Contains(searchLower) ||
                    (t.Description?.ToLower().Contains(searchLower) ?? false));
            }

            // Filter nach erledigten Aufgaben
            if (!ShowCompletedTasks)
            {
                filteredTasks = filteredTasks.Where(t => !t.IsCompleted);
            }

            FilteredTasks.Clear();
            foreach (var task in filteredTasks.OrderByDescending(t => t.CreatedAt))
            {
                FilteredTasks.Add(task);
            }
        }

        private void UpdateStatistics()
        {
            OnPropertyChanged(nameof(TotalTasks));
            OnPropertyChanged(nameof(CompletedTasks));
            OnPropertyChanged(nameof(PendingTasks));
            OnPropertyChanged(nameof(OverdueTasks));
            OnPropertyChanged(nameof(ProgressText));
        }

        private void AddSampleData()
        {
            // Demo-Daten für Präsentation
            Tasks.Add(new TaskItem
            {
                Id = 1,
                Title = "Willkommen bei TaskManager! 👋",
                Description = "Dies ist eine Demo-Aufgabe. Sie können sie bearbeiten oder löschen.",
                Category = "Allgemein",
                Priority = 1,
                CreatedAt = DateTime.Now.AddDays(-2),
                IsCompleted = false
            });

            Tasks.Add(new TaskItem
            {
                Id = 2,
                Title = "LP10 Präsentation vorbereiten",
                Description = "Demo erstellen und Präsentation üben",
                Category = "Arbeit",
                Priority = 3,
                DueDate = DateTime.Today.AddDays(1),
                CreatedAt = DateTime.Now.AddDays(-1),
                IsCompleted = false
            });

            Tasks.Add(new TaskItem
            {
                Id = 3,
                Title = "Code auf GitHub hochladen",
                Description = "Finalen Code committen und pushen",
                Category = "Arbeit",
                Priority = 2,
                CreatedAt = DateTime.Now.AddHours(-3),
                IsCompleted = true
            });

            FilterTasks();
            UpdateStatistics();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
