using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCoin : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {

        if (col.CompareTag("coin"))
        {
            GameManager.Instance.gold += 1;
            Destroy(col.gameObject, 0.5f);
        }
        else
        {
            Debug.Log("nothing");
        }
    }
}
