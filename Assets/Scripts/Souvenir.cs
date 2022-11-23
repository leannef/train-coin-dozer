using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Souvenir", menuName = "Souvenir")]
public class Souvenir : ScriptableObject
{
    public string shortname = "";
    public GameObject appearence;
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

    public static Souvenir WithShortname(string shortname)
    {
        return (Souvenir)Resources.Load("SriptableObjects/Souvenir/" + shortname);
    }
}
