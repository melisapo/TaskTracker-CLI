using System.Text.Json;
using TaskTrackerCLI.Models;

namespace TaskTrackerCLI.Services;

public class StorageService
{
    private readonly string _dataFilePath;

    public StorageService()
    {
        var projectRoot = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));
        var dataDir = Path.Combine(projectRoot, "Data");

        if (!Directory.Exists(dataDir))
            Directory.CreateDirectory(dataDir);

        _dataFilePath = Path.Combine(dataDir, "data.json");
    }

    public List<TaskModel> Load()
    {
        if (!File.Exists(_dataFilePath))
            return new List<TaskModel>();

        string json = File.ReadAllText(_dataFilePath);

        
        if (string.IsNullOrWhiteSpace(json))
            return new List<TaskModel>();

        try
        {
            return JsonSerializer.Deserialize<List<TaskModel>>(json) ?? new List<TaskModel>();
        }
        catch (JsonException)
        {

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("El archivo data.json está dañado o no tiene formato válido. Se reiniciará. ദ്ദി(ᗜˬᗜ)");
            Console.ResetColor();
            return new List<TaskModel>();
        }
    }

    public void Save(List<TaskModel>? tasks)
    {
        string json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_dataFilePath, json);
    }
}