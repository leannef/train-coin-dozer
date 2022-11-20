using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotContainer : MonoBehaviour
{
    public float speed = 3f;
    private float originXaxis; 

    void Start()
    {
        originXaxis = transform.position.x; 
    }

    void Update()
    {
        transform.position = new Vector3(Mathf.PingPong(Time.time * 2, originXaxis+speed - originXaxis) + originXaxis, transform.position.y, transform.position.z);
    }

    void OnTriggerEnter(Collider collider)
    {
        Destroy(collider.gameObject);
        //TODO: add rewards to Player Inventory;
    }
}
