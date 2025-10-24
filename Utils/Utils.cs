using TaskTrackerCLI.Enum;
using TaskTrackerCLI.Models;

namespace TaskTrackerCLI.Utils;

public class Utils
{
    public string GoodEmoji { get; }= "(๑╹ᵕ╹๑)⸝*";
    public string HelpEmoji { get; } = "ദ്ദി(˵ •̀ᴗ- ˵) ✧";
    public string ErrorEmoji { get; } = "( ꩜ ᯅ ꩜;)";
    public string InprogressEmoji { get; } = "ദ്ദി(ᗜˬᗜ)";
    public string DoneEmoji { get; } = "✧｡٩(ˊᗜˋ )و✧*｡";
    public string EmptyEmoji { get; } = "( ╹ -╹)?";


    public void PrintTable(List<TaskModel> tasks)
    {
        int maxDescLength = tasks.Max(t => t.Description.Length);
        maxDescLength = Math.Max(maxDescLength, "Descripción".Length);

        // 2️⃣ Encabezado
        string header = string.Format(
            "{0,-5} {1,-" + maxDescLength + "} {2,-12} {3,-20} {4,-20}",
            "ID", "Descripción", "Estado", "Creado", "Actualizado"
        );
        FontColor(ConsoleColor.Blue, "\n" + header + "\n");
        
        
        foreach (var task in tasks)
        {
            int id = task.Id;
            string description = task.Description;
            Status status = task.Status;
            DateTime createdAt = task.CreatedAt;
            DateTime updatedAt = task.UpdatedAt;
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
            
            Console.WriteLine(string.Format(
                        "{0,-5} {1,-" + maxDescLength + "} {2,-12} {3,-20} {4,-20}",
                        id, description, statusString, createdAt.ToString("g"), updatedAt.ToString("g")
                        ));
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