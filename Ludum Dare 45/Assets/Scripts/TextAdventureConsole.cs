using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TextAdventureConsole : MonoBehaviour
{
    [Header("Objects")]
    public TMP_InputField inputField;
    public Transform consoleParent;

    [Header("Prefabs")]
    public GameObject consoleLitItemPrefab;


    public string[] History { get { return history.ToArray(); } }
    private List<string> history;

    private List<ConsoleListItem> consoleListItems;

    private void Start()
    {
        Focus();
    }

    void OnEnable()
    {
        Init();
    }

    private void Init()
    {
        history = new List<string>();
        consoleListItems = new List<ConsoleListItem>();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            InputLine("> " + inputField.text);
        }
    }

    private void InputLine(string input)
    {
        WriteLine(input);
        ParseLine(input);
        inputField.text = "";
        Focus();
    }

    private void ParseLine(string input)
    {
        
        WriteLine("Nice Input!");
    }

    public void WriteLine(string newLine)
    {
        history.Add(newLine);
        var go = Instantiate(consoleLitItemPrefab, consoleParent).GetComponent<ConsoleListItem>().InitItem(newLine);
        consoleListItems.Add(go);

    }

    private void Focus()
    {
        inputField.text = "";
        inputField.Select();
        inputField.ActivateInputField();
    }


}
