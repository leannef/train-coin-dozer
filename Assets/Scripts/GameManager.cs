using System;
using System.Collections.Generic;
using UnityEngine;


public enum GameState { MainMenu, Pause, Play }
public delegate void OnStateChangeHandler();

public class GameManager : MonoBehaviour
{
    public event OnStateChangeHandler OnStateChange;
    public float coinRechargeTimeLeft;

    public float rechargeTime = 60f;
    public GameState gameState { get; private set; }
    public int gold;
    public const int maxGold = 60;
    public DateTime lastVisit;
    public Sqlite database;
    public Country country => Country.Japan;
    public PopUpManager popupManager; 

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
        coinRechargeTimeLeft = rechargeTime;
        database.InitializeDatabase();
    }


    private void Start()
    {
        //foreach (KeyValuePair<Station, string> entry in Player.stationDict)
        //{
        //    string shortname = entry.Value;
        //    Station s = Station.WithShortname(shortname);
        //    s.isFinished = entry.Key.isFinished;
        //    s.isLocked = entry.Key.isLocked;
        //}
    }

    public void SetGameState(GameState state)
    {
        this.gameState = state;
        OnStateChange();
    }

}
