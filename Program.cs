using TaskTrackerCLI.Commands;

namespace TaskTrackerCLI;

class Program
{
    static void Main()
    {
        Utils.Utils utils = new Utils.Utils();
        utils.BackColor(ConsoleColor.DarkMagenta, "𑣲 Hola! Bienvenido a TaskTracker! (๑╹ᵕ╹๑)⸝* \n");
        utils.FontColor(ConsoleColor.Magenta, "ʚ Escribe 'ayuda' para ver todos los comandos! ɞ \n");

        var processor = new CommandProcessor();
        
        while (true)
        {
            utils.FontColor(ConsoleColor.Cyan," ╰┈➤ ");
            var input = Console.ReadLine()?.Trim();
            if (string.IsNullOrEmpty(input)) continue;
            if (input.Equals("salir", StringComparison.OrdinalIgnoreCase)) break;
            
            processor.Process(input);
        }
    }
}