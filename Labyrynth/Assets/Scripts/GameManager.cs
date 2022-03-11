using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [System.Serializable]
    public struct ControlScheme
    {
        public KeyCode pauseBind;
    }

    public static GameManager Instance { get; set; }
    public int timeToEnd;
    public int score;

    // Pausing 
    public bool isPaused = false;
    public ControlScheme scheme;

    // Ending
    public GameState state;

    private void Awake()
    {
        if (Instance == null)
            Instance  = this;
    }

    private void Start()
    {
        if (timeToEnd == 0)
            timeToEnd = 100;

        InvokeRepeating(nameof(Stopper), 0, 1);
    }

    private void Update()
    {
        if (Input.GetKeyDown(scheme.pauseBind))
        {
            if (isPaused)
                UnPauseGame();
            else
                PauseGame();
        }
    }

    private void Stopper()
    {
        timeToEnd--;
        Debug.Log(timeToEnd);

        if (timeToEnd <= 0)
            EndGame(GameState.Timeout);
    }

    public void EndGame(GameState state)
    {
        CancelInvoke(nameof(Stopper));
        timeToEnd = 100;

        this.state = state;

        if (state == GameState.Timeout)
        {
            Debug.Log("Lost!");
        }
        else
        {
            Debug.Log("Won!");
        }
    }

    #region Pause

    public void PauseGame()
    {
        Debug.Log("Paused game");
        Time.timeScale = 0f;
        isPaused = true;
        Cursor.visible = true;
    }

    public void UnPauseGame()
    {
        Debug.Log("Un Paused Game");
        Time.timeScale = 1f;
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    #endregion
}
