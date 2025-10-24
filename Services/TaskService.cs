using TaskTrackerCLI.Enum;
using TaskTrackerCLI.Models;

namespace TaskTrackerCLI.Services;

public class TaskService
{
    private readonly List<TaskModel> _tasks;
    private readonly StorageService _storageService;
    private readonly Utils.Utils _utils;

    public TaskService()
    {
        _utils = new Utils.Utils();
        _storageService = new StorageService();
        _tasks = _storageService.Load();
    }

    public void CreateTask(string description)
    {
        int nextId = _tasks.Count != 0 ? _tasks.Max(t => t.Id) + 1 : 1;
        
        TaskModel newTask = new TaskModel(nextId, description);
        _tasks.Add(newTask);
        SaveChanges();
        _utils.FontColor(ConsoleColor.Green, $"La tarea '{description}' se ha creado. Id: {newTask.Id}. {_utils.GoodEmoji} \n");
    }

    public void UpdateTask(int id, string newDescription)
    {
        TaskModel? task = _tasks.FirstOrDefault(t => t.Id == id);

        if (task == null)
        {
            _utils.FontColor(ConsoleColor.Cyan, $"No se ha encontrado la tarea. {_utils.EmptyEmoji}\n");
            return;
        }
        string oldDescription = task.Description;
        task.Description = newDescription;
        task.UpdatedAt = DateTime.Now;
        SaveChanges();
        _utils.FontColor(ConsoleColor.Green, $"La tarea '{oldDescription}' se ha actualizado a '{newDescription}'. {_utils.GoodEmoji}\n");
    }

    public void DeleteTask(int id)
    {
        TaskModel? task = _tasks.FirstOrDefault(t => t.Id == id);

        if (task == null)
        {
            _utils.FontColor(ConsoleColor.Cyan, $"No se ha encontrado la tarea. {_utils.EmptyEmoji}\n");
            return;
        }
        string description = task.Description;
        _tasks.Remove(task);
        SaveChanges();
        _utils.FontColor(ConsoleColor.Green, $"La tarea '{description}' ha sido eliminada. {_utils.GoodEmoji}\n");
    }

    public void MarkTaskAsInProgress(int id)
    {
        TaskModel? task = _tasks.FirstOrDefault(t => t.Id == id);
        if (task == null)
        {
            _utils.FontColor(ConsoleColor.Cyan, $"No se ha encontrado la tarea. {_utils.EmptyEmoji}\n");
            return;
        }
        string description = task.Description;
        task.Status = Status.EnProgreso;
        task.UpdatedAt = DateTime.Now;
        SaveChanges();
        _utils.FontColor(ConsoleColor.Green, $"La tarea '{description}' se ha marcado como 'En Progreso'{_utils.InprogressEmoji}\n");
    }
    
    public void MarkTaskAsCompleted(int id)
    {
        TaskModel? task = _tasks.FirstOrDefault(t => t.Id == id);
        if (task == null)
        {
            _utils.FontColor(ConsoleColor.Cyan, $"No se ha encontrado la tarea. {_utils.EmptyEmoji}\n");
            return;
        }
        string description = task.Description;
        task.Status = Status.Completada;
        task.UpdatedAt = DateTime.Now;
        SaveChanges();
        _utils.FontColor(ConsoleColor.Green, $"La tarea '{description}' se ha marcado como 'Completada'{_utils.DoneEmoji}\n");
    }

    public void ListTasks()
    {
        if (_tasks.Count == 0)
        {
            _utils.FontColor(ConsoleColor.Cyan, $"No se ha encontrado ninguna tarea. {_utils.EmptyEmoji}\n");
            return;
        }
        _utils.PrintTable(_tasks);
    }

    public void ListInProgressTasks()
    {
        var inProgressTasks = _tasks.Where(t => t.Status == Status.EnProgreso).ToList();
        if (inProgressTasks.Count == 0)
        {
            _utils.FontColor(ConsoleColor.Cyan, $"No se ha encontrado ninguna tarea. {_utils.EmptyEmoji}\n");
            return;
        }
        _utils.PrintTable(inProgressTasks);
    }
    
    public void ListCompletedTasks()
    {
        var completedTasks = _tasks.Where(t => t.Status == Status.Completada).ToList();
        if (completedTasks.Count == 0)
        {
            _utils.FontColor(ConsoleColor.Cyan, $"No se ha encontrado ninguna tarea. {_utils.EmptyEmoji}\n");
            return;
        }
        _utils.PrintTable(completedTasks);
    }

    private void SaveChanges()
    {
        _storageService.Save(_tasks);
    }
}