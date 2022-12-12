using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Station", menuName = "StationList")]
public class StationList : ScriptableObject
{
    [SerializeField] public List<Souvenir> stationList;
    //[SerializeField] public SceneHandle sceneHandle;
    //public bool isUnlocked => IsMapUnlocked();
    public static StationList GetWithCountry(Country country)
    {
        switch (country)
        {
            case Country.Japan:
                return (StationList)Resources.Load("SriptableObjects/Station/StationList/JapanStations");
            case Country.Europe:
                return null;
        }
        return null;
    }
}

