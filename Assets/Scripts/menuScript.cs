using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour
{

    public GameObject mainButtons;
    public GameObject levelButtons;

    public void exitGame()
    {
        Application.Quit();
    }

    public void toggleButtons()
    {
        mainButtons.SetActive(!mainButtons.activeSelf);
        levelButtons.SetActive(!levelButtons.activeSelf);
    }

    public void loadSmallMap()
    {
        SceneManager.LoadScene("Map 2");
    }

    public void loadBigMap()
    {
        SceneManager.LoadScene("Map 1");
    }
}

