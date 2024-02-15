using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    [SerializeField] private int TimeToEnd;
    public bool isPaused = false;
    public bool endGame = false;
    public bool win;

    public int greenKeys = 0;
    public int redKeys = 0;
    public int blueKeys = 0;

    public int coins;

    void Start()
    {
        if (gameManager == null) gameManager = this;

        InvokeRepeating("Stopper", 2, 1);
    }

    void Update()
    {
        PauseCheck();
    }

    public void GamePause()
    {
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void GameResume()
    {
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void AddKey(KeyColor color)
    {
        if (color == KeyColor.Red)
            redKeys++;
        else if (color == KeyColor.Blue)
            blueKeys++;
        else if (color == KeyColor.Green)
            greenKeys++;
    }

    public void PauseCheck()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!isPaused) GamePause(); else GameResume();
        }
    }

    public void AddTime(int time)
    {
        TimeToEnd += time;
    }

    void EndGame()
    {
        CancelInvoke("Stopper");
    }

    private void Stopper()
    {
        TimeToEnd--;

        if (TimeToEnd <= 0)
        {
            TimeToEnd = 0;
            endGame = true;
        }
        if (endGame) EndGame();
    }

    public void Freez(int f)
    {
        CancelInvoke("Stopper");
        InvokeRepeating("Stopper", f, 1);
    }
}
