using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTimer : MonoBehaviour
{
    void Update()
    {
        RecchargeCoin();
    }

    private void RecchargeCoin()
    {
		GameManager.Instance.coinRechargeTimeLeft -= Time.deltaTime;

		if (GameManager.Instance.coinRechargeTimeLeft <= 0.0f)
		{
			GameManager.Instance.coinRechargeTimeLeft = GameManager.Instance.rechargeTime;

			if (GameManager.Instance.gold < GameManager.maxGold)
			{
				GameManager.Instance.gold++;
			}
		}
	}
}
