using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{
    //87.5  0.5
    // grid boyutu 1, 1
    //en sol üst -87.5 48.5
    //en sol alt -87.5 -48.5
    //en sað üst 87.5 48.5
    //en sað alt 87.5 -48.5
    //baþlangýç 87.5 0.5

    private bool isMoving;
    private Vector3 origPos, targetPos;
    public float timeToMove = 0.05f;
    public string whichPlayer;
    private string playersWay;
    private bool gameStopped = false;

    public GameObject player1;
    public GameObject player2;

    private playerMovement player1movement;
    private playerMovement player2movement;

    public GameObject player1WinScreen;
    public GameObject player2WinScreen;
    public GameObject tieScreen;
    public GameObject pauseScreen;

    public string whichMap;
    int countdownValue = 4;

    void Start()
    {
        player1movement = player1.GetComponent<playerMovement>();
        player2movement = player2.GetComponent<playerMovement>();

        if (whichPlayer == "player 1")
        playersWay = "right";

        if (whichPlayer == "player 2")
        playersWay = "left";

        StartCoroutine(StartCountdown());

        if (whichMap == "map 1")
            timeToMove = 0.05f;

        if (whichMap == "map 2")
            timeToMove = 0.07f;
    }


    void Update()
    {
        if (whichPlayer == "player 1")
        {
            if (Input.GetKeyDown(KeyCode.W) && playersWay != "down")
                playersWay = "up";
            if (Input.GetKeyDown(KeyCode.A) && playersWay != "right")
                playersWay = "left";
            if (Input.GetKeyDown(KeyCode.S) && playersWay != "up")
                playersWay = "down";
            if (Input.GetKeyDown(KeyCode.D) && playersWay != "left")
                playersWay = "right";

            if (Input.GetKeyDown(KeyCode.Escape) && !player1WinScreen.activeSelf && !player2WinScreen.activeSelf && !tieScreen.activeSelf && countdownValue <= 0)
                toggleGameStop();
            
                
        }
        else if(whichPlayer == "player 2")
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && playersWay != "down")
                playersWay = "up";
            if (Input.GetKeyDown(KeyCode.LeftArrow) && playersWay != "right")
                playersWay = "left";
            if (Input.GetKeyDown(KeyCode.DownArrow) && playersWay != "up")
                playersWay = "down";
            if (Input.GetKeyDown(KeyCode.RightArrow) && playersWay != "left")
                playersWay = "right";
        }


        if (playersWay == "up" && !isMoving && !gameStopped)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 90f);
            StartCoroutine(MovePlayer(Vector3.up));
        }

        if (playersWay == "left" && !isMoving && !gameStopped)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 180f);
            StartCoroutine(MovePlayer(Vector3.left));
        }

        if (playersWay == "down" && !isMoving && !gameStopped)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, -90f);
            StartCoroutine(MovePlayer(Vector3.down));
        }

        if (playersWay == "right" && !isMoving && !gameStopped)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            StartCoroutine(MovePlayer(Vector3.right));
        }
            
        if(tieScreen.activeSelf)
        {
            player1WinScreen.SetActive(!enabled);
            player2WinScreen.SetActive(!enabled);
        }

        if (player1WinScreen.activeSelf && player2WinScreen.activeSelf)
        {
            tieScreen.SetActive(enabled);
            player1WinScreen.SetActive(!enabled);
            player2WinScreen.SetActive(!enabled);
        }
    }

    private IEnumerator MovePlayer(Vector3 direction)
    {
        isMoving = true;

        float elapsedTime = 0;

        origPos = transform.position;

        if(whichMap == "map 1")
        targetPos = origPos + direction;

        if (whichMap == "map 2")
        targetPos = origPos + direction*2;

        while (elapsedTime < timeToMove)
        {
            transform.position = Vector3.Lerp(origPos, targetPos, (elapsedTime / timeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;

        isMoving = false;
    }

    public void toggleGameStop()
    {
        player1movement.gameStopped = !player1movement.gameStopped;
        player2movement.gameStopped = !player2movement.gameStopped;
        pauseScreen.SetActive(!pauseScreen.activeSelf);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player1movement.gameStopped = true;
            player2movement.gameStopped = true;
            tieScreen.SetActive(enabled); 

        }
        
        if (collision.gameObject.CompareTag("Trail"))
        {
            if (whichPlayer == "player 1")
            {
                player2WinScreen.SetActive(enabled);
                player2movement.gameStopped = true;
                gameStopped = true;
            }

            if (whichPlayer == "player 2")
            {
                player1WinScreen.SetActive(enabled);
                player1movement.gameStopped = true;
                gameStopped = true;
            }
               
        }
    }

    IEnumerator StartCountdown()
    {
        countdownValue = 4;

        while (countdownValue > 0)
        {
            player1movement.gameStopped = true;
            player2movement.gameStopped = true;
            yield return new WaitForSeconds(1f);
            countdownValue--;
        }
        player1movement.gameStopped = false;
        player2movement.gameStopped = false;

        yield return null;
    }
}
