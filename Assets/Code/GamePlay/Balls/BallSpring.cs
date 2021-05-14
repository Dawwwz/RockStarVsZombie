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
            if (collision.collider.name == "Cabeca")
            {
            rockMode.Set_Active_RockMode();
            rockMode.Set_Head_Shot_count();
            rockMode.Set_Diminuir_Spawn_Bola();
            }
            dmgHUD();
            if (danoTacada <= 0.001)
            {
            Destroy(gameObject);
            }
            if (podeDarDano)
            {
                collision.gameObject.GetComponent<Inimigo>().Set_Damage(danoTacada);
                collision.gameObject.GetComponent<Inimigo>().Set_Life_Bar_Update();
                Debug.Log(danoTacada);
                StartCoroutine(CD());
            }
            podecontar = true;
            contagem++;
            audioScript.SoundEffect(2);
        }
    }
    public void OnCollisionStay2D(Collision2D collision)
    {    
        if (collision.gameObject.tag == "inimigo")
        {
                    dmgHUD();
                    collision.gameObject.GetComponent<Inimigo>().Set_Damage(danoTacada);
                    collision.gameObject.GetComponent<Inimigo>().Set_Life_Bar_Update();
                    audioScript.SoundEffect(2);
                    if (danoTacada == 0)
                            {
                                Destroy(gameObject);
                            }
        }
    }
    IEnumerator morrer()
    {
        morre = false;
        contagemMax = contagem;
        yield return new WaitForSeconds(7);
        if(contagem == contagemMax)
        {
            Destroy(gameObject);
        }
        morre = true;
    }
  
}
