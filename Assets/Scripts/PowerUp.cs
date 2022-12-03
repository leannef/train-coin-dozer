using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PowerUp", menuName = "PowerUp")]
public class PowerUp : ScriptableObject
{
    public int type;
    public Sprite icon;

    public bool isValid
    {
        get
        {
            bool valid = (icon != null);
            return valid;
        }
    }

    public static PowerUp WithType(int type)
    {
        switch (type)
        {
            case 0: 
                return (PowerUp)Resources.Load("SriptableObjects/PowerUp/" + "");
            case 1:
                return (PowerUp)Resources.Load("SriptableObjects/PowerUp/" + "");
            case 2:
                return (PowerUp)Resources.Load("SriptableObjects/PowerUp/" + "");
            case 3:
                return (PowerUp)Resources.Load("SriptableObjects/PowerUp/" + "");
            case 4:
                return (PowerUp)Resources.Load("SriptableObjects/PowerUp/" + "");
            case 5:
                return (PowerUp)Resources.Load("SriptableObjects/PowerUp/" + "");
        }
        return null;
    }
}