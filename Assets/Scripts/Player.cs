using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    //Initailly Loaded from Opening Application
    private static int _id;
    public static int id
    {
        get { return _id; }
        set { _id = value; }
    }

    private static int _gold;
    public static int gold
    {
        get { return _gold; }
        set { _gold = value; }
    }

    public static Dictionary<Souvenir, int> souvenirtItems;
    // int => type of PowerUp
    public static Dictionary<PowerUp, int> powerupItems;
    public static Dictionary<Station, string> stationDict;
    public static Station station;
    public static void GrantGold()
    {
        gold++;
    }

    public static void ConsumeGold()
    {
        if (gold > 0)
        {
            gold--;
        }
        else
        {
            gold = 0;
        }
    }
    public static void UpdateStation(Station curr, Station next)
    {
        curr.isFinished = true;
        next.isLocked = true;
        next.isFinished = false;
        if (!stationDict.ContainsKey(next))
            stationDict.Add(next, next.shortname);
    }
    public static void GrantSouvenir()
    {

    }

    public static void GrantPowerUp()
    {

    }

    public void ConsumePowerUp()
    {

    }
}
