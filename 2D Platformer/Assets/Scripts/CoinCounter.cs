using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{

    public Text text;

    private void Update()
    {
        text.text = "Coins: " + Coin.coinCount;
    }


}
