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
        if(transform.position.x > 8.6 || transform.position.x < -8.70 || transform.position.y < -5)
        {
           transform.position = new Vector3(8.5f, -1);
           if(GetComponent<Rigidbody2D>() != null)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }
        }
    }
}
