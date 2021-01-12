using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
//using Unity.Mathematics;

public class BallCold : Ball
{
    public GameObject explosive;
    public List<GameObject> zombie = new List<GameObject>();

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("inimigo"))
        {
            collision.gameObject.GetComponent<Inimigo>().pararDeColidir = true;
            gameObject.GetComponent<CircleCollider2D>().enabled = true;
            if (podeDarDano && collision != null && collision.gameObject.GetComponent<Inimigo>().vida > 0)
            {

                dmgHUD();
                collision.gameObject.GetComponent<Inimigo>().vida -= danoTacada;
                explosive.gameObject.GetComponent<DestroyHUD3>().danoTacada = danoTacada;

                if (collision.gameObject.GetComponent<Inimigo>().lifeBartrue != null)
                {
                    collision.gameObject.GetComponent<Inimigo>().lifeBartrue.GetComponent<Image>().fillAmount = collision.gameObject.GetComponent<Inimigo>().vida / collision.gameObject.GetComponent<Inimigo>().vidaMax;
                    Instantiate(explosive, transform.position, Quaternion.identity);
                }
            }
        }
    
    }
}
