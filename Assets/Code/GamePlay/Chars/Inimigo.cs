﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Inimigo : Character
{
    [Header("CheckGround")]
    [SerializeField] private Transform pezin;
    [SerializeField] private float tamanho;
    [SerializeField] private LayerMask chao ;
    [SerializeField] private bool piso;
    [SerializeField] private bool congelado,stunado;

    void Start()
    {

        Set_Zombie_Fly();
        leafControler.Set_Leaf_Spawn();

        lifeBar.SetLifeBarSpawn();
        lifeBar.SetLifeBarTransform(lifeBarPos);
    }
    private void FixedUpdate()
    {
        Onground();
        
        Vida();
        if(lifeBar.Get_Life_Bar_GO() != null)
        {
            lifeBar.SetLifeBarTransform(lifeBarPos);
            Debug.Log("lifebar");
        }
        if (transform.position.x < -5)
        {
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }
    void Vida()
    {
        if (life <= 0)
        {
            if (!dead)
            {
                // GameManager.instanceGameManager.zombiesAmount++; // SPAWN CONTROLER 
                if (
                    leafControler.Get_Leaf_can_Spawn() && 
                    PlayerPrefs.GetInt("Level" + levelManager.scenaAtualInt) == 0 
                    && leafControler.Get_Leaf_Chance_Spawn() == 1
                    )
                {
                    leafControler.Set_leaf_Can_Spawn(false);
                    leafControler.Set_Ho_Get_leaf(false, false, false, true);
                    leafControler.Set_Spawn_Leaf(lifeBarPos);
                }
                dead = true;
                lifeBar.Get_Life_Bar_GO().GetComponent<DestroyHud1>().destroys = true;
                Destroy(gameObject);
            }
        }
    }
    public void Set_Zombie_Fly()
    {
        if (rb.gravityScale == 0)
        {
            gameObject.transform.position = new Vector3(transform.position.x, transform.position.y + 3.4f);
            rb.constraints = RigidbodyConstraints2D.FreezePositionY;
        }
    }
    public GameObject Get_Life_Bar_GO()
    {
        return lifeBar.Get_Life_Bar_GO();
    }
   
    public void Onground()
    {
        if (!congelado && !stunado)
        {    
            piso = Physics2D.OverlapCircle(pezin.position, tamanho, chao);
            Debug.Log(piso);
            if (piso)
            {
                Update_Movement();
            }
        }
    }
    public IEnumerator VelRechargeTime(float timer)
    {
        stunado = true;
        Set_Velocity(false);
        yield return new WaitForSeconds(timer);
        Set_Velocity(true);
        stunado = false;
    }
    public void VelRechargeTimes(float a)
    {
        StartCoroutine(VelRechargeTime(a));
    }
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(pezin.position, tamanho);
    }
}

