using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class LojaManager : MonoBehaviour
{
    public static LojaManager instance;

    // BALL STORE
    [Header("Ball Store")]
    public List<Produto> produtoList = new List<Produto>();
    public List<GameObject> prefabInfos = new List<GameObject>();
    public GameObject produtoPrefabGen;
    public Transform produtoPosition;

    // guitar STORE
    [Header("Guitar Store")]
    public List<Guitar> guitar_Attribute_List = new List<Guitar>();
    public List<GameObject> guitar_GO_List = new List<GameObject>();
    public GameObject guitar_GO;
    public Transform guitar_Store_Position;

    // FOOD STORE
    [Header("Food Store")]
  
    public List<GameObject> food_GO_List = new List<GameObject>();
    public GameObject food_GO;
    public Transform food_Store_Position;
    
    [System.Serializable]
    public class Produto
    {
        public int ballID;
        public string ballSpriteName;
        public float ballPrice;
        public bool ballbuy;
        public string ballBtnName;
      
    }
    [System.Serializable]
    public class Guitar
    {
        public int guitarID;
        public string guitarSpriteName;
        public float guitarPrice;
        public string guitarName;
        public string guitarBtnTxt;
        public bool guitarBuy;
        public string descricao;
    }

  
   


    void Awake ()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        CreateGuitarStore();
        CriandoLoja();

    }

    //
    // BALL STORE
    //
   void CriandoLoja()
    {
        foreach(Produto produto in produtoList)
        {
            //POSICIONANDO PRODUTOS
            GameObject produtoPrefab = Instantiate(produtoPrefabGen) as GameObject; 
            produtoPrefab.transform.SetParent(produtoPosition, false);
            StoreSup atribProdutos = produtoPrefab.GetComponent<StoreSup>();

            //ATRIB DOS PRODUTOS
            atribProdutos.ballName.text = produto.ballSpriteName;
            atribProdutos.ballID =  produto.ballID;
            atribProdutos.ballPriceTxt.text = produto.ballPrice.ToString();
            if (PlayerPrefs.GetInt("produtoLib"+atribProdutos.ballID) == 1)
            {
                produto.ballbuy = true;
            }
            if (PlayerPrefs.HasKey("btntxtup"+atribProdutos.ballID) && produto.ballbuy)
            {

                atribProdutos.ballUseTxt.text = PlayerPrefs.GetString("btntxtup" + atribProdutos.ballID);
            }
            if (produto.ballbuy == true)
            {
               
                atribProdutos.ballSprite.sprite = Resources.Load<Sprite> ("Sprites/"+produto.ballSpriteName) ;
                atribProdutos.ballSprite.color = Color.white;
                atribProdutos.ballPriceTxt.text = "Comprado";
               
            }
            else
            {
      
                atribProdutos.ballSprite.sprite = Resources.Load<Sprite> ("Sprites/"+produto.ballSpriteName);
                atribProdutos.ballSprite.color = Color.black;
            }
           
            //INFOS DA PREFAB CRIADA
            prefabInfos.Add(produtoPrefab);
           
        }
    }

   public void lojaUpdate(int ID_bola)
    {
        foreach(GameObject preFab in prefabInfos)
        {
            StoreSup infos = preFab.GetComponent<StoreSup>();
          
            if (infos.ballID == ID_bola)
            {
                
                foreach (Produto produto in produtoList)
                {
                    if(produto.ballID == ID_bola)
                    {

                    if (ID_bola == produto.ballID && produto.ballbuy )
                    {
                       
                        infos.ballSprite.sprite = Resources.Load<Sprite> ("Sprites/"+produto.ballSpriteName);
                            infos.ballSprite.color = Color.white;
                            infos.ballPriceTxt.text = "comprado";
                            ProdutoSave(infos.ballID);


                        }
                    else
                    {
                        
                        infos.ballSprite.sprite = Resources.Load<Sprite> ("Sprites/"+produto.ballSpriteName);
                            infos.ballSprite.color = Color.black;
                        }
                    }
                }
            }
        }
    }
    
    void ProdutoSave(int idBall)
    {
        foreach(GameObject go in prefabInfos)
        {
            StoreSup ss = go.GetComponent<StoreSup>();
            if (ss.ballID == idBall)
            {
                PlayerPrefs.SetInt("produtoLib" + ss.ballID, ss.ballBtn ? 1 : 0);
            }
        }
    }

    public void UpdateBtnTxt(int ballid, string used)
    {
        foreach (GameObject go in prefabInfos)
        {
            StoreSup ss = go.GetComponent<StoreSup>();
            if (ss.ballID == ballid)
            {
                PlayerPrefs.SetString("btntxtup" + ss.ballID, used);
              
            }
        }
    }

    //
    // GUITAR STORE
    //
   /* public void GuitarupdatebtnUse(int ballid,string btnState)
    {
        foreach(GameObject guitar_GO in guitar_GO_List)
        {
            Guitar guitar = guitar_GO.GetComponent<Guitar>();
            if(guitar.guitarID == ballid)
            {
                PlayerPrefs.SetString("btntxtup" + ballid, btnState);
            }
        }
    }*/

    public void CreateGuitarStore()
    {
        foreach (Guitar guitar_Attribute in guitar_Attribute_List)
        {
            GameObject guitar_GO = Instantiate(this.guitar_GO) as GameObject;
            guitar_GO.transform.SetParent(guitar_Store_Position, false);
            Guitar_Store guitar_Store = guitar_GO.GetComponent<Guitar_Store>();
            guitar_Store.guitar_ID = guitar_Attribute.guitarID;
            guitar_Store.guitar_Name.text = guitar_Attribute.guitarSpriteName;
            guitar_Store.guitar_Price.text = guitar_Attribute.guitarPrice.ToString();
            guitar_GO_List.Add(guitar_GO);
                
            if (PlayerPrefs.GetInt("GuitarBuy"+guitar_Attribute.guitarID) == 1)
            {
                Debug.Log((PlayerPrefs.GetInt("GuitarBuy" + guitar_Attribute.guitarID)));
                guitar_Store.guitar_Img.sprite = Resources.Load<Sprite>("Sprites/" + guitar_Attribute.guitarSpriteName);
                guitar_Store.guitar_Img.color = Color.white;
                guitar_Attribute.guitarBuy = true;
                guitar_Store.guitar_Price.text = "Comprado";
            }
            if (PlayerPrefs.HasKey("GuitarBtnState" + guitar_Attribute.guitarID) && guitar_Attribute.guitarBuy)
            {

                guitar_Store.guitar_Img.sprite = Resources.Load<Sprite>("Sprites/" + guitar_Attribute.guitarSpriteName);
                guitar_Store.guitar_Img.color = Color.white;
                guitar_Store.guitar_Stats_Txt.text = PlayerPrefs.GetString("GuitarBtnState" + guitar_Attribute.guitarID);
            }
            else if (!guitar_Attribute.guitarBuy)
            {
               
                guitar_Store.guitar_Img.sprite = Resources.Load<Sprite>("Sprites/" + guitar_Attribute.guitarSpriteName);
                guitar_Store.guitar_Img.color = Color.black;
            }
            


        }
    } 
}
