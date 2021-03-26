using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManeger : MonoBehaviour
{
    public static LevelManeger instance;
    [System.Serializable]
    public  class Level
    {
         
         public int levelTxt ;
         public bool freeLevel ;
        
    }
    public GameObject btnLevel;
    public Transform   btnLocal;
    public List<Level> levelList = new List<Level>();
    public  List<GameObject> level_GO = new List<GameObject>();
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        //SceneManager.sceneLoaded += ListAdd;  ListAdd( Scene cena , LoadSceneMode modo) FAZ OS BOTOES FICAREM CRIADOS SEMPRE NA SCENA
    }
    void Start()
    {

        ListAdd();
    }
   public void ListAdd( )
    {
        foreach (Level level in levelList)
        {  
            Text txtBtnLevel = btnLevel.transform.GetChild(1).GetComponent<Text>();
            txtBtnLevel.text = level.levelTxt.ToString();
            GameObject btnLevelNew = Instantiate(btnLevel) as GameObject;
            int a = level.levelTxt;
            ++a;
            
            if(PlayerPrefs.GetInt("freelevel"+level.levelTxt)== 1)
            {
                level.freeLevel = true;
            }
            if (PlayerPrefs.GetInt("Level"+a) == 1)
            {
           
                     Image leaff =    btnLevelNew.transform.GetChild(0).GetComponent<Image>();
                     leaff.color = new Color(leaff.color.r, leaff.color.b, leaff.color.g, 255);
       
            }
            a--;
            btnLevelNew.GetComponent<Button>().interactable = level.freeLevel;
            btnLevelNew.GetComponent<Button>().onClick.AddListener(() => LevelSelect("Level"+level.levelTxt,level.levelTxt));
            btnLevelNew.transform.SetParent(btnLocal, false);
            level_GO.Add(btnLevelNew);
        }  
    }
           
     public void LevelSelect(string level,int levelN)
    {
        
        SceneManager.LoadScene(level);
        LevelManager.levelManager.scenaAtualString = level;
        levelN++;
        LevelManager.levelManager.scenaAtualInt = levelN;

    }
   
}
