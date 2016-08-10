using UnityEngine;
using System.Collections;

public class AcceptButton : MonoBehaviour
{
    public Tube tube;

    public void OnTriggerEnter2D(Collider2D coll)
    {
        tube.Validate();
    }
}
