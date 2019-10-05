using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ConsoleListItem : MonoBehaviour {
    public TextMeshProUGUI bodyObject;

    private void Start() {
        bodyObject = GetComponent<TextMeshProUGUI>();
    }

    public ConsoleListItem InitItem(string text) {
        bodyObject.SetText(text);
        return this;
    }
}