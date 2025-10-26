using TaskTrackerCLI.Enum;

namespace TaskTrackerCLI.Models;

public class TaskModel(int id, string description)
{
    public int Id { get; } = id;
    public string Description { get; set; } = description;
    public Status Status { get; set; } = Status.ToDo;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}

