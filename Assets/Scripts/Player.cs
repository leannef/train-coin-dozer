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

    public static void GrantGold()
    {

    }

    public static void ConsumeGold()
    {
   
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
