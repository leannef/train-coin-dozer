using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Station", menuName = "Station")]
public class Station : ScriptableObject
{
    public string shortname = "";
    public GameObject appearence;
    public bool isLocked;
    public bool isFinished;
    public Sprite icon;
    public Country country;

    public bool isValid
    {
        get
        {
            bool valid = (appearence != null) && (icon != null);
            return valid;
        }
    }

    public static Station WithShortname(string shortname)
    {
        return (Station)Resources.Load("SriptableObjects/Station/" + shortname);
    }
}
