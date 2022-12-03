using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickArea : MonoBehaviour
{
	public GameObject coinPrefab;
	public float height;

    private void OnMouseDown()
	{
        if (GameManager.Instance.gold > 0)
        {
            AddCoinOnUserClicked();
            GameManager.Instance.gold--;
        }
    }
    public void AddCoinOnUserClicked()
	{
        /*      IsPlayerAllowed to click? (player not allowed to click to frequently)
                then is playercoin > 0 ?*/

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            Instantiate(coinPrefab,
                         new Vector3(hit.point.x, height, hit.point.z),
                         Quaternion.identity);

            //Reduce coin in the inventory
        }
    }
}
