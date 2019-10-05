using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ConsoleListItem : MonoBehaviour
{
    public TextMeshProUGUI bodyObject;

    private void Start()
    {
        bodyObject = GetComponent<TextMeshProUGUI>();
    }

    public ConsoleListItem InitItem(string text){
        bodyObject.SetText(text);
        return this;
    }
}
