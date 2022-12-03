using TMPro;
using UnityEngine;

public class DisplayCoinAmount : MonoBehaviour
{
    public TMP_Text coinsLabel;

    private void Update()
    {
        coinsLabel.text = GameManager.Instance.gold.ToString();
    }
}