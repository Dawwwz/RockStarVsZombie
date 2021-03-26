using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BallDog : Ball
{
   
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("inimigo"))
        {
            if (podeDarDano)
            {
                dmgHUD();
                collision.gameObject.GetComponent<Inimigo>().Set_Damage(danoTacada);
                collision.gameObject.GetComponent<Inimigo>().Set_Life_Bar_Update();
            }
        }
    } 
}

  

