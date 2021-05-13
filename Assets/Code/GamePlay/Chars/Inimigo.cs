
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
                spawnController.Set_Select_GameObjec(spawnController.coin, new Vector3 (transform.position.x,transform.position.y+3));
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
        if (!congelado && !stunado && rb.gravityScale == 1)
        {    
            piso = Physics2D.OverlapCircle(pezin.position, tamanho, chao);
            if (piso)
            {
                RigAnimationn(false, true);
                Update_Movement();
            }
        }
        else if (!congelado && !stunado && rb.gravityScale == 0)
        {
                RigAnimationn(false, true);
                Update_Movement();
           
        }
        else if(congelado || stunado)
        {
            RigAnimationn(true, false);
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
    public void State(bool stun, bool cold)
    {
        stunado = stun;
        congelado = cold;
    }
}

