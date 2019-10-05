using System;
using System.Collections.Generic;
/// <summary>
/// This Class represents a Command in the Text Adventure Interface.
/// </summary>
public class Command {
    struct CommandConfig {
        public CommandType type;
        public string[] aliases;

        public CommandConfig(CommandType t, string[] a) {
            type = t;
            aliases = a;
        }
    }

    public enum CommandType {
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

    public CommandType type;
    public string[] args = new string[0];

    private static Dictionary<string, CommandType> commandMap;

    /// <summary>
    /// Parses a <see cref="Command"/> object from a string.
    /// </summary>
    /// <param name="input">The string that needs to be parsed</param>
    /// <returns></returns>
    public static Command Parse(string input) {
        if (commandMap == null) IndexCommands();

        Command value = new Command();
        value.type = CommandType.Invalid;
        var args = input.Split(new char[] { ' ' });

        CommandType type = CommandType.Invalid;
        if (commandMap.TryGetValue(args[0].Trim().ToLower(), out type)) {
            value.type = type;
            if(args.Length > 1){
                value.args = new string[args.Length];
                Array.Copy(args, 1, value.args, 0, args.Length - 1);
            }
        }

        return value;
    }

    /// <summary>
    /// Index all commands 
    /// </summary>
    private static void IndexCommands() {
        commandMap = new Dictionary<string, CommandType>();
        CommandConfig[] commandArray = {
            new CommandConfig(CommandType.Take,
            new string[] {
            "take",
            "grab",
            }),
            new CommandConfig(CommandType.Drop,
            new string[] {
            "drop",
            "discard"
            }),
            new CommandConfig(CommandType.Look,
            new string[] {
            "look",
            "watch",
            "eye"
            }),
            new CommandConfig(CommandType.Move,
            new string[] {
            "move",
            "walk",
            "run"
            }),
            new CommandConfig(CommandType.Read,
            new string[] {
            "read"
            }),
            new CommandConfig(CommandType.Use,
            new string[] {
            "use",
            "interact"
            }),
            new CommandConfig(CommandType.Open,
            new string[] {
            "open",
            "unlock",
            }),
            new CommandConfig(CommandType.Attack,
            new string[] {
            "attack",
            "hit",
            "break"
            })
        };

        foreach (CommandConfig c in commandArray) {
            foreach (string s in c.aliases) {
                commandMap.Add(s, c.type);
            }
        }

        UnityEngine.Debug.Log(commandMap.Count + " Commands Indexed");
    }
}