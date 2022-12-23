using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDozerController : MonoBehaviour
{
    public GameObject coinCollector;
    public GameObject pusher;
    public GameObject coinTemplate;
    public BoxCollider souvenirSpawner;

    private Country country;
    private int maxSouvenir = 0;
    private const float kSpeedPerSec = 1.5f;
    private bool isPushForward = true;
    private float curOffset, minOffset, maxOffset;
    private float maxOffsetDefault = 3.0f;

    Vector3 zeroOffset;
    void Start()
    {

        country = GameManager.Instance.country;
        zeroOffset = new Vector3(0.0f, 0.2f, -5.0f);

        minOffset = 0.1f;
        maxOffset = maxOffsetDefault;

        curOffset = minOffset;

        InvokeRepeating("SpawnSouvenir", 5.0f, 3f);


    }


    void Update()
    {
        if (GameManager.Instance.gameState == GameState.Play)
        {
            if (isPushForward)
            {
                curOffset += Time.deltaTime * kSpeedPerSec;

                if (curOffset >= maxOffset)
                {
                    curOffset = maxOffset;
                    isPushForward = false;
                }
            }
            else
            {
                curOffset -= Time.deltaTime * kSpeedPerSec;

                if (curOffset <= minOffset)
                {
                    curOffset = minOffset;
                    maxOffset = maxOffsetDefault;
                    isPushForward = true;
                }
            }

            pusher.GetComponent<Rigidbody>().MovePosition(zeroOffset + new Vector3(0, 0, curOffset));

        }
    }

    private void SpawnSouvenir()
    {
        if (GameManager.Instance.gameState == GameState.Play)
        {
            SouvenirList list = SouvenirList.GetWithCountry(country);
            var rnd = new System.Random();
            Souvenir template = list.souvenirList[rnd.Next(list.souvenirList.Count)];
            if (maxSouvenir < 5)
            {
                //Souvenir s = Souvenir.WithShortname();
                Bounds colliderBounds = souvenirSpawner.bounds;
                Vector3 colliderCenter = colliderBounds.center;
                float randomX = Random.Range(colliderCenter.x - colliderBounds.extents.x, colliderCenter.x + colliderBounds.extents.x);
                float randomY = Random.Range(colliderCenter.y - colliderBounds.extents.y, colliderCenter.y + colliderBounds.extents.y);
                float randomZ = Random.Range(colliderCenter.z - colliderBounds.extents.z, colliderCenter.z + colliderBounds.extents.z);
                Vector3 randomPos = new Vector3(randomX, randomY, randomZ);

                GameObject newSouvenir;
                newSouvenir = Instantiate(template.appearence, randomPos, Quaternion.identity);
                Physics.IgnoreCollision(newSouvenir.GetComponent<BoxCollider>(), souvenirSpawner, true);
                maxSouvenir++;
            }
        }
    }


}
