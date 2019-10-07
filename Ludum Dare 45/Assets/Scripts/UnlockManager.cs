using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockManager : Singleton<UnlockManager>
{

    public enum GraphicsLevel
    {
        Low, Medium, High
    }

    private static bool take = false;
    private static bool drop = false;
    private static bool look = false;
    private static bool move = false;
    /*TODO: */ private static bool read = false;
    private static bool use = false;
    private static bool open = false;
    private static bool attack = false;
    private static bool backpack = false;

    public GraphicsLevel graphics = GraphicsLevel.Low;

    public bool Take {
        get {
            return take;
        }
    }

    public bool Drop {
        get {
            return drop;
        }
    }

    public bool Look {
        get {
            return look;
        }
    }

    public bool Move {
        get {
            return move;
        }
    }

    public bool Read {
        get {
            return read;
        }
    }

    public bool Open {
        get {
            return open;
        }
    }

    public bool Attack {
        get {
            return attack;
        }
    }

    public bool Backpack {
        get {
            return backpack;
        }
    }

    public bool Use {
        get {
            return use;
        }
    }

    public GraphicsLevel Graphics { get => graphics; }

    public void UnlockHands()
    {
        take = true;
        drop = true;
        use = true;
    }

    public void SetGraphicsLevel(GraphicsLevel level)
    {
        graphics = level;
    }

    public void PickUpKey()
    {
        open = true;
        //Skeleton Key; picked up from slaying the skeleton
    }

    public void DropKey()
    {
        // Drop the Skeleton key.
        open = false;
    }

    public void UnlockSword()
    {
        //Enable Attack
        attack = true;
    }

    bool toggle1 = false;
    bool toggle2 = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            toggle1 = !toggle1;
            if(toggle1) {
                TextAdventureConsole.Instance.WriteLine("All commands unlocked.");
            } else {
                TextAdventureConsole.Instance.WriteLine("All commands locked.");
            }
            take =      toggle1;
            drop =      toggle1;
            look =      toggle1;
            move =      toggle1;
            read =      toggle1;
            use =       toggle1;
            open =      toggle1;
            attack =    toggle1;
        }
        
        if(Input.GetKeyDown(KeyCode.Alpha2)) {
            toggle2 = !toggle2;
            if(toggle2) {
                TextAdventureConsole.Instance.WriteLine("Inventory Expanded!");
            } else {
                TextAdventureConsole.Instance.WriteLine("Inventory Locked!");
            }
            backpack = toggle2;
        }


    }





}
