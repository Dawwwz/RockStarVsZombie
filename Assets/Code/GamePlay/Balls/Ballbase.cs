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
                
                if (collision.collider.name == "Cabeca")
                {
                    rockMode.Set_Active_RockMode();
                    rockMode.Set_Head_Shot_count();
                    rockMode.Set_Diminuir_Spawn_Bola();
                }
                audioScript.SoundEffect(2);
                dmgHUD();  
                collision.gameObject.GetComponent<Inimigo>().Set_Damage(danoTacada);
                collision.gameObject.GetComponent<Inimigo>().Set_Life_Bar_Update();
            }
        }
    }
  
}

  

