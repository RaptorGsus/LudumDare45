using System.Collections.Generic;

public class CommandParser
{
    struct Command
    {
        public CommandType type;
        public string[] aliases;

        public Command(CommandType t, string[] a)
        {
            type = t;
            aliases = a;
        }
    }

    public enum CommandType
    {
        Take,
        Drop,
        Look,
        Move,
        Read,
        Use,
        Open,
        Attack,
        //Unique,
        Invalid
    }

    private Dictionary<string, CommandType> commandMap;
    private List<Command> commands;
    
    private void Start()
    {
        IndexCommands();
    }

    public CommandType ParseCommand(string input){
        CommandType type;
        if (commandMap.TryGetValue(input, out type)){{
            return type;
        }}

        return CommandType.Invalid;

    }

    private void IndexCommands()
    {
        commands = new List<Command>();
        Command[] commandArray =
        {
            new Command(CommandType.Take,
                new string[] {
                    "take",
                    "grab",
                }),
            new Command(CommandType.Drop,
                new string[] {
                    "drop",
                    "discard"
                }),
            new Command(CommandType.Look,
                new string[] {
                    "look",
                    "watch",
                    "eye"
                }),
            new Command(CommandType.Move,
                new string[] {
                    "move",
                    "walk",
                    "run"
                }),
            new Command(CommandType.Read,
                new string[] {
                    "read"
                }),
            new Command(CommandType.Use,
                new string[] {
                    "use",
                    "interact"
                }),
            new Command(CommandType.Open,
                new string[] {
                    "open",
                    "unlock",
                }),
            new Command(CommandType.Attack,
                new string[] {
                    "attack",
                    "hit",
                    "break"
                    })
        };

        foreach(Command c in commandArray){
            foreach(string s in c.aliases){
                commandMap.Add(s, c.type);
            }
        }

    }
}
