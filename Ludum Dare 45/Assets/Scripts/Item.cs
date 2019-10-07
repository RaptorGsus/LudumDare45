using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TextAdventure {
    public class Item : MonoBehaviour {
        public void Take() {
            Player player = FindObjectOfType<Player>();

            if (player) {
                transform.parent = player.transform;
            }
        }

        public Interactable GetInteractable() {
            return GetComponent<Interactable>();
        }
    }

}