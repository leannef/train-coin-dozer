using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Souvenir", menuName = "SouvenirList")]
public class SouvenirList : ScriptableObject
{
    [SerializeField] public List<Souvenir> souvenirList;
    //[SerializeField] public SceneHandle sceneHandle;
    //public bool isUnlocked => IsMapUnlocked();
    public static SouvenirList LoadTrackList(List<Souvenir> souvenirList)
    {
        return (SouvenirList)Resources.Load("/Souvenir/SouvenirList/" + souvenirList);
    }
}
