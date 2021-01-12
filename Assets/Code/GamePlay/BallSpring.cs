using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using Unity.Mathematics;

public class BallSpring : Ball
{
    public bool morre;
    public int contagem;
    public int contagemMax;
    public bool podecontar;
    void LateUpdate()
    {
        if (podecontar)
        {
            if (morre)
            {
                StartCoroutine("morrer");
            }
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "inimigo")
        {

            if (podeDarDano)
            {
                if (collision != null)
                {
                    
                    dmgHUD();
                    if (danoTacada <= 0.001)
                    {
                        Destroy(gameObject);
                    }
                    if (collision.gameObject.GetComponent<Inimigo>().vida > 0)
                    {
                        podecontar = true; ;
                        contagem++;
                    collision.gameObject.GetComponent<Inimigo>().vida -= danoTacada;
                        if (collision.gameObject.GetComponent<Inimigo>().lifeBartrue != null)
                        {
                          collision.gameObject.GetComponent<Inimigo>().lifeBartrue.GetComponent<Image>().fillAmount = collision.gameObject.GetComponent<Inimigo>().vida / collision.gameObject.GetComponent<Inimigo>().vidaMax;
                        }
                    }
                    else
                    {
                        collision = null;
                    }
                }
            }
        }
    }
    public void OnCollisionStay2D(Collision2D collision)
    {
            
        if (collision.gameObject.tag == "inimigo")
        {

            if (podeDarDano && collision != null)
            {
                    dmgHUD();
                    if (danoTacada == 0)
                    {
                        Destroy(gameObject);
                    }
                    if (collision.gameObject.GetComponent<Inimigo>().vida > 0)
                    {
                        collision.gameObject.GetComponent<Inimigo>().vida -= danoTacada;
                        collision.gameObject.GetComponent<Inimigo>().lifeBartrue.GetComponent<Image>().fillAmount = collision.gameObject.GetComponent<Inimigo>().vida / collision.gameObject.GetComponent<Inimigo>().vidaMax;
                    }
                    else
                    {
                        collision = null;
                    }                 
            }
        }
    }
    IEnumerator morrer()
    {
        morre = false;
        contagemMax = contagem;
        yield return new WaitForSeconds(12);
        if(contagem == contagemMax)
        {
            Destroy(gameObject);
        }
        morre = true;
    }
  
}
