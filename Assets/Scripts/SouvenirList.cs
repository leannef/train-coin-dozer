using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Souvenir", menuName = "SouvenirList")]
public class SouvenirList : ScriptableObject
{
    [SerializeField] public List<Souvenir> souvenirList;
    //[SerializeField] public SceneHandle sceneHandle;
    //public bool isUnlocked => IsMapUnlocked();
    public static SouvenirList GetWithCountry(Country country)
    {
        switch (country)
        {
            case Country.Japan:
                return (SouvenirList)Resources.Load("SriptableObjects/Souvenir/SouvenirList/JapanSouvenirs");
            case Country.Europe:
                return null;
        }
        return null;
    }
}
