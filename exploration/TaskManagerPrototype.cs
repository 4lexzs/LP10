using System;
using System.Collections.Generic;

namespace TaskManagerPrototype
{
    // Einfache Klasse für eine Aufgabe
    class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        
        public Task(int id, string title, string description)
        {
            Id = id;
            Title = title;
            Description = description;
            IsCompleted = false;
        }
        
        public override string ToString()
        {
            return $"[{(IsCompleted ? "X" : " ")}] {Id}: {Title} - {Description}";
        }
    }
    
    // Hauptprogramm zum Testen der CRUD-Operationen
    class Program
    {
        static List<Task> tasks = new List<Task>();
        static int nextId = 1;
        
        static void Main(string[] args)
        {
            Console.WriteLine("=== Aufgabenverwaltung Prototyp ===");
            bool running = true;
            
            while (running)
            {
                Console.WriteLine("\nWähle eine Option:");
                Console.WriteLine("1: Aufgabe hinzufügen");
                Console.WriteLine("2: Alle Aufgaben anzeigen");
                Console.WriteLine("3: Aufgabe bearbeiten");
                Console.WriteLine("4: Aufgabe löschen");
                Console.WriteLine("5: Programm beenden");
                
                string input = Console.ReadLine();
                
                switch (input)
                {
                    case "1":
                        AddTask();
                        break;
                    case "2":
                        ShowAllTasks();
                        break;
                    case "3":
                        EditTask();
                        break;
                    case "4":
                        DeleteTask();
                        break;
                    case "5":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Ungültige Eingabe!");
                        break;
                }
            }
            
            Console.WriteLine("Programm beendet.");
        }
        
        static void AddTask()
        {
            Console.WriteLine("Titel der Aufgabe:");
            string title = Console.ReadLine();
            
            Console.WriteLine("Beschreibung der Aufgabe:");
            string description = Console.ReadLine();
            
            Task newTask = new Task(nextId, title, description);
            tasks.Add(newTask);
            nextId++;
            
            Console.WriteLine("Aufgabe hinzugefügt!");
        }
        
        static void ShowAllTasks()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("Keine Aufgaben vorhanden.");
                return;
            }
            
            Console.WriteLine("Aufgabenliste:");
            foreach (Task task in tasks)
            {
                Console.WriteLine(task);
            }
        }
        
        static void EditTask()
        {
            ShowAllTasks();
            
            if (tasks.Count == 0)
                return;
                
            Console.WriteLine("ID der zu bearbeitenden Aufgabe eingeben:");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Ungültige ID!");
                return;
            }
            
            Task taskToEdit = tasks.Find(t => t.Id == id);
            if (taskToEdit == null)
            {
                Console.WriteLine("Aufgabe nicht gefunden!");
                return;
            }
            
            Console.WriteLine("Neuer Titel (leer lassen für unverändert):");
            string newTitle = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newTitle))
                taskToEdit.Title = newTitle;
                
            Console.WriteLine("Neue Beschreibung (leer lassen für unverändert):");
            string newDescription = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newDescription))
                taskToEdit.Description = newDescription;
                
            Console.WriteLine("Status ändern? (j/n)");
            if (Console.ReadLine().ToLower() == "j")
                taskToEdit.IsCompleted = !taskToEdit.IsCompleted;
                
            Console.WriteLine("Aufgabe aktualisiert!");
        }
        
        static void DeleteTask()
        {
            ShowAllTasks();
            
            if (tasks.Count == 0)
                return;
                
            Console.WriteLine("ID der zu löschenden Aufgabe eingeben:");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Ungültige ID!");
                return;
            }
            
            Task taskToDelete = tasks.Find(t => t.Id == id);
            if (taskToDelete == null)
            {
                Console.WriteLine("Aufgabe nicht gefunden!");
                return;
            }
            
            tasks.Remove(taskToDelete);
            Console.WriteLine("Aufgabe gelöscht!");
        }
    }
}
