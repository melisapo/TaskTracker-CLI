namespace TaskTrackerCLI.Utils;

public class LanguageUtils(string languageInput)
{
    private readonly Utils _utils = new();
    public bool Language { get; } = ProcessLanguage(languageInput);

    private static bool ProcessLanguage(string languageInput)
    {
        var lang = languageInput == "1";
        return lang;
    }
    
    public void WelcomeMessage()
    {
        Console.Clear();
        if (Language)
        {
            _utils.BackColor(ConsoleColor.DarkMagenta, "𑣲 Hola! Bienvenido a TaskTracker! (๑╹ᵕ╹๑)⸝* \n");
            _utils.FontColor(ConsoleColor.Magenta, "ʚ Escribe 'help' para ver todos los comandos! ɞ \n");
        }
        else
        {
            _utils.BackColor(ConsoleColor.DarkMagenta, "𑣲 Hi! Welcome to TaskTracker! (๑╹ᵕ╹๑)⸝* \n");
            _utils.FontColor(ConsoleColor.Magenta, "ʚ Type 'help' to se all the commands! ɞ \n");
        }
    }

    public void HelpCommandMessage()
    {
        if (Language)
        {
            _utils.FontColor(ConsoleColor.Green, $"Lista de comandos {Utils.HelpEmoji} \n");
            Console.Write($"'help' : Lista todos los comandos.\n" +
                          "'create -[descripcion]' : Crea una nueva tarea. Ej: create -Comprar tomates\n" +
                          "'update -[id] -[descripcion]' : Edita una tarea existente. Ej: update -1 -Comprar 5 tomates\n" +
                          "'delete -[id]' : Elimina una tarea. Ej: delete -1\n" +
                          "'mark -p -[id]' : Marca una tarea como 'En Progreso'. Ej: mark -p -1\n" +
                          "'mark -c -[id]' : Marca una tarea como 'Completada'. Ej: mark -c -1\n" +
                          "'list' : Lista todas las tareas.\n" +
                          "'list -h' : Lista todas las tareas por hacer.\n" +
                          "'list -p' : Lista todas las tareas en progreso.\n" +
                          "'list -c' : Lista todas las tareas completadas.\n" +
                          "'clear' : Limpia la consola.\n" +
                          "'exit' : Salir de TaskTracker.\n");
        }
        else
        {
            _utils.FontColor(ConsoleColor.Green, $"Command List {Utils.HelpEmoji} \n");
            Console.Write($"'help' : List all commands.\n" +
                          "'create -[descripcion]' : Create a new task. Ex: create -Buy tomatoes\n" +
                          "'update -[id] -[descripcion]' : Update an existing task. Ej: update -1 -Buy 5 tomatoes\n" +
                          "'delete -[id]' : Delete a task. Ej: delete -1\n" +
                          "'mark -p -[id]' : Mark a task as 'In Progress'. Ej: mark -p -1\n" +
                          "'mark -c -[id]' : Mark a task as 'Completed'. Ej: mark -c -1\n" +
                          "'list' : List all tasks.\n" +
                          "'list -h' : List all tasks to do.\n" +
                          "'list -p' : List all tasks in progress.\n" +
                          "'list -c' : List all completed tasks.\n" +
                          "'clear' : Clean the terminal.\n" +
                          "'exit' : Exit TaskTracker.\n");
        }
        Console.ResetColor();
    }

    public void UpdateCommandMessage()
    {
        _utils.FontColor(ConsoleColor.Yellow,
            Language
                ? $"El comando correcto seria 'update -[id] -[descripcion]' {Utils.HelpEmoji} \n"
                : $"The correct command is 'update -[id] -[description]' {Utils.HelpEmoji} \n");
        Console.ResetColor();
    }
    public void DeleteCommandMessage()
    {
        _utils.FontColor(ConsoleColor.Yellow,
            Language
                ? $"El comando correcto seria 'delete -[id]' {Utils.HelpEmoji} \n"
                : $"The correct command is 'delete -[id] -[description]' {Utils.HelpEmoji} \n");
        Console.ResetColor();
    }
    public void MarkCommandMessage()
    {
        _utils.FontColor(ConsoleColor.Yellow,
            Language
                ? $"El comando correcto seria 'mark -p|-c -[id]' {Utils.HelpEmoji} \n"
                : $"The correct command is 'mark -p|-c -[id]' {Utils.HelpEmoji} \n");
        Console.ResetColor();
    }
    public void ListCommandMessage()
    {
        _utils.FontColor(ConsoleColor.Yellow,
            Language
                ? $"El comando correcto seria 'list' o 'list -p|-c|-t' {Utils.HelpEmoji} \n"
                : $"The correct command is 'list' r 'list -p|-c|-t' {Utils.HelpEmoji} \n");
        Console.ResetColor();
    }
    public void BadCommandMessage()
    {
        _utils.FontColor(ConsoleColor.Red,
            Language
                ? $"Ese comando no parece ser valido {Utils.ErrorEmoji} \n"
                : $"That command doesn't seem to be valid {Utils.ErrorEmoji} \n");
        Console.ResetColor();
    }

    public void NoTaskMessage()
    {
        _utils.FontColor(ConsoleColor.Cyan,
            Language
                ? $"No se ha encontrado la tarea {Utils.EmptyEmoji} \n"
                : $"Task not found {Utils.EmptyEmoji} \n");
        Console.ResetColor();
    }

    public void NoTasksMessage()
    {
        _utils.FontColor(ConsoleColor.Cyan,
            Language
                ? $"No se ha encontrado ninguna tarea {Utils.EmptyEmoji} \n"
                : $"Couldn't find any task {Utils.EmptyEmoji} \n");
        Console.ResetColor();
    }

    public void CreatedTaskMessage(string description, int id)
    {
        _utils.FontColor(ConsoleColor.Green,
            Language
                ? $"La tarea '{description}' se ha creado. Id: {id}. {Utils.GoodEmoji} \n"
                : $"The task '{description}' has been created. Id: {id}. {Utils.GoodEmoji} \n");
        Console.ResetColor();
    }
    
    public void UpdatedTaskMessage(string description, string newDescription)
    {
        _utils.FontColor(ConsoleColor.Green,
            Language
                ? $"La tarea '{description}' se ha actualizado a '{newDescription}'. {Utils.GoodEmoji} \n"
                : $"The task '{description}' has been updated to '{newDescription}'. {Utils.GoodEmoji} \n");
        Console.ResetColor();
    }

    public void DeletedTaskMessage(string description)
    {
        _utils.FontColor(ConsoleColor.Green,
            Language
                ? $"La tarea '{description}' ha sido eliminada. {Utils.GoodEmoji} \n"
                : $"The task '{description}' has been deleted. {Utils.GoodEmoji} \n");
        Console.ResetColor();
    }

    public void MarkedTaskMessage(string description, Enum.Status status)
    {
        switch (status)
        {
            case Enum.Status.Completed:
                _utils.FontColor(ConsoleColor.Green,
                    Language
                        ? $"La tarea '{description}' se ha marcado como 'Completada'. {Utils.DoneEmoji}\n"
                        : $"The task '{description}' has been marked as 'Completed'. {Utils.DoneEmoji}\\n");
                break;
            case Enum.Status.InProgress:
                _utils.FontColor(ConsoleColor.Green,
                    Language
                        ? $"La tarea '{description}' se ha marcado como 'En Progreso'. {Utils.InprogressEmoji}\n"
                        : $"The task '{description}' has been marked as 'In Progress'. {Utils.InprogressEmoji}\n");
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(status), status, null);
        }
        Console.ResetColor();
    }
}