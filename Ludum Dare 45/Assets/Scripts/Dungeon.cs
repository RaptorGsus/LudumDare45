using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace TextAdventure {
    public class Dungeon : MonoBehaviour {
        public int size;
        Room[][] rooms;
        // Start is called before the first frame update
        private void Start() {
            InitGrid();
        }

        private void InitGrid() {
            rooms = new Room[size][];
            for (int i = 0; i < size; i++) {
                rooms[i] = new Room[size];
            }
            var roomComponents = GetComponentsInChildren<Room>();
            foreach (Room room in roomComponents) {
                rooms[room.Position.x][room.Position.y] = room;
            }
        }

        public Room GetRoomAt(Vector2Int pos) {
            try {
                return rooms[pos.x][pos.y];
            } catch (IndexOutOfRangeException ex) {
                Debug.Log(ex.StackTrace);
                return null;
            }
        }

        public Room GetRoomAt(int x, int y) {
            try {
                return rooms[x][y];
            } catch (IndexOutOfRangeException ex) {
                Debug.Log(ex.StackTrace);
                return null;
            }
        }
    }
}