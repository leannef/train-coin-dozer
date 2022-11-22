using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GameState { MainMenu, Pause, Play }
public delegate void OnStateChangeHandler();

public class GameManager : MonoBehaviour
{

    public event OnStateChangeHandler OnStateChange;
    public GameState gameState { get; private set; }
    public int gold;
    public DateTime lastVisit;

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
    }

    public void SetGameState(GameState state)
    {
        this.gameState = state;
        OnStateChange();
    }

}
