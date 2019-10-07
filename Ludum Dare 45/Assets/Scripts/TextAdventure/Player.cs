using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using TextAdventure;
using UnityEngine;

namespace TextAdventure {
    public class Player : MonoBehaviour {

        public TMPro.TextMeshProUGUI debug;

        private static Room room;
        public static Room CurrentRoom {
            get { return room; }
            set { room = value; }
        }

        public List<Item> Inventory { get { return new List<Item>(GetComponentsInChildren<Item>()); } }

        private void Start() {
            room = FindObjectOfType<Dungeon>().GetRoomAt(0, 0);
        }

        private void Update() {
            if (debug) {
                debug.text = "Room\n" + String.Join(",", new int[] { CurrentRoom.Position.x, CurrentRoom.Position.y });
            }
        }

        public string DoCommand(Command com) {
            string message = "";

            switch (com.type) {
                case Command.InteractionType.Take:
                    if (!UnlockManager.Instance.Take) {
                        message = "Unknown Command 405";
                        break;
                    }
                    if(!UnlockManager.Instance.Backpack && Inventory.Count > 0) {
                        message = "Your hands are full... if only there was a way to carry more objects...";
                        break;
                    }
                    if (com.args.Length == 0) { message = GetTakeNoArgs(); } else {
                        message = CurrentRoom.PassCommand(com);
                    }
                    break;
                case Command.InteractionType.Drop:
                    if (!UnlockManager.Instance.Drop) {
                        message = "Unknown Command 405";
                        break;
                    }
                    if (Inventory.Count == 0) {
                        message = "You aren't holding anything";
                        break;
                    }
                    foreach (Item item in Inventory) {
                        if (com.args.Contains(item.GetInteractable().Name, StringComparer.OrdinalIgnoreCase)) {
                            item.transform.parent = CurrentRoom.transform;
                            message = "Dropped " + item.GetInteractable().Name;
                            break;
                        }
                        message = "You aren't holding " + com.args[0];
                    }
                    break;
                case Command.InteractionType.Look:
                    if (!UnlockManager.Instance.Look) {
                        message = "Unknown Command 405";
                        break;
                    }
                    if (com.args.Length == 0 || com.args.Contains("room", StringComparer.OrdinalIgnoreCase)) {
                        message = CurrentRoom.Interactables.Count() <= 1 ?
                            CurrentRoom.description + "\nThe Room is empty." :
                            CurrentRoom.description + "\nThe Room contains the following\n +" +
                            String.Join("\n +", CurrentRoom.ListInteractables());
                    } else {
                        message = CurrentRoom.PassCommand(com);
                    }
                    break;
                case Command.InteractionType.Move:
                    if (!UnlockManager.Instance.Move) {
                        message = "Unknown Command 405";
                        break;
                    }
                    if (com.args.Length == 0) {
                        var validDirs = CurrentRoom.ListDoors();
                        message = "There are " + validDirs.Length + " Doors in this room\n +" + String.Join("\n +", validDirs);
                    } else {
                        message = CurrentRoom.PassCommand(com);
                    }
                    break;
                case Command.InteractionType.Read:
                    if (!UnlockManager.Instance.Read) {
                        message = "Unknown Command 405";
                        break;
                    }
                    if (com.args.Length == 0) {
                        message = GetReadNoArgs();
                    } else {
                        //CurrentRoom.MatchInteraction(com);
                    }
                    break;
                case Command.InteractionType.Use:
                    if (!UnlockManager.Instance.Use) {
                        message = "Unknown Command 405";
                        break;
                    }
                    if (com.args.Length == 0) {
                        message = "Typically, you use an object, but don't let me tell you how to live your life...";
                    } else {
                        //CurrentRoom.MatchInteraction(com);
                    }
                    break;
                case Command.InteractionType.Open:
                    if (!UnlockManager.Instance.Open) {
                        message = "Unknown Command 405";
                        break;
                    }
                    if (com.args.Length == 0) {
                        message = "What do you want to open?";
                    } else {
                        //CurrentRoom.MatchInteraction(com);
                    }
                    break;
                case Command.InteractionType.Attack:
                    if (!UnlockManager.Instance.Attack) {
                        message = "Unknown Command 405";
                        break;
                    }
                    if (com.args.Length == 0) {
                        message = "You swing your sword wildly making everyone *very* uncomfortable.";
                    } else {
                        //CurrentRoom.MatchInteraction(com);
                    }
                    break;
                case Command.InteractionType.Invalid:
                    message = ("Unknown command.");
                    break;
                default:
                    message = "Unk.";
                    break;
            }

            return message;
        }

        private static string GetReadNoArgs() {
            System.Random r = new System.Random();
            string message;
            var responses = new List<string> {
                "You are reading right this very second!",
                "Yes.",
                "You read the room... it's awkward."
            };
            message = responses[r.Next(0, responses.Count)];
            return message;
        }

        private string GetTakeNoArgs() {
            System.Random r = new System.Random();
            var responses = new List<string> {
                "You take in the view",
                "You take... A deep breath",
                "You grab at the air... You look stupid.",
                "You take a moment to self-reflect..."
            };
            return responses[r.Next(0, responses.Count)];
        }
    }
}