using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyHud1 : MonoBehaviour
{
    public bool destroys;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(destroys == true)
        {
            Destroy(gameObject,0.3f);
        }
    }
}
