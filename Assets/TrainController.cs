using PathCreation;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UIElements;
using System;
public class TrainController : MonoBehaviour
{
    public EndOfPathInstruction endOfPathInstruction;
    private PathCreator trainPath;
    private float speed = 5.0f;
    private float distance;
    private bool isInTrainStation = false;
    private bool isFinishedMap = false;

    private void Start()
    {
        trainPath = this.transform.parent.GetComponent<PathCreator>();
        this.transform.position = trainPath.path.GetPoint(0);
    }
    void FixedUpdate()
    {    
        if(!isInTrainStation && !isFinishedMap)
        {
            distance += speed * Time.fixedDeltaTime;
            transform.position = trainPath.path.GetPointAtDistance(distance, endOfPathInstruction);
            transform.rotation = trainPath.path.GetRotationAtDistance(distance, endOfPathInstruction);
        }
    }
    void OnTriggerEnter(Collider collider)
    {
        Station station = collider.GetComponent<StationController>().station;
        if (!station.isFinished && !station.isLocked)
        {
            Debug.Log("In station");
            isInTrainStation = true;
            PopUpManager p = GameManager.Instance.popupManager;
            p.Close(p.MapMenu);
        }

        
    }
}