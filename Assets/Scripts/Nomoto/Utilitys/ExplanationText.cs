using UnityEngine;
using System.Collections;

public class ExplanationText : MonoBehaviour
{
    [SerializeField]
    string text;

    public string Text
    {
        get { return Text; }
        set { text = value; }
    }
}
