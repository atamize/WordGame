using UnityEngine;
using System.Collections;
using System.Text;

public class Tube : MonoBehaviour
{

    StringBuilder word;

    void Awake()
    {
        word = new StringBuilder();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            var ball = collision.GetComponent<Ball>();
            word.Insert(0, ball.Letter);
            print("Current word: " + word);
        }
    }
}
