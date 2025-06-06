using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TaskManager.Models;
using TaskManager.ViewModels;

namespace TaskManager
{
    public partial class MainWindow : Window
    {
        private MainViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();

            _viewModel = new MainViewModel();
            DataContext = _viewModel;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.AddTask();
        }

        private void TitleTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            // Enter-Taste zum Hinzufügen von Aufgaben
            if (e.Key == Key.Enter)
            {
                _viewModel.AddTask();
                e.Handled = true;
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is FrameworkElement element && element.Tag is TaskItem task)
            {
                var result = MessageBox.Show(
                    $"Möchtest du die Aufgabe '{task.Title}' wirklich löschen?",
                    "Aufgabe löschen",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    _viewModel.DeleteTask(task);
                }
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (sender is FrameworkElement element && element.Tag is TaskItem task)
            {
                _viewModel.ToggleTaskCompletion(task);
            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            if (sender is FrameworkElement element && element.Tag is TaskItem task)
            {
                _viewModel.ToggleTaskCompletion(task);
            }
        }
    }
}
