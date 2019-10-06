using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextAdventureConsole : Singleton<TextAdventureConsole> {
    [Header("Objects")]
    public TMP_InputField inputField;
    public Transform consoleParent;
    public Player player;

    [Header("Prefabs")]
    public GameObject consoleLitItemPrefab;

    public string[] History { get { return history.ToArray(); } }
    private List<string> history;

    private List<ConsoleListItem> consoleListItems;

    private void Start() {
        this.ForceFocus();
    }

    void OnEnable() {
        Init();
    }

    private void Init() {
        history = new List<string>();
        consoleListItems = new List<ConsoleListItem>();

    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Return)) {
            if (!string.IsNullOrWhiteSpace(inputField.text)) {
                Return(inputField.text);
            } else {
                this.Clear();
            }
        }
    }

    private void Return(string consoleInput) {
        WriteLine('>' + consoleInput);
        ParseLine(consoleInput);
        this.Clear();
        this.ForceFocus();
    }

    private void ParseLine(string input) {
        var msg = player.DoCommand(Command.Parse(input));
        this.WriteLine(msg);
    }

    public void WriteLine(string newLine) {
        history.Add(newLine);
        var go = Instantiate(consoleLitItemPrefab, consoleParent).GetComponent<ConsoleListItem>().InitItem(newLine);
        consoleListItems.Add(go);
    }

    private void ForceFocus() {
        inputField.text = "";
        inputField.Select();
        inputField.ActivateInputField();
    }

    public void Clear() {
        inputField.text = "";
    }

}