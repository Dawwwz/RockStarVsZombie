using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_Menu : MonoBehaviour
{
    public Text menuLevelCoin;

    [SerializeField] private AudioManager audioScript;
    //StartSCreen

    public GameObject startScreen;

    // STARTMENU
    [Header("START MENU")]
    public GameObject menu_MainScren;


    // Settings 
    [Header("SETTINGS")]
    public GameObject settings;
    public GameObject audioEffect;
    public Sprite[] audioImg;
    public bool somAtivadoOrDesativado;
    public GameObject panelANim;

    // credtius 
    [Header("CREDITUS")]
    public GameObject cretiusMenu;

    // MenuLevel
    [Header("MENU LEVEL")]
    public GameObject menuLevel;

    [Header("MENU ATTRIBUTES")]
    public GameObject menu_Attributes;
    // MenuStore
    [Header("MENU STORE")]
    public GameObject menuStore;
    public GameObject menu_Store_Ball;
    public GameObject menu_Store_Guitar;
    



    









    void Start()
    {
        audioScript = FindObjectOfType<AudioManager>();
        UpdateUICoin();
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void FixedUpdate()
    {
        UpdateUICoin();
    }
    void UpdateUICoin()
    {
        menuLevelCoin.text = PlayerPrefs.GetFloat("Coin").ToString();
        

    }

    public void MenuMainScreen()
    {
        UpdateUICoin();
        cretiusMenu.SetActive(false);
        menuLevel.SetActive(false);
        menu_Attributes.SetActive(false);
        menuStore.SetActive(false);
        menu_Store_Ball.SetActive(false);
        menu_Store_Guitar.SetActive(false);

        menu_MainScren.SetActive(true);
        settings.SetActive(true);
       
    }
    public void Store()
    {
        UpdateUICoin();
        menu_MainScren.SetActive(false);
        settings.SetActive(false);
        cretiusMenu.SetActive(false);
        menuLevel.SetActive(false);
        menu_Attributes.SetActive(false);
       
        menu_Store_Ball.SetActive(false);
        menu_Store_Guitar.SetActive(false);
       
        menuStore.SetActive(true);
    }
    public void MenuLevel()
    {
        UpdateUICoin();
        menu_MainScren.SetActive(false);
        settings.SetActive(false);
        cretiusMenu.SetActive(false);
        menuLevel.SetActive(true);
        menu_Attributes.SetActive(false);
        menuStore.SetActive(false);
        menu_Store_Ball.SetActive(false);
        menu_Store_Guitar.SetActive(false);
   
    }
    public void MenuAttribute()
    {
        UpdateUICoin();
        menu_MainScren.SetActive(false);
        settings.SetActive(false);
        cretiusMenu.SetActive(false);
        menuLevel.SetActive(false);
        menu_Attributes.SetActive(true);
        menuStore.SetActive(false);
        menu_Store_Ball.SetActive(false);
        menu_Store_Guitar.SetActive(false);
       
    }
    public void MenuStoreBall()
    {
        UpdateUICoin();
        menu_MainScren.SetActive(false);
        settings.SetActive(false);
        cretiusMenu.SetActive(false);
        menuLevel.SetActive(false);
        menu_Attributes.SetActive(false);
        menuStore.SetActive(false);
        menu_Store_Ball.SetActive(true);
        menu_Store_Guitar.SetActive(false);
       
    }
    public void MenuStoreGuitar()
    {
        UpdateUICoin();
        menu_MainScren.SetActive(false);
        settings.SetActive(false);
        cretiusMenu.SetActive(false);
        menuLevel.SetActive(false);
        menu_Attributes.SetActive(false);
        menuStore.SetActive(false);
        menu_Store_Ball.SetActive(false);
        menu_Store_Guitar.SetActive(true);
        
    }
  
    public void Settings ()
    {
        if (panelANim.activeInHierarchy)
        {
            panelANim.SetActive(false);
        } else if (!panelANim.activeInHierarchy)
        {
            panelANim.SetActive(true);
        }
        
    }
    public void Sound()
    {
        if (audioScript.guitarBGAS.mute)
        {
            audioScript.UnMute();
            audioEffect.GetComponent<Image>().sprite = audioImg[1];
        }
        else
        {
            audioScript.Mute();
            audioEffect.GetComponent<Image>().sprite = audioImg[0];
        }
    }

    public void Creditus()
    {
        menuStore.SetActive(false);
        menu_MainScren.SetActive(false);
        settings.SetActive(false);
        cretiusMenu.SetActive(true);
        menuLevel.SetActive(false);
        menu_Attributes.SetActive(false);
        menuStore.SetActive(false);
        menu_Store_Ball.SetActive(false);
        menu_Store_Guitar.SetActive(false);
        
    }
}
