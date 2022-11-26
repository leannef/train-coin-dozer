using System;
using UnityEngine;


public enum GameState { MainMenu, Pause, Play }
public delegate void OnStateChangeHandler();

public class GameManager : MonoBehaviour
{

    public event OnStateChangeHandler OnStateChange;
    public GameState gameState { get; private set; }
    public int gold;
    public DateTime lastVisit;
    public Sqlite database;

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
        gold = 50;
    }

    public void SetGameState(GameState state)
    {
        this.gameState = state;
        OnStateChange();
    }

}
