using TaskTrackerCLI.Services;

namespace TaskTrackerCLI.Commands;

public class CommandProcessor
{
    public void Process(string input)
    {
        var args = input.Split('-', StringSplitOptions.RemoveEmptyEntries).ToList();
        var command = args[0].ToLower().Trim();
        var arg1 = args.Count > 1 ? args[1].Trim() :  null;
        var arg2 = args.Count > 2 ? args[2].Trim() :  null;

        var taskService = new TaskService();
        int.TryParse(arg1, out int arg1Int);
        int.TryParse(arg2, out int arg2Int);

        Utils.Utils utils = new Utils.Utils(); 

        switch (command)
        {
            case"ayuda":
                utils.FontColor(ConsoleColor.Green, $"Lista de comandos {Utils.Utils.HelpEmoji} \n");
                Console.Write($"'ayuda' : Lista todos los comandos.\n" +
                              "'crear -[descripcion]' : Crea una nueva tarea. Ej: crear -Comprar tomates\n" +
                              "'editar -[id] -[descripcion]' : Edita una tarea existente. Ej: editar -1 -Comprar 5 tomates\n" +
                              "'eliminar -[id]' : Elimina una tarea. Ej: eliminar -1\n" +
                              "'marcar -p -[id]' : Marca una tarea como 'En Progreso'. Ej: marcar -p -1\n" +
                              "'marcar -c -[id]' : Marca una tarea como completada. Ej: marcar -c -1\n" +
                              "'listar' : Lista todas las tareas.\n" +
                              "'listar -h' : Lista todas las tareas por hacer.\n" +
                              "'listar -p' : Lista todas las tareas en progreso.\n" +
                              "'listar -c' : Lista todas las tareas completadas.\n" +
                              "'limpiar' : Limpia la consola.\n" +
                              "'salir' : Salir de TaskTracker.\n");
                break;
            case "crear":
                if (arg1 is null || args.Count != 2)
                   taskService.CreateTask("Nueva Tarea");
                else taskService.CreateTask(arg1);
                break;
                
            case "editar":
                if (!(arg1 is null || arg2 is null || args.Count != 3))
                    taskService.UpdateTask(arg1Int, arg2);
                else utils.FontColor(ConsoleColor.Yellow, $"El comando correcto seria 'editar -[id] -[descripcion]' {Utils.Utils.HelpEmoji} \n");
                break;
            
            case "eliminar":
                if (arg1 is null || args.Count != 2) 
                    utils.FontColor(ConsoleColor.Yellow, $"El comando correcto seria 'eliminar -[id]' {Utils.Utils.HelpEmoji} \n");
                else taskService.DeleteTask(arg1Int);
                break;
            
            case "marcar":
                if ((args.Count != 3 || string.IsNullOrEmpty(arg1) || string.IsNullOrEmpty(arg2))|| (arg1 != "p" && arg1 != "c"))
                {
                    utils.FontColor(ConsoleColor.Yellow, $"El comando correcto seria 'marcar -p|-c -[id]'{Utils.Utils.HelpEmoji} \n");
                    return;
                }
                if(arg1 == "p") taskService.MarkTaskAsInProgress(arg2Int);
                else taskService.MarkTaskAsCompleted(arg2Int);
                break;
            
            case "listar":
                if (args.Count == 1)
                {
                    taskService.ListTasks();
                }
                else if (args.Count == 2 && arg1 is "c" or "p" or "h")
                {
                    if (arg1 == "c") taskService.ListCompletedTasks();
                    else if (arg1 == "p") taskService.ListInProgressTasks();
                    else taskService.ListToDoTasks();
                }
                else 
                    utils.FontColor(ConsoleColor.Yellow, $"El comando correcto seria 'listar' o 'listar -p|-c|-h' {Utils.Utils.HelpEmoji} \n");
                break;
            
            case "limpiar":
                Console.Clear();
                break;
            
            default:
                utils.FontColor(ConsoleColor.Red, $"Ese comando no parece ser valido {Utils.Utils.ErrorEmoji} \n");
                break;
        }
    }
}