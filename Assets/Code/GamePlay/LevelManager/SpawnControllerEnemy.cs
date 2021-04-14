using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnControllerEnemy : SpawnController
{
    [Header ("Enemy")]
    [SerializeField] protected bool spawn_CanBe_Method_Timer_Counter;
    [SerializeField] protected int[] hud_Time_Counter;
    [SerializeField] protected int hud_Time_Counter_Index;
    [SerializeField] protected int[] spawn_GO_int_TypeSelect_Random_Range;
    [SerializeField] protected int spawn_GO_int_TypeSelect_Random_Range_index;

    [SerializeField] protected int[] spawn_GO_int_TypeSelect_Random_Ranges;
    [SerializeField] protected int spawn_GO_int_TypeSelect_Random_Range_indexs;
    // Start is called before the first frame update

    private void FixedUpdate()
    {
        Set_Spawn_GameObjects_In_hud_Time_Counter();
        Set_Spawn_GameObjects_In_Standard_Cycles();
        Set_Timer();
    }

    public void Set_Spawn_GameObjects_In_hud_Time_Counter()
    {
        if (spawn_CanBe_Spawned && spawn_CanBe_Method_Timer_Counter)
        {
            Debug.Log("hud" + Mathf.Round(levelManager.Get_Time()));
            Debug.Log("array"+hud_Time_Counter[hud_Time_Counter_Index]);
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
