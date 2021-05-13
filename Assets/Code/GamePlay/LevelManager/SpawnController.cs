using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    //header
    //hud



   
    [Header("HUD TIMER")]
    [SerializeField] protected int zombie;
    [SerializeField] protected LevelManager levelManager;
    [SerializeField] protected Hud hud;
    [Header("Instantiate")]
    [SerializeField] public GameObject[] spawn_GO;
    [SerializeField] protected Transform spawn_Transform;
    [SerializeField] protected int spawn_GO_int_TypeSelect;
    [SerializeField] protected int spawn_GO_int_TypeSelectt;


    [Header("Quantidade de objetos")]
    [SerializeField] protected float[] spawn_Amount;
    [SerializeField] protected int spawn_Amount_Index;

    [Header("Bools")]
    [SerializeField] protected bool spawn_CanBe_Spawned;

    [SerializeField] protected bool spawn_CanBe_Method_Standart_Cycles;

     
    [Header(" Timer")]
    [SerializeField] protected float timer;
    [SerializeField] protected float timer_Max;
    [SerializeField] protected float timer_Max_Save;
    [SerializeField] protected bool timer_Bool;
    public GameObject coin;


    // Start is called before the first frame update
    private void Awake()
    {
        hud = FindObjectOfType<Hud>();
        levelManager = FindObjectOfType<LevelManager>();
    }
    void Start()
    {  
        // como as coisas devem começar porq sim !!!
        spawn_CanBe_Spawned = true;
        spawn_CanBe_Method_Standart_Cycles = true;
        timer_Bool = false;
        timer_Max_Save = timer_Max;
    }
 
    public void Set_Select_GameObject(GameObject[] GO, int go_Select,int go_Sellect, Vector3 spawn_Position,int select_Amount_GO = 1,bool playerPrefs = false)
    {
        for(int i = 0; i < spawn_Amount[select_Amount_GO]; i++)
        {
            Instantiate(GO[Random.Range(go_Select, go_Sellect)], spawn_Position, Quaternion.identity);
        }
    }
    public void Set_Select_GameObjec(GameObject GO, Vector3 spawn_Position)
    {
        
            Instantiate(GO, spawn_Position, Quaternion.identity);
        
    }
    public void Set_Spawn_GameObjects_In_Standard_Cycles()
    {
        if (spawn_CanBe_Spawned && spawn_CanBe_Method_Standart_Cycles)
        {

            if (levelManager.Get_Time() > 0)
            {
                Set_Select_GameObject(spawn_GO, spawn_GO_int_TypeSelect, spawn_GO_int_TypeSelectt,
                                      spawn_Transform.position,
                                      spawn_Amount_Index);
                spawn_CanBe_Method_Standart_Cycles = false;
                timer_Bool = true;
            }
        }
    }
    public void Set_Timer()
    {
        if (timer_Bool)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                spawn_CanBe_Method_Standart_Cycles = true;
                timer = timer_Max;
            }
        }
    }
    public float Get_Spawn_Recharge_Time()
    {
        return timer;
    }
   

  


}
