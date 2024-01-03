using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuTrails : MonoBehaviour
{

    private Vector3 origPos, targetPos;
    float timeToMove = 0.05f;
    public string whichColor;
    bool isMoving;

    void Start()
    {
        if (whichColor == "pink")
        {
            int randomY = Random.Range(-45, 45);
            float randomSpeed = Random.Range(0.01f, 0.04f);
            Vector3 newPosition = new Vector3(-88f, randomY, 0f);
            transform.position = newPosition;
            timeToMove = randomSpeed;
        }

        if (whichColor == "blue")
        {
            int randomY = Random.Range(-45, 45);
            float randomSpeed = Random.Range(0.01f, 0.04f);
            Vector3 newPosition = new Vector3(88f, randomY, 0f);
            transform.position = newPosition;
            timeToMove = randomSpeed;
        }

    }

    void Update()
    {

        if (whichColor == "pink")
        {

            if (!isMoving && transform.position.x <= 88f)
            {
                StartCoroutine(MovePlayer(Vector3.right));
            }
            if (transform.position.x >= 88)
            {
                Destroy(gameObject);
            }
        }

        if (whichColor == "blue")
        {
            if (!isMoving && transform.position.x >= -88f)
            {
                StartCoroutine(MovePlayer(Vector3.left));

            }
            if (transform.position.x <= -88f)
            {
                Destroy(gameObject);
            }
        }
    }

    private IEnumerator MovePlayer(Vector3 direction)
    {
        isMoving = true;

        float elapsedTime = 0;

        origPos = transform.position;

        targetPos = origPos + direction;

        while (elapsedTime < timeToMove)
        {
            transform.position = Vector3.Lerp(origPos, targetPos, (elapsedTime / timeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;

        isMoving = false;
    }
}
