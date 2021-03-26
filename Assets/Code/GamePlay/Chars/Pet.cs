﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
public class Pet : Character
{
    public bool voltando;
    public bool indo;
    public bool parado;
    public bool buffado;
    public bool petTelp;

    void Start()
    {
        lifeBar.SetLifeBarSpawn();
        lifeBar.SetLifeBarTransform(lifeBarPos);
        Set_IA_Parado();
    }
    private void FixedUpdate()
    {
        if(life > lifeMax) // colocar na hora do hit para diminuir consumo d ram;
        {
            life = lifeMax;
        }
        lifeBar.SetLifeBarTransform(lifeBarPos); // atualizando posição da barra d vida
        lifeBar.Set_Life_Bar_Update(life, lifeMax); // atualiza dano da hud

        Update_Movement();
        Set_IA_Pet_Voltar();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag ("Coin") )
        {
            Destroy(collision.gameObject);
            GameManager.instanceGameManager.coinEphemeral += 100;
           
            Hud.instance.AttHuds();
        }

        if (collision.gameObject.CompareTag("leaf"))
        {
            Destroy(collision.gameObject.GetComponent<Rigidbody2D>());
            collision.gameObject.transform.SetParent(transform, true);
            collision.transform.position = new Vector2(transform.position.x , transform.position.y + 1.2f) ;
            leafControler.Set_Ho_Get_leaf(false,true,false,false);           
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
        if (collision.gameObject.CompareTag("inimigo"))
        {    
            if (!voltando)
            {
                Inimigo a = collision.gameObject.GetComponent<Inimigo>();
                if (a != null)
                {
                    Set_Damage(a.Get_HitPower());
                    Set_Life_Bar_Update();
                    if (buffado)
                    {
                         a.Set_Damage(hitPower);
                         a.Set_Life_Bar_Update();                            
                    } 
                } 
            }
        } 
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("inimigo"))
        {
            if (!voltando)
            {

                if (!voltando)
                {
                    Inimigo a = collision.gameObject.GetComponent<Inimigo>();
                    if (a != null)
                    {
                        Set_Damage(a.Get_HitPower());
                        Set_Life_Bar_Update();
                        if (buffado)
                        {
                            gameObject.transform.localScale = new Vector2(1, 2.4f);
                            a.Set_Damage(hitPower);
                            a.Set_Life_Bar_Update();
                        }
                    }
                } 
                else if (!hitBool && !voltando && petTelp)
                {
                    Set_Teleport();
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag =="PlayerSub")
        {
            if(transform.childCount > 1)
            {
                    transform.GetChild(1).gameObject.tag = "Untagged";
                    leafControler.Set_Ho_Get_leaf(true, false, false, false);
                    GameObject lef = transform.GetChild(1).gameObject;
                    lef.transform.SetParent(collision.transform, true);
                    lef.transform.position = new Vector2(collision.transform.position.x, collision.transform.position.y + 1.6f);             
            }
            Set_IA_Parado();

        }
    }
    IEnumerator CD()
    {

        yield return new WaitForSeconds(hitSpeed);

        hitBool = true;

    }
    IEnumerator CDtelep(float cdTelep)
    {
        petTelp = false;
        yield return new WaitForSeconds(cdTelep);
        petTelp = true;
    }
    public void Set_Buff_Pet()
    {
        if (!voltando && petTelp && buffado) 
        {
            if (transform.position.y < -2.5)
            {
                transform.position = new Vector2(transform.position.x, -2.3f);
            }
            GameObject[] ver = GameObject.FindGameObjectsWithTag("inimigo");
            for (int i = 0; i < ver.Length; i++)
            {
                if (ver[i].transform.position.x <= transform.position.x && ver[i].transform.position.y >= 2.7)
                {

                    petTelp = false;
                    StartCoroutine("CDtelep");
                    transform.position = new Vector2(ver[i].transform.position.x - 1f, ver[i].transform.position.y + 1);
                }
            }
        }
        
    }
    public void Set_IA_Pet_Voltar()
    {
        //
        //CONDIÇÕES PARA VOLTAR
        //
            // AJEITAR PARADA DA FOLLHAAA SKALE E VOLTAR NAO TA COLIDINDO QUANDO VOLTAA
            if ( !voltando && life <= 0 || transform.position.x > 12.5f  /* || transform.childCount > 1*/)
            {
                gameObject.GetComponent<CapsuleCollider2D>().size = new Vector2(gameObject.GetComponent<CapsuleCollider2D>().size.x, 1);
                gameObject.transform.localScale = new Vector2(1, 1);
                gameObject.GetComponent<CapsuleCollider2D>().usedByEffector = true;
                movementVelocity = 5;
                if(movementVelocity > 0)
                {
                    movementVelocity *= -1;
                }
                voltando = true;
            }
        
    }
    public void Set_IA_Pet_Avançar()
    {
        //
        //coNDIÇÃO PARA IR DNV
        // 
        
            if (transform.position.x < -8 && !voltando && parado)
            {
                gameObject.GetComponent<CapsuleCollider2D>().usedByEffector = false;
                movementVelocity = 2;
                movementBool = true;
                parado = false;
                if(movementVelocity < 0)
                {
                movementVelocity = movementVelocity * -1;
                }
            }
        
    }
    public void Set_IA_Parado()
    {
        // colidiu com o player
        movementVelocity = 0;
        movementBool = false;
        life = lifeMax;
        indo = false;
        voltando = false;
        parado = true;
    }
    public void Set_Teleport()
    {
        GameObject[] verificaInimigo = GameObject.FindGameObjectsWithTag("inimigo");
        for (int i = 0; i < verificaInimigo.Length; i++)
        {
            if (verificaInimigo[i].transform.position.x <= transform.position.x
                && verificaInimigo[i].transform.position.y >= 2.7)
            {
                StartCoroutine(CDtelep(3));
                transform.position = new Vector2(verificaInimigo[i].transform.position.x - 1f, verificaInimigo[i].transform.position.y + 1);
            }
        }
    }
    
}