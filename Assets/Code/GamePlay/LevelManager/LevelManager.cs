using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    public static LevelManager levelManager;
    [SerializeField] private LeafControler leafControler;
    [SerializeField] private Hud hud;
    public string scenaAtualString;
    public int scenaAtualInt;
    public int[] levelAtual = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    public bool gameLose, gameWin, gameIsPlaying, gamePause;
    public float time;
    // Start is called before the first frame update
    void Awake()
    {
        if(levelManager == null)
        {
            levelManager = this;
        }

    }
    void Start()
    {
        hud = FindObjectOfType<Hud>();
        scenaAtualString = SceneManager.GetActiveScene().name;

        for(int i = 0; i < levelAtual.Length; i++)
        {
            if(SceneManager.GetActiveScene().name == "Teste" + i)
            {
                scenaAtualInt = i;
                scenaAtualString = SceneManager.GetActiveScene().name;
            }
        }
    }
    private void FixedUpdate()
    {
        Timer();
        Win();
    }
    public void Set_Win_Game(bool win)
    {
        gameWin = win;
    }
    public void Set_Lose_Game(bool win)
    {
        gameLose = win;
    }
    public void LoseGame()
    {
        if (levelManager.gameLose)
        {
            Time.timeScale = 0;
           // AudioManager.audioManager.guitarBGAS.volume = 0;

            time = 360;
           // UnityAddss.instance.ChamandoAdd();
            hud.Set_Lose_Game();
        }
    }
    public void Timer()
    {
        if (time >= 0)
        {
            time -= 1 * Time.deltaTime;
            hud.Set_Timer(time);
        }
    }
    public float Get_Time()
    {
        return time;
    }
    void Win()
    {
        if (levelManager.Get_Time() <= 0 && Hud.zombienaTela == 0)
        {
            Set_Win_Game(true);
            
            GameObject[] verLeaf = GameObject.FindGameObjectsWithTag("leaf");
            if (verLeaf.Length == 0)
            {
                if (PlayerPrefs.GetInt("Level2") == 1)
                {
                    GameWin_LevelProgress();
                    hud.GameWin();
                }
                else if (PlayerPrefs.GetInt("freelevel" + 2) == 0)
                {
                    GameObject[] verMoeda = GameObject.FindGameObjectsWithTag("Coin");
                    if (verMoeda.Length == 0)
                    {
                        GameWin_LevelProgress();
                        hud.GameWin();
                    }
                }
            }
        }
    }
    public void GameWin_LevelProgress()
    {
        if (levelManager.gameWin)
        {
            foreach (LevelManeger.Level level in LevelManeger.instance.levelList)
            {
                if (level.levelTxt == levelManager.scenaAtualInt + 1)             /// GAME MANAGER SAVE THIS INFORMATION
                {                                                                /// NÃO TEM INDEPENDENCIA POR CONTA DO LEVEL MANAGER
                    level.freeLevel = true;
                    PlayerPrefs.SetInt("freelevel" + level.levelTxt, 1);
                }
            }
            //end
            if (PlayerPrefs.GetInt("Teste" + levelManager.scenaAtualInt) == 0)
            {

                leafControler.UpdateLeaf();
            }
        }
    }
}
