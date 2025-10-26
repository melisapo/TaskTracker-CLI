using TaskTrackerCLI.Commands;

namespace TaskTrackerCLI;

class Program
{
    static void Main()
    {
        var utils = new Utils.Utils();
        
        utils.FontColor(ConsoleColor.Cyan ,"Selecciona un idioma / Select a language:\n1- Espanol\n2- English\n");
        
        var languageInput = Console.ReadLine();
        
        while (languageInput is not ("1" or "2"))
        {
            Console.WriteLine("Por favor ingrese una opcion valida / Please enter a valid option");
            languageInput = Console.ReadLine();
        }
        
        var langUtils = new Utils.LanguageUtils(languageInput);
        
        langUtils.WelcomeMessage();
        
        while (true)
        {
            utils.FontColor(ConsoleColor.Cyan," ╰┈➤ ");
            Console.ResetColor();
            var input = Console.ReadLine()?.Trim();
            if (string.IsNullOrEmpty(input)) continue;
            if (input is "exit") break;
            
            CommandProcessor.Process(input, languageInput);
        }
    }
}