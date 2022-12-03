using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GameState { MainMenu, Pause, Play }
public delegate void OnStateChangeHandler();

public class GameManager : MonoBehaviour
{

    public event OnStateChangeHandler OnStateChange;
    [System.Obsolete("Use Inventory.gold instead")]
    public int gold; 
    public GameState gameState { get; private set; }
    private Sqlite sqlite;

    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("Game Manager is null!");
            }

            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
        if (sqlite == null)
        {
            sqlite = this.gameObject.GetComponent<Sqlite>();
        }

        sqlite.InitializeDatabase();
    }

    public void SetGameState(GameState state)
    {
        this.gameState = state;
        OnStateChange();
    }

    void OnApplicationQuit()
    {
        Debug.Log("Application end, update data to database");
        //sqlite.on

    }

}
