using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Particlee : MonoBehaviour
{
    
    public GameObject Sayajin;
    public GameObject refsp;
    public GameObject part;
    public TrailRenderer trailrender;
    private void Start()
    {
       
        refsp = Instantiate(part, new Vector2(transform.position.x + 0.5f, transform.position.y - 1), part.transform.rotation) as GameObject;
    }
    
    public void Set_Sayajin_Aura()
    {
        Sayajin.SetActive(true);
    }
    public void Set_Sayajin_Aura_off()
    {
        Sayajin.SetActive(false);
    }


}
