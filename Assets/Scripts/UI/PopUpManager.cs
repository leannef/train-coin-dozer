using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpManager : MonoBehaviour
{
    public GameObject MapMenu;
    public GameObject SouvenirMenu;
    public GameObject HUD;

    void Start()
    {
        MapMenu.SetActive(false);
        SouvenirMenu.SetActive(false);
        HUD.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenMap()
    {
        MapMenu.SetActive(true);
        HUD.SetActive(false);
    }

    public void OpenSouvenirMenu()
    {
        SouvenirMenu.SetActive(true);
        HUD.SetActive(false);
    }

    public void Close(GameObject obj)
    {
        obj.SetActive(false);
        HUD.SetActive(true);
    }
}
