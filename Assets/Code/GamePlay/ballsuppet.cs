using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballsuppet : MonoBehaviour
{
  
    public float dogHeal = Player.ballPowerImpulse;
    // Start is called before the first frame update
    void Start()
    {
      
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
            collision.gameObject.GetComponent<Pet>().vida += dogHeal;
            collision.gameObject.GetComponent<Pet>().HudHPUp();

        }
    }
}
