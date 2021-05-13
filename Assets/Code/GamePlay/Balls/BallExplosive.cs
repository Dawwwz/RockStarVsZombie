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
            if (collision.collider.name == "Cabeca")
            {
                rockMode.Set_Active_RockMode();
                rockMode.Set_Head_Shot_count();
                rockMode.Set_Diminuir_Spawn_Bola();
            }
                collision.gameObject.GetComponent<Inimigo>().Set_Velocity(false);
                gameObject.GetComponent<CircleCollider2D>().enabled = true;
                explosion.gameObject.GetComponent<DestroyHUD3>().danoTacada = danoTacada;
                dmgHUD();
                collision.gameObject.GetComponent<Inimigo>().Set_Damage(danoTacada);
                collision.gameObject.GetComponent<Inimigo>().Set_Life_Bar_Update();
                Instantiate(explosion, transform.position, Quaternion.identity);

        }
    }
} 

