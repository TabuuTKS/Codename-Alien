using UnityEngine;

[System.Serializable]
public class Dailogue
{
    string name;
    [TextArea(3,10)]
    public string[] sentences;
}
