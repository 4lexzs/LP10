# Lern-Periode 10

25.4 bis 27.6

## Grob-Planung

1. Welche Programmiersprache möchten Sie verwenden? Was denken Sie, wo Ihre Zeit und Übung am sinnvollsten ist?
  Ich will mit C# programmieren, weil ich diese Sprache besser lernen möchte.
1. Welche Datenbank-Technologie möchten Sie üben? Fühlen Sie sich sicher mit SQL und möchten etwas Neues ausprobieren; oder möchten Sie sich weiter mit SQL beschäftigen?
   Bei Datenbanken will ich SQL weiter üben und mit Entity Framework arbeiten, um Daten in meiner App zu speichern.
1. Was wäre ein geeignetes Abschluss-Projekt?
   Als Projekt möchte ich eine Aufgaben-App bauen, mit der man To-Do-Listen erstellen und verwalten kann.

## 25.4

Welche 3 *features* sind die wichtigsten Ihres Projektes? Wie können Sie die Machbarkeit dieser in jeweils 45' am einfachsten beweisen?

- [X] *make or break feature* 1: Aufgaben erstellen, anzeigen, ändern und löschen können
- [X] *make or break feature* 2: Aufgaben in einer Datenbank speichern
- [X] *make or break feature* 3: Eine einfache Benutzeroberfläche mit Buttons und Feldern


Heute habe ich mein Projekt geplant und überlegt, was es können soll. Ich habe ein kleines Testprogramm in der Konsole gebaut, das zeigt, wie man Aufgaben erstellen, anzeigen, ändern und löschen kann. Das Programm ist noch sehr einfach, aber es beweist, dass ich die Grundfunktionen bauen kann. Ich habe eine Klasse für Aufgaben erstellt mit Eigenschaften wie Titel, Beschreibung und Status.

☝️ Vergessen Sie nicht, den Code von heute auf github hochzuladen. Ggf. bietet es sich an, für die Code-Schnipsel einen eigenen Ordner `exploration` zu erstellen.

## 2.5

Ausgehend von Ihren Erfahrungen vom 25.4, welche *features* brauchen noch mehr Recherche? (Sie können auch mehrere AP für ein *feature* aufwenden.)

- [X] lernen, wie ich meine App mit einer Datenbank verbinde.
- [X] lernen, wie ich Fenster mit Buttons und Textfeldern erstelle.
- [X] lernen, wie ich meinen Code sauber organisiere.
- [X] App-Oberfläche 

Heute habe ich recherchiert, wie ich Entity Framework Core benutze. Ich habe die nötigen Pakete installiert und ein einfaches Datenbank-Modell für meine Aufgaben-App erstellt. Ich habe gelernt, wie man Daten definiert, eine Datenbank-Verbindung aufbaut und wie man Daten speichert und abruft. Ausserdem habe ich erste Skizzen meiner App auf Papier gezeichnet, um ein besseres Gefühl für das Layout und die Benutzerführung zu bekommen.

## 9.5

Planen Sie nun Ihr Projekt, sodass die *Kern-Funktionalität* in 3 Sitzungen realisiert ist. Schreiben Sie dazu zunächst 3 solche übergeordneten Kern-Funktionalitäten auf:

1. Datenbank-Anbindung mit Entity Framework Core
2. CRUD-Funktionalität (Erstellen, Lesen, Aktualisieren, Löschen von Aufgaben)
3. Benutzeroberfläche mit WPF und MVVM-Muster

Diese Kern-Funktionalitäten breche ich nun in etwa 4 AP je herunter:

- [X] Erstellen des TaskDbContext und Konfiguration der Datenbankverbindung
- [X] Design der TaskService-Klasse mit grundlegenden CRUD-Methoden
- [X] Einrichten der Datenbankmigrationen und Testen der Datenbankfunktionalität
- [X] Implementieren des Repositories für die Trennung von Datenzugriff und Geschäftslogik

Heute habe ich an der Datenbank-Anbindung gearbeitet. Ich habe den TaskDbContext erweitert und erste CRUD-Operationen im TaskService implementiert. Ausserdem habe ich begonnen, das Repository-Muster umzusetzen, indem ich ein Interface (ITaskRepository) und dessen Implementierung (TaskRepository) erstellt habe. Diese Struktur wird mir helfen, die Datenzugriffsschicht sauber von der Geschäftslogik zu trennen. Meine App kann jetzt theoretisch Aufgaben in der Datenbank speichern und wieder abrufen.

## 16.5

- [X] Erstellen eines MainViewModel und Implementierung der MVVM-Struktur
- [X] Erstellen der MainWindow.xaml mit grundlegenden UI-Elementen
- [X] Implementierung der Datenbindung zwischen ViewModel und View
- [X] Implementierung der Benutzerinteraktionen (Buttons, Eingabefelder, etc.)

Heute habe ich die Benutzeroberfläche meiner Aufgaben-App erstellt und die MVVM-Architektur implementiert. Ich habe ein MainViewModel entwickelt, das die Geschäftslogik von der UI trennt, und eine WPF-Oberfläche mit Eingabefeldern, einer Liste für Aufgaben und Buttons für Interaktionen gebaut. Die Datenbindung funktioniert gut und ich kann jetzt Aufgaben hinzufügen, anzeigen, als erledigt markieren und löschen. Meine App hat jetzt eine vollständige grafische Benutzeroberfläche.

## 23.5

- [x] Hinzufügen von Kategorien für Aufgaben
- [x] Implementieren von Filteroptionen nach Status und Kategorie
- [x] Hinzufügen von Prioritätsstufen für Aufgaben
- [x] Verbessern des Designs und der Benutzerfreundlichkeit

Heute habe ich die Funktionalität meiner Aufgaben-App deutlich erweitert. Ich habe Kategorien und Prioritätsstufen für Aufgaben hinzugefügt, damit Benutzer ihre Aufgaben besser organisieren können. Ausserdem habe ich Filter implementiert, mit denen man Aufgaben nach Kategorie filtern und erledigte Aufgaben ein-/ausblenden kann. Das Design wurde verbessert mit farbcodierten Prioritäten und einer übersichtlicheren Darstellung. Die App ist jetzt viel nützlicher für die tägliche Aufgabenverwaltung.

## 6.6

Ihr Projekt sollte nun alle Funktionalität haben, dass man es benutzen kann. Allerdings gibt es sicher noch Teile, welche "schöner" werden können: Layout, Code, Architektur... beschreiben Sie kurz den Stand Ihres Projekts, und leiten Sie daraus 6 solche "kosmetischen" AP für den 6.6 und den 13.6 ab.

**Stand meines Projekts:**
Meine Aufgaben-App funktioniert bereits vollständig. Benutzer können Aufgaben erstellen, bearbeiten, löschen und als erledigt markieren. Die App hat Kategorien, Prioritätsstufen und Filterfunktionen. Die Daten werden in einer SQLite-Datenbank gespeichert und die App folgt dem MVVM-Muster. Allerdings gibt es noch Verbesserungsmöglichkeiten beim Design, der Benutzerfreundlichkeit und der Code-Qualität.

- [X] Verbesserung des UI-Designs mit modernen Farben und besseren Layouts
- [X] Hinzufügen einer Suchfunktion für Aufgaben nach Titel und Beschreibung
- [X] Implementierung von Fälligkeitsdaten für Aufgaben mit Erinnerungen
- [X] Code-Bereinigung und Optimierung der Performance
- [X] Hinzufügen von Keyboard-Shortcuts (Enter zum Hinzufügen, Delete zum Löschen)
- [X] Verbesserung der Benutzerfreundlichkeit mit besseren Tooltips und Feedback

Heute habe ich das UI-Design meiner App deutlich verbessert. Ich habe modernere Farben eingesetzt, die Layouts optimiert und die Benutzeroberfläche benutzerfreundlicher gestaltet. Ausserdem habe ich Keyboard-Shortcuts implementiert - jetzt kann man mit Enter neue Aufgaben hinzufügen und mit Delete markierte Aufgaben löschen. Die Code-Struktur wurde bereinigt und Performance-Optimierungen vorgenommen. Tooltips und besseres visuelles Feedback machen die App jetzt professioneller und einfacher zu bedienen.

☝️  Vergessen Sie nicht, den Code von heute auf github hochzuladen.

## 13.6

- [X] Suchfunktion implementiert
- [X] Fälligkeitsdaten hinzugefügt


Heute habe ich die Suchfunktion fertig implementiert, sodass man Aufgaben nach Titel und Beschreibung filtern kann. Ausserdem habe ich Fälligkeitsdaten für Aufgaben hinzugefügt - überfällige Aufgaben werden automatisch rot hervorgehoben. Die App ist jetzt deutlich nützlicher für die tägliche Aufgabenverwaltung. Der Code wurde auf GitHub hochgeladen und die Datenbankstruktur entsprechend erweitert.
## 20.6

Was fehlt Ihrem fertigen Projekt noch, um es auszuliefern? Reicht die Zeit für ein *nice-to-have feature*?

- [X] Projekt dokumentieren und Screenshots erstellen für GitHub
- [X] Code-Kommentare und Dokumentation vervollständigen
- [X] Finale Tests und Bug-Fixes
- [X] Nice-to-have: Statistiken-Dashboard für Aufgaben

Bereiten Sie in den verbleibenden 2 AP Ihre Präsentation vor

- [X] Materialien der Präsentation vorbereiten (Demo, Screenshots, Code-Beispiele)
- [X] Präsentation üben und Struktur festlegen

✍️ Heute habe ich mein TaskManager-Projekt erfolgreich abgeschlossen, indem ich ein Live-Statistiken Dashboard hinzugefügt und die GitHub-Dokumentation finalisiert habe. Außerdem habe ich meine Präsentation strukturiert und Demo-Daten vorbereitet. Das Projekt ist nun vollständig auslieferungsbereit mit allen Features und bereit für die finale Präsentation am 27.6.

☝️ Vergessen Sie nicht, die Unterlagen für Ihre Präsentation auf github hochzuladen.

## 27.6
