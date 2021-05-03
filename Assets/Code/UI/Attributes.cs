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
        if (PlayerPrefs.HasKey("hitPower"))
        {
           power.value = PlayerPrefs.GetFloat("hitPower");
        }
        else if (!PlayerPrefs.HasKey("hitPower"))
        {
            PlayerPrefs.SetFloat("hitPower", PlayerPrefs.GetFloat("hitPower") + 1);
            power.value = PlayerPrefs.GetFloat("hitPower");
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void IncreasePower()
    {
        Debug.Log(PlayerPrefs.GetFloat("hitPower"));
        PlayerPrefs.SetFloat("hitPower", PlayerPrefs.GetFloat("hitPower") +0.10f);
        power.value = PlayerPrefs.GetFloat("hitPower");

    }
}
