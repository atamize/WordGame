using UnityEngine;
using System.Collections;

public class Grabber : MonoBehaviour
{
    enum State { Idle, Grabbing, Retracting }

    public float moveSpeed = 7f;
    public float dropSpeed = 10f;

    Transform mTransform;
    State state;
    Rigidbody2D capturedBall;

    void Awake()
    {
        mTransform = GetComponent<Transform>();
    }

    void Update()
    {
        switch (state)
        {
            case State.Idle:
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    mTransform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
                }
                else if (Input.GetKey(KeyCode.RightArrow))
                {
                    mTransform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    if (capturedBall == null)
                    {
                        StartCoroutine(Grab());
                    }
                    else
                    {
                        capturedBall.transform.parent = null;
                        capturedBall.isKinematic = false;
                        capturedBall = null;
                        state = State.Idle;
                    }
                }
                break;
        }
        
    }

    IEnumerator Grab()
    {
        state = State.Grabbing;
        Vector3 ogPosition = mTransform.position;

        while (state == State.Grabbing)
        {
            mTransform.Translate(Vector3.down * dropSpeed * Time.deltaTime);
            yield return null;
        }

        while (mTransform.position != ogPosition)
        {
            float step = dropSpeed * Time.deltaTime;
            mTransform.position = Vector3.MoveTowards(mTransform.position, ogPosition, step);
            yield return null;
        }

        state = State.Idle;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (state == State.Grabbing && coll.CompareTag("Ball"))
        {
            coll.transform.parent = mTransform;
            capturedBall = coll.GetComponent<Rigidbody2D>();
            capturedBall.isKinematic = true;
        }
        state = State.Retracting;
    }
}
