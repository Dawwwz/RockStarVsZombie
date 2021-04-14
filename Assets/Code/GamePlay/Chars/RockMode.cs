using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMode : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Hud hud;
    [Header("RockMode Timer")]
    [SerializeField] private float timer ;
    [SerializeField] private float timer_Max;
    [SerializeField] private bool timer_Bool;
    [Header("RockMode Utilits")]
    [SerializeField] private bool rock_Star_Aura;
    [SerializeField] private int head_Shot_Count;
    [SerializeField] private int head_Shot_Count_Save;
    [SerializeField] private bool head_Shot_Count_Bool;


    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        hud = FindObjectOfType<Hud>();
    }

    // Update is called once per frame
    void Update()
    {
        Set_Timer();
    }
    public void Set_Timer()
    {
        if (timer_Bool)
        {
            if (timer == timer_Max)
            {
                head_Shot_Count_Save = head_Shot_Count;
                rock_Star_Aura = true;
                player.Set_Sayajin_Aura();
            }

            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                if (head_Shot_Count == head_Shot_Count_Save)
                {
                    rock_Star_Aura = false;
                    player.Set_Sayajin_Aura_off();
                    timer_Bool = false;
                    Set_Head_Shot_count_O();
                    Set_Aumentar_Tempo_Spawn_Bola();
                    timer = timer_Max;
                    return;
                }
                timer = timer_Max;

            }
        }
    }
    public void Set_Active_RockMode()
    {
        timer_Bool = true;
    }
    public void Set_Head_Shot_count()
    {
        head_Shot_Count += 1;
        hud.Set_rockMOdeUI(head_Shot_Count);
    }
    public void Set_Head_Shot_count_O()
    {
        hud.Set_rockMOdeUIF();
        head_Shot_Count = 0;
        head_Shot_Count_Save = 0;
    }

    public bool Get_Rock_Star_Aura()
    {
       return rock_Star_Aura;
    }
    public void Set_Rock_Star_Aura()
    {
         rock_Star_Aura = false;
    }
    public int Get_Head_Shot_count ()
    {
        return head_Shot_Count;
    }
    
    public void Set_Diminuir_Spawn_Bola()
    {
        player.Set_Diminuir_Spawn_Bola();
    }
    public void Set_Aumentar_Tempo_Spawn_Bola()
    {
        player.Set_Aumentar_Tempo_Spawn_Bola();
    }
}
