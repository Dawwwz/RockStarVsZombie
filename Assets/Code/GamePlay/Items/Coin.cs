using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        if(transform.position.x > 8.50)
        {
           transform.position = new Vector3(8.5f, transform.position.y);
        }
    }
}
