using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;
using System.Threading;

public class Hud : MonoBehaviour
{
    public static Hud instance;
    public GameObject zombieOutOfScreen;
    public Image timerImg;
    public Text timerTxt;
    public float time;
    public int aondeqeuto;
    public Text ballPowerImpulse;
    public Text CoinEpheremal;
    public Text CoinEthernal;
    public Text Result;
    public Text Rockmode;
    public GameObject winPanel,losePanel,pausePanel;
    public Text coinTxt;
    public Text levelInfo;


    public static int zombienaTela;
    void Start()
    {
        time = 180;
        if (instance == null)
        {
            instance = this;
        }

        AttHuds();
        GameManager.instanceGameManager.scenaEmQueEstou = SceneManager.GetActiveScene().name;
        GameManager.instanceGameManager.levelBtnRef = SceneManager.GetActiveScene().buildIndex;
        if (GameManager.instanceGameManager.levelBtnRef == SceneManager.GetActiveScene().buildIndex)
        {
        int a = SceneManager.GetActiveScene().buildIndex;
        a++;
        GameManager.instanceGameManager.levelBtnRef = a;
        }
        AttHuds();
    }

   
    void FixedUpdate ()
    {
        Timer();
        if (GameManager.instanceGameManager.gameWin)
        {
         GameWin();

        }else if (GameManager.instanceGameManager.gameLose && !GameManager.instanceGameManager.gameWin)
        {
         LoseGame();
        }
        VerificarZombie();
        AttHuds();

    }


    // HUd Score
    public void AttHuds()
    {
        coinTxt.text = GameManager.instanceGameManager.coinEphemeral.ToString();
        levelInfo.text = GameManager.instanceGameManager.scenaEmQueEstou;
        Rockmode.text = "Hits"+ Player.rockModeCount.ToString();

    }

    //  Hud Menus
    public void LoseGame()
    {
        if (GameManager.instanceGameManager.gameLose)
        {

            if (PlayerPrefs.GetInt("Level" + GameManager.instanceGameManager.levelBtnRef) == 0 )
            {
                GameManager.instanceGameManager.leafCanSpawn = true;


            }

            Time.timeScale = 0;
            Player.rockModeCount = 0;
            AudioManager.audioManager.guitarBGAS.volume = 0;
            GameManager.instanceGameManager.zombiesAmount = 0;
            time = 360;
            pausePanel.SetActive(false);
            losePanel.SetActive(true);
            UnityAddss.instance.ChamandoAdd();
        }
    }
    public void GameWin()
    {
        if (GameManager.instanceGameManager.gameWin)
        {
           foreach(LevelManeger.Level level in LevelManeger.instance.levelList)
            {
                                   
                if ( level.levelTxt == GameManager.instanceGameManager.levelBtnRef)
                {
                    level.freeLevel = true;
                    PlayerPrefs.SetInt("freelevel" + level.levelTxt, 1);
                }         
            }

            if (PlayerPrefs.GetInt("Level" + GameManager.instanceGameManager.levelBtnRef) == 0)
            {
                GameManager.instanceGameManager.leafCanSpawn = true;
               

            }
            if (GameManager.instanceGameManager.leafCatch)
            {
                GameManager.instanceGameManager.UpdateLeaf();
            }
        
            coinTxt.text = PlayerPrefs.GetFloat("Coin").ToString();

            Time.timeScale = 0;
            Player.rockModeCount = 0;
            AudioManager.audioManager.guitarBGAS.volume = 0;
            GameManager.instanceGameManager.zombiesAmount = 0;
            CoinEpheremal.text = GameManager.instanceGameManager.coinEphemeral.ToString();
            CoinEthernal.text = GameManager.instanceGameManager.coin.ToString();
            Result.text = PlayerPrefs.GetFloat("Coin").ToString();
            GameManager.instanceGameManager.CoinSave();
            time = 360;
            pausePanel.SetActive(false);
            winPanel.SetActive(true);
        }
    }
    // Hud Buttons
    public void OpenMenu()
    {
        if (PlayerPrefs.GetInt("Level"+GameManager.instanceGameManager.levelBtnRef) == 0)
        {
            GameManager.instanceGameManager.leafCanSpawn = true;
        } 
        GameManager.instanceGameManager.zombiesAmount = 0;
        int scene = SceneManager.GetActiveScene().buildIndex;
        GameManager.instanceGameManager.gameLose = false;
        GameManager.instanceGameManager.gameWin = false;
        Time.timeScale = 1;
        Player.rockModeCount = 0;
        AudioManager.audioManager.guitarBGAS.volume = 0;
        AudioManager.audioManager.SoundBG(5);
        losePanel.SetActive(false);
        winPanel.SetActive(false);
        pausePanel.SetActive(false);
        SceneManager.LoadScene(11);
    }
    public void RestartLevel(int scene)
    {

        if (PlayerPrefs.GetInt("Level" + GameManager.instanceGameManager.levelBtnRef) == 0)
        {    
            GameManager.instanceGameManager.leafCanSpawn = true;   
        }
        scene = SceneManager.GetActiveScene().buildIndex;
        Time.timeScale = 1;
        Player.rockModeCount = 0;
        AudioManager.audioManager.guitarBGAS.volume = 0;
        losePanel.SetActive(false);
        winPanel.SetActive(false);
        pausePanel.SetActive(false);
        GameManager.instanceGameManager.gameLose = false;
        SceneManager.LoadScene(scene);
    }
    public void NextLevel()
    {
        if (PlayerPrefs.GetInt("Level"+GameManager.instanceGameManager.levelBtnRef) == 1)
        {
            GameManager.instanceGameManager.leafCanSpawn = true; 
        }
        if(PlayerPrefs.GetInt("freelevel"+ GameManager.instanceGameManager.levelBtnRef) == 1)
        {
            GameManager.instanceGameManager.gameWin = false;
            GameManager.instanceGameManager.gameLose = false;  
            time = 360;
            GameManager.instanceGameManager.zombiesAmount = 0;
            Player.rockModeCount = 0;
            AudioManager.audioManager.guitarBGAS.volume = 0;
            Time.timeScale = 1;
            losePanel.SetActive(false);
            winPanel.SetActive(false);
            pausePanel.SetActive(false);
            SceneManager.LoadScene("Level" + GameManager.instanceGameManager.levelBtnRef);
        }
    }
    public void GamePause()
    {
       GameManager.instanceGameManager.gamePause = true;
        if (GameManager.instanceGameManager.gamePause)
        {
            Time.timeScale = 0;

            pausePanel.SetActive(true);
        }
    }
    public void GameUnPause()
    {
        GameManager.instanceGameManager.gamePause = false;
        if (!GameManager.instanceGameManager.gamePause)
        {
            Time.timeScale = 1;
            pausePanel.SetActive(false);
        }
    }


    public void Timer()
    {
        if (time >= 0)
        {
            time -= 1 *Time.deltaTime;
            timerTxt.text = Mathf.Round(time).ToString();
            timerImg.fillAmount =  time / 180;
        }
    }
    public void VerificarZombie()
    {
        GameObject[] ver = GameObject.FindGameObjectsWithTag("inimigo");
        zombienaTela = ver.Length;
        for(int i = 0; i < ver.Length; i++)
        {
            if(ver[i] != null)
            {

               if( ver[i].transform.position.x > 9)
                {
                    zombieOutOfScreen.SetActive(true);
                }
                else
                {
                    zombieOutOfScreen.SetActive(false);
                }
            }
        }

      

    }
}
