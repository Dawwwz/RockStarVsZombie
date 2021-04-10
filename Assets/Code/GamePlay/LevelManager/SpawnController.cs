using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    //header
    //hud

    [Header("HUD TIMER")]

    [SerializeField] private LevelManager levelManager;
    [Header("Instantiate")]
    [SerializeField] public GameObject[] spawn_GO;
    [SerializeField] private Transform spawn_Transform;
    [SerializeField] private int spawn_GO_int_TypeSelect;
    [Header("Quantidade de objetos")]
    [SerializeField] private float[] spawn_Amount;
    [SerializeField] private int spawn_Amount_Index;
    [Header("Bools")]
    [SerializeField] private bool spawn_CanBe_Spawned;
    [SerializeField] private bool spawn_CanBe_Method_Standart_Cycles;
    [SerializeField] private bool spawn_CanBe_PlayerPrefs;
    [Header("Spawn_Hud_Time")]
    [SerializeField] private bool spawn_CanBe_Method_Timer_Counter;
    [SerializeField] private int[] hud_Time_Counter;
    [SerializeField] private int hud_Time_Counter_Index;
    [SerializeField] private int[] spawn_GO_int_TypeSelect_Random_Range;
    [SerializeField] private int spawn_GO_int_TypeSelect_Random_Range_index;
    [Header(" Timer")]
    [SerializeField] private float timer;
    [SerializeField] private float timer_Max;
    [SerializeField] private float timer_Max_Save;
    [SerializeField] private bool timer_Bool;
    [SerializeField] private int go_Select1;

    // Start is called before the first frame update
    void Start()
    {
        if(gameObject.name == "Spawn_Controller_Balls")
        {
            spawn_GO_int_TypeSelect = PlayerPrefs.GetInt("BallChosed");
            go_Select1 = PlayerPrefs.GetInt("BallChosed");
        }

        
        levelManager = FindObjectOfType<LevelManager>();
        // como as coisas devem começar porq sim !!!
        spawn_CanBe_Spawned = true;
        spawn_CanBe_Method_Standart_Cycles = true;
        timer_Bool = false;
        timer_Max_Save = timer_Max;
     

    }
    private void FixedUpdate()
    {
        Set_Spawn_GameObjects_In_Standard_Cycles();
        if (gameObject.name == "Spawn_Controller_Enemy")
        {
             Set_Spawn_GameObjects_In_hud_Time_Counter();
        }
       
        Set_Timer();
    }
    public void Set_Select_GameObject(GameObject[] GO, int go_Select, Vector3 spawn_Position,int select_Amount_GO = 1,bool playerPrefs = false)
    {
        for(int i = 0; i < spawn_Amount[select_Amount_GO]; i++)
        {
            if (playerPrefs)
            {
                Instantiate(GO[PlayerPrefs.GetInt("BallSelect"+go_Select)], spawn_Position, Quaternion.identity);
                return;
            }
            Instantiate(GO[Random.Range(go_Select, go_Select1)], spawn_Position, Quaternion.identity);
        }
    }
    public void Set_Select_GameObjectss(GameObject[] GO, int go_Select, Vector3 spawn_Position, int select_Amount_GO = 1, bool playerPrefs = false)
    {
        for (int i = 0; i < select_Amount_GO; i++)
        {
            if (playerPrefs)
            {
                Instantiate(GO[PlayerPrefs.GetInt("BallSelect" + go_Select)], spawn_Position, Quaternion.identity);
                return;
            }
            Instantiate(GO[go_Select], spawn_Position, Quaternion.identity);
        }
    }
    public void Set_Spawn_GameObjects_In_Standard_Cycles()
    {
        if (spawn_CanBe_Spawned && spawn_CanBe_Method_Standart_Cycles)
        {

            if (levelManager.Get_Time() > 0 )
             {

                Set_Select_GameObject(spawn_GO, spawn_GO_int_TypeSelect, spawn_Transform.position,spawn_Amount_Index);
                spawn_CanBe_Method_Standart_Cycles = false;
                timer_Bool = true;
             }
        }
    }
    public void Set_Spawn_GameObjects_In_hud_Time_Counter()
    {
        if (spawn_CanBe_Spawned && spawn_CanBe_Method_Timer_Counter)
        {
            if (Mathf.Round(levelManager.Get_Time()) == hud_Time_Counter[hud_Time_Counter_Index] && levelManager.Get_Time() > 0)
            {
                spawn_CanBe_Method_Timer_Counter = false;
                Set_Select_GameObject(spawn_GO,spawn_GO_int_TypeSelect_Random_Range[spawn_GO_int_TypeSelect_Random_Range_index], spawn_Transform.position,spawn_Amount_Index);
                if(spawn_Amount_Index < spawn_Amount.Length-1)
                {
                spawn_GO_int_TypeSelect_Random_Range_index++;
                hud_Time_Counter_Index++;
                spawn_Amount_Index++;
                }

                spawn_CanBe_Method_Timer_Counter = true;
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
    public void Sett_Spawn_Recharge_Time(float number)
    {
        timer_Max += number;
    }
    public float Get_Spawn_Recharge_Time()
    {
        return timer;
    }
    public void Set_Diminuir_Spawn_Bola()
    {
        if(timer_Max == timer_Max_Save)
        {
            timer_Max -= 2;
            return;
        }
        if(timer_Max >= 3.5)
        {
            Debug.Log("diminuiu2");
            timer_Max -= 0.5f;
        }
    }
    public void Set_Aumentar_Tempo_Spawn_Bola()
    {
        timer_Max = timer_Max_Save;
    }
    public void Set_Trocar_Bola()
    {
        if (spawn_GO_int_TypeSelect < 4)
        {
            spawn_GO_int_TypeSelect++;
            go_Select1++;
        }
        else if (spawn_GO_int_TypeSelect == 4)
        {
            spawn_GO_int_TypeSelect = 0;
            go_Select1 = 0;
        }

    }
}
