using System.Diagnostics.Tracing;
using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TextAdventure {
    public class Interactable : MonoBehaviour {

        public string Name { get => objectName; }

        [Header("Interactable")]
        [SerializeField]
        string objectName;
        internal List<Interaction> Interactions { get => interactions; }

        [SerializeField]
        List<Interaction> interactions;

        public bool HasInteraction(Command.InteractionType commandType){
            foreach (Interaction inter in interactions)
            {
                if(inter.type == commandType){
                    return true;
                }
            }
            return false;
        }     

        public string Interact(Command.InteractionType commandType){
            foreach (Interaction inter in interactions)
            {
                if(inter.type == commandType){
                    inter.triggerEvent.Invoke();
                    return inter.interactionDialog;
                }
            }
            return "You can't do that with " + Name;
        }     

    }

    [System.Serializable]
    public class Interaction {
        public Command.InteractionType type;
        public string interactionDialog;
        public UnityEngine.Events.UnityEvent triggerEvent;
        public string[] validArgs;
    }
}