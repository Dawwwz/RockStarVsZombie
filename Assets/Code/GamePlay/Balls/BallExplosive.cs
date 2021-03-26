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

            collision.gameObject.GetComponent<Inimigo>().Set_Velocity(false);
            gameObject.GetComponent<CircleCollider2D>().enabled = true;

            // get > circle collider inimigo;
            if (podeDarDano && collision != null)
            {
                dmgHUD();
                collision.gameObject.GetComponent<Inimigo>().Set_Damage(danoTacada);
                collision.gameObject.GetComponent<Inimigo>().Set_Life_Bar_Update();
                explosion.gameObject.GetComponent<DestroyHUD3>().danoTacada = danoTacada;
                Instantiate(explosion, transform.position, Quaternion.identity);

            }
        }
    }
  
}
