using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("System's to help")]
    [SerializeField] protected SpawnController spawnController;
    [SerializeField] protected Hud hud;
    [SerializeField] protected LeafControler leafControler;
    [SerializeField] protected Particlee particle;
    [SerializeField] protected HitTarget hitTarget;
    [SerializeField] protected RockMode rockMode;
    [SerializeField] protected LevelManager levelManager;

    [SerializeField] protected LifeBar lifeBar;
    [SerializeField] protected Transform lifeBarPos;
    [Header("Life")]
    [SerializeField] protected float lifeMax;
    [SerializeField] protected float life;
    [SerializeField] protected bool  dead;
    [Header("Hit")]
    [SerializeField] protected  float hitPower;
    [SerializeField] protected float hitSpeed;
    [SerializeField] public bool  hitBool;
    [SerializeField] protected bool  hitBoolAux;
    [Header("movement")]
    [SerializeField] protected bool  movementBool;
    [SerializeField] protected bool movementBooll;
    [SerializeField] protected float movementVelocity;
    [SerializeField] protected float movementVelocityMax;
    [SerializeField] protected Rigidbody2D rb;
    [Header("Animação")]
    [SerializeField] protected Animator rigAnime;
    private void Awake()
    {
        Set_Search_For_Refs();
        rb = GetComponent<Rigidbody2D>();
    }
    public float Get_Life()
    {
        return life;
    }
    public void Set_Damage(float value)
    {
        if (life > 0 && hitBool)
        {
            this.life -= value;
            StartCoroutine(HitRechargeTime(hitSpeed));
        }
    }
    public void Set_Life(float value)
    {
        if (life <= lifeMax)
        {
            this.life += value;
        }
    }
    public void Set_Velocity(bool par_MovementBool)
    {
       
        movementBool = par_MovementBool;
    }
    public void Set_VelocityFloat(float par_Velocity)
    {
        movementVelocity = par_Velocity;
      
    }
    public void Update_Movement()
    {
        if (movementBool && !dead)
        {
            rb.velocity = new Vector3(movementVelocity, rb.velocity.y);
            if (transform.position.y < -3)
            {
                transform.position = new Vector2(transform.position.x, -2);
                return;
            }
        }
 
    }
    
    public void RigAnimation(bool idle,bool walk,
                              bool hit,bool hitEnergyze,
                              bool dying
                             )
    {   
        rigAnime.SetBool("parado", idle);
        //rigAnime.SetBool("andando", walk);
        rigAnime.SetBool("segurandodano", hitEnergyze);
        rigAnime.SetBool("batendo", hit);
        rigAnime.SetBool("morrendo", dying);
    }
    public void Set_Search_For_Refs()
    {
        spawnController = GameObject.Find("Spawn_Controller_Balls").GetComponent<SpawnController>();
        leafControler = FindObjectOfType<LeafControler>();
        hitTarget = FindObjectOfType<HitTarget>();
        rockMode = FindObjectOfType<RockMode>();
        particle = FindObjectOfType<Particlee>();
        hud = FindObjectOfType<Hud>();
        levelManager = FindObjectOfType<LevelManager>();
    }
    public void Set_Life_Bar_Update()
    {
        lifeBar.Set_Life_Bar_Update(life, lifeMax);
    }
    public float Get_HitPower()
    {
        return hitPower;
    }
    IEnumerator HitRechargeTime(float timer)
    {
        hitBool = false;
        yield return new WaitForSeconds(timer);
        hitBool = true;
    }
   public IEnumerator VelRechargeTime(float timer)
    {
        movementBool = false;
        yield return new WaitForSeconds(timer);
        movementBool = true;
    }
    public void VelRechargeTimes(float a)
    {
        StartCoroutine(VelRechargeTime(a));
    }
}
