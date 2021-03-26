using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public  class GameManager : MonoBehaviour
{
    public static GameManager instanceGameManager;
    
    // ECONOMIA
    public float coin , coinEphemeral ;//Ephemeral SEMPRE SETAR PARA 0 QUANDO SAIR DA FAZE

   

   
    // condition win 
   
 
    public int zombiesAmount;
 
    public float power = 100 ;
    public float CD = 100;
    


    
    void Awake()
    {
        if (instanceGameManager == null)
        {
            instanceGameManager = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        coinEphemeral = 1000000;
        CoinSave();
       // CoinStartValue();
        CoinUpdate();

    }
    //Coin Manager
    public void CoinStartValue()
    {
        if (!PlayerPrefs.HasKey("Coin"))
        {
            coinEphemeral = 1000000;
            CoinSave();
        }
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
 
}
