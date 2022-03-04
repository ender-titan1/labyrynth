using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }
    [SerializeField] private int timeToEnd;


    private void Awake()
    {
        if (Instance == null)
            Instance  = this;
    }

    private void Start()
    {
        InvokeRepeating(nameof(Stopper), 0, 1);
    }

    private void Stopper()
    {
        timeToEnd--;
        Debug.Log(timeToEnd);
    }
}
