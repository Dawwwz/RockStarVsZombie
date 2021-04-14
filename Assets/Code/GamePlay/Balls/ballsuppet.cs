using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballsuppet : MonoBehaviour
{

    private Player player;
    public float dogHeal ;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        dogHeal = player.Get_HitPower();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
  
        if (collision.gameObject.CompareTag("pet"))
        {

            collision.gameObject.GetComponent<Pet>().buffado = true;
            collision.gameObject.GetComponent<Pet>().Set_Life(dogHeal);
           // collision.gameObject.GetComponent<Pet>().HudHPUp();

        }
    }
}
