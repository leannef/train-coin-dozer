using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PusherController : MonoBehaviour
{
    public float megaDozerMultiplier =2f;
    private Vector3 origin;
    private Rigidbody rigidbody => GetComponent<Rigidbody>();
    // Update is called once per frame
    void Update()
    {
        Vector3 offset = new Vector3(0, 0, Mathf.Sin(Time.time));
        rigidbody.MovePosition(origin + offset* megaDozerMultiplier);
    }

    void Awake()
    {
        origin = rigidbody.transform.position;
        Debug.Log("Origin Pos: " + origin);
    }
}
