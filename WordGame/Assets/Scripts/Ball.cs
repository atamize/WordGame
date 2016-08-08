using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
    public string letter;
    public TextMesh textMesh;

    public string Letter
    {
        get { return letter; }
        set
        {
            letter = value;
            textMesh.text = letter;
        }
    }

    void Start()
    {

    }
}
