using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationController : MonoBehaviour
{
    public Station station;
    public bool isFinished => station.isFinished;
    public bool isLocked => station.isLocked;


}
