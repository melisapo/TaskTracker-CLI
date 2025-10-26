using TaskTrackerCLI.Services;
using TaskTrackerCLI.Utils;

namespace TaskTrackerCLI.Commands;

public static class CommandProcessor
{
    public static void Process(string input, string languageInput)
    {
        var taskService = new TaskService(languageInput);
        var langUtils = new LanguageUtils(languageInput);

        var args = input.Split('-', StringSplitOptions.RemoveEmptyEntries).ToList();
        var command = args[0].ToLower().Trim();
        var arg1 = args.Count > 1 ? args[1].Trim() :  null;
        var arg2 = args.Count > 2 ? args[2].Trim() :  null;
        
        int.TryParse(arg1, out var arg1Int);
        int.TryParse(arg2, out var arg2Int);
        
        switch (command)
        {
            case "help":
                langUtils.HelpCommandMessage();
                break;
            
            case "create":
                if (arg1 is null || args.Count != 2)
                {
                    taskService.CreateTask("");
                    return;
                }
                taskService.CreateTask(arg1);
                break;
                
            case "update":
                if (arg1 is null || arg2 is null || args.Count != 3)
                {
                    langUtils.UpdateCommandMessage();
                    return;
                }
                taskService.UpdateTask(arg1Int, arg2);
                break;
            
            case "delete":
                if (arg1 is null || args.Count != 2)
                {
                    langUtils.DeleteCommandMessage();
                    return;
                } 
                taskService.DeleteTask(arg1Int);
                break;
            
            case "mark":
                if ((args.Count != 3 || string.IsNullOrEmpty(arg1) || string.IsNullOrEmpty(arg2))|| (arg1 != "p" && arg1 != "c"))
                {
                    langUtils.MarkCommandMessage();
                    return;
                }
                if(arg1 == "p") taskService.MarkTaskAsInProgress(arg2Int);
                else taskService.MarkTaskAsCompleted(arg2Int);
                break;
            
            case "list":
                switch (args.Count)
                {
                    case 1:
                        taskService.ListTasks();
                        break;
                    case 2 when arg1 is "c" or "p" or "h":
                    {
                        switch (arg1)
                        {
                            case "c":
                                taskService.ListCompletedTasks();
                                break;
                            case "p":
                                taskService.ListInProgressTasks();
                                break;
                            default:
                                taskService.ListToDoTasks();
                                break;
                        }

                        break;
                    }
                    default:
                        langUtils.ListCommandMessage();
                        break;
                }
                break;
            
            case "clear":
                Console.Clear();
                break;
            
            default:
                langUtils.BadCommandMessage();
                Console.ResetColor();
                break;
        }
    }
}