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

            gameObject.GetComponent<CircleCollider2D>().enabled = true;
            if (podeDarDano && collision != null && collision.gameObject.GetComponent<Inimigo>().Get_Life() > 0)
            {

                dmgHUD();
                collision.gameObject.GetComponent<Inimigo>().Set_Damage(danoTacada);
                explosive.gameObject.GetComponent<DestroyHUD3>().danoTacada = danoTacada;
                collision.gameObject.GetComponent<Inimigo>().Set_Life_Bar_Update();
                Instantiate(explosive, transform.position, Quaternion.identity);
                
            }
        }
    
    }
}
