using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.CoreUtils;

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

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "coin")
        {
            Debug.Log("Got Coin!");
            var rnd = new System.Random();
            int proceed = rnd.Next(8);
            //int proceed = 1;
            if (proceed == 1)
            {
                GameManager.Instance.SetGameState(GameState.Loading);
                GameManager.Instance.popupManager.loadingText.text = "You win ! Next Station Unlocked!";
                GameManager.Instance.popupManager.loadingScreen.SetActive(true);
                StationList stations = StationList.GetWithCountry(Country.Japan);
                Station next = stations.stationList[Player.station.level - 1];
                Player.UpdateStation(Player.station, next);
            }
            StartCoroutine(WaitAndProceed(2f));
        }

        if (other.tag == "Souvenir")
        {
            Debug.LogWarning("TODO: Add Souvenir to player inventory");
        }
        Destroy(other.gameObject);
    }
    private IEnumerator WaitAndProceed(float waitTime)
    {

        yield return new WaitForSeconds(waitTime);
        GameManager.Instance.SetGameState(GameState.MainMenu);
        GameManager.Instance.popupManager.loadingScreen.SetActive(false);
        GameManager.Instance.popupManager.MapMenu.SetActive(true);
        GameManager.Instance.popupManager.ThreeDMap.SetActive(true);
        
    }
}
