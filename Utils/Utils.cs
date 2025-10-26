using TaskTrackerCLI.Enum;
using TaskTrackerCLI.Models;

namespace TaskTrackerCLI.Utils;

public class Utils
{
    public const string GoodEmoji = "(๑╹ᵕ╹๑)⸝*";
    public const string HelpEmoji = "ദ്ദി(˵ •̀ᴗ- ˵) ✧";
    public const string ErrorEmoji = "( ꩜ ᯅ ꩜;)";
    public const string InprogressEmoji = "ദ്ദി(ᗜˬᗜ)";
    public const string DoneEmoji = "✧｡٩(ˊᗜˋ )و✧*｡";
    public const string EmptyEmoji = "( ╹ -╹)?";


    public void PrintTable(List<TaskModel> tasks, bool language)
    {
        var maxDescLength = tasks.Max(t => t.Description.Length);
        maxDescLength = Math.Max(maxDescLength + 2, 13);

        string header;
        if(language) header = string.Format(
            "{0,-5} {1,-" + maxDescLength + "} {2,-12} {3,-23} {4,-23}",
            "ID", "Descripción", "Estado", "Creado", "Actualizado"
        );
        else header = string.Format(
            "{0,-5} {1,-" + maxDescLength + "} {2,-12} {3,-23} {4,-23}",
            "ID", "Description", "Status", "CreatedAt", "UpdatedAt"
        );
        FontColor(ConsoleColor.Blue, "\n" + header + "\n");
        FontColor(ConsoleColor.Blue, new string('-', header.Length));
        
        foreach (var task in tasks)
        {
            var id = task.Id;
            var description = task.Description;
            var status = task.Status;
            var createdAt = task.CreatedAt;
            var updatedAt = task.UpdatedAt;
            string statusString;

            if(language)
                if (status == Status.ToDo)
                {
                    statusString = "Por Hacer";
                }
                else if (status == Status.InProgress)
                {
                    statusString = "En Progreso";
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else
                {
                    statusString = "Completada";
                    Console.ForegroundColor = ConsoleColor.Green;
                }
            else
            {
                if (status == Status.ToDo)
                {
                    statusString = "To Do";
                }
                else if (status == Status.InProgress)
                {
                    statusString = "In Progress";
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else
                {
                    statusString = "Completed";
                    Console.ForegroundColor = ConsoleColor.Green;
                }
            }
            
            Console.WriteLine("{0,-5} {1,-" + maxDescLength + "} {2,-12} {3,-20} {4,-20}", id, description, statusString, createdAt.ToString("g"), updatedAt.ToString("g"));
            Console.ResetColor();
            FontColor(ConsoleColor.Blue, new string('-', header.Length));
            Console.WriteLine();
        }
    }

    public void FontColor(ConsoleColor color, string text)
    {
        Console.ForegroundColor = color;
        Console.Write(text);
        Console.ResetColor();
    }

    public void BackColor(ConsoleColor color, string text)
    {
        Console.BackgroundColor = color;
        Console.Write(text);
        Console.ResetColor();
    }
}