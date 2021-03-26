using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attributes : MonoBehaviour
{
    public Slider power;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void IncreasePower()
    {
       GameManager.instanceGameManager.power += 10;
        power.value = GameManager.instanceGameManager.power ;

    }
}
