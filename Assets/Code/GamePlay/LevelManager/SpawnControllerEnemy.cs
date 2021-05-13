using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnControllerEnemy : SpawnController
{
    [Header("Enemy")]
    
    [SerializeField] protected bool spawn_CanBe_Method_Timer_Counter;
    [SerializeField] protected int[] hud_Time_Counter;
    [SerializeField] protected int hud_Time_Counter_Index;
    [SerializeField] protected int[] spawn_GO_int_TypeSelect_Random_Range;
    [SerializeField] protected int spawn_GO_int_TypeSelect_Random_Range_index;
    [SerializeField] public bool leveljafoi;
    [SerializeField] protected int[] spawn_GO_int_TypeSelect_Random_Ranges;
    [SerializeField] protected int spawn_GO_int_TypeSelect_Random_Range_indexs;
    // Start is called before the first frame update

    private void FixedUpdate()
    {
        if (leveljafoi)
        {
        Set_Spawn_GameObjects_In_hud_Time_Counter();
        Set_Spawn_GameObjects_In_Standard_Cycless();
        Set_Timer();
        }
    }
    public void Set_Spawn_GameObjects_In_Standard_Cycless()
    {
        if (spawn_CanBe_Spawned && spawn_CanBe_Method_Standart_Cycles)
        {

            if (levelManager.Get_Time() > 0)
            {
                Set_Select_GameObject(spawn_GO, spawn_GO_int_TypeSelect, spawn_GO_int_TypeSelectt,
                                      spawn_Transform.position,
                                      zombie);
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
                Set_Select_GameObject
                    (
                    spawn_GO, 
                    spawn_GO_int_TypeSelect_Random_Range[spawn_GO_int_TypeSelect_Random_Range_index], 
                    spawn_GO_int_TypeSelect_Random_Ranges[spawn_GO_int_TypeSelect_Random_Range_indexs], 
                    spawn_Transform.position,
                    spawn_Amount_Index
                    );
                if (hud_Time_Counter_Index < hud_Time_Counter.Length - 1)
                {
                    spawn_GO_int_TypeSelect_Random_Range_index++;
                    spawn_GO_int_TypeSelect_Random_Range_indexs++;
                    hud_Time_Counter_Index++;
                    spawn_Amount_Index++;
                }

                StartCoroutine(hudRecharg());
            }
        }
    }
    public IEnumerator hudRecharg()
    {
        yield return new WaitForSeconds(2);
        spawn_CanBe_Method_Timer_Counter = true;
    }
}
