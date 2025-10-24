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


    public void PrintTable(List<TaskModel> tasks)
    {
        var maxDescLength = tasks.Max(t => t.Description.Length);
        maxDescLength = Math.Max(maxDescLength, "Descripción".Length);

        // 2️⃣ Encabezado
        var header = string.Format(
            "{0,-5} {1,-" + maxDescLength + "} {2,-12} {3,-20} {4,-20}",
            "ID", "Descripción", "Estado", "Creado", "Actualizado"
        );
        FontColor(ConsoleColor.Blue, "\n" + header + "\n");
        
        
        foreach (var task in tasks)
        {
            var id = task.Id;
            var description = task.Description;
            var status = task.Status;
            var createdAt = task.CreatedAt;
            var updatedAt = task.UpdatedAt;
            string statusString;

            if (status == Status.PorHacer)
            {
                statusString = "Por Hacer";
            }
            else if (status == Status.EnProgreso)
            {
                statusString = "En Progreso";
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                statusString = "Completada";
                Console.ForegroundColor = ConsoleColor.Green;
            }
            
            Console.WriteLine("{0,-5} {1,-" + maxDescLength + "} {2,-12} {3,-20} {4,-20}", id, description, statusString, createdAt.ToString("g"), updatedAt.ToString("g"));
            Console.ResetColor();
            FontColor(ConsoleColor.Blue, new string('-', header.Length)+"\n");
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