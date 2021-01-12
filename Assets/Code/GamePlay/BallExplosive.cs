using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class BallExplosive : Ball
{
    public GameObject explosion;
    

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("inimigo"))
        {
            
            collision.gameObject.GetComponent<Inimigo>().explodiu = true;
            gameObject.GetComponent<CircleCollider2D>().enabled = true;
           
             collision.gameObject.GetComponent<Inimigo>().pararDeColidir = true;
            if (podeDarDano && collision != null && collision.gameObject.GetComponent<Inimigo>().vida > 0)
            {
                dmgHUD();
               collision.gameObject.GetComponent<Inimigo>().vida -= danoTacada;
                explosion.gameObject.GetComponent<DestroyHUD3>().danoTacada = danoTacada;
                if (collision.gameObject.GetComponent<Inimigo>().lifeBartrue != null)
                {
                    collision.gameObject.GetComponent<Inimigo>().lifeBartrue.GetComponent<Image>().fillAmount = collision.gameObject.GetComponent<Inimigo>().vida / collision.gameObject.GetComponent<Inimigo>().vidaMax;
                    Instantiate(explosion, transform.position,Quaternion.identity);
                }

            }
        }
    }
  
}
