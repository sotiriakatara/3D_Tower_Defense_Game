using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver;

    public GameObject gameOverUI;
    public GameObject completeLevelUI;

    public string nextLevel = "Level02";
    public int levelToUnlock = 2;

   


    void Start()
    {
        GameIsOver = false;
    }

    // Update is called once per frame
    void Update()
    {


        if (GameIsOver)
            return;

        if (Input.GetKeyDown("e"))
        {
            EndGame();
        }
        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        GameIsOver = true;
        gameOverUI.SetActive(true);
    }

    public void WinLevel()
    {
        GameIsOver = true; // camera stop moving
        completeLevelUI.SetActive(true);
       
    }



}
