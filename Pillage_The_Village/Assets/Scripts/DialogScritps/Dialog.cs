using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Dialog //not extending MonoDevelope
{
    public string name;
    [TextArea(3, 10)]//sets size of text area in inspector
    public string[] sentences; //creates an array of sentences
}

