using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace TextAdventure {
    public class Room : MonoBehaviour {
        // Classes, Structs and Enums
        private Dungeon dungeon;
        public enum Neighbor {
            North,
            East,
            South,
            West
        }

        //Members
        [Multiline(5)]
        public string description;
        [SerializeField]
        private Vector2Int roomPosition;
        private List<Interactable> interactables;

        //Properties
        public List<Interactable> Interactables { get => new List<Interactable>(GetComponentsInChildren<Interactable>()); }
        public Vector2Int Position { get => roomPosition; }

        public void SetPosition(Vector2Int pos) {
            roomPosition = pos;
        }

        private void Start() {
            dungeon = GetComponentInParent<Dungeon>();

        }

        

        public string MoveDirection(Neighbor direction) {
            var newPos = Position;
            switch (direction) {
                case Neighbor.North:
                    newPos.y++;
                    break;
                case Neighbor.East:
                    newPos.x++;
                    break;
                case Neighbor.South:
                    newPos.y--;
                    break;
                case Neighbor.West:
                    newPos.x--;
                    break;
                default:

                    break;
            }

            Room newRoom = dungeon.GetRoomAt(newPos);
            if (newRoom) {
                Player.CurrentRoom = newRoom;
                return "You head " + direction.ToString() + Environment.NewLine +
                    this.description;
            } else {
                return "There's no door to the " + direction.ToString();
            }
        }

        internal string[] ListDoors() {
            List<string> value = new List<string>();
            if (dungeon.GetRoomAt(Position.x - 1, Position.y) != null) {
                value.Add("West");
            }
            if (dungeon.GetRoomAt(Position.x + 1, Position.y) != null) {
                value.Add("East");
            }
            if (dungeon.GetRoomAt(Position.x, Position.y + 1) != null) {
                value.Add("North");
            }
            if (dungeon.GetRoomAt(Position.x, Position.y - 1) != null) {
                value.Add("South");
            }
            return value.ToArray();
        }

        public void PrintDescription() {
            TextAdventureConsole.Instance.WriteLine(description);
        }

        public string[] ListInteractables() {
            List<string> value = new List<string>();
            if (Interactables.Count > 1) {
                for (int i = 1; i < Interactables.Count; i++) {
                    value.Add(Interactables[i].Name);
                }
            }
            return value.ToArray();
        }

        public string PassCommand(Command com) {
            if (com.type == Command.InteractionType.Move) {
                string dirArg = com.args[0].Trim().ToLower();
                switch (dirArg) {
                    case "north":
                        return MoveDirection(Neighbor.North);
                    case "south":
                        return MoveDirection(Neighbor.South);
                    case "east":
                        return MoveDirection(Neighbor.East);
                    case "west":
                        return MoveDirection(Neighbor.West);
                    default:
                        return "Can't move to <"+ dirArg + "> \nPlease choose: North, South, East or West";
                }
            }
            Interactable subject = GetInteractable(com.args[0]);
            if (!subject) {
                return "There is no " + com.args[0] + " here.";
            }

            return subject.Interact(com.type);
        }

        private Interactable GetInteractable(string query) {
            foreach (Interactable i in Interactables) {
                if (i.Name.Equals(query.Trim(), StringComparison.OrdinalIgnoreCase)) {
                    return i;
                }
            }

            return null;
        }

        public Interactable[] MatchInteraction(Command com) {
            List<Interactable> matches = new List<Interactable>();

            foreach (Interactable ii in Interactables) {
                if (ii.HasInteraction(com.type) && com.args[0].Equals(ii.Name, StringComparison.OrdinalIgnoreCase)) {
                    matches.Add(ii);
                }
            }
            return matches.ToArray();
        }

        private void OnValidate() {
            gameObject.name = "Room (" + Position.x + "," + Position.y + ")";
        }

        public class CommandEventArgs : EventArgs {
            public Command.InteractionType type;
            public string[] args;
            public string message;

            public CommandEventArgs(Command com) {
                type = com.type;
                args = com.args;
            }
        }
    }
}