using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Hud : MonoBehaviour
{
    [Header("SitemTOhelp")]
   
    public static Hud instance;

    [SerializeField] private LeafControler leafControler;
    [SerializeField] private RockMode rockMode;
    [SerializeField] private Pet pet;
    [SerializeField] private LevelManager levelManager;

    [SerializeField] private GameObject zombieOutOfScreen;
    [SerializeField] private Image timerImg;
    [SerializeField] private Text timerTxt;

    [SerializeField] private Text ballPowerImpulse;

    [SerializeField] private Text Rockmode;
    [SerializeField] private GameObject winPanel,losePanel,pausePanel;
    [SerializeField] private Text coinTxt;
    [SerializeField] private Text levelInfo;

    [SerializeField] private Image arrowBG;
    [SerializeField] private Image arrowBGs;

    public static int zombienaTela; /// otimizar 
    private void Awake()
    {
        arrowBG = GameObject.Find("Img_ArrowBG").GetComponent<Image>();
    }
    void Start()
    {
        
        if (instance == null)
        {
            instance = this;
        }
        levelManager = FindObjectOfType<LevelManager>();
        leafControler = FindObjectOfType<LeafControler>();
        rockMode = FindObjectOfType<RockMode>();
        pet = FindObjectOfType<Pet>();

    }
    void FixedUpdate ()
    {
        AttHuds();
        Set_Zombie_Out_Of_Screen();
    }
    public void AttHuds()
    {
      ///  coinTxt.text = GameManager.instanceGameManager.coinEphemeral.ToString();
        levelInfo.text = levelManager.scenaAtualString;
        Rockmode.text = "Hits" + rockMode.Get_Head_Shot_count();
        timerTxt.text = levelManager.Get_Time().ToString();
    }
    public void GameWin()
    {
        if (levelManager.gameWin)
        {
            coinTxt.text = PlayerPrefs.GetFloat("Coin").ToString();            Time.timeScale = 0;
           // AudioManager.audioManager.guitarBGAS.volume = 0;
           // CoinEpheremal.text = GameManager.instanceGameManager.coinEphemeral.ToString();
           // CoinEthernal.text = GameManager.instanceGameManager.coin.ToString();
           // GameManager.instanceGameManager.CoinSave();
            pausePanel.SetActive(false);
            winPanel.SetActive(true);
        }
    }
    public void OpenMenu()
    {
        Time.timeScale = 1;
       // AudioManager.audioManager.guitarBGAS.volume = 0;
       // AudioManager.audioManager.SoundBG(5);
        losePanel.SetActive(false);
        winPanel.SetActive(false);
        pausePanel.SetActive(false);
        SceneManager.LoadScene("UI_Menu");
    }
    public void RestartLevel()
    {
        Time.timeScale = 1;
        //AudioManager.audioManager.guitarBGAS.volume = 0;
        losePanel.SetActive(false);
        winPanel.SetActive(false);
        pausePanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void NextLevel()
    {
        if(PlayerPrefs.GetInt("freelevel"+ levelManager.scenaAtualInt+1) == 1)
        {
           // AudioManager.audioManager.guitarBGAS.volume = 0;
            Time.timeScale = 1;
            losePanel.SetActive(false);
            winPanel.SetActive(false);
            pausePanel.SetActive(false);
            SceneManager.LoadScene("Level" + levelManager.scenaAtualInt+1);
        }
    }
    public void GamePause()
    {
       levelManager.gamePause = true;
        if (levelManager.gamePause)
        {
            Time.timeScale = 0;

            pausePanel.SetActive(true);
        }
    }
    public void GameUnPause()
    {
        levelManager.gamePause = false;
        if (!levelManager.gamePause)
        {
            Time.timeScale = 1;
            pausePanel.SetActive(false);
        }
    }
    public void SetTxtBallPOwer(string a)
    {
        ballPowerImpulse.text = a;
    }
    public void Set_Zombie_Out_Of_Screen()
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
    public void Set_Lose_Game()
    {  
            pausePanel.SetActive(false);
            losePanel.SetActive(true);
    }
    public void Set_Btn_Pet()
    {
        pet.Set_IA_Pet_Avançar();
    }
    public void Set_Timer(float time)
    {
         timerTxt.text = Mathf.Round(time).ToString();
         timerImg.fillAmount = time / 180;
    }
    public Image Get_HItTarget_ArrowBG()
    {
        return arrowBG;
    }
    public Image Get_HItTarget_ArrowBGs()
    {
        return arrowBGs;
    }
}
