using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Guitar_Store : MonoBehaviour
{
    public int guitar_ID;
    public Text guitar_Name;
    public Text guitar_Price;
    public Text guitar_Stats_Txt;
    public Text guitar_Descricao;
    public Image guitar_Img;
    public GameObject guitar_Btn;
    public Text descricao;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void btnBuyUpdate()
    {
        foreach(LojaManager.Guitar guitarStats in LojaManager.instance.guitar_Attribute_List)
        {
           
            if (guitar_ID == guitarStats.guitarID && GameManager.instanceGameManager.coin >= guitarStats.guitarPrice && !guitarStats.guitarBuy)
            {
                Debug.Log("oi");
                guitarStats.guitarBuy = true;
                PlayerPrefs.SetInt("GuitarBuy" + guitarStats.guitarID, 1);
                Debug.Log( guitarStats.guitarID);
                GameManager.instanceGameManager.CoinDecrease(guitarStats.guitarPrice);
                GameManager.instanceGameManager.CoinSave();
                UpdateBtn();
                
            } 
            else if(guitar_ID == guitarStats.guitarID && guitarStats.guitarBuy)
            {
                PlayerPrefs.SetInt("GuitarBuy" + guitarStats.guitarID, 1);
                UpdateBtn();
            }
           
        }
    }

    public void UpdateBtn()
    {
        foreach (GameObject guitar_GO in LojaManager.instance.guitar_GO_List)
        {
            Guitar_Store guitar_GO_Componets = guitar_GO.GetComponent<Guitar_Store>();
            foreach(LojaManager.Guitar guitar_Atrib_Original in LojaManager.instance.guitar_Attribute_List)
            {
                if (guitar_GO_Componets.guitar_ID == guitar_Atrib_Original.guitarID)
                {
                    
                    if (guitar_GO_Componets.guitar_ID == guitar_Atrib_Original.guitarID && !guitar_Atrib_Original.guitarBuy && guitar_GO_Componets.guitar_ID == guitar_ID)
                    {

                        PlayerPrefs.SetString("GuitarBtnState" + guitar_GO_Componets.guitar_ID, "Buy");
                        guitar_GO_Componets.guitar_Stats_Txt.text  = "Buy";
                       
                    }
                    if(guitar_GO_Componets.guitar_ID == guitar_Atrib_Original.guitarID && guitar_Atrib_Original.guitarBuy && guitar_GO_Componets.guitar_ID != guitar_ID)
                    {
                        PlayerPrefs.SetString("GuitarBtnState" + guitar_GO_Componets.guitar_ID, "Use");
                        guitar_GO_Componets.guitar_Img.color = Color.white;
                        guitar_GO_Componets.guitar_Stats_Txt.text = "Use";
                      
                    }
                    if(guitar_GO_Componets.guitar_ID == guitar_Atrib_Original.guitarID && guitar_Atrib_Original.guitarBuy && guitar_GO_Componets.guitar_ID == guitar_ID)
                    {
                        guitar_GO_Componets.guitar_Img.color = Color.white;
                        guitar_GO_Componets.guitar_Stats_Txt.text = "Usando";
                        PlayerPrefs.SetString("GuitarBtnState"+guitar_GO_Componets.guitar_ID, "usando");
                        PlayerPrefs.SetString("GuitarUsando", guitar_Atrib_Original.guitarSpriteName);
                       

                    }
                }
            }
        }


    }
}
