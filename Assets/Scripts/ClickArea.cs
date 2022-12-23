using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickArea : MonoBehaviour
{
	public GameObject coinPrefab;
	public float height;

    private void OnMouseDown()
	{
        if (Player.gold > 0)
        {
            AddCoinOnUserClicked();
            Player.gold--;
        }
    }
    public void AddCoinOnUserClicked()
	{
        /*      IsPlayerAllowed to click? (player not allowed to click to frequently)
                then is playercoin > 0 ?*/

        RaycastHit hit;
        Debug.Log(Input.mousePosition);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (hit.collider.gameObject.tag == "clickarea")
            {
                Instantiate(coinPrefab,
                         ray.origin,
                         Quaternion.identity);
            }
            //Reduce coin in the inventory
        }
    }
}
