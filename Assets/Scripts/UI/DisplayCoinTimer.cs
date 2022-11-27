using TMPro;
using UnityEngine;

public class DisplayCoinTimer : MonoBehaviour
{
    public TMP_Text coinTimerLabel;

    private void Update()
    {
        coinTimerLabel.text = "Next in " + Mathf.CeilToInt(GameManager.Instance.coinRechargeTimeLeft).ToString();
    }
}
