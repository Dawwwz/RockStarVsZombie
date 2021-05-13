using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Hud : MonoBehaviour
{
    [Header("SitemTOhelp")]


    [SerializeField] private CoinManager coinManager;
    [SerializeField] private LeafControler leafControler;
    [SerializeField] private RockMode rockMode;
    [SerializeField] private Pet pet;
    [SerializeField] private LevelManager levelManager;

    [Header("Hud")]
    [SerializeField] private GameObject zombieOutOfScreen;
    [SerializeField] private Image timerImg;
    [SerializeField] private Text timerTxt;

    [SerializeField] private Text ballPowerImpulse;
    
    [SerializeField] private GameObject[] zombieHeadTransform;
    [SerializeField] private GameObject btnDog; 

    [SerializeField] private Text Rockmode;
    [SerializeField] private GameObject winPanel,losePanel,pausePanel;
    [SerializeField] private Text coinTxt;
    [SerializeField] private Text levelInfo;

    [SerializeField] private Image arrowBG;
    [SerializeField] private Image arrowBGs;
    [SerializeField] private Image arrobackground;
    public static int zombienaTela; /// otimizar 
    private void Awake()
    {
        
        arrowBG = GameObject.Find("Img_ArrowBG").GetComponent<Image>();
    }
    void Start()
    {

        coinManager = FindObjectOfType<CoinManager>();
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
        coinTxt.text = coinManager.Get_Ephemeral().ToString();
        levelInfo.text = levelManager.scenaAtualString;
        timerTxt.text = levelManager.Get_Time().ToString();
    }
    public void GameWin()
    {
        if (levelManager.gameWin)
        {

            // Time.timeScale = 0;
           // AudioManager.audioManager.guitarBGAS.volume = 0;
            coinManager.CoinSave();
            //pausePanel.SetActive(false);
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

           // AudioManager.audioManager.guitarBGAS.volume = 0;
            Time.timeScale = 1;
            losePanel.SetActive(false);
            winPanel.SetActive(false);
            pausePanel.SetActive(false);
            SceneManager.LoadScene("Level" + (levelManager.scenaAtualInt +1));
        
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
        animbtndogg();
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
    public void Set_rockMOdeUI(int lalas)
    {
        for(int i = 0; i < lalas; i++)
        {
        if(i < 10)
            {
               zombieHeadTransform[i].SetActive(true);
            }
        }
    }
    public void Set_rockMOdeUIF()
    {
        for (int i = 0; i < 10; i++)
        {
            zombieHeadTransform[i].SetActive(false);
        }
    }
    public void ArrowBGG(Sprite lala)
    {
         arrobackground.sprite = lala;
    }

    public void animbtndog()
    {
        
        btnDog.GetComponent<Animator>().SetBool("andando", true);
        btnDog.GetComponent<Animator>().SetBool("parado", false);
    }
    public void animbtndogg()
    {
        
        btnDog.GetComponent<Animator>().SetBool("andando", false);
        btnDog.GetComponent<Animator>().SetBool("parado", true);
    }
}
