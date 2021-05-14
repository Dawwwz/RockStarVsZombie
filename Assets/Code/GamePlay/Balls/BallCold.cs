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
            if (collision.collider.name == "Cabeca")
            {
                rockMode.Set_Active_RockMode();
                rockMode.Set_Head_Shot_count();
                rockMode.Set_Diminuir_Spawn_Bola();
            }
            audioScript.SoundEffect(2);
            gameObject.GetComponent<CircleCollider2D>().enabled = true;
            dmgHUD();
            collision.gameObject.GetComponent<Inimigo>().Set_Damage(danoTacada);
            explosive.gameObject.GetComponent<DestroyHUD3>().danoTacada = danoTacada;
            collision.gameObject.GetComponent<Inimigo>().Set_Life_Bar_Update();
            Instantiate(explosive, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    
    }
}
