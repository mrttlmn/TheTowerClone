using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetCoin : MonoBehaviour
{
    public Text text;
    public int coin;
    void Start()
    {
        if (PlayerPrefs.GetInt("GameSetBefore") == 1)
        {
           
            coin = PlayerPrefs.GetInt("coin");
        }
        else
        {
            PlayerPrefs.SetInt("coin", 50);
            coin = PlayerPrefs.GetInt("coin");
        }
        text.text = coin.ToString();
    }

   
}
