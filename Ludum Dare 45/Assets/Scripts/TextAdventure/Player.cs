using System.Linq;
using System;
using UnityEngine;

public class Player : MonoBehaviour {

    public string DoCommand(Command com) {
        string message = "";
        switch (com.type) {
            case Command.CommandType.Take:
                message = "Command - " + com.type.ToString() + Environment.NewLine +
                "Arg: ";
                foreach(string arg in com.args ) { message += " " + arg;}
                break;
            case Command.CommandType.Drop:
                message = "Command - " + com.type.ToString() + Environment.NewLine +
                "Arg: ";
                foreach(string arg in com.args ) { message += " " + arg;}
                break;
            case Command.CommandType.Look:
                message = "Command - " + com.type.ToString() + Environment.NewLine +
                "Arg: ";
                foreach(string arg in com.args ) { message += " " + arg;}
                break;
            case Command.CommandType.Move:
                message = "Command - " + com.type.ToString() + Environment.NewLine +
                "Arg: ";
                foreach(string arg in com.args ) { message += " " + arg;}
                break;
            case Command.CommandType.Read:
                message = "Command - " + com.type.ToString() + Environment.NewLine +
                "Arg: ";
                foreach(string arg in com.args ) { message += " " + arg;}
                break;
            case Command.CommandType.Use:
                message = "Command - " + com.type.ToString() + Environment.NewLine +
                "Arg: ";
                foreach(string arg in com.args ) { message += " " + arg;}
                break;
            case Command.CommandType.Open:
                message = "Command - " + com.type.ToString() + Environment.NewLine +
                "Arg: ";
                foreach(string arg in com.args ) { message += " " + arg;}
                break;
            case Command.CommandType.Attack:
                message = "Command - " + com.type.ToString() + Environment.NewLine +
                "Arg: ";
                foreach(string arg in com.args ) { message += " " + arg;}
                break;
            case Command.CommandType.Invalid:
                message = "Command - " + com.type.ToString() + Environment.NewLine +
                "Arg: ";
                foreach(string arg in com.args ) { message += " " + arg;}
                break;
            default:
                message = com.type.ToString() + " is not a valid command.";
                break;
        }

        return message;
    }
}