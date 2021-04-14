using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnControlerBall : SpawnController
{
    
    // Start is called before the first frame update
    private void OnEnable()
    {
        spawn_GO_int_TypeSelect = PlayerPrefs.GetInt("BallChosed");
        spawn_GO_int_TypeSelectt = PlayerPrefs.GetInt("BallChosed");
        hud.ArrowBGG(spawn_GO[spawn_GO_int_TypeSelect].GetComponent<SpriteRenderer>().sprite);
    }

    private void FixedUpdate()
    {
        Set_Spawn_GameObjects_In_Standard_Cycless();
        Set_Timer();
    }
    public void Set_Trocar_Bola()
    {
        if (spawn_GO_int_TypeSelect < 4)
        {
            spawn_GO_int_TypeSelect++;
            spawn_GO_int_TypeSelectt++;
            hud.ArrowBGG(spawn_GO[spawn_GO_int_TypeSelect].GetComponent<SpriteRenderer>().sprite);
        }
        else if (spawn_GO_int_TypeSelect == 4)
        {
            spawn_GO_int_TypeSelect = 0;
            spawn_GO_int_TypeSelectt = 0;
            hud.ArrowBGG(spawn_GO[spawn_GO_int_TypeSelect].GetComponent<SpriteRenderer>().sprite);
        }

    }
    public void Set_Aumentar_Tempo_Spawn_Bola()
    {
        timer_Max = timer_Max_Save;
    }
    public void Set_Diminuir_Spawn_Bola()
    {
        if (timer_Max == timer_Max_Save)
        {
            timer_Max -= 2;
            return;
        }
        if (timer_Max >= 3.5)
        {
            Debug.Log("diminuiu2");
            timer_Max -= 0.5f;
        }
    }
    public void Set_Spawn_GameObjects_In_Standard_Cycless()
    {
        if (spawn_CanBe_Spawned && spawn_CanBe_Method_Standart_Cycles)
        {

            if (!levelManager.gameWin && !levelManager.gameLose )
            {
                Set_Select_GameObject(spawn_GO, spawn_GO_int_TypeSelect, spawn_GO_int_TypeSelectt,
                                      spawn_Transform.position,
                                      spawn_Amount_Index);
                spawn_CanBe_Method_Standart_Cycles = false;
                timer_Bool = true;
            }
        }
    }
}
