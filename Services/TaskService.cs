using TaskTrackerCLI.Enum;
using TaskTrackerCLI.Models;

namespace TaskTrackerCLI.Services;

public class TaskService
{
    private readonly List<TaskModel> _tasks;
    private readonly StorageService _storageService;
    private readonly Utils.Utils _utils;
    private readonly Utils.LanguageUtils _langUtils;

    public TaskService(string languageInput)
    {
        _utils = new Utils.Utils();
        _storageService = new StorageService();
        _tasks = _storageService.Load();
        _langUtils =  new Utils.LanguageUtils(languageInput);
    }

    public void CreateTask(string description)
    {
        int nextId = _tasks.Count != 0 ? _tasks.Max(t => t.Id) + 1 : 1;
        
        TaskModel newTask = new TaskModel(nextId, description);
        _tasks.Add(newTask);
        SaveChanges();
        _langUtils.CreatedTaskMessage(description, newTask.Id);
        Console.ResetColor();
    }

    public void UpdateTask(int id, string newDescription)
    {
        TaskModel? task = _tasks.FirstOrDefault(t => t.Id == id);

        if (task == null)
        {
            _langUtils.NoTaskMessage();
            Console.ResetColor();
            return;
        }
        string oldDescription = task.Description;
        task.Description = newDescription;
        task.UpdatedAt = DateTime.Now;
        SaveChanges();
        _langUtils.UpdatedTaskMessage(oldDescription, newDescription);
        Console.ResetColor();
    }

    public void DeleteTask(int id)
    {
        TaskModel? task = _tasks.FirstOrDefault(t => t.Id == id);

        if (task == null)
        {
            _langUtils.NoTaskMessage();
            Console.ResetColor();
            return;
        }
        string description = task.Description;
        _tasks.Remove(task);
        SaveChanges();
        _langUtils.DeletedTaskMessage(description);
        Console.ResetColor();
    }

    public void MarkTaskAsInProgress(int id)
    {
        TaskModel? task = _tasks.FirstOrDefault(t => t.Id == id);
        if (task == null)
        {
            _langUtils.NoTaskMessage();
            Console.ResetColor();
            return;
        }
        string description = task.Description;
        task.Status = Status.InProgress;
        task.UpdatedAt = DateTime.Now;
        SaveChanges();
        _langUtils.MarkedTaskMessage(description, task.Status);
        Console.ResetColor();
    }
    
    public void MarkTaskAsCompleted(int id)
    {
        TaskModel? task = _tasks.FirstOrDefault(t => t.Id == id);
        if (task == null)
        {
            _langUtils.NoTaskMessage();
            Console.ResetColor();
            return;
        }
        string description = task.Description;
        task.Status = Status.Completed;
        task.UpdatedAt = DateTime.Now;
        SaveChanges();
        _langUtils.MarkedTaskMessage(description, task.Status);
        Console.ResetColor();
    }

    public void ListTasks()
    {
        if (_tasks.Count == 0)
        {
            _langUtils.NoTasksMessage();
            Console.ResetColor();
            return;
        }
        _utils.PrintTable(_tasks, _langUtils.Language);
    }
    
    public void ListToDoTasks()
    {
        var toDoTasks = _tasks.Where(t => t.Status == Status.ToDo).ToList();
        if (toDoTasks.Count == 0)
        {
            _langUtils.NoTasksMessage();
            Console.ResetColor();
            return;
        }
        _utils.PrintTable(toDoTasks, _langUtils.Language);
    }

    public void ListInProgressTasks()
    {
        var inProgressTasks = _tasks.Where(t => t.Status == Status.InProgress).ToList();
        if (inProgressTasks.Count == 0)
        {
            _langUtils.NoTasksMessage();
            Console.ResetColor();
            return;
        }
        _utils.PrintTable(inProgressTasks, _langUtils.Language);
    }
    
    public void ListCompletedTasks()
    {
        var completedTasks = _tasks.Where(t => t.Status == Status.Completed).ToList();
        if (completedTasks.Count == 0)
        {
            _langUtils.NoTasksMessage();
            Console.ResetColor();
            return;
        }
        _utils.PrintTable(completedTasks, _langUtils.Language);
    }

    private void SaveChanges()
    {
        _storageService.Save(_tasks);
    }
}