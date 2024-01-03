using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttons : MonoBehaviour
{

    public GameObject countdown;
    public TextMeshProUGUI countdownText;

    void Start()
    {
        countdown.SetActive(true);
        StartCoroutine(StartCountdown());
    }


    void Update()
    {
        
    }

    IEnumerator StartCountdown()
    {
        int countdownValue = 3;

        while (countdownValue > 0)
        {
            countdownText.text = countdownValue.ToString();

            yield return new WaitForSeconds(1f);
            countdownValue--;
        }

        countdownText.text = "Go!";
        yield return new WaitForSeconds(1f);
        countdown.SetActive(false);
        yield return null;
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void returnMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void exitGame()
    {
        Application.Quit();
    }


}
