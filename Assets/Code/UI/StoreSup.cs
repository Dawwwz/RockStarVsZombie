using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreSup : MonoBehaviour
{
    public int ballID;
    public Text ballUseTxt;
    public Text ballPriceTxt;
    public Text ballName;
    public Text descricao;
    public Image ballSprite;
    public GameObject ballBtn;
    public CoinManager coin;
    public void Start()
    {
        coin = FindObjectOfType<CoinManager>();
    }
    public void Comprar()
    {

        foreach (LojaManager.Produto produto in LojaManager.instance.produtoList)
        {

          
            if (produto.ballID == ballID && !produto.ballbuy && coin.Get_coin() >= produto.ballPrice)
            {

                produto.ballbuy = true;
                UpdateCompra();
                coin.CoinDecrease(produto.ballPrice);


            }
            else if (produto.ballID == ballID && produto.ballbuy)
            {
                UpdateCompra();
            }

        }

        LojaManager.instance.lojaUpdate(ballID);


    }

    void UpdateCompra()
    {
        foreach (GameObject go in LojaManager.instance.prefabInfos)
        {
            StoreSup ss = go.GetComponent<StoreSup>();
            foreach (LojaManager.Produto produto in LojaManager.instance.produtoList)
            {
                if (produto.ballID == ss.ballID)
                {
                    if (produto.ballID == ss.ballID && !produto.ballbuy && produto.ballID == ballID)
                    {
                        ss.ballUseTxt.text = "buy";
                        LojaManager.instance.UpdateBtnTxt(ss.ballID,"buy");
                       
                    }

                    if (produto.ballID == ss.ballID && produto.ballbuy && produto.ballID == ballID)
                    {
                        ss.ballUseTxt.text = "usando";
                        LojaManager.instance.UpdateBtnTxt(ss.ballID, "usando");
                        
                        PlayerPrefs.SetInt("BallChosed", ss.ballID);

                    }
                    if (produto.ballID == ss.ballID && produto.ballbuy && produto.ballID != ballID)
                    {
                        ss.ballUseTxt.text = "use";
                        LojaManager.instance.UpdateBtnTxt(ss.ballID, "use");
                        
                    }
                }
            }
        }
    }
   
}
