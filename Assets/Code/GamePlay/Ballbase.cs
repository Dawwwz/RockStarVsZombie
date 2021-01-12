using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Ballbase : Ball
{
   
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("inimigo"))
        {
            if (podeDarDano)
            {
                
                collision.gameObject.TryGetComponent<Inimigo>(out Inimigo component);
                dmgHUD();
                if (component.vida > 0)
                {
                    
                    
                     component.vida -= danoTacada;
                    if (collision.gameObject.GetComponent<Inimigo>().lifeBartrue != null)
                    {
                        collision.gameObject.GetComponent<Inimigo>().lifeBartrue.GetComponent<Image>().fillAmount = collision.gameObject.GetComponent<Inimigo>().vida / collision.gameObject.GetComponent<Inimigo>().vidaMax;
                    }
                }          
            }
        }
    }
  
}

  

