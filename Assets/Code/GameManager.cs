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
    public bool leafCanSpawn;
    public bool leafCatch;
    public string leafLevel;
    public GameObject[] leaf;
    public int zombiesAmount;

    // HUD 
    public bool gameLose,gameWin,gameIsPlaying,gamePause;

    // Rastrear
    public string scenaEmQueEstou;
    public int levelBtnRef;
    

   
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

    public void OndeEstou()
    {

    }
   public void UpdateLeaf()
    {
        if (leafCatch)
        {

            leafCatch = false;
                switch (leafLevel)
                {
                    case "Level2":
                        PlayerPrefs.SetInt("Level2", 1);
                        
                        break;
                    case "Level3":
                        PlayerPrefs.SetInt("Level3", 1);
                        break;
                    case "Level4":
                        PlayerPrefs.SetInt("Level4", 1);
                        break;
                    case "Level5":
                        PlayerPrefs.SetInt("Level5", 1);
                        break;
                    case "Level6":
                        PlayerPrefs.SetInt("Level6", 1);
                        break;

                    case "Level7":
                        PlayerPrefs.SetInt("Level7", 1);
                        break;
                    case "Level8":
                        PlayerPrefs.SetInt("Level8", 1);
                        break;

                    case "Level9":
                        PlayerPrefs.SetInt("Level9", 1);
                        break;
                    case "Level10":
                        PlayerPrefs.SetInt("Level10", 1);
                        break;
                   
                }
        }
    }
}
