using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class Tube : MonoBehaviour
{
    public ScoreManager scoreManager;

    StringBuilder word;
    Stack<Ball> ballStack;

    void Awake()
    {
        word = new StringBuilder();
        ballStack = new Stack<Ball>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            var ball = collision.GetComponent<Ball>();

            if (ballStack.Contains(ball))
            {
                
            }
            else
            {
                word.Insert(0, ball.Letter);
                print("Current word: " + word);
                ballStack.Push(ball);
            }
        }
    }

    public void Validate()
    {
        if (scoreManager.Validate(word.ToString().ToLower()))
        {
            print(word.ToString() + "    is VALID");

            foreach (var ball in ballStack)
            {
                Destroy(ball.gameObject);
            }
            ballStack.Clear();
            word.Length = 0;
        }
        else
        {
            print(word.ToString() + "    is INVALID");
        }
    }
}
