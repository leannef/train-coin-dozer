using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject coinTemplate;
    public Transform spawnParent;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {            
            SpawnCoin();
        }
    }

    private void SpawnCoin()
    {
        //TODO: Coin falling animation 
        GameObject newCoin;
        newCoin = Instantiate(coinTemplate, spawnParent);
        //TODO: Deduct Player Coin Count if not in power-up infinite coin type

    }
}
