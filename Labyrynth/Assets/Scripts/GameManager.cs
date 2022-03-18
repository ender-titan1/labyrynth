using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [System.Serializable]
    public struct ControlScheme
    {
        public KeyCode pauseBind;
        public KeyCode printBind;
    }

    public static GameManager Instance { get; set; }
    private int timeToEnd;

    public int TimeToEnd
    {
        get => timeToEnd;
        set => timeToEnd = value;
    }

    private int score;

    public int Score
    {
        get => score;
        set => score = value;
    }

    // Pausing 
    private bool isPaused = false;

    [SerializeField]
    private ControlScheme scheme;

    // Ending
    public GameState state;

    // Keys
    private int redKeys;
    private int greenKeys;
    private int goldKeys;

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
        CheckPause();
        PrintInfo();
    }

    private void PrintInfo()
    {
        if (Input.GetKeyDown(scheme.printBind))
        {
            Debug.Log($"Time left: {timeToEnd}");
            Debug.Log($"Keys:\n\tGreen: {greenKeys}, Red: {redKeys}, Gold: {goldKeys}");
            Debug.Log($"Score: {score}");
        }
    }

    private void CheckPause()
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
        //Debug.Log(timeToEnd, gameObject);

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

    public void FreezeTime(float time)
    {
        CancelInvoke("Stopper");
        InvokeRepeating("Stopper", time, 1);
    }

    public void AddKey(Key.KeyColor key)
    {
        switch (key)
        {
            case Key.KeyColor.Red:
                redKeys++;
                break;
            case Key.KeyColor.Green:
                greenKeys++;
                break;
            case Key.KeyColor.Gold:
                goldKeys++;
                break;
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
