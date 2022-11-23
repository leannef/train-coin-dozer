using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PowerUp", menuName = "PowerUp")]
public class PowerUp : ScriptableObject
{
    public string shortname = "";
    public Sprite icon;
    public PowerUps type;

    public bool isValid
    {
        get
        {
            bool valid = (icon != null);
            return valid;
        }
    }

    public static PowerUp WithShortname(string shortname)
    {
        return (PowerUp)Resources.Load("SriptableObjects/PowerUp/" + shortname);
    }
}