using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public float coin, coinEphemeral;//Ephemeral SEMPRE SETAR PARA 0 QUANDO SAIR DA FAZE
    public float gameplayCoin;
    
    // Start is called before the first frame update
    private void Start()
    {
        CoinUpdate();
        coin = PlayerPrefs.GetFloat("Coin");
    }
    public void CoinStartValue()
    {
        if (!PlayerPrefs.HasKey("Coin"))
        {
            coinEphemeral = 1000000;
            CoinSave();
        }
    }
    public void CoinIncreaseGameplay(float coinValue)
    {
        coinEphemeral += coinValue;
    }
    public void CoinIncrease(float coinValue)
    {
        coinEphemeral += coinValue;
        CoinSave();
    }
    public void CoinDecrease(float coinValue)
    {
        coinEphemeral -= coinValue;
        CoinSave();
    }
    public void CoinUpdate()
    {

        coin = PlayerPrefs.GetFloat("Coin");
    }

    public void CoinSave()
    {
        coin += coinEphemeral;
        PlayerPrefs.SetFloat("Coin", coin);
        coinEphemeral = 0;

    }
    public float Get_Ephemeral()
    {
        return coinEphemeral;
    }
    public float Get_coin()
    {
        return coin;
    }
}
