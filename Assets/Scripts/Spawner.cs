using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject coinTemplate;
    public GameObject souvenirTemplate;
    public Transform coinSpawnParent;
    public BoxCollider souvenirSpawner;

    private int maxSouvenir = 0; 

    void Start()
    {
        InvokeRepeating("SpawnSouvenir", 5.0f, 3f);
    }
    

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {            
            SpawnCoin();
        }
    }


    private void SpawnSouvenir()
    {
        if (maxSouvenir < 5)
        {
            Bounds colliderBounds = souvenirSpawner.bounds;
            Vector3 colliderCenter = colliderBounds.center;
            float randomX = Random.Range(colliderCenter.x - colliderBounds.extents.x, colliderCenter.x + colliderBounds.extents.x);
            float randomY = Random.Range(colliderCenter.y - colliderBounds.extents.y, colliderCenter.y + colliderBounds.extents.y);
            float randomZ = Random.Range(colliderCenter.z - colliderBounds.extents.z, colliderCenter.z + colliderBounds.extents.z);
            Vector3 randomPos = new Vector3(randomX, randomY, randomZ);

            GameObject newSouvenir;
            newSouvenir = Instantiate(souvenirTemplate, randomPos, Quaternion.identity);
            Physics.IgnoreCollision(newSouvenir.GetComponent<Collider>(), souvenirSpawner);
            maxSouvenir++;
        }
    }


    private void SpawnCoin()
    {
        //TODO: Coin falling animation 
        //TODO: Deduct Player gold count, update UI when deducted
        GameObject newCoin;
        newCoin = Instantiate(coinTemplate, coinSpawnParent);
        //TODO: Deduct Player Coin Count if not in power-up infinite coin type

    }
}
