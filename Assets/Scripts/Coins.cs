using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Coins : MonoBehaviour
{
    private const string COINS_TEXT = "Coins: ";

    public GameObject coinText;
    public int coinCount = 0;
    private TextMeshProUGUI textMeshProUGUI;
    private int CoinCount
    {
        get => coinCount;
        set
        {
            coinCount = value;
            SetCoinText(value);
        }
    }

    private void Start()
    {
        textMeshProUGUI = coinText.gameObject.GetComponent<TextMeshProUGUI>();
    }

    private void SetCoinText(int coins)
    {
        textMeshProUGUI.text = COINS_TEXT + coins;
    }

    public void AddCoin()
    {
        CoinCount++;
    }

    public void ResetCoins()
    {
        CoinCount = 0;
    }
}
